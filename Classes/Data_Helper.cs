using OfficeOpenXml;
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
            List<string> delimiters = new List<string> { "\t", ";", ",", "|"};
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

        public async Task<List<string[]>> GetWorkSheetdataAsList(Sylvan.Data.Excel.ExcelDataReader edr, CsvDataReader csv = null, System.Data.DataTable worksheet = null, ExcelWorksheet Ep_Worksheet = null, List<string> filelines = null, string delimiter = null,string quote = null)
        {
            try
            {

                List<string[]> textrowslist = new List<string[]>();
                if (csv != null)
                {
                    if (csv.RowFieldCount > 1000)
                    {
                        throw new Exception("Number of columns exceeds limit");
                    }
                    while (await csv.ReadAsync())
                    {
                        string[] textrows = new string[csv.RowFieldCount];

                        for (int i = 0; i < csv.RowFieldCount; i++)
                        {
                            textrows[i] = csv.GetString(i).ToString() == null ? String.Empty : csv.GetString(i).ToString();
                        }
                        textrowslist.Add(textrows);
                    }
                }
                else if (worksheet != null)
                {
                    if (worksheet.Columns.Count > 1000)
                    {
                        throw new Exception("Number of columns exceeds limit");
                    }
                    for (var row = 0; row < worksheet.Rows.Count; row++)
                    {
                        textrowslist.Add(worksheet.Rows[row].ItemArray.Select(x => x.ToString()).ToArray());
                    }
                }
                else if (filelines != null)
                {
                    foreach (var line in filelines)
                    {
                        if (line.Length > 0)
                        {
                            var splitOn = $"{quote}{delimiter}{quote}";
                            var splitline = line.Split(splitOn.ToCharArray()).Select(x => x.Replace(quote,"")).ToArray();
                            textrowslist.Add(splitline);
                        }
                    }
                }
                else if (Ep_Worksheet != null)
                {
                    //Cells.Last(c => c.Start.Column == 1);//(c => Helper.StripString(c.Text) != null && Helper.StripString(c.Text) != String.Empty)
                    var LastColumnWithText = Ep_Worksheet.Cells.Where(x => StripString(x.Text) != null && StripString(x.Text) != String.Empty).Max(y => Ep_Worksheet.Cells[y.Address].End.Column);
                    //MessageBox.Show(LastColumnWithText.ToString());//Ep_Worksheet.Cells[LastColumnWithText].End.Column.ToString()
                    for (var row = 1; row <= Ep_Worksheet.Dimension.End.Row; row++)
                    {
                        string[] textrows = new string[LastColumnWithText];
                        //textrowslist.Add(Ep_Worksheet.Rows[row].Select(x => x.ToString()).ToArray());
                        var wsRow = Ep_Worksheet.Cells[row, 1, row, LastColumnWithText];

                        int index = 0;
                        for (var cell = 1; cell <= LastColumnWithText; cell++)
                        {
                            textrows[cell - 1] = Ep_Worksheet.Cells[row, cell].Text ?? String.Empty;
                        }
                        textrowslist.Add(textrows);
                    }

                    return textrowslist;
                }
                else
                {
                    while (await edr.ReadAsync())
                    {
                        if (edr.RowFieldCount > 1000)
                        {
                            throw new Exception("Number of columns exceeds limit");
                        }
                        var endcolumn = edr.RowFieldCount;

                        string[] textrows = new string[endcolumn];

                        for (int i = 0; i < endcolumn; i++)
                        {

                            var formatt = edr.GetFormat(i);

                            //newRow[i] = edr.GetExcelValue(i).ToString() == null ? String.Empty : edr.GetExcelValue(i).ToString();
                            textrows[i] = edr.GetString(i).ToString() == null ? String.Empty : edr.GetString(i).ToString();
                        }
                        textrowslist.Add(textrows);
                    }
                }

                return textrowslist;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        public string FormatValue(object v)
        {
            if (v == null)
            {
                return null;
            }
            if (v is DateTime dt)
            {
                return dt.ToString("O");
            }
            if (v is DateTimeOffset dto)
            {
                return dto.ToString("O");
            }
            if (v is byte[] ba)
            {
                var sb = new StringBuilder(2 + ba.Length * 2);
                sb.Append("0x");
                for (int i = 0; i < ba.Length; i++)
                {
                    sb.Append(ba[i].ToString("X2"));
                }
                return sb.ToString();
            }
            return v.ToString();
        }
        public string ReplaceLastOccurrence(string source, string find, string replace)
        {
            int place = source.LastIndexOf(find);

            if (place == -1)
                return source;

            return source.Remove(place, find.Length).Insert(place, replace);
        }
        public string ToNullSafeString(object obj)
        {
            return (obj ?? string.Empty).ToString();
        }
        public string StripString(string input)
        {
            // var line = input.Trim().Replace(System.Environment.NewLine, " ");
            string reduceMultiSpace = @"[ ]{2,}";
            char tab = '\u0009';
            var trimmed = input.Replace(tab.ToString(), "").Replace(Environment.NewLine, " ").Trim();
            return Regex.Replace(trimmed.Replace("\t", " ").Replace("\r\n", " "), reduceMultiSpace, " ").ToUpper().Trim();
        }
        public async Task<DataTable> FillDataTableFromList(List<string[]> Rows, int headerRow, bool skiprow = false)
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
                var StartingRow = false ? headerRow + 1 : headerRow;
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

               // await SQLHELPER.GatherSqlColumns(ServerName, DataBaseName, TableName, newcols);
                var currentColumns = (from dc in table.Columns.Cast<DataColumn>() select dc.ColumnName.ToUpper().Trim()).Distinct().ToList();

                 //MessageBox.Show(String.Join(",", currentColumns));
                //foreach (var col in currentColumns.ToList())
                //{
                //    if (!columnstoAdd.Contains(col.ToUpper().Trim()))
                //    {
                //        columnstoAdd.Add(col.ToUpper().Trim());
                //    }
                //}
                //MessageBox.Show(columnstoAdd.Count.ToString() + "\n\n vs \n\n " + newcols.Count.ToString());
                //if (columnstoAdd.Count > 0)
                //{
                //    //MessageBox.Show("Total Columns in Data Table" + columnstoAdd.Count + "\n\n Total Columns in SQL:" + currentColumns.Count+ "\n\n Total Columns to Add: " + columnstoAdd.Count);
                //    await SQLHELPER.AddColumns(ServerName, DataBaseName, TableName, columnstoAdd);
                //}


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
