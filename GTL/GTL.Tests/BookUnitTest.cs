using System;
using GTL.Model;
using GTL.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GTL.Tests
{
    [TestClass]
    public class BookUnitTest
    {
        [TestMethod]
        public void BasicAddBookTest()
        {
            // Arrange
            Book book = new Book();
            BookController ctr = new BookController();
            // Act
            bool expectedResult = true;
            bool actualResult = ctr.AddBook(book);
            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void BasicCreateBookTest()
        {
            // Arrange
            int inputISBN = 1234;
            string inputTitle = "Book1";
            BookController ctr = new BookController();
            // Act
            Book expectedResult = new Book(inputISBN, inputTitle);
            Book actualResult = ctr.CreateBook(inputISBN, inputTitle);
            // Assert
            Assert.AreEqual(expectedResult.ISBN, actualResult.ISBN);
            Assert.AreEqual(expectedResult.Title, actualResult.Title);
            
        }
    }
}
