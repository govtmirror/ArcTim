namespace ArcTim
{
    partial class RasterExists
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
            this.button_RasterOK = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_RasterOK
            // 
            this.button_RasterOK.Location = new System.Drawing.Point(303, 106);
            this.button_RasterOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_RasterOK.Name = "button_RasterOK";
            this.button_RasterOK.Size = new System.Drawing.Size(100, 28);
            this.button_RasterOK.TabIndex = 0;
            this.button_RasterOK.Text = "OK";
            this.button_RasterOK.UseVisualStyleBackColor = true;
            this.button_RasterOK.Click += new System.EventHandler(this.button_RasterOK_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 55);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(335, 22);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "A raster with this name already exists.  Please \r\nwrite a new name.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(361, 55);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RasterExists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 149);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_RasterOK);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RasterExists";
            this.Text = "RasterExists";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_RasterOK;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}