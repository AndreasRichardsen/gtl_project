using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.DAL.Models
{
    public class Member : Person
    {
        public string Personification { get; set; }

        public Member(long ssn, string firstName, string lastName,
            string homeAddress, string campusAddress, long cardNo, string personfication)
            : base(ssn, firstName, lastName, homeAddress, campusAddress, cardNo)
        {
            Personification = personfication;
        }
    }
}
