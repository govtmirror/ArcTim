namespace ArcTim
{
    partial class NewModel
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
            this.TextBoxModelName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button_browse = new System.Windows.Forms.Button();
            this.textbox_Path = new System.Windows.Forms.TextBox();
            this.button_CreateModel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBoxModelName
            // 
            this.TextBoxModelName.Location = new System.Drawing.Point(110, 78);
            this.TextBoxModelName.Name = "TextBoxModelName";
            this.TextBoxModelName.Size = new System.Drawing.Size(234, 22);
            this.TextBoxModelName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Model Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 42);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Path";
            // 
            // button_browse
            // 
            this.button_browse.Location = new System.Drawing.Point(502, 31);
            this.button_browse.Margin = new System.Windows.Forms.Padding(4);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new System.Drawing.Size(40, 28);
            this.button_browse.TabIndex = 4;
            this.button_browse.Text = "...";
            this.button_browse.UseVisualStyleBackColor = true;
            this.button_browse.Click += new System.EventHandler(this.button_browse_Click);
            // 
            // textbox_Path
            // 
            this.textbox_Path.Location = new System.Drawing.Point(74, 37);
            this.textbox_Path.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_Path.Name = "textbox_Path";
            this.textbox_Path.Size = new System.Drawing.Size(411, 22);
            this.textbox_Path.TabIndex = 3;
            // 
            // button_CreateModel
            // 
            this.button_CreateModel.Location = new System.Drawing.Point(383, 99);
            this.button_CreateModel.Name = "button_CreateModel";
            this.button_CreateModel.Size = new System.Drawing.Size(159, 44);
            this.button_CreateModel.TabIndex = 6;
            this.button_CreateModel.Text = "Create New Model File";
            this.button_CreateModel.UseVisualStyleBackColor = true;
            this.button_CreateModel.Click += new System.EventHandler(this.button_CreateModel_Click_1);
            // 
            // NewModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 179);
            this.Controls.Add(this.button_CreateModel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button_browse);
            this.Controls.Add(this.textbox_Path);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxModelName);
            this.Name = "NewModel";
            this.Text = "NewModel";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxModelName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_browse;
        private System.Windows.Forms.TextBox textbox_Path;
        private System.Windows.Forms.Button button_CreateModel;
    }
}