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
        //Control Loops
        PT1 _PT1 = new PT1();
        IT1 _IT1 = new IT1();
        PT2_wdb1 _PT2_wdb1 = new PT2_wdb1();
        PT2_wdse1 _PT2_wdse1 = new PT2_wdse1();

        //Controller
        Controller_I _I = new Controller_I();
        Controller_P _P = new Controller_P();
        Controller_PI _PI = new Controller_PI();

        //Simulator
        Simulator _Simulator;
        public MainWindow()
        {
            InitializeComponent();

            //Set default Controller
            tab_Regler_P.IsEnabled = false;
            tab_Regler_I.IsEnabled = true;
            tab_Regler_PI.IsEnabled = false;
            tab_Regler_PID.IsEnabled = false;

            //init Simulator
            _Simulator = new Simulator (_I,_PT1);
        }
        #region Slider
        private void Base_Slider_PT1_Vs_value_changed(float output)
        {
            _PT1._Vs = output;
            _PT1.recalc_coefficients();
        }

        private void Base_Slider_PT1_T1_value_changed(float output)
        {
            _PT1._T1 = output;
            _PT1.recalc_coefficients();
        }
        private void Base_Slider_IT1_Ti_value_changed(float output)
        {
            _IT1._Ti = output;
            _IT1.recalc_coefficients();
        }

        private void Base_Slider_IT1_T2_value_changed(float output)
        {
            _IT1._T2 = output;
            _IT1.recalc_coefficients();
        }

        private void Base_Slider_PT2wdb1_value_changed(float output)
        {
            _PT2_wdb1._Vs = output;
            _PT2_wdb1.recalc_coefficients();
        }

        private void Base_Slider_PT2wdb1_T1_value_changed(float output)
        {
            _PT2_wdb1._T1 = output;
            _PT2_wdb1.recalc_coefficients();
        }

        private void Base_Slider_PT2wdb1_T2_value_changed(float output)
        {
            _PT2_wdb1._T2 = output;
            _PT2_wdb1.recalc_coefficients();
        }
        private void Base_Slider_PT2_wdse1_Vs_value_changed(float output)
        {
            _PT2_wdse1._Vs = output;
            _PT2_wdse1.recalc_coefficients();
        }

        private void Base_Slider_PT2_wdse1_d_value_changed(float output)
        {
            _PT2_wdse1._d = output;
            _PT2_wdse1.recalc_coefficients();
        }

        private void Base_Slider_PT2_wdse1_T_value_changed(float output)
        {
            _PT2_wdse1._T = output;
            _PT2_wdse1.recalc_coefficients();
        }

        private void Base_Slider_I_Ti_value_changed(float output)
        {
            _I._Ti = output;
            _I.recalc_coefficients();
        }

        private void Base_Slider_P_Vr_value_changed(float output)
        {
            _P._Vr = output;
            _P.recalc_coefficients();
        }

        private void Base_Slider_PI_Vr_value_changed(float output)
        {
            _PI._Vr = output;
            _PI.recalc_coefficients();
        }

        private void Base_Slider_PI_Tn_value_changed(float output)
        {
            _PI._Tn = output;
            _PI.recalc_coefficients();
        }
        #endregion
        #region Control-Loop_select
        private void tab_Strecke_PT1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tab_Regler_P.IsEnabled = false;
            tab_Regler_I.IsEnabled = true;
            tab_Regler_PI.IsEnabled = false;
            tab_Regler_PID.IsEnabled = false;
            tab_Regler_I.Focus();
        }

        private void tab_Strecke_IT1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tab_Regler_P.IsEnabled = true;
            tab_Regler_I.IsEnabled = false;
            tab_Regler_PI.IsEnabled = true;
            tab_Regler_PID.IsEnabled = false;
            if (tab_Regler_PI.IsSelected == false)
                tab_Regler_P.Focus();
        }
        private void tab_Strecke_PT2dk2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tab_Regler_P.IsEnabled = true;
            tab_Regler_I.IsEnabled = false;
            tab_Regler_PI.IsEnabled = true;
            tab_Regler_PID.IsEnabled = false;
            if (tab_Regler_PI.IsSelected == false)
                tab_Regler_P.Focus();
        }
        private void tab_Strecke_PT2dg1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tab_Regler_P.IsEnabled = true;
            tab_Regler_I.IsEnabled = false;
            tab_Regler_PI.IsEnabled = true;
            tab_Regler_PID.IsEnabled = false;
            if (tab_Regler_PI.IsSelected == false)
                tab_Regler_P.Focus();
        }
        private void tab_Strecke_Beliebig_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tab_Regler_P.IsEnabled = true;
            tab_Regler_I.IsEnabled = true;
            tab_Regler_PI.IsEnabled = true;
            tab_Regler_PID.IsEnabled = true;
        }
        #endregion
    }
}
