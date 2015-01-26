using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ArcTim
{
    public partial class Number_of_Layers : Form
    {
        public int nol;
        public Number_of_Layers(int numberOfLayers)
        {
            InitializeComponent();
            nol = numberOfLayers;
        }

        private void button_NOL_OK_Click(object sender, EventArgs e)
        {
            nol = Convert.ToInt32(textBox_NOL.Text);
            this.Hide();
        }

        private void button_NOL_Cancel_Click(object sender, EventArgs e)
        {
            
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_NOL_TextChanged(object sender, EventArgs e)
        {

        }
    }
}