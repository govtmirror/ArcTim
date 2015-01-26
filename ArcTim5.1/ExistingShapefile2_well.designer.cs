namespace ArcTim
{
    partial class ExistingShapefile2_well
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_Flow = new System.Windows.Forms.ComboBox();
            this.comboBox_Radius = new System.Windows.Forms.ComboBox();
            this.comboBox_Name = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flow";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Radius";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name";
            // 
            // comboBox_Flow
            // 
            this.comboBox_Flow.FormattingEnabled = true;
            this.comboBox_Flow.Location = new System.Drawing.Point(194, 52);
            this.comboBox_Flow.Name = "comboBox_Flow";
            this.comboBox_Flow.Size = new System.Drawing.Size(121, 24);
            this.comboBox_Flow.TabIndex = 3;
            // 
            // comboBox_Radius
            // 
            this.comboBox_Radius.FormattingEnabled = true;
            this.comboBox_Radius.Location = new System.Drawing.Point(194, 80);
            this.comboBox_Radius.Name = "comboBox_Radius";
            this.comboBox_Radius.Size = new System.Drawing.Size(121, 24);
            this.comboBox_Radius.TabIndex = 4;
            // 
            // comboBox_Name
            // 
            this.comboBox_Name.FormattingEnabled = true;
            this.comboBox_Name.Location = new System.Drawing.Point(194, 110);
            this.comboBox_Name.Name = "comboBox_Name";
            this.comboBox_Name.Size = new System.Drawing.Size(121, 24);
            this.comboBox_Name.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Number of Layers";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(295, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Select the attribute for each parameter type...";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(153, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(240, 255);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(194, 140);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 22);
            this.textBox1.TabIndex = 15;
            // 
            // ExistingShapefile2_well
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 299);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_Name);
            this.Controls.Add(this.comboBox_Radius);
            this.Controls.Add(this.comboBox_Flow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ExistingShapefile2_well";
            this.Text = "Convert Existing Shapefile - step 2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Flow;
        private System.Windows.Forms.ComboBox comboBox_Radius;
        private System.Windows.Forms.ComboBox comboBox_Name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
    }
}