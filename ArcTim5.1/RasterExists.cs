using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ArcTim
{
    public partial class RasterExists : Form
    {
        public string newRasterName;
        public RasterExists()
        {
            InitializeComponent();
        }

        private void button_RasterOK_Click(object sender, EventArgs e)
        {
            newRasterName = textBox1.Text;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sdlg = new SaveFileDialog();
            //fdlg.Title = "Hyena / New Line Delimited Text File";
            sdlg.InitialDirectory = ArcTimData.StaticClass.infoTable.Rows[0]["ShapefilePath"].ToString();
            sdlg.AddExtension = false;
            //sdlg.Filter = "All files ";
            sdlg.FilterIndex = 2;
            sdlg.RestoreDirectory = true;
            if (sdlg.ShowDialog() == DialogResult.OK)
            {
                newRasterName = sdlg.FileName;
            }
        }
    }
}