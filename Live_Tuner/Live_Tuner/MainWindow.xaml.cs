﻿using System;
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
using controller_design.Save_and_load;

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
        PT1 _PT1 = new PT1();
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
        /// <summary>
        /// Filter Coefficients a (backward)
        /// </summary>
        float[] _a = {1.0f,-200f};
        /// <summary>
        /// Filter Coefficients b (forward)
        /// </summary>
        float[] _b = {0f, 400f};

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
        /// <summary>
        /// The Simulator
        /// </summary>
        Simulator _Simulator;
        /// <summary>
        /// Base Value for the Sample Time of the simulation
        /// </summary>
        float _Ts_Base = 200.0f;
        /// <summary>
        /// exponent for the Sample Time of the simulation
        /// </summary>
        float _Ts_exponent = (float)Math.Pow(10, -6);
        /// <summary>
        /// Base Value for the end Time of the simulation
        /// </summary>
        float _Tend_Base = 400.0f;
        /// <summary>
        /// exponent value for the end Time of the simulation
        /// </summary>
        float _Tend_exponent = (float)Math.Pow(10, -3);
        /// <summary>
        /// flag for the plot (if false -> plot is off)
        /// </summary>
        bool _plot_on = false;
        /// <summary>
        /// every x value from the Simulation will be plotted
        /// </summary>
        int  _plot_count = 5;
        /// <summary>
        /// flag for the warning (if true -> the warning will be disabled)
        /// </summary>
        bool _ignore_warnings = false;
        /// <summary>
        /// The list of savable obj for the FileManager
        /// </summary>
        List<Isavable> _savable_array;
        #endregion
        /// <summary>
        /// Init Main Window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            //Set default Controller
            tab_Regler_I.IsEnabled = true;
            tab_Regler_P.IsEnabled = false;
            tab_Regler_PI.IsEnabled = false;
            tab_Regler_PID.IsEnabled = false;

            //init The Sliders
            Base_Slider_PT1_Vs.set_Base(2.0f);         //PT1 Vs
            Base_Slider_PT1_T1.set_Base(0.005f);       //PT1 T1
            Base_Slider_IT1_Ti.set_Base(2.0f);         //IT1 Ti
            Base_Slider_IT1_T2.set_Base(0.005f);       //IT1 T2
            Base_Slider_PT2_wdb1_Vs.set_Base(2.0f);    //PT2 Vs
            Base_Slider_PT2_wdb1_T1.set_Base(0.005f);  //PT2 T1
            Base_Slider_PT2_wdb1_T2.set_Base(0.001f);  //PT2 T2

            Base_Slider_PT2_wdse1_Vs.set_Base(2.0f);   //PT2 Vs
            Base_Slider_PT2_wdse1_d.set_Base(0.8f);    //PT2 d
            Base_Slider_PT2_wdse1_T.set_Base(0.005f);  //PT2 T

            Optimize.Controller(_IT1, _P);
            Base_Slider_P_Vr.set_Base(_P._Vr);         //P   Vr
            Optimize.Controller(_PT2_wdb1, _PI);
            Base_Slider_PI_Vr.set_Base(_PI._Vr);       //PI  Vr
            Base_Slider_PI_Tn.set_Base(_PI._Tn);       //PI  Tn

            //init Simulator
            Optimize.Controller(_PT1, _I);
            Base_Slider_I_Ti.set_Base(_I._Ti);
            _Simulator = new Simulator (_I,_Jamming,_PT1);
            _plot_on = true;
            plot_graph();

            //init Obj for FileManager
            Savable_WPF_Obj _savable_WPF_objects = new Savable_WPF_Obj(new List<ComboBox>() { combmBox_Zeit, combmBox_Zeit_Tend }, new List<TextBox>() { textBox_Ts, textBox_Tend, textbox_b, textbox_a, textBox_plot_count }, new List<TabControl>() { TabControl_Strecke, TabControl_Regler, TabControl_Infos }, new List<CheckBox>() { CheckBox_LivePlotOn });
            _savable_array = new List<Isavable>() { Base_Slider_PT1_Vs, Base_Slider_PT1_T1, Base_Slider_IT1_Ti, Base_Slider_IT1_T2, Base_Slider_PT2_wdb1_Vs, Base_Slider_PT2_wdb1_T1, Base_Slider_PT2_wdb1_T2, Base_Slider_PT2_wdse1_Vs, Base_Slider_PT2_wdb1_T1, Base_Slider_PT2_wdb1_T2, Base_Slider_PT2_wdse1_Vs, Base_Slider_PT2_wdse1_d, Base_Slider_PT2_wdse1_T, Base_Slider_P_Vr, Base_Slider_PI_Vr, Base_Slider_PI_Tn, Base_Slider_I_Ti, Base_Slider_St_Vz, Base_Slider_St_Tz, _savable_WPF_objects };

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
            check_optimization_for_IT1();
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
            check_optimization_for_IT1();
            plot_graph();
        }
        /// <summary>
        /// Update Vs of PT2 with damping bigger 1 Control Loop and plot graph
        /// </summary>
        /// <param name="output">The new Vs-Value for the PT2 Loop</param>
        private void Base_Slider_PT2_wdb1_Vs_value_changed(float output)
        {
            _PT2_wdb1._Vs = output;
            _PT2_wdb1.recalc_coefficients();
            plot_graph();
        }
        /// <summary>
        /// Update T1 of PT2 with damping bigger 1 Control Loop and plot graph
        /// </summary>
        /// <param name="output">The new T1-Value for the PT2 Loop</param>
        private void Base_Slider_PT2_wdb1_T1_value_changed(float output)
        {
            _PT2_wdb1._T1 = output;
            _PT2_wdb1.recalc_coefficients();
            check_optimization_for_PT2_wdb1();
            plot_graph();
        }
        /// <summary>
        /// Update T2 of PT2 with damping bigger 1 Control Loop and plot graph
        /// </summary>
        /// <param name="output">The new T2-Value for the PT2 Loop</param>
        private void Base_Slider_PT2_wdb1_T2_value_changed(float output)
        {
            _PT2_wdb1._T2 = output;
            _PT2_wdb1.recalc_coefficients();
            check_optimization_for_PT2_wdb1();
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
            check_optimization_for_PT2_wdse1();
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
        /// <summary>
        /// Transform Text to Filter Coefficients b
        /// replace in Schematic and plot the graph
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">Arguments</param>
        private void textbox_b_TextChanged(object sender, TextChangedEventArgs e)
        {
            float[] help = new float[] { };
            if (split_text2float(textbox_b.Text, ref help))
            {
                _b = help;
                Transferfunction _Tf = new Transferfunction(_a, _b);
                if (_Simulator != null)
                    _Simulator.replace_in_Schematic_at_pos(3, _Tf);
                plot_graph();
            }

        }
        /// <summary>
        /// Transform Text to Filter Coefficients a
        /// replace in Schematic and plot the graph
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">Arguments</param>
        private void textbox_a_TextChanged(object sender, TextChangedEventArgs e)
        {
            float[] help = new float[] { };
            if (split_text2float("1;" + textbox_a.Text, ref help))
            {
                _a = help;
                Transferfunction _Tf = new Transferfunction(_a, _b);
                if (_Simulator != null)
                    _Simulator.replace_in_Schematic_at_pos(3, _Tf);
                plot_graph();
            }
        }
        #endregion
        #region Plot
        /// <summary>
        /// Start the simulation and plot the graph
        /// </summary>
        void plot_graph()
        {
            MessageBoxButton b1 = MessageBoxButton.YesNo;
            MessageBoxImage i1 = MessageBoxImage.Warning;
            float Ts =  _Ts_Base * _Ts_exponent;
            float Tend = _Tend_Base * _Tend_exponent;
            if (_plot_on)                       
                if (_Simulator != null)
                {
                    if ((Tend/Ts)/_plot_count >= 1000 && !_ignore_warnings)
                    {
                        MessageBoxResult mbr1 = MessageBox.Show("ACHTUNG: Für die Erstellung des Plots mit den aktuellen Solver-Parametern werden " + (int)((Tend / Ts) / _plot_count) + " Werte geplottet. Dies kann sehr zeitintensiv sein oder zum Absturz führen! \n Sind Sie sicher, dass Sie dies durchführen wollen? \n (wenn nicht -> Live Plot wird abgeschaltet)", "Warnung", b1, i1);
                        switch(mbr1)
                        {
                            case MessageBoxResult.Yes:
                                MessageBoxResult mbr2 = MessageBox.Show("Wollen Sie diese Warnung dauerhaft ignorieren?", "Warnung", b1, i1);
                                switch(mbr2)
                                {
                                    case MessageBoxResult.Yes:
                                        _ignore_warnings = true;
                                        break;
                                    case MessageBoxResult.No:
                                        _ignore_warnings = false;
                                        break;
                                }
                                break;
                            case MessageBoxResult.No:
                                CheckBox_LivePlotOn.IsChecked = false;

                                break;
                        }
                    }
                    if (_plot_on) {
                        float[,] result = _Simulator.simulate(Ts, Tend);
                        if (result[0,result.Length/2-1]==result[0,result.Length/2-1])            // is the simulation korrekt? (NaN problem)
                          Graph.plot(result, _plot_count);
                    } 
                }
        }
        #endregion
        #region Optimize_and_select_Controller
        /// <summary>
        /// Optimize Controller-I and plot the graph
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">arguments</param>
        private void butten_auslegen_I_Click(object sender, RoutedEventArgs e)
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
        /// <summary>
        /// Enable all Optimizations (for all Controllers)
        /// </summary>
        void enable_all_optimizations()
        {
            butten_auslegen_I.IsEnabled = true;
            butten_auslegen_P.IsEnabled = true;
            butten_auslegen_PI.IsEnabled = true;
        }
        /// <summary>
        /// Check if the IT1 Control Loop can be optimized and enable if so
        /// </summary>
        void check_optimization_for_IT1()
        {
            if (_IT1._Ti / _IT1._T2 > 1)
                butten_auslegen_P.IsEnabled = true;
            else
                butten_auslegen_P.IsEnabled = false;
            if (_IT1._Ti / _IT1._T2 > 0)
                butten_auslegen_PI.IsEnabled = true;
            else
                butten_auslegen_PI.IsEnabled = false;
        }
        /// <summary>
        /// Check if the PT2 with damping bigger 1 Control Loop can be optimized and enable if so
        /// </summary>
        void check_optimization_for_PT2_wdb1()
        {
            if (_PT2_wdb1._T1 / _PT2_wdb1._T2 > 8)
                butten_auslegen_P.IsEnabled = true;
            else
                butten_auslegen_P.IsEnabled = false;
            if (_PT2_wdb1._T1 / _PT2_wdb1._T2 > 1)
                butten_auslegen_PI.IsEnabled = true;
            else
                butten_auslegen_PI.IsEnabled = false;
        }
        /// <summary>
        /// Check if the PT2 Control Loop with damping smaller equal 1 can be optimized and enable if so
        /// </summary>
        void check_optimization_for_PT2_wdse1()
        {
            if (_PT2_wdse1._d >= 0.5 && _PT2_wdse1._d <= 1)
                butten_auslegen_I.IsEnabled = true;
            else
                butten_auslegen_I.IsEnabled = false;
            if (_PT2_wdse1._d > 1 / Math.Sqrt(2) && _PT2_wdse1._d <= 1)
                butten_auslegen_PI.IsEnabled = true;
            else
                butten_auslegen_PI.IsEnabled = false;
        }
        /// <summary>
        /// When the Selection Changed, it will calculate the new possible loops.
        /// Ans replace the loop in the Schematic
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">Arguments</param>
        private void TabControl_Strecke_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItem lbi = ((sender as TabControl).SelectedItem as TabItem);
            if (lbi.Name == "tab_Strecke_PT1")
            {
                tab_Regler_P.IsEnabled = false;
                tab_Regler_I.IsEnabled = true;
                tab_Regler_PI.IsEnabled = false;
                tab_Regler_PID.IsEnabled = false;
                TabControl_Regler.SelectedIndex = 0;
                enable_all_optimizations();

                _Simulator.replace_in_Schematic_at_pos(1, _I);
                _Simulator.replace_in_Schematic_at_pos(3, _PT1);
            }
            else if (lbi.Name == "tab_Strecke_IT1")
            {
                tab_Regler_P.IsEnabled = true;
                tab_Regler_I.IsEnabled = false;
                tab_Regler_PI.IsEnabled = true;
                tab_Regler_PID.IsEnabled = false;
                enable_all_optimizations();
                check_optimization_for_IT1();

                if (tab_Regler_PI.IsSelected == false)
                {
                    TabControl_Regler.SelectedIndex = 1;
                    _Simulator.replace_in_Schematic_at_pos(1, _P);
                }
                _Simulator.replace_in_Schematic_at_pos(3, _IT1);
            }
            else if (lbi.Name == "tab_Strecke_PT2_wdb1")
            {
                tab_Regler_P.IsEnabled = true;
                tab_Regler_I.IsEnabled = false;
                tab_Regler_PI.IsEnabled = true;
                tab_Regler_PID.IsEnabled = false;
                enable_all_optimizations();
                check_optimization_for_PT2_wdb1();

                if (tab_Regler_PI.IsSelected == false)
                {
                    TabControl_Regler.SelectedIndex = 1;
                    _Simulator.replace_in_Schematic_at_pos(1, _P);
                }
                _Simulator.replace_in_Schematic_at_pos(3, _PT2_wdb1);
            }
            else if (lbi.Name == "tab_Strecke_PT2_wdse1")
            {
                tab_Regler_P.IsEnabled = false;
                tab_Regler_I.IsEnabled = true;
                tab_Regler_PI.IsEnabled = true;
                tab_Regler_PID.IsEnabled = false;
                enable_all_optimizations();
                check_optimization_for_PT2_wdse1();

                if (tab_Regler_PI.IsSelected == false)
                {
                    TabControl_Regler.SelectedIndex = 0;
                    _Simulator.replace_in_Schematic_at_pos(1, _I);
                }
                _Simulator.replace_in_Schematic_at_pos(3, _PT2_wdse1);
            }
            else if (lbi.Name == "tab_Strecke_Beliebig")
            {
                tab_Regler_P.IsEnabled = true;
                tab_Regler_I.IsEnabled = true;
                tab_Regler_PI.IsEnabled = true;
                tab_Regler_PID.IsEnabled = true;
                butten_auslegen_I.IsEnabled = false;
                butten_auslegen_P.IsEnabled = false;
                butten_auslegen_PI.IsEnabled = false;

                Transferfunction _Tf = new Transferfunction(_a, _b);
                _Simulator.replace_in_Schematic_at_pos(3, _Tf);
            }
            plot_graph();
        }
        /// <summary>
        /// It will replace the Controller in the Schematic
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">arguments</param>
        private void TabControl_Regler_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItem lbi = ((sender as TabControl).SelectedItem as TabItem);
            if (lbi.Name == "tab_Regler_I")
            {
                _Simulator.replace_in_Schematic_at_pos(1, _I);
            }
            else if (lbi.Name == "tab_Regler_P")
            {
                _Simulator.replace_in_Schematic_at_pos(1, _P);
            }
            else if (lbi.Name == "tab_Regler_PI")
            {
                _Simulator.replace_in_Schematic_at_pos(1, _PI);
            }
            plot_graph();
        }
        #endregion
        #region Time
        /// <summary>
        /// Update Sample Time Base Ts and plot the graph
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">exponent</param>
        private void textBox_Ts_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (trimtext2float(textBox_Ts.Text, ref _Ts_Base))
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
        /// <summary>
        /// Set exponent for the End Time to 10^-0 and plot the graph
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">arguments</param>
        private void comboBox_Tend_s_Selected(object sender, RoutedEventArgs e)
        {
            _Tend_exponent = (float)Math.Pow(10, 0);
            plot_graph();
        }
        /// <summary>
        /// Set exponent for the End Time to 10^-3 and plot the graph
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">arguments</param>
        private void comboBox_Tend_ms_Selected(object sender, RoutedEventArgs e)
        {
            _Tend_exponent = (float)Math.Pow(10, -3);
            plot_graph();
        }
        /// <summary>
        /// Set exponent for the End Time to 10^-6 and plot the graph
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">arguments</param>
        private void comboBox_Tend_µs_Selected(object sender, RoutedEventArgs e)
        {
            _Tend_exponent = (float)Math.Pow(10, -6);
            plot_graph();
        }
        /// <summary>
        /// Set exponent for the End Time to 10^-9 and plot the graph
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">arguments</param>
        private void comboBox_Tend_ns_Selected(object sender, RoutedEventArgs e)
        {
            _Tend_exponent = (float)Math.Pow(10, -9);
            plot_graph();
        }
        /// <summary>
        /// Update End Time Base Tend and plot the graph
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">exponent</param>
        private void textBox_Tend_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (trimtext2float(textBox_Tend.Text, ref _Tend_Base))
                plot_graph();
        }
        /// <summary>
        /// disable Live Plot
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">Arguments</param>
        private void CheckBox_LivePlotOn_Unchecked(object sender, RoutedEventArgs e)
        {
            _plot_on = false;
        }
        /// <summary>
        /// enable Live Plot
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">Arguments</param>
        private void CheckBox_LivePlotOn_Checked(object sender, RoutedEventArgs e)
        {
            _plot_on = true;
            plot_graph();
        }
        /// <summary>
        /// every x value from the Simulation will be plotted.
        /// Where x is an Integer in the TextBox
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">Arguments</param>
        private void textBox_plot_count_TextChanged(object sender, TextChangedEventArgs e)
        {
            int help;
            if (int.TryParse(textBox_plot_count.Text, out help))
            {
                if (help > 0)
                {
                    _plot_count = help;
                    plot_graph();
                }
            }
            else
            {
                textBox_plot_count.Text = "5";
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// replace all . with , in the Text
        /// remove all spaces in the Text
        /// Try to Parse the text to float
        /// </summary>
        /// <param name="input">The string you want to parse</param>
        /// <param name="output">The parsed string (in float)</param>
        /// <returns>true if all was successful</returns>
        bool trimtext2float(string input, ref float output)
        {
            float temp;
            bool all_ok = true;
            string help = input.Replace(".", ",").Replace(" ","");
            if (!float.TryParse(help, out temp))
                all_ok = false;
            output = temp;
            return all_ok;
        }
        /// <summary>
        /// Split a Text at ';' and try to parse each to float
        /// </summary>
        /// <param name="input">The text you want to split</param>
        /// <param name="output">The parsed float array</param>
        /// <returns>true if all was successful</returns>
        bool split_text2float(string input, ref float[] output)
        {
            string[] help_split;
            float temp = 0.0f;
            bool all_ok = true;
            LinkedList<float> result = new LinkedList<float>();
            help_split = (input.Trim()).Split(';');
            foreach (string s in help_split)
            {
                if(!trimtext2float(s, ref temp))
                    all_ok = false;
                result.AddLast(temp);
            }
            output = result.ToArray();
            return all_ok;
        }
        #endregion
        #region save&load
        /// <summary>
        /// Save the all relevant Obj to a .LiveTuner File
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">Arguments</param>
        private void butten_save_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Optimization1"; // Default file name
            dialog.DefaultExt = ".LiveTuner"; // Default file extension
            dialog.Filter = "LiveTuner files (*.LiveTuner)|*.LiveTuner"; // Filter files by extension
            bool? result = dialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                File_Manager.save2file(dialog.FileName, _savable_array);
            }
        }
        /// <summary>
        /// Load all the relevant Objs from a .LiveTuner File
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">Arguments</param>
        private void butten_load_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "LiveTuner files (*.LiveTuner)|*.LiveTuner";
            bool? result = dialog.ShowDialog();
            _plot_on = false;
            if (result.HasValue && result.Value)
            {
                File_Manager.load_from_file(dialog.FileName,_savable_array);
            }
            _plot_on = (bool)CheckBox_LivePlotOn.IsChecked;
            plot_graph();
        }
        #endregion
    }
}
