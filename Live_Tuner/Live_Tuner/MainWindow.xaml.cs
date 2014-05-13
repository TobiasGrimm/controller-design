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
using controller_design.Schematic;

namespace controller_design.WPF
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables
        //Control Loops
        /// <summary>
        /// PT1 Control Loop
        /// </summary>
        PT1 _PT1 = new PT1(2f, 0.005f);
        /// <summary>
        /// IT1 Control Loop
        /// </summary>
        IT1 _IT1 = new IT1();
        /// <summary>
        /// PT2 Control Loop with damping bigger 1
        /// </summary>
        PT2_wdb1 _PT2_wdb1 = new PT2_wdb1();
        /// <summary>
        /// PT2 Control Loop with damping smaler equal 1
        /// </summary>
        PT2_wdse1 _PT2_wdse1 = new PT2_wdse1();

        //Controller
        /// <summary>
        /// I-Controller
        /// </summary>
        Controller_I _I = new Controller_I();
        /// <summary>
        /// P-Controller
        /// </summary>
        Controller_P _P = new Controller_P();
        /// <summary>
        /// PI-Controller
        /// </summary>
        Controller_PI _PI = new Controller_PI();

        //Jamming
        /// <summary>
        /// Jamming
        /// </summary>
        Step _Jamming = new Step();

        //Simulator
        Simulator _Simulator;
        float _Ts_Base = 200.0f;
        float _Ts_exponent = (float)Math.Pow(10, -6);
        float _T_end = 300.0f * 0.0002f;
        #endregion
        /// <summary>
        /// Init Main Window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            //Set default Controller
            tab_Regler_P.IsEnabled = false;
            tab_Regler_I.IsEnabled = true;
            tab_Regler_PI.IsEnabled = false;
            tab_Regler_PID.IsEnabled = false;

            //init Simulator
            combmBox_Zeit.SelectedItem = combmBox_Zeit.Items[2];
            Optimize.Controller(_PT1, _I);
            _Simulator = new Simulator (_I,_Jamming,_PT1);
        }
        #region Slider
        /// <summary>
        /// Update Vs of PT1 Control Loop and plot graph
        /// </summary>
        /// <param name="output">The new Vs-Value for the PT1 Loop</param>
        private void Base_Slider_PT1_Vs_value_changed(float output)
        {
            _PT1._Vs = output;
            _PT1.recalc_coefficients();
            plot_graph();
        }
        /// <summary>
        /// Update T1 of PT1 Control Loop and plot graph
        /// </summary>
        /// <param name="output">The new T1-Value for the PT1 Loop</param>
        private void Base_Slider_PT1_T1_value_changed(float output)
        {
            _PT1._T1 = output;
            _PT1.recalc_coefficients();
            plot_graph();
        }
        /// <summary>
        /// Update Ti of IT1 Control Loop and plot graph
        /// </summary>
        /// <param name="output">The new Ti-Value for the IT1 Loop</param>
        private void Base_Slider_IT1_Ti_value_changed(float output)
        {
            _IT1._Ti = output;
            _IT1.recalc_coefficients();
            plot_graph();
        }
        /// <summary>
        /// Update T2 of IT1 Control Loop and plot graph
        /// </summary>
        /// <param name="output">The new Ti-Value for the IT2 Loop</param>
        private void Base_Slider_IT1_T2_value_changed(float output)
        {
            _IT1._T2 = output;
            _IT1.recalc_coefficients();
            plot_graph();
        }
        /// <summary>
        /// Update Vs of PT2 with damping bigger 1 Control Loop and plot graph
        /// </summary>
        /// <param name="output">The new Vs-Value for the PT2 Loop</param>
        private void Base_Slider_PT2wdb1_value_changed(float output)
        {
            _PT2_wdb1._Vs = output;
            _PT2_wdb1.recalc_coefficients();
            plot_graph();
        }
        /// <summary>
        /// Update T1 of PT2 with damping bigger 1 Control Loop and plot graph
        /// </summary>
        /// <param name="output">The new T1-Value for the PT2 Loop</param>
        private void Base_Slider_PT2wdb1_T1_value_changed(float output)
        {
            _PT2_wdb1._T1 = output;
            _PT2_wdb1.recalc_coefficients();
            plot_graph();
        }
        /// <summary>
        /// Update T2 of PT2 with damping bigger 1 Control Loop and plot graph
        /// </summary>
        /// <param name="output">The new T2-Value for the PT2 Loop</param>
        private void Base_Slider_PT2wdb1_T2_value_changed(float output)
        {
            _PT2_wdb1._T2 = output;
            _PT2_wdb1.recalc_coefficients();
            plot_graph();
        }
        /// <summary>
        /// Update Vs of PT2 with damping smaller equal 1 Control Loop and plot graph
        /// </summary>
        /// <param name="output">The new Vs-Value for the PT2 Loop</param>
        private void Base_Slider_PT2_wdse1_Vs_value_changed(float output)
        {
            _PT2_wdse1._Vs = output;
            _PT2_wdse1.recalc_coefficients();
            plot_graph();
        }
        /// <summary>
        /// Update damping of PT2 with damping smaller equal 1 Control Loop and plot graph
        /// </summary>
        /// <param name="output">The new d-Value for the PT2 Loop</param>
        private void Base_Slider_PT2_wdse1_d_value_changed(float output)
        {
            _PT2_wdse1._d = output;
            _PT2_wdse1.recalc_coefficients();
            plot_graph();
        }
        /// <summary>
        /// Update T of PT2 with damping smaller equal 1 Control Loop and plot graph
        /// </summary>
        /// <param name="output">The new T-Value for the PT2 Loop</param>
        private void Base_Slider_PT2_wdse1_T_value_changed(float output)
        {
            _PT2_wdse1._T = output;
            _PT2_wdse1.recalc_coefficients();
            plot_graph();
        }
        /// <summary>
        /// Update Ti of I-Controller and plot graph
        /// </summary>
        /// <param name="output">The new Ti-Value for the Controller</param>
        private void Base_Slider_I_Ti_value_changed(float output)
        {
            _I._Ti = output;
            _I.recalc_coefficients();
            plot_graph();
        }
        /// <summary>
        /// Update Vr of P-Controller and plot graph
        /// </summary>
        /// <param name="output">The new Vr-Value for the Controller</param>
        private void Base_Slider_P_Vr_value_changed(float output)
        {
            _P._Vr = output;
            _P.recalc_coefficients();
            plot_graph();
        }
        /// <summary>
        /// Update Vr of PI-Controller and plot graph
        /// </summary>
        /// <param name="output">The new Vr-Value for the Controller</param>
        private void Base_Slider_PI_Vr_value_changed(float output)
        {
            _PI._Vr = output;
            _PI.recalc_coefficients();
            plot_graph();
        }
        /// <summary>
        /// Update Tn of PI-Controller and plot graph
        /// </summary>
        /// <param name="output">The new Tn-Value for the Controller</param>
        private void Base_Slider_PI_Tn_value_changed(float output)
        {
            _PI._Tn = output;
            _PI.recalc_coefficients();
            plot_graph();
        }
        /// <summary>
        /// Update Vz Gain of the Jamming and plot graph
        /// </summary>
        /// <param name="output">The new Vz-Value for the Jamming</param>
        private void Base_Slider_St_Vz_value_changed(float output)
        {
            _Jamming._step_Value = output;
            plot_graph();
        }
        /// <summary>
        /// Update Tz Timestep of the Jamming and plot graph
        /// </summary>
        /// <param name="output">The new Tz-Value for the Jamming</param>
        private void Base_Slider_St_Tz_value_changed(float output)
        {
            _Jamming._step_Time = output;
            plot_graph();
        }
        #endregion
        #region select_Controller_and_Loop
        /// <summary>
        /// Hide all Controllers who are bad for this Loop. Select this Loop and plot the graph;
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">arguments</param>
        private void tab_Strecke_PT1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tab_Regler_P.IsEnabled = false;
            tab_Regler_I.IsEnabled = true;
            tab_Regler_PI.IsEnabled = false;
            tab_Regler_PID.IsEnabled = false;
            tab_Regler_I.Focus();
            _Simulator.replace_in_Schematic_at_pos(1, _I);
            _Simulator.replace_in_Schematic_at_pos(3, _PT1);
            plot_graph();
        }
        /// <summary>
        /// Hide all Controllers who are bad for this Loop. Select this Loop and plot the graph;
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">arguments</param>
        private void tab_Strecke_IT1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tab_Regler_P.IsEnabled = true;
            tab_Regler_I.IsEnabled = false;
            tab_Regler_PI.IsEnabled = true;
            tab_Regler_PID.IsEnabled = false;
            if (tab_Regler_PI.IsSelected == false)
            {
                tab_Regler_P.Focus();
                _Simulator.replace_in_Schematic_at_pos(1, _P);
            }
            _Simulator.replace_in_Schematic_at_pos(3, _IT1);
            plot_graph();
        }
        /// <summary>
        /// Hide all Controllers who are bad for this Loop. Select this Loop and plot the graph;
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">arguments</param>
        private void tab_Strecke_PT2_wdse1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tab_Regler_P.IsEnabled = false;
            tab_Regler_I.IsEnabled = true;
            tab_Regler_PI.IsEnabled = true;
            tab_Regler_PID.IsEnabled = false;
            if (tab_Regler_PI.IsSelected == false)
            {
                tab_Regler_I.Focus();
                _Simulator.replace_in_Schematic_at_pos(1, _I);
            }
            _Simulator.replace_in_Schematic_at_pos(3, _PT2_wdse1);
            plot_graph();
        }
        /// <summary>
        /// Hide all Controllers who are bad for this Loop. Select this Loop and plot the graph;
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">arguments</param>
        private void tab_Strecke_PT2_wdb1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tab_Regler_P.IsEnabled = true;
            tab_Regler_I.IsEnabled = false;
            tab_Regler_PI.IsEnabled = true;
            tab_Regler_PID.IsEnabled = false;
            if (tab_Regler_PI.IsSelected == false)
            {
                tab_Regler_P.Focus();
                _Simulator.replace_in_Schematic_at_pos(1, _P);
            }
            _Simulator.replace_in_Schematic_at_pos(3, _PT2_wdb1);
            plot_graph();
        }
        /// <summary>
        /// Hide all Controllers who are bad for this Loop. Select this Loop and plot the graph;
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">arguments</param>
        private void tab_Strecke_Beliebig_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tab_Regler_P.IsEnabled = true;
            tab_Regler_I.IsEnabled = true;
            tab_Regler_PI.IsEnabled = true;
            tab_Regler_PID.IsEnabled = true;
            plot_graph();
        }
        /// <summary>
        /// Select this Controller and plot the graph.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">arguments</param>
        private void tab_Regler_I_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _Simulator.replace_in_Schematic_at_pos(1, _I);
            plot_graph();
        }
        /// <summary>
        /// Select this Controller and plot the graph.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">arguments</param>
        private void tab_Regler_P_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _Simulator.replace_in_Schematic_at_pos(1, _P);
            plot_graph();
        }
        /// <summary>
        /// Select this Controller and plot the graph.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">arguments</param>
        private void tab_Regler_PI_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _Simulator.replace_in_Schematic_at_pos(1, _PI);
            plot_graph();
        }
        #endregion
        #region Plot
        /// <summary>
        /// Start the simulation and plot the graph
        /// </summary>
        void plot_graph()
        {
            if (_Simulator != null)
            {
                float[,] result = _Simulator.simulate(_Ts_Base * _Ts_exponent, _T_end);

                //List<KeyValuePair<float, float>> list = new List<KeyValuePair<float, float>>();

                //Plott_o_mat.UserControl1 x = new Plott_o_mat.UserControl1();

                Graph.plot(result);
                TextBlock1.Text = result[0, result.Length / 2 - 1].ToString();
            }
        }
        #endregion
        #region Optimize_Controller
        /// <summary>
        /// Optimize Controller-I and plot the graph
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">arguments</param>
        private void butten_Auslegen_I_Click(object sender, RoutedEventArgs e)
        {
            if(tab_Strecke_PT1.IsSelected)
                Optimize.Controller(_PT1, _I);
            else if (tab_Strecke_PT2_wdse1.IsSelected)
                Optimize.Controller(_PT2_wdse1, _I);
            Base_Slider_I_Ti.set_Base(_I._Ti);
        }
        /// <summary>
        /// Optimize Controller-P and plot the graph
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">arguments</param>
        private void butten_auslegen_P_Click(object sender, RoutedEventArgs e)
        {
            if (tab_Strecke_IT1.IsSelected)
                Optimize.Controller(_IT1, _P);
            else if (tab_Strecke_PT2_wdb1.IsSelected)
                Optimize.Controller(_PT2_wdb1, _P);
            Base_Slider_P_Vr.set_Base(_P._Vr);
        }
        /// <summary>
        /// Optimize Controller-PI and plot the graph
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">arguments</param>
        private void butten_auslegen_PI_Click(object sender, RoutedEventArgs e)
        {
            if (tab_Strecke_IT1.IsSelected)
                Optimize.Controller(_IT1, _PI);
            else if (tab_Strecke_PT2_wdb1.IsSelected)
                Optimize.Controller(_PT2_wdb1, _PI);
            else if (tab_Strecke_PT2_wdse1.IsSelected)
                Optimize.Controller(_PT2_wdse1, _PI);
            Base_Slider_PI_Vr.set_Base(_PI._Vr);
            Base_Slider_PI_Tn.set_Base(_PI._Tn);
        }
        #endregion
        #region Sample_Time
        /// <summary>
        /// Update Sample Time Base Ts and plot the graph
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">exponent</param>
        private void textBox_Ts_TextChanged(object sender, TextChangedEventArgs e)
        {
            float.TryParse(textBox_Ts.Text, out _Ts_Base);
            plot_graph();
        }
        /// <summary>
        /// Set exponent for the Sample Time to 10^0 and plot the graph
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">arguments</param>
        private void comboBox_s_Selected(object sender, RoutedEventArgs e)
        {
            _Ts_exponent = (float)Math.Pow(10, 0);
            plot_graph();
        }
        /// <summary>
        /// Set exponent for the Sample Time to 10^-3 and plot the graph
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">arguments</param>
        private void comboBox_ms_Selected(object sender, RoutedEventArgs e)
        {
            _Ts_exponent = (float)Math.Pow(10, -3);
            plot_graph();
        }
        /// <summary>
        /// Set exponent for the Sample Time to 10^-6 and plot the graph
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">arguments</param>
        private void comboBox_µs_Selected(object sender, RoutedEventArgs e)
        {
            _Ts_exponent = (float)Math.Pow(10, -6);
            plot_graph();
        }
        /// <summary>
        /// Set exponent for the Sample Time to 10^-9 and plot the graph
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">arguments</param>
        private void comboBox_ns_Selected(object sender, RoutedEventArgs e)
        {
            _Ts_exponent = (float)Math.Pow(10, -9);
            plot_graph();
        }
        #endregion
    }
}
