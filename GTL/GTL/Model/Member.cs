using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.Model
{
    public class Member
    {
        public string SSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Enum Type { get; set; }
        public string CampusAddress { get; set; }
        public string HomeAddress { get; set; }
        public string[] PhoneNumbers { get; set; }
    }
}
