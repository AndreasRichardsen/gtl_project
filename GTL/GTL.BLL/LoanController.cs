using GTL.DAL.ConnectedLayer;
using GTL.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.BLL
{
    public class LoanController
    {
        public bool InsertNewLoan(Loan loan)
        {
            DatabaseConnection DbConnection = new DatabaseConnection();
            SqlConnectionStringBuilder cnStringBuilder = DbConnection.GetConnectionString();
            LoanDAL loanDAL = new LoanDAL();
            return loanDAL.InsertNewLoan(cnStringBuilder.ConnectionString, loan);
        }

        public bool DeleteLoanById(long id)
        {
            DatabaseConnection DbConnection = new DatabaseConnection();
            SqlConnectionStringBuilder cnStringBuilder = DbConnection.GetConnectionString();
            LoanDAL loanDAL = new LoanDAL();
            return loanDAL.DeleteLoanById(cnStringBuilder.ConnectionString, id);
        }

        public bool MatchBookWithCopy(long isbn, long barcode)
        {
            DatabaseConnection DbConnection = new DatabaseConnection();
            SqlConnectionStringBuilder cnStringBuilder = DbConnection.GetConnectionString();
            LoanDAL loanDAL = new LoanDAL();
            BookCopy result = loanDAL.GetBookCopyByIsbnAndBarcode(cnStringBuilder.ConnectionString, isbn, barcode);
            if (result == null) return false;
            else return true;
        }

        public bool VerifyBookCopyIsAvailable(long barcode)
        {
            DatabaseConnection DbConnection = new DatabaseConnection();
            SqlConnectionStringBuilder cnStringBuilder = DbConnection.GetConnectionString();
            LoanDAL loanDAL = new LoanDAL();
            BookCopy result = loanDAL.GetBookCopyAvailability(cnStringBuilder.ConnectionString, barcode);

            if (result == null) return true;
            else return false;
        }

        public bool VerifyCardNotExpired(int cardNo)
        {
            DatabaseConnection DbConnection = new DatabaseConnection();
            SqlConnectionStringBuilder cnStringBuilder = DbConnection.GetConnectionString();
            CardDAL cardDAL = new CardDAL();
            Card result = cardDAL.GetCardAvailability(cnStringBuilder.ConnectionString, cardNo);

            if (result == null) return false;
            else return true;
        }

        public bool CheckLoanBookLimit(int noOfBookLoans)
        {
            if (noOfBookLoans >= 5) return false;
            else return true;
        }

        public bool CheckBookType(string typeOfBook)
        {
            if (typeOfBook == "Normal") return true;
            else return false;
        }
    }
}
