using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Model;

namespace GTL.Business
{
    public class MemberController
    {
        public Member CreateMember(string SSN, string FName)
        {
            return new Member(SSN, FName);
        }
    }
}
