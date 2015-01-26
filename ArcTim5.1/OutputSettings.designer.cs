namespace ArcTim
{
    partial class OutputSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_outputCancel = new System.Windows.Forms.Button();
            this.button_outputOK = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton_high = new System.Windows.Forms.RadioButton();
            this.radioButton_med = new System.Windows.Forms.RadioButton();
            this.radioButton_low = new System.Windows.Forms.RadioButton();
            this.radioButton_cells = new System.Windows.Forms.RadioButton();
            this.textBox_yCells = new System.Windows.Forms.TextBox();
            this.radioButton_res = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_xCells = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButton_defineExtents = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.radioButton_currentExtents = new System.Windows.Forms.RadioButton();
            this.textBox_yMin = new System.Windows.Forms.TextBox();
            this.textBox_yMax = new System.Windows.Forms.TextBox();
            this.textBox_xMin = new System.Windows.Forms.TextBox();
            this.textBox_xMax = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_outputCancel
            // 
            this.button_outputCancel.Location = new System.Drawing.Point(434, 236);
            this.button_outputCancel.Name = "button_outputCancel";
            this.button_outputCancel.Size = new System.Drawing.Size(100, 30);
            this.button_outputCancel.TabIndex = 34;
            this.button_outputCancel.Text = "Cancel";
            this.button_outputCancel.UseVisualStyleBackColor = true;
            this.button_outputCancel.Click += new System.EventHandler(this.button_outputCancel_Click);
            // 
            // button_outputOK
            // 
            this.button_outputOK.Location = new System.Drawing.Point(322, 236);
            this.button_outputOK.Name = "button_outputOK";
            this.button_outputOK.Size = new System.Drawing.Size(93, 30);
            this.button_outputOK.TabIndex = 33;
            this.button_outputOK.Text = "OK";
            this.button_outputOK.UseVisualStyleBackColor = true;
            this.button_outputOK.Click += new System.EventHandler(this.button_outputOK_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.radioButton_cells);
            this.groupBox3.Controls.Add(this.textBox_yCells);
            this.groupBox3.Controls.Add(this.radioButton_res);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBox_xCells);
            this.groupBox3.Location = new System.Drawing.Point(322, 33);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(212, 182);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output Resolution";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButton_high);
            this.panel2.Controls.Add(this.radioButton_med);
            this.panel2.Controls.Add(this.radioButton_low);
            this.panel2.Location = new System.Drawing.Point(21, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(158, 26);
            this.panel2.TabIndex = 9;
            // 
            // radioButton_high
            // 
            this.radioButton_high.AutoSize = true;
            this.radioButton_high.Location = new System.Drawing.Point(106, 6);
            this.radioButton_high.Name = "radioButton_high";
            this.radioButton_high.Size = new System.Drawing.Size(55, 21);
            this.radioButton_high.TabIndex = 2;
            this.radioButton_high.Text = "High";
            this.radioButton_high.UseVisualStyleBackColor = true;
            // 
            // radioButton_med
            // 
            this.radioButton_med.AutoSize = true;
            this.radioButton_med.Checked = true;
            this.radioButton_med.Location = new System.Drawing.Point(54, 6);
            this.radioButton_med.Name = "radioButton_med";
            this.radioButton_med.Size = new System.Drawing.Size(53, 21);
            this.radioButton_med.TabIndex = 1;
            this.radioButton_med.TabStop = true;
            this.radioButton_med.Text = "Med";
            this.radioButton_med.UseVisualStyleBackColor = true;
            // 
            // radioButton_low
            // 
            this.radioButton_low.AutoSize = true;
            this.radioButton_low.Location = new System.Drawing.Point(3, 6);
            this.radioButton_low.Name = "radioButton_low";
            this.radioButton_low.Size = new System.Drawing.Size(51, 21);
            this.radioButton_low.TabIndex = 0;
            this.radioButton_low.Text = "Low";
            this.radioButton_low.UseVisualStyleBackColor = true;
            // 
            // radioButton_cells
            // 
            this.radioButton_cells.AutoSize = true;
            this.radioButton_cells.Checked = true;
            this.radioButton_cells.Location = new System.Drawing.Point(6, 65);
            this.radioButton_cells.Name = "radioButton_cells";
            this.radioButton_cells.Size = new System.Drawing.Size(151, 21);
            this.radioButton_cells.TabIndex = 8;
            this.radioButton_cells.TabStop = true;
            this.radioButton_cells.Text = "Use number of cells";
            this.radioButton_cells.UseVisualStyleBackColor = true;
            // 
            // textBox_yCells
            // 
            this.textBox_yCells.Location = new System.Drawing.Point(53, 154);
            this.textBox_yCells.Name = "textBox_yCells";
            this.textBox_yCells.Size = new System.Drawing.Size(84, 22);
            this.textBox_yCells.TabIndex = 6;
            this.textBox_yCells.Text = "70";
            // 
            // radioButton_res
            // 
            this.radioButton_res.AutoSize = true;
            this.radioButton_res.Location = new System.Drawing.Point(6, 18);
            this.radioButton_res.Name = "radioButton_res";
            this.radioButton_res.Size = new System.Drawing.Size(195, 21);
            this.radioButton_res.TabIndex = 7;
            this.radioButton_res.Text = "Use Pre-defined resolution";
            this.radioButton_res.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Number of y Cells";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Number of x Cells";
            // 
            // textBox_xCells
            // 
            this.textBox_xCells.Location = new System.Drawing.Point(53, 106);
            this.textBox_xCells.Name = "textBox_xCells";
            this.textBox_xCells.Size = new System.Drawing.Size(84, 22);
            this.textBox_xCells.TabIndex = 3;
            this.textBox_xCells.Text = "111";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.radioButton_defineExtents);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.radioButton_currentExtents);
            this.groupBox4.Controls.Add(this.textBox_yMin);
            this.groupBox4.Controls.Add(this.textBox_yMax);
            this.groupBox4.Controls.Add(this.textBox_xMin);
            this.groupBox4.Controls.Add(this.textBox_xMax);
            this.groupBox4.Location = new System.Drawing.Point(26, 33);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(290, 182);
            this.groupBox4.TabIndex = 31;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Define Output Extents";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "XMax";
            // 
            // radioButton_defineExtents
            // 
            this.radioButton_defineExtents.AutoSize = true;
            this.radioButton_defineExtents.Checked = true;
            this.radioButton_defineExtents.Location = new System.Drawing.Point(9, 45);
            this.radioButton_defineExtents.Name = "radioButton_defineExtents";
            this.radioButton_defineExtents.Size = new System.Drawing.Size(117, 21);
            this.radioButton_defineExtents.TabIndex = 14;
            this.radioButton_defineExtents.TabStop = true;
            this.radioButton_defineExtents.Text = "Define Extents";
            this.radioButton_defineExtents.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(149, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "YMin";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(146, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 17);
            this.label9.TabIndex = 22;
            this.label9.Text = "YMax";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 17);
            this.label10.TabIndex = 19;
            this.label10.Text = "XMin";
            // 
            // radioButton_currentExtents
            // 
            this.radioButton_currentExtents.AutoSize = true;
            this.radioButton_currentExtents.Location = new System.Drawing.Point(9, 21);
            this.radioButton_currentExtents.Name = "radioButton_currentExtents";
            this.radioButton_currentExtents.Size = new System.Drawing.Size(152, 21);
            this.radioButton_currentExtents.TabIndex = 13;
            this.radioButton_currentExtents.Text = "Use Current Extents";
            this.radioButton_currentExtents.UseVisualStyleBackColor = true;
            // 
            // textBox_yMin
            // 
            this.textBox_yMin.Location = new System.Drawing.Point(194, 86);
            this.textBox_yMin.Name = "textBox_yMin";
            this.textBox_yMin.Size = new System.Drawing.Size(90, 22);
            this.textBox_yMin.TabIndex = 17;
            this.textBox_yMin.Text = "0";
            // 
            // textBox_yMax
            // 
            this.textBox_yMax.Location = new System.Drawing.Point(194, 126);
            this.textBox_yMax.Name = "textBox_yMax";
            this.textBox_yMax.Size = new System.Drawing.Size(90, 22);
            this.textBox_yMax.TabIndex = 18;
            this.textBox_yMax.Text = "21000";
            // 
            // textBox_xMin
            // 
            this.textBox_xMin.Location = new System.Drawing.Point(51, 86);
            this.textBox_xMin.Name = "textBox_xMin";
            this.textBox_xMin.Size = new System.Drawing.Size(90, 22);
            this.textBox_xMin.TabIndex = 15;
            this.textBox_xMin.Text = "-6000";
            // 
            // textBox_xMax
            // 
            this.textBox_xMax.Location = new System.Drawing.Point(51, 126);
            this.textBox_xMax.Name = "textBox_xMax";
            this.textBox_xMax.Size = new System.Drawing.Size(90, 22);
            this.textBox_xMax.TabIndex = 16;
            this.textBox_xMax.Text = "27300";
            // 
            // OutputSettings
            // 
            this.ClientSize = new System.Drawing.Size(553, 288);
            this.Controls.Add(this.button_outputCancel);
            this.Controls.Add(this.button_outputOK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Name = "OutputSettings";
            this.Text = "Output Settings";
            this.TopMost = true;
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_outputCancel;
        private System.Windows.Forms.Button button_outputOK;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButton_high;
        private System.Windows.Forms.RadioButton radioButton_med;
        private System.Windows.Forms.RadioButton radioButton_low;
        private System.Windows.Forms.RadioButton radioButton_cells;
        private System.Windows.Forms.TextBox textBox_yCells;
        private System.Windows.Forms.RadioButton radioButton_res;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_xCells;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButton_defineExtents;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton radioButton_currentExtents;
        private System.Windows.Forms.TextBox textBox_yMin;
        private System.Windows.Forms.TextBox textBox_yMax;
        private System.Windows.Forms.TextBox textBox_xMin;
        private System.Windows.Forms.TextBox textBox_xMax;

   
    }
}