using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Model;

namespace GTL.Business
{
    public class BookController
    {
        public bool AddBook(Book book)
        {
            // cant unit test this yet cause db 
            // TODO integration test
            throw new NotImplementedException();
        }

        public Book CreateBook(int ISBN, string Title)
        {
            return new Book(ISBN, Title);
        }
    }
}
