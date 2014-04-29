﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Forms.DataVisualization.Charting;

namespace Chart
{
    public partial class Form1 : Form
    {
        bool firstrun = false;

        public Form1()
        {
            InitializeComponent();
            chart_y_label.Visible = false;
            chart_x_label.Visible = false;

            Vs_factor.SelectedIndex = 3;
            T1_factor.SelectedIndex = 3;
            T_sigma_factor.SelectedIndex = 3;
            Vr_factor.SelectedIndex = 3;
            Ti_factor.SelectedIndex = 3;
            Tn_factor.SelectedIndex = 3;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            firstrun = true;

            Random rdn = new Random();

            float[] x = { 0f, 1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f };

            // chart Reseten und neu zeichnen
            chart1.Series.Clear();
            chart1.Series.Add("Amplitude");
            chart1.Series["Amplitude"].ChartType =
                SeriesChartType.Line;

            /* Legende ausblenden */
            chart1.Series["Amplitude"].IsVisibleInLegend = false;   

            /* Farbe der Linie */
            chart1.Series["Amplitude"].Color = Color.Red;   
            //chart1.Series["Amplitude"].BackImage = Color.Black;

            /* Achsenbeschriftung */
            chart1.ChartAreas[0].AxisY.Title = "Amplitude";
            chart1.ChartAreas[0].AxisX.Title = "Zeit in s";

            chart1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseWheel);

            /* X Achsen Skalierung */
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = x.Length;

            for (int i = 0; i < 10; i++)
            {
                chart1.Series["Amplitude"].Points.AddXY(x[i], rdn.Next(0, 100));
            }

        }

        private void chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            if(e.Delta > 0)
            {
                chart1.ChartAreas[0].AxisX.ScaleView.Zoom(
                    chart1.ChartAreas[0].AxisX.ScaleView.ViewMinimum / 2,
                    chart1.ChartAreas[0].AxisX.ScaleView.ViewMaximum / 2);
                chart1.ChartAreas[0].AxisY.ScaleView.Zoom(
                    chart1.ChartAreas[0].AxisY.ScaleView.ViewMinimum / 2,
                    chart1.ChartAreas[0].AxisX.ScaleView.ViewMaximum / 2);
            }
            else
            {
                if(chart1.ChartAreas[0].AxisX.ScaleView.ViewMaximum <
                    chart1.ChartAreas[0].AxisX.Maximum || 
                    chart1.ChartAreas[0].AxisX.ScaleView.ViewMinimum >
                    chart1.ChartAreas[0].AxisX.Minimum)
                {
                    chart1.ChartAreas[0].AxisX.ScaleView.Zoom(
                        chart1.ChartAreas[0].AxisX.ScaleView.ViewMinimum * 2,
                        chart1.ChartAreas[0].AxisY.ScaleView.ViewMaximum * 2);
                    chart1.ChartAreas[0].AxisY.ScaleView.Zoom(
                        chart1.ChartAreas[0].AxisY.ScaleView.ViewMinimum * 2,
                        chart1.ChartAreas[0].AxisY.ScaleView.ViewMaximum * 2);
                }
                else
                {
                    chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                    chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset();
                }

            }
        }

        private void Mouse_Over(object sender, EventArgs e)
        {
            
        }

        private void Mouse_Move(object sender, MouseEventArgs e)
        {
            
            // Liest den Wert an der jerweiligen Position im Chart aus
            var xAxis = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
            var yAxis = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);

            // Ergebnis auf 2 Stellen nach dem Komma runden
            double x = Math.Round(xAxis, 2, MidpointRounding.AwayFromZero);
            double y = Math.Round(yAxis, 2, MidpointRounding.AwayFromZero);

            chart_x_label.Text = x.ToString(); 
            chart_y_label.Text = y.ToString();

            chart_x_label.Location = new Point(e.X + chart1.Location.X, chart1.Location.Y - 15);
            chart_y_label.Location = new Point(chart1.Location.X - 35, e.Y + chart1.Location.Y);


            if(firstrun)
            {
                chart_y_label.Visible = true;
                chart_x_label.Visible = true;
            }
            
        }

        private void Mouse_Leave(object sender, EventArgs e)
        {
            chart_y_label.Visible = false;
            chart_x_label.Visible = false;
        }

        
    }
}
