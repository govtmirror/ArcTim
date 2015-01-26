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
    [Guid("B0670CA5-CC71-46c7-9F75-E732830CBAD1")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("ArcTim5.ModelSettingsWindow")]
    public partial class ExistingShapefile2_rls : Form
    {
        string shpFileName = null;
        IApplication m_app = null;
        public ExistingShapefile2_rls(string shapefileName, string featuretype, IApplication m_application)
        {
            
            InitializeComponent();

            m_app = m_application;
            IMap map = ArcTimUtilities.GetMap(m_application);
            ShapeFile shp = new ShapeFile(ArcTimData.StaticClass.infoTable.Rows[0]["ShapefilePath"].ToString() + "\\" + shapefileName + ".shp");
            DataTable attTable = shp.AttributeTable;
            int numCol = attTable.Columns.Count;
            for (int i = 0; i < numCol; i++)
            {
                this.comboBox_Head.Items.Add(attTable.Columns[i].ColumnName);
                this.comboBox_Res.Items.Add(attTable.Columns[i].ColumnName);
                this.comboBox_width.Items.Add(attTable.Columns[i].ColumnName);
                this.comboBox_name.Items.Add(attTable.Columns[i].ColumnName);
                this.comboBox_bot.Items.Add(attTable.Columns[i].ColumnName);
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

            r[0] = "Resis";

            if (this.comboBox_Res.Text == null)
                MessageBox.Show("Please select an attribute for Resistance", "Error", MessageBoxButtons.RetryCancel);
            else
                r[1] = this.comboBox_Res.Text;
            newAttTable.Rows.Add(r);
            r = newAttTable.NewRow();

            r[0] = "Width";

            if (this.comboBox_width.Text == null)
                MessageBox.Show("Please select an attribute for width", "Error", MessageBoxButtons.RetryCancel);
            else
                r[1] = this.comboBox_width.Text;
            newAttTable.Rows.Add(r);
            r = newAttTable.NewRow();

            r[0] = "Name";

            if (this.comboBox_name.Text == null)
                MessageBox.Show("Please select an attribute for name", "Error", MessageBoxButtons.RetryCancel);
            else
                r[1] = this.comboBox_name.Text;
            newAttTable.Rows.Add(r);
            r = newAttTable.NewRow();

            r[0] = "BotElev";

            if (this.comboBox_bot.Text == null)
                MessageBox.Show("Please select an attribute for Bottom Elevation", "Error", MessageBoxButtons.RetryCancel);
            else
                r[1] = this.comboBox_bot.Text;
            newAttTable.Rows.Add(r);
            string newShapefileName = ArcTimUtilities.createTimShapefile(shpFileName, newAttTable, "rls");
            ArcTimUtilities.addNewShapefile(m_app, newShapefileName);
            this.Hide();
        }
    }
}