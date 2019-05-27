using GTL.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.DAL.ConnectedLayer
{
    public class BookDAL
    {
        CommandBuilder cmdBuilder = new CommandBuilder();

        public bool InsertNewBook(string connectionString, Book newBook)
        {

            string sql = "INSERT INTO Item (ISBN, Title, Author, ItemDescription, Publisher, YearPublishing) " +
                $"VALUES ('{newBook.ISBN}', '{newBook.Title}', '{newBook.Author}', '{newBook.Description}'," +
                $" '{newBook.Publisher}', '{newBook.YearPublishing}');" +
                "INSERT INTO Book(ISBN, BookType) " + $"VALUES('{newBook.ISBN}', '{newBook.Type}');";

            return cmdBuilder.ExecuteCommand(connectionString, sql);
        }

        public bool DeleteBookByIsbn(string connectionString, long isbn)
        {

            string sql = $"DELETE FROM Book WHERE ISBN = '{isbn}';" +
                $"DELETE FROM Item WHERE ISBN = '{isbn}';";

            return cmdBuilder.ExecuteCommand(connectionString, sql);
        }

        public bool InsertNewBookCopy(string connectionString, long isbn, long barcode)
        {

            string sql = $"INSERT INTO BookCopy (ISBN, Barcode) VALUES ('{isbn}', '{barcode}');";

            return cmdBuilder.ExecuteCommand(connectionString, sql);
        }
    }
}
