using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.ArcMapUI;
using System.Windows.Forms;
using System.IO;

namespace ArcTim
{
    /// <summary>
    /// Summary description for SaveModel.
    /// </summary>
    [Guid("8666b075-cdeb-4450-bebd-991d78462507")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("ArcTim5._1.SaveModel")]
    public sealed class SaveModel : BaseCommand
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
        //private ModelSettingsWindow _refMSW;
        public SaveModel()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "Save"; //localizable text
            base.m_caption = "Save";  //localizable text
            base.m_message = "Save Tim model";  //localizable text 
            base.m_toolTip = "Save Tim model";  //localizable text 
            base.m_name = "save";   //unique id, non-localizable (e.g. "MyCategory_ArcMapCommand")
            
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

        #region Overridden Class Methods

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

            // TODO:  Add other initialization code
        }

        /// <summary>
        /// Occurs when this command is clicked
        /// </summary>
        public override void OnClick()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML file|*.xml";
            saveFileDialog1.Title = "Save model file";
            saveFileDialog1.ShowDialog();
            
            if (saveFileDialog1.FileName != "")
            {
                ArcTimData.StaticClass.infoTable.Rows[0]["ShapefilePath"] = Path.GetDirectoryName(saveFileDialog1.FileName);
                ArcTimData.StaticClass.infoTable.Rows[0]["ModelName"] = Path.GetFileNameWithoutExtension(saveFileDialog1.FileName);
                //ArcTim5PropertiesMenu.StaticClass.modelXMLfilename = saveFileDialog1.FileName; 
                //ModelSettingsWindow ms = new ModelSettingsWindow(m_application, true);
                //ms.saveModelFile();
                ArcTimData.writexmlFile();
                //ArcTim5PropertiesMenu.StaticClass.infoTable.WriteXml(ArcTim5PropertiesMenu.StaticClass.pathName + "//" + ArcTim5PropertiesMenu.StaticClass.modelname + ".xml");
                //ArcTim5PropertiesMenu.StaticClass.shapeFileTable.WriteXml(ArcTim5PropertiesMenu.StaticClass.pathName + "//" + ArcTim5PropertiesMenu.StaticClass.modelname + "_aq.xml");
                //ArcTim5PropertiesMenu.StaticClass.aquiferTable.WriteXml(ArcTim5PropertiesMenu.StaticClass.pathName + "//" + ArcTim5PropertiesMenu.StaticClass.modelname + "_shp.xml");
    
            }
        }

        #endregion
    }
}
