using GTL.DAL.Models;
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
        }

        public void CloseConnection()
        {
            _sqlConnection.Close();
        }

        public void InsertItem(
            int ISBN, 
            string Title, 
            string Description,
            string Author, 
            string Publisher,
            string YearPublishing)
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

        public void InsertItem(NewItem item)
        {
            string sql = "INSERT INTO Item" +
                $"(ISBN, Title, ItemDescription, Author, Publisher, YearPublishing) VALUES ('{item.ISBN}','{item.Title}','{item.Description}','{item.Author},'{item.Publisher}','{item.YearPublishing}')";
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

        public List<NewItem> GetAllItemsAsList()
        {
            List<NewItem> items = new List<NewItem>();

            string sql = "SELECT * FROM Item";

            using(SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    items.Add(new NewItem
                    {
                        ISBN = (int)dataReader["ISBN"],
                        Title = (string)dataReader["Title"],
                        Description = (string)dataReader["ItemDescription"],
                        Author = (string)dataReader["Author"],
                        Publisher = (string)dataReader["Publisher"],
                        YearPublishing = (int)dataReader["YearPublishing"]
                    });
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
    }
}
