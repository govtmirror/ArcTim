using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.ADF.BaseClasses;

namespace ArcTim
{
    /// <summary>
    /// Summary description for ShapefileMenu.
    /// </summary>
    [Guid("6eabdcb9-abba-435e-8192-3561cf3c4b8c")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("ArcTim5.ShapefileMenu")]
    public sealed class ShapefileMenu : BaseMenu
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

        public ShapefileMenu()
        {
            //
            // TODO: Define your menu here by adding items
            //
            //AddItem("esriArcMapUI.ZoomInFixedCommand");
            //BeginGroup(); //Separator
            AddItem("{051d13fd-836e-4332-b2c0-615effbd192b}", 1);
            AddItem("{bff035a4-b51f-4d47-8d37-75a54c4eb074}", 1);//undo command
            //AddItem(new Guid("FBF8C3FB-0480-11D2-8D21-080009EE4E51"), 2); //redo command
        }

        public override string Caption
        {
            get
            {
                //TODO: Replace bar caption
                return "Shapefile Tools";
            }
        }
        public override string Name
        {
            get
            {
                //TODO: Replace bar ID
                return "ShapefileMenu";
            }
        }
    }
}