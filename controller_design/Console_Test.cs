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
            Controller_I I1= new Controller_I(0f);
            Step Step1 = new Step(0.02f, 0.0f);
            PT1 PT11 = new PT1(Vs, T1);
            Simulator Simulator1 = new Simulator(I1,Step1,PT11);
            Optimize.Controller(PT11, I1);
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
