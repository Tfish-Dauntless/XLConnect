
using Sylvan.Data.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelMate
{
    public partial class Export_Window : Form
    {
        public Export_Window(DataTable datalist)
        {
            InitializeComponent();
            Rowsleft = datalist.Rows.Count;
            TotalRows = datalist.Rows.Count;
            DataList = datalist;
            ExportCount_Label.Text = DataList.Rows.Count.ToString();
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
            saveFile.Filter = "Data Files (*.Xlsx)|*.Xlsx";
            saveFile.DefaultExt = "Xlsx";
            saveFile.AddExtension = true;
            saveFile.FileName = DateTime.Now.ToString("yyyyMMdd") + "_REPLACEWITHCASENAME_Delivery";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                ExportLocation_TextBox.Text = saveFile.FileName;
            }

        }
        private async void Export_Btn_Click(object sender, EventArgs e)
        {

            try
            {
                int excelCap;
                int toSkip = 0;
                int num = 1;
                if (MaxRowSize_CheckBox.Checked)
                {
                    excelCap = Decimal.ToInt32(RowsPerSheet_NumBox.Value);
                    if (TotalRows > excelCap)
                    {
                        while (Rowsleft > 0)
                        {
                            if (Rowsleft < excelCap)
                            {
                                //MessageBox.Show("Im Here to export a large amount");
                                await ExportToExcel(ExportLocation_TextBox.Text.Replace(".Xlsx", "") + "_" + num + ".Xlsx", "ExcelCap", Rowsleft, toSkip);
                                
                                break;
                            }
                            else
                            {
                                await ExportToExcel(ExportLocation_TextBox.Text.Replace(".Xlsx", "") + "_" + num + ".Xlsx", "ExcelCap", excelCap, toSkip);
                            }
                            num += 1;
                            toSkip += excelCap;
                            Rowsleft -= excelCap;
                        }
                        
                    }
                }
                // || 
                else if (!MaxRowSize_CheckBox.Checked && TotalRows > 999999)
                {
                    excelCap = 500000;
                    if (TotalRows > excelCap)
                    {
                        while (Rowsleft > 0)
                        {
                            if (Rowsleft < excelCap)
                            {
                                //MessageBox.Show("Im Here to export a large amount");
                                await ExportToExcel(ExportLocation_TextBox.Text.Replace(".Xlsx", "") + "_" + num + ".Xlsx", "ExcelCap", Rowsleft, toSkip);

                                break;
                            }
                            else
                            {
                                await ExportToExcel(ExportLocation_TextBox.Text.Replace(".Xlsx", "") + "_" + num + ".Xlsx", "ExcelCap", excelCap, toSkip);
                            }
                            num += 1;
                            toSkip += excelCap;
                            Rowsleft -= excelCap;
                        }

                    }              
                }
                else
                {
                    MessageBox.Show("I am Exporting");
                    await ExportToExcel(ExportLocation_TextBox.Text);
                    
                }

               // await ExportToExcel(ExportLocation_TextBox.Text.Replace("_Delivery.Xlsx", "_RoundTracking.Xlsx"), "RoundTracking");
                MessageBox.Show("Complete");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception em)
            {
                MessageBox.Show(em.Message);
            }
        }
        private void MaxRowSize_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (MaxRowSize_CheckBox.Checked)
            {
                
                RowsPerSheet_NumBox.Visible = true;
                RowsPerSheet_NumBox.Value = 999999;
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

       
    }
}
