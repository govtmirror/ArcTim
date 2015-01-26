using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Windows.Forms;



namespace TimLib
{
    public class Utilities
    {
        public static string ModelName;
       
        //Source: http://riteshk.blogspot.com/2007/03/how-to-readwrite-data-from-dbf-file.html
        private static void GetFileNameAndPath(string completePath, ref string fileName, ref string folderPath)
        {
            string[] fileSep = completePath.Split('\\');
            for (int iCount = 0; iCount < fileSep.Length; iCount++)
            {
                if (iCount == fileSep.Length - 2)
                {
                    if (fileSep.Length == 2)
                    {
                        folderPath += fileSep[iCount] + "\\";
                    }
                    else
                    {
                        folderPath += fileSep[iCount];
                    }
                }
                else
                {
                    if (fileSep[iCount].IndexOf(".") > 0)
                    {
                        fileName = fileSep[iCount];
                        fileName = fileName.Substring(0, fileName.IndexOf("."));
                    }
                    else
                    {
                        folderPath += fileSep[iCount] + "\\";
                    }
                }
            }
        }
        // This function takes Dataset (to be exported) and filePath as input parameter and return // bool status as output parameter
        // comments are written inside the function to describe the functionality
        // Source: http://riteshk.blogspot.com/2007/03/how-to-readwrite-data-from-dbf-file.html
        public static bool EportDBF(DataSet dsExport, string filePath)
        {
            string tableName = string.Empty;
            string folderPath = string.Empty;
            bool returnStatus = false;
            // This function give the Folder name and table name to use in 
            // the connection string and create table statement.
            GetFileNameAndPath(filePath, ref tableName, ref folderPath);
            // here you can use DBASE IV also 
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + folderPath + "; Extended Properties=DBASE III;";
            string createStatement = "Create Table " + tableName + " ( ";
            string insertStatement = "Insert Into " + tableName + " Values ( ";
            string insertTemp = string.Empty;
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection conn = new OleDbConnection(connString);
            if (dsExport.Tables[0].Columns.Count <= 0) { throw new Exception(); }
            // This for loop to create "Create table statement" for DBF
            // Here I am creating varchar(250) datatype for all column.
            // for formatting If you don't have to format data before 
            // export then you can make a clone of dsExport data and transfer // data in to that no need to add datatable, datarow and 
            // datacolumn in the code.
            for (int iCol = 0; iCol < dsExport.Tables[0].Columns.Count; iCol++)
            {
                createStatement += dsExport.Tables[0].Columns[iCol].ColumnName.ToString();
                if (iCol == dsExport.Tables[0].Columns.Count - 1)
                {
                    createStatement += " varchar(250) )";
                }
                else
                {
                    createStatement += " varchar(250), ";
                }
            }
            //Create Temp Dateset 
            DataSet dsCreateTable = new DataSet();
            //Open the connection 
            conn.Open();
            //Create the DBF table
            DataSet dsFill = new DataSet();
            OleDbDataAdapter daInsertTable = new OleDbDataAdapter(createStatement, conn);
            daInsertTable.Fill(dsFill);
            //Adding One DataTable into the dsCreatedTable dataset
            DataTable dt = new DataTable();
            dsCreateTable.Tables.Add(dt);
            for (int row = 0; row < dsExport.Tables[0].Rows.Count; row++)
            {
                insertTemp = insertStatement;
                //Adding Rows to the dsCreatedTable dataset
                DataRow dr = dsCreateTable.Tables[0].NewRow();
                dsCreateTable.Tables[0].Rows.Add(dr);
                for (int col = 0; col < dsExport.Tables[0].Columns.Count; col++)
                {
                    if (row == 0)
                    {
                        //Adding Columns to the dsCreatedTable dataset
                        DataColumn dc = new DataColumn();
                        dsCreateTable.Tables[0].Columns.Add(dc);
                    }
                    // Remove Special character if any like dot,semicolon,colon,comma // etc
                    dsExport.Tables[0].Rows[row][col].ToString().Replace("LF", "");
                    // do the formating if you want like modify the Date symbol , //thousand saperator etc.
                    dsCreateTable.Tables[0].Rows[row][col] = dsExport.Tables[0].Rows[row][col].ToString().Trim();
                    //} // inner for loop close
                    // Create Insert Statement
                    if (col == dsExport.Tables[0].Columns.Count - 1)
                    {
                        insertTemp += "'" + dsCreateTable.Tables[0].Rows[row][col] + "' ) ;";
                    }
                    else
                    {
                        insertTemp += "'" + dsCreateTable.Tables[0].Rows[row][col] + "' , ";
                    }
                }
                // This lines of code insert Row One by one to above created 
                // datatable.
                daInsertTable = new OleDbDataAdapter(insertTemp, conn);
                daInsertTable.Fill(dsFill);

            } // close outer for loop
            MessageBox.Show("Exported done Successfully to DBF File.");
            return true;
        } // close function
        // This function takes filePath as input parameter and return DataSet as output parameter
        // comments are written inside the function to describe the functionality
        //source: http://riteshk.blogspot.com/2007/03/how-to-readwrite-data-from-dbf-file.html
        public static DataSet ImportDBF(string filePath)
        {
            string ImportDirPath = string.Empty;
            string tableName = string.Empty;
            // This function give the Folder name and table name to use in 
            // the connection string and create table statement.
            GetFileNameAndPath(filePath, ref tableName, ref ImportDirPath);
            DataSet dsImport = new DataSet();
            //string thousandSep = thousandSeparator;
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + ImportDirPath + "; Extended Properties=DBASE IV;";
            OleDbConnection conn = new OleDbConnection(connString);
            DataSet dsGetData = new DataSet();
            OleDbDataAdapter daGetTableData = new OleDbDataAdapter("Select * from " + tableName, conn);
            // fill all the data in to dataset
            daGetTableData.Fill(dsGetData);
            DataTable dt = new DataTable(dsGetData.Tables[0].TableName.ToString());
            dsImport.Tables.Add(dt);
            // here I am copying get Dataset into another dataset because //before return the dataset I want to format the data like change //"datesymbol","thousand symbol" and date format as did while 
            // exporting. If you do not want to format the data then you can // directly return the dsGetData
            for (int row = 0; row < dsGetData.Tables[0].Rows.Count; row++)
            {
                DataRow dr = dsImport.Tables[0].NewRow();
                dsImport.Tables[0].Rows.Add(dr);
                for (int col = 0; col < dsGetData.Tables[0].Columns.Count; col++)
                {
                    if (row == 0)
                    {
                        DataColumn dc = new DataColumn(dsGetData.Tables[0].Columns[col].ColumnName.ToString());
                        dsImport.Tables[0].Columns.Add(dc);
                    }
                    if (!String.IsNullOrEmpty(dsGetData.Tables[0].Rows[row][col].
                    ToString()))
                    {
                        dsImport.Tables[0].Rows[row][col] = Convert.ToString(dsGetData.Tables[0].Rows[row][col].ToString().Trim());
                    }
                } // close inner for loop
            }// close ouer for loop
            MessageBox.Show("Import done Successfully to DBF File.");
            return dsImport;
        } // close function


        static bool debugOutput = true;
        public static DataTable Read(string filename)
        {
            string tableName = TableName(filename);
            return Read(filename, "select * from " + tableName);
        }
        public static DataTable Read(string filename, string sql)
        {
            if (debugOutput)
                Console.Write("Reading from " + filename);

            AssertFileExists(filename);
            string tableName = TableName(filename);
            string strAccessConn = ConnectionStr(filename);

            DataSet myDataSet = new DataSet();
            myDataSet.Tables.Add(tableName);

            OdbcConnection myAccessConn = new OdbcConnection(strAccessConn);
            OdbcCommand myAccessCommand = new OdbcCommand(sql, myAccessConn);
            OdbcDataAdapter myDataAdapter = new OdbcDataAdapter(myAccessCommand);

            myAccessConn.Open();

            try
            {
                myDataAdapter.Fill(myDataSet, tableName);
            }
            finally
            {
                myAccessConn.Close();
            }
            if (debugOutput)
                Console.WriteLine(" done.");
            return myDataSet.Tables[tableName].Copy();
        }
        public static void AssertFileExists(string filename)
        {

            if (DoesFileExists(filename) == false)
                throw new Exception("File " + filename + " does not exist");

        }
        private static string ConnectionStr(string filename)
        {
            string strConnection = "Driver={Microsoft dBase Driver (*.dbf)};DBQ=";
            //string strConnection = "Driver={Microsoft dBase VFP Driver (*.dbf)};DBQ=";
            string tableName = TableName(filename);
            string path = System.IO.Path.GetDirectoryName(filename);
            string strAccessConn = strConnection + path;
            return strAccessConn;
        }
        private static string TableName(string filename)
        {
            string tableName = System.IO.Path.GetFileNameWithoutExtension(filename);
            return tableName;
        }
        public static bool DoesFileExists(string filename)
        {
            FileInfo Info = new FileInfo(filename);
            return (Info.Exists);
        }
    }
}
