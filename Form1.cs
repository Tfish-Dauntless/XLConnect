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
        private Dictionary<string, string> ErrorList = new Dictionary<string, string>();
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
        private async Task<bool> validateServerName()
        {
            try
            {
                var servernameActual = System.Environment.MachineName.ToUpper() == "DEVMACHINE" ? "LocalHost" : "Proc-SQL01";
                Server_TextBox.Text = servernameActual;
                await IsServerConnected(servernameActual);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

        }
        private async Task<bool> IsServerConnected(string server)
        {

            string connectionString = @"Data Source=" + server + ";Initial Catalog=Master;Integrated Security=True;";
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
                    connectionerror = false;
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
                    haserror = true;
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
                    string query = "use [" + DBCOMBOBOX.Text + "] SELECT name FROM sys.tables";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();
                    DataTable dt = new DataTable();
                    da.Fill(dt);


                    for (var r = 0; r < dt.Rows.Count; r++)
                    {
                        if (!Table_Combobox.Items.Contains(dt.Rows[r][0].ToString()))
                        {
                            Table_Combobox.Items.Add(dt.Rows[r][0].ToString());
                        }
                    }

                    Table_Combobox.DisplayMember = "name";
                    Table_Combobox.ValueMember = "name";

                    Export_Button.Visible = true;
                    Clear_Button.Visible = true;
                    dt.Dispose();
                }
                catch (Exception ex)
                {
                    // write exception info to log or anything else
                    MessageBox.Show($"Error occured!\n{ex.Message}\n{ex.StackTrace}");
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
                                        ErrorList.Add(finfo.Name, e.Message);

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
                                            ErrorList.Add(finfo.Name, e.Message);

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
                        progressHelper.Percentage = (i) * 100 / totalfiles - 1;
                        //toshow = (int.Parse(roundcount)) * 100 / totalcount;
                        progress.Report(progressHelper);
                        i += 1;
                    });
                }));


                return true;
            }
            catch (Exception e)
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
            catch (Exception e)
            {
                Error_RichTextBox.Text += $"\n Message: {e.Message}\n{e.StackTrace}";
                Error_RichTextBox.ScrollToCaret();
                MessageBox.Show($"\n Message: {e.Message}\n{e.StackTrace}");
            }
            return true;
        }

        private async void TestConnection_Button_Click(object sender, EventArgs e)
        {
            await IsServerConnected(Server_TextBox.Text);
        }

        private async void Run_Button_Click(object sender, EventArgs e)
        {
            switch (Data_Tab.SelectedIndex)
            {
                case 0:
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



        private async void Export_Button_Click(object sender, EventArgs e)
        {
            switch (Data_Tab.SelectedIndex)
            {
                case 0:
                    
                    break;
                case 1:

                    if(headers_listbox.SelectedItems.Count <= 0)
                    {
                        for(var si = 0;si <  headers_listbox.Items.Count; si++)
                        {
                            headers_listbox.SetSelected(si, true);
                        }
                    }

                    List<string> adjustedHeaders = new List<string>();
                    List<string> RawHeaders = new List<string>();

                    for(var i=0; i< headers_listbox.SelectedItems.Count; i++)
                    {
                        var formattedHeader = $"NULLIF({headers_listbox.SelectedItems[i]},'') [{headers_listbox.SelectedItems[i]}]";
                        adjustedHeaders.Add(formattedHeader);
                        RawHeaders.Add(headers_listbox.SelectedItems[i].ToString());
                    }
                    var orderby = "";
                    List<string> orderBYFields = new List<string>();
                    //$"USE [{DBCOMBOBOX.Text}]   Select {String.Join(",", adjustedHeaders)} FROM {Table_Combobox.Text} \n {orderby}";
                    if (sortOrder_ListBox.Items.Count > 0)
                    {
                        
                        for(var ob = 0; ob < sortOrder_ListBox.Items.Count; ob++)
                        {
                            var adjusteditem = $"[{sortOrder_ListBox.Items[ob]}]";
                            if (!orderBYFields.Contains(adjusteditem))
                            {
                                orderBYFields.Add(adjusteditem);
                            }
                        }
                        orderby = $"  ORDER BY {String.Join(",", orderBYFields)}";
                    }
                    //var orderby = sortOrder_ListBox.Items.Count <= 0 ? "" : $"  ORDER BY [{String.Join("],[", sortOrder_ListBox.Items)}]";
                    var query = $"USE [{DBCOMBOBOX.Text}]   Select {String.Join(",", adjustedHeaders)} FROM {Table_Combobox.Text} {orderby}";

                    MessageBox.Show(query);
                    var TableexportWindow = new ExcelMate.Export_Window(Table, SQLHELPER, DataHelper, Server_TextBox.Text, query, DBCOMBOBOX.Text, Table_Combobox.Text,true, RawHeaders);
                    TableexportWindow.Show();
                    if(TableexportWindow.DialogResult == DialogResult.OK || TableexportWindow.DialogResult == DialogResult.Cancel)
                    {
                        RawHeaders.Clear();
                        adjustedHeaders.Clear();
                        TableexportWindow.Dispose();
                    }
                    
                    break;
                case 2:
                    var exportWindow = new ExcelMate.Export_Window(Table, SQLHELPER, DataHelper, Server_TextBox.Text, Query_Box.Text, DBCOMBOBOX.Text, Table_Combobox.Text);
                    exportWindow.Show();
                    if (exportWindow.DialogResult == DialogResult.OK || exportWindow.DialogResult == DialogResult.Cancel)
                    {
                        exportWindow.Dispose();
                    }
                    break;
            }

        }


        private async void DBCOMBOBOX_Click(object sender, EventArgs e)
        {
            headers_listbox.Items.Clear();
            sortOrder_ListBox.Items.Clear();
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



        private void headers_listbox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1 && ModifierKeys == Keys.None)
            {
                if (this.headers_listbox.SelectedItem == null) return;
                this.headers_listbox.DoDragDrop(this.headers_listbox.SelectedItem, DragDropEffects.Move);
            }
            //if (e.Button == MouseButtons.Right && e.Clicks == 1)
            //{
            //    if (this.headers_listbox.SelectedItem == null) return;
            //    this.sortOrder_ListBox.DoDragDrop(this.headers_listbox.SelectedItem, DragDropEffects.Copy);
            //}

            //this.sortOrder_ListBox.DoDragDrop(this.headers_listbox.SelectedItem, DragDropEffects.Copy);
        }

        private void headers_listbox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            //var hoveredindex = headers_listbox.IndexFromPoint(headers_listbox.PointToClient(Cursor.Position));
            //headers_listbox.sele
        }

        private void headers_listbox_DragDrop(object sender, DragEventArgs e)
        {
            Point point = headers_listbox.PointToClient(new Point(e.X, e.Y));
            int index = this.headers_listbox.IndexFromPoint(point);
            if (index < 0) index = this.headers_listbox.Items.Count - 1;
            object eventItem = e.Data.GetData(typeof(String));
            //MessageBox.Show($"Event Item: {eventItem}\neventData: {e.Data.GetData(typeof(String))}");
            this.headers_listbox.Items.Remove(eventItem);
            this.headers_listbox.Items.Insert(index, eventItem);
        }

        private void sortOrder_ListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.sortOrder_ListBox.SelectedItem == null) return;
            this.sortOrder_ListBox.DoDragDrop(this.sortOrder_ListBox.SelectedItem, DragDropEffects.Move);
        }

        private void sortOrder_ListBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            
        }

        private void sortOrder_ListBox_DragDrop(object sender, DragEventArgs e)
        {
            Point point = sortOrder_ListBox.PointToClient(new Point(e.X, e.Y));
            int index = this.sortOrder_ListBox.IndexFromPoint(point);
            if (index < 0) index = this.sortOrder_ListBox.Items.Count - 1;
            object eventItem = e.Data.GetData(typeof(String));
            //MessageBox.Show($"Event Item: {eventItem}\neventData: {e.Data.GetData(typeof(String))}");
            this.sortOrder_ListBox.Items.Remove(eventItem);
            this.sortOrder_ListBox.Items.Insert(index, eventItem);
        }

        private async void Table_Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            


        }

        private async void Table_Combobox_SelectedValueChanged(object sender, EventArgs e)
        {
            
            headers_listbox.Items.Clear();
            sortOrder_ListBox.Items.Clear();

            var columns = await SQLHELPER.GatherSqlColumns(Server_TextBox.Text, DBCOMBOBOX.Text, Table_Combobox.Text);
            //MessageBox.Show(String.Join(";", columns));
            foreach (var column in columns)
            {
                headers_listbox.Items.Add(column);
            }
        }



        private void headers_listbox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.headers_listbox.IndexFromPoint(e.Location);
            if (!sortOrder_ListBox.Items.Contains(headers_listbox.Items[index]))
            {
                sortOrder_ListBox.Items.Add(headers_listbox.Items[index]);
            }
        }

        private void sortOrder_ListBox_KeyUp(object sender, KeyEventArgs e)
        {
            //MessageBox.Show($"KeyCode: {e.KeyCode.ToString()}\nKeyValue: {e.KeyValue.ToString()}\n SupressentKey: {e.SuppressKeyPress}");
            if(e.KeyCode == Keys.Delete)
            {
                //MessageBox.Show($"KeyCode: {e.KeyCode.ToString()}\nKeyValue: {e.KeyValue.ToString()}\n SupressentKey: {e.SuppressKeyPress}\nSelectedIndex {sortOrder_ListBox.SelectedIndex}");
                if (sortOrder_ListBox.SelectedIndex < 0)
                {
                    MessageBox.Show($"KeyCode: {e.KeyCode.ToString()}\nKeyValue: {e.KeyValue.ToString()}\n SupressentKey: {e.SuppressKeyPress}\nSelectedIndex {sortOrder_ListBox.SelectedIndex}");
                    return;
                }

                var index = sortOrder_ListBox.SelectedIndex;
                sortOrder_ListBox.Items.RemoveAt(index);
            }
            
        }

        private void headers_listbox_MouseHover(object sender, EventArgs e)
        {
           // if(headers_listbox.Items.Count <= 0)
           // {
           //     return;
           // }

           // Point point = headers_listbox.PointToClient(Cursor.Position);
           // int index = headers_listbox.IndexFromPoint(point);
           // if (index <= 0) return;

           //// headers_listbox.Items[index]dray


           // var rect = headers_listbox.GetItemRectangle(index);
           // rect.Inflate(0, 10);
        }
    }
    
}
