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

        public void plot(Chart chart)
        {
            int[,] x = new int[2, 12];
            x[0, 0] = 1;
            x[0, 1] = 2;
            x[0, 2] = 3;
            x[0, 3] = 4;
            x[0, 4] = 5;
            x[0, 5] = 6;
            x[0, 6] = 7;
            x[0, 7] = 8;
            x[0, 8] = 9;
            x[0, 9] = 10;
            x[0, 10] = 11;
            x[0, 11] = 12;
            x[1, 0] = 5;
            x[1, 1] = 4;
            x[1, 2] = 2;
            x[1, 3] = 1;
            x[1, 4] = 5;
            x[1, 5] = 7;
            x[1, 6] = 9;
            x[1, 7] = 10;
            x[1, 8] = 12;
            x[1, 9] = 14;
            x[1, 10] = 16;
            x[1, 11] = 18;

            List<KeyValuePair<float, float>> list = new List<KeyValuePair<float, float>>();

            for(int i = 0; i<(x.Length/2); i++)
            {
                list.Insert(0, new KeyValuePair<float, float>((float) x[0,i],(float) x[1,i]));      
            }

            ((LineSeries)chart.Series[0]).ItemsSource = list;
        }

        private void Plot_Chart_Loaded(object sender, RoutedEventArgs e)
        {
            

        }
    }
}
