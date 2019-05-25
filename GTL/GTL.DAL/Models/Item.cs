using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.DAL.Models
{
    public abstract class Item
    {
        public long ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public int YearPublishing { get; set; }

        public Item(long isbn, string title, string author, string description, string publisher, int yearPublishing)
        {
            this.ISBN = isbn;
            this.Title = title;
            this.Author = author;
            this.Description = description;
            this.Publisher = publisher;
            this.YearPublishing = yearPublishing;
        }
    }
}
