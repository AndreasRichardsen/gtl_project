using GTL.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.DAL.ConnectedLayer
{
    public class LoanDAL
    {
        public bool InsertNewLoan(string connectionString, Loan newLoan)
        {
            SqlConnection _sqlConnection = new SqlConnection { ConnectionString = connectionString };
            _sqlConnection.Open();

            bool success = false;

            string sql = "INSERT INTO Borrow (ISBN, Barcode, CardNo, IsReturned, DateBorrowed) " +
                $"VALUES ('{newLoan.ISBN}', '{newLoan.Barcode}', '{newLoan.CardNo}'," +
                $" '{newLoan.IsReturned.ToString()}', '{newLoan.DateBorrowed}');";

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
            _sqlConnection.Close();
            return success;
        }

        public BookCopy GetBookCopyByIsbnAndBarcode(string connectionString, long isbn, long barcode)
        {
            BookCopy bookCopy = null;

            SqlConnection _sqlConnection = new SqlConnection { ConnectionString = connectionString };
            _sqlConnection.Open();

            string sql = "SELECT ISBN, Barcode FROM BookCopy " +
                $"WHERE ISBN = '{isbn}' AND Barcode = '{barcode}';";

            using (SqlCommand cmd = new SqlCommand(sql, _sqlConnection))
            {
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    bookCopy = new BookCopy
                    {
                        ISBN = Convert.ToInt64( dataReader["ISBN"]),
                        Barcode = Convert.ToInt64(dataReader["Barcode"])
                    };
                }
                dataReader.Close();
            }

            _sqlConnection.Close();
            return bookCopy;
        }

        public BookCopy GetBookCopyAvailability(string connectionString, long barcode)
        {
            BookCopy bookCopy = null;

            SqlConnection _sqlConnection = new SqlConnection { ConnectionString = connectionString };
            _sqlConnection.Open();

            string sql = "SELECT Barcode FROM Borrow " +
                $"WHERE Barcode = '{barcode}' AND IsReturned = 'false';";

            using (SqlCommand cmd = new SqlCommand(sql, _sqlConnection))
            {
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    bookCopy = new BookCopy
                    {
                        Barcode = Convert.ToInt64(dataReader["Barcode"])
                    };
                }
                dataReader.Close();
            }

            _sqlConnection.Close();
            return bookCopy;
        }
    }
}
