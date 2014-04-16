using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using controller_design.Schematic;

namespace controller_design
{
    class Console_Test
    {
        static void Main(string[] args)
        {
            float Ts = 0.0002f;      //Sample Time
            float Vs = 2f;           //Gain Constant for Route
            float T1 = 0.005f;       //Time Constant for Route
            ISimulatable[] Schematic1 = { new Adder(new string[] { "+1", "-1" }),new Controller_I(0f),new PT1(Vs,T1) };
            Schematic1[1].connect_this_Input_with(Schematic1[0]);
            Schematic1[2].connect_this_Input_with(Schematic1[1]);
            Schematic1[0].connect_this_Input_with(Schematic1[2]);
            Optimize.Controller((PT1)Schematic1[2], (Controller_I)Schematic1[1]);
            Simulator Simulator1 = new Simulator(Schematic1);
            LinkedList<float>[] result1 = Simulator1.simulate(Ts, 300 * Ts);
            for (int i = 0; i < result1[1].Count(); ++i)
            {
                Console.WriteLine("[ " + result1[0].ElementAt(i) + " , " + result1[1].ElementAt(i) + " ]");
            }
            Console.Read();
        }
    }
    /// <summary>
    /// An empty class, when you want to create a new class
    /// </summary>
    public class emty_class
    {
        #region Variables
        #endregion
        #region Methods
        #endregion
        #region Events
        #endregion
        #region Constructors
        #endregion
    }
}
