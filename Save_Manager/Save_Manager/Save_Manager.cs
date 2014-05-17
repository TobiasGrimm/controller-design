using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Basics
{
    public interface Isavable
    {
        string parameters2string();
        void restorefromstring(string s);
    }
    public static class File_Manager
    {
        public static void save2file(string path,IEnumerable<Isavable> x)
        {
            LinkedList <string> result = new LinkedList<string> {};
            foreach (Isavable savableobj in x)
                result.AddLast(savableobj.parameters2string());
            Console.WriteLine(result);
            File.WriteAllLines(path, result);
        }
        public static void load_from_file (string path,IEnumerable<Isavable> x)
        {
            string[] information = File.ReadAllLines(path);
            int i = 0;
            foreach (string s in information)
            {
                try 
                {
                x.ElementAt(i).restorefromstring(s);
                }
                catch (ArgumentOutOfRangeException e)
                {

                }
                ++i;
            }
        } 
    }
    public class Testobject : Isavable
    {
        public string _name;
        public string parameters2string()
        {
            return _name;
        }
        public void restorefromstring(string s)
        {
            _name = s;
        }
        public Testobject(string name)
        {
            _name = name;
        }
    }
}
