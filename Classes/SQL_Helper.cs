using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XLConnect.Classes
{
   public class SQL_Helper
    {

        public async Task<bool> RunSQLQuery(string query,string ServerName,string dataBaseName,DataTable Table)
        {
            if (query.Length <= 0)
            {
                MessageBox.Show("Please create SQL Query");
                return false;
            }
            else
            {

                //string querystring = query + " FROM [dbo].[" + Table_Combobox.Text+"]";
                //MessageBox.Show(querystring);
                string connectionString = @"Data Source=" + ServerName + ";Initial Catalog=" + dataBaseName + ";Integrated Security=True;Timeout=32767";
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
        public async Task<bool> CreateTable(string server, string database, string tablename, List<string> headers, bool hascolumns, string type = "Process")
        {
            try
            {
                string query;
                string headerstrings = "";

                headerstrings = $"[{string.Join("] NVARCHAR(Max) NULL ,[", headers)}] NVARCHAR(Max) NULL";
                query = $@"CREATE Table [{tablename}] ({headerstrings})";
                var fullquery = $@"IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[{tablename}]') AND type in (N'U')) BEGIN {query} END";

                //MessageBox.Show(fullquery);
                string connectionString = $@"Data Source={server};Initial Catalog={database};Integrated Security=True;Timeout=32767";
                using (var connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(fullquery, connection))
                    {
                        _cmd.CommandTimeout = 32767;
                        await connection.OpenAsync();
                        await _cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Message: {e.Message}\nStackTrace: {e.StackTrace}");
            }

            return true;
        }
        public async Task<List<string>> GatherSqlColumns(string server, string database, string tablename)
        {
            try
            {

                List<string> columns = new List<string>();

                string connectionString = @"Data Source=" + server + ";Initial Catalog=" + database + ";Integrated Security=True;Timeout=32767";

                string query = $@"Select Column_Name FROM  INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tablename}' ORDER BY [Column_Name]";


                DataTable table = new DataTable();
                using (SqlConnection _con = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(query, _con))
                    {
                        _cmd.CommandTimeout = 32767;
                        await _con.OpenAsync();
                        SqlDataAdapter da = new SqlDataAdapter(_cmd);
                        // this will query your database and return the result to your datatable
                        da.Fill(table);
                        _con.Close();


                        foreach (DataRow column in table.Rows)
                        {
                            columns.Add(column[0].ToString().ToUpper().Trim());
                        }
                        table.Dispose();
                    }
                }
                return columns;
            }
            catch (Exception e)
            {
                throw new Exception($"Error gathering Columns\nError Message: {e.Message}");
            }
        }
        public async Task<bool> CreateDataBase(string server, string database)
        {
            try
            {
                //MessageBox.Show("Creating DB");
                string connectionString = @"Data Source=" + server + ";Initial Catalog=master;Integrated Security=True;Timeout=32767";
                using (var connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand($"CREATE DATABASE [{database}]" , connection))
                    {
                        _cmd.CommandTimeout = 32767;
                        await connection.OpenAsync();
                        _cmd.ExecuteNonQuery();
                    }

                }
                //MessageBox.Show("Complete");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed to Created DataBase\nMessage: {e.Message}\nStackTrace: {e.StackTrace}");
            }

            return true;
        }
        public async Task<bool> InsertDataIntoSQL(DataTable datatable, string server, string database, string tablename)
        {
            try
            {

                //MessageBox.Show("I've made it here - input data");
                string connectionString = @"Data Source=" + server + ";Initial Catalog=" + database + ";Integrated Security=True;Timeout=32767";
                //MessageBox.Show("I've made it here - input data \n\n" + @"Data Source=" + server + ";\n\nInitial Catalog=" + database + ";\n\nIntegrated Security=True;\n\nTimeout=32767\n\n [" +tablename+"]");
                using (SqlConnection connection = new SqlConnection(connectionString))

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.BatchSize = 50;
                    bulkCopy.BulkCopyTimeout = 32767;
                    connection.Open();
                    bulkCopy.DestinationTableName = "[" + tablename + "]";

                    foreach (var column in datatable.Columns)
                    {
                        // MessageBox.Show(column.ToString().ToUpper().Trim(), "[" + column.ToString().ToUpper().Trim() + "]");
                        bulkCopy.ColumnMappings.Add(column.ToString().ToUpper().Trim(), column.ToString().ToUpper().Trim());
                    }
                    bulkCopy.WriteToServer(datatable);

                }


                return true;


            }
            catch (Exception e)
            {
                //MessageBox.Show("failed to input data");
                throw new Exception($"Failed to Insert data\nMessage: {e.Message}\nStackTrace: {e.StackTrace}");
                return false;
            }

        }
        public async Task<bool> AddColumns(string server, string database, string tablename, List<string> columns)
        {
            try
            {

                var query = "Alter Table [" + tablename + @"] ADD [" + string.Join("] NVARCHAR(Max) NULL, [", columns) + "] NVARCHAR(Max) NULL";
                string connectionString = @"Data Source=" + server + ";Initial Catalog=" + database + ";Integrated Security=True;Timeout=32767";
                //MessageBox.Show(connectionString);
                //MessageBox.Show(query);
                using (var connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(query, connection))
                    {
                        _cmd.CommandTimeout = 32767;
                        await connection.OpenAsync();
                        _cmd.ExecuteNonQuery();
                    }
                }
                //MessageBox.Show("Success");

                return true;
            }
            catch (Exception e)
            {

                throw new Exception($"Message: {e.Message}\nStackTrace: {e.StackTrace}");
                return false;
            }

        }

        
    }
}
