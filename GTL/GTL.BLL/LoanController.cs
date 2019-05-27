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
    }
}
