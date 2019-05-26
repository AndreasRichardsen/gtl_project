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
            long inputISBN = 12345665;
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

        [Test]
        public void DeleteBookByISBN_Success_Returns_True()
        {
            long inputISBN = 12345665;
            BookController bookCtr = new BookController();

            bool actualResult = bookCtr.DeleteBookByIsbn(inputISBN);

            Assert.IsTrue(actualResult);
        }

        [Test]
        public void InsertNewBookCopy_Success_Returns_True()
        {
            long inputISBN = 12345665;
            long inputBarcode = 77777777777;
            BookController bookCtr = new BookController();

            bool result = bookCtr.InsertNewBookCopy(inputISBN, inputBarcode);

            Assert.IsTrue(result);
        }
    }
}
