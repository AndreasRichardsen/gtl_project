using System;
using GTL.Model;
using GTL.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GTL.Tests
{
    [TestClass]
    public class MemberUnitTest
    {
        [TestMethod]
        public void BasicCreateMember()
        {
            string inputSSN = "1234";
            string inputFName = "John";
            MemberController ctr = new MemberController();

            Member expectedResult = new Member(inputSSN, inputFName);
            Member actualResult = ctr.CreateMember(inputSSN, inputFName);

            Assert.AreEqual(expectedResult.SSN, actualResult.SSN);
            Assert.AreEqual(expectedResult.FirstName, actualResult.FirstName);
        }
    }
}
