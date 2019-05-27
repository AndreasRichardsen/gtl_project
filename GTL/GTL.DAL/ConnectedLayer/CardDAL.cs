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
    }
}
