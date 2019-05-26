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
    }
}
