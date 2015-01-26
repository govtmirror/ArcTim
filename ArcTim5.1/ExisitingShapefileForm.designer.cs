namespace ArcTim
{
    partial class ExisitingShapefileForm
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
            this.comboBox_esf = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_fsf = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textbox_Path = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_esf
            // 
            this.comboBox_esf.FormattingEnabled = true;
            this.comboBox_esf.Location = new System.Drawing.Point(248, 72);
            this.comboBox_esf.Name = "comboBox_esf";
            this.comboBox_esf.Size = new System.Drawing.Size(288, 24);
            this.comboBox_esf.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "2.  Select Shapefile to Convert";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "3.  Select Tim Feature Type";
            // 
            // comboBox_fsf
            // 
            this.comboBox_fsf.FormattingEnabled = true;
            this.comboBox_fsf.Location = new System.Drawing.Point(248, 120);
            this.comboBox_fsf.Name = "comboBox_fsf";
            this.comboBox_fsf.Size = new System.Drawing.Size(288, 24);
            this.comboBox_fsf.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(363, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 33);
            this.button1.TabIndex = 4;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(458, 169);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 33);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "1.  Select working directory";
            // 
            // textbox_Path
            // 
            this.textbox_Path.Location = new System.Drawing.Point(248, 31);
            this.textbox_Path.Name = "textbox_Path";
            this.textbox_Path.Size = new System.Drawing.Size(260, 22);
            this.textbox_Path.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(514, 31);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(35, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ExisitingShapefileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 235);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textbox_Path);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox_fsf);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_esf);
            this.Name = "ExisitingShapefileForm";
            this.Text = "Convert Exisiting Shapefile - step 1";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_esf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_fsf;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textbox_Path;
        private System.Windows.Forms.Button button3;
    }
}