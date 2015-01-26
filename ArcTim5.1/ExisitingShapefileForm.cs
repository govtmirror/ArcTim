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
using Karl.Tools.ShapeLib1;


namespace ArcTim
{
    [Guid("996FF295-3301-47d0-AA91-F60A6AF7B090")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("ArcTim5.ModelSettingsWindow")]
    public partial class ExisitingShapefileForm : Form
    {
        private IApplication m_application;
        public ExisitingShapefileForm(IApplication hook)
        {
            InitializeComponent();
            m_application = hook;
            this.loadCBox(m_application);
            String[] combolist = new string[5]{"Constant", "Head Line Sink",
                "Resistance Line Sink", "Flow Line Sink", "Well"};
            
            this.comboBox_fsf.Items.AddRange(combolist);
            if (ArcTimData.StaticClass.infoTable.Rows[0]["ShapefilePath"].ToString()!= null)
                textbox_Path.Text = ArcTimData.StaticClass.infoTable.Rows[0]["ShapefilePath"].ToString();
        }

        public void loadCBox(IApplication m_app)
        {
            ILayer pLyr;
            IMap map = ArcTimUtilities.GetMap(m_app);
            if (map != null)
            {
                int iLyrCount = map.LayerCount;
                for (int i = 0; i < iLyrCount; i++)
                {
                    pLyr = map.get_Layer(i);
                    if (pLyr is IFeatureLayer)
                    {
                        this.comboBox_esf.Items.Add(pLyr.Name);

                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string shapefilename = null;
            string timFileType = null;
            if (comboBox_fsf.Text == "")
            {
                MessageBox.Show("You must select a feature type","Error",MessageBoxButtons.RetryCancel);
            }
            else
                timFileType = comboBox_fsf.Text;
            if (comboBox_esf.Text == "")
            {
                MessageBox.Show("You must select a shapefile to convert", "Error", MessageBoxButtons.RetryCancel);
            }
            else
                shapefilename = comboBox_esf.Text;
            if (timFileType == "Constant")
            {
                ExistingShapefile2_constant esf2_constant = new ExistingShapefile2_constant(shapefilename, timFileType, m_application);
                this.Hide();
                esf2_constant.Show();
            }
            if (timFileType == "Flow Line Sink")
            {
                ExistingShapefile2_fls esf2_fls = new ExistingShapefile2_fls(shapefilename, timFileType, m_application);
                this.Hide();
                esf2_fls.Show();
            }
            if (timFileType == "Head Line Sink")
            {
                ExistingShapefile2_hls esf2_hls = new ExistingShapefile2_hls(shapefilename, timFileType, m_application);
                this.Hide();
                esf2_hls.Show();
            }
            if (timFileType == "Resistance Line Sink")
            {
                ExistingShapefile2_rls esf2_rls = new ExistingShapefile2_rls(shapefilename, timFileType, m_application);
                this.Hide();
                esf2_rls.Show();
            }
            if (timFileType == "Well")
            {
                ExistingShapefile2_well esf2_well = new ExistingShapefile2_well(shapefilename, timFileType, m_application);
                this.Hide();
                esf2_well.Show();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdlg = new FolderBrowserDialog();
            fdlg.RootFolder = Environment.SpecialFolder.MyComputer;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textbox_Path.Text = fdlg.SelectedPath;
            }
            else if (fdlg.ShowDialog() == DialogResult.Cancel)
            {
                textbox_Path.Text = ArcTimData.StaticClass.infoTable.Rows[0]["ModelPath"].ToString();
            }
            ArcTimData.StaticClass.infoTable.Rows[0]["ModelPath"]= textbox_Path.Text;
        }
    }
}