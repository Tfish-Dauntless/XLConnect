using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;

namespace XLConnect
{
   
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            Table = new DataTable();
            SQLCONNECTION = @"Data Source=localHost;Initial Catalog=DupeTesting;Integrated Security=True;";
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial; ;
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
                    MessageBox.Show("Connection Established");
                    connection.Close();
                }
                catch (SqlException s)
                {
                    MessageBox.Show("SQL CONNECTION FAILED \n" + s.Message);
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
        private async Task<bool> RunSQLQuery(string query)
        {
            if(query.Length <= 0)
            {
                MessageBox.Show("Please create SQL Query");
                 return false;
            }
            else
            {

                //string querystring = query + " FROM [dbo].[" + Table_Combobox.Text+"]";
                //MessageBox.Show(querystring);
                string connectionString = @"Data Source=" + Server_TextBox.Text + ";Initial Catalog=" + DBCOMBOBOX.Text + ";Integrated Security=True;Timeout=32767";
                bool queryerror = false;
                try
                {
                    using (SqlConnection _con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand _cmd = new SqlCommand(query, _con))
                        {
                            _cmd.CommandTimeout = 32767;
                            await _con.OpenAsync();
                            SqlDataAdapter da = new SqlDataAdapter(_cmd);
                            // this will query your database and return the result to your datatable
                            da.Fill(Table);
                            _con.Close();
                            MessageBox.Show("Success");
                            return true;

                        }


                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    queryerror = true;
                }
            }
            
            
            return true;
        }

        private async  void TestConnection_Button_Click(object sender, EventArgs e)
        {
           await IsServerConnected(Server_TextBox.Text);
        }

        private async void Run_Button_Click(object sender, EventArgs e)
        {
            await RunSQLQuery(Query_Box.Text);
        }

        private void Export_Button_Click(object sender, EventArgs e)
        {
            var exportWindow = new ExcelMate.Export_Window(Table);
            exportWindow.Show();
        }
        public DataTable Table { get; set; }
        public string SQLCONNECTION { get; set; }

        private async void DBCOMBOBOX_Click(object sender, EventArgs e)
        {
            await PopulateComboBox();
        }

        private async void Table_Combobox_Click(object sender, EventArgs e)
        {
            await PopulateTableComboBox();
        }
    }

}
