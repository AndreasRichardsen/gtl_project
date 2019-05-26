using GTL.DAL.ConnectedLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.BLL
{
    public class CardController
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

        public bool InsertNewCard(string issueDate)
        {
            SqlConnectionStringBuilder cnStringBuilder = GetConnectionString();
            CardDAL cardDAL = new CardDAL();
            return cardDAL.InsertNewCard(cnStringBuilder.ConnectionString, issueDate);
        }

        public bool DeleteCardByCardNo(long cardNo)
        {
            SqlConnectionStringBuilder cnStringBuilder = GetConnectionString();
            CardDAL cardDAL = new CardDAL();
            return cardDAL.DeleteCardByCardNo(cnStringBuilder.ConnectionString, cardNo);
        }
    }
}
