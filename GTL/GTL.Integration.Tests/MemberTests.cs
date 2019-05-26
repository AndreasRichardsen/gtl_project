using System;
using GTL.BLL;
using GTL.DAL.Models;
using NUnit.Framework;

namespace GTL.Integration.Tests
{
    [TestFixture]
    public class MemberTests
    {
        [Test]
        public void InsertNewMember_Success_Returns_True()
        {
            long inputSSN = 232323232323;
            string inputFirstName = "Jon";
            string inputLastName = "Snow";
            string inputHomeAddress = "Winterfell";
            string inputCampusAddress = "UCN";
            long inputCardNo = 1;
            string inputPersonification = "Student";
            Member inputMember = new Member(inputSSN, inputFirstName, inputLastName, inputHomeAddress,
                inputCampusAddress, inputCardNo, inputPersonification);
            PersonController personCtr = new PersonController();

            bool result = personCtr.InsertNewMember(inputMember);

            Assert.IsTrue(result);
        }

        [Test]
        public void DeleteMemberBySSN_Success_Returns_True()
        {
            long inputSSN = 232323232323;
            PersonController personController = new PersonController();

            bool result = personController.DeleteMemberBySSN(inputSSN);

            Assert.IsTrue(result);
        }
    }
}
