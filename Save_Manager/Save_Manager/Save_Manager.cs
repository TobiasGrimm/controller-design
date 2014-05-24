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

namespace controller_design.Save_and_load
{
    /// <summary>
    /// Implement this Interface and your Objs. can be saved with the File_Manager
    /// </summary>
    public interface Isavable
    {
        /// <summary>
        /// Transform all Information you want to save into a String
        /// </summary>
        /// <returns>The Informations as a string</returns>
        string parameters2string();
        /// <summary>
        /// Restore all Informations from the String you created with "parameters2string()"
        /// </summary>
        /// <param name="s">The String you created</param>
        void restorefromstring(string s);
    }
    /// <summary>
    /// With the File_Manager you can save and restore Obj to File, which implements the Isavable Interface
    /// </summary>
    public static class File_Manager
    {
        /// <summary>
        /// Save to a File
        /// </summary>
        /// <param name="path">The path where you want to save it</param>
        /// <param name="x">The Enumerable Objs you want to save</param>
        public static void save2file(string path, IEnumerable<Isavable> x)
        {
            LinkedList<string> result = new LinkedList<string> { };
            foreach (Isavable savableobj in x)
                result.AddLast(savableobj.parameters2string());
            File.WriteAllLines(path, result);
        }
        /// <summary>
        /// Loaf from a File
        /// </summary>
        /// <param name="path">The path where you want to load from</param>
        /// <param name="x">The Enumerable Objs you want to restore</param>
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
    /// <summary>
    /// With the Savable Windows Presentation Foundation Objects you can Save and Load WPFs.
    /// At the moment you can save: TextBoxes, ComboBoxes, TabControlles, CheckBoxes
    /// </summary>
    public class Savable_WPF_Obj : Isavable
    {
        #region Variables
        /// <summary>
        /// remember the ComboBox list, that it can be saved and restored
        /// </summary>
        List<ComboBox> _cb_list;
        /// <summary>
        /// remember the TextBox list, that it can be saved and restored
        /// </summary>
        List<TextBox>  _tb_list;
        /// <summary>
        /// remember the TabControl list, that it can be saved and restored
        /// </summary>
        List<TabControl> _tc_list;
        /// <summary>
        /// remember the CheckBox list, that it can be saved and restored
        /// </summary>
        List<CheckBox> _checkb_list;
        #endregion
        #region Methods
        /// <summary>
        /// Transform The relevant ComboBox Information into a string
        /// </summary>
        /// <returns>the transformed Informations</returns>
        string comboBoxes2string()
        {
            string result = "";
            foreach (ComboBox cb in _cb_list)
                result += cb.SelectedIndex + "$";
            return result;
        }
        /// <summary>
        /// Transform The relevant TextBox Information into a string
        /// </summary>
        /// <returns>the transformed Informations</returns>
        string textBoxes2string()
        {
            string result = "";
            foreach (TextBox tb in _tb_list)
                result += tb.Text.Replace("§", "").Replace("$", "") + "$";
            return result;
        }
        /// <summary>
        /// Transform The relevant CheckBox Information into a string
        /// </summary>
        /// <returns>the transformed Informations</returns>
        string checkBoxes2string()
        {
            string result = "";
            foreach (CheckBox cb in _checkb_list)
                result += cb.IsChecked + "$";
            return result;
        }
        /// <summary>
        /// Transform The relevant tabControl Information into a string
        /// </summary>
        /// <returns>the transformed Informations</returns>
        string tabControl2string()
        {
            string result = "";
            foreach (TabControl tc in _tc_list)
                result += tc.SelectedIndex + "$";
            return result;
        }
        /// <summary>
        /// Restore the ComboBox from the String
        /// </summary>
        /// <param name="s">Information in form of a string</param>
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
        /// <summary>
        /// Restore the TextBox from the String
        /// </summary>
        /// <param name="s">Information in form of a string</param>
        void restoreTextBoxes(string s)
        {
            string[] splitted = s.Split('$');
            for (int i = 0; i < _tb_list.Count; ++i)
            {
                _tb_list[i].Text = splitted[i];
            }
        }
        /// <summary>
        /// Restore the CheckBox from the String
        /// </summary>
        /// <param name="s">Information in form of a string</param>
        void restoreCheckBoxes(string s)
        {
            bool help = false;
            string[] splitted = s.Split('$');
            for (int i = 0; i < _checkb_list.Count; ++i)
            {
                bool.TryParse(splitted[i], out help);
                _checkb_list[i].IsChecked = help;
            }
        }
        /// <summary>
        /// Restore the TabControl from the String
        /// </summary>
        /// <param name="s">Information in form of a string</param>
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
        /// <summary>
        /// Transform all Information you want to save into a String
        /// </summary>
        /// <returns>The Informations as a string</returns>
        public string parameters2string()
        {
            return comboBoxes2string() + "§" + textBoxes2string() + "§" + tabControl2string() + "§" + checkBoxes2string();
        }
        /// <summary>
        /// Restore all Informations from the String you created with "parameters2string()"
        /// </summary>
        /// <param name="s">The String you created</param>
        public void restorefromstring(string s)
        {

            string[] splitted = s.Split('§');
            restoreComboBoxes(splitted[0]);
            restoreTextBoxes(splitted[1]);
            restoreTabControls(splitted[2]);
            restoreCheckBoxes(splitted[3]);
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of a Savable_WPF_Obj
        /// </summary>
        /// <param name="cb_list">The List of ComboBoxes you want to save</param>
        /// <param name="tb_list">The List of TextBoxes you want to save</param>
        /// <param name="tc_list">The List of TabControlls you want to save</param>
        /// <param name="checkb_list">The List of CheckBoxes you want to save</param>
        public Savable_WPF_Obj(List<ComboBox> cb_list, List<TextBox> tb_list, List<TabControl> tc_list, List<CheckBox> checkb_list)
        {
            _cb_list = cb_list;
            _tb_list = tb_list;
            _tc_list = tc_list;
            _checkb_list = checkb_list;
        }
        /// <summary>
        /// Initializes a new instance of a Savable_WPF_Obj
        /// </summary>
        /// <param name="cb_list">The List of ComboBoxes you want to save</param>
        /// <param name="tb_list">The List of TextBoxes you want to save</param>
        /// <param name="tc_list">The List of TabControlls you want to save</param>
        public Savable_WPF_Obj(List<ComboBox> cb_list, List<TextBox> tb_list, List<TabControl> tc_list)
        {
            _cb_list = cb_list;
            _tb_list = tb_list;
            _tc_list = tc_list;
        }
        /// <summary>
        /// Initializes a new instance of a Savable_WPF_Obj
        /// </summary>
        /// <param name="cb_list">The List of ComboBoxes you want to save</param>
        /// <param name="tb_list">The List of TextBoxes you want to save</param>
        public Savable_WPF_Obj(List<ComboBox> cb_list, List<TextBox> tb_list)
        {
            _cb_list = cb_list;
            _tb_list = tb_list;
            _tc_list = new List<TabControl>() { };
        }
        #endregion
    }
}
