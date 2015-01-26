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
using ESRI.ArcGIS.Controls;
using TimLib;
using System.IO;
using System.Collections;

namespace ArcTim
{
    class ModelUtilities
    {
        public static int numberOfLayers;
        public static DataSet newds;
        public DataTable aquiferData;
        public DataTable tempaquiferData;
        public DataTable tempInfoData;
        public DataTable tempOutputData;
        public static string path;
        public static string modelName;
        public static bool firstPop;
        public static int previousIndex;
        public IApplication m_application;
        public bool dataTableChanged;

        //private ModelSettingsWindow _refMSW;
        //public ModelUtilities(ModelSettingsWindow MSW)
        //{
        //    _refMSW = MSW;

        //}
        
              
        //public void saveModelFile()
        //{
        //    newds = ArcTim5PropertiesMenu.StaticClass.modeldataset;
        //    ModelSettingsWindow.updateInfoTable(ArcTim5PropertiesMenu.StaticClass.pathName + "//" + ArcTim5PropertiesMenu.StaticClass.modelname);
        //    tempaquiferData = _refMSW.updateTempAquiferTable();
        //    if (ArcTim5PropertiesMenu.StaticClass.modeldataset.Tables["aquiferData"].Equals(this.tempaquiferData))
        //        this.dataTableChanged = true;
        //    this.aquiferData = this.tempaquiferData;

        //    if (ArcTim5PropertiesMenu.StaticClass.modeldataset.Tables["aquiferData"] != null)
        //        ArcTim5PropertiesMenu.StaticClass.modeldataset.Tables.Remove("aquiferData");

        //    newds.Tables.Add(this.aquiferData);

        //    DataTable shapefileDataTable = _refMSW.getShapefileDataTable();

        //    if (shapefileDataTable != null)
        //    {
        //        if (ArcTim5PropertiesMenu.StaticClass.modeldataset.Tables["ShapefileData"] != null)
        //            ArcTim5PropertiesMenu.StaticClass.modeldataset.Tables.Remove("ShapefileData");
        //        newds.Tables.Add(shapefileDataTable);
        //    }
        //    if (ArcTim5PropertiesMenu.StaticClass.modelname == null)
        //    {
        //        MessageBox.Show("Please save model file");
        //        ArcTim5._1.SaveModel sv = new ArcTim5._1.SaveModel();
        //        sv.OnClick();
        //        ArcTim5PropertiesMenu.StaticClass.modelISOpen = true;
        //    }
        //    if (newds.Tables["infoTable"] == null)
        //        ModelSettingsWindow.updateInfoTable(ArcTim5PropertiesMenu.StaticClass.pathName + "//" + ArcTim5PropertiesMenu.StaticClass.modelname);
        //    ArcTim5PropertiesMenu.StaticClass.modeldataset = newds;
        //    newds.WriteXml(ArcTim5PropertiesMenu.StaticClass.pathName + "//" + ArcTim5PropertiesMenu.StaticClass.modelname + ".xml");
        //}

       

        
    }
}
