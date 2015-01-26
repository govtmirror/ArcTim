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
    [Guid("488A9362-81AE-4e5e-A77F-D9644A8008C5")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("ArcTim5.NewModelWindow")]
    public partial class NewModel : Form
    {
        public NewModel()
        {
            InitializeComponent();
        }

        private void button_browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdlg = new FolderBrowserDialog();
            fdlg.RootFolder = Environment.SpecialFolder.MyComputer;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textbox_Path.Text = fdlg.SelectedPath;
            }
            else if (fdlg.ShowDialog() == DialogResult.Cancel)
            {
                textbox_Path.Text = ArcTimData.StaticClass.infoTable.Rows[0]["ShapefilePath"].ToString();
            }
            ArcTimData.StaticClass.infoTable.Rows[0]["ShapefilePath"]= textbox_Path.Text;
        }


        private void button_CreateModel_Click_1(object sender, EventArgs e)
        {
            ArcTimData.StaticClass.infoTable.Rows[0]["ModelName"] = TextBoxModelName.Text;
            ArcTimData.StaticClass.infoTable.Rows[0]["ShapefilePath"] = textbox_Path.Text;
            ArcTimData.StaticClass.infoTable.Rows[0]["ModelName"] = textbox_Path.Text + ".xml";
            this.Close();

        }
    }
}