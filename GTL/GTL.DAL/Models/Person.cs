using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.DAL.Models
{
    public abstract class Person
    {
        public long SSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomeAddress { get; set; }
        public string CampusAddress { get; set; }
        public long CardNo { get; set; }

        public Person(long ssn, string firstName, string lastName, 
            string homeAddress, string campusAddress, long cardNo)
        {
            SSN = ssn;
            FirstName = firstName;
            LastName = lastName;
            HomeAddress = homeAddress;
            CampusAddress = campusAddress;
            CardNo = cardNo;
        }
    }
}
