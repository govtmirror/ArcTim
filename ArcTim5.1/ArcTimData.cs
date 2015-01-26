using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Carto;

namespace ArcTim
{
    class ArcTimData
    {
        public static class StaticClass
        {
            public static DataTable infoTable;
            public static DataTable aqPropTable;
            public static DataTable shapefileTable;
            public static DataTable outputPropTable;
            public static string modelName;
            public static DataTable modflowInfoTable;
            public static DataTable modflowPropTable;
        }

        public static void writexmlFile()
        {
            DataSet ds = new DataSet();
            string xmlPath = @"C:\";
            
            if (StaticClass.infoTable.Rows[0]["ModelPath"].ToString()!="")
                    xmlPath = StaticClass.infoTable.Rows[0]["ModelPath"].ToString();
            if (StaticClass.infoTable.Rows[0]["ModelName"].ToString() != "")
                StaticClass.modelName = StaticClass.infoTable.Rows[0]["ModelName"].ToString();
            ds.Tables.Add(StaticClass.infoTable);
            ds.Tables.Add(StaticClass.aqPropTable);
            ds.Tables.Add(StaticClass.shapefileTable);
            ds.Tables.Add(StaticClass.outputPropTable);
            ds.WriteXml(xmlPath + "\\"+StaticClass.modelName+".xml");
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                ds.Tables[i].ChildRelations.Clear();
                ds.Tables[i].ParentRelations.Clear();
                string s = ds.Tables[i].TableName;
                ds.Tables.Remove(s);
            }


        }
        public static void readXMLFile(string xmlFile)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(xmlFile);
            StaticClass.infoTable = ds.Tables["infoTable"];
            StaticClass.aqPropTable = ds.Tables["AquiferPropertyTable"];
            StaticClass.shapefileTable = ds.Tables["ShapefileData"];
            StaticClass.outputPropTable = ds.Tables["OutputSettings"];

            for (int i = 0; i < ds.Tables.Count; i++)
            {
                ds.Tables[i].ChildRelations.Clear();
                ds.Tables[i].ParentRelations.Clear();
                string s = ds.Tables[i].TableName;
                ds.Tables.Remove(s);
            }

        }
       

       


        #region"Get Map from ArcMap"
        // ArcGIS Snippet Title:
        // Get Map from ArcMap
        // 
        // Long Description:
        // Get Map from ArcMap.
        // 
        // Add the following references to the project:
        // ESRI.ArcGIS.ArcMapUI
        // ESRI.ArcGIS.Carto
        // ESRI.ArcGIS.Framework
        // ESRI.ArcGIS.System
        // 
        // Intended ArcGIS Products for this snippet:
        // ArcGIS Desktop (ArcEditor, ArcInfo, ArcView)
        // 
        // Applicable ArcGIS Product Versions:
        // 9.2
        // 9.3
        // 9.3.1
        // 10.0
        // 
        // Required ArcGIS Extensions:
        // (NONE)
        // 
        // Notes:
        // This snippet is intended to be inserted at the base level of a Class.
        // It is not intended to be nested within an existing Method.
        // 

        ///<summary>Get Map from ArcMap</summary>
        ///  
        ///<param name="application">An IApplication interface that is the ArcMap application.</param>
        ///   
        ///<returns>An IMap interface.</returns>
        ///   
        ///<remarks></remarks>
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
    
