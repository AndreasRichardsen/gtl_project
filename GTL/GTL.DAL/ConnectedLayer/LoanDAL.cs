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
    }
}
