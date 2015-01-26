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
using ESRI.ArcGIS.Controls;

namespace ArcTim
{
    [Guid("EBE9DB35-AC7B-4dc9-ACD2-E4AC274CACAF")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("ArcTim5.OutputSettings")]
    public partial class OutputSettings : Form
    {
        public DataTable outputData;
        private IApplication m_application;
        private IHookHelper m_hookHelper2 = new HookHelperClass();
        public String path;
        public OutputSettings(IApplication hook, IHookHelper m_hookHelper)
        {

            InitializeComponent();
            m_application = hook;
            m_hookHelper2 = m_hookHelper;
            populateOutputSettings();

        }
        public void populateOutputSettings()
        {
            DataSet outputDataSettings = new DataSet("outputSettings");
            if (File.Exists(ArcTimData.StaticClass.infoTable.Rows[0]["ModelName"].ToString() + "\\outputSettings.xml"))
                outputDataSettings.ReadXml(ArcTimData.StaticClass.infoTable.Rows[0]["ModelName"].ToString() + "\\outputSettings.xml");
            else 
                ArcTimUtilities.CreateDefaultOutputFile(m_application,m_hookHelper2);

            DataTable outputData2 = outputDataSettings.Tables[0];
            textBox_xMin.Text = outputData2.Rows[0][0].ToString();
            textBox_xMax.Text = outputData2.Rows[0][1].ToString();
            textBox_xCells.Text = outputData2.Rows[0][2].ToString();
            textBox_yMin.Text = outputData2.Rows[1][0].ToString();
            textBox_yMax.Text = outputData2.Rows[1][1].ToString();
            textBox_yCells.Text = outputData2.Rows[1][2].ToString();
            
        }

    

        private void button_outputOK_Click(object sender, EventArgs e)
        {
            IMap map = ArcTimUtilities.GetMap(m_application);
            IActiveView ia = m_hookHelper2.ActiveView;
            DataSet oD = new DataSet("OutputData");
            DataTable outputData = new DataTable("Output");
            double xmax = 0;
            double xmin = 0;
            double ymax = 0;
            double ymin = 0;
            double nx = Convert.ToDouble(textBox_xCells.Text);
            double ny = Convert.ToDouble(textBox_yCells.Text);
            outputData.Columns.Add("MinExtents");
            outputData.Columns.Add("MaxExtents");
            outputData.Columns.Add("NumCells");
            double resx = 0;
            // getextentsData
            if (radioButton_currentExtents.Checked == true)
            {
                xmax = ia.Extent.XMax;
                xmin = ia.Extent.XMin;
                ymax = ia.Extent.YMax;
                ymin = ia.Extent.YMin;
            }
            else if (radioButton_defineExtents.Checked == true)
            {
                xmax = Convert.ToDouble(textBox_xMax.Text);
                xmin = Convert.ToDouble(textBox_xMin.Text);
                ymax = Convert.ToDouble(textBox_yMax.Text);
                ymin = Convert.ToDouble(textBox_yMin.Text);
            }
            //getResolutionData
            if (radioButton_res.Checked == true)
            {
                if (radioButton_low.Checked == true)
                {
                    resx = 0.01;

                }
                if (radioButton_med.Checked == true)
                {
                    resx = 0.008;
                }
                if (radioButton_high.Checked == true)
                {
                    resx = 0.004;
                }
                double xtemp = 0;
                double ytemp = 0;
                double delx = 0;
                double dely = 0;


                delx = xmax - xmin;
                //dely = ymax - ymin;

                xtemp = delx * resx;
                //ytemp = dely * resx;

                //ny = Convert.ToInt64(dely / ytemp);
                nx = Convert.ToInt64(delx / xtemp);

                //if (dely % ytemp != 0)
                //{
                //    ny = Convert.ToInt64(dely / ytemp) + 1;
                //    dely = ny * ytemp;
                //}
                if (delx % xtemp != 0)
                {
                    nx = Convert.ToInt64(delx / xtemp) + 1;
                    delx = nx * xtemp;
                    ny = Convert.ToInt64(delx / xtemp) + 1;
                    dely = nx * xtemp;
                }
                //if (delx < dely)
                //{
                    xmax = nx * xtemp + xmin;
                    ymax = nx * xtemp + ymin;
                //}
                //if (dely < delx)
                //{
                //    xmax = nx * xtemp + xmin;
                //    ymax = ny * xtemp + ymin;
                //}
            }
            DataRow rx = outputData.NewRow();
            DataRow ry = outputData.NewRow();
            rx[0] = xmin;
            ry[0] = ymin;
            rx[1] = xmax;
            ry[1] = ymax;
            rx[2] = nx;
            ry[2] = ny;
            outputData.Rows.Add(rx);
            outputData.Rows.Add(ry);
            oD.Tables.Add(outputData);
            oD.WriteXml(ArcTimData.StaticClass.infoTable.Rows[0]["ModelPath"] + "\\outputSettings.xml");
            this.Hide();
            
        }



        private void button_outputCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void Load(ESRI.ArcGIS.esriSystem.IVariantStream stream)
        {
            path = (string)stream.Read();
        }


    }
}