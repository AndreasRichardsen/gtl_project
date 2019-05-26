using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.DAL.ConnectedLayer
{
    public class CardDAL
    {
        public bool InsertNewCard(string connectionString, string issueDate)
        {
            bool success = false;
            SqlConnection _sqlConnection = new SqlConnection { ConnectionString = connectionString };
            _sqlConnection.Open();

            string sql = $"INSERT INTO LibraryCard (IssueDate) VALUES ('{issueDate}');";

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

        public bool DeleteCardByCardNo(string connectionString, long cardNo)
        {
            bool success = false;
            SqlConnection _sqlConnection = new SqlConnection { ConnectionString = connectionString };
            _sqlConnection.Open();

            string sql = $"DELETE FROM LibraryCard WHERE CardNo = '{cardNo}' " +
                "DBCC CHECKIDENT (LibraryCard, RESEED, 1)";

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
