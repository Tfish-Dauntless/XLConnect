using Sylvan.Data.Csv;
using Sylvan.Data.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Sylvan.Data.Schema;

namespace XLConnect.Classes
{
    public class Data_Helper
    {
        private SQL_Helper SQLHELPER { get; set; }
        public Data_Helper(SQL_Helper sqlHelper)
        {
            SQLHELPER = sqlHelper;
        }

        public async Task<string> DetermineFileDelimiter(string extension,List<string>FileLines)
        {
            //MessageBox.Show("Determin File Demiliter");
            List<string> delimiters = new List<string> { "\t", ";", "-", ",", "|","*","~","^" };
            Dictionary<string, int> counts = delimiters.ToDictionary(key => key, value => 0);
            string Delimiter = "|";


            switch (extension.ToUpper())
            {
                case ".TSV":
                case ".TXT":
                case ".CSV":

                    foreach (var line in FileLines)
                    {
                        foreach (string c in delimiters)
                        {
                            counts[c] = line.Count(t => t.ToString() == c);
                        }

                        //MessageBox.Show(line.ToString());
                    }
                    //MessageBox.Show(string.Join(";", counts.Select(x => x.Key.ToString() + "=" + x.Value).ToArray()));
                    if (counts.Values.All(value => value <= 0))
                    {
                        Delimiter = "Unknown";

                    }

                    Delimiter = counts.FirstOrDefault(x => x.Value == counts.Values.Max()).Key;
                    //counts.Clear();
                    break;
                case ".XLS":
                case ".XLSX":
                case ".XLSM":
                    Delimiter = "TAB";
                    break;
                case ".XLSB":
                    //File.Move(file.FilePath + "\\" + file.FileName,Path.ChangeExtension(file.FilePath + "\\" + file.FileName, ".XLS"));
                    //file.FileName = file.FileName.ToUpper().Replace("XLSB", "XLSX");
                    Delimiter = "TAB";
                    //file.FileExtension = ".XLSX";
                    break;

            }
            return Delimiter;
        }
        public async Task<List<string[]>> GetWorkSheetdataAsList(ExcelDataReader edr, string type = "normal", CsvDataReader csv = null,List<string> filelines = null,string delimiter = null)
        {
            ExcelFormat format = null;
            ExcelDataType etype = new ExcelDataType();

            try
            {
                List<string[]> textrowslist = new List<string[]>();
                int procCount = 1;
                if (csv != null)
                {

                    while (await csv.ReadAsync())
                    {

                        var endcolumn = csv.RowFieldCount;

                        string[] textrows = new string[endcolumn];

                        for (int i = 0; i < endcolumn; i++)
                        {



                            //newRow[i] = edr.GetExcelValue(i).ToString() == null ? String.Empty : edr.GetExcelValue(i).ToString();
                            textrows[i] = csv.GetString(i).ToString() == null ? String.Empty : csv.GetString(i).ToString();
                        }
                        textrowslist.Add(textrows);
                        procCount += 1;
                    }
                }
                else if(filelines != null)
                {
                    foreach (var line in filelines)
                    {
                        if (line.Length > 0)
                        {
                            var splitOn = delimiter == "TAB" ? "\t" : delimiter;
                            var splitline = line.Split(splitOn.ToCharArray()).ToArray();
                            textrowslist.Add(splitline);
                          
                        }
                    }
                }
                else
                {
                    while (await edr.ReadAsync())
                    {

                        var endcolumn = edr.RowFieldCount;

                        string[] textrows = new string[endcolumn];

                        for (int i = 0; i < endcolumn; i++)
                        {
                            //var schem =  edr.GetColumnSchema();

                            //newRow[i] = edr.GetExcelValue(i).ToString() == null ? String.Empty : edr.GetExcelValue(i).ToString();
                            //etype = edr.GetExcelDataType(i);

                            format = edr.GetFormat(i);
                            etype = edr.GetExcelDataType(i);

                            //edr.GetFormat(i).Kind = FormatKind.String;
                            //MessageBox.Show(format.ToString());
                            //edr.GetExcelValue;

                            //MessageBox.Show(edr.GetFormulaError(i).ToString());

                            if (format.Kind == FormatKind.Number)
                            {

                                textrows[i] = (string)edr.GetString(i) == null ? String.Empty : (string)edr.GetString(i);
                            }
                            else
                            {
                                textrows[i] = edr.GetString(i);
                            }


                            //if (edr.GetFormulaError(i) == ExcelErrorCode.Value)//|| edr.GetString(i) == null
                            //{

                            //    textrows[i] = String.Empty;
                            //}
                            //else
                            //{

                            //}
                        }
                        textrowslist.Add(textrows);
                    }
                }

                if (textrowslist.Count <= 0)
                {
                    throw new Exception("Worksheet is empty");
                }


                return textrowslist;
            }
            catch (Exception e)
            {

                //MessageBox.Show($"Error is coming from GetWorkSheetdataAsList Method. Cell DataFormat:{format}.\nFormatKind: {format.Kind}\nCell DataType: {etype}\n{e.Message}\n{e.StackTrace}");
                throw new Exception(e.Message);
            }

        }

        public string StripString(string input)
        {
            // var line = input.Trim().Replace(System.Environment.NewLine, " ");
            string reduceMultiSpace = @"[ ]{2,}";
            char tab = '\u0009';
            var trimmed = input.Replace(tab.ToString(), "").Replace(Environment.NewLine, " ").Trim();
            return Regex.Replace(trimmed.Replace("\t", " ").Replace("\r\n", " "), reduceMultiSpace, " ").ToUpper().Trim();
        }
        public async Task<DataTable> FillDataTableFromList(List<string[]> Rows, int headerRow)
        {
            try
            {
                var headercount = new Dictionary<string, int>();
                var dt = new DataTable();
                foreach (var header in Rows[headerRow])
                {

                    var aliasedheader = header == String.Empty || header == null ? "DD_BlankHeader": header;
                    if (headercount.Keys.Contains(aliasedheader))
                    {
                        headercount[aliasedheader] += 1;
                    }
                    else
                    {
                        headercount.Add(aliasedheader, 0);
                    }
                    var headerNameActual = headercount[aliasedheader] > 0 ? $"{aliasedheader}_{headercount[aliasedheader]}" : aliasedheader;
                    if (headerNameActual.Length > 128)
                    {
                        if(!dt.Columns.Contains(StripString(headerNameActual.Substring(0, 100))))
                        {
                            dt.Columns.Add(StripString(headerNameActual.Substring(0, 100)));
                        }
                    }
                    else
                    {
                        if (!dt.Columns.Contains(StripString(headerNameActual)))
                        {
                            dt.Columns.Add(StripString(headerNameActual));
                        }
                        
                    }
                   
                }
                var maxRow = Rows.Max(x => x.Length);
                if (dt.Columns.Count < maxRow)
                {
                    for (var ic = dt.Columns.Count; ic < maxRow; ic++)
                    {
                        dt.Columns.Add($"DD_PlaceHolder_{ic}");
                    }
                }
                foreach (var item in Rows.Skip(headerRow))
                {
                   dt.Rows.Add(item);
                }


                return dt;
            }
            catch (Exception e)
            {
                // MessageBox.Show(e.Message + " " + e.StackTrace);
               //throw new Exception($"Error is coming from AddHeadersToDataTable Method.\n{e.Message}\n{e.StackTrace}");
                throw new Exception(e.Message);

            }

        }
        private async Task<bool> CleanExportTable(System.Data.DataTable table)
        {
            try
            {
                foreach (var column in table.Columns.Cast<DataColumn>().ToArray())
                {
                    if (table.AsEnumerable().All(dr => dr.IsNull(column)))
                    {
                        table.Columns.Remove(column);
                    }
                    
                }

                table.AcceptChanges();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n\n" + e.StackTrace);
                return false;
            }


        }

        public async Task<bool> InsertProcessedData(System.Data.DataTable table,string ServerName, string DataBaseName,string TableName)
        {
            try
            {

                //await CleanExportTable(table);

                var newcols = new List<string>();
                var columnstoAdd = new List<string>();

                await SQLHELPER.GatherSqlColumns(ServerName, DataBaseName, TableName, newcols);
                var currentColumns = (from dc in table.Columns.Cast<DataColumn>() select dc.ColumnName.ToUpper().Trim()).ToList();

                // MessageBox.Show(String.Join(",", currentColumns));
                foreach (var col in currentColumns.ToList())
                {
                    if (!newcols.Contains(col.ToUpper().Trim()))
                    {
                        columnstoAdd.Add(col.ToUpper().Trim());
                    }
                }
                //MessageBox.Show(columnstoAdd.Count.ToString() + "\n\n vs \n\n " + newcols.Count.ToString());
                if (columnstoAdd.Count > 0)
                {
                    //MessageBox.Show("Total Columns in Data Table" + columnstoAdd.Count + "\n\n Total Columns in SQL:" + currentColumns.Count+ "\n\n Total Columns to Add: " + columnstoAdd.Count);
                    await SQLHELPER.AddColumns(ServerName, DataBaseName, TableName, columnstoAdd);
                }


                var sql = await SQLHELPER.InsertDataIntoSQL(table, ServerName, DataBaseName, TableName);
                if (!sql)
                {
                    //MessageBox.Show("Data did not import");
                    return false;
                }


                columnstoAdd.Clear();
                newcols.Clear();
                //await CleanExportTable(ExportTable);

                return true;
            }
            catch (Exception sql)
            {
                throw new Exception("Failed to insert data into SQL\n\n" + sql.Message + "\n\n" + sql.StackTrace);
            }




        }

    }
}
