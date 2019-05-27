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
        CommandBuilder cmdBuilder = new CommandBuilder();

        public bool InsertNewMember(string connectionString, Member newMember)
        {

            string sql = "INSERT INTO Person (SSN, FName, LName, HomeAddress, CampusAddress, CardNo) " +
                $"VALUES ('{newMember.SSN}', '{newMember.FirstName}', '{newMember.LastName}', '{newMember.HomeAddress}'," +
                $" '{newMember.CampusAddress}', '{newMember.CardNo}');" +
                "INSERT INTO Member(SSN, Personification) " + $"VALUES('{newMember.SSN}', '{newMember.Personification}');";

            return cmdBuilder.ExecuteCommand(connectionString, sql);
        }

        public bool DeleteMemberBySSN(string connectionString, long ssn)
        {

            string sql = $"DELETE FROM Person WHERE SSN = '{ssn}';";

            return cmdBuilder.ExecuteCommand(connectionString, sql);
        }
    }
}
