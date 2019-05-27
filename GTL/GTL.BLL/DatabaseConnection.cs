using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.BLL
{
    class DatabaseConnection
    {
        public SqlConnectionStringBuilder GetConnectionString()
        {
            string connectionString = @"Data Source=(local)\MSSQLEXPRESS2014;" + "Initial Catalog=GTL_TEST; Integrated Security=True";
            string connectionString_ = @"Data Source=(local)\SQL1;" + "Initial Catalog=GTL_TEST; Integrated Security=True";

            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder(connectionString)
            {
                ConnectTimeout = 5
            };

            return connectionStringBuilder;
        }
    }
}
