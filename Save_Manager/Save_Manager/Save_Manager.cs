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
    public class Savable_WPF_Obj : Isavable
    {
        List<ComboBox> _cb_list;
        List<TextBox>  _tb_list;
        List<TabControl> _tc_list;
        public Savable_WPF_Obj(List<ComboBox> cb_list, List<TextBox> tb_list, List<TabControl> tc_list)
        {
            _cb_list = cb_list;
            _tb_list = tb_list;
            _tc_list = tc_list;
        }
        public Savable_WPF_Obj(List<ComboBox> cb_list, List<TextBox> tb_list)
        {
            _cb_list = cb_list;
            _tb_list = tb_list;
            _tc_list = new List<TabControl>() { };
        }
        string comboBoxes2string()
        {
            string result = "";
            foreach (ComboBox cb in _cb_list)
                result += cb.SelectedIndex + "$";
            return result;
        }
        string textBoxes2string()
        {
            string result = "";
            foreach (TextBox tb in _tb_list)
                result += tb.Text.Replace("§", "").Replace("$", "") + "$";
            return result;
        }
        string tabControl2string()
        {
            string result = "";
            foreach (TabControl tc in _tc_list)
                result += tc.SelectedIndex + "$";
            return result;
        }
        void restoreComboBoxes(string s)
        {
            string[] splitted = s.Split('$');
            int help = 0;
            for (int i = 0; i < _cb_list.Count; ++i)
            {
                int.TryParse(splitted[i], out help);
                _cb_list[i].SelectedIndex = help;
            }
        }
        void restoreTextBoxes(string s)
        {
            string[] splitted = s.Split('$');
            for (int i = 0; i < _tb_list.Count; ++i)
            {
                _tb_list[i].Text = splitted[i];
            }
        }
        void restoreTabControls(string s)
        {
            string[] splitted = s.Split('$');
            int help = 0;
            for (int i = 0; i < _tc_list.Count; ++i)
            {
                int.TryParse(splitted[i], out help);
                _tc_list[i].SelectedIndex = help;
            }
        }
        public string parameters2string()
        {
            return comboBoxes2string()+"§"+textBoxes2string()+"§"+tabControl2string();
        }

        public void restorefromstring(string s)
        {

            string[] splitted = s.Split('§');
            restoreComboBoxes(splitted[0]);
            restoreTextBoxes(splitted[1]);
            restoreTabControls(splitted[2]);
        }
    }
}
