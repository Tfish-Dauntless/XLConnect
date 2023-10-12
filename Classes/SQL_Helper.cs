﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XLConnect.Classes
{
   public class SQL_Helper
    {
        Data_Helper Helper {  get; set; }
       
        public async Task<bool> RunSqlQuery_New(Data_Helper helper,string exportLocation,string query, string ServerName, string dataBaseName,List<string>headers,string exportType,char delim,char qualifier)
        {
            try
            {
                Helper = helper;
                string connectionString = @"Data Source=" + ServerName + ";Initial Catalog=" + dataBaseName + ";Integrated Security=True;Timeout=32767";
                //List<string>fixedHeaders = new List<string>();

                //foreach(var header in headers)
                //{
                //    var adjuestheader =  Helper.StripString(header.Replace("[", "").Replace("]", "").Replace(",",""));
                //    fixedHeaders.Add(adjuestheader);
                //}

                using (SqlConnection _con = new SqlConnection(connectionString))
                {
                    _con.Open();

                    //MessageBox.Show($"Connection Open\nnew FilePath: {exportLocation}");
                    //MessageBox.Show($"Location: {exportLocation}\nServerName{ServerName}\nDataBase: {dataBaseName}\nExportType: {exportType}\nDelim: {delim}\nQualifier: {qualifier}");

                    // MessageBox.Show("Created Export Table");

                    using (SqlCommand _cmd2 = new SqlCommand(query, _con))
                    {
                        _cmd2.CommandTimeout = 32767;

                        using (var reader = await _cmd2.ExecuteReaderAsync())
                        {
                            switch (exportType.ToLower())
                            {
                                case "txt":
                                case "csv":
                                    using (var tw = File.CreateText(exportLocation))
                                    {
                                       
                                        var combinedHeaders = Helper.StripString($"{qualifier}{String.Join($"{qualifier}{delim}{qualifier}", headers)}{qualifier}");
                                        tw.Write(combinedHeaders.Replace("[","").Replace("]","")+ "\r\n");
                                        while (await reader.ReadAsync())
                                        {
                                            //MessageBox.Show("Reading");
                                            for (int i = 0; i < reader.FieldCount; i++)
                                            {
                                                if (i != 0)
                                                {
                                                    tw.Write(delim);
                                                }

                                                string val = reader[i] == null ? null :  Helper.FormatValue(reader[i]);


                                                tw.Write(qualifier);
                                                tw.Write(val.Replace(qualifier.ToString(), $"{qualifier}{qualifier}"));
                                                tw.Write(qualifier);
                                            }
                                            tw.Write("\r\n");
                                        }

                                    }
                                    break;
                                case "xlsx":

                                    break;
                            }
                        }
                    }

                    //MessageBox.Show("Export Table Populated");
                    _con.Close();


                }
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                throw new Exception(e.Message);
            }
        }


        public async Task<bool> RunSQLQuery(string query,string ServerName,string dataBaseName,DataTable Table)
        {
            if (query.Length <= 0)
            {
                MessageBox.Show("Please create SQL Query");
                return false;
            }
            else
            {
                int rowcount = 1;

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
