using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ArcTim
{
    
    public partial class FileNameExists : Form
    {
        public string filename;
        string path2;
        public FileNameExists(string path)
        {
            InitializeComponent();
            path2 = path;
        }
        
        private void button_FNE_OK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button_FNE_browse_Click(object sender, EventArgs e)
        {
            SaveFileDialog sdlg = new SaveFileDialog();
            //fdlg.Title = "Hyena / New Line Delimited Text File";
            sdlg.InitialDirectory = path2;
            sdlg.Filter = "All files (*.*)|*.*|dbf (*.dbf)|*.dbf";
            sdlg.FilterIndex = 2;
            sdlg.RestoreDirectory = true;
            if (sdlg.ShowDialog() == DialogResult.OK)
            {
                FNE_textBox.Text = sdlg.FileName;
            }
            filename = sdlg.FileName;
        }
    }
}