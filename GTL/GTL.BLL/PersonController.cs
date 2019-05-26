using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.DAL.ConnectedLayer;
using GTL.DAL.Models;

namespace GTL.BLL
{
    public class PersonController
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

        public bool InsertNewMember(Member member)
        {
            SqlConnectionStringBuilder cnStringBuilder = GetConnectionString();
            PersonDAL personDAL = new PersonDAL();
            return personDAL.InsertNewMember(cnStringBuilder.ConnectionString, member);
        }

        public bool DeleteMemberBySSN(long ssn)
        {
            SqlConnectionStringBuilder cnStringBuilder = GetConnectionString();
            PersonDAL personDAL = new PersonDAL();
            return personDAL.DeleteMemberBySSN(cnStringBuilder.ConnectionString, ssn);
        }
    }
}
