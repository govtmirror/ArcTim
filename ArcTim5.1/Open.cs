using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Framework;

namespace ArcTim
{
    public partial class Open : Form
    {
        public static string path;
        private IApplication m_application;
        private IHookHelper m_hookHelper2 = new HookHelperClass();
        public Open(IApplication hook, IHookHelper m_hookHelper)
        {
            InitializeComponent();
            m_application = hook;
            m_hookHelper2 = m_hookHelper;
        }
        private string filepath;
        private void button1_Click(object sender, EventArgs e)
        {
            int num = 0;
            string modelfile = "";
            OpenFileDialog fdlg = new OpenFileDialog();
            string path = @"C:\\";
            if (ArcTimData.StaticClass.infoTable != null)
                path = ArcTimData.StaticClass.infoTable.Rows[0]["ModelPath"].ToString();
            fdlg.InitialDirectory = path;
            fdlg.Filter = "All files (*.*)|*.*|xml (*.xml)|*.xml";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                modelfile = fdlg.FileName;
                //for (int i = 0; i < filepath.Length; i++)
                //{
                //    if (filepath.Substring(i, 1).ToString() == "\\")
                //        num = i;

                //}

                textBox1.Text = modelfile;
                //ArcTimData.StaticClass.infoTable.Rows[0]["ModelPath"] = Path.GetDirectoryName(modelfile);
                ArcTimData.StaticClass.modelName = Path.GetFileNameWithoutExtension(modelfile);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
           string xmlFile = this.textBox1.Text;
            ArcTimData.readXMLFile(xmlFile);
            ModelSettingsForm msf = new ModelSettingsForm(m_application,false,m_hookHelper2);
            this.Hide();
            msf.Show();
            
        }

    }
}