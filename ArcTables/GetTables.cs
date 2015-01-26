using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geometry;

namespace ArcTables
{
    public class GetTables
    {

        public  DataTable getAttributeTable(string shapeFileName, string shapeFilePath)
        {
            DataTable dt = new DataTable();

            IFeatureClass featureClass = GetFeatureClassFromShapefileOnDisk(shapeFilePath, shapeFileName);
            IFields fields = featureClass.Fields;
            IField field = null;

            
            for (int i = 0; i < fields.FieldCount; i++)
            {
                field = fields.get_Field(i);
                dt.Columns.Add(field.Name);
            }

            DataRow r;
            IIndexes indexes = featureClass.Indexes;
            IFeatureCursor featureCursor = featureClass.Search(null, false);
            IRow featureRow;
            featureRow= featureCursor.NextFeature();
            if (featureRow != null)
            {
                while(featureRow!=null)
                {
                    r = dt.NewRow();
                    for (int i = 0; i < fields.FieldCount; i++)
                    {
                       r[i] = featureRow.get_Value(i);
                    }
                    dt.Rows.Add(r);
                    featureRow = featureCursor.NextFeature();
                }
            }

            
            return dt;
        }

        public DataTable getCoordinates(string shapeFileName, string shapeFilePath, string type)
        {
             DataTable dt = new DataTable();

            IFeatureClass featureClass = GetFeatureClassFromShapefileOnDisk(shapeFilePath, shapeFileName);
            IFields fields = featureClass.Fields;
            //IField field = null;

            DataRow r;
            IIndexes indexes = featureClass.Indexes;
            IFeatureCursor featureCursor = featureClass.Search(null, false);
            IFeature featureRow;
            IPoint pfeat;
            IPolyline pline;
            //IPolygon ppgon;
            

            featureRow = featureCursor.NextFeature();
            
          

            if (type == "point")
            {
                dt.Columns.Add("X");
                dt.Columns.Add("Y");
               
                if (featureRow != null)
                {
                    while (featureRow != null)
                    {
                        r = dt.NewRow();
                        pfeat = (IPoint)featureRow.Shape;
                        r[0] = pfeat.X;
                        r[1] = pfeat.Y;
                        dt.Rows.Add(r);
                        featureRow = featureCursor.NextFeature();
                    }
                }

            }
            if (type == "polyline")
            {
                dt.Columns.Add("X1");
                dt.Columns.Add("Y1");
                dt.Columns.Add("X2");
                dt.Columns.Add("Y2");

                if (featureRow != null)
                {
                    while (featureRow != null)
                    {
                        r = dt.NewRow();
                        pline = (IPolyline)featureRow.Shape;
                        r[0] = pline.FromPoint.X;
                        r[1] = pline.FromPoint.Y;
                        r[2] = pline.ToPoint.X;
                        r[3] = pline.ToPoint.Y;
                        dt.Rows.Add(r);
                        featureRow = featureCursor.NextFeature();
                    }
                }
            }
            if (type == "polygon")
            {
 
            }
            return dt;
        }
        /// <summary>
        /// Get the FeatureClass from a Shapefile on disk (hard drive).
        /// </summary>
        /// <param name="string_ShapefileDirectory">A System.String that is the directory where the shapefile is located. Example: "C:\data\USA"</param>
        /// <param name="string_ShapefileName">A System.String that is the shapefile name. Note: the shapefile extension's (.shp, .shx, .dbf, etc.) is not provided! Example: "States"</param>
        /// <returns>An IFeatureClass interface. Nothing (VB.NET) or null (C#) is returned if unsuccessful.</returns>
        /// <remarks></remarks>
        public ESRI.ArcGIS.Geodatabase.IFeatureClass GetFeatureClassFromShapefileOnDisk(System.String string_ShapefileDirectory, System.String string_ShapefileName)
        {

            System.IO.DirectoryInfo directoryInfo_check = new System.IO.DirectoryInfo(string_ShapefileDirectory);
            if (directoryInfo_check.Exists)
            {

                //We have a valid directory, proceed

                System.IO.FileInfo fileInfo_check = new System.IO.FileInfo(string_ShapefileDirectory + "\\" + string_ShapefileName + ".shp");
                if (fileInfo_check.Exists)
                {

                    //We have a valid shapefile, proceed

                    ESRI.ArcGIS.Geodatabase.IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesFile.ShapefileWorkspaceFactoryClass();
                    ESRI.ArcGIS.Geodatabase.IWorkspace workspace = workspaceFactory.OpenFromFile(string_ShapefileDirectory, 0);
                    ESRI.ArcGIS.Geodatabase.IFeatureWorkspace featureWorkspace = (ESRI.ArcGIS.Geodatabase.IFeatureWorkspace)workspace; // Explict Cast
                    ESRI.ArcGIS.Geodatabase.IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(string_ShapefileName);

                    return featureClass;
                }
                else
                {

                    //Not valid shapefile
                    return null;
                }

            }
            else
            {

                // Not valid directory
                return null;

            }

        }
        
    }
}
