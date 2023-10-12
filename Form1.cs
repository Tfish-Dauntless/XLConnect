using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using Sylvan.Data.Csv;
using Sylvan.Data.Excel;
using XLConnect.Classes;
using XLConnect.Forms;

namespace XLConnect
{
   
    public partial class Form1 : Form
    {
        private SQL_Helper SQLHELPER = new SQL_Helper();
        private Data_Helper DataHelper { get; set; }
        private Progress<ProgressBarHelper> Progress = new Progress<ProgressBarHelper>();
        public DataTable Table { get; set; }
        public string SQLCONNECTION { get; set; }
        private Dictionary<string,string> ErrorList = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
            Table = new DataTable();
            SQLCONNECTION = @"Data Source=localHost;Initial Catalog=DupeTesting;Integrated Security=True;";
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.Commercial;
            DataHelper = new Data_Helper(SQLHELPER);
            Progress.ProgressChanged += ReportProgess;
            validateServerName();



        }
        private async Task <bool>validateServerName()
        {
            try
            {
                var servernameActual =  System.Environment.MachineName.ToUpper() == "DEVMACHINE" ? "LocalHost" :  "Proc-SQL01";
                Server_TextBox.Text = servernameActual;
                await IsServerConnected(servernameActual);
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

        }
        private async Task<bool> IsServerConnected(string server)
        {
          
            string connectionString = @"Data Source="+server+";Initial Catalog=Master;Integrated Security=True;";
            bool connectionerror = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                try
                {
                    connection.Open();
                    SQLCONNECTION = connectionString;
                    Control_GroupBox.Text += ":  Connected";
                    //MessageBox.Show("Connection Established");
                    connection.Close();
                }
                catch (SqlException s)
                {
                    MessageBox.Show("SQL CONNECTION FAILED \n" + s.Message);
                    Control_GroupBox.Text += ":  Connection Failed";
                    connectionerror =  false;
                    connection.Close();
                }
            }

            return connectionerror;
        }
        private async Task<bool> PopulateComboBox()
        {
            bool haserror = false;
            using (SqlConnection conn = new SqlConnection(SQLCONNECTION))
            {
                try
                {
                    string query = "select name from sys.databases";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    DBCOMBOBOX.DataSource = dt;
                    DBCOMBOBOX.DisplayMember = "name";
                    DBCOMBOBOX.ValueMember = "name";



                }
                catch (Exception ex)
                {
                    // write exception info to log or anything else
                    MessageBox.Show("Error occured!");
                    haserror =  true;
                }
            }
            return haserror;
        }
        private async Task<bool> PopulateTableComboBox()
        {
            bool haserror = false;
            using (SqlConnection conn = new SqlConnection(SQLCONNECTION))
            {
                try
                {
                    string query = "use ["+DBCOMBOBOX.Text+"] SELECT name FROM sys.tables";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Table_Combobox.DataSource = dt;
                    Table_Combobox.DisplayMember = "name";
                    Table_Combobox.ValueMember = "name";


                    Export_Button.Visible = true;
                    Clear_Button.Visible = true;
                }
                catch (Exception ex)
                {
                    // write exception info to log or anything else
                    MessageBox.Show("Error occured!");
                    haserror = true;
                }
            }
            return haserror;
        }

        private async Task<bool> GatherFIleData(IProgress<ProgressBarHelper> progress)
        {
            try
            {
               // MessageBox.Show("I'm running next method");
                var i = 0;
                var newFilenames = new List<string>();
                var progressHelper = new ProgressBarHelper();
                DirectoryInfo directory = new DirectoryInfo(Import_Textbox.Text);
                var totalfiles = directory.GetFiles("*.*", searchOption: SearchOption.AllDirectories).Count();
                var headerrow = int.Parse(headerRow_TextBox.Text);
                var ServerName = Server_TextBox.Text;
                var DataBaseName = DBCOMBOBOX.Text;
                await Task.WhenAll(Task.Run(() =>
                {
                    //foreach (var finfo in directory.GetFiles("*.*", searchOption: SearchOption.AllDirectories))
                    Parallel.ForEach(directory.GetFiles("*.*", searchOption: SearchOption.AllDirectories), new ParallelOptions { MaxDegreeOfParallelism = Convert.ToInt32(Math.Ceiling((Environment.ProcessorCount * 0.75) * 1.0)) }, async finfo =>
                    {
                        //var finfo = new FileInfo(file);
                        this.Invoke(new MethodInvoker(delegate
                        {
                            Error_RichTextBox.Text += "\nRunning " + finfo.Name;

                        }));
                       
                        switch (finfo.Extension.ToLower())
                        {
                            case ".txt":
                            case ".tsv":
                                var filelines = File.ReadAllLines(finfo.FullName).ToList();
                                try
                                {
                                    var delimiter = await DataHelper.DetermineFileDelimiter(finfo.Extension, filelines);
                                    if (delimiter == "unknown" || delimiter == null)
                                    {
                                        throw new Exception("Unable to determine Delimiter");
                                    }
                                    var rows = await DataHelper.GetWorkSheetdataAsList(null, filelines: filelines, delimiter: delimiter);
                                    var dt = await DataHelper.FillDataTableFromList(rows, headerrow);
                                    var tablename = $"{finfo.Name.Replace(finfo.Extension, "")}_{DateTime.Now.Ticks}";
                                    var dtheaders = new List<string>();
                                    foreach (var column in dt.Columns)
                                    {

                                        dtheaders.Add(column.ToString());
                                    }
                                    await SQLHELPER.CreateTable(ServerName, DataBaseName, tablename, dtheaders, true);
                                    await DataHelper.InsertProcessedData(dt, ServerName, DataBaseName, tablename);

                                    dt.Dispose();
                                    dtheaders.Clear();
                                }
                                catch (Exception e)
                                {
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        Error_RichTextBox.Text += $"\n Error: {finfo.Name}\n Message: {e.Message}";
                                        Error_RichTextBox.ScrollToCaret();
                                        ErrorList.Add(finfo.Name,e.Message);

                                    }));
                                    
                                }

                                break;
                            case ".csv":
                                var opts = new CsvDataReaderOptions
                                {
                                    HasHeaders = false
                                };
                                using (var csv = CsvDataReader.Create(finfo.FullName, opts))
                                {
                                    try
                                    {
                                        var rows = await DataHelper.GetWorkSheetdataAsList(null, csv: csv);
                                        var dt = await DataHelper.FillDataTableFromList(rows, headerrow);
                                        var tablename = $"{finfo.Name.Replace(finfo.Extension, "")}_{DateTime.Now.Ticks}";
                                        var dtheaders = new List<string>();
                                        foreach (var column in dt.Columns)
                                        {
                                            dtheaders.Add(column.ToString());
                                        }
                                       
                                        await SQLHELPER.CreateTable(ServerName, DataBaseName, tablename, dtheaders, true);
                                        await DataHelper.InsertProcessedData(dt, ServerName, DataBaseName, tablename);

                                        dt.Dispose();
                                        dtheaders.Clear();
                                    }
                                    catch (Exception e)
                                    {
                                        this.Invoke(new MethodInvoker(delegate
                                        {
                                            Error_RichTextBox.Text += $"\n Error: {finfo.Name}\n Message: {e.Message}";
                                            Error_RichTextBox.ScrollToCaret();
                                            ErrorList.Add(finfo.Name,e.Message);

                                        }));
                                        
                                    }

                                }
                                break;
                            case ".xls":
                            case ".xlsx":
                            case ".xlsm":
                            case ".xlsb":

                                var options = new ExcelDataReaderOptions { Schema = ExcelSchema.NoHeaders, GetErrorAsNull = true, ReadHiddenWorksheets = true, DateTimeFormat = "MM/DD/YYYY" };
                                var currentSheetName = "";
                                using (Sylvan.Data.Excel.ExcelDataReader edr = Sylvan.Data.Excel.ExcelDataReader.Create(finfo.FullName, options))
                                {

                                    do
                                    {
                                        currentSheetName = edr.WorksheetName;
                                        try
                                        {
                                            //if (!edr.HasRows)
                                            //{
                                            //    throw new Exception("Worksheet is empty or missing");
                                            //}

                                            var rows = await DataHelper.GetWorkSheetdataAsList(edr);
                                            var dt = await DataHelper.FillDataTableFromList(rows, headerrow);

                                            var tablename = $"{finfo.Name.Replace(finfo.Extension, "")}_{edr.WorksheetName}_{DateTime.Now.Ticks}";
                                            var dtheaders = new List<string>();
                                            foreach (var column in dt.Columns)
                                            {
                                                dtheaders.Add(column.ToString());
                                            }
                                            await SQLHELPER.CreateTable(ServerName, DataBaseName, tablename, dtheaders, true);
                                            await DataHelper.InsertProcessedData(dt, ServerName, DataBaseName, tablename);

                                            dt.Dispose();
                                            dtheaders.Clear();
                                        }
                                        catch (Exception e)
                                        {
                                            this.Invoke(new MethodInvoker(delegate
                                            {
                                                Error_RichTextBox.Text += $"\n Error: {finfo.Name}\n Message: {e.Message}";
                                                Error_RichTextBox.ScrollToCaret();
                                                ErrorList.Add($"{finfo.Name}_{currentSheetName}", e.Message);

                                            }));
                                            
                                        }

                                    }
                                    while (await edr.NextResultAsync());

                                }
                                break;
                        }
                        newFilenames.Add(i.ToString());
                        progressHelper.files = newFilenames;
                        progressHelper.Percentage = (i) * 100 / totalfiles -1;
                        //toshow = (int.Parse(roundcount)) * 100 / totalcount;
                        progress.Report(progressHelper);
                        i += 1;
                    });
                }));
                

                return true;
            }
            catch(Exception e)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    Error_RichTextBox.Text += $"\n Message: {e.Message}\n{e.StackTrace}";
                    Error_RichTextBox.ScrollToCaret();

                }));
                
                return false;
            }
            
        }

        private async Task<bool> ExportErrorsToFile()
        {
            try
            {
               
                       
                using (StreamWriter outfilelocation = new StreamWriter(Import_Textbox.Text + "\\ErrorList.Txt"))
                {

                    foreach (var line in ErrorList)
                    {
                        await outfilelocation.WriteLineAsync($"{line.Key}: {line.Value}");
                    }
                }
            }
            catch(Exception e)
            {
                Error_RichTextBox.Text += $"\n Message: {e.Message}\n{e.StackTrace}";
                Error_RichTextBox.ScrollToCaret();
                MessageBox.Show($"\n Message: {e.Message}\n{e.StackTrace}");
            }
            return true;
        }

        private async  void TestConnection_Button_Click(object sender, EventArgs e)
        {
           await IsServerConnected(Server_TextBox.Text);
        }

        private async void Run_Button_Click(object sender, EventArgs e)
        {
            switch (Data_Tab.SelectedIndex)
            {
                case 0:
                    await SQLHELPER.RunSQLQuery(Query_Box.Text,Server_TextBox.Text,DBCOMBOBOX.Text,Table);
                    break;
                case 1:

                   // MessageBox.Show("Running");
                    
                    await GatherFIleData(Progress);
                    if(ErrorList.Count > 0)
                    {
                        await ExportErrorsToFile();
                    }
                    var errorstoadd = ErrorList.Count > 0 ? "d With Errors" : "!";
                    Error_RichTextBox.Text += $"\n\n\nComplete{errorstoadd}";
                    Error_RichTextBox.ScrollToCaret();
                    // MessageBox.Show("Complete!");
                    break;
            }
            
        }

      

        private async void Export_Button_Click(object sender, EventArgs e)
        {
            switch (Data_Tab.SelectedIndex)
            {
                case 0:
                    var exportWindow = new ExcelMate.Export_Window(Table, SQLHELPER,DataHelper, Server_TextBox.Text, Query_Box.Text, DBCOMBOBOX.Text, Table_Combobox.Text);
                    exportWindow.Show();

                    break;
                case 1:

                    // MessageBox.Show("Running");

                    await GatherFIleData(Progress);
                    if (ErrorList.Count > 0)
                    {
                        await ExportErrorsToFile();
                    }
                    var errorstoadd = ErrorList.Count > 0 ? "d With Errors" : "!";
                    Error_RichTextBox.Text += $"\n\n\nComplete{errorstoadd}";
                    Error_RichTextBox.ScrollToCaret();
                    // MessageBox.Show("Complete!");
                    break;
            }
            
        }
       

        private async void DBCOMBOBOX_Click(object sender, EventArgs e)
        {
            await PopulateComboBox();
        }

        private async void Table_Combobox_Click(object sender, EventArgs e)
        {
            await PopulateTableComboBox();
        }

        private void Clear_Button_Click(object sender, EventArgs e)
        {
            
            Table.Clear();
            Table.AcceptChanges();
            Table.Dispose();
            MessageBox.Show("Tables have been cleared");
        }

        private void OpenFile_Button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;

            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                Import_Textbox.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private async void AddDataBase_Button_Click(object sender, EventArgs e)
        {
            var dialog = new PopUpForm();
            string dbname = "";
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                dbname = dialog.DBNAME;
                //MessageBox.Show(dbname);
                await SQLHELPER.CreateDataBase(Server_TextBox.Text, dbname);
                DBCOMBOBOX.Text = dbname;
            }
        }
        private void ReportProgess(object sender, ProgressBarHelper e)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                progressBar1.Value = e.Percentage;
            }));
        }
    }

}
