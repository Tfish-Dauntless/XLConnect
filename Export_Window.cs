
using Sylvan.Data.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using XLConnect.Classes;

namespace ExcelMate
{
    public partial class Export_Window : Form
    {
        private string Query { get; set; }
        private string ServerName { get; set; }
        private string DataBaseName { get; set; }
        private string TableName { get; set; }
        private SQL_Helper SQLHelper { get; set; }
        private Data_Helper Helper { get; set; }
        public Export_Window(DataTable datalist,SQL_Helper sqlhelper,Data_Helper helper, string server,string query = null,string database = null, string table = null)
        {
            InitializeComponent();
            Rowsleft = datalist.Rows.Count;
            TotalRows = datalist.Rows.Count;
            DataList = datalist;
            ExportCount_Label.Text = "Empty";//datalist == null ? "0" : DataList.Rows.Count.ToString()
            Query = query.Replace("\n", "").Replace(Environment.NewLine, "");
            ServerName = server;
            DataBaseName = database;
            TableName = table;
            SQLHelper = sqlhelper;
            Helper = helper;
        }

        private async Task<Dictionary<string, string>> GetDBContextFromQuery()
        {
            try
            {
                Dictionary<string, string> dbContext = new Dictionary<string, string>()
                {
                    {"DataBaseName","" },
                    {"schema","" },
                    {"TableName","" },
                    {"Columns","" }
                };

                int indexOfSelect = Query.ToUpper().IndexOf("SELECT ");
                int indexOfSelectOffset = 7;


                Regex Columnregex = new Regex(@"(?:SELECT TOP.+?\)|SELECT)(?<columns>.*?)FROM");
                Regex dataBaseRegex = new Regex(@"FROM.+?(?<dbname>.*?)\.");
                Regex scehmaRegex = new Regex(@"FROM.+?\.(?<schema>.*)\.");
                Regex tableNameRegex = new Regex(@"FROM.*?\..*?\.(?<tablename>.*?)(?:\n|WHERE|$)");
                Regex fromLineRegex = new Regex(@"FROM(?<from>.*?)(?:\n|WHERE|$)");

                Match columnMatch = Columnregex.Match(Query);
                Match fromLineMatch = fromLineRegex.Match(Query);
                var comma = ',';
                dbContext["Columns"] = Helper.StripString(columnMatch.Groups["columns"].Value).Replace(",",",");
                Group fromLine = fromLineMatch.Groups["from"];

                Match dataBaseMatch;
                Match scehmaMatch;
                Match tableNameMatch;
                

                if (fromLine.Value.Count(c => c ==  '.') >= 0)
                {
                   // MessageBox.Show(fromLine.Value.Count(c => c == '.').ToString());

                    switch (fromLine.Value.Count(c => c == '.'))
                    {
                        
                        case 0:
                            //scehmaRegex = null;
                           // dataBaseRegex = null;
                            tableNameRegex = new Regex(@"FROM.+?(?<tablename>.*?)(?:\n|WHERE|\s|$)");
                            tableNameMatch = tableNameRegex.Match(Query);
                            dbContext["TableName"] = tableNameMatch.Groups["tablename"].Value;

                            break;
                        case 1:
                            //MessageBox.Show(fromLine.Value.Count(c => c == '.').ToString());
                            //dataBase = null;
                           // dataBaseRegex = null;
                            scehmaRegex = new Regex(@"FROM.+?(?<schema>.*?)\.");
                            tableNameRegex = new Regex(@"FROM.+?\.(?<tablename>.*?)(?:\n|WHERE|\s|$)");
                            scehmaMatch = scehmaRegex.Match(Query);
                            tableNameMatch = tableNameRegex.Match(Query);
                            dbContext["schema"] = scehmaMatch.Groups["schema"].Value;
                            dbContext["TableName"] = tableNameMatch.Groups["tablename"].Value;
                            break;
                        default:
                            dataBaseMatch = dataBaseRegex.Match(Query);
                            scehmaMatch = scehmaRegex.Match(Query);
                            tableNameMatch = tableNameRegex.Match(Query);
                            dbContext["schema"] = scehmaMatch.Groups["schema"].Value;
                            dbContext["TableName"] = tableNameMatch.Groups["tablename"].Value;
                            dbContext["DataBaseName"] = dataBaseMatch.Groups["dbname"].Value;
                            break;
                    }
                }
              
                //MessageBox.Show($"Count: {fromLine.Value.Count(c => c == '.')}\n\nFROM: {fromLine.Value.Trim()}\n\nColumns: {dbContext["Columns"]}\n\nDataBase: {dbContext["DataBaseName"]}\n\nSchema: {dbContext["schema"]}\n\nTable: {dbContext["TableName"]}");
                return dbContext;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<String> ExportToExcel(string filepath, string type = "", int tokeep = 0, int toSkip = 0)
        {
            
            var File = new FileInfo(filepath);
            using (ExcelDataWriter edw = ExcelDataWriter.Create(filepath))
            {
               
                if (type == "ExcelCap")
                {
                    //MessageBox.Show("I've made it to the export method" + DataList.Rows.Count.ToString());
                    DataTable firstMilly = DataList.AsEnumerable().Skip(toSkip).Take(tokeep).CopyToDataTable();
                    var reader = firstMilly.CreateDataReader();
                    await edw.WriteAsync(reader, "Delivery");
                }
                else
                {

                    var reader = DataList.CreateDataReader();
                    await edw.WriteAsync(reader, "Delivery");
                }
            }

            return "Complete";

        }

        //================================================================================================================================================================================================================
        //Event Handlers
        //================================================================================================================================================================================================================

        private void ExportLocation_Button_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel (*.Xlsx)|*.Xlsx|Comma Seperated (*.csv)|*.csv|Text (*.txt)|*.txt|dat (*.dat)|*.dat";
            saveFile.DefaultExt = "xlsx";
            
            saveFile.AddExtension = true;
            saveFile.FileName = DateTime.Now.ToString("yyyyMMdd") + "_REPLACEWITHCASENAME_Delivery";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                if (!Delimiter_TextBox.Enabled)
                {
                    Delimiter_TextBox.Enabled = true;
                   


                }
                if (!Qualifier_TextBox.Enabled)
                {
                    Qualifier_TextBox.Enabled = true;
                }
                
                ExportLocation_TextBox.Text = saveFile.FileName;

                var ext = saveFile.FileName.Split('.').ToList().Last();
                ExportType_ComboBox.Text = ext.ToUpper();
                switch (ext)
                {
                    case "XLSX":
                        Delimiter_TextBox.Enabled = false;
                        Qualifier_TextBox.Enabled = false;
                        break;
                    case "CSV":
                        Delimiter_TextBox.Text = ",";
                        Qualifier_TextBox.Text = "\"";
                        break;
                    case "TXT":
                        Delimiter_TextBox.Text = "|";
                        Qualifier_TextBox.Text = "^";
                        break;
                    case "DAT":
                        Delimiter_TextBox.Enabled = false;
                        Qualifier_TextBox.Enabled = false;
                        break;
                }
            }

        }
        private async void Export_Btn_Click(object sender, EventArgs e)
        {

            try
            {
                //{ "DataBaseName","" },
                //    { "schema","" },
                //    { "TableName","" },
                //    { "Columns","" }
                //var sqlColumns = await SQLHelper.GatherSqlColumns();

                var dbcontext = GetDBContextFromQuery().Result;

                var adjustedDBContext_Db = dbcontext["DataBaseName"].Contains("[") ? dbcontext["DataBaseName"] : $"[{dbcontext["DataBaseName"]}]";
                var adjustedDBContext_Table = dbcontext["TableName"].Contains("[") ? dbcontext["TableName"] : $"[{dbcontext["TableName"]}]";

                //MessageBox.Show($"DataBase in Query and DataBase Field do not match.\nQuery: {adjustedDBContext_Db}\nField: [{DataBaseName}] ");

                if (DataBaseName != null && $"[{DataBaseName.Trim()}]" != adjustedDBContext_Db.Trim())
                {
                    MessageBox.Show($"DataBase in Query and DataBase Field do not match.\nQuery: {adjustedDBContext_Db.Trim()}\nField: [{DataBaseName.Trim()}] ");
                    return;
                }
                if (TableName != null && $"[{TableName.Trim()}]" != adjustedDBContext_Table.Trim())
                {
                    MessageBox.Show($"Table in Query and Table Field do not match.\nQuery: {adjustedDBContext_Table.Trim()}\nField:   [{TableName.Trim()}] ");
                    return;
                }
                if(ExportLocation_TextBox.Text == null || ExportLocation_TextBox.Text == String.Empty)
                {
                    MessageBox.Show($"Please provide an export location!");
                    return;
                }

                var exportname = ExportLocation_TextBox.Text;
                var delim = Delimiter_TextBox.Text == null || Delimiter_TextBox.Text == String.Empty? '\t' : Delimiter_TextBox.Text.ToCharArray().First();
                var qual = Qualifier_TextBox.Text == null || Qualifier_TextBox.Text == String.Empty ? '\"': Qualifier_TextBox.Text.ToCharArray().First();

                if (ExportType_ComboBox.Text == "CSV")
                {
                    exportname = ExportLocation_TextBox.Text.Replace(".xlsx", ".csv");
                }
                if (ExportType_ComboBox.Text == "TXT")
                {
                    exportname = ExportLocation_TextBox.Text.Replace(".xlsx", ".txt");
                }
                if (ExportType_ComboBox.Text == "DAT")
                {
                    exportname = ExportLocation_TextBox.Text.Replace(".xlsx", ".dat");
                    delim = '\u0014';
                    qual = 'þ';
                }


                await SQLHelper.RunSqlQuery_New(Helper, exportname, Query, ServerName, adjustedDBContext_Db.Replace("[","").Replace("]",""), adjustedDBContext_Table.Replace("[", "").Replace("]", ""), dbcontext["Columns"].Split(',').ToList(),ExportType_ComboBox.Text,delim,qual);


                //int toSkip = 0;
                //int num = 1;
                //int MaxRowSize = 500000;
                //if (MaxRowSize_CheckBox.Checked)
                //{
                //    MaxRowSize = Decimal.ToInt32(RowsPerSheet_NumBox.Value);
                //}

                //if (TotalRows > MaxRowSize)
                //{
                //    while (Rowsleft > 0)
                //    {
                //        if (Rowsleft < MaxRowSize)
                //        {
                //            //MessageBox.Show("Im Here to export a large amount");
                //            await ExportToExcel(ExportLocation_TextBox.Text.Replace(".Xlsx", "") + "_" + num + ".Xlsx", "ExcelCap", Rowsleft, toSkip);

                //            break;
                //        }
                //        else
                //        {
                //            await ExportToExcel(ExportLocation_TextBox.Text.Replace(".Xlsx", "") + "_" + num + ".Xlsx", "ExcelCap", MaxRowSize, toSkip);
                //        }
                //        num += 1;
                //        toSkip += MaxRowSize;
                //        Rowsleft -= MaxRowSize;
                //    }

                //}
                //else
                //{

                //    await ExportToExcel(ExportLocation_TextBox.Text);

                //}
                // await ExportToExcel(ExportLocation_TextBox.Text.Replace("_Delivery.Xlsx", "_RoundTracking.Xlsx"), "RoundTracking");



                MessageBox.Show("Complete");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception em)
            {
                MessageBox.Show(em.Message +"\n\n" + em.StackTrace);
            }
        }
        private void MaxRowSize_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (MaxRowSize_CheckBox.Checked)
            {
                
                RowsPerSheet_NumBox.Visible = true;
                RowsPerSheet_NumBox.Value = 500000;
            }
            else
            {
               
                RowsPerSheet_NumBox.Visible = false;
            }
            
        }
        private void MaxRowSize_CheckBox_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(MaxRowSize_CheckBox, "Defualt Max Row limit is 999,999"); // you can change the first parameter (textbox3) on any control you wanna focus
        }
        public int TotalRows { get; set; }
        public int Rowsleft { get; set; }
        public DataTable DataList { get; set; }
        public DataTable RoundTracking { get; set; }

        private void ExportType_ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!Delimiter_TextBox.Enabled)
            {
                Delimiter_TextBox.Enabled = true;
            }
            if (!Qualifier_TextBox.Enabled)
            {
                Qualifier_TextBox.Enabled = true;
            }
            switch (ExportType_ComboBox.Text)
            {
                case "XLSX":
                    Delimiter_TextBox.Enabled = false;
                    Qualifier_TextBox.Enabled = false;
                    break;
                case "CSV":
                    Delimiter_TextBox.Text = ",";
                    Qualifier_TextBox.Text = "\"";
                    break;
                case "TXT":
                    Delimiter_TextBox.Text = "|";
                    Qualifier_TextBox.Text = "^";
                    break;
                case "DAT":
                    Delimiter_TextBox.Text = "\u0014";
                    Qualifier_TextBox.Text = "þ";
                    break;
            }
        }
    }
}
