using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.DAL.Models
{
    public class BookCopy
    {
        public long ISBN { get; set; }
        public long Barcode { get; set; }

        public BookCopy()
        {

        }

        public BookCopy(long isbn, long barcode)
        {
            ISBN = isbn;
            Barcode = barcode;
        }
    }
}
