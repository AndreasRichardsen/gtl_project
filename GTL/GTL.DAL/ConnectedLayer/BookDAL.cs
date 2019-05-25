using GTL.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.DAL.ConnectedLayer
{
    public class BookDAL
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

        public bool InsertNewBook(string cntString, Book newBook)
        {
            SqlConnection _sqlConnection = new SqlConnection { ConnectionString = cntString };
            _sqlConnection.Open();

            bool success = false;

            string sql = "INSERT INTO Item (ISBN, Title, Author, ItemDescription, Publisher, YearPublishing) " +
                $"VALUES ('{newBook.ISBN}', '{newBook.Title}', '{newBook.Author}', '{newBook.Description}'," +
                $" '{newBook.Publisher}', '{newBook.YearPublishing}');" +
                "INSERT INTO Book(ISBN, BookType) " + $"VALUES('{newBook.ISBN}', '{newBook.Type}');";

            using(SqlCommand cmd = new SqlCommand(sql, _sqlConnection))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    success = true;
                }
                catch(SqlException e)
                {
                    
                    Console.WriteLine(e.Message);
                }
            }
            _sqlConnection.Close();
            return success;
        }
    }
}
