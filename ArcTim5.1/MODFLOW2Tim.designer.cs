namespace ArcTim
{
    partial class MODFLOW2Tim
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
            this.textBox_TimBoundary = new System.Windows.Forms.TextBox();
            this.textBox_gridFile = new System.Windows.Forms.TextBox();
            this.button_browse1 = new System.Windows.Forms.Button();
            this.button_browse2 = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_output = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_TimBoundary
            // 
            this.textBox_TimBoundary.Location = new System.Drawing.Point(240, 26);
            this.textBox_TimBoundary.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_TimBoundary.Name = "textBox_TimBoundary";
            this.textBox_TimBoundary.Size = new System.Drawing.Size(325, 22);
            this.textBox_TimBoundary.TabIndex = 0;
            // 
            // textBox_gridFile
            // 
            this.textBox_gridFile.Location = new System.Drawing.Point(240, 80);
            this.textBox_gridFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_gridFile.Name = "textBox_gridFile";
            this.textBox_gridFile.Size = new System.Drawing.Size(325, 22);
            this.textBox_gridFile.TabIndex = 1;
            // 
            // button_browse1
            // 
            this.button_browse1.Location = new System.Drawing.Point(591, 22);
            this.button_browse1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_browse1.Name = "button_browse1";
            this.button_browse1.Size = new System.Drawing.Size(37, 28);
            this.button_browse1.TabIndex = 2;
            this.button_browse1.Text = "...";
            this.button_browse1.UseVisualStyleBackColor = true;
            this.button_browse1.Click += new System.EventHandler(this.button_browse1_Click);
            // 
            // button_browse2
            // 
            this.button_browse2.Location = new System.Drawing.Point(591, 76);
            this.button_browse2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_browse2.Name = "button_browse2";
            this.button_browse2.Size = new System.Drawing.Size(37, 28);
            this.button_browse2.TabIndex = 3;
            this.button_browse2.Text = "...";
            this.button_browse2.UseVisualStyleBackColor = true;
            this.button_browse2.Click += new System.EventHandler(this.button_browse2_Click);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(359, 202);
            this.button_OK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(100, 28);
            this.button_OK.TabIndex = 4;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(528, 202);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(100, 28);
            this.button_Cancel.TabIndex = 5;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tim boundary file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "MODFLOW grid file with heads";
            // 
            // textBox_output
            // 
            this.textBox_output.Location = new System.Drawing.Point(240, 134);
            this.textBox_output.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_output.Name = "textBox_output";
            this.textBox_output.Size = new System.Drawing.Size(325, 22);
            this.textBox_output.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 143);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Output filename (with .shp)";
            // 
            // MODFLOW2Tim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 260);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_output);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.button_browse2);
            this.Controls.Add(this.button_browse1);
            this.Controls.Add(this.textBox_gridFile);
            this.Controls.Add(this.textBox_TimBoundary);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MODFLOW2Tim";
            this.Text = "MODFLOW2Tim";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_TimBoundary;
        private System.Windows.Forms.TextBox textBox_gridFile;
        private System.Windows.Forms.Button button_browse1;
        private System.Windows.Forms.Button button_browse2;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_output;
        private System.Windows.Forms.Label label3;
    }
}