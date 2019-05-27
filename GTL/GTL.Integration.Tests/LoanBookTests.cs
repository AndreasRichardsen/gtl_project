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
        [TestCase(1234567890, 77777777788, true)]
        [TestCase(1234567890, 77777777780, false)]
        public void MatchBookIsbnWithBookCopyBarcode(long isbn, long barcode, bool expectedResult)
        {
            LoanController loanCtr = new LoanController();

            bool actualResult = loanCtr.MatchBookWithCopy(isbn, barcode);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(77777777788, false)]
        [TestCase(77777777777, true)]
        public void VerifyBookCopyIsAvailable_Success_Returns_True(long barcode, bool expectedResult)
        {
            LoanController loanCtr = new LoanController();

            bool actualResult = loanCtr.VerifyBookCopyIsAvailable(barcode);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(1, true)]
        [TestCase(3, false)]
        public void VerifyCardNotExpired_Success_Returns_True(int cardNo, bool expectedResult)
        {
            LoanController loanCtr = new LoanController();

            bool actualResult = loanCtr.VerifyCardNotExpired(cardNo);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
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
