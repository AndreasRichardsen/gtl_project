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
        public SqlConnectionStringBuilder GetConnectionString()
        {
            string connectionString = @"Data Source=(local)\SQL1;" + "Initial Catalog=GTL_TEST; Integrated Security=True";

            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder(connectionString)
            {
                ConnectTimeout = 5
            };

            return connectionStringBuilder;
        }

        public bool InsertNewLoan(Loan loan)
        {
            SqlConnectionStringBuilder cnStringBuilder = GetConnectionString();
            LoanDAL loanDAL = new LoanDAL();
            return loanDAL.InsertNewLoan(cnStringBuilder.ConnectionString, loan);
        }

        public bool MatchBookWithCopy(long isbn, long barcode)
        {
            SqlConnectionStringBuilder cnStringBuilder = GetConnectionString();
            LoanDAL loanDAL = new LoanDAL();
            BookCopy result = loanDAL.GetBookCopyByIsbnAndBarcode(cnStringBuilder.ConnectionString, isbn, barcode);
            if (result == null) return false;
            else return true;
        }

        public bool VerifyBookCopyIsAvailable(long barcode)
        {
            SqlConnectionStringBuilder cnStringBuilder = GetConnectionString();
            LoanDAL loanDAL = new LoanDAL();
            BookCopy result = loanDAL.GetBookCopyAvailability(cnStringBuilder.ConnectionString, barcode);

            if (result == null) return true;
            else return false;
        }

        public bool VerifyCardNotExpired(int cardNo)
        {
            SqlConnectionStringBuilder cnStringBuilder = GetConnectionString();
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
