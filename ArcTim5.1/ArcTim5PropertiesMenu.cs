using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.ADF.BaseClasses;
using System.Data;

namespace ArcTim
{
    /// <summary>
    /// Summary description for ArcTim5PropertiesMenu.
    /// </summary>
    [Guid("d2f30b9c-bd65-4ced-9c38-cce5845bb3de")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("ArcTim5.ArcTim5PropertiesMenu")]
    public sealed class ArcTim5PropertiesMenu : BaseMenu
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
            MxCommandBars.Register(regKey);
        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommandBars.Unregister(regKey);
        }

        #endregion
        #endregion

        public ArcTim5PropertiesMenu()
        {
            //
            // TODO: Define your menu here by adding items
            //
            //AddItem("esriArcMapUI.ZoomInFixedCommand");
            //BeginGroup(); //Separator
            AddItem("{8666b075-cdeb-4450-bebd-991d78462507}", 1); //SaveModel Command
            AddItem("{ab3b6761-cff3-4a93-a9bb-29d977be137e}", 1); //Open Command
            AddItem("{38f38bc7-8a24-46a7-aa47-77d78ffde0a5}", 1); //Model Settings Command
            AddItem("{fff85839-f477-49b9-bed9-d51cb8b6511a}", 1); //Output Settings Command
            
            //AddItem(new Guid("FBF8C3FB-0480-11D2-8D21-080009EE4E51"), 2); //redo command
        }
        //public static class StaticClass
        //{
        //    public static string pathName;
        //    public static int numLayers;
        //    public static string modelname;
        //    public static string modelXMLfilename = null;
        //    //public static string dbfFileName;
        //    public static DataSet modeldataset;
        //    public static bool modelISOpen = false;
        //    public static string pythonPathName;
        //    public static string shapefilePathName;
        //    public static DataTable infoTable;
        //    //public static DataTable shapeFileTable;
        //    //public static DataTable aquiferTable;
        //    //public static DataTable outputTable;
        //}
        public override string Caption
        {
            get
            {
                //TODO: Replace bar caption
                return "Model";
            }
        }
        public override string Name
        {
            get
            {
                //TODO: Replace bar ID
                return "ArcTim5PropertiesMenu";
            }
        }
    }
}