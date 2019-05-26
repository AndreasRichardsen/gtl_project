using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.DAL.Models
{
    public class Loan
    {
        public long ISBN { get; set; }
        public long Barcode { get; set; }
        public long CardNo { get; set; }
        public bool IsReturned { get; set; }
        public string DateBorrowed { get; set; }

        public Loan(long isbn, long barcode, long cardNo)
        {
            ISBN = isbn;
            Barcode = barcode;
            CardNo = cardNo;
            IsReturned = false;
            DateBorrowed = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
}
