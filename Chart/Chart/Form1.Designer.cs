namespace Chart
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.calculate = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_y_label = new System.Windows.Forms.Label();
            this.chart_x_label = new System.Windows.Forms.Label();
            this.pdf_export = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label_Regelstrecke = new System.Windows.Forms.Label();
            this.label_Regler = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.Vs_textBox = new System.Windows.Forms.TextBox();
            this.Vs_factor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Vr_label = new System.Windows.Forms.Label();
            this.Vr_factor = new System.Windows.Forms.ComboBox();
            this.Vr_textBox = new System.Windows.Forms.TextBox();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.T1_label = new System.Windows.Forms.Label();
            this.T1_factor = new System.Windows.Forms.ComboBox();
            this.T1_textBox = new System.Windows.Forms.TextBox();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.Ti_label = new System.Windows.Forms.Label();
            this.Ti_factor = new System.Windows.Forms.ComboBox();
            this.Ti_textBox = new System.Windows.Forms.TextBox();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.T_sigma_label = new System.Windows.Forms.Label();
            this.T_sigma_factor = new System.Windows.Forms.ComboBox();
            this.T_sigma_textBox = new System.Windows.Forms.TextBox();
            this.trackBar5 = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.Tn_label = new System.Windows.Forms.Label();
            this.Tn_factor = new System.Windows.Forms.ComboBox();
            this.Tn_textBox = new System.Windows.Forms.TextBox();
            this.trackBar6 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).BeginInit();
            this.SuspendLayout();
            // 
            // calculate
            // 
            this.calculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.calculate.Location = new System.Drawing.Point(210, 578);
            this.calculate.Name = "calculate";
            this.calculate.Size = new System.Drawing.Size(75, 23);
            this.calculate.TabIndex = 0;
            this.calculate.Text = "Berechnen";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.button1_Click);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(511, 41);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(729, 560);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            this.chart1.MouseLeave += new System.EventHandler(this.Mouse_Leave);
            this.chart1.MouseHover += new System.EventHandler(this.Mouse_Over);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Mouse_Move);
            // 
            // chart_y_label
            // 
            this.chart_y_label.AutoSize = true;
            this.chart_y_label.Location = new System.Drawing.Point(355, 41);
            this.chart_y_label.Name = "chart_y_label";
            this.chart_y_label.Size = new System.Drawing.Size(35, 13);
            this.chart_y_label.TabIndex = 3;
            this.chart_y_label.Text = "label2";
            // 
            // chart_x_label
            // 
            this.chart_x_label.AutoSize = true;
            this.chart_x_label.Location = new System.Drawing.Point(393, 25);
            this.chart_x_label.Name = "chart_x_label";
            this.chart_x_label.Size = new System.Drawing.Size(35, 13);
            this.chart_x_label.TabIndex = 6;
            this.chart_x_label.Text = "label5";
            // 
            // pdf_export
            // 
            this.pdf_export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pdf_export.Location = new System.Drawing.Point(291, 578);
            this.pdf_export.Name = "pdf_export";
            this.pdf_export.Size = new System.Drawing.Size(97, 23);
            this.pdf_export.TabIndex = 7;
            this.pdf_export.Text = "Export to PDF";
            this.pdf_export.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "PT1",
            "IT1",
            "PT2"});
            this.comboBox1.Location = new System.Drawing.Point(41, 67);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(137, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "I",
            "P",
            "PI"});
            this.comboBox2.Location = new System.Drawing.Point(210, 67);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(137, 21);
            this.comboBox2.TabIndex = 9;
            // 
            // label_Regelstrecke
            // 
            this.label_Regelstrecke.AutoSize = true;
            this.label_Regelstrecke.Location = new System.Drawing.Point(71, 51);
            this.label_Regelstrecke.Name = "label_Regelstrecke";
            this.label_Regelstrecke.Size = new System.Drawing.Size(70, 13);
            this.label_Regelstrecke.TabIndex = 11;
            this.label_Regelstrecke.Text = "Regelstrecke";
            // 
            // label_Regler
            // 
            this.label_Regler.AutoSize = true;
            this.label_Regler.Location = new System.Drawing.Point(265, 51);
            this.label_Regler.Name = "label_Regler";
            this.label_Regler.Size = new System.Drawing.Size(38, 13);
            this.label_Regler.TabIndex = 12;
            this.label_Regler.Text = "Regler";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(25, 177);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(101, 45);
            this.trackBar1.TabIndex = 13;
            // 
            // Vs_textBox
            // 
            this.Vs_textBox.Location = new System.Drawing.Point(41, 126);
            this.Vs_textBox.Name = "Vs_textBox";
            this.Vs_textBox.Size = new System.Drawing.Size(137, 20);
            this.Vs_textBox.TabIndex = 14;
            this.Vs_textBox.Text = "0";
            // 
            // Vs_factor
            // 
            this.Vs_factor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Vs_factor.FormattingEnabled = true;
            this.Vs_factor.Items.AddRange(new object[] {
            "1e9",
            "1e6",
            "1e3",
            "1",
            "1e-3",
            "1e-6",
            "1e-9"});
            this.Vs_factor.Location = new System.Drawing.Point(132, 177);
            this.Vs_factor.Name = "Vs_factor";
            this.Vs_factor.Size = new System.Drawing.Size(46, 21);
            this.Vs_factor.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Vs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Skalierung";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Skalierung";
            // 
            // Vr_label
            // 
            this.Vr_label.AutoSize = true;
            this.Vr_label.Location = new System.Drawing.Point(240, 110);
            this.Vr_label.Name = "Vr_label";
            this.Vr_label.Size = new System.Drawing.Size(17, 13);
            this.Vr_label.TabIndex = 21;
            this.Vr_label.Text = "Vr";
            // 
            // Vr_factor
            // 
            this.Vr_factor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Vr_factor.FormattingEnabled = true;
            this.Vr_factor.Items.AddRange(new object[] {
            "1e9",
            "1e6",
            "1e3",
            "1",
            "1e-3",
            "1e-6",
            "1e-9"});
            this.Vr_factor.Location = new System.Drawing.Point(301, 177);
            this.Vr_factor.Name = "Vr_factor";
            this.Vr_factor.Size = new System.Drawing.Size(46, 21);
            this.Vr_factor.TabIndex = 20;
            // 
            // Vr_textBox
            // 
            this.Vr_textBox.Location = new System.Drawing.Point(210, 126);
            this.Vr_textBox.Name = "Vr_textBox";
            this.Vr_textBox.Size = new System.Drawing.Size(137, 20);
            this.Vr_textBox.TabIndex = 19;
            this.Vr_textBox.Text = "0";
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(194, 177);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(101, 45);
            this.trackBar2.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Skalierung";
            // 
            // T1_label
            // 
            this.T1_label.AutoSize = true;
            this.T1_label.Location = new System.Drawing.Point(71, 218);
            this.T1_label.Name = "T1_label";
            this.T1_label.Size = new System.Drawing.Size(20, 13);
            this.T1_label.TabIndex = 26;
            this.T1_label.Text = "T1";
            // 
            // T1_factor
            // 
            this.T1_factor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.T1_factor.FormattingEnabled = true;
            this.T1_factor.Items.AddRange(new object[] {
            "1e9",
            "1e6",
            "1e3",
            "1",
            "1e-3",
            "1e-6",
            "1e-9"});
            this.T1_factor.Location = new System.Drawing.Point(132, 285);
            this.T1_factor.Name = "T1_factor";
            this.T1_factor.Size = new System.Drawing.Size(46, 21);
            this.T1_factor.TabIndex = 25;
            // 
            // T1_textBox
            // 
            this.T1_textBox.Location = new System.Drawing.Point(41, 234);
            this.T1_textBox.Name = "T1_textBox";
            this.T1_textBox.Size = new System.Drawing.Size(137, 20);
            this.T1_textBox.TabIndex = 24;
            this.T1_textBox.Text = "0";
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(25, 285);
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(101, 45);
            this.trackBar3.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(240, 269);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Skalierung";
            // 
            // Ti_label
            // 
            this.Ti_label.AutoSize = true;
            this.Ti_label.Location = new System.Drawing.Point(240, 218);
            this.Ti_label.Name = "Ti_label";
            this.Ti_label.Size = new System.Drawing.Size(16, 13);
            this.Ti_label.TabIndex = 31;
            this.Ti_label.Text = "Ti";
            // 
            // Ti_factor
            // 
            this.Ti_factor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Ti_factor.FormattingEnabled = true;
            this.Ti_factor.Items.AddRange(new object[] {
            "1e9",
            "1e6",
            "1e3",
            "1",
            "1e-3",
            "1e-6",
            "1e-9"});
            this.Ti_factor.Location = new System.Drawing.Point(301, 285);
            this.Ti_factor.Name = "Ti_factor";
            this.Ti_factor.Size = new System.Drawing.Size(46, 21);
            this.Ti_factor.TabIndex = 30;
            // 
            // Ti_textBox
            // 
            this.Ti_textBox.Location = new System.Drawing.Point(210, 234);
            this.Ti_textBox.Name = "Ti_textBox";
            this.Ti_textBox.Size = new System.Drawing.Size(137, 20);
            this.Ti_textBox.TabIndex = 29;
            this.Ti_textBox.Text = "0";
            // 
            // trackBar4
            // 
            this.trackBar4.Location = new System.Drawing.Point(194, 285);
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(101, 45);
            this.trackBar4.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(71, 373);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Skalierung";
            // 
            // T_sigma_label
            // 
            this.T_sigma_label.AutoSize = true;
            this.T_sigma_label.Location = new System.Drawing.Point(71, 322);
            this.T_sigma_label.Name = "T_sigma_label";
            this.T_sigma_label.Size = new System.Drawing.Size(44, 13);
            this.T_sigma_label.TabIndex = 36;
            this.T_sigma_label.Text = "T sigma";
            // 
            // T_sigma_factor
            // 
            this.T_sigma_factor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.T_sigma_factor.FormattingEnabled = true;
            this.T_sigma_factor.Items.AddRange(new object[] {
            "1e9",
            "1e6",
            "1e3",
            "1",
            "1e-3",
            "1e-6",
            "1e-9"});
            this.T_sigma_factor.Location = new System.Drawing.Point(132, 389);
            this.T_sigma_factor.Name = "T_sigma_factor";
            this.T_sigma_factor.Size = new System.Drawing.Size(46, 21);
            this.T_sigma_factor.TabIndex = 35;
            // 
            // T_sigma_textBox
            // 
            this.T_sigma_textBox.Location = new System.Drawing.Point(41, 338);
            this.T_sigma_textBox.Name = "T_sigma_textBox";
            this.T_sigma_textBox.Size = new System.Drawing.Size(137, 20);
            this.T_sigma_textBox.TabIndex = 34;
            this.T_sigma_textBox.Text = "0";
            // 
            // trackBar5
            // 
            this.trackBar5.Location = new System.Drawing.Point(25, 389);
            this.trackBar5.Name = "trackBar5";
            this.trackBar5.Size = new System.Drawing.Size(101, 45);
            this.trackBar5.TabIndex = 33;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(240, 373);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 42;
            this.label11.Text = "Skalierung";
            // 
            // Tn_label
            // 
            this.Tn_label.AutoSize = true;
            this.Tn_label.Location = new System.Drawing.Point(240, 322);
            this.Tn_label.Name = "Tn_label";
            this.Tn_label.Size = new System.Drawing.Size(20, 13);
            this.Tn_label.TabIndex = 41;
            this.Tn_label.Text = "Tn";
            // 
            // Tn_factor
            // 
            this.Tn_factor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Tn_factor.FormattingEnabled = true;
            this.Tn_factor.Items.AddRange(new object[] {
            "1e9",
            "1e6",
            "1e3",
            "1",
            "1e-3",
            "1e-6",
            "1e-9"});
            this.Tn_factor.Location = new System.Drawing.Point(301, 389);
            this.Tn_factor.Name = "Tn_factor";
            this.Tn_factor.Size = new System.Drawing.Size(46, 21);
            this.Tn_factor.TabIndex = 40;
            // 
            // Tn_textBox
            // 
            this.Tn_textBox.Location = new System.Drawing.Point(210, 338);
            this.Tn_textBox.Name = "Tn_textBox";
            this.Tn_textBox.Size = new System.Drawing.Size(137, 20);
            this.Tn_textBox.TabIndex = 39;
            this.Tn_textBox.Text = "0";
            // 
            // trackBar6
            // 
            this.trackBar6.Location = new System.Drawing.Point(194, 389);
            this.trackBar6.Name = "trackBar6";
            this.trackBar6.Size = new System.Drawing.Size(101, 45);
            this.trackBar6.TabIndex = 38;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 613);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Tn_label);
            this.Controls.Add(this.Tn_factor);
            this.Controls.Add(this.Tn_textBox);
            this.Controls.Add(this.trackBar6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.T_sigma_label);
            this.Controls.Add(this.T_sigma_factor);
            this.Controls.Add(this.T_sigma_textBox);
            this.Controls.Add(this.trackBar5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Ti_label);
            this.Controls.Add(this.Ti_factor);
            this.Controls.Add(this.Ti_textBox);
            this.Controls.Add(this.trackBar4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.T1_label);
            this.Controls.Add(this.T1_factor);
            this.Controls.Add(this.T1_textBox);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Vr_label);
            this.Controls.Add(this.Vr_factor);
            this.Controls.Add(this.Vr_textBox);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Vs_factor);
            this.Controls.Add(this.Vs_textBox);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label_Regler);
            this.Controls.Add(this.label_Regelstrecke);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pdf_export);
            this.Controls.Add(this.chart_x_label);
            this.Controls.Add(this.chart_y_label);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.calculate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button calculate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label chart_y_label;
        private System.Windows.Forms.Label chart_x_label;
        private System.Windows.Forms.Button pdf_export;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label_Regelstrecke;
        private System.Windows.Forms.Label label_Regler;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox Vs_textBox;
        private System.Windows.Forms.ComboBox Vs_factor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Vr_label;
        private System.Windows.Forms.ComboBox Vr_factor;
        private System.Windows.Forms.TextBox Vr_textBox;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label T1_label;
        private System.Windows.Forms.ComboBox T1_factor;
        private System.Windows.Forms.TextBox T1_textBox;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Ti_label;
        private System.Windows.Forms.ComboBox Ti_factor;
        private System.Windows.Forms.TextBox Ti_textBox;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label T_sigma_label;
        private System.Windows.Forms.ComboBox T_sigma_factor;
        private System.Windows.Forms.TextBox T_sigma_textBox;
        private System.Windows.Forms.TrackBar trackBar5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label Tn_label;
        private System.Windows.Forms.ComboBox Tn_factor;
        private System.Windows.Forms.TextBox Tn_textBox;
        private System.Windows.Forms.TrackBar trackBar6;
    }
}

