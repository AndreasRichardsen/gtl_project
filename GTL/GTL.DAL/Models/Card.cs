using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.DAL.Models
{
    public class Card
    {
        public long CardNo { get; set; }
        public string IssueDate { get; set; }

        public Card(long cardno, string issuedate)
        {
            this.CardNo = cardno;
            this.IssueDate = issuedate;
        }
        
    }
}
