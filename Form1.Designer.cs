
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
            this.Table_Combobox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TestConnection_Button = new System.Windows.Forms.Button();
            this.DBCOMBOBOX = new System.Windows.Forms.ComboBox();
            this.Server_TextBox = new System.Windows.Forms.TextBox();
            this.DataBase_ComboBox = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Query_GroupBox = new System.Windows.Forms.GroupBox();
            this.Query_Box = new System.Windows.Forms.RichTextBox();
            this.Action_GroupBox = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Export_Button = new System.Windows.Forms.Button();
            this.Run_Button = new System.Windows.Forms.Button();
            this.Clear_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.Control_GroupBox.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.Query_GroupBox);
            this.splitContainer1.Panel2.Controls.Add(this.Action_GroupBox);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 80;
            this.splitContainer1.TabIndex = 0;
            // 
            // Control_GroupBox
            // 
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
            this.Control_GroupBox.Size = new System.Drawing.Size(800, 80);
            this.Control_GroupBox.TabIndex = 0;
            this.Control_GroupBox.TabStop = false;
            this.Control_GroupBox.Text = "SQLConnection";
            // 
            // Table_Combobox
            // 
            this.Table_Combobox.FormattingEnabled = true;
            this.Table_Combobox.Location = new System.Drawing.Point(316, 51);
            this.Table_Combobox.Name = "Table_Combobox";
            this.Table_Combobox.Size = new System.Drawing.Size(472, 21);
            this.Table_Combobox.TabIndex = 6;
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
            this.TestConnection_Button.Click += new System.EventHandler(this.TestConnection_Button_Click);
            // 
            // DBCOMBOBOX
            // 
            this.DBCOMBOBOX.FormattingEnabled = true;
            this.DBCOMBOBOX.Location = new System.Drawing.Point(316, 22);
            this.DBCOMBOBOX.Name = "DBCOMBOBOX";
            this.DBCOMBOBOX.Size = new System.Drawing.Size(472, 21);
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
            // Query_GroupBox
            // 
            this.Query_GroupBox.Controls.Add(this.Query_Box);
            this.Query_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Query_GroupBox.Location = new System.Drawing.Point(0, 0);
            this.Query_GroupBox.Name = "Query_GroupBox";
            this.Query_GroupBox.Size = new System.Drawing.Size(800, 266);
            this.Query_GroupBox.TabIndex = 1;
            this.Query_GroupBox.TabStop = false;
            this.Query_GroupBox.Text = "Query";
            // 
            // Query_Box
            // 
            this.Query_Box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Query_Box.Location = new System.Drawing.Point(3, 16);
            this.Query_Box.Name = "Query_Box";
            this.Query_Box.Size = new System.Drawing.Size(794, 247);
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
            this.Action_GroupBox.Location = new System.Drawing.Point(0, 266);
            this.Action_GroupBox.Name = "Action_GroupBox";
            this.Action_GroupBox.Size = new System.Drawing.Size(800, 100);
            this.Action_GroupBox.TabIndex = 0;
            this.Action_GroupBox.TabStop = false;
            this.Action_GroupBox.Text = "Actions";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(3, 74);
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
            this.Export_Button.Visible = false;
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
            // Clear_Button
            // 
            this.Clear_Button.Location = new System.Drawing.Point(520, 19);
            this.Clear_Button.Name = "Clear_Button";
            this.Clear_Button.Size = new System.Drawing.Size(116, 28);
            this.Clear_Button.TabIndex = 3;
            this.Clear_Button.Text = "Clear";
            this.Clear_Button.UseVisualStyleBackColor = true;
            this.Clear_Button.Visible = false;
            this.Clear_Button.Click += new System.EventHandler(this.Clear_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.Control_GroupBox.ResumeLayout(false);
            this.Control_GroupBox.PerformLayout();
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
    }
}

