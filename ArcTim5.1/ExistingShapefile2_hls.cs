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
    [Guid("7BEAE71F-9C70-4084-A2C6-1F462BA9791D")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("ArcTim5.ModelSettingsWindow")]
    public partial class ExistingShapefile2_hls : Form
    {
        string shpFileName = null;
        IApplication m_app = null;
        public ExistingShapefile2_hls(string shapefileName, string featuretype, IApplication m_application)
        {

            InitializeComponent();
            m_app = m_application;

            IMap map = ArcTimData.GetMap(m_application);
            ShapeFile shp = new ShapeFile(ArcTimData.StaticClass.infoTable.Rows[0]["ShapefilePath"].ToString() + "\\" + shapefileName + ".shp");
            DataTable attTable = shp.AttributeTable;
            int numCol = attTable.Columns.Count;
            for (int i = 0; i < numCol; i++)
            {
                this.comboBox_Head.Items.Add(attTable.Columns[i].ColumnName);
                this.comboBox_Name.Items.Add(attTable.Columns[i].ColumnName);
            }
            shpFileName = shapefileName;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable newAttTable = new DataTable("NewAttTable");
            newAttTable.Columns.Add("TimFeatureName");
            newAttTable.Columns.Add("OldAttName");
            DataRow r;
            r = newAttTable.NewRow();
            r[0] = "Head1";

            if (this.comboBox_Head.Text == null)
                MessageBox.Show("Please select an attribute for Head", "Error", MessageBoxButtons.RetryCancel);
            else
                r[1] = this.comboBox_Head.Text;

            newAttTable.Rows.Add(r);
            r = newAttTable.NewRow();

            r[0] = "Name";

            if (this.comboBox_Name.Text == null)
                MessageBox.Show("Please select an attribute for Name", "Error", MessageBoxButtons.RetryCancel);
            else
                r[1] = this.comboBox_Name.Text;
            newAttTable.Rows.Add(r);
            string newShapefileName = ArcTimUtilities.createTimShapefile(shpFileName, newAttTable, "hls");
            ArcTimUtilities.addNewShapefile(m_app, newShapefileName);
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}