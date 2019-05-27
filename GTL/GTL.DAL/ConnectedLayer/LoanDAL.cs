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
        CommandBuilder cmdBuilder = new CommandBuilder();

        public bool InsertNewLoan(string connectionString, Loan newLoan)
        {

            string sql = "INSERT INTO Borrow (ISBN, Barcode, CardNo, IsReturned, DateBorrowed) " +
                $"VALUES ('{newLoan.ISBN}', '{newLoan.Barcode}', '{newLoan.CardNo}'," +
                $" '{newLoan.IsReturned.ToString()}', '{newLoan.DateBorrowed}');";

            return cmdBuilder.ExecuteCommand(connectionString, sql);
        }

        public bool DeleteLoanById(string connectionString, long id)
        {

            string sql = $"DELETE FROM Borrow WHERE Id = '{id}' " +
                "DBCC CHECKIDENT (Borrow, RESEED, 0)";

            return cmdBuilder.ExecuteCommand(connectionString, sql);
        }
    }
}
