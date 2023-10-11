
namespace ExcelMate
{
    partial class Export_Window
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
            this.components = new System.ComponentModel.Container();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ExportLocation_TextBox = new System.Windows.Forms.TextBox();
            this.ExportLocation_Button = new System.Windows.Forms.Button();
            this.RowsPerSheet_NumBox = new System.Windows.Forms.NumericUpDown();
            this.Export_Btn = new System.Windows.Forms.Button();
            this.MaxRowSize_CheckBox = new System.Windows.Forms.CheckBox();
            this.RowsToExport = new System.Windows.Forms.Label();
            this.ExportCount_Label = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Location_GroupBox = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.Actions_GroupBox = new System.Windows.Forms.GroupBox();
            this.Settings_GroupBox = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Delimiter_TextBox = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ExportType_ComboBox = new System.Windows.Forms.ComboBox();
            this.ExportType_Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.Qualifier_TextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.RowsPerSheet_NumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.Location_GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.Actions_GroupBox.SuspendLayout();
            this.Settings_GroupBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(250, 175);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(345, 29);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 6;
            // 
            // ExportLocation_TextBox
            // 
            this.ExportLocation_TextBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.ExportLocation_TextBox.Location = new System.Drawing.Point(35, 16);
            this.ExportLocation_TextBox.Name = "ExportLocation_TextBox";
            this.ExportLocation_TextBox.Size = new System.Drawing.Size(707, 20);
            this.ExportLocation_TextBox.TabIndex = 0;
            // 
            // ExportLocation_Button
            // 
            this.ExportLocation_Button.Location = new System.Drawing.Point(6, 15);
            this.ExportLocation_Button.Name = "ExportLocation_Button";
            this.ExportLocation_Button.Size = new System.Drawing.Size(26, 22);
            this.ExportLocation_Button.TabIndex = 2;
            this.ExportLocation_Button.Text = "...";
            this.ExportLocation_Button.UseVisualStyleBackColor = true;
            this.ExportLocation_Button.Click += new System.EventHandler(this.ExportLocation_Button_Click);
            // 
            // RowsPerSheet_NumBox
            // 
            this.RowsPerSheet_NumBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.RowsPerSheet_NumBox.Location = new System.Drawing.Point(92, 0);
            this.RowsPerSheet_NumBox.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.RowsPerSheet_NumBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RowsPerSheet_NumBox.Name = "RowsPerSheet_NumBox";
            this.RowsPerSheet_NumBox.Size = new System.Drawing.Size(147, 20);
            this.RowsPerSheet_NumBox.TabIndex = 3;
            this.RowsPerSheet_NumBox.Value = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.RowsPerSheet_NumBox.Visible = false;
            // 
            // Export_Btn
            // 
            this.Export_Btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Export_Btn.Location = new System.Drawing.Point(3, 252);
            this.Export_Btn.Name = "Export_Btn";
            this.Export_Btn.Size = new System.Drawing.Size(106, 40);
            this.Export_Btn.TabIndex = 5;
            this.Export_Btn.Text = "Export";
            this.Export_Btn.UseVisualStyleBackColor = true;
            this.Export_Btn.Click += new System.EventHandler(this.Export_Btn_Click);
            // 
            // MaxRowSize_CheckBox
            // 
            this.MaxRowSize_CheckBox.AutoSize = true;
            this.MaxRowSize_CheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.MaxRowSize_CheckBox.Location = new System.Drawing.Point(0, 0);
            this.MaxRowSize_CheckBox.Name = "MaxRowSize_CheckBox";
            this.MaxRowSize_CheckBox.Size = new System.Drawing.Size(76, 24);
            this.MaxRowSize_CheckBox.TabIndex = 6;
            this.MaxRowSize_CheckBox.Text = "Max Rows";
            this.MaxRowSize_CheckBox.UseVisualStyleBackColor = true;
            this.MaxRowSize_CheckBox.CheckedChanged += new System.EventHandler(this.MaxRowSize_CheckBox_CheckedChanged);
            this.MaxRowSize_CheckBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MaxRowSize_CheckBox_MouseMove);
            // 
            // RowsToExport
            // 
            this.RowsToExport.AutoSize = true;
            this.RowsToExport.Location = new System.Drawing.Point(48, 226);
            this.RowsToExport.Name = "RowsToExport";
            this.RowsToExport.Size = new System.Drawing.Size(83, 13);
            this.RowsToExport.TabIndex = 7;
            this.RowsToExport.Text = "Rows To Export";
            // 
            // ExportCount_Label
            // 
            this.ExportCount_Label.AutoSize = true;
            this.ExportCount_Label.Location = new System.Drawing.Point(130, 226);
            this.ExportCount_Label.Name = "ExportCount_Label";
            this.ExportCount_Label.Size = new System.Drawing.Size(68, 13);
            this.ExportCount_Label.TabIndex = 8;
            this.ExportCount_Label.Text = "Export Count";
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.RowsToExport);
            this.splitContainer1.Panel2.Controls.Add(this.progressBar1);
            this.splitContainer1.Panel2.Controls.Add(this.ExportCount_Label);
            this.splitContainer1.Size = new System.Drawing.Size(861, 590);
            this.splitContainer1.SplitterDistance = 295;
            this.splitContainer1.TabIndex = 9;
            // 
            // Location_GroupBox
            // 
            this.Location_GroupBox.Controls.Add(this.ExportLocation_TextBox);
            this.Location_GroupBox.Controls.Add(this.ExportLocation_Button);
            this.Location_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location_GroupBox.Location = new System.Drawing.Point(0, 0);
            this.Location_GroupBox.Name = "Location_GroupBox";
            this.Location_GroupBox.Size = new System.Drawing.Size(745, 43);
            this.Location_GroupBox.TabIndex = 9;
            this.Location_GroupBox.TabStop = false;
            this.Location_GroupBox.Text = "Export Location";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.Actions_GroupBox);
            this.splitContainer2.Size = new System.Drawing.Size(861, 295);
            this.splitContainer2.SplitterDistance = 745;
            this.splitContainer2.TabIndex = 10;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.Location_GroupBox);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.Settings_GroupBox);
            this.splitContainer3.Size = new System.Drawing.Size(745, 295);
            this.splitContainer3.SplitterDistance = 43;
            this.splitContainer3.TabIndex = 10;
            // 
            // Actions_GroupBox
            // 
            this.Actions_GroupBox.Controls.Add(this.Export_Btn);
            this.Actions_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Actions_GroupBox.Location = new System.Drawing.Point(0, 0);
            this.Actions_GroupBox.Name = "Actions_GroupBox";
            this.Actions_GroupBox.Size = new System.Drawing.Size(112, 295);
            this.Actions_GroupBox.TabIndex = 0;
            this.Actions_GroupBox.TabStop = false;
            this.Actions_GroupBox.Text = "Actions";
            // 
            // Settings_GroupBox
            // 
            this.Settings_GroupBox.Controls.Add(this.panel4);
            this.Settings_GroupBox.Controls.Add(this.panel2);
            this.Settings_GroupBox.Controls.Add(this.panel1);
            this.Settings_GroupBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.Settings_GroupBox.Location = new System.Drawing.Point(0, 0);
            this.Settings_GroupBox.Name = "Settings_GroupBox";
            this.Settings_GroupBox.Size = new System.Drawing.Size(245, 248);
            this.Settings_GroupBox.TabIndex = 7;
            this.Settings_GroupBox.TabStop = false;
            this.Settings_GroupBox.Text = "Settings";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MaxRowSize_CheckBox);
            this.panel1.Controls.Add(this.RowsPerSheet_NumBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(239, 24);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(239, 169);
            this.panel2.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.Delimiter_TextBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(239, 36);
            this.panel3.TabIndex = 1;
            // 
            // Delimiter_TextBox
            // 
            this.Delimiter_TextBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.Delimiter_TextBox.Location = new System.Drawing.Point(92, 0);
            this.Delimiter_TextBox.Name = "Delimiter_TextBox";
            this.Delimiter_TextBox.Size = new System.Drawing.Size(147, 20);
            this.Delimiter_TextBox.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ExportType_Label);
            this.panel4.Controls.Add(this.ExportType_ComboBox);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(239, 36);
            this.panel4.TabIndex = 9;
            // 
            // ExportType_ComboBox
            // 
            this.ExportType_ComboBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.ExportType_ComboBox.FormattingEnabled = true;
            this.ExportType_ComboBox.ItemHeight = 13;
            this.ExportType_ComboBox.Items.AddRange(new object[] {
            "XLSX",
            "CSV",
            "TXT"});
            this.ExportType_ComboBox.Location = new System.Drawing.Point(92, 0);
            this.ExportType_ComboBox.Name = "ExportType_ComboBox";
            this.ExportType_ComboBox.Size = new System.Drawing.Size(147, 21);
            this.ExportType_ComboBox.TabIndex = 0;
            // 
            // ExportType_Label
            // 
            this.ExportType_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExportType_Label.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ExportType_Label.Location = new System.Drawing.Point(0, 0);
            this.ExportType_Label.Name = "ExportType_Label";
            this.ExportType_Label.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.ExportType_Label.Size = new System.Drawing.Size(92, 36);
            this.ExportType_Label.TabIndex = 1;
            this.ExportType_Label.Text = "Export Type:";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label1.Size = new System.Drawing.Size(57, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Delimiter:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 36);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(239, 133);
            this.panel5.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.Qualifier_TextBox);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(239, 36);
            this.panel6.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label2.Size = new System.Drawing.Size(86, 36);
            this.label2.TabIndex = 3;
            this.label2.Text = "Quote Qualifier";
            // 
            // Qualifier_TextBox
            // 
            this.Qualifier_TextBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.Qualifier_TextBox.Location = new System.Drawing.Point(92, 0);
            this.Qualifier_TextBox.Name = "Qualifier_TextBox";
            this.Qualifier_TextBox.Size = new System.Drawing.Size(147, 20);
            this.Qualifier_TextBox.TabIndex = 2;
            // 
            // Export_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 590);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Export_Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export_Window";
            ((System.ComponentModel.ISupportInitialize)(this.RowsPerSheet_NumBox)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.Location_GroupBox.ResumeLayout(false);
            this.Location_GroupBox.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.Actions_GroupBox.ResumeLayout(false);
            this.Settings_GroupBox.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox ExportLocation_TextBox;
        private System.Windows.Forms.Button ExportLocation_Button;
        private System.Windows.Forms.NumericUpDown RowsPerSheet_NumBox;
        private System.Windows.Forms.Button Export_Btn;
        private System.Windows.Forms.CheckBox MaxRowSize_CheckBox;
        private System.Windows.Forms.Label RowsToExport;
        private System.Windows.Forms.Label ExportCount_Label;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox Location_GroupBox;
        private System.Windows.Forms.GroupBox Settings_GroupBox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label ExportType_Label;
        private System.Windows.Forms.ComboBox ExportType_ComboBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Qualifier_TextBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Delimiter_TextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox Actions_GroupBox;
    }
}