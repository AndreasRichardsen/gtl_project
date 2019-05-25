﻿using GTL.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.DAL.ConnectedLayer
{
    public class ItemDAL
    {
        
        private SqlConnection _sqlConnection = null;

        public void OpenConnection(string connectionString)
        {
            _sqlConnection = new SqlConnection { ConnectionString = connectionString };
            _sqlConnection.Open();
            Console.WriteLine("Connected to the db!");
            Console.ReadLine();
        }

        public void CloseConnection()
        {
            _sqlConnection.Close();
        }

        public void InsertItem(
            long ISBN, 
            string Title, 
            string Description,
            string Author, 
            string Publisher,
            string YearPublishing) // CODE REVIEW CATCH BUG INT INSTEAD of STRING
        {
            string sql = "INSERT INTO Item" +
                "(ISBN, Title, ItemDescription, Author, Publisher, YearPublishing) VALUES (@ISBN,@Title,@Description,@Author,@Publisher,@YearPublishing)";
            
            using (SqlCommand command = new SqlCommand(sql,_sqlConnection))
            {
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@ISBN",
                    Value = ISBN,
                    SqlDbType = SqlDbType.BigInt
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Title",
                    Value = Title,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Description",
                    Value = Description,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Author",
                    Value = Author,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Publisher",
                    Value = Publisher,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@YearPublishing",
                    Value = YearPublishing,
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
            }
        }

        public bool InsertNewItem(Item newItem)
        {
            bool success = false;

            string sql = "INSERT INTO Item" +
                $"(ISBN, Title, ItemDescription, Author, Publisher, YearPublishing) VALUES ('{newItem.ISBN}','{newItem.Title}','{newItem.Description}','{newItem.Author},'{newItem.Publisher}','{newItem.YearPublishing}')";

            using (SqlCommand cmd = new SqlCommand(sql, _sqlConnection))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    success = true;
                }
                catch (SqlException e)
                {

                    Console.WriteLine(e.Message);
                }
            }
            return success;
        }

        public void DeleteItem(int ISBN)
        {
            string sql = $"DELETE FROM Item WHERE ISBN = '{ISBN}'";

            using(SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                try
                {
                    command.ExecuteNonQuery();
                }
                catch(SqlException ex)
                {
                    Exception error = new Exception("Error deleting item!", ex);
                    throw error;
                }
            }
        }

        public void UpdateItemTitle(int ISBN, string newTitle)
        {
            string sql = $"UPDATE Item SET Title = '{newTitle}' WHERE ISBN = '{ISBN}'";

            using(SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        public List<Item> GetAllItemsAsList()
        {
            List<Item> items = new List<Item>();

            string sql = "SELECT * FROM Item";

            using(SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    /*
                    items.Add(new NewItem
                    {
                        ISBN = (int)dataReader["ISBN"],
                        Title = (string)dataReader["Title"],
                        Description = (string)dataReader["ItemDescription"],
                        Author = (string)dataReader["Author"],
                        Publisher = (string)dataReader["Publisher"],
                        YearPublishing = (int)dataReader["YearPublishing"]
                    });*/
                }
                dataReader.Close();
            }
            return items;
        }

        public DataTable GetAllItemsAsDataTable()
        {
            DataTable dataTable = new DataTable();

            string sql = "SELECT * FROM Item";
            using(SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                SqlDataReader dataReader = command.ExecuteReader();
                dataTable.Load(dataReader);
                dataReader.Close();
            }
            return dataTable;
        }

        public string LookUpItemDescription(int itemISBN)
        {
            string itemDescription;

            using(SqlCommand command = new SqlCommand("GetItemDescription", _sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@isbn",
                    SqlDbType = SqlDbType.Int,
                    Value = itemISBN,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@itemDescription",
                    SqlDbType = SqlDbType.Char,
                    Size = 10,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();

                itemDescription = (string)command.Parameters["@itemDescription"].Value;
            }
            return itemDescription;
        }
    }
}
