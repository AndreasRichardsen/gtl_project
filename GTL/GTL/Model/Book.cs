using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.Model
{
    public class Book
    {
        public int ISBN { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public Enum Type { get; set; }

        public Enum Subject { get; set; }

        public string Publisher { get; set; }

        public int YearOfPublishing { get; set; }

        public int NoOfCopies { get; set; }

        public int AvailableNoOfCopies { get; set; }

        public Book()
        {

        }

        public Book(int ISBN, string Title)
        {
            this.ISBN = ISBN;
            this.Title = Title;
        }
    }
}
