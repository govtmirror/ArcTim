using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ESRI.ArcGIS.DataSourcesFile; 
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Display; 
using ESRI.ArcGIS.esriSystem; 
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry; 
using ESRI.ArcGIS.Framework;
using Karl.Tools.ShapeLib1;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using TimLib;
using ESRI.ArcGIS.Controls;
using System.Collections;

namespace ArcTim
{
    class ArcTimUtilities
    {
        public static string ModelName;
        //public static DataTable getModelData()
        //{

        //    //DataTable modelData = TimLib.Utilities.Read(dbfFilename);
        //    DataTable modelData =ModelSettingsWindow.ds.Tables["aquiferData"];
        //    modelData.WriteXml("xlData.xml");
        //    //DataSet temp = modelData.DataSet;
        //    //temp.Tables.Remove(modelData);
        //    ModelName = modelData.Columns[0].ColumnName;
        //    ArcTim5PropertiesMenu.StaticClass.numLayers = Convert.ToInt16(modelData.Rows[0][0].ToString());
        //    ModelSettingsWindow.numberOfLayers = ArcTim5PropertiesMenu.StaticClass.numLayers;
        //    return modelData;
        //}
        //public static void setModelData(string filename, DataTable modelDataTable)
        //{

        //    // write code to write new .dbf file with data from dialog
        //    //bool fileexists = ArcTimUtilites.DoesFileExists(filename);
        //    //DataSet ds = new DataSet();
        //    //ds.Tables.Add(modelDataTable);
        //    bool fileexport = TimLib.Utilities.EportDBF(modelDataTable, filename);


        //}
        public static string createTimShapefile( string filename, DataTable dtable, string fileType)
        {
            string TimFileName = filename + "_Tim";
            ShapeFile OldShp = new ShapeFile(ArcTimData.StaticClass.infoTable.Rows[0]["ShapefilePath"].ToString()+ "\\" + filename + ".shp");
            DataTable coordTable = new DataTable("coordinates");
            DataTable attTable = new DataTable("attributes");
            DataTable OldAttTable = new DataTable("oldAttTable");
            ShapeFile.ShapeFileTypes shpfileType = ShapeFile.ShapeFileTypes.Point;
            coordTable = OldShp.CoordinateTable;
            OldAttTable = OldShp.AttributeTable;
            
            if (fileType == "constant")
            {
                shpfileType = ShapeFile.ShapeFileTypes.Point;
                int count = dtable.Rows.Count;
                int[] attName = new int[count];
                for (int i = 0; i < count; i++)
                {
                    attTable.Columns.Add(dtable.Rows[i][0].ToString());
                    attName[i] = OldAttTable.Columns.IndexOf(dtable.Rows[i][1].ToString());
                }
                attTable.Columns.Add("Name");
                attTable.Columns.Add("Layer1");
                DataRow r;
                for (int j = 0; j < OldAttTable.Rows.Count; j++)
                {
                    r = attTable.NewRow();
                    for (int k = 0; k < count; k++)
                    {

                        r[0] = OldAttTable.Rows[j][attName[k]].ToString();
                        r[1] = "Constant";
                        r[2] = 1;
                    }
                    attTable.Rows.Add(r);
                }
            }
            if (fileType == "hls")
            {
                shpfileType = ShapeFile.ShapeFileTypes.PolyLine;
                int count = dtable.Rows.Count;
                int[] attName = new int[count];
                for (int i = 0; i < count; i++)
                {
                    attTable.Columns.Add(dtable.Rows[i][0].ToString());
                    attName[i] = OldAttTable.Columns.IndexOf(dtable.Rows[i][1].ToString());
                }
                //attTable.Columns.Add("Name");
                
                DataRow r;
                for (int j = 0; j < OldAttTable.Rows.Count; j++)
                {
                    r = attTable.NewRow();
                    

                        r[0] = OldAttTable.Rows[j][attName[0]].ToString();
                        r[1] = OldAttTable.Rows[j][attName[1]].ToString();
                      
                    
                    attTable.Rows.Add(r);
                }
            }
            if (fileType == "rls")
            {
                shpfileType = ShapeFile.ShapeFileTypes.PolyLine;
                int count = dtable.Rows.Count;
                int[] attName = new int[count];
                for (int i = 0; i < count; i++)
                {
                    attTable.Columns.Add(dtable.Rows[i][0].ToString());
                    attName[i] = OldAttTable.Columns.IndexOf(dtable.Rows[i][1].ToString());
                }
                //attTable.Columns.Add("Name");
                
                DataRow r;
                for (int j = 0; j < OldAttTable.Rows.Count; j++)
                {
                    r = attTable.NewRow();

                    
                    r[0] = OldAttTable.Rows[j][attName[0]].ToString();
                    r[1] = OldAttTable.Rows[j][attName[1]].ToString();
                    r[2] = OldAttTable.Rows[j][attName[2]].ToString();
                    r[3] = OldAttTable.Rows[j][attName[3]].ToString();
                    r[4] = OldAttTable.Rows[j][attName[4]].ToString();

                    

                    attTable.Rows.Add(r);
                }
            }
            if (fileType == "fls")
            {
                shpfileType = ShapeFile.ShapeFileTypes.PolyLine;
                int count = dtable.Rows.Count;
                int[] attName = new int[count];
                for (int i = 0; i < count; i++)
                {
                    attTable.Columns.Add(dtable.Rows[i][0].ToString());
                    attName[i] = OldAttTable.Columns.IndexOf(dtable.Rows[i][1].ToString());
                }
                //attTable.Columns.Add("Name");
               
                DataRow r;
                for (int j = 0; j < OldAttTable.Rows.Count; j++)
                {
                    r = attTable.NewRow();


                    r[0] = OldAttTable.Rows[j][attName[0]].ToString();
                    r[1] = OldAttTable.Rows[j][attName[1]].ToString();

                    

                    attTable.Rows.Add(r);
                }
            }
                if (fileType == "well")
                {
                    shpfileType = ShapeFile.ShapeFileTypes.Point;
                    int count = dtable.Rows.Count;
                    int[] attName = new int[count-1];
                    for (int i = 0; i < count-1; i++)
                    {
                        attTable.Columns.Add(dtable.Rows[i][0].ToString());
                        attName[i] = OldAttTable.Columns.IndexOf(dtable.Rows[i][1].ToString());
                    }
                    //attTable.Columns.Add("Name");
                    for (int i = 0; i < Convert.ToInt32(dtable.Rows[count - 1][1]); i++)
                    {
                        attTable.Columns.Add("Layer"+Convert.ToString(i+1));
                    }
                    DataRow r;
                    for (int j = 0; j < OldAttTable.Rows.Count; j++)
                    {
                        r = attTable.NewRow();

                        for (int k = 0; k <attName.Length;k++)
                            r[k] = OldAttTable.Rows[j][attName[k]].ToString();

                        attTable.Rows.Add(r);
                    }
                }
           //ShapeFile.ShapeFileTypes.Point
            ShapeFile newTimShp = new ShapeFile(shpfileType, coordTable, attTable);
            newTimShp.Write(ArcTimData.StaticClass.infoTable.Rows[0]["ShapefilePath"].ToString() + "\\" + filename + "_Tim.shp");
            //next step... bring shapefile into map document
            //extrapolate to other feature types
            return filename + "_Tim.shp";
        }

       
        internal static void addNewShapefile(IApplication m_application, string shpFileName)
        {

            IMxDocument pDoc = m_application.Document as IMxDocument;
            IMap pMap = pDoc.FocusMap; 
            IWorkspaceFactory pFactory = new ShapefileWorkspaceFactory();
            // Based on the .NET Application Setting WorldShapefilePath, get the path, make a layer, and add to TOC
            IFeatureWorkspace pFeatWorkspace = pFactory.OpenFromFile(System.IO.Path.GetDirectoryName(ArcTimData.StaticClass.infoTable.Rows[0]["ShapefilePath"].ToString() + "\\" + shpFileName), 0) as IFeatureWorkspace;
            IFeatureClass pFeatClass = pFeatWorkspace.OpenFeatureClass(System.IO.Path.GetFileNameWithoutExtension(ArcTimData.StaticClass.infoTable.Rows[0]["ShapefilePath"].ToString() + "\\" + shpFileName));
            IFeatureLayer pfeatureLayer = new FeatureLayerClass();
            pfeatureLayer.Name = System.IO.Path.GetFileNameWithoutExtension(shpFileName);
            pfeatureLayer.FeatureClass = pFeatClass;
            pMap.AddLayer((ILayer)pfeatureLayer);
            IActiveView iav = pDoc.ActiveView;
            iav.PartialRefresh(esriViewDrawPhase.esriViewGeography,null, null);
            iav.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            pDoc.UpdateContents();
        }


        internal static string CreateNewTimShapefile(string timFeatureType, string shapefileName)
        {
            DataTable coordTable = new DataTable();
            DataTable attTable = new DataTable();
            ShapeFile.ShapeFileTypes shpfiletype = ShapeFile.ShapeFileTypes.Point;
            if (timFeatureType == "Constant")
            {
                shpfiletype = ShapeFile.ShapeFileTypes.Point;
                attTable.Columns.Add("Head");
                attTable.Columns.Add("Name");
                attTable.Columns.Add("Layer1");
                
            }

            if (timFeatureType == "FlowLineSink")
            {
                shpfiletype = ShapeFile.ShapeFileTypes.PolyLine;
                //attTable.Columns.Add("sigma");
                attTable.Columns.Add("Name");
                attTable.Columns.Add("Sigma1");
            }
            if (timFeatureType == "ResLineSink")
            {
                shpfiletype = ShapeFile.ShapeFileTypes.PolyLine;
                //attTable.Columns.Add("Head");
                attTable.Columns.Add("Resistance");
                attTable.Columns.Add("BotElev");
                attTable.Columns.Add("Width");
                attTable.Columns.Add("Name");
                attTable.Columns.Add("Head1");
            }
            if (timFeatureType == "HeadLineSink")
            {
                shpfiletype = ShapeFile.ShapeFileTypes.PolyLine;
                //attTable.Columns.Add("Head");
                attTable.Columns.Add("Name");
                attTable.Columns.Add("Head1");
            }
            if (timFeatureType == "Well")
            {
                shpfiletype = ShapeFile.ShapeFileTypes.Point;
                attTable.Columns.Add("Discharge");
                attTable.Columns.Add("Radius");
                attTable.Columns.Add("Name");
                attTable.Columns.Add("Layer1");
            }
            ShapeFile newTimShp = new ShapeFile(shpfiletype, coordTable, attTable);
            newTimShp.Write(ArcTimData.StaticClass.infoTable.Rows[0]["ShapefilePath"].ToString() + "\\" + shapefileName + "_Tim.shp");
            return  shapefileName + "_Tim.shp";
        }
        public static void CreateDefaultOutputFile(IApplication m_application, IHookHelper m_hookHelper2)
        {

            IMap map = GetMap(m_application);
            IActiveView ia = m_hookHelper2.ActiveView;
            //DataSet oD = new DataSet("OutputData");
            DataTable outputData = new DataTable("Output");
            double xmax = 0;
            double xmin = 0;
            double ymax = 0;
            double ymin = 0;
            double nx = 0;
            double ny = 0;
            outputData.Columns.Add("MinExtents");
            outputData.Columns.Add("MaxExtents");
            outputData.Columns.Add("NumCells");
            double resx = 0;
            // getextentsData

            xmax = ia.Extent.XMax;
            xmin = ia.Extent.XMin;
            ymax = ia.Extent.YMax;
            ymin = ia.Extent.YMin;


            resx = 0.01;

            double xtemp = 0;
            double ytemp = 0;
            double delx = 0;
            double dely = 0;


            delx = xmax - xmin;
            dely = ymax - ymin;

            xtemp = delx * resx;
            ytemp = dely * resx;

            ny = Convert.ToInt64(dely / ytemp);
            nx = Convert.ToInt64(delx / xtemp);

            if (dely % ytemp != 0)
            {
                ny = Convert.ToInt64(dely / ytemp) + 1;
                dely = ny * ytemp;
            }
            if (delx % xtemp != 0)
            {
                nx = Convert.ToInt64(delx / xtemp) + 1;
                delx = nx * xtemp;
            }
            if (delx < dely)
            {
                xmax = nx * ytemp + xmin;
                ymax = ny * ytemp + ymin;
            }
            if (dely < delx)
            {
                xmax = nx * xtemp + xmin;
                ymax = ny * xtemp + ymin;
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
            //oD.Tables.Add(outputData);
            outputData.WriteXml(ArcTimData.StaticClass.infoTable.Rows[0]["ModelPath"].ToString()+ "\\outputSettings.xml");
        }
        #region "Get ActiveView from ArcMap"
        // ArcGIS Snippet Title: 
        // Get ActiveView from ArcMap
        //
        // Add the following references to the project:
        // ESRI.ArcGIS.ArcMapUI
        // ESRI.ArcGIS.Carto
        // ESRI.ArcGIS.Framework
        // ESRI.ArcGIS.System
        // 
        // Intended ArcGIS Products for this snippet:
        // ArcGIS Desktop
        //
        // Required ArcGIS Extensions:
        // (NONE)
        //
        // Notes:
        // This snippet is intended to be inserted at the base level of a Class.
        // It is not intended to be nested within an existing Method.
        //
        // Use the following XML documentation comments to use this snippet:
        /// <summary>Get ActiveView from ArcMap.</summary>
        ///
        /// <param name="application">An IApplication interface that is the ArcMap application.</param>
        /// 
        /// <returns>An IActiveView interface.</returns>
        /// 
        /// <remarks></remarks>
        public static ESRI.ArcGIS.Carto.IActiveView GetActiveView(ESRI.ArcGIS.Framework.IApplication application)
        {
            if (application == null)
            {
                return null;
            }
            ESRI.ArcGIS.ArcMapUI.IMxDocument mxDocument = application.Document as ESRI.ArcGIS.ArcMapUI.IMxDocument; // Dynamic Cast
            ESRI.ArcGIS.Carto.IActiveView activeView = mxDocument.ActiveView;

            return activeView;
        }
        #endregion
        #region "Get Map from ArcMap"
        // ArcGIS Snippet Title: 
        // Get Map from ArcMap
        //
        // Add the following references to the project:
        // ESRI.ArcGIS.ArcMapUI
        // ESRI.ArcGIS.Carto
        // ESRI.ArcGIS.Framework
        // ESRI.ArcGIS.System
        // 
        // Intended ArcGIS Products for this snippet:
        // ArcGIS Desktop
        //
        // Required ArcGIS Extensions:
        // (NONE)
        //
        // Notes:
        // This snippet is intended to be inserted at the base level of a Class.
        // It is not intended to be nested within an existing Method.
        //
        // Use the following XML documentation comments to use this snippet:
        /// <summary>Get Map from ArcMap.</summary>
        ///
        /// <param name="application">An IApplication interface that is the ArcMap application.</param>
        /// 
        /// <returns>An IMap interface.</returns>
        /// 
        /// <remarks></remarks>
        public static ESRI.ArcGIS.Carto.IMap GetMap(ESRI.ArcGIS.Framework.IApplication application)
        {
            if (application == null)
            {
                return null;
            }
            ESRI.ArcGIS.ArcMapUI.IMxDocument mxDocument = ((ESRI.ArcGIS.ArcMapUI.IMxDocument)(application.Document)); // Explicit Cast
            ESRI.ArcGIS.Carto.IActiveView activeView = mxDocument.ActiveView;
            ESRI.ArcGIS.Carto.IMap map = activeView.FocusMap;

            return map;

        }
        #endregion             
    }
}
