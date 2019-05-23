using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.Common;
using static System.Console;

namespace GTL.CUIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataProvider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.AppSettings["connectionString"];

            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);

            using(DbConnection connection = factory.CreateConnection())
            {
                if(connection == null)
                {
                    ShowError("Connection");
                    return;
                }

                connection.ConnectionString = connectionString;
                connection.Open();

                DbCommand command = factory.CreateCommand();
                if (command == null)
                {
                    ShowError("Command");
                    return;
                }

                command.Connection = connection;
                command.CommandText = "SELECT top 10 * FROM Item";

                using(DbDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        WriteLine($"Item {dataReader["Title"]} is written by {dataReader["Author"]}.");
                    }
                }
            }
            ReadLine();
        }

        private static void ShowError(string objectName)
        {
            WriteLine($"There was an issue creating the {objectName}");
            ReadLine();
        }
    }
}
