using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.DAL.Models;

namespace GTL.DAL.ConnectedLayer
{
    public class CardDAL
    {
        CommandBuilder cmdBuilder = new CommandBuilder();

        public bool InsertNewCard(string connectionString, string issueDate)
        {

            string sql = $"INSERT INTO LibraryCard (IssueDate) VALUES ('{issueDate}');";

            return cmdBuilder.ExecuteCommand(connectionString, sql);
        }

        public bool DeleteCardByCardNo(string connectionString, long cardNo)
        {

            string sql = $"DELETE FROM LibraryCard WHERE CardNo = '{cardNo}' " +
                "DBCC CHECKIDENT (LibraryCard, RESEED, 1)";


            return cmdBuilder.ExecuteCommand(connectionString, sql);
        }

        public Card GetCardAvailability(string connectionString, int cardNo)
        {
            Card card = null;

            SqlConnection _sqlConnection = new SqlConnection { ConnectionString = connectionString };
            _sqlConnection.Open();

            string sql = "SELECT CardNo FROM LibraryCard " +
                $"WHERE CardNo = '{cardNo}' AND DATEDIFF(YEAR, IssueDate, GETDATE()) <= 4";

            using (SqlCommand cmd = new SqlCommand(sql, _sqlConnection))
            {
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    card = new Card();
                }
                dataReader.Close();
            }

            _sqlConnection.Close();
            return card;
        }
    }
}
