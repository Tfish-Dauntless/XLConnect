
namespace XLConnect
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Control_GroupBox = new System.Windows.Forms.GroupBox();
            this.AddDataBase_Button = new System.Windows.Forms.Button();
            this.Table_Combobox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TestConnection_Button = new System.Windows.Forms.Button();
            this.DBCOMBOBOX = new System.Windows.Forms.ComboBox();
            this.Server_TextBox = new System.Windows.Forms.TextBox();
            this.DataBase_ComboBox = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Data_Tab = new System.Windows.Forms.TabControl();
            this.Import_Tab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Error_RichTextBox = new System.Windows.Forms.RichTextBox();
            this.Options_GroupBox = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Delimiter_TextBox = new System.Windows.Forms.TextBox();
            this.Delimiter_Label = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.headerRow_Label = new System.Windows.Forms.Label();
            this.headerRow_TextBox = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.SheetSpecification_Label = new System.Windows.Forms.Label();
            this.SheetName_TextBox = new System.Windows.Forms.TextBox();
            this.File_GroupBox = new System.Windows.Forms.GroupBox();
            this.Import_Textbox = new System.Windows.Forms.TextBox();
            this.OpenFile_Button = new System.Windows.Forms.Button();
            this.TableDump_tab = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.Headers_GroupBox = new System.Windows.Forms.GroupBox();
            this.headers_listbox = new System.Windows.Forms.ListBox();
            this.orderby_GroupBox = new System.Windows.Forms.GroupBox();
            this.Export_Tab = new System.Windows.Forms.TabPage();
            this.Query_GroupBox = new System.Windows.Forms.GroupBox();
            this.Query_Box = new System.Windows.Forms.RichTextBox();
            this.Action_GroupBox = new System.Windows.Forms.GroupBox();
            this.Clear_Button = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Export_Button = new System.Windows.Forms.Button();
            this.Run_Button = new System.Windows.Forms.Button();
            this.sortOrder_ListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.Control_GroupBox.SuspendLayout();
            this.Data_Tab.SuspendLayout();
            this.Import_Tab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.Options_GroupBox.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.File_GroupBox.SuspendLayout();
            this.TableDump_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.Headers_GroupBox.SuspendLayout();
            this.orderby_GroupBox.SuspendLayout();
            this.Export_Tab.SuspendLayout();
            this.Query_GroupBox.SuspendLayout();
            this.Action_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Control_GroupBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Data_Tab);
            this.splitContainer1.Panel2.Controls.Add(this.Action_GroupBox);
            this.splitContainer1.Size = new System.Drawing.Size(800, 687);
            this.splitContainer1.SplitterDistance = 79;
            this.splitContainer1.TabIndex = 0;
            // 
            // Control_GroupBox
            // 
            this.Control_GroupBox.Controls.Add(this.AddDataBase_Button);
            this.Control_GroupBox.Controls.Add(this.Table_Combobox);
            this.Control_GroupBox.Controls.Add(this.label2);
            this.Control_GroupBox.Controls.Add(this.TestConnection_Button);
            this.Control_GroupBox.Controls.Add(this.DBCOMBOBOX);
            this.Control_GroupBox.Controls.Add(this.Server_TextBox);
            this.Control_GroupBox.Controls.Add(this.DataBase_ComboBox);
            this.Control_GroupBox.Controls.Add(this.label1);
            this.Control_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Control_GroupBox.Location = new System.Drawing.Point(0, 0);
            this.Control_GroupBox.Name = "Control_GroupBox";
            this.Control_GroupBox.Size = new System.Drawing.Size(800, 79);
            this.Control_GroupBox.TabIndex = 0;
            this.Control_GroupBox.TabStop = false;
            this.Control_GroupBox.Text = "SQLConnection";
            // 
            // AddDataBase_Button
            // 
            this.AddDataBase_Button.Location = new System.Drawing.Point(681, 22);
            this.AddDataBase_Button.Name = "AddDataBase_Button";
            this.AddDataBase_Button.Size = new System.Drawing.Size(52, 21);
            this.AddDataBase_Button.TabIndex = 7;
            this.AddDataBase_Button.Text = "+";
            this.AddDataBase_Button.UseVisualStyleBackColor = true;
            this.AddDataBase_Button.Click += new System.EventHandler(this.AddDataBase_Button_Click);
            // 
            // Table_Combobox
            // 
            this.Table_Combobox.FormattingEnabled = true;
            this.Table_Combobox.Location = new System.Drawing.Point(316, 51);
            this.Table_Combobox.Name = "Table_Combobox";
            this.Table_Combobox.Size = new System.Drawing.Size(359, 21);
            this.Table_Combobox.TabIndex = 6;
            this.Table_Combobox.SelectedIndexChanged += new System.EventHandler(this.Table_Combobox_SelectedIndexChanged);
            this.Table_Combobox.SelectedValueChanged += new System.EventHandler(this.Table_Combobox_SelectedValueChanged);
            this.Table_Combobox.Click += new System.EventHandler(this.Table_Combobox_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Table:";
            // 
            // TestConnection_Button
            // 
            this.TestConnection_Button.Location = new System.Drawing.Point(83, 48);
            this.TestConnection_Button.Name = "TestConnection_Button";
            this.TestConnection_Button.Size = new System.Drawing.Size(111, 25);
            this.TestConnection_Button.TabIndex = 4;
            this.TestConnection_Button.Text = "Test Connection";
            this.TestConnection_Button.UseVisualStyleBackColor = true;
            this.TestConnection_Button.Visible = false;
            this.TestConnection_Button.Click += new System.EventHandler(this.TestConnection_Button_Click);
            // 
            // DBCOMBOBOX
            // 
            this.DBCOMBOBOX.FormattingEnabled = true;
            this.DBCOMBOBOX.Location = new System.Drawing.Point(316, 22);
            this.DBCOMBOBOX.Name = "DBCOMBOBOX";
            this.DBCOMBOBOX.Size = new System.Drawing.Size(359, 21);
            this.DBCOMBOBOX.TabIndex = 3;
            this.DBCOMBOBOX.Click += new System.EventHandler(this.DBCOMBOBOX_Click);
            // 
            // Server_TextBox
            // 
            this.Server_TextBox.Location = new System.Drawing.Point(59, 22);
            this.Server_TextBox.Name = "Server_TextBox";
            this.Server_TextBox.Size = new System.Drawing.Size(169, 20);
            this.Server_TextBox.TabIndex = 2;
            // 
            // DataBase_ComboBox
            // 
            this.DataBase_ComboBox.AutoSize = true;
            this.DataBase_ComboBox.Location = new System.Drawing.Point(250, 25);
            this.DataBase_ComboBox.Name = "DataBase_ComboBox";
            this.DataBase_ComboBox.Size = new System.Drawing.Size(60, 13);
            this.DataBase_ComboBox.TabIndex = 1;
            this.DataBase_ComboBox.Text = "Data Base:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server:";
            // 
            // Data_Tab
            // 
            this.Data_Tab.Controls.Add(this.Import_Tab);
            this.Data_Tab.Controls.Add(this.TableDump_tab);
            this.Data_Tab.Controls.Add(this.Export_Tab);
            this.Data_Tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Data_Tab.Location = new System.Drawing.Point(0, 0);
            this.Data_Tab.Name = "Data_Tab";
            this.Data_Tab.SelectedIndex = 0;
            this.Data_Tab.Size = new System.Drawing.Size(800, 492);
            this.Data_Tab.TabIndex = 1;
            // 
            // Import_Tab
            // 
            this.Import_Tab.Controls.Add(this.panel1);
            this.Import_Tab.Location = new System.Drawing.Point(4, 22);
            this.Import_Tab.Name = "Import_Tab";
            this.Import_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.Import_Tab.Size = new System.Drawing.Size(792, 466);
            this.Import_Tab.TabIndex = 1;
            this.Import_Tab.Text = "Import From File(s)";
            this.Import_Tab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.File_GroupBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 460);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.Options_GroupBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(786, 414);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Error_RichTextBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(786, 366);
            this.panel3.TabIndex = 1;
            // 
            // Error_RichTextBox
            // 
            this.Error_RichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Error_RichTextBox.Location = new System.Drawing.Point(0, 0);
            this.Error_RichTextBox.Name = "Error_RichTextBox";
            this.Error_RichTextBox.Size = new System.Drawing.Size(786, 366);
            this.Error_RichTextBox.TabIndex = 0;
            this.Error_RichTextBox.Text = "";
            // 
            // Options_GroupBox
            // 
            this.Options_GroupBox.Controls.Add(this.panel5);
            this.Options_GroupBox.Controls.Add(this.panel4);
            this.Options_GroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.Options_GroupBox.Location = new System.Drawing.Point(0, 0);
            this.Options_GroupBox.Name = "Options_GroupBox";
            this.Options_GroupBox.Size = new System.Drawing.Size(786, 48);
            this.Options_GroupBox.TabIndex = 0;
            this.Options_GroupBox.TabStop = false;
            this.Options_GroupBox.Text = "Options";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.Delimiter_TextBox);
            this.panel5.Controls.Add(this.Delimiter_Label);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(346, 16);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(437, 29);
            this.panel5.TabIndex = 5;
            // 
            // Delimiter_TextBox
            // 
            this.Delimiter_TextBox.Location = new System.Drawing.Point(244, 4);
            this.Delimiter_TextBox.Name = "Delimiter_TextBox";
            this.Delimiter_TextBox.Size = new System.Drawing.Size(189, 20);
            this.Delimiter_TextBox.TabIndex = 6;
            this.Delimiter_TextBox.Text = ",";
            // 
            // Delimiter_Label
            // 
            this.Delimiter_Label.AutoSize = true;
            this.Delimiter_Label.Location = new System.Drawing.Point(188, 7);
            this.Delimiter_Label.Name = "Delimiter_Label";
            this.Delimiter_Label.Size = new System.Drawing.Size(50, 13);
            this.Delimiter_Label.TabIndex = 5;
            this.Delimiter_Label.Text = "Delimiter:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.headerRow_Label);
            this.panel6.Controls.Add(this.headerRow_TextBox);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(182, 29);
            this.panel6.TabIndex = 4;
            // 
            // headerRow_Label
            // 
            this.headerRow_Label.AutoSize = true;
            this.headerRow_Label.Location = new System.Drawing.Point(1, 7);
            this.headerRow_Label.Name = "headerRow_Label";
            this.headerRow_Label.Size = new System.Drawing.Size(70, 13);
            this.headerRow_Label.TabIndex = 2;
            this.headerRow_Label.Text = "Header Row:";
            // 
            // headerRow_TextBox
            // 
            this.headerRow_TextBox.Location = new System.Drawing.Point(77, 3);
            this.headerRow_TextBox.Name = "headerRow_TextBox";
            this.headerRow_TextBox.Size = new System.Drawing.Size(100, 20);
            this.headerRow_TextBox.TabIndex = 3;
            this.headerRow_TextBox.Text = "1";
            this.headerRow_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.SheetSpecification_Label);
            this.panel4.Controls.Add(this.SheetName_TextBox);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(3, 16);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(343, 29);
            this.panel4.TabIndex = 4;
            // 
            // SheetSpecification_Label
            // 
            this.SheetSpecification_Label.AutoSize = true;
            this.SheetSpecification_Label.Location = new System.Drawing.Point(0, 6);
            this.SheetSpecification_Label.Name = "SheetSpecification_Label";
            this.SheetSpecification_Label.Size = new System.Drawing.Size(76, 13);
            this.SheetSpecification_Label.TabIndex = 0;
            this.SheetSpecification_Label.Text = "Select Sheets:";
            // 
            // SheetName_TextBox
            // 
            this.SheetName_TextBox.Location = new System.Drawing.Point(81, 4);
            this.SheetName_TextBox.Name = "SheetName_TextBox";
            this.SheetName_TextBox.Size = new System.Drawing.Size(256, 20);
            this.SheetName_TextBox.TabIndex = 1;
            this.SheetName_TextBox.Text = "--Delimit By Semi Colon--";
            // 
            // File_GroupBox
            // 
            this.File_GroupBox.Controls.Add(this.Import_Textbox);
            this.File_GroupBox.Controls.Add(this.OpenFile_Button);
            this.File_GroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.File_GroupBox.Location = new System.Drawing.Point(0, 0);
            this.File_GroupBox.Name = "File_GroupBox";
            this.File_GroupBox.Size = new System.Drawing.Size(786, 46);
            this.File_GroupBox.TabIndex = 0;
            this.File_GroupBox.TabStop = false;
            this.File_GroupBox.Text = "File Information:";
            // 
            // Import_Textbox
            // 
            this.Import_Textbox.Location = new System.Drawing.Point(65, 19);
            this.Import_Textbox.Name = "Import_Textbox";
            this.Import_Textbox.Size = new System.Drawing.Size(715, 20);
            this.Import_Textbox.TabIndex = 1;
            // 
            // OpenFile_Button
            // 
            this.OpenFile_Button.Location = new System.Drawing.Point(5, 19);
            this.OpenFile_Button.Name = "OpenFile_Button";
            this.OpenFile_Button.Size = new System.Drawing.Size(54, 20);
            this.OpenFile_Button.TabIndex = 0;
            this.OpenFile_Button.Text = "...";
            this.OpenFile_Button.UseVisualStyleBackColor = true;
            this.OpenFile_Button.Click += new System.EventHandler(this.OpenFile_Button_Click);
            // 
            // TableDump_tab
            // 
            this.TableDump_tab.Controls.Add(this.splitContainer2);
            this.TableDump_tab.Location = new System.Drawing.Point(4, 22);
            this.TableDump_tab.Name = "TableDump_tab";
            this.TableDump_tab.Padding = new System.Windows.Forms.Padding(3);
            this.TableDump_tab.Size = new System.Drawing.Size(792, 466);
            this.TableDump_tab.TabIndex = 2;
            this.TableDump_tab.Text = "Export Table";
            this.TableDump_tab.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.Headers_GroupBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.orderby_GroupBox);
            this.splitContainer2.Size = new System.Drawing.Size(786, 460);
            this.splitContainer2.SplitterDistance = 342;
            this.splitContainer2.TabIndex = 0;
            // 
            // Headers_GroupBox
            // 
            this.Headers_GroupBox.Controls.Add(this.headers_listbox);
            this.Headers_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Headers_GroupBox.Location = new System.Drawing.Point(0, 0);
            this.Headers_GroupBox.Name = "Headers_GroupBox";
            this.Headers_GroupBox.Size = new System.Drawing.Size(342, 460);
            this.Headers_GroupBox.TabIndex = 0;
            this.Headers_GroupBox.TabStop = false;
            this.Headers_GroupBox.Text = "Columns to export";
            // 
            // headers_listbox
            // 
            this.headers_listbox.AllowDrop = true;
            this.headers_listbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headers_listbox.FormattingEnabled = true;
            this.headers_listbox.Location = new System.Drawing.Point(3, 16);
            this.headers_listbox.Name = "headers_listbox";
            this.headers_listbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.headers_listbox.Size = new System.Drawing.Size(336, 441);
            this.headers_listbox.TabIndex = 0;
            this.headers_listbox.DragDrop += new System.Windows.Forms.DragEventHandler(this.headers_listbox_DragDrop);
            this.headers_listbox.DragOver += new System.Windows.Forms.DragEventHandler(this.headers_listbox_DragOver);
            this.headers_listbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headers_listbox_MouseDown);
            // 
            // orderby_GroupBox
            // 
            this.orderby_GroupBox.Controls.Add(this.sortOrder_ListBox);
            this.orderby_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderby_GroupBox.Location = new System.Drawing.Point(0, 0);
            this.orderby_GroupBox.Name = "orderby_GroupBox";
            this.orderby_GroupBox.Size = new System.Drawing.Size(440, 460);
            this.orderby_GroupBox.TabIndex = 0;
            this.orderby_GroupBox.TabStop = false;
            this.orderby_GroupBox.Text = "Sort Order";
            // 
            // Export_Tab
            // 
            this.Export_Tab.Controls.Add(this.Query_GroupBox);
            this.Export_Tab.Location = new System.Drawing.Point(4, 22);
            this.Export_Tab.Name = "Export_Tab";
            this.Export_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.Export_Tab.Size = new System.Drawing.Size(792, 466);
            this.Export_Tab.TabIndex = 0;
            this.Export_Tab.Text = "Export_Custom_Query";
            this.Export_Tab.UseVisualStyleBackColor = true;
            // 
            // Query_GroupBox
            // 
            this.Query_GroupBox.Controls.Add(this.Query_Box);
            this.Query_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Query_GroupBox.Location = new System.Drawing.Point(3, 3);
            this.Query_GroupBox.Name = "Query_GroupBox";
            this.Query_GroupBox.Size = new System.Drawing.Size(786, 460);
            this.Query_GroupBox.TabIndex = 1;
            this.Query_GroupBox.TabStop = false;
            this.Query_GroupBox.Text = "Query";
            // 
            // Query_Box
            // 
            this.Query_Box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Query_Box.Location = new System.Drawing.Point(3, 16);
            this.Query_Box.Name = "Query_Box";
            this.Query_Box.Size = new System.Drawing.Size(780, 441);
            this.Query_Box.TabIndex = 0;
            this.Query_Box.Text = "";
            // 
            // Action_GroupBox
            // 
            this.Action_GroupBox.Controls.Add(this.Clear_Button);
            this.Action_GroupBox.Controls.Add(this.progressBar1);
            this.Action_GroupBox.Controls.Add(this.Export_Button);
            this.Action_GroupBox.Controls.Add(this.Run_Button);
            this.Action_GroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Action_GroupBox.Location = new System.Drawing.Point(0, 492);
            this.Action_GroupBox.Name = "Action_GroupBox";
            this.Action_GroupBox.Size = new System.Drawing.Size(800, 112);
            this.Action_GroupBox.TabIndex = 0;
            this.Action_GroupBox.TabStop = false;
            this.Action_GroupBox.Text = "Actions";
            // 
            // Clear_Button
            // 
            this.Clear_Button.Location = new System.Drawing.Point(520, 19);
            this.Clear_Button.Name = "Clear_Button";
            this.Clear_Button.Size = new System.Drawing.Size(116, 28);
            this.Clear_Button.TabIndex = 3;
            this.Clear_Button.Text = "Clear";
            this.Clear_Button.UseVisualStyleBackColor = true;
            this.Clear_Button.Click += new System.EventHandler(this.Clear_Button_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(3, 86);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(794, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // Export_Button
            // 
            this.Export_Button.Location = new System.Drawing.Point(346, 19);
            this.Export_Button.Name = "Export_Button";
            this.Export_Button.Size = new System.Drawing.Size(116, 28);
            this.Export_Button.TabIndex = 1;
            this.Export_Button.Text = "Export";
            this.Export_Button.UseVisualStyleBackColor = true;
            this.Export_Button.Click += new System.EventHandler(this.Export_Button_Click);
            // 
            // Run_Button
            // 
            this.Run_Button.Location = new System.Drawing.Point(173, 19);
            this.Run_Button.Name = "Run_Button";
            this.Run_Button.Size = new System.Drawing.Size(114, 28);
            this.Run_Button.TabIndex = 0;
            this.Run_Button.Text = "Run";
            this.Run_Button.UseVisualStyleBackColor = true;
            this.Run_Button.Click += new System.EventHandler(this.Run_Button_Click);
            // 
            // sortOrder_ListBox
            // 
            this.sortOrder_ListBox.AllowDrop = true;
            this.sortOrder_ListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sortOrder_ListBox.FormattingEnabled = true;
            this.sortOrder_ListBox.Location = new System.Drawing.Point(3, 16);
            this.sortOrder_ListBox.Name = "sortOrder_ListBox";
            this.sortOrder_ListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.sortOrder_ListBox.Size = new System.Drawing.Size(434, 441);
            this.sortOrder_ListBox.TabIndex = 0;
            this.sortOrder_ListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.sortOrder_ListBox_DragDrop);
            this.sortOrder_ListBox.DragOver += new System.Windows.Forms.DragEventHandler(this.sortOrder_ListBox_DragOver);
            this.sortOrder_ListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sortOrder_ListBox_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 687);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.Control_GroupBox.ResumeLayout(false);
            this.Control_GroupBox.PerformLayout();
            this.Data_Tab.ResumeLayout(false);
            this.Import_Tab.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.Options_GroupBox.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.File_GroupBox.ResumeLayout(false);
            this.File_GroupBox.PerformLayout();
            this.TableDump_tab.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.Headers_GroupBox.ResumeLayout(false);
            this.orderby_GroupBox.ResumeLayout(false);
            this.Export_Tab.ResumeLayout(false);
            this.Query_GroupBox.ResumeLayout(false);
            this.Action_GroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox Control_GroupBox;
        private System.Windows.Forms.Button TestConnection_Button;
        private System.Windows.Forms.ComboBox DBCOMBOBOX;
        private System.Windows.Forms.TextBox Server_TextBox;
        private System.Windows.Forms.Label DataBase_ComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Query_GroupBox;
        private System.Windows.Forms.RichTextBox Query_Box;
        private System.Windows.Forms.GroupBox Action_GroupBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button Export_Button;
        private System.Windows.Forms.Button Run_Button;
        private System.Windows.Forms.ComboBox Table_Combobox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Clear_Button;
        private System.Windows.Forms.TabControl Data_Tab;
        private System.Windows.Forms.TabPage Export_Tab;
        private System.Windows.Forms.TabPage Import_Tab;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox File_GroupBox;
        private System.Windows.Forms.TextBox Import_Textbox;
        private System.Windows.Forms.Button OpenFile_Button;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox Options_GroupBox;
        private System.Windows.Forms.Label SheetSpecification_Label;
        private System.Windows.Forms.TextBox headerRow_TextBox;
        private System.Windows.Forms.Label headerRow_Label;
        private System.Windows.Forms.TextBox SheetName_TextBox;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox Delimiter_TextBox;
        private System.Windows.Forms.Label Delimiter_Label;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RichTextBox Error_RichTextBox;
        private System.Windows.Forms.Button AddDataBase_Button;
        private System.Windows.Forms.TabPage TableDump_tab;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox Headers_GroupBox;
        private System.Windows.Forms.ListBox headers_listbox;
        private System.Windows.Forms.GroupBox orderby_GroupBox;
        private System.Windows.Forms.ListBox sortOrder_ListBox;
    }
}

