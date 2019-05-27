using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.DAL.ConnectedLayer
{
    class CommandBuilder
    {
        public bool ExecuteCommand(string connectionString, string sql)
        {
            bool success = false;
            SqlConnection _sqlConnection = new SqlConnection { ConnectionString = connectionString };
            _sqlConnection.Open();

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
