namespace ArcTim
{
    partial class Number_of_Layers
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
            this.textBox_NOL = new System.Windows.Forms.TextBox();
            this.button_NOL_OK = new System.Windows.Forms.Button();
            this.button_NOL_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Change number of model layers";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox_NOL
            // 
            this.textBox_NOL.Location = new System.Drawing.Point(32, 35);
            this.textBox_NOL.Name = "textBox_NOL";
            this.textBox_NOL.Size = new System.Drawing.Size(104, 20);
            this.textBox_NOL.TabIndex = 1;
            this.textBox_NOL.TextChanged += new System.EventHandler(this.textBox_NOL_TextChanged);
            // 
            // button_NOL_OK
            // 
            this.button_NOL_OK.Location = new System.Drawing.Point(84, 73);
            this.button_NOL_OK.Name = "button_NOL_OK";
            this.button_NOL_OK.Size = new System.Drawing.Size(69, 24);
            this.button_NOL_OK.TabIndex = 2;
            this.button_NOL_OK.Text = "OK";
            this.button_NOL_OK.UseVisualStyleBackColor = true;
            this.button_NOL_OK.Click += new System.EventHandler(this.button_NOL_OK_Click);
            // 
            // button_NOL_Cancel
            // 
            this.button_NOL_Cancel.Location = new System.Drawing.Point(173, 73);
            this.button_NOL_Cancel.Name = "button_NOL_Cancel";
            this.button_NOL_Cancel.Size = new System.Drawing.Size(72, 24);
            this.button_NOL_Cancel.TabIndex = 3;
            this.button_NOL_Cancel.Text = "Cancel";
            this.button_NOL_Cancel.UseVisualStyleBackColor = true;
            this.button_NOL_Cancel.Click += new System.EventHandler(this.button_NOL_Cancel_Click);
            // 
            // Number_of_Layers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 110);
            this.Controls.Add(this.button_NOL_Cancel);
            this.Controls.Add(this.button_NOL_OK);
            this.Controls.Add(this.textBox_NOL);
            this.Controls.Add(this.label1);
            this.Name = "Number_of_Layers";
            this.Text = "Number of Layers";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_NOL;
        private System.Windows.Forms.Button button_NOL_OK;
        private System.Windows.Forms.Button button_NOL_Cancel;
    }
}