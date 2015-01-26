namespace ArcTim
{
    partial class FileNameExists
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
            this.FNE_textBox = new System.Windows.Forms.TextBox();
            this.button_FNE_OK = new System.Windows.Forms.Button();
            this.button_FNE_browse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "A data table with that name exists.  Please enter new file name.";
            // 
            // FNE_textBox
            // 
            this.FNE_textBox.Location = new System.Drawing.Point(39, 54);
            this.FNE_textBox.Name = "FNE_textBox";
            this.FNE_textBox.Size = new System.Drawing.Size(267, 20);
            this.FNE_textBox.TabIndex = 1;
            // 
            // button_FNE_OK
            // 
            this.button_FNE_OK.Location = new System.Drawing.Point(271, 117);
            this.button_FNE_OK.Name = "button_FNE_OK";
            this.button_FNE_OK.Size = new System.Drawing.Size(87, 32);
            this.button_FNE_OK.TabIndex = 2;
            this.button_FNE_OK.Text = "OK";
            this.button_FNE_OK.UseVisualStyleBackColor = true;
            this.button_FNE_OK.Click += new System.EventHandler(this.button_FNE_OK_Click);
            // 
            // button_FNE_browse
            // 
            this.button_FNE_browse.Location = new System.Drawing.Point(322, 54);
            this.button_FNE_browse.Name = "button_FNE_browse";
            this.button_FNE_browse.Size = new System.Drawing.Size(36, 20);
            this.button_FNE_browse.TabIndex = 3;
            this.button_FNE_browse.Text = "...";
            this.button_FNE_browse.UseVisualStyleBackColor = true;
            this.button_FNE_browse.Click += new System.EventHandler(this.button_FNE_browse_Click);
            // 
            // FileNameExists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 170);
            this.Controls.Add(this.button_FNE_browse);
            this.Controls.Add(this.button_FNE_OK);
            this.Controls.Add(this.FNE_textBox);
            this.Controls.Add(this.label1);
            this.Name = "FileNameExists";
            this.Text = "Data Table Exists";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FNE_textBox;
        private System.Windows.Forms.Button button_FNE_OK;
        private System.Windows.Forms.Button button_FNE_browse;
    }
}