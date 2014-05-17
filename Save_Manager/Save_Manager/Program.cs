using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            Isavable[] test = { new Testobject("Hinz"), new Testobject("Kunz") };
            //File_Manager.save2file("C:\\Temp\\test.txt",test);
            File_Manager.load_from_file("C:\\Temp\\test.txt",test);
            foreach (Testobject i in test)
                Console.WriteLine(i._name);
            Console.Read();
        }
    }
}
