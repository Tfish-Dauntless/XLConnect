
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
            this.ExportLocation_Label = new System.Windows.Forms.Label();
            this.ExportLocation_Button = new System.Windows.Forms.Button();
            this.RowsPerSheet_NumBox = new System.Windows.Forms.NumericUpDown();
            this.MaxRows_Label = new System.Windows.Forms.Label();
            this.Export_Btn = new System.Windows.Forms.Button();
            this.MaxRowSize_CheckBox = new System.Windows.Forms.CheckBox();
            this.RowsToExport = new System.Windows.Forms.Label();
            this.ExportCount_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RowsPerSheet_NumBox)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(4, 223);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(345, 29);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 6;
            // 
            // ExportLocation_TextBox
            // 
            this.ExportLocation_TextBox.Location = new System.Drawing.Point(448, 67);
            this.ExportLocation_TextBox.Name = "ExportLocation_TextBox";
            this.ExportLocation_TextBox.Size = new System.Drawing.Size(297, 20);
            this.ExportLocation_TextBox.TabIndex = 0;
            // 
            // ExportLocation_Label
            // 
            this.ExportLocation_Label.AutoSize = true;
            this.ExportLocation_Label.Location = new System.Drawing.Point(448, 52);
            this.ExportLocation_Label.Name = "ExportLocation_Label";
            this.ExportLocation_Label.Size = new System.Drawing.Size(84, 13);
            this.ExportLocation_Label.TabIndex = 1;
            this.ExportLocation_Label.Text = "Export Location:";
            // 
            // ExportLocation_Button
            // 
            this.ExportLocation_Button.Location = new System.Drawing.Point(750, 65);
            this.ExportLocation_Button.Name = "ExportLocation_Button";
            this.ExportLocation_Button.Size = new System.Drawing.Size(37, 22);
            this.ExportLocation_Button.TabIndex = 2;
            this.ExportLocation_Button.Text = "...";
            this.ExportLocation_Button.UseVisualStyleBackColor = true;
            this.ExportLocation_Button.Click += new System.EventHandler(this.ExportLocation_Button_Click);
            // 
            // RowsPerSheet_NumBox
            // 
            this.RowsPerSheet_NumBox.Location = new System.Drawing.Point(448, 131);
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
            this.RowsPerSheet_NumBox.Size = new System.Drawing.Size(103, 20);
            this.RowsPerSheet_NumBox.TabIndex = 3;
            this.RowsPerSheet_NumBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RowsPerSheet_NumBox.Visible = false;
            // 
            // MaxRows_Label
            // 
            this.MaxRows_Label.AutoSize = true;
            this.MaxRows_Label.Location = new System.Drawing.Point(448, 116);
            this.MaxRows_Label.Name = "MaxRows_Label";
            this.MaxRows_Label.Size = new System.Drawing.Size(98, 13);
            this.MaxRows_Label.TabIndex = 4;
            this.MaxRows_Label.Text = "Max Rows Per File:";
            this.MaxRows_Label.Visible = false;
            // 
            // Export_Btn
            // 
            this.Export_Btn.Location = new System.Drawing.Point(558, 186);
            this.Export_Btn.Name = "Export_Btn";
            this.Export_Btn.Size = new System.Drawing.Size(109, 39);
            this.Export_Btn.TabIndex = 5;
            this.Export_Btn.Text = "Export";
            this.Export_Btn.UseVisualStyleBackColor = true;
            this.Export_Btn.Click += new System.EventHandler(this.Export_Btn_Click);
            // 
            // MaxRowSize_CheckBox
            // 
            this.MaxRowSize_CheckBox.AutoSize = true;
            this.MaxRowSize_CheckBox.Location = new System.Drawing.Point(448, 97);
            this.MaxRowSize_CheckBox.Name = "MaxRowSize_CheckBox";
            this.MaxRowSize_CheckBox.Size = new System.Drawing.Size(113, 17);
            this.MaxRowSize_CheckBox.TabIndex = 6;
            this.MaxRowSize_CheckBox.Text = "Set Max Row Size";
            this.MaxRowSize_CheckBox.UseVisualStyleBackColor = true;
            this.MaxRowSize_CheckBox.CheckedChanged += new System.EventHandler(this.MaxRowSize_CheckBox_CheckedChanged);
            this.MaxRowSize_CheckBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MaxRowSize_CheckBox_MouseMove);
            // 
            // RowsToExport
            // 
            this.RowsToExport.AutoSize = true;
            this.RowsToExport.Location = new System.Drawing.Point(624, 100);
            this.RowsToExport.Name = "RowsToExport";
            this.RowsToExport.Size = new System.Drawing.Size(86, 13);
            this.RowsToExport.TabIndex = 7;
            this.RowsToExport.Text = "Rows To Export:";
            // 
            // ExportCount_Label
            // 
            this.ExportCount_Label.AutoSize = true;
            this.ExportCount_Label.Location = new System.Drawing.Point(706, 100);
            this.ExportCount_Label.Name = "ExportCount_Label";
            this.ExportCount_Label.Size = new System.Drawing.Size(0, 13);
            this.ExportCount_Label.TabIndex = 8;
            // 
            // Export_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 590);
            this.Controls.Add(this.ExportCount_Label);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.RowsToExport);
            this.Controls.Add(this.MaxRowSize_CheckBox);
            this.Controls.Add(this.ExportLocation_Label);
            this.Controls.Add(this.Export_Btn);
            this.Controls.Add(this.ExportLocation_TextBox);
            this.Controls.Add(this.MaxRows_Label);
            this.Controls.Add(this.ExportLocation_Button);
            this.Controls.Add(this.RowsPerSheet_NumBox);
            this.Name = "Export_Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export_Window";
            ((System.ComponentModel.ISupportInitialize)(this.RowsPerSheet_NumBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox ExportLocation_TextBox;
        private System.Windows.Forms.Label ExportLocation_Label;
        private System.Windows.Forms.Button ExportLocation_Button;
        private System.Windows.Forms.NumericUpDown RowsPerSheet_NumBox;
        private System.Windows.Forms.Label MaxRows_Label;
        private System.Windows.Forms.Button Export_Btn;
        private System.Windows.Forms.CheckBox MaxRowSize_CheckBox;
        private System.Windows.Forms.Label RowsToExport;
        private System.Windows.Forms.Label ExportCount_Label;
    }
}