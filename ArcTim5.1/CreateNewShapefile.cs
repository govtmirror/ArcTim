using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
//using ESRI.ArcGIS.Controls;
//using TimLib;
using System.IO;
using System.Collections;


namespace ArcTim
{
    [Guid("77F756FE-0A69-49c6-B4FF-32D012117B88")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("ArcTim5.ModelSettingsWindow")]
    public partial class CreateNewShapefile : Form
    {
        IApplication m_app = null;
        public CreateNewShapefile(IApplication m_application)
        {
            InitializeComponent();
            m_app = m_application;
            this.comboBox1.Items.Add("Constant");
            this.comboBox1.Items.Add("FlowLineSink");
            this.comboBox1.Items.Add("ResLineSink");
            this.comboBox1.Items.Add("HeadLineSink");
            this.comboBox1.Items.Add("Well");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string shpFileName = ArcTimUtilities.CreateNewTimShapefile(comboBox1.SelectedItem.ToString(), this.textBox1.Text.ToString());
            ArcTimUtilities.addNewShapefile(m_app, shpFileName);
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdlg = new FolderBrowserDialog();
            fdlg.RootFolder = Environment.SpecialFolder.MyComputer;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = fdlg.SelectedPath;
            }
            else if (fdlg.ShowDialog() == DialogResult.Cancel)
            {
                textBox2.Text = ArcTimData.StaticClass.infoTable.Rows[0]["ShapefilePath"].ToString();
            }
            ArcTimData.StaticClass.infoTable.Rows[0]["ShapefilePath"] = textBox2.Text;
        }
    }
}