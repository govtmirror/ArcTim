using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.esriSystem;
using System.Data;
using System.IO;
using System.Xml;
using System.Collections;
using TimLib;
using System.Diagnostics;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.GeoAnalyst;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Carto;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ArcTables;

namespace ArcTim
{
    /// <summary>
    /// Summary description for RunTimML.
    /// </summary>
    [Guid("40acb430-f604-4611-887a-24b7626529bc")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("ArcTim5.RunTimML")]
    public sealed class RunTimML : BaseCommand
    {
        #region COM Registration Function(s)
        [ComRegisterFunction()]
        [ComVisible(false)]
        static void RegisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryRegistration(registerType);

            //
            // TODO: Add any COM registration code here
            //
        }

        [ComUnregisterFunction()]
        [ComVisible(false)]
        static void UnregisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryUnregistration(registerType);

            //
            // TODO: Add any COM unregistration code here
            //
        }

        #region ArcGIS Component Category Registrar generated code
        /// <summary>
        /// Required method for ArcGIS Component Category registration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Register(regKey);

        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Unregister(regKey);

        }

        #endregion
        #endregion

        private IApplication m_application;
       // public string outputName;
        public int numLayers;
        public IHookHelper  m_hookhelper2;
        private IHookHelper m_hookHelper = null;
        public StreamWriter sw2;

        public RunTimML()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = ""; //localizable text
            base.m_caption = "RunTimML";  //localizable text
            base.m_message = "";  //localizable text 
            base.m_toolTip = "Run TimML";  //localizable text 
            base.m_name = "";   //unique id, non-localizable (e.g. "MyCategory_ArcMapCommand")

            try
            {
                //
                // TODO: change bitmap name if necessary
                //
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overriden Class Methods

        /// <summary>
        /// Occurs when this command is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            if (hook == null)
                return;
            
            m_application = hook as IApplication;

            //Disable if it is not ArcMap
            if (hook is IMxApplication)
                base.m_enabled = true;
            else
                base.m_enabled = false;
            try
            {
                m_hookHelper = new HookHelperClass();
                m_hookHelper.Hook = hook;
                if (m_hookHelper.ActiveView == null)
                {
                    m_hookHelper = null;
                }
            }
            catch
            {
                m_hookHelper = null;
            }
            // TODO:  Add other initialization code
        }

        /// <summary>
        /// Occurs when this command is clicked
        /// </summary>
        public override void OnClick()
        {
           Process process;
            ProcessStartInfo startInfo = new ProcessStartInfo();
            //StreamWriter sm = new StreamWriter(ArcTimData.StaticClass.infoTable.Rows[0]["ModelPath"].ToString() + "\runTim.log");
            string timMLFileName = this.prepareTimInputFile();
            startInfo.FileName = ArcTimData.StaticClass.infoTable.Rows[0]["PythonPath"].ToString() + "\\python";
            startInfo.Arguments = timMLFileName;
            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            startInfo.ErrorDialog = true;
            process = Process.Start(startInfo);
            Console.WriteLine("Waiting for 30 seconds for process to finish.");
            if (process.WaitForExit(18000000))
            {
                Console.WriteLine("Process terminated.");
            }
            else
            {
                Console.WriteLine("TImed out waiting for process to end.");
            }
            for (int i = 0; i < ArcTimData.StaticClass.aqPropTable.Rows.Count; i++)
            {
                string modelpath = ArcTimData.StaticClass.infoTable.Rows[0]["ModelPath"].ToString();
                string modelName = ArcTimData.StaticClass.infoTable.Rows[0]["ModelName"].ToString();
                string filename = modelpath + "\\" + modelName + Convert.ToString(i + 1) + ".txt";
                string outputfilename = modelpath + "\\" + modelName + Convert.ToString(i + 1) + ".aux";
                //string outputfilename = ArcTim5PropertiesMenu.StaticClass.pathName + "\\" + "TimOut" + Convert.ToString(i + 1) + ".aux";
                string checkName = modelName + Convert.ToString(i + 1);
                //string checkName = "TimOut" + Convert.ToString(i + 1);
                if (modelName.Length > 7)
                {
                    checkName = modelName.Remove(6) + (i + 1);
                    outputfilename = modelpath + "\\" + checkName + ".aux";
                }
                int checkRaster = CheckforExisitingRaster(checkName);
                IMxDocument pMxDoc = GetMxDocument(m_application);
                IWorkspaceFactory pRasterWSF = new RasterWorkspaceFactory();


                if (checkRaster >= 0)
                {
                    IRasterWorkspace pRasterWS = pRasterWSF.OpenFromFile(modelpath, 0) as IRasterWorkspace;
                    IRasterDataset pRasterDataset = pRasterWS.OpenRasterDataset(checkName);
                    IDataset pDataset = pRasterDataset as IDataset;
                    if (checkRaster >= 0)
                        pMxDoc.FocusMap.DeleteLayer(pMxDoc.FocusMap.get_Layer(checkRaster));
                    if (pDataset.CanDelete())
                        pDataset.Delete();
                }
                if (File.Exists(outputfilename) || Directory.Exists(modelpath + "\\" + checkName) || Directory.Exists(modelpath + "\\Info"))
                {
                    if (File.Exists(outputfilename))
                        File.Delete(outputfilename);
                    if (Directory.Exists(modelpath + "\\" + checkName))
                        Directory.Delete(modelpath + "\\" + checkName, true);
                    if (Directory.Exists(modelpath + "\\Info"))
                        Directory.Delete(modelpath + "\\Info", true);
                }
                readModelOutput(filename, checkName);

            }
        }

        private int CheckforExisitingRaster(string checkName)
        {
            IMxDocument pMxDoc = GetMxDocument(m_application);
            IMap pMap = pMxDoc.FocusMap;
            int layNum = -1;
            for (int l = 0; l < pMap.LayerCount; l++)
            {
               
                if (pMap.get_Layer(l).Name == checkName)
                    layNum = l;
            }
            if (layNum != -1)
                return layNum;
            else
                return -1;
            //pMxDoc.FocusMap.DeleteLayer(iLay)
        }


        public void readModelOutput(string InputFileName, string OutputFileName)
        {
            try
            {
                IRasterImportOp pRasterImportOp = new ESRI.ArcGIS.GeoAnalyst.RasterConversionOp() as IRasterImportOp;

                IWorkspaceFactory PRasterWSFact = new RasterWorkspaceFactory() as IWorkspaceFactory;
                IWorkspace pRasterWS = PRasterWSFact.OpenFromFile(ArcTimData.StaticClass.infoTable.Rows[0]["ModelPath"].ToString(), 0) as IWorkspace;
                //ImportfromAscii must have an output filename that is less than 8 char
                //the output filename shouldn't have the path with it
                IRasterDataset pRasOut = pRasterImportOp.ImportFromASCII(InputFileName, pRasterWS, OutputFileName, "GRID", false);
                IRasterLayer pRasterLy = new RasterLayer();
                pRasterLy.CreateFromDataset(pRasOut);
                IMxDocument pMxDoc = GetMxDocument(m_application);
                pMxDoc.FocusMap.AddLayer(pRasterLy);
                pMxDoc.FocusMap.MoveLayer(pRasterLy,pMxDoc.FocusMap.LayerCount - 1);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            //try
            //{
            //    IWorkspaceFactory pWorkspaceFactory = new RasterWorkspaceFactory() as IWorkspaceFactory;
            //    IRasterWorkspace pRasterworkspace = (IRasterWorkspace)pWorkspaceFactory.OpenFromFile(ArcTim5PropertiesMenu.StaticClass.pathName, 0);

            //    IRasterLayer pRasterLayer = new RasterLayer();
            //    pRasterLayer.CreateFromDataset(pRasterworkspace.OpenRasterDataset(InputFileName));
            //    pRasterLayer.Name = OutputFileName;

            //    IMxDocument pMxDoc = GetMxDocument(m_application);
            //    pMxDoc.FocusMap.AddLayer(pRasterLayer);
            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine(ex.Message);
            //}

        }
        #region "Get MxDocument from ArcMap"
        // ArcGIS Snippet Title: 
        // Get MxDocument from ArcMap
        //
        // Add the following references to the project:
        // ESRI.ArcGIS.ArcMapUI
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
        /// <summary>Get MxDocument from ArcMap.</summary>
        ///
        /// <param name="application">An IApplication interface that is the ArcMap application.</param>
        /// 
        /// <returns>An IMxDocument interface.</returns>
        /// 
        /// <remarks></remarks>
        public ESRI.ArcGIS.ArcMapUI.IMxDocument GetMxDocument(ESRI.ArcGIS.Framework.IApplication application)
        {

            if (application == null)
            {
                return null;
            }
            ESRI.ArcGIS.ArcMapUI.IMxDocument mxDocument = ((ESRI.ArcGIS.ArcMapUI.IMxDocument)(application.Document)); // Explicit Cast

            return mxDocument;

        }
        #endregion       
        public string prepareTimInputFile()
        {
            //ArrayList shapefileNames, ArrayList shapefileTypes, 
            //string TimFileName, ArrayList tableNames, double xmax, 
            //double xmin, double ymax, double ymin, double xres, 
            //double yres, string path, string outputName, 
            //string dbBaseTableName, string outputSig

            //RunTim rt = new RunTim();
            //rt.ShowDialog();
            //string path = rt.path;
            string shapefilepath = ArcTimData.StaticClass.infoTable.Rows[0]["ShapefilePath"].ToString();
            string modelpath = ArcTimData.StaticClass.infoTable.Rows[0]["ModelPath"].ToString();
            string pythonPathName = ArcTimData.StaticClass.infoTable.Rows[0]["PythonPath"].ToString();
            string modelName = ArcTimData.StaticClass.infoTable.Rows[0]["ModelName"].ToString();

            ArrayList shapefileNames = new ArrayList();
            ArrayList shapefileTypes = new ArrayList();
            ArrayList tableNames = new ArrayList();


            for (int i = 0; i < ArcTimData.StaticClass.shapefileTable.Rows.Count; i++)
            {
                shapefileNames.Add(shapefilepath + "\\" + ArcTimData.StaticClass.shapefileTable.Rows[i][0].ToString() + ".shp");
                shapefileTypes.Add(ArcTimData.StaticClass.shapefileTable.Rows[i][1].ToString());
                tableNames.Add(ArcTimData.StaticClass.shapefileTable.Rows[i][2].ToString());
            }

            //string TimFileName = modelData.Rows[0][1].ToString();

            double xmax = Convert.ToDouble(ArcTimData.StaticClass.outputPropTable.Rows[0]["MaxExtents"].ToString());
            double ymax = Convert.ToDouble(ArcTimData.StaticClass.outputPropTable.Rows[1]["MaxExtents"].ToString());
            double xmin = Convert.ToDouble(ArcTimData.StaticClass.outputPropTable.Rows[0]["MinExtents"].ToString());
            double ymin = Convert.ToDouble(ArcTimData.StaticClass.outputPropTable.Rows[1]["MinExtents"].ToString());
            double nx = Convert.ToDouble(ArcTimData.StaticClass.outputPropTable.Rows[0]["NumCells"].ToString());
            double ny = Convert.ToDouble(ArcTimData.StaticClass.outputPropTable.Rows[1]["NumCells"].ToString());
            double dx = Convert.ToDouble(ArcTimData.StaticClass.outputPropTable.Rows[0]["Delta"].ToString());

            //outputName = ArcTim5PropertiesMenu.StaticClass.modelname;
            //int numPath = path.Length+1;
            // string dbBaseTableName = modelData.Rows[0][2].ToString();
            //// dbBaseTableName = dbBaseTableName.Remove(0, numPath);
            // int locDot = dbBaseTableName.IndexOf('.');
            // dbBaseTableName = dbBaseTableName.Remove(locDot);
            string xmlfilename = ArcTimData.StaticClass.infoTable.Rows[0]["ModelName"].ToString() + ".xml";
            string outputSig = "1";


            TimLib.TimLib1 tc = new TimLib.TimLib1();
            tc.writeTimFile(shapefileNames, shapefileTypes, modelName, tableNames, xmin, ymin, nx, ny, dx, modelpath, modelName, xmlfilename, outputSig, pythonPathName);
            //tc.writeTimFile(shapefileNames, shapefileTypes, ArcTim5PropertiesMenu.StaticClass.modelname, tableNames, xmax, xmin, ymax, ymin, nx, ny, modelpath, ArcTim5PropertiesMenu.StaticClass.modelname, xmlfilename, outputSig, sw2);

            return @"" + modelpath + "\\" + modelName + ".py" + "";
        }

        
        #endregion
    }
}
