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

using System.Windows.Controls.DataVisualization;
using System.Windows.Controls.DataVisualization.Charting;

namespace Plott_o_mat
{
    /// <summary>
    /// Interaktionslogik für UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();            
        }

        public void plot(float [,] x)
        {
            
            List<KeyValuePair<float, float>> list = new List<KeyValuePair<float, float>>();

            for(int i = 0; i<(x.Length/2); i++)
            {
                list.Insert(0, new KeyValuePair<float, float>(x[1,i], x[0,i]));      
            }

            ((LineSeries)Plot_Chart.Series[0]).ItemsSource = list;
        }

        private void Plot_Chart_Loaded(object sender, RoutedEventArgs e)
        {
            

        }
    }
}
