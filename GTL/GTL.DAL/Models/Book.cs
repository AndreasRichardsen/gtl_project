using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.DAL.Models
{
    public class Book : Item
    {
        public string Type { get; set; }

        public Book(long isbn, 
            string title, 
            string author,
            string description,
            string publisher,
            int yearPublishing,
            string type) : base(isbn, title, author, description, publisher, yearPublishing)
        {
            this.Type = type;
        }
    }
}
