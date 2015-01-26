using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Controls;
using System.IO;

namespace ArcTim
{
    public partial class ModelSettingsForm : Form
    {
        public IApplication m_application;
        private IHookHelper m_hookHelper2 = new HookHelperClass();
        public ModelSettingsForm(IApplication hook, bool save, IHookHelper m_hookHelper)
        {
            InitializeComponent();
            m_application = hook;
            m_hookHelper2 = m_hookHelper;
        
            if (ArcTim.ArcTimData.StaticClass.shapefileTable != null)
            {
                loadCBox(m_application);
                loadTypeComboBox();
                loadComboBoxes(ArcTimData.StaticClass.shapefileTable);
            }
            else
            {
                loadCBox(m_application);
                loadTypeComboBox();
            }

            if (ArcTimData.StaticClass.aqPropTable != null)
            {
                this.dataGridView_aqData.Columns.Clear();
                this.dataGridView_aqData.Rows.Clear();
                this.dataGridView_aqData.DataSource = ArcTimData.StaticClass.aqPropTable.DefaultView;
                this.dataGridView_aqData.Update();
            }

            if (ArcTimData.StaticClass.infoTable != null)
                updateInfo(ArcTimData.StaticClass.infoTable);

            if (ArcTimData.StaticClass.outputPropTable!=null)
                updateOutput(ArcTimData.StaticClass.outputPropTable);
            
        }

        public void updateInfoTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ModelName");
            dt.Columns.Add("ShapeFilePath");
            dt.Columns.Add("PythonPath");
            dt.Columns.Add("ModelPath");

            DataRow r;
            r = dt.NewRow();
            r[0] = this.textBox_modName.Text;
            r[1] = this.textBox_shpPath.Text;
            r[2] = this.textBox_pyPath.Text;
            r[3] = this.textBox_modPath.Text;

            dt.Rows.Add(r);

            ArcTimData.StaticClass.infoTable = dt;
            ArcTimData.StaticClass.infoTable.TableName = "infoTable";

        }
        private void button_ok_Click(object sender, EventArgs e)
        {
            


            ArcTimData.StaticClass.aqPropTable = getDataFromDataGridView(this.dataGridView_aqData);
            ArcTimData.StaticClass.aqPropTable.TableName = "AquiferPropertyTable";
            getDataFromShp();
            updateInfoTable();
            getOutputSettings();
            ArcTimData.writexmlFile();
            this.Hide();
        }
        public void updateInfo(DataTable dt)
        {
            textBox_modName.Text = dt.Rows[0]["ModelName"].ToString();
            textBox_shpPath.Text = dt.Rows[0]["ShapeFilePath"].ToString();
            textBox_pyPath.Text = dt.Rows[0]["PythonPath"].ToString();
            textBox_modPath.Text = dt.Rows[0]["ModelPath"].ToString();
        }
        private void getDataFromShp()
        {
            DataTable sfdt = new DataTable();
            sfdt.Columns.Add("ShapefileName");
            sfdt.Columns.Add("ShapefileType");
            sfdt.Columns.Add("ShapefileDataTable");


            if (this.checkBox1.Checked && this.comboBox_SF1.SelectedItem.ToString() != null)
            {
                DataRow r1;
                r1 = sfdt.NewRow();
                r1[0] = comboBox_SF1.SelectedItem.ToString();
                r1[1] = comboBox_SFt1.SelectedItem.ToString();
                r1[2] = "";
                sfdt.Rows.Add(r1);
            }

            if (this.checkBox2.Checked && this.comboBox_SF2.SelectedItem.ToString() != null)
            {
                DataRow r2;
                r2 = sfdt.NewRow();
                r2[0] = comboBox_SF2.SelectedItem.ToString();
                r2[1] = comboBox_SFt2.SelectedItem.ToString();
                r2[2] = "";
                sfdt.Rows.Add(r2);
            }

            if (this.checkBox3.Checked && this.comboBox_SF3.SelectedItem.ToString() != null)
            {
                DataRow r3;
                r3 = sfdt.NewRow();
                r3[0] = comboBox_SF3.SelectedItem.ToString();
                r3[1] = comboBox_SFt3.SelectedItem.ToString();
                r3[2] = "";
                sfdt.Rows.Add(r3);
            }

            if (this.checkBox4.Checked && this.comboBox_SF4.SelectedItem.ToString() != null)
            {
                DataRow r4;
                r4 = sfdt.NewRow();
                r4[0] = comboBox_SF4.SelectedItem.ToString();
                r4[1] = comboBox_SFt4.SelectedItem.ToString();
                r4[2] = "";
                sfdt.Rows.Add(r4);
            }

            if (this.checkBox5.Checked && this.comboBox_SF5.SelectedItem.ToString() != null)
            {
                DataRow r5;
                r5 = sfdt.NewRow();
                r5[0] = comboBox_SF5.SelectedItem.ToString();
                r5[1] = comboBox_SFt5.SelectedItem.ToString();
                r5[2] = "";
                sfdt.Rows.Add(r5);
            }

            if (this.checkBox6.Checked && this.comboBox_SF6.SelectedItem.ToString() != null)
            {
                DataRow r6;
                r6 = sfdt.NewRow();
                r6[0] = comboBox_SF6.SelectedItem.ToString();
                r6[1] = comboBox_SFt6.SelectedItem.ToString();
                r6[2] = "";
                sfdt.Rows.Add(r6);
            }
            if (this.checkBox7.Checked && this.comboBox_SF7.SelectedItem.ToString() != null)
            {
                DataRow r7;
                r7 = sfdt.NewRow();
                r7[0] = comboBox_SF6.SelectedItem.ToString();
                r7[1] = comboBox_SFt6.SelectedItem.ToString();
                r7[2] = "";
                sfdt.Rows.Add(r7);
            }
            if (this.checkBox8.Checked && this.comboBox_SF8.SelectedItem.ToString() != null)
            {
                DataRow r8;
                r8 = sfdt.NewRow();
                r8[0] = comboBox_SF6.SelectedItem.ToString();
                r8[1] = comboBox_SFt6.SelectedItem.ToString();
                r8[2] = "";
                sfdt.Rows.Add(r8);
            }

           ArcTimData.StaticClass.shapefileTable = sfdt;
           ArcTimData.StaticClass.shapefileTable.TableName = "ShapefileData";
        }

        private DataTable getDataFromDataGridView(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                dt.Columns.Add(col.HeaderText);
            }

            foreach(DataGridViewRow row in dgv.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach(DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                if(dRow[0].ToString()!="")
                     dt.Rows.Add(dRow);
            }
            return dt;
        }

        public void loadComboBoxes(DataTable shapefileInfo)
        {
            
            int sfRowCount = shapefileInfo.Rows.Count;
            ComboBox[] sfComboBox = new ComboBox[8] { comboBox_SF1, comboBox_SF2, comboBox_SF3, comboBox_SF4, comboBox_SF5, comboBox_SF6, comboBox_SF7, comboBox_SF8 };
            ComboBox[] sftComboBox = new ComboBox[8] { comboBox_SFt1, comboBox_SFt2, comboBox_SFt3, comboBox_SFt4, comboBox_SFt5, comboBox_SFt6,comboBox_SFt7, comboBox_SFt8   };
            CheckBox[] sfCheckBox = new CheckBox[8] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8 };

            for (int i = 0; i < sfRowCount; i++)
            {
                sfComboBox[i].SelectedItem = (string)shapefileInfo.Rows[i][0];
                sftComboBox[i].SelectedItem = shapefileInfo.Rows[i][1].ToString();
                sfCheckBox[i].CheckState = CheckState.Checked;
            }

        }
        public void loadCBox(IApplication m_app)
        {
            ILayer pLyr;
            IMap map = ArcTimData.GetMap(m_app);
            if (map != null)
            {
                int iLyrCount = map.LayerCount;
                for (int i = 0; i < iLyrCount; i++)
                {
                    pLyr = map.get_Layer(i);
                    if (pLyr is IFeatureLayer)
                    {
                        this.comboBox_SF1.Items.Add(pLyr.Name);
                        this.comboBox_SF2.Items.Add(pLyr.Name);
                        this.comboBox_SF3.Items.Add(pLyr.Name);
                        this.comboBox_SF4.Items.Add(pLyr.Name);
                        this.comboBox_SF5.Items.Add(pLyr.Name);
                        this.comboBox_SF6.Items.Add(pLyr.Name);

                    }
                }
            }
        }
        public void loadTypeComboBox()
        {
            String[] combolist = new string[8]{"constant", "flowlinesink",
                "headlinesink", "reslinesink", "polyareasink", "well",
                "testpoint","circareasink"};
            comboBox_SFt1.Items.AddRange(combolist);
            comboBox_SFt2.Items.AddRange(combolist);
            comboBox_SFt3.Items.AddRange(combolist);
            comboBox_SFt4.Items.AddRange(combolist);
            comboBox_SFt5.Items.AddRange(combolist);
            comboBox_SFt6.Items.AddRange(combolist);
            comboBox_SFt7.Items.AddRange(combolist);
            comboBox_SFt8.Items.AddRange(combolist);
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void getOutputSettings()
        {
            DataTable dt = new DataTable();
            double xmax = 0, xmin = 0, ymax = 0, ymin = 0;
            double nx=Convert.ToDouble(textBox_xCells.Text), ny = Convert.ToDouble(textBox_yCells.Text);
            double dx = Convert.ToDouble(textBox_cellsize.Text);
            dt.Columns.Add("MinExtents");
            dt.Columns.Add("MaxExtents");
            dt.Columns.Add("NumCells");
            dt.Columns.Add("Delta");
            IMap map = ArcTimData.GetMap(m_application);
            IActiveView ia = m_hookHelper2.ActiveView;
           
            //get extents data
            if (radioButton_useCurrentExtents.Checked == true)
            {
                xmax = ia.Extent.XMax;
                xmin = ia.Extent.XMin;
                ymax = ia.Extent.YMax;
                ymin = ia.Extent.YMin;
            }
            else if (radioButton_defineExtents.Checked == true)
            {
                xmax = Convert.ToDouble(textBox_xmax.Text);
                xmin = Convert.ToDouble(textBox_xmin.Text);
                ymax = Convert.ToDouble(textBox_ymax.Text);
                ymin = Convert.ToDouble(textBox_ymin.Text);
            }

            //get res data
            if(radioButton_res.Checked==true)
            {
                if(radioButton_reslow.Checked==true)
                {
                    dx = 0.01;
                }
                if(radioButton_resmed.Checked==true)
                {
                    dx = 0.008;
                }
                if(radioButton_reshigh.Checked==true)
                {
                    dx = 0.004;
                }
                double xtemp = 0, ytemp = 0, tempnx = 0, tempny = 0;
                tempnx = Math.Truncate((xmax-xmin)*dx);
                tempny = Math.Truncate((ymax - ymin) * dx);
                //xtemp = delx*resx;
                //nx = Math.Truncate(delx/xtemp);
                //if(delx%xtemp!=0)
                //{
                //    nx = Math.Truncate(delx/xtemp)+1;
                //    delx = nx*xtemp;
                //    ny = Math.Truncate(delx/xtemp)+1;
                //    dely = nx*xtemp;
                //}
                //xmax = nx*xtemp+xmin;
                //ymax = nx*xtemp+ymin;
                dx = (xmax - xmin) / tempnx;
                nx = tempnx;
                ny = tempny;
            }
            DataRow rx = dt.NewRow();
            DataRow ry = dt.NewRow();
            rx[0] = xmin;
            ry[0]= ymin;
            rx[1] = xmax;
            ry[1] = ymax;
            rx[2] = nx;
            ry[2] = ny;
            rx[3] = dx;
            ry[3] = dx;
            dt.Rows.Add(rx);
            dt.Rows.Add(ry);
            ArcTimData.StaticClass.outputPropTable = dt;
            ArcTimData.StaticClass.outputPropTable.TableName = "OutputSettings";
        }

        public void updateOutput(DataTable dt)
        {
            textBox_xmin.Text = dt.Rows[0]["MinExtents"].ToString();
            textBox_xmax.Text = dt.Rows[0]["MaxExtents"].ToString();
            textBox_ymin.Text = dt.Rows[1]["MinExtents"].ToString();
            textBox_ymax.Text = dt.Rows[1]["MaxExtents"].ToString();
            textBox_xCells.Text = dt.Rows[0]["NumCells"].ToString();
            textBox_yCells.Text = dt.Rows[1]["NumCells"].ToString();
            textBox_cellsize.Text = dt.Rows[0]["Delta"].ToString();
            radioButton_defineExtents.Checked = true;
            radioButton_cells.Checked = true;
        }

        private void button_fileLookUp1_Click(object sender, EventArgs e)
        {
            
            
            FolderBrowserDialog fdlg = new FolderBrowserDialog();
            string path =@"C:\\";
            if(ArcTimData.StaticClass.infoTable!=null)
                path = ArcTimData.StaticClass.infoTable.Rows[0]["ShapefilePath"].ToString();
            fdlg.SelectedPath = System.IO.Path.GetDirectoryName(path);
            
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textBox_shpPath.Text = fdlg.SelectedPath;
                
            }
            
        }

        private void button_fileLookUp2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdlg = new FolderBrowserDialog();
            string path = @"C:\\";
            if (ArcTimData.StaticClass.infoTable != null)
                path = ArcTimData.StaticClass.infoTable.Rows[0]["PythonPath"].ToString();
            fdlg.RootFolder = Environment.SpecialFolder.MyComputer;

            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textBox_pyPath.Text = fdlg.SelectedPath;

            }
        }

        private void button_fileLookUp3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdlg = new FolderBrowserDialog();
            string path = @"C:\\";
            if (ArcTimData.StaticClass.infoTable != null)
                path = ArcTimData.StaticClass.infoTable.Rows[0]["ModelPath"].ToString();
            fdlg.RootFolder = Environment.SpecialFolder.MyComputer;

            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textBox_modPath.Text = fdlg.SelectedPath;

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
