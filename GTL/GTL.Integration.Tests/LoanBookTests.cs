using System;
using GTL.BLL;
using GTL.DAL.Models;
using NUnit.Framework;

namespace GTL.Integration.Tests
{
    [TestFixture]
    public class LoanBookTests
    {
        [Test]
        public void InsertNewLoan_Success_Returns_True()
        {
            long inputISBN = 1234567890;
            long inputBarcode = 77777777788;
            long inputCardNo = 1;
            Loan inputLoan = new Loan(inputISBN, inputBarcode, inputCardNo);
            LoanController loanCtr = new LoanController();

            bool result = loanCtr.InsertNewLoan(inputLoan);

            Assert.IsTrue(result);
        }

        [Test]
        public void DeleteLoanById_Success_Returns_True()
        {
            long inputId = 1;
            LoanController loanCtr = new LoanController();

            bool result = loanCtr.DeleteLoanById(inputId);

            Assert.IsTrue(result);
        }
    }
}
