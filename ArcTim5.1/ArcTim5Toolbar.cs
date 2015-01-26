using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.ADF.BaseClasses;

namespace ArcTim
{
    /// <summary>
    /// Summary description for ArcTim5Toolbar.
    /// </summary>
    [Guid("86793782-d90a-486c-bbc3-50afddb672f0")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("ArcTim5.ArcTim5Toolbar")]
    public sealed class ArcTim5Toolbar : BaseToolbar
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

        public ArcTim5Toolbar()
        {
            //
            // TODO: Define your toolbar here by adding items
            //
            
            AddItem("{d2f30b9c-bd65-4ced-9c38-cce5845bb3de}", 1); //Model dropdown
            BeginGroup();
            AddItem("{6eabdcb9-abba-435e-8192-3561cf3c4b8c}", 2); //Shapefile dropdown
            BeginGroup();
            AddItem("{6132ad18-beed-451d-88af-509e3fb9b9ae}", 3);
            BeginGroup();
            AddItem("{40acb430-f604-4611-887a-24b7626529bc}", 4); //Run button
            
            
            
            //AddItem("esriArcMapUI.ZoomInTool");
            //BeginGroup(); //Separator
            //AddItem("{FBF8C3FB-0480-11D2-8D21-080009EE4E51}", 1); //undo command
            //AddItem(new Guid("FBF8C3FB-0480-11D2-8D21-080009EE4E51"), 2); //redo command
        }

        public override string Caption
        {
            get
            {
                //TODO: Replace bar caption
                return "ArcTim 2.0";
            }
        }
        public override string Name
        {
            get
            {
                //TODO: Replace bar ID
                return "ArcTim5Toolbar";
            }
        }
    }
}