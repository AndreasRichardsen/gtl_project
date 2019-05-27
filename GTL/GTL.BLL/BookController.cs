using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Configuration;
using GTL.DAL.ConnectedLayer;
using GTL.DAL.Models;
using System.Data.SqlClient;

namespace GTL.BLL
{
    public class BookController
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

        public bool AddBook(Book book)
        {
            SqlConnectionStringBuilder cnStringBuilder = GetConnectionString();
            BookDAL bookDAL = new BookDAL();
            return bookDAL.InsertNewBook(cnStringBuilder.ConnectionString, book);
        }

        public Book CreateBook(long inputISBN, string inputTitle, string inputAuthor, string inputDescription, string inputPublisher, int inputYearPublishing, string inputType)
        {
            return new Book(inputISBN, inputTitle, inputAuthor, inputDescription, inputPublisher, inputYearPublishing, inputType);
        }

        public bool DeleteBookByIsbn(long isbn)
        {
            SqlConnectionStringBuilder cnStringBuilder = GetConnectionString();
            BookDAL bookDAL = new BookDAL();
            return bookDAL.DeleteBookByIsbn(cnStringBuilder.ConnectionString, isbn);
        }

        public bool InsertNewBookCopy(long isbn, long barcode)
        {
            SqlConnectionStringBuilder cnStringBuilder = GetConnectionString();
            BookDAL bookDAL = new BookDAL();
            return bookDAL.InsertNewBookCopy(cnStringBuilder.ConnectionString, isbn, barcode);
        }

        public bool CheckBook(long isbn, long barcode)
        {
            return false;
        }
    }
}
