using System;
using NUnit.Framework;
using Moq;
using GTL.BLL;
using System.Collections.Generic;
using GTL.DAL.Models;

namespace GTL.Unit.Tests
{
    [TestFixture]
    public class LoanBookTests
    {
        Mock<LoanController> mockLoanCtr;
        Mock<BookController> mockBookCtr;
        BookController bookCtr;
        LoanController loanCtr;

        List<Loan> loans; 

        [SetUp]
        public void Setup()
        {
            bookCtr = new BookController();
            loanCtr = new LoanController();
            mockLoanCtr = new Mock<LoanController>();
            mockBookCtr = new Mock<BookController>();
            loans = new List<Loan>();
            loans.Add(new Loan(12345, 55555, 1));
            loans.Add(new Loan(23456, 11111, 1));
            loans.Add(new Loan(34567, 22222, 1));
            loans.Add(new Loan(45678, 66666, 1));
            loans.Add(new Loan(56789, 33333, 1));
        }


        [Test]
        [TestCase(0, true)]
        [TestCase(1, true)]
        [TestCase(5, false)]
        [TestCase(6, false)]
        public void CheckBookLimit_Most_Cases_Return__Can_Loan(int noOfBookLoans, bool expectedResult)
        {
            bool actualResult = loanCtr.CheckLoanBookLimit(noOfBookLoans);
            
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("Normal", true)]
        [TestCase("Reference", false)]
        [TestCase("Rare", false)]
        [TestCase("Other", false)]
        public void CheckBookType_Most_Cases_Return_Can_Loan(string typeOfBook, bool expectedResult)
        {
            bool actualResult = loanCtr.CheckBookType(typeOfBook);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        
    }
}
