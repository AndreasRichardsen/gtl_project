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

        public bool DeleteBookByIsbn(string connectionString, long isbn)
        {
            bool success = false;

            SqlConnection _sqlConnection = new SqlConnection { ConnectionString = connectionString };
            _sqlConnection.Open();

            string sql = $"DELETE FROM Book WHERE ISBN = '{isbn}';" +
                $"DELETE FROM Item WHERE ISBN = '{isbn}';";

            using(SqlCommand cmd = new SqlCommand(sql, _sqlConnection))
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
            _sqlConnection.Close();
            return success;
        }

        public bool InsertNewBookCopy(string connectionString, long isbn, long barcode)
        {
            bool success = false;
            SqlConnection _sqlConnection = new SqlConnection { ConnectionString = connectionString };
            _sqlConnection.Open();

            string sql = $"INSERT INTO BookCopy (ISBN, Barcode) VALUES ('{isbn}', '{barcode}');";

            using(SqlCommand cmd = new SqlCommand(sql, _sqlConnection))
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
            _sqlConnection.Close();
            return success;
        }
    }
}
