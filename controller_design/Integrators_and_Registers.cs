using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controller_design.Integrators_and_Registers
{
    /// <summary>
    /// A collection of different integration methods
    /// </summary>
    static public class Integrator
    {
        /// <summary>
        /// The integration method "Backward Euler"
        /// </summary>
        /// <param name="x_mom">The current input value (Time=0)</param>
        /// <param name="y_old">The last output value (Time=-Ts)</param>
        /// <param name="Ts">The sample time between x_mom and x_old</param>
        /// <returns>The integrated input</returns>
        static public float Backward_Euler(float x_mom, float y_old, float Ts)
        {
            return x_mom * Ts + y_old;
        }
        /// <summary>
        /// The integration method "Trapezoidal"
        /// </summary>
        /// <param name="x_mom">The current value (Time=0)</param>
        /// <param name="x_old">The last input value (Time=-Ts)</param>
        /// <param name="y_old">The last output value (Time=-Ts)</param>
        /// <param name="Ts">The sample time between x_mom and x_old</param>
        /// <returns>The integrated input</returns>
        static public float Trapezoidal(float x_mom, float x_old, float y_old, float Ts)
        {
            return y_old + (x_mom + x_old) * Ts / 2;
        }
    }
    /// <summary >
    /// A Shifting Register with a fixed length
    /// </summary >
    public class Shift_Register<T>
    {
        #region Variables and Properties
        /// <summary>
        /// A array which represents the Register
        /// </summary>
        T[] _Register;
        /// <summary>
        /// Get access to internal Register
        /// </summary>
        /// <param name="index">The index of the array</param>
        /// <returns>The object of the Register at the index</returns>
        public T this[int index] { get { return _Register[index]; } set { _Register[index] = value; } }
        #endregion
        #region Methods
        /// <summary>
        /// Adds at first, and delete the last.
        /// </summary>
        /// <param name="x_in">The object you want to add</param>
        public void add_and_shift(T x_in)
        {
            for (int i = _Register.Count() - 1; i >= 1; --i)
                _Register[i] = _Register[i - 1];
            _Register[0] = x_in;
        }
        /// <summary>
        /// Builds a string information about the Register.
        /// </summary>
        /// <returns>A string with all information about all objects in the Register.</returns>
        public override string ToString()
        {
            string help = "";
            foreach (T x in _Register)
                help += x + " ";
            return (help);
        }
        #endregion
        #region Constructors
        /// <summary >
        /// Initializes a new instance of the Shift_Register
        /// type using the specified Array.
        /// (The length of the Array is the length of the Register)
        /// </summary >
        /// <param name ="x">An array</param >
        public Shift_Register(T[] x)
        {
            _Register = x;
        }
        /// <summary>
        /// Initializes a new instance of the Shift_Register
        /// type with an array of two empty elements.
        /// </summary>
        public Shift_Register()
        {
            _Register = new T[2];
        }
        #endregion
    }
    /// <summary >
    /// A Integrator Register with a fixed length.
    /// The value at Register-Index=0 is not integrated,
    /// at Register-Index=1 it is one time integrated,
    /// at Register-Index=2 it es two times integrated, ...
    /// (Register[i]==x_in*p^-i)
    /// </summary >
    public class Integrator_Register
    {
        #region Variables and Properties
        /// <summary>
        /// The value at Register-Index=0 is not integrated,
        /// at Register-Index=1 it is one time integrated,
        /// at Register-Index=2 it es two times integrated, ...
        /// (Register[i]==x_in*p^-i)
        /// </summary>
        float[] _Register;
        /// <summary>
        /// The Old Values in the Register
        /// </summary>
        float[] _Register_old;
        /// <summary>
        /// Get access to the Register at a specified index
        /// </summary>
        /// <param name="index">The index of the Register (array)</param>
        /// <returns>The information of the Register</returns>
        public float this[int index] { get { return _Register[index]; } set { _Register[index] = value; } }
        #endregion
        #region Methods
        /// <summary>
        /// Calculate one time step in the Register
        /// (internal integration)
        /// </summary>
        /// <param name="Ts">The sample Time for one step</param>
        public void do_one_step(float Ts)
        {            
            for (int i = 1; i < _Register.Count(); ++i)
                _Register[i] = Integrator.Trapezoidal(_Register[i - 1], _Register_old[i-1], _Register[i], Ts);
            _Register_old = _Register;
        }
        /// <summary>
        /// Resets each element of the Register to 0
        /// </summary>
        public void reset()
        {
            for (int i = 0; i < _Register.Count(); ++i)
            {
                _Register[i] = 0;
                _Register_old[i] = 0;
            }

        }
        /// <summary>
        /// Gives an information about each Register Value.
        /// </summary>
        /// <returns>An information about the Registers</returns>
        public override string ToString()
        {
            string help = "";
            foreach (float x in _Register)
                help += x + " ";
            return (help);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the Integrator_Register
        /// type using the specified Array.
        /// (The length of the Array is the length of the Register)
        /// </summary>
        /// <param name="x">An array with time=0 elements</param>
        public Integrator_Register(float[] x)
        {
            _Register = x;
            _Register_old = x;
            for (int i = 0; i < x.Length; ++i)
                _Register_old[i] = 0;
        }
        #endregion
    }
}
