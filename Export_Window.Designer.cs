
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Excel_Tab = new System.Windows.Forms.TabPage();
            this.MaxRowSize_CheckBox = new System.Windows.Forms.CheckBox();
            this.Export_Btn = new System.Windows.Forms.Button();
            this.MaxRows_Label = new System.Windows.Forms.Label();
            this.RowsPerSheet_NumBox = new System.Windows.Forms.NumericUpDown();
            this.ExportLocation_Button = new System.Windows.Forms.Button();
            this.ExportLocation_Label = new System.Windows.Forms.Label();
            this.ExportLocation_TextBox = new System.Windows.Forms.TextBox();
            this.SQL_Tab = new System.Windows.Forms.TabPage();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.RowsToExport = new System.Windows.Forms.Label();
            this.ExportCount_Label = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.Excel_Tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RowsPerSheet_NumBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Excel_Tab);
            this.tabControl1.Controls.Add(this.SQL_Tab);
            this.tabControl1.Location = new System.Drawing.Point(-5, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(416, 252);
            this.tabControl1.TabIndex = 0;
            // 
            // Excel_Tab
            // 
            this.Excel_Tab.Controls.Add(this.ExportCount_Label);
            this.Excel_Tab.Controls.Add(this.RowsToExport);
            this.Excel_Tab.Controls.Add(this.MaxRowSize_CheckBox);
            this.Excel_Tab.Controls.Add(this.Export_Btn);
            this.Excel_Tab.Controls.Add(this.MaxRows_Label);
            this.Excel_Tab.Controls.Add(this.RowsPerSheet_NumBox);
            this.Excel_Tab.Controls.Add(this.ExportLocation_Button);
            this.Excel_Tab.Controls.Add(this.ExportLocation_Label);
            this.Excel_Tab.Controls.Add(this.ExportLocation_TextBox);
            this.Excel_Tab.Location = new System.Drawing.Point(4, 24);
            this.Excel_Tab.Name = "Excel_Tab";
            this.Excel_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.Excel_Tab.Size = new System.Drawing.Size(408, 224);
            this.Excel_Tab.TabIndex = 0;
            this.Excel_Tab.Text = "Excel";
            this.Excel_Tab.UseVisualStyleBackColor = true;
            // 
            // MaxRowSize_CheckBox
            // 
            this.MaxRowSize_CheckBox.AutoSize = true;
            this.MaxRowSize_CheckBox.Location = new System.Drawing.Point(6, 70);
            this.MaxRowSize_CheckBox.Name = "MaxRowSize_CheckBox";
            this.MaxRowSize_CheckBox.Size = new System.Drawing.Size(117, 19);
            this.MaxRowSize_CheckBox.TabIndex = 6;
            this.MaxRowSize_CheckBox.Text = "Set Max Row Size";
            this.MaxRowSize_CheckBox.UseVisualStyleBackColor = true;
            this.MaxRowSize_CheckBox.CheckedChanged += new System.EventHandler(this.MaxRowSize_CheckBox_CheckedChanged);
            this.MaxRowSize_CheckBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MaxRowSize_CheckBox_MouseMove);
            // 
            // Export_Btn
            // 
            this.Export_Btn.Location = new System.Drawing.Point(134, 173);
            this.Export_Btn.Name = "Export_Btn";
            this.Export_Btn.Size = new System.Drawing.Size(127, 45);
            this.Export_Btn.TabIndex = 5;
            this.Export_Btn.Text = "Export";
            this.Export_Btn.UseVisualStyleBackColor = true;
            this.Export_Btn.Click += new System.EventHandler(this.Export_Btn_Click);
            // 
            // MaxRows_Label
            // 
            this.MaxRows_Label.AutoSize = true;
            this.MaxRows_Label.Location = new System.Drawing.Point(6, 92);
            this.MaxRows_Label.Name = "MaxRows_Label";
            this.MaxRows_Label.Size = new System.Drawing.Size(105, 15);
            this.MaxRows_Label.TabIndex = 4;
            this.MaxRows_Label.Text = "Max Rows Per File:";
            this.MaxRows_Label.Visible = false;
            // 
            // RowsPerSheet_NumBox
            // 
            this.RowsPerSheet_NumBox.Location = new System.Drawing.Point(6, 110);
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
            this.RowsPerSheet_NumBox.Size = new System.Drawing.Size(120, 23);
            this.RowsPerSheet_NumBox.TabIndex = 3;
            this.RowsPerSheet_NumBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RowsPerSheet_NumBox.Visible = false;
            // 
            // ExportLocation_Button
            // 
            this.ExportLocation_Button.Location = new System.Drawing.Point(358, 34);
            this.ExportLocation_Button.Name = "ExportLocation_Button";
            this.ExportLocation_Button.Size = new System.Drawing.Size(43, 25);
            this.ExportLocation_Button.TabIndex = 2;
            this.ExportLocation_Button.Text = "...";
            this.ExportLocation_Button.UseVisualStyleBackColor = true;
            this.ExportLocation_Button.Click += new System.EventHandler(this.ExportLocation_Button_Click);
            // 
            // ExportLocation_Label
            // 
            this.ExportLocation_Label.AutoSize = true;
            this.ExportLocation_Label.Location = new System.Drawing.Point(6, 18);
            this.ExportLocation_Label.Name = "ExportLocation_Label";
            this.ExportLocation_Label.Size = new System.Drawing.Size(93, 15);
            this.ExportLocation_Label.TabIndex = 1;
            this.ExportLocation_Label.Text = "Export Location:";
            // 
            // ExportLocation_TextBox
            // 
            this.ExportLocation_TextBox.Location = new System.Drawing.Point(6, 36);
            this.ExportLocation_TextBox.Name = "ExportLocation_TextBox";
            this.ExportLocation_TextBox.Size = new System.Drawing.Size(346, 23);
            this.ExportLocation_TextBox.TabIndex = 0;
            // 
            // SQL_Tab
            // 
            this.SQL_Tab.Location = new System.Drawing.Point(4, 24);
            this.SQL_Tab.Name = "SQL_Tab";
            this.SQL_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.SQL_Tab.Size = new System.Drawing.Size(408, 224);
            this.SQL_Tab.TabIndex = 1;
            this.SQL_Tab.Text = "SQL";
            this.SQL_Tab.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(5, 257);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(402, 33);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 6;
            // 
            // RowsToExport
            // 
            this.RowsToExport.AutoSize = true;
            this.RowsToExport.Location = new System.Drawing.Point(211, 74);
            this.RowsToExport.Name = "RowsToExport";
            this.RowsToExport.Size = new System.Drawing.Size(90, 15);
            this.RowsToExport.TabIndex = 7;
            this.RowsToExport.Text = "Rows To Export:";
            // 
            // ExportCount_Label
            // 
            this.ExportCount_Label.AutoSize = true;
            this.ExportCount_Label.Location = new System.Drawing.Point(307, 74);
            this.ExportCount_Label.Name = "ExportCount_Label";
            this.ExportCount_Label.Size = new System.Drawing.Size(0, 15);
            this.ExportCount_Label.TabIndex = 8;
            // 
            // Export_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 298);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Export_Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export_Window";
            this.tabControl1.ResumeLayout(false);
            this.Excel_Tab.ResumeLayout(false);
            this.Excel_Tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RowsPerSheet_NumBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Excel_Tab;
        private System.Windows.Forms.Button Export_Btn;
        private System.Windows.Forms.Label MaxRows_Label;
        private System.Windows.Forms.NumericUpDown RowsPerSheet_NumBox;
        private System.Windows.Forms.Button ExportLocation_Button;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage SQL_Tab;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label ExportLocation_Label;
        private System.Windows.Forms.TextBox ExportLocation_TextBox;
        private System.Windows.Forms.CheckBox MaxRowSize_CheckBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label RowsToExport;
        private System.Windows.Forms.Label ExportCount_Label;
    }
}