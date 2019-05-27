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
        public bool InsertNewMember(Member member)
        {
            DatabaseConnection DbConnection = new DatabaseConnection();
            SqlConnectionStringBuilder cnStringBuilder = DbConnection.GetConnectionString();
            PersonDAL personDAL = new PersonDAL();
            return personDAL.InsertNewMember(cnStringBuilder.ConnectionString, member);
        }

        public bool DeleteMemberBySSN(long ssn)
        {
            DatabaseConnection DbConnection = new DatabaseConnection();
            SqlConnectionStringBuilder cnStringBuilder = DbConnection.GetConnectionString();
            PersonDAL personDAL = new PersonDAL();
            return personDAL.DeleteMemberBySSN(cnStringBuilder.ConnectionString, ssn);
        }
    }
}
