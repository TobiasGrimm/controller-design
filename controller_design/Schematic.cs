using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using controller_design.Integrators_and_Registers;

namespace controller_design.Schematic
{
    /// <summary >
    /// Interface for the Simulation of a Schematic
    /// </summary >
    public interface ISimulatable
    {
        /// <summary>
        /// Calculate one time step.
        /// </summary>
        /// <param name="Ts">Sample Time</param>
        /// <returns>Result of one time step calculation</returns>
        float do_one_step(float Ts);
        /// <summary>
        /// Set the input value for the next step calculation
        /// </summary>
        /// <param name="x_in">The input value</param>
        void set_input(float x_in);
        /// <summary>
        /// Reset all old time domains, and input values to 0.
        /// </summary>
        void reset();
        /// <summary>
        /// You can register here, if you want to know when a calculation of one step is done.
        /// </summary>
        event OutputEventHandler I_am_finish;
        /// <summary>
        /// Connect this input with the output of another ISimulatable object in your Schematic.
        /// </summary>
        /// <param name="Target_output">You want to connect with</param>
        void connect_this_Input_with(ISimulatable Target_output);
        /// <summary>
        /// Disconnect this Input from Target Output.
        /// </summary>
        /// <param name="Target_output">The Target Output you want to disconnect</param>
        void disconnect_this_Input_from(ISimulatable Target_output);
    }
    /// <summary >
    /// Delegate for the Output Event when a step is done 
    /// </summary >
    public delegate void OutputEventHandler(float output);
    /// <summary >
    /// A form of an Digital Filter.
    /// </summary >
    public class Transferfunction : ISimulatable
    {
        #region Variables
        /// <summary>
        /// Filter Coefficients a (backward) and b (forward)
        /// </summary>
        protected float[] _a, _b;
        /// <summary>
        /// A Register for the internal integration
        /// </summary>
        protected Integrator_Register _p;
        /// <summary>
        /// The current input value for the next step
        /// </summary>
        protected float _input;
        #endregion
        #region Methods
        /// <summary>
        /// Calculate one step with Sample-Time Ts
        /// </summary>
        /// <param name="Ts">Sample Time</param>
        /// <returns>One step</returns>
        public float do_one_step(float Ts)
        {
            _p[0] = _input * _a[0];
            for (int i = 1; i < _a.Count(); ++i)
                _p[0] += _a[i] * _p[i];
            _p.do_one_step(Ts);
            float result = 0;
            for (int i = 0; i < _b.Count(); ++i)
                result += _b[i] * _p[i];
            OnI_am_finish(result);
            return result;
        }
        /// <summary>
        /// Set the input value for the next calculation.
        /// </summary>
        /// <param name="x_in">current input value</param>
        public void set_input(float x_in)
        {
            _input = x_in;
        }
        /// <summary>
        /// Connect this input with the output of another ISimulatable object.
        /// </summary>
        /// <param name="Target_output">You want to connect with</param>
        public void connect_this_Input_with(ISimulatable Target_output)
        {
            ((ISimulatable)Target_output).I_am_finish += ConnectEventHandler;
        }
        /// <summary>
        /// Disconnect this Input from Target Output.
        /// </summary>
        /// <param name="Target_output">The Target Output you want to disconnect</param>
        public void disconnect_this_Input_from(ISimulatable Target_output)
        {
            ((ISimulatable)Target_output).I_am_finish -= ConnectEventHandler;
        }
        /// <summary>
        /// This event handler will copy the output value of the firing object the the input value of this object.
        /// </summary>
        /// <param name="output">The result of a calculation</param>
        void ConnectEventHandler(float output)
        {
            this._input = output;
        }
        /// <summary>
        /// Will give an information about the Filter Coefficients (a and b) and the Register for the internal integration.
        /// </summary>
        /// <returns>A string with the informations</returns>
        public override string ToString()
        {
            string help = "a= ";
            foreach (float x in _a)
                help += x + " ";
            help += "\nb= ";
            foreach (float x in _b)
                help += x + " ";
            help += "\np= " + _p;
            return (help);
        }
        /// <summary>
        /// Will initialize the integrators of the filter.
        /// </summary>
        protected void init_p()
        {
            if (_a.Count() >= _b.Count())
            {
                float[] help = new float[_a.Count()];
                _p = new Integrator_Register(help);
            }
            else
            {
                float[] help = new float[_b.Count()];
                _p = new Integrator_Register(help);
            }
            _input = 0f;
        }
        /// <summary>
        /// Will reset the integrators of the filter (all stages are 0).
        /// </summary>
        public void reset()
        {
            _p.reset();
            _input = 0f;
        }
        #endregion
        #region Events
        /// <summary>
        /// You can register here, if you want to know when a calculation of one step is done.
        /// </summary>
        public event OutputEventHandler I_am_finish;
        /// <summary>
        /// Will be fired when a calculation of one step is done.
        /// </summary>
        /// <param name="output">The result of the calculation of one step</param>
        private void OnI_am_finish(float output)
        {
            if (I_am_finish != null)
                I_am_finish(output);
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of an Transferfunktion
        /// (It's like an digital Filter)
        /// </summary>
        /// <param name="a">Filter Coefficients a (backward)</param>
        /// <param name="b">Filter Coefficients b (forward)</param>
        public Transferfunction(float[] a, float[] b)
        {
            _a = a;
            _b = b;
            init_p();
        }
        /// <summary>
        /// Initializes a new instance of an Transferfunktion
        /// (It's like an digital Filter)
        /// The filter Coefficients a and b will be 0.
        /// </summary>
        public Transferfunction()
        {
            _a= new float[] { 0f };
            _b= new float[] { 0f };
            init_p();
        }
        #endregion
    }
    //***********************************************Control loop************************************************************//
    /// <summary>
    /// Control loop PT1
    /// </summary>
    public class PT1 : Transferfunction
    {
        #region Properties
        /// <summary>
        /// Control loop gain
        /// </summary>
        public float _Vs
        {
            get;
            set;
        }
        /// <summary>
        /// Control loop time constant
        /// </summary>
        public float _T1
        {
            get;
            set;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Recalculates the filter coefficients a and b
        /// </summary>
        public void recalc_coefficients()
        {
            _a = new float[] { 1f, -1 / _T1 };
            _b = new float[] { 0f, _Vs / _T1 };
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of a PT1 control loop
        /// </summary>
        /// <param name="Vs">Control loop gain</param>
        /// <param name="T1">Time Constant T1</param>
        public PT1(float Vs, float T1)
        {
            _Vs = Vs;
            _T1 = T1;
            recalc_coefficients();
            init_p();
        }
        /// <summary>
        /// Initializes a new instance of a PT1 control loop with Vs=0 and T1=0
        /// </summary>
        public PT1()
        {
            _Vs = 0.0f;
            _T1 = 0.0f;
            recalc_coefficients();
            init_p();
        }
        #endregion
    }
    /// <summary>
    /// Control loop IT1
    /// </summary>
    public class IT1 : Transferfunction
    {
        #region Properties
        /// <summary>
        /// time constant for integral gain
        /// </summary>
        public float _Ti
        {
            get;
            set;
        }
        /// <summary>
        /// time constant T2
        /// </summary>
        public float _T2
        {
            get;
            set;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Recalculates the filter coefficients a and b
        /// </summary>
        public void recalc_coefficients()
        {
            _a = new float[] { 1f, -1 / _T2 };
            _b = new float[] { 0f, 0f, 1 / (_Ti*_T2) };
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of a IT1 control loop
        /// </summary>
        /// <param name="Ti">Time Constant Ti</param>
        /// <param name="T2">Time Constant T2</param>
        public IT1(float Ti, float T2)
        {
            _Ti = Ti;
            _T2 = T2;
            recalc_coefficients();
            init_p();
        }
        /// <summary>
        /// Initializes a new instance of a IT1 control loop with Ti=0 and T2=0
        /// </summary>
        public IT1()
        {
            _Ti = 0.0f;
            _T2 = 0.0f;
            recalc_coefficients();
            init_p();
        }
        #endregion
    }
    /// <summary>
    /// Control loop PT2 with damping > 1
    /// </summary>
    public class PT2_wdb1 : Transferfunction
    {
        #region Properties
        /// <summary>
        /// control loop gain
        /// </summary>
        public float _Vs
        {
            get;
            set;
        }
        /// <summary>
        /// time constant T1
        /// </summary>
        public float _T1
        {
            get;
            set;
        }
        /// <summary>
        /// time constant T2
        /// </summary>
        public float _T2
        {
            get;
            set;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Recalculates the filter coefficients a and b
        /// </summary>
        public void recalc_coefficients()
        {
            _a = new float[] { 1f, -(_T1+_T2) / (_T1*_T2), -1/(_T1*_T2) };
            _b = new float[] { 0f, 0f,  _Vs / (_T1*_T2) };
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of a PT2 control loop with damping > 1
        /// </summary>
        /// <param name="Vs">Control loop gain</param>
        /// <param name="T1">Time Constant T1</param>
        /// <param name="T2">Time Constant T2</param>
        public PT2_wdb1(float Vs, float T1, float T2)
        {
            _Vs = Vs;
            _T1 = T1;
            _T2 = T2;
            recalc_coefficients();
            init_p();
        }
        /// <summary>
        /// Initializes a new instance of a PT2 control loop with damping > 1 (Vs=0,T1=0,T2=0)
        /// </summary>
        public PT2_wdb1()
        {
            _Vs = 0.0f;
            _T1 = 0.0f;
            _T2 = 0.0f;
            recalc_coefficients();
            init_p();
        }
        #endregion
    }
    /// <summary>
    /// Control loop PT2 with damping smaller-equal 1
    /// </summary>
    public class PT2_wdse1 : Transferfunction
    {
        #region Properties
        /// <summary>
        /// Control loop gain
        /// </summary>
        public float _Vs
        {
            get;
            set;
        }
        /// <summary>
        /// Time constant T
        /// </summary>
        public float _T
        {
            get;
            set;
        }
        /// <summary>
        /// Damping
        /// </summary>
        public float _d
        {
            get;
            set;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Recalculates the filter coefficients a and b
        /// </summary>
        public void recalc_coefficients()
        {
            _a = new float[] { 1f, -(2*_d) / (_T), -1 / (_T * _T) };
            _b = new float[] { 0f, 0f, _Vs / (_T * _T) };
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of a PT2 control loop with damping smaller-equal 1
        /// </summary>
        /// <param name="Vs">Control loop gain</param>
        /// <param name="T">Time Constant T</param>
        /// <param name="d">Damping</param>
        public PT2_wdse1(float Vs, float T, float d)
        {
            _Vs = Vs;
            _T = T;
            _d = d;
            recalc_coefficients();
            init_p();
        }
        /// <summary>
        /// Initializes a new instance of a PT2 control loop with damping smaller-equal 1 (Vs=0, T=0, d=0)
        /// </summary>
        public PT2_wdse1()
        {
            _Vs = 0.0f;
            _T = 0.0f;
            _d = 0.0f;
            recalc_coefficients();
            init_p();
        }
        #endregion
    }
    //***********************************************Controller************************************************************//
    /// <summary>
    /// Integral Controller
    /// </summary>
    public class Controller_I : Transferfunction
    {
        #region Variables
        /// <summary>
        /// Integration time constant
        /// </summary>
        public float _Ti
        {
            get;
            set;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Recalculates the filter coefficients a and b
        /// </summary>
        public void recalc_coefficients()
        {
            _a = new float[] { 1f};
            _b = new float[] { 0f, 1 / _Ti };
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of a Integral Controller 
        /// </summary>
        /// <param name="Ti">Integration time constant</param>
        public Controller_I(float Ti)
        {
            _Ti = Ti;
            recalc_coefficients();
            init_p();
        }
        /// <summary>
        /// Initializes a new instance of a Integral Controller  (Ti=0)
        /// </summary>
        public Controller_I()
        {
            _Ti = 0.0f;
            recalc_coefficients();
            init_p();
        }
        #endregion
    }
    /// <summary>
    /// Proportional Controller
    /// </summary>
    public class Controller_P : Transferfunction
    {
        #region Variables
        /// <summary>
        /// Proportional gain
        /// </summary>
        public float _Vr
        {
            get;
            set;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Recalculates the filter coefficients a and b
        /// </summary>
        public void recalc_coefficients()
        {
            _a = new float[] { 1f };
            _b = new float[] { _Vr};
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of a Proportional Controller
        /// </summary>
        /// <param name="Vr">Proportional gain</param>
        public Controller_P(float Vr)
        {
            _Vr = Vr;
            recalc_coefficients();
            init_p();
        }
        /// <summary>
        /// Initializes a new instance of a Proportional Controller (Vr=0)
        /// </summary>
        public Controller_P()
        {
            _Vr = 0.0f;
            recalc_coefficients();
            init_p();
        }
        #endregion
    }
    /// <summary>
    /// Proportional/Integral Controller
    /// </summary>
    public class Controller_PI : Transferfunction
    {
        #region Variables
        /// <summary>
        /// Proportional gain
        /// </summary>
        public float _Vr
        {
            get;
            set;
        }
        /// <summary>
        /// integral action time constant
        /// </summary>
        public float _Tn
        {
            get;
            set;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Recalculates the filter coefficients a and b
        /// </summary>
        public void recalc_coefficients()
        {
            _a = new float[] { 1f };
            _b = new float[] { _Vr , _Vr/_Tn };
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of a Proportional Controller
        /// </summary>
        /// <param name="Vr">Proportional gain</param>
        /// <param name="Tn">integral action time constant</param>
        public Controller_PI(float Vr,float Tn)
        {
            _Vr = Vr;
            _Tn = Tn;
            recalc_coefficients();
            init_p();
        }
        /// <summary>
        /// Initializes a new instance of a Proportional Controller (Vr=0, Tn=0)
        /// </summary>
        public Controller_PI()
        {
            _Vr = 0.0f;
            _Tn = 0.0f;
            recalc_coefficients();
            init_p();
        }
        #endregion
    }
    /// <summary >
    /// The Controller for a Schematic
    /// </summary >
    public class Adder : ISimulatable
    {
        #region Variables
        /// <summary>
        /// current Input Values 1
        /// </summary>
        float _input1;
        /// <summary>
        /// current Input Values 2
        /// </summary>
        float _input2;
        /// <summary>
        /// first and second element: "+1" for + operator and "-1" for - operator
        /// </summary>
        string[] _operator;
        #endregion
        #region Methods
        /// <summary>
        /// Calculate one time step.
        /// </summary>
        /// <param name="Ts">Sample Time</param>
        /// <returns>Result of one time step calculation</returns>
        public float do_one_step(float Ts)
        {
            float result = 0f;
            if ((_operator[0] == "-1") && (_operator[1] == "-1"))
                result = -(_input1) - (_input2);
            else if ((_operator[0] == "+1") && (_operator[1] == "-1"))
                result = (_input1) - (_input2);
            else if ((_operator[0] == "-1") && (_operator[1] == "+1"))
                result = -(_input1) + (_input2);
            else if ((_operator[0] == "+1") && (_operator[1] == "+1"))
                result = (_input1) + (_input2);
            else
                Console.WriteLine("ERROR something is wrong with the Adder!");
            OnI_am_finish(result);
            return result;
        }
        /// <summary>
        /// Set the input value for the next step calculation
        /// </summary>
        /// <param name="x_in">The input value</param>
        public void set_input(float x_in)
        {
            _input1 = x_in;
        }
        /// <summary>
        /// Reset all old time domains, and input values to 0.
        /// </summary>
        public void reset()
        {
            _input1 = 0f;
            _input2 = 0f;
        }
        /// <summary>
        /// Connect this input with the output of another ISimulatable object in your Schematic.
        /// </summary>
        /// <param name="Target_output">You want to connect with</param>
        public void connect_this_Input_with(ISimulatable Target_output)
        {
            ((ISimulatable)Target_output).I_am_finish += ConnectEventHandler;
        }
        /// <summary>
        /// Disconnect this Input from Target Output.
        /// </summary>
        /// <param name="Target_output">The Target Output you want to disconnect</param>
        public void disconnect_this_Input_from(ISimulatable Target_output)
        {
            ((ISimulatable)Target_output).I_am_finish -= ConnectEventHandler;
        }
        /// <summary>
        /// This event handler will copy the output value of the firing object the the input value of this object.
        /// </summary>
        /// <param name="output">The result of a calculation</param>
        void ConnectEventHandler(float output)
        {
            this._input2 = output;
        }
        #endregion
        #region Events
        /// <summary>
        /// You can register here, if you want to know when a calculation of one step is done.
        /// </summary>
        public event OutputEventHandler I_am_finish;
        /// <summary>
        /// Will be fired when a calculation of one step is done.
        /// </summary>
        /// <param name="output">The result of the calculation of one step</param>
        private void OnI_am_finish(float output)
        {
            if (I_am_finish != null)
                I_am_finish(output);
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of an Adder
        /// </summary>
        /// <param name="operatations">first and second element: "+1" for + operator and "-1" for - operator</param> 
        public Adder(string[] operatations)
        {
            _operator = operatations;
            _input1 = 0f;
            _input2 = 0f;
        }
        #endregion
    }
    /// <summary >
    /// The Controller for a Schematic
    /// </summary >
    public class Step : ISimulatable
    {
        #region Variables
        public float _step_Time
        {
            get;
            set;
        }
        public float _step_Value
        {
            get;
            set;
        }
        float _t_mom = 0.0f;
        /// <summary>
        /// The current input value for the next step
        /// </summary>
        float _input;
        #endregion
        #region Methods
        public float do_one_step(float Ts)
        {
            float result;
            _t_mom += Ts;
            if(_t_mom>=_step_Time)
                result = _input+_step_Value;
            else
                result = _input;
            OnI_am_finish(result);
            return result;
        }
        /// <summary>
        /// Set the input value for the next step calculation
        /// </summary>
        /// <param name="x_in">The input value</param>
        public void set_input(float x_in)
        {
            _input = x_in;
        }
        /// <summary>
        /// Reset all old time domains, and input values to 0.
        /// </summary>
        public void reset()
        {
            _input = 0.0f;
            _t_mom=0.0f;
        }
        /// <summary>
        /// Connect this input with the output of another ISimulatable object in your Schematic.
        /// </summary>
        /// <param name="Target_output">You want to connect with</param>
        public void connect_this_Input_with(ISimulatable Target_output)
        {
            ((ISimulatable)Target_output).I_am_finish += ConnectEventHandler;
        }
        /// <summary>
        /// Disconnect this Input from Target Output.
        /// </summary>
        /// <param name="Target_output">The Target Output you want to disconnect</param>
        public void disconnect_this_Input_from(ISimulatable Target_output)
        {
            ((ISimulatable)Target_output).I_am_finish -= ConnectEventHandler;
        }
        /// <summary>
        /// This event handler will copy the output value of the firing object the the input value of this object.
        /// </summary>
        /// <param name="output">The result of a calculation</param>
        void ConnectEventHandler(float output)
        {
            this._input = output;
        }
        #endregion
        #region Events
        /// <summary>
        /// You can register here, if you want to know when a calculation of one step is done.
        /// </summary>
        public event OutputEventHandler I_am_finish;
        /// <summary>
        /// Will be fired when a calculation of one step is done.
        /// </summary>
        /// <param name="output">The result of the calculation of one step</param>
        private void OnI_am_finish(float output)
        {
            if (I_am_finish != null)
                I_am_finish(output);
        }
        #endregion
        #region Constructors
        public Step(float step_Time, float step_Value)
        {
            _step_Time = step_Time;
            _step_Value = step_Value;
        }
        public Step()
        {
            _step_Time =0.0f;
            _step_Value =0.0f;
        }
        #endregion
    }
    //*************************************************Simulator and optimizer**********************************************//
    /// <summary >
    /// With this Simulator you can simulate the time domain of a Schematic
    /// </summary >
    public class Simulator
    {
        #region Variables
        /// <summary>
        /// The Schematic will be represented as an array of simulatable objects.
        /// </summary>
        ISimulatable[] _Schematic;
        #endregion
        #region Methods
        /// <summary>
        /// Simulate the Schematic of a specified time domain with a Sample Time.
        /// </summary>
        /// <param name="Ts">Sample Time</param>
        /// <param name="Tend">The Time when the simulation will stop</param>
        /// <returns>A Matrix with 2 rows. In the first row you will find the Values of the simulation, in the second row the corresponding time.</returns>
        public float[,] simulate(float Ts, float Tend)
        {
            int iend = (int)(Tend / Ts);               //Calc how many steps to be done
            float[,] result = new float[2, iend + 1];  //Value and Time
            foreach (ISimulatable x in _Schematic)     //reset all old time domains
                x.reset();
            for (int i = 1; i <= iend; ++i)            //step simulation 
            {
                _Schematic.First().set_input(1);
                for (int j = 0; j < _Schematic.Count() - 1; ++j)
                {
                    _Schematic[j].do_one_step(Ts);
                }
                result[0, i] = _Schematic[_Schematic.Count() - 1].do_one_step(Ts);
                result[1, i] = i * Ts;
            }
            return result;
        }
        public bool replace_in_Schematic_at_pos(int position, ISimulatable x)
        {
            int kdh = _Schematic.Length;
            if ((_Schematic.Length - 1 > position) && position > 0)
            {
                //Step 1: Disconnect both old connections
                _Schematic[position].disconnect_this_Input_from(_Schematic[position - 1]);
                _Schematic[position + 1].disconnect_this_Input_from(_Schematic[position]);

                //Step 2: Set new Object to the position
                _Schematic[position] = x;

                //Step 3: new connections
                _Schematic[position].connect_this_Input_with(_Schematic[position - 1]);
                _Schematic[position + 1].connect_this_Input_with(_Schematic[position]);
                return true;
            }
            else if ((_Schematic.Length - 1 == position) && position > 0)                         //Last position in Schematic
            {
                //Step 1: Disconnect both old connections
                _Schematic[position].disconnect_this_Input_from(_Schematic[position - 1]);
                _Schematic[0].disconnect_this_Input_from(_Schematic[position]);

                //Step 2: Set new Object to the position
                _Schematic[position] = x;

                //Step 3: new connections
                _Schematic[position].connect_this_Input_with(_Schematic[position - 1]);
                _Schematic[0].connect_this_Input_with(_Schematic[position]);
                return true;
            }
            else
                return false;

        }
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of a Simulator
        /// </summary>
        /// <param name="x">The Schematic you want to simulate</param>
        public Simulator(ISimulatable[] x)
        {
            _Schematic = x;

        }

        /// <summary>
        /// Initializes a new instance of a Simulator of a standard Controller Schematic
        /// </summary>
        /// <param name="Controller">The Controller of your Schematic</param>
        /// <param name="Jamming">The Jamming of your Schematic</param>
        /// <param name="Control_loop">The Control-Loop of your Schematic</param>
        public Simulator(ISimulatable Controller, Step Jamming, ISimulatable Control_loop)
        {
            _Schematic = new ISimulatable[] { new Adder(new string[] { "+1", "-1" }), Controller, Jamming ,Control_loop };
            _Schematic[1].connect_this_Input_with(_Schematic[0]);
            _Schematic[2].connect_this_Input_with(_Schematic[1]);
            _Schematic[3].connect_this_Input_with(_Schematic[2]);
            _Schematic[0].connect_this_Input_with(_Schematic[3]);
        }
        #endregion
    }
    /// <summary>
    /// Optimization Methods
    /// </summary>
    public static class Optimize
    {
        /// <summary>
        /// Optimize a controller for a specific control loop
        /// </summary>
        /// <param name="control_loop">The PT1-control loop in your Schematic</param>
        /// <param name="controller">The I-controller you want to optimize</param>
        public static void Controller(PT1 control_loop, Controller_I controller)
        {
            controller._Ti = 2 * control_loop._Vs * control_loop._T1;
            controller.recalc_coefficients();
        }
        /// <summary>
        /// Optimize a controller for a specific control loop
        /// </summary>
        /// <param name="control_loop">The IT1-control loop in your Schematic</param>
        /// <param name="controller">The P-controller you want to optimize</param>
        public static void Controller(IT1 control_loop, Controller_P controller)
        {
            controller._Vr = control_loop._Ti/(2*control_loop._T2);
            controller.recalc_coefficients();
        }
        /// <summary>
        /// Optimize a controller for a specific control loop
        /// </summary>
        /// <param name="control_loop">The IT1-control loop in your Schematic</param>
        /// <param name="controller">The PI-controller you want to optimize</param>
        public static void Controller(IT1 control_loop, Controller_PI controller)
        {
            controller._Vr = control_loop._Ti / (2 * control_loop._T2);
            controller._Tn = 4*control_loop._T2;
            controller.recalc_coefficients();
        }
        /// <summary>
        /// Optimize a controller for a specific control loop
        /// </summary>
        /// <param name="control_loop">The PT2-control (with damping bigger 1) loop in your Schematic</param>
        /// <param name="controller">The P-controller you want to optimize</param>
        public static void Controller(PT2_wdb1 control_loop, Controller_P controller)
        {
            controller._Vr = control_loop._T1 / (2 * control_loop._T2*control_loop._Vs);
            controller.recalc_coefficients();
        }
        /// <summary>
        /// Optimize a controller for a specific control loop
        /// </summary>
        /// <param name="control_loop">The PT2-control (with damping bigger 1) loop in your Schematic</param>
        /// <param name="controller">The PI-controller you want to optimize</param>
        public static void Controller(PT2_wdb1 control_loop, Controller_PI controller)
        {
            if((control_loop._T1 / control_loop._T2)<=4.0f)       //Absolute Optimum  (BO)
            {
                controller._Vr = control_loop._T1 / (2 * control_loop._T2 * control_loop._Vs);
                controller._Tn = control_loop._T1;
            }
            else                                                  //Symmetry Optimum  (SO)
            {
                controller._Vr = control_loop._T1 / (2 * control_loop._T2 * control_loop._Vs);
                controller._Tn = 4*control_loop._T2;
            }
            controller.recalc_coefficients();
        }
        /// <summary>
        /// Optimize a controller for a specific control loop
        /// </summary>
        /// <param name="control_loop">The PT2-control (with damping smaller-equal 1) loop in your Schematic</param>
        /// <param name="controller">The I-controller you want to optimize</param>
        public static void Controller(PT2_wdse1 control_loop, Controller_I controller)
        {
            controller._Ti = 4*control_loop._d*control_loop._T*control_loop._Vs;
            controller.recalc_coefficients();
        }
        /// <summary>
        /// Optimize a controller for a specific control loop
        /// </summary>
        /// <param name="control_loop">The PT2-control (with damping smaller-equal 1) loop in your Schematic</param>
        /// <param name="controller">The PI-controller you want to optimize</param>
        public static void Controller(PT2_wdse1 control_loop, Controller_PI controller)
        {
            controller._Vr = (2*control_loop._d*control_loop._d-1)/control_loop._Vs;
            controller._Tn = (control_loop._T / control_loop._d) * (2 - 1 / (control_loop._d * control_loop._d));
            controller.recalc_coefficients();
        }
    }
}
