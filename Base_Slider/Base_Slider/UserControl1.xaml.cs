using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Control_Tools
{
    /// <summary>
    /// The Base Slider is a GUI Element for maximum precision and coolness
    /// </summary>
    public partial class Base_Slider : UserControl
    {
        #region Variables
        /// <summary>
        /// Math components of the Slider
        /// </summary>
        float base_value, slider_value, mult_value;
        /// <summary>
        /// The Name of the Slider, which is represented before it.
        /// </summary>
        public string Label
        {
            get { return textBlock_Name.Text; }
            set { textBlock_Name.Text = value; }
        }
        #endregion
        #region Methods
        /// <summary>
        /// calculate the reult and fire the event "value_changed"
        /// </summary>
        private void calc_and_fire()
        {
            float result = base_value + slider_value * mult_value;
            if (textBox_result != null)
                textBox_result.Text = result.ToString();
            On_value_changed(result);
        }
        /// <summary>
        /// Set Base Value, and reset Slider Value.
        /// </summary>
        /// <param name="base_value">The Value for the new Base</param>
        public void set_Base(float base_value)
        {
            textBox_Base.Text = base_value.ToString("e1");
            Slider_Mult.Value = 0.0f;
            textBox_Mult.Text = (base_value / 2).ToString("e1");
            calc_and_fire();
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Init Base Slider
        /// </summary>
        public Base_Slider()
        {
            InitializeComponent();
            base_value = 0.0f;
            slider_value = 0.0f;
            mult_value = 1.0f;
            textBox_Base.Text = base_value.ToString();
            textBox_Mult.Text = mult_value.ToString();
        }
        #endregion
        #region Events
        /// <summary>
        /// You can register here, if you want to know when a calculation of one step is done.
        /// </summary>
        public event OutputEventHandler value_changed;
        /// <summary>
        /// Will be fired when a calculation of one step is done.
        /// </summary>
        /// <param name="output">The result of the calculation of one step</param>
        private void On_value_changed(float output)
        {
            if (value_changed != null)
                value_changed(output);
        }
        /// <summary>
        /// Read Text Box for the Base Value, calc and fire event "value_changed"
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">arguments</param>
        private void textBox_Base_TextChanged(object sender, TextChangedEventArgs e)
        {
            float.TryParse(textBox_Base.Text, out base_value);
            calc_and_fire();
        }
        /// <summary>
        /// Read Text Box for the Slider Value, calc and fire event "value_changed"
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">arguments</param>
        private void Slider_Mult_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            slider_value = (float)e.NewValue;
            calc_and_fire();
        }
        /// <summary>
        /// Read Text Box for the Mult Value, calc and fire event "value_changed"
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">arguments</param>
        private void textBox_PT1_VS_Skale_TextChanged(object sender, TextChangedEventArgs e)
        {
            float.TryParse(textBox_Mult.Text, out mult_value);
            calc_and_fire();
        }
        #endregion
    }
    /// <summary >
    /// Delegate for the Output Event when a step is done 
    /// </summary >
    public delegate void OutputEventHandler(float output);
}
