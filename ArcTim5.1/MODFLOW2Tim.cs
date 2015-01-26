using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ModflowToTimML;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.Framework;


namespace ArcTim
{
    [Guid("84F270F7-F1A4-4a8a-A79F-42316B1737F6")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("ArcTim5.MODFLOW2Tim")]
    public partial class MODFLOW2Tim : Form
    {
        private IApplication m_application;
        public MODFLOW2Tim(IApplication m_app)
        {
            m_application = m_app;
            InitializeComponent();
        }
        private string boundaryFilePath;
        private string headFilePath;
        private void button_browse1_Click(object sender, EventArgs e)
        {
            int num = 0;
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.InitialDirectory = ArcTimData.StaticClass.infoTable.Rows[0]["ShapefilePath"].ToString();
            fdlg.Filter = "All files (*.*)|*.*|shp (*.shp)|*.shp";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                boundaryFilePath = fdlg.FileName;
                for (int i = 0; i < boundaryFilePath.Length; i++)
                {
                    if (boundaryFilePath.Substring(i, 1).ToString() == "\\")
                        num = i;

                }
            }
            textBox_TimBoundary.Text = boundaryFilePath;
        }

        private void button_browse2_Click(object sender, EventArgs e)
        {
           int num = 0;
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.InitialDirectory = ArcTimData.StaticClass.infoTable.Rows[0]["ShapefilePath"].ToString();
            fdlg.Filter = "All files (*.*)|*.*|shp (*.shp)|*.shp";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                headFilePath = fdlg.FileName;
                for (int i = 0; i < headFilePath.Length; i++)
                {
                    if (headFilePath.Substring(i, 1).ToString() == "\\")
                        num = i;

                }
                
               
            }
            textBox_gridFile.Text = headFilePath;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            ModflowToTimML.TimBoundaryGenerator.Generate(textBox_TimBoundary.Text, textBox_gridFile.Text, textBox_output.Text);
            if (ArcTimData.StaticClass.infoTable.Rows[0]["ShapefilePath"]== null)
                ArcTimData.StaticClass.infoTable.Rows[0]["ShapefilePath"] = System.IO.Path.GetDirectoryName(textBox_TimBoundary.Text);
            ArcTimUtilities.addNewShapefile(m_application, textBox_output.Text);
            this.Hide();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
