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
            ISimulatable[] Schematic = { new Adder(new string[] { "+1", "-1" }),new Controller_I(0f),new PT1(Vs,T1) };
            Schematic[1].connect_this_Input_with(Schematic[0]);
            Schematic[2].connect_this_Input_with(Schematic[1]);
            Schematic[0].connect_this_Input_with(Schematic[2]);
            Optimize.Controller((PT1)Schematic[2], (Controller_I)Schematic[1]);
            Simulator Simulator1 = new Simulator(Schematic);
            float[,] result = Simulator1.simulate(Ts, 300 * Ts);
            for (int i = 0; i < (result.Length/2); ++i)
            {
                Console.WriteLine("[ " + result[0,i] + " , " + result[1,i] + " ]");
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
