using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.DAL.Models;

namespace GTL.DAL.ConnectedLayer
{
    public class PersonDAL
    {
        public bool InsertNewMember(string connectionString, Member newMember)
        {
            SqlConnection _sqlConnection = new SqlConnection { ConnectionString = connectionString };
            _sqlConnection.Open();

            bool success = false;

            string sql = "INSERT INTO Person (SSN, FName, LName, HomeAddress, CampusAddress, CardNo) " +
                $"VALUES ('{newMember.SSN}', '{newMember.FirstName}', '{newMember.LastName}', '{newMember.HomeAddress}'," +
                $" '{newMember.CampusAddress}', '{newMember.CardNo}');" +
                "INSERT INTO Member(SSN, Personification) " + $"VALUES('{newMember.SSN}', '{newMember.Personification}');";

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

        public bool DeleteMemberBySSN(string connectionString, long ssn)
        {
            SqlConnection _sqlConnection = new SqlConnection { ConnectionString = connectionString };
            _sqlConnection.Open();

            bool success = false;

            string sql = $"DELETE FROM Person WHERE SSN = '{ssn}';";

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
