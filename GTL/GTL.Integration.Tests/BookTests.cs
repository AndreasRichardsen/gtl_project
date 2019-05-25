using System;
using System.Configuration;
using GTL.BLL;
using GTL.DAL.Models;
using NUnit.Framework;

namespace GTL.Integration.Tests
{
    [TestFixture]
    public class BookTests
    {
        [Test]
        public void InsertNewBook_Success_Returns_True()
        {
            // Arrange 
            long inputISBN = 12345677;
            string inputTitle = "Test Book 1";
            string inputAuthor = "Test Author";
            string inputDescription = "Test description";
            string inputPublisher = "Publisher of Testing";
            int inputYearPublishing = 1995;
            string inputType = "Normal";
            Book inputBook = new Book(inputISBN, inputTitle, inputAuthor, 
                inputDescription, inputPublisher, inputYearPublishing, inputType);
            BookController bookCtr = new BookController();
            bool expectedResult = true;
            // Act
            bool actualResult = bookCtr.AddBook(inputBook);
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
