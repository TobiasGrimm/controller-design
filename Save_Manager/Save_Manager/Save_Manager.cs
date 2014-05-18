using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Xaml;

namespace Basics
{
    public interface Isavable
    {
        string parameters2string();
        void restorefromstring(string s);
    }
    public static class File_Manager
    {
        public static void save2file(string path, IEnumerable<Isavable> x)
        {
            LinkedList<string> result = new LinkedList<string> { };
            foreach (Isavable savableobj in x)
                result.AddLast(savableobj.parameters2string());
            Console.WriteLine(result);
            File.WriteAllLines(path, result);
        }
        public static void load_from_file(string path, IEnumerable<Isavable> x)
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
    public class Save_Text_Boxes : Isavable
    {
        List<TextBox> _tb_list;
        public Save_Text_Boxes(List<TextBox> tb_list)
        {
            _tb_list = tb_list;
        }

        public string parameters2string()
        {
            string result = "";
            foreach (TextBox tb in _tb_list)
                result += tb.Text + "$";
            return result;
        }

        public void restorefromstring(string s)
        {

            string[] splitted = s.Split('$');
            for (int i = 0; i < _tb_list.Count; ++i)
            {
                _tb_list[i].Text = splitted[i];
            }
        }
    }
    public class Save_Combo_Boxes : Isavable
    {
        List<ComboBox> _cb_list = new List<ComboBox>() { };
        public Save_Combo_Boxes(List<ComboBox> cb_list)
        {
            _cb_list = cb_list;
        }

        public string parameters2string()
        {
            string result = "";
            foreach (ComboBox cb in _cb_list)
                result += cb.SelectedIndex+ "$";
            return result;
        }

        public void restorefromstring(string s)
        {

            string[] splitted = s.Split('$');
            int help = 0;
            for (int i = 0; i < _cb_list.Count; ++i)
            {
                int.TryParse(splitted[i],out help);
                _cb_list[i].SelectedIndex=help;
            }
        }
    }
}
