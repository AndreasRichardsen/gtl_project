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
        public bool InsertNewCard(string issueDate)
        {
            DatabaseConnection DbConnection = new DatabaseConnection();
            SqlConnectionStringBuilder cnStringBuilder = DbConnection.GetConnectionString();
            CardDAL cardDAL = new CardDAL();
            return cardDAL.InsertNewCard(cnStringBuilder.ConnectionString, issueDate);
        }

        public bool DeleteCardByCardNo(long cardNo)
        {
            DatabaseConnection DbConnection = new DatabaseConnection();
            SqlConnectionStringBuilder cnStringBuilder = DbConnection.GetConnectionString();
            CardDAL cardDAL = new CardDAL();
            return cardDAL.DeleteCardByCardNo(cnStringBuilder.ConnectionString, cardNo);
        }
    }
}
