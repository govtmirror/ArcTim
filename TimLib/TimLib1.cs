using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;
using System.Data;
using System.Xml;
using ArcTables;





namespace TimLib
{
    public class TimLib1
    {
        public string ModelName = "ml";
        public int naq = 0;
        public string wellNames = null;
        public double numwells = 0;
        public string kCol, vkCol, tCol, bCol, nCol, vnCol, lCol;

        public void writeTimFile(ArrayList shapefileNames, ArrayList shapefileTypes, 
            string TimFileName, ArrayList tableNames,  
            double xmin, double ymin, double nx, 
            double ny, double dx, string path, string outputName, 
            string xmlTableName, string outputSig, string pythonPathName)
        {
            //check for analytic element types in types.txt
            string TimType = null;
            int typeSZ = shapefileTypes.Count;
            DataSet ds = new DataSet();
            DataTable headlinesinkTable = new DataTable();
            DataTable wellTable = new DataTable();
            DataTable constantTable = new DataTable();
            DataTable circTable = new DataTable();
            DataTable flowlinesinkTable = new DataTable();
            DataTable reslinesinkTable = new DataTable();
            DataTable polyareasinkTable = new DataTable();
            int hls = 0, fls=0, rls=0, w=0, cs=0, ps=0, pi=0, ci=0, tp = 0;
            string dTypeName = null;
            int cNum = 0;
            this.getModelData(path, xmlTableName, ds);
            if (shapefileTypes.Contains("constant"))
            {
                cNum = shapefileTypes.IndexOf("constant");
                string shp = (string)shapefileNames[cNum].ToString();
                TimType = (string)shapefileTypes[cNum].ToString();
                this.getpointDatafromShp(shp, ds, TimType, "constant");
            }
            for (int i = 0; i < typeSZ; i++)
            {
                
                string shp = (string)shapefileNames[i].ToString();
                DataTable dt = new DataTable();
                TimType = (string)shapefileTypes[i].ToString();
                
               

                string dtName = (string)tableNames[i].ToString();
                if (dtName != " " && dtName != "")
                    dt = Utilities.Read(dtName);
                switch (TimType)//get data from Shapefiles
                {
                    case "headlinesink":
                        hls = hls + 1;
                        dTypeName = TimType + hls.ToString();
                        this.getlineDatafromShp(shp, ds, TimType, dTypeName);
                        break;
                    case "flowlinesink":
                        fls = fls + 1;
                        dTypeName = TimType + fls.ToString();
                        this.getlineDatafromShp(shp, ds, TimType, dTypeName);
                        break;
                    case "reslinesink":
                        rls = rls + 1;
                        dTypeName = TimType + rls.ToString();
                        this.getlineDatafromShp(shp, ds, TimType, dTypeName);
                        break;
                    case "well":
                        w = w + 1;
                        dTypeName = TimType + w.ToString();
                        this.getpointDatafromShp(shp, ds, TimType, dTypeName);
                        break;
                    //case "constant":
                    //    c = c + 1;
                    //    dTypeName = TimType + c.ToString();
                    //    this.getpointDatafromShp(shp, ds, TimType, dTypeName);
                    //    break;
                    case "circareasink":
                        cs = cs + 1;
                        dTypeName = TimType + cs.ToString();
                        this.getpointDatafromShp(shp, ds, TimType, dTypeName);
                        break;
                    case "polyareasink":
                        ps = ps + 1;
                        dTypeName = TimType + ps.ToString();
                        this.getpolySinkDatafromShp(shp, ds, TimType, dTypeName);
                        break;
                    case "polyinhom":
                        pi = pi + 1;
                        dTypeName = TimType + pi.ToString();
                        this.getInhomDatafromShp(shp, ds, TimType, dt, dTypeName);
                        break;
                    case "circinhom":
                        ci = ci + 1;
                        dTypeName = TimType + ci.ToString();
                        this.getInhomDatafromShp(shp, ds, TimType, dt, dTypeName);
                        break;
                    case "testpoint":
                        tp = tp + 1;
                        dTypeName = TimType + tp.ToString();
                        this.getpointDatafromShp(shp, ds, TimType, dTypeName);
                        break;
                }
            }



            //write each type of data into file
            
            StreamWriter sw = new StreamWriter(path+"\\"+TimFileName+".py");
            sw.WriteLine("import sys");
            sw.WriteLine("sys.path.append(r\"" + pythonPathName + "\")");
            sw.WriteLine("from TimML import *");
            this.writeModelData(TimFileName, ds, sw);
            int check = 0;
            bool isWell = false;
            bool testpoint = false;
            this.writeConstantData(TimFileName, ds, sw, "constant");
            int dtypeSize= ds.Tables.Count;
            for (int i = 0; i < dtypeSize; i++)
            {

                
                dTypeName = (string)ds.Tables[i].TableName.ToString();
                //int z = dTypeName.Length;
                //TimType = dTypeName.Substring(0, z - 1);
             
                    if (dTypeName.StartsWith("circsink"))
                        this.writeCircSinkData(TimFileName, ds, sw, dTypeName);

                    if (dTypeName.StartsWith("well"))
                    {
                        this.writeWellData(TimFileName, ds, sw, dTypeName);
                        isWell = true;
                    }
                    if (dTypeName.StartsWith("headlinesink"))
                        this.writeHeadlinesinkData(TimFileName, ds, sw, dTypeName);

                    if (dTypeName.StartsWith("flowlinesink"))
                        this.writeFlowlinesinkData(TimFileName, ds, sw, dTypeName);

                    if (dTypeName.StartsWith("reslinesink"))
                        this.writeReslinesinkData(TimFileName, ds, sw, dTypeName);

                    if (dTypeName.StartsWith("polyinhom"))
                    {
                        if (check == 0)
                            this.writePolyInhomData(TimFileName, ds, sw, dTypeName);
                        check = check + 1;
                    }
                    if (dTypeName.StartsWith("polyareasink"))
                    {
                        if (check == 0)
                            this.writePolyAreaSink(TimFileName, ds, sw, dTypeName);
                        check = check + 1;
                    }
                    if (dTypeName.StartsWith("testpoint"))
                        testpoint = true;
                       

                
            }
            sw.WriteLine(ModelName+".solve()");
            if(outputSig == "1")
                this.writeOutputContourData(xmin, ymin, nx,ny, dx, path, sw, naq, outputName);
            

            //if(isWell)
            //    this.writeWellReport(numwells, wellNames, path + "\\WellReport", sw);
            //if (testpoint)
            //    this.writeTestPoints(TimFileName, ds, sw, path, "testpoint");
            //sw.WriteLine("pcheck("+ModelName+"," + "'"+path + "')");
            sw.Close();

        }

        public void getModelData(string path, string xmlfilename, DataSet ds)
        {

            //DataTable modelData = Utilities.Read(path + "\\"+ dbfFilename + ".dbf");
         
            //modelData.WriteXml("xlData.xml");
            ////DataSet temp = modelData.DataSet;
            ////temp.Tables.Remove(modelData);
            //ModelName = modelData.Columns[0].ColumnName;
            
            DataSet tempds = new DataSet();
            tempds.ReadXml(path +"//"+xmlfilename);
            DataTable modelData = tempds.Tables["AquiferPropertyTable"];
            naq = Convert.ToInt16(modelData.Rows.Count);
            DataTable tempModelData = new DataTable();
            
             tempModelData =   modelData.Copy();
            
            ds.Tables.Add(tempModelData);

        }
        public void getColNames(DataTable dt)
        {
            for (int i = 0; i < dt.Columns.Count-1; i++)
            {
                if (dt.Columns[i].ColumnName.StartsWith("Top"))
                    tCol = "topElev";
                if (dt.Columns[i].ColumnName.StartsWith("Bottom"))
                    bCol = "botElev";
                if (dt.Columns[i].ColumnName.StartsWith("Horizontal"))
                    kCol = "permeabili";
                if (dt.Columns[i].ColumnName.StartsWith("Res"))
                    vkCol = "resistance";
                if (dt.Columns[i].ColumnName.StartsWith("Poro"))
                    nCol = "porosity";
                if (dt.Columns[i].ColumnName.StartsWith("Vert"))
                    vnCol = "porosityV";
            }
        }
        public void writeModelData(string timFileName, DataSet ds, StreamWriter sw)
        {
            // make bracketed datasets
            // writeline into python file

            DataTable modelData = ds.Tables["AquiferPropertyTable"];
            getColNames(modelData);
            int numLayers = Convert.ToInt32(modelData.Rows.Count);
            string permeability = "[";
            string botElev = "[";
            string topElev = "[";
            string resistance = "[";
            string porosity = "[";
            string llporosity = "[";
            int count = 0;

            

            for (int i = 0; i < numLayers; i++)
            {
                if (count != 0)
                    permeability = String.Concat(permeability, ",");
                permeability = String.Concat(permeability, modelData.Rows[i][3].ToString());
                if (count != 0)
                    botElev = String.Concat(botElev, ",");
                botElev = String.Concat(botElev, modelData.Rows[i][2].ToString());
                if (count != 0)
                    topElev = String.Concat(topElev, ",");
                topElev = String.Concat(topElev, modelData.Rows[i][1].ToString());
                if (count != 0)
                    porosity = String.Concat(porosity, ",");
                porosity = String.Concat(porosity, modelData.Rows[i][5].ToString());
                count = count + 1;
            }
            count = 0;
            for (int i = 0; i < (numLayers - 1); i++)
            {
                if (count != 0)
                    resistance = String.Concat(resistance, ",");
                resistance = String.Concat(resistance, modelData.Rows[i][4].ToString());
                if (count != 0)
                    llporosity = String.Concat(llporosity, ",");
                llporosity = String.Concat(llporosity, modelData.Rows[i][6].ToString());
                count = count + 1;
            }
            permeability = String.Concat(permeability, "]");
            botElev = String.Concat(botElev, "]");
            topElev = String.Concat(topElev, "]");
            resistance = String.Concat(resistance, "]");
            porosity = String.Concat(porosity, "]");
            llporosity = String.Concat(llporosity, "]");

            sw.WriteLine(ModelName + "=Model(" + numLayers + ","
                + permeability + ","
                + botElev + ","
                + topElev + ","
                + resistance + ",n="
                + porosity + ",nll="
                + llporosity + ")");
        }
        public void getlineDatafromShp(string shp, DataSet ds, string dataType, string dtName)
        {
            /////// not test for res and flow---- head works fine ///////

            //find head column number
            //find name column number
            //find number of layers and layer column numbers
            //get x,y data
            //place all data into datatable 
            //headLineSink[ x1,y1,x2,y2,head,layers[],name] = headLineSinks
            //flowLineSink[ x1,y1,x2,y2,sigma,layers[],name] = flowLineSinks
            //resLineSink[ x1,y1,x2,y2,head,res,width,layers[],name] = resLineSinks
            string shapeFile = Path.GetFileNameWithoutExtension(shp);
            string shapeFilePath = Path.GetDirectoryName(shp);
            ArcTables.GetTables gt = new ArcTables.GetTables();
            DataTable xyTable = gt.getCoordinates(shapeFile,shapeFilePath,"polyline"); // xyTable in shapefile
            DataTable attTable = gt.getAttributeTable(shapeFile, shapeFilePath); // attribute table in shapefile
            DataTable headLineSinkTable = new DataTable("headLineSinkTable");
            DataTable flowLineSinkTable = new DataTable("flowLineSinkTable");
            DataTable resLineSinkTable = new DataTable("resLineSinkTable");
            DataTable tempDataTable = new DataTable("tempDataTable");

            int szXY = xyTable.Rows.Count; // number of rows in xyTable
            int sz2XY = xyTable.Columns.Count; // number of columns in xyTable
            int szAT = attTable.Rows.Count;    // number of rows in attributeTable
            int sz2AT = attTable.Columns.Count; // number of columns in attributeTable
            int elementNum = Convert.ToInt32(xyTable.Rows[szXY-1][2]);

            int x1Num = 0;  // x1 column number 
            int y1Num = 0;  // y1 column number
            int x2Num = 0;  // x2 column number 
            int y2Num = 0;  // y2 column number
            int resNum = 0; // res column number
            int headNum = 0;  // head column number
            int sigmaNum = 0; // sigma column number
            int widthNum = 0; // width column number
            int nameNum = 0;  // name column number
            int botElevNum = 0; // botElev column number
            int numLayers = 0;  // layers column number
            int count = 0;      // counter
            int num = 0;
            ArrayList layerArray = new ArrayList(); // list of layers
            string attTablename = null;
            string xyTablename = null;

            DataRow r;
            tempDataTable.Columns.Add("ModelName", typeof(string)); //begin adding columns to tempDataTable
            tempDataTable.Columns.Add("x1", typeof(string));
            tempDataTable.Columns.Add("y1", typeof(string));
            tempDataTable.Columns.Add("x2", typeof(string));
            tempDataTable.Columns.Add("y2", typeof(string));
            if (dataType == "headlinesink" || dataType == "reslinesink")
                tempDataTable.Columns.Add("head", typeof(string));
            if (dataType == "flowlinesink")
                tempDataTable.Columns.Add("sigma", typeof(string));
            if (dataType == "reslinesink")
            {
                tempDataTable.Columns.Add("res", typeof(string));
                tempDataTable.Columns.Add("width", typeof(string));
                tempDataTable.Columns.Add("botElev", typeof(string));
            }
            for (int i = 0; i < sz2AT; i++)
            {
                attTablename = attTable.Columns[i].ColumnName;
                if (attTablename.StartsWith("layer") || attTablename.StartsWith("Layer")||attTablename.StartsWith("LAYER"))
                {
                    layerArray.Add(i);
                    numLayers = numLayers + 1;
                    tempDataTable.Columns.Add("Layer" + (numLayers), typeof(string));
                }
                if (attTablename.StartsWith("Sigma") || attTablename.StartsWith("sigma")||attTablename.StartsWith("SIGMA")) // get column nums 
                    sigmaNum = i;
                if (attTablename.StartsWith("Res" )|| attTablename.StartsWith("res" )|| attTablename.StartsWith("Res") || attTablename.StartsWith("RESISTANCE")||attTablename.StartsWith("RES"))
                    resNum = i;
                if (attTablename.StartsWith("Width")|| attTablename.StartsWith("width")|| attTablename.StartsWith("WIDTH"))
                    widthNum = i;
                if (attTablename.StartsWith("Head") || attTablename.StartsWith("head")|| attTablename.StartsWith("HEAD"))
                    headNum = i;
                if (attTablename.StartsWith("Name") || attTablename.StartsWith("name")|| attTablename.StartsWith("NAME"))
                    nameNum = i;    
                if (attTablename.StartsWith("Bottom") || attTablename.StartsWith("botElev") || attTablename.StartsWith("BotElev") || attTablename.StartsWith( "botelev")||attTablename.StartsWith("BOTELEV"))
                    botElevNum = i;
            }
            for (int i = 0; i < sz2XY; i++)
            {
                xyTablename = xyTable.Columns[i].ColumnName;
                if (xyTablename == "X1")
                    x1Num = i;
                if (xyTablename == "Y1")
                    y1Num = i;
                if (xyTablename == "X2")
                    x2Num = i;
                if (xyTablename == "Y2")
                    y2Num = i;
            }
            tempDataTable.Columns.Add("label", typeof(string));
            if (dataType == "reslinesink")
                num = 9;
            else num = 6;
            int nameLoc = num + numLayers;
            //int tempElementNum = 1;

                            

            for (int i = 0; i < szXY; i++)
            {
               
                
                //if (tempElementNum == Convert.ToInt32(xyTable.Rows[i][2])&& tempElementNum == Convert.ToInt32(xyTable.Rows[i+1][2]))
                //{
                    
                r = tempDataTable.NewRow();
                 r[0] = ModelName;
                
                r[1] = xyTable.Rows[i][x1Num].ToString(); //x1
                r[2] = xyTable.Rows[i][y1Num].ToString(); //x2
                r[3] = xyTable.Rows[i][x2Num].ToString(); //y1
                r[4] = xyTable.Rows[i][y2Num].ToString(); //y2
                //    r[1] = xyTable.Rows[i][xNum].ToString();      //x2
                //    r[3] = xyTable.Rows[i + 1][xNum].ToString();  //x1
                //    r[2] = xyTable.Rows[i][yNum].ToString();      //y2
                //    r[4] = xyTable.Rows[i + 1][yNum].ToString();  //y1
                if (dataType == "headlinesink" || dataType == "reslinesink")
                r[5] = attTable.Rows[i][headNum].ToString(); //head
                if (dataType == "flowlinesink")
                    r[5] = attTable.Rows[i][sigmaNum].ToString(); //sigma
                if (dataType == "reslinesink")
                {
                    r[6] = attTable.Rows[i][resNum].ToString(); //resistance
                    r[7] = attTable.Rows[i][widthNum].ToString(); //width
                    r[8] = attTable.Rows[i][botElevNum].ToString(); //bottom elevation
                }

                for (int j = 0; j < numLayers; j++)
                {
                    string number = attTable.Rows[i][(int)layerArray[j]].ToString();
                    if (number == Convert.ToString((j + 1)))
                    {
                        r[j + num] = number; //layer

                    }
                    else
                        r[j + num] = 0;
                }
                r[nameLoc] = attTable.Rows[i][nameNum].ToString(); //name

                count = count + 1;
                tempDataTable.Rows.Add(r);
                //}
                //else
                //{
                //    tempElementNum = tempElementNum + 1;
                //    //r = tempDataTable.NewRow();
                //    //r[0] = ModelName;
                //    //r[1] = xyTable.Rows[i][xNum].ToString();      //x2
                //    //r[3] = xyTable.Rows[i + 1][xNum].ToString();  //x1
                //    //r[2] = xyTable.Rows[i][yNum].ToString();      //y2
                //    //r[4] = xyTable.Rows[i + 1][yNum].ToString();  //y1
                //    //if (dataType == "headlinesink" || dataType == "reslinesink")
                //    //    r[5] = attTable.Rows[tempElementNum-1][headNum].ToString(); //head
                //    //if (dataType == "flowlinesink")
                //    //    r[5] = attTable.Rows[tempElementNum-1][sigmaNum].ToString(); //sigma
                //    //if (dataType == "reslinesink")
                //    //{
                //    //    r[6] = attTable.Rows[tempElementNum-1][resNum].ToString(); //resistance
                //    //    r[7] = attTable.Rows[tempElementNum-1][widthNum].ToString(); //width
                //    //    r[8] = attTable.Rows[tempElementNum-1][botElevNum].ToString(); //bottom elevation
                //    //}

                //    //for (int j = 0; j < numLayers; j++)
                //    //{
                //    //    string number = attTable.Rows[tempElementNum-1][(int)layerArray[j]].ToString();
                //    //    if (number == Convert.ToString((j + 1)))
                //    //    {
                //    //        r[j + num] = number; //layer

                //    //    }
                //    //    else
                //    //        r[j + num] = 0;
                //    //}
                //    //r[nameLoc] = attTable.Rows[tempElementNum-1][nameNum].ToString(); //name

                //    //count = count + 1;
                //    //tempDataTable.Rows.Add(r);
                //    GC.Collect();
                //}
                    

            }
            if (dataType == "flowlinesink")
            {
                tempDataTable.TableName = dtName;
                flowLineSinkTable = tempDataTable;
                ds.Tables.Add(flowLineSinkTable);
            }
            if (dataType == "headlinesink")
            {
                tempDataTable.TableName = dtName;
                headLineSinkTable = tempDataTable;
                ds.Tables.Add(headLineSinkTable);
            }
            if (dataType == "reslinesink")
            {
                tempDataTable.TableName = dtName;
                resLineSinkTable = tempDataTable;
                ds.Tables.Add(resLineSinkTable);
            }
           // xyTable.DataSet.WriteXml("xyline.xml");
            ds.WriteXml("data.xml");
        }
        public void getpointDatafromShp(string shp, DataSet ds, string dataType, string dtName)
        {
            //find flow column number
            //find radius number
            //find name column number
            //find number of layers and layer column numbers
            //get x,y data
            //place all data into datatable [x,y,flow,radius,layers[],name]
            // place dataTable into dataSet dTableName = wellTable
            DataTable constantTable = new DataTable("constantTable");
            DataTable circSinkTable = new DataTable("circSinkTable");
            DataTable wellTable = new DataTable("wellTable");
            DataTable testPoints = new DataTable("testPoints");
            DataTable tempTable = new DataTable("temp");
            string shapeFilePath = Path.GetDirectoryName(shp);
            string shapeFile = Path.GetFileNameWithoutExtension(shp);
            ArcTables.GetTables gt = new ArcTables.GetTables();
            DataTable xyTable = gt.getCoordinates(shapeFile,shapeFilePath,"point");
            DataTable attTable = gt.getAttributeTable(shapeFile,shapeFilePath);

            int szXY = xyTable.Rows.Count;
            int sz2XY = xyTable.Columns.Count;
            int szAT = attTable.Rows.Count;
            int sz2AT = attTable.Columns.Count;

            string xyTablename = null;
            int xNum = 0;
            int yNum = 0;
            int headNum = 0;
            int nameNum = 0;
            int numLayers = 0;
            int radNum = 0;
            int inNum = 0;
            int dischargeNum = 0;
            ArrayList layerArray = new ArrayList();
            string attTablename = null;
            int count = 0;
            DataRow r;
            tempTable.Columns.Add("ModelName", typeof(string));
            tempTable.Columns.Add("x", typeof(string));
            tempTable.Columns.Add("y", typeof(string));
            if (dataType == "well")
            {
                tempTable.Columns.Add("Discharge", typeof(string));
                tempTable.Columns.Add("Radius", typeof(string));
            }
            if (dataType == "constant"||dataType == "testpoint")
            {
                tempTable.Columns.Add("Head", typeof(string));
            }
            if (dataType == "circareasink")
            {
                tempTable.Columns.Add("Radius", typeof(string));
                tempTable.Columns.Add("Infil", typeof(string));
            }

            for (int i = 0; i < sz2AT; i++)
            {
                attTablename = attTable.Columns[i].ColumnName;
                if (attTablename.StartsWith("layer") || attTablename.StartsWith("Layer"))
                {
                    layerArray.Add(i);
                    numLayers = numLayers + 1;
                    tempTable.Columns.Add("Layer" + (numLayers), typeof(string));
                }
                if (attTablename == "Discharge" || attTablename == "discharge")
                    dischargeNum = i;
                if (attTablename == "Infil" || attTablename == "infil")
                    inNum = i;
                if (attTablename == "head" || attTablename == "Head")
                    headNum = i;
                if (attTablename == "Name" || attTablename == "name")
                    nameNum = i;
                if (attTablename == "Radius" || attTablename == "radius")
                    radNum = i;
            }

            for (int i = 0; i < sz2XY; i++)
            {
                xyTablename = xyTable.Columns[i].ColumnName;
                if (xyTablename == "X")
                    xNum = i;
                if (xyTablename == "Y")
                    yNum = i;
            }
            tempTable.Columns.Add("label", typeof(string));
            int n = 4;
            if (dataType == "well" || dataType == "circsink")
                n = n + 1;
            int nameLoc = n + numLayers;
            for (int i = 0; i < szXY; i = i + 1)
            {
                r = tempTable.NewRow();
                r[0] = ModelName;
                r[1] = xyTable.Rows[i][xNum].ToString();      //x

                r[2] = xyTable.Rows[i][yNum].ToString();      //y
                if (dataType == "well")
                {
                    r[3] = attTable.Rows[count][dischargeNum].ToString(); //discharge
                    r[4] = attTable.Rows[count][radNum].ToString(); //radius
                }
                if (dataType == "constant"||dataType =="testpoint")
                    r[3] = attTable.Rows[count][headNum].ToString();
                if (dataType == "circsink")
                {
                    r[3] = attTable.Rows[count][radNum].ToString();
                    r[4] = attTable.Rows[count][inNum].ToString();
                }
                for (int j = 0; j < numLayers; j++)
                {
                    string num = attTable.Rows[count][(int)layerArray[j]].ToString();
                    if (num == Convert.ToString((j + 1)))
                    {
                        r[j + n] = num; //layer

                    }
                    else
                        r[j + n] = 0;
                }
                r[nameLoc] = attTable.Rows[count][nameNum].ToString(); //name

                count = count + 1;
                tempTable.Rows.Add(r);
            }
            if (dataType == "well")
            {
                tempTable.TableName = dtName;
                wellTable = tempTable;
                ds.Tables.Add(wellTable);
            }
            if (dataType == "constant")
            {
                tempTable.TableName = dtName;
                constantTable = tempTable;
                ds.Tables.Add(constantTable);
            }
            if (dataType == "testpoint")
            {
                tempTable.TableName = "testpoint";
                constantTable = tempTable;
                ds.Tables.Add(constantTable);
            }
            if (dataType == "circsink")
            {
                tempTable.TableName = dtName;
                circSinkTable = tempTable;
                ds.Tables.Add(circSinkTable);
            }
            //xyTable.DataSet.WriteXml("xyline.xml");
            ds.WriteXml("data.xml");




        }
        public void getpolySinkDatafromShp(string shp, DataSet ds, string dataType, string dtName)
        {
            //find flow column number
            //find radius number
            //find name column number
            //find number of layers and layer column numbers
            //get x,y data
            //place all data into datatable [x,y,flow,radius,layers[],name]

            DataTable polySinkTable = new DataTable("polySinkTable");
            DataTable tempTable = new DataTable("temp");
            string shapeFilePath = Path.GetDirectoryName(shp);
            string shapeFile = Path.GetFileNameWithoutExtension(shp);
            ArcTables.GetTables gt = new ArcTables.GetTables();
            DataTable xyTable = gt.getCoordinates(shapeFile,shapeFilePath,"point");
            DataTable attTable = gt.getAttributeTable(shapeFile, shapeFilePath);

            int szXY = xyTable.Rows.Count;
            int sz2XY = xyTable.Columns.Count;
            int szAT = attTable.Rows.Count;
            int sz2AT = attTable.Columns.Count;

            string xyTablename = null;
            int xNum = 0;
            int yNum = 0;
            int nameNum = 0;
            int inNum = 0;
            int count = 0;
            int numberOfPoints = 0;
            string attTablename = null;


            DataRow r;
            tempTable.Columns.Add("ModelName", typeof(string)); //0
            tempTable.Columns.Add("elementName", typeof(string)); //1
            tempTable.Columns.Add("pointNum", typeof(string)); //2
            tempTable.Columns.Add("x", typeof(string)); //3
            tempTable.Columns.Add("y", typeof(string)); //4
            tempTable.Columns.Add("Infil", typeof(string)); //5
            tempTable.Columns.Add("label", typeof(string)); //6

            for (int i = 0; i < sz2AT; i++)
            {
                attTablename = attTable.Columns[i].ColumnName;

                if (attTablename == "Infil" || attTablename == "infil")
                    inNum = i;
                if (attTablename == "Name" || attTablename == "name")
                    nameNum = i;
            }

            for (int i = 0; i < sz2XY; i++)
            {
                xyTablename = xyTable.Columns[i].ColumnName;
                if (xyTablename == "X")
                    xNum = i;
                if (xyTablename == "Y")
                    yNum = i;
            }

            numberOfPoints = szXY / szAT - 1;

            for (int j = 0; j < szAT; j++)
            {

                for (int i = count; i < numberOfPoints; i++)
                {

                    r = tempTable.NewRow();
                    r[0] = ModelName;
                    r[1] = j;
                    r[2] = i;
                    r[3] = xyTable.Rows[i][xNum].ToString();
                    r[4] = xyTable.Rows[i][yNum].ToString();
                    r[5] = attTable.Rows[j][inNum].ToString();
                    r[6] = attTable.Rows[j][nameNum].ToString();
                    tempTable.Rows.Add(r);
                    count = count + 1;
                }
                count = count + 1;
            }

            tempTable.TableName = dtName;
            polySinkTable = tempTable;
            ds.Tables.Add(polySinkTable);


            xyTable.DataSet.WriteXml("xylinePoly.xml");
            ds.WriteXml("data.xml");
        }
        public void getInhomDatafromShp(string shp, DataSet ds, string dataType, DataTable dt, string dtName)
        {
            //find flow column number
            //find radius number
            //find name column number
            //find number of layers and layer column numbers
            //get x,y data
            //place all data into datatable [x,y,flow,radius,layers[],name]

            DataTable polyinhomTable;
            DataTable circinhomTable;
            ArcTables.GetTables gt = new ArcTables.GetTables();
            string shapeFile = Path.GetFileName(shp);
            string shapeFilePath = Path.GetDirectoryName(shp);
            DataTable tempTable = new DataTable();
            if (dataType == "polyinhom")
            {
                if (ds.Tables.Contains("polyinhom"))
                {
                    tempTable = ds.Tables["polyinhom"];
                }
                else
                {
                    polyinhomTable = new DataTable("polyinhom");
                    tempTable = new DataTable("temp");
                }
            }
            if (dataType == "circinhom")
            {
                if (ds.Tables.Contains("circinhom"))
                {
                    tempTable = ds.Tables["circinhom"];
                }
                else
                {
                    circinhomTable = new DataTable("circinhom");
                    tempTable = new DataTable("temp");
                }
            }
            string tablename = dt.TableName;
            DataTable xyTable = gt.getCoordinates(shapeFile,shapeFilePath,"point");
            DataTable attTable = gt.getAttributeTable(shapeFile,shapeFilePath);

            int szAtt = attTable.Rows.Count;
            int sz2Att = attTable.Columns.Count;
            int szXY = xyTable.Rows.Count;
            int sz2XY = xyTable.Columns.Count;

            string xyTablename = null;
            string attTablename = null;
            int tableNum = 0;
            int xNum = 0;
            int yNum = 0;
            int colNum = 0;
            int elementNum = 0;
            int FIDNum = 0;
            int radnum = 0;
            int[] numberOfPoints = new int[szAtt];
            DataRow r;
            if (dataType == "polyinhom")
            {
                if (!ds.Tables.Contains("polyinhom"))
                {
                    tempTable.Columns.Add("ModelName", typeof(string));
                    tempTable.Columns.Add("elementName", typeof(string));
                    tempTable.Columns.Add("pointNum", typeof(string));
                    tempTable.Columns.Add("x", typeof(string));
                    tempTable.Columns.Add("y", typeof(string));
                    tempTable.Columns.Add("label", typeof(string));
                }
            }
            if (dataType == "circinhom")
            {
                if (!ds.Tables.Contains("circinhom"))
                {
                    tempTable.Columns.Add("ModelName", typeof(string));
                    tempTable.Columns.Add("elementName", typeof(string));
                    tempTable.Columns.Add("pointNum", typeof(string));
                    tempTable.Columns.Add("x", typeof(string));
                    tempTable.Columns.Add("y", typeof(string));
                    tempTable.Columns.Add("Radius", typeof(string));
                    tempTable.Columns.Add("label", typeof(string));
                }
            }
            for (int i = 0; i < sz2XY; i++)
            {
                xyTablename = xyTable.Columns[i].ColumnName;
                if (xyTablename == "X")
                    xNum = i;
                if (xyTablename == "Y")
                    yNum = i;
                if (xyTablename == "ShapeNumber")
                    colNum = i;
            }
            for (int i = 0; i < sz2Att; i++)
            {
                attTablename = attTable.Columns[i].ColumnName;
                if (attTablename == "TableName")
                    tableNum = i;
                if (attTablename == "FID")
                    FIDNum = i;
            }
            for (int i = 0; i < szAtt; i++)
            {
                if (tablename == attTable.Rows[i][tableNum].ToString())
                    elementNum = Convert.ToInt32(attTable.Rows[i][FIDNum].ToString()) + 1;
            }

            int t = 0;
            for (int i = 0; i < szXY; i++)
            {
                if (Convert.ToInt32(xyTable.Rows[i][colNum].ToString()) == elementNum)
                {
                    t = t + 1;
                    r = tempTable.NewRow();
                    r[0] = ModelName;
                    r[1] = tablename;
                    r[2] = t;
                    if (dataType == "polyinhom")
                    {
                        r[3] = xyTable.Rows[i][xNum].ToString();
                        r[4] = xyTable.Rows[i][yNum].ToString();
                    }
                    if (dataType == "circinhom")
                    {
                        r[3] = xyTable.Rows[i][xNum].ToString();
                        r[4] = xyTable.Rows[i][yNum].ToString();
                        r[5] = attTable.Rows[elementNum - 1][radnum].ToString();
                    }
                    tempTable.Rows.Add(r);
                }
            }
            if (dataType == "polyinhom")
            {
                tempTable.TableName = "polyinhom";
                polyinhomTable = tempTable;
                if (ds.Tables.Contains("polyinhom"))
                    tempTable.DataSet.Tables.Remove("polyinhom");
                ds.Tables.Add(polyinhomTable);
                dt.DataSet.Tables.Remove(dt);
                ds.Tables.Add(dt);
            }
            if (dataType == "circinhom")
            {
                tempTable.TableName = dtName;
                circinhomTable = tempTable;
                if (ds.Tables.Contains("circinhom"))
                    tempTable.DataSet.Tables.Remove("circinhom");
                ds.Tables.Add(circinhomTable);
                dt.DataSet.Tables.Remove(dt);
                ds.Tables.Add(dt);
            }
            xyTable.DataSet.WriteXml("xyinhom.xml");
            ds.WriteXml("data.xml");
        }

        public void writeHeadlinesinkData(string timFileName, DataSet ds, StreamWriter sw, string dtName)
        {
            //form of headlinesinkFile
            // HeadLineSink(modelParent,x1,y1,x2,y2,head,layers[],label="")


            DataTable headlinesinkTable = ds.Tables[dtName];
            int sinkNum = headlinesinkTable.Rows.Count;
            int sinkColNum = headlinesinkTable.Columns.Count;
            int x1num = 0;
            int x2num = 0;
            int y1num = 0;
            int y2num = 0;
            int headnum = 0;
            int modelparentnum = 0;
            int namenum = 0;
            int layerCount = 0;
            string layerArray = null;
            for (int j = 0; j < sinkNum; j++)
            {
                layerCount = 0;
                layerArray = "[";
                for (int i = 0; i < sinkColNum; i++)
                {

                    if (headlinesinkTable.Columns[i].ToString() == "x1")
                        x1num = i;
                    if (headlinesinkTable.Columns[i].ToString() == "x2")
                        x2num = i;
                    if (headlinesinkTable.Columns[i].ToString() == "y1")
                        y1num = i;
                    if (headlinesinkTable.Columns[i].ToString() == "y2")
                        y2num = i;
                    if (headlinesinkTable.Columns[i].ToString() == "head")
                        headnum = i;
                    if (headlinesinkTable.Columns[i].ToString() == "Model")
                        modelparentnum = i;
                    if (headlinesinkTable.Columns[i].ToString() == "label")
                        namenum = i;

                    if (headlinesinkTable.Columns[i].ColumnName.StartsWith("Layer") || headlinesinkTable.Columns[i].ColumnName.StartsWith("layer"))
                    {
                        if (layerCount != 0 && headlinesinkTable.Rows[j][i].ToString() != "0" && headlinesinkTable.Rows[j][i - 1].ToString() != "0")
                            layerArray = String.Concat(layerArray, ",");
                        layerCount = layerCount + 1;
                        if (headlinesinkTable.Rows[j][i].ToString() != "0")
                            layerArray = String.Concat(layerArray, headlinesinkTable.Rows[j][i].ToString());
                    }
                }

                layerArray = String.Concat(layerArray, "]");
                Console.WriteLine(layerArray);

                sw.WriteLine("HeadLineSink(" + headlinesinkTable.Rows[j][modelparentnum].ToString() + ", " +
                    headlinesinkTable.Rows[j][x1num].ToString() + ", " +
                    headlinesinkTable.Rows[j][y1num].ToString() + ", " +
                    headlinesinkTable.Rows[j][x2num].ToString() + ", " +
                    headlinesinkTable.Rows[j][y2num].ToString() + ", " +
                    headlinesinkTable.Rows[j][headnum].ToString() + ", " +
                    layerArray + ", label =\"" +
                    headlinesinkTable.Rows[j][namenum].ToString() + "\")");
            }


        }
        public void writeFlowlinesinkData(string timFileName, DataSet ds, StreamWriter sw, string dtName)
        {
            //form of headlinesinkFile
            // FlowLineSink(modelParent,x1,y1,x2,y2,sigma,layers[],label="")

            DataTable flowlinesinkTable = ds.Tables[dtName];
            int sinkNum = flowlinesinkTable.Rows.Count;
            int sinkColNum = flowlinesinkTable.Columns.Count;
            int x1num = 0;
            int x2num = 0;
            int y1num = 0;
            int y2num = 0;
            int sigmanum = 0;
            int modelparentnum = 0;
            int namenum = 0;
            int layerCount = 0;
            string layerArray = null;
            for (int j = 0; j < sinkNum; j++)
            {
                layerCount = 0;
                layerArray = "[";
                for (int i = 0; i < sinkColNum; i++)
                {

                    if (flowlinesinkTable.Columns[i].ToString() == "x1" || flowlinesinkTable.Columns[i].ToString() == "X1")
                        x1num = i;
                    if (flowlinesinkTable.Columns[i].ToString() == "x2" || flowlinesinkTable.Columns[i].ToString() == "X2")
                        x2num = i;
                    if (flowlinesinkTable.Columns[i].ToString() == "y1" || flowlinesinkTable.Columns[i].ToString() == "Y1")
                        y1num = i;
                    if (flowlinesinkTable.Columns[i].ToString() == "y2" || flowlinesinkTable.Columns[i].ToString() == "Y2")
                        y2num = i;
                    if (flowlinesinkTable.Columns[i].ToString() == "sigma" || flowlinesinkTable.Columns[i].ToString() == "sigma")
                        sigmanum = i;
                    if (flowlinesinkTable.Columns[i].ToString() == "Model")
                        modelparentnum = i;
                    if (flowlinesinkTable.Columns[i].ToString() == "label" || flowlinesinkTable.Columns[i].ToString() == "Label")
                        namenum = i;

                    if (flowlinesinkTable.Columns[i].ColumnName.StartsWith("Layer") || flowlinesinkTable.Columns[i].ColumnName.StartsWith("layer"))
                    {
                        if (layerCount != 0 && flowlinesinkTable.Rows[j][i].ToString() != "0" && flowlinesinkTable.Rows[j][i - 1].ToString() != "0")
                            layerArray = String.Concat(layerArray, ",");
                        layerCount = layerCount + 1;
                        if (flowlinesinkTable.Rows[j][i].ToString() != "0")
                            layerArray = String.Concat(layerArray, flowlinesinkTable.Rows[j][i].ToString());
                    }
                }

                layerArray = String.Concat(layerArray, "]");
                Console.WriteLine(layerArray);

                sw.WriteLine("LineSink(" + flowlinesinkTable.Rows[j][modelparentnum].ToString() + ", " +
                    flowlinesinkTable.Rows[j][x1num].ToString() + ", " +
                    flowlinesinkTable.Rows[j][y1num].ToString() + ", " +
                    flowlinesinkTable.Rows[j][x2num].ToString() + ", " +
                    flowlinesinkTable.Rows[j][y2num].ToString() + ", " +
                    flowlinesinkTable.Rows[j][sigmanum].ToString() + ", " +
                    layerArray + ", label =\"" +
                    flowlinesinkTable.Rows[j][namenum].ToString() + "\")");
            }


        }
        public void writeReslinesinkData(string timFileName, DataSet ds, StreamWriter sw, string dtName)
        {
            //form of headlinesinkFile
            // FlowLineSink(modelParent,x1,y1,x2,y2,sigma,layers[],label="")

            DataTable reslinesinkTable = ds.Tables[dtName];
            int sinkNum = reslinesinkTable.Rows.Count;
            int sinkColNum = reslinesinkTable.Columns.Count;
            int x1num = 0;
            int x2num = 0;
            int y1num = 0;
            int y2num = 0;
            int headnum = 0;
            int resnum = 0;
            int widthnum = 0;
            int modelparentnum = 0;
            int namenum = 0;
            int layerCount = 0;
            int botElevNum =0;
            string layerArray = null;
            for (int j = 0; j < sinkNum; j++)
            {
                layerCount = 0;
                layerArray = "[";
                for (int i = 0; i < sinkColNum; i++)
                {

                    if (reslinesinkTable.Columns[i].ToString() == "x1")
                        x1num = i;
                    if (reslinesinkTable.Columns[i].ToString() == "x2")
                        x2num = i;
                    if (reslinesinkTable.Columns[i].ToString() == "y1")
                        y1num = i;
                    if (reslinesinkTable.Columns[i].ToString() == "y2")
                        y2num = i;
                    if (reslinesinkTable.Columns[i].ToString() == "head")
                        headnum = i;
                    if (reslinesinkTable.Columns[i].ToString() == "res")
                        resnum = i;
                    if (reslinesinkTable.Columns[i].ToString() == "width")
                        widthnum = i;
                    if (reslinesinkTable.Columns[i].ToString() == "Model")
                        modelparentnum = i;
                    if (reslinesinkTable.Columns[i].ToString() == "label")
                        namenum = i;
                    if (reslinesinkTable.Columns[i].ToString() == "botElev")
                        botElevNum = i;

                    if (reslinesinkTable.Columns[i].ColumnName.StartsWith("Layer") || reslinesinkTable.Columns[i].ColumnName.StartsWith("layer"))
                    {
                        if (layerCount != 0 && reslinesinkTable.Rows[j][i].ToString() != "0" && reslinesinkTable.Rows[j][i - 1].ToString() != "0")
                            layerArray = String.Concat(layerArray, ",");
                        layerCount = layerCount + 1;
                        if (reslinesinkTable.Rows[j][i].ToString() != "0")
                            layerArray = String.Concat(layerArray, reslinesinkTable.Rows[j][i].ToString());
                    }
                }

                layerArray = String.Concat(layerArray, "]");
                Console.WriteLine(layerArray);

                sw.WriteLine("ResLineSink(" + reslinesinkTable.Rows[j][modelparentnum].ToString() + ", " +
                    reslinesinkTable.Rows[j][x1num].ToString() + ", " +
                    reslinesinkTable.Rows[j][y1num].ToString() + ", " +
                    reslinesinkTable.Rows[j][x2num].ToString() + ", " +
                    reslinesinkTable.Rows[j][y2num].ToString() + ", " +
                    reslinesinkTable.Rows[j][headnum].ToString() + ", " +
                    reslinesinkTable.Rows[j][resnum].ToString() + ", " +
                    reslinesinkTable.Rows[j][widthnum].ToString() + ", " +
                    layerArray + ", label =\"" +
                    reslinesinkTable.Rows[j][namenum].ToString() + "\", bottomelev=" + 
                    reslinesinkTable.Rows[j][botElevNum].ToString() + ")");
            }


        }


        public void writeWellData(string timFileName, DataSet ds, StreamWriter sw, string dtName)
        {
            DataTable wellTable = ds.Tables[dtName];
            int sinkNum = wellTable.Rows.Count;
            int sinkColNum = wellTable.Columns.Count;
            int xnum = 0;
            int ynum = 0;
            int flownum = 0;
            int radnum = 0;
            int modelparentnum = 0;
            int namenum = 0;
            int layerCount = 0;
            string layerArray = null;
            wellNames = "[";
            for (int j = 0; j < sinkNum; j++)
            {
                layerCount = 0;
                layerArray = "[";
                for (int i = 0; i < sinkColNum; i++)
                {

                    if (wellTable.Columns[i].ToString() == "x" || wellTable.Columns[i].ToString() == "X")
                        xnum = i;
                    if (wellTable.Columns[i].ToString() == "y" || wellTable.Columns[i].ToString() == "Y")
                        ynum = i;
                    if (wellTable.Columns[i].ToString() == "Discharge" || wellTable.Columns[i].ToString() == "discharge")
                        flownum = i;
                    if (wellTable.Columns[i].ToString() == "Model")
                        modelparentnum = i;
                    if (wellTable.Columns[i].ToString() == "Radius" || wellTable.Columns[i].ToString() == "radius")
                        radnum = i;
                    if (wellTable.Columns[i].ToString() == "label" || wellTable.Columns[i].ToString() == "Label")
                        namenum = i;

                    if (wellTable.Columns[i].ColumnName.StartsWith("Layer") || wellTable.Columns[i].ColumnName.StartsWith("layer"))
                    {
                        if (layerCount != 0 && wellTable.Rows[j][i].ToString() != "0" && wellTable.Rows[j][i - 1].ToString() != "0")
                            layerArray = String.Concat(layerArray, ",");
                        layerCount = layerCount + 1;
                        if (wellTable.Rows[j][i].ToString() != "0")
                            layerArray = String.Concat(layerArray, wellTable.Rows[j][i].ToString());
                    }
                }

                layerArray = String.Concat(layerArray, "]");
                Console.WriteLine(layerArray);
                wellNames = String.Concat(wellNames, "w" + j);
                if (j != sinkNum-1)
                    wellNames = String.Concat(wellNames, ",");
                sw.WriteLine("w" + j + "=Well(" + wellTable.Rows[j][modelparentnum].ToString() + ", " +
                    wellTable.Rows[j][xnum].ToString() + ", " +
                    wellTable.Rows[j][ynum].ToString() + ", " +
                    wellTable.Rows[j][flownum].ToString() + ", " +
                    wellTable.Rows[j][radnum].ToString() + ", " +
                    layerArray + ", label =\"" +
                    wellTable.Rows[j][namenum].ToString() + "\")");
            }
            wellNames = String.Concat(wellNames, "]");
            numwells = sinkNum;
        }
        public void writeConstantData(string timFileName, DataSet ds, StreamWriter sw, string dtName)
        {
            DataTable constantTable = ds.Tables[dtName];
            int sinkNum = constantTable.Rows.Count;
            int sinkColNum = constantTable.Columns.Count;
            int xnum = 0;
            int ynum = 0;
            int headnum = 0;
            int modelparentnum = 0;
            int namenum = 0;
            int layerCount = 0;
            string layerArray = null;
            for (int j = 0; j < sinkNum; j++)
            {
                layerCount = 0;
                layerArray = "[";
                for (int i = 0; i < sinkColNum; i++)
                {

                    if (constantTable.Columns[i].ToString() == "x")
                        xnum = i;
                    if (constantTable.Columns[i].ToString() == "y")
                        ynum = i;
                    if (constantTable.Columns[i].ToString() == "Head")
                        headnum = i;
                    if (constantTable.Columns[i].ToString() == "Model")
                        modelparentnum = i;
                    if (constantTable.Columns[i].ToString() == "label" || constantTable.Columns[i].ToString() == "Label")
                        namenum = i;

                    if (constantTable.Columns[i].ColumnName.StartsWith("Layer") || constantTable.Columns[i].ColumnName.StartsWith("layer"))
                    {
                        if (layerCount != 0 && constantTable.Rows[j][i].ToString() != "0" && constantTable.Rows[j][i - 1].ToString() != "0")
                            layerArray = String.Concat(layerArray, ",");
                        layerCount = layerCount + 1;
                        if (constantTable.Rows[j][i].ToString() != "0")
                            layerArray = String.Concat(layerArray, constantTable.Rows[j][i].ToString());
                    }
                }

                layerArray = String.Concat(layerArray, "]");
                Console.WriteLine(layerArray);

                sw.WriteLine("rf=Constant(" + constantTable.Rows[j][modelparentnum].ToString() + ", " +
                    constantTable.Rows[j][xnum].ToString() + ", " +
                    constantTable.Rows[j][ynum].ToString() + ", " +
                    constantTable.Rows[j][headnum].ToString() + ", " +
                    layerArray + ", label =\"" +
                    constantTable.Rows[j][namenum].ToString() + "\")");
            }


        }
        public void writeCircSinkData(string timFileName, DataSet ds, StreamWriter sw, string dtName)
        {
            DataTable circSinkTable = ds.Tables[dtName];
            int sinkNum = circSinkTable.Rows.Count;
            int sinkColNum = circSinkTable.Columns.Count;
            int xnum = 0;
            int ynum = 0;
            int innum = 0;
            int radnum = 0;
            int modelparentnum = 0;
            int namenum = 0;
            int layerCount = 0;
            string layerArray = null;
            for (int j = 0; j < sinkNum; j++)
            {
                layerCount = 0;
                layerArray = "[";
                for (int i = 0; i < sinkColNum; i++)
                {

                    if (circSinkTable.Columns[i].ToString() == "x" || circSinkTable.Columns[i].ToString() == "X")
                        xnum = i;
                    if (circSinkTable.Columns[i].ToString() == "y" || circSinkTable.Columns[i].ToString() == "Y")
                        ynum = i;
                    if (circSinkTable.Columns[i].ToString() == "Infil" || circSinkTable.Columns[i].ToString() == "infil")
                        innum = i;
                    if (circSinkTable.Columns[i].ToString() == "Model")
                        modelparentnum = i;
                    if (circSinkTable.Columns[i].ToString() == "Radius" || circSinkTable.Columns[i].ToString() == "radius")
                        radnum = i;
                    if (circSinkTable.Columns[i].ToString() == "label" || circSinkTable.Columns[i].ToString() == "Label")
                        namenum = i;

                    if (circSinkTable.Columns[i].ColumnName.StartsWith("Layer") || circSinkTable.Columns[i].ColumnName.StartsWith("layer"))
                    {
                        if (layerCount != 0 && circSinkTable.Rows[j][i].ToString() != "0" && circSinkTable.Rows[j][i - 1].ToString() != "0")
                            layerArray = String.Concat(layerArray, ",");
                        layerCount = layerCount + 1;
                        if (circSinkTable.Rows[j][i].ToString() != "0")
                            layerArray = String.Concat(layerArray, circSinkTable.Rows[j][i].ToString());
                    }
                }

                layerArray = String.Concat(layerArray, "]");
                Console.WriteLine(layerArray);

                sw.WriteLine("p" + j + "=CircAreaSink(" + circSinkTable.Rows[j][modelparentnum].ToString() + ", " +
                    circSinkTable.Rows[j][xnum].ToString() + ", " +
                    circSinkTable.Rows[j][ynum].ToString() + ", " +
                    circSinkTable.Rows[j][radnum].ToString() + ", " +
                    circSinkTable.Rows[j][innum].ToString() + ", " +
                    layerArray + ", label =\"" +
                    circSinkTable.Rows[j][namenum].ToString() + "\")");

            }
        }

        public void writePolyInhomData(string timFileName, DataSet ds, StreamWriter sw, string dtName)
        {
            //form of headlinesinkFile
            // FlowLineSink(modelParent,x1,y1,x2,y2,sigma,layers[],label="")

            DataTable tempTablepoly = new DataTable();

            int inhomCol;
            int inhomRow;
            //string colName = null;
            int t = 0;
            int count = 1;
            string naq = null;
            string k = null;
            string zb = null;
            string zt = null;
            string c = null;
            string xylist = null;
            string n = null;
            string nll = null;
            int dtableRow = 0;
            string tableName = null;

            ArrayList ElementNum = new ArrayList();

            if (ds.Tables.Contains(dtName))
            {
                tempTablepoly = ds.Tables[dtName];

            }
            inhomCol = tempTablepoly.Columns.Count;
            inhomRow = tempTablepoly.Rows.Count;
            for (int i = 0; i < inhomRow; i++)
            {
                if (tempTablepoly.Rows[i]["elementName"].ToString().EndsWith(Convert.ToString(count)))
                {
                    t = t + 1;
                }
                if (!tempTablepoly.Rows[i]["elementName"].ToString().EndsWith(Convert.ToString(count)))
                {
                    ElementNum.Add(t);
                    count = count + 1;
                    t = 0;
                }
            }
            ElementNum.Add(t+1);
            DataTable dtable = new DataTable();
            int NumOfElements = ElementNum.Count;
            for (int j = 0; j < NumOfElements; j++)
            {
                int startnum;
                int endnum;
                xylist = "[";
                int num = (int)ElementNum[j];
                if (j == 0)
                {
                    startnum = 0;
                    endnum = (int)ElementNum[j];
                }
                else
                {
                    startnum = num - 1;
                    endnum = startnum + (int)ElementNum[j];
                }
                for (int y = startnum; y < endnum; y++)
                {
                    string xytemp = "(" + tempTablepoly.Rows[y]["x"].ToString() + "," + tempTablepoly.Rows[y]["y"].ToString() + ")";
                    xylist = String.Concat(xylist, xytemp);
                    if (y != (endnum - 1))
                        xylist = String.Concat(xylist, ",");
                }
                xylist = String.Concat(xylist, "]");

                    tableName = tempTablepoly.Rows[j+(int)ElementNum[j]-1]["elementName"].ToString();
                    dtable = ds.Tables[tableName];
                    dtableRow = dtable.Rows.Count;
                    naq = Convert.ToString(dtableRow);
                    k   = "[";
                    zb  = "[";
                    zt  = "[";
                    c   = "[";
                    n   = "[";
                    nll = "[";
                    for (int i = 0; i < dtableRow; i++)
                    {
                        k = String.Concat(k, dtable.Rows[i]["permeabili"].ToString());
                        if (i!=(dtableRow-1))
                            k = String.Concat(k, ",");
                        zb = String.Concat(zb, dtable.Rows[i]["botElev"].ToString());
                        if (i != (dtableRow - 1))
                            zb = String.Concat(zb, ",");
                        zt = String.Concat(zt, dtable.Rows[i]["topElev"].ToString());
                        if (i != (dtableRow - 1))
                            zt = String.Concat(zt, ",");
                        if (i != (dtableRow - 1))
                        {
                            c = String.Concat(c, dtable.Rows[i]["resistance"].ToString());
                            if (i != (dtableRow - 2))
                                c = String.Concat(c, ",");
                        }
                        n = String.Concat(n, dtable.Rows[i]["porosity"].ToString());
                        if (i != (dtableRow - 1))
                            n = String.Concat(n, ",");
                        if (i != (dtableRow - 1))
                        {
                            nll = String.Concat(nll, dtable.Rows[i]["porosityll"].ToString());
                            if (i != (dtableRow - 2))
                                nll = String.Concat(nll, ",");
                        }

                    }
                    k = String.Concat(k, "]");
                    zb = String.Concat(zb, "]");
                    zt = String.Concat(zt, "]");
                    c = String.Concat(c, "]");
                    n = String.Concat(n, "]");
                    nll = String.Concat(nll, "]");


                    sw.WriteLine(dtable.TableName + " = PolygonInhom(ml," + dtableRow + ", " +
                        k + ", " +
                        zb + ", " +
                        zt + ", " +
                        c + ", " +
                        xylist + ", " +
                        "n=" + n + ", " +
                        "nll=" + nll  +
                        ")");
                    sw.WriteLine("AquiferSystemInhomogeneity(ml, " + xylist + "," + dtable.TableName + ",ml.aq)");

                
            }

        }
        public void writePolyAreaSink(string timFileName, DataSet ds, StreamWriter sw, string dtName)
        {

            DataTable tempTablepoly = new DataTable();

            int inhomCol;
            int inhomRow;
            int t = 0;
            int count = 0;
            string infil = null;
            string label = null;
            string xylist = null;
            string tableName = null;

            ArrayList ElementNum = new ArrayList();

            if (ds.Tables.Contains(dtName))
            {
                tempTablepoly = ds.Tables[dtName];

            }
            inhomCol = tempTablepoly.Columns.Count;
            inhomRow = tempTablepoly.Rows.Count;
            for (int i = 0; i < inhomRow; i++)
            {
                if (tempTablepoly.Rows[i]["elementName"].ToString().EndsWith(Convert.ToString(count)))
                {
                    t = t + 1;
                }
                if (!tempTablepoly.Rows[i]["elementName"].ToString().EndsWith(Convert.ToString(count)))
                {
                    ElementNum.Add(t);
                    count = count + 1;
                    t = 0;
                }
            }
            ElementNum.Add(t);
            DataTable dtable = new DataTable();
            int NumOfElements = ElementNum.Count;
            for (int j = 0; j < NumOfElements; j++)
            {
                int startnum;
                int endnum;
                xylist = "[";
                int num = (int)ElementNum[j];
                if (j == 0)
                {
                    startnum = 0;
                    endnum = (int)ElementNum[j];
                }
                else
                {
                    startnum = num - 1;
                    endnum = startnum + (int)ElementNum[j];
                }
                for (int y = startnum; y < endnum; y++)
                {
                    string xytemp = "(" + tempTablepoly.Rows[y]["x"].ToString() + "," + tempTablepoly.Rows[y]["y"].ToString() + ")";
                    xylist = String.Concat(xylist, xytemp);
                    if (y != (endnum - 1))
                        xylist = String.Concat(xylist, ",");
                }
                infil = tempTablepoly.Rows[startnum]["Infil"].ToString();
                label = tempTablepoly.Rows[startnum]["label"].ToString();
                xylist = String.Concat(xylist, "]");
                tableName = tempTablepoly.Rows[j + (int)ElementNum[j] - 1]["elementName"].ToString();



                sw.WriteLine(label +"=PolyAreaSink(ml," + xylist + ", " +
                    infil + ", " +
                    "label=\""+
                    label + "\")");
               


            }
        }
        //public void writeCircInhom(string timFileName, DataSet ds, StreamWriter sw)
        //{

        //}
        public void writeOutputContourData(double xmin, double ymin, double nx, double ny,double dx, string path, StreamWriter sw, int naq, string outputName)
        {

            long nx2 = Convert.ToInt64(nx);
            long ny2 = Convert.ToInt64(ny);

            //if (ny>nx)
             //   nx = ny;


            path.Replace("\"", "/");
            sw.WriteLine("esrigrid2(" + ModelName + "," + xmin + "," + ymin + "," + nx2 + "," + dx +"," + ny2 + ",filename=r'" + path + "/" +outputName+"',Naquifers=" + naq+")");
           // sw.WriteLine("esrigrid(" + ModelName + "," + xmin + "," + xmax + "," + nx + "," + ymin + "," + ymax + "," + ny + ",filename=r'" + path + "/" + outputName + "',Naquifers=" + naq + ")");
        }
        public void getLayers() 
        {
            

        }
        public void writeWellReport(double numWells, string wellNames, string outputFilename, StreamWriter sw)
        {
            sw.WriteLine("pWellRep("+ModelName+","+numWells+","+wellNames+",filename='"+outputFilename+"')");
        }
        public void writeTestPoints(string timFileName, DataSet ds, StreamWriter sw, string path, string dtName) 
        {

            string layer = null;
            string x = null;
            string y = null;
            string name = null;

            
            DataTable dt = ds.Tables[dtName];
            int length = dt.Rows.Count;
            int colCount = dt.Columns.Count;
            int count = 0;
            for (int i = 0; i < length; i++)
            {
                x = dt.Rows[i]["X"].ToString();
                y = dt.Rows[i]["Y"].ToString();
                name = dt.Rows[i]["label"].ToString();
                for(int j = 0; j<colCount;j++)
                {
                    if (dt.Columns[j].ColumnName.StartsWith("Layer") && dt.Rows[i][j].ToString() != "0")
                        layer = dt.Rows[i][j].ToString();
                }
                count = count + 1;
                sw.WriteLine("pTestPoints(" + ModelName + "," + layer + "," + x + "," + y + ",\"" + name + "\",\"" + path + "\"," +count+")");
            }

        }
        
    }
}
