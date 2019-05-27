using System;
using GTL.BLL;
using GTL.DAL.Models;
using NUnit.Framework;

namespace GTL.Unit.Tests
{
    [TestFixture]
    public class BookTests
    {
        [Test]
        public void CreateBookObject_Success_Returns_Book()
        {
            // Arrange
            long inputISBN = 1234;
            string inputTitle = "Book1";
            string inputAuthor = "Test Author";
            string inputDescription = "Test description";
            string inputPublisher = "Pub1";
            int inputYearPublishing = 1995;
            string inputType = "Normal";
            BookController ctr = new BookController();
            // Act
            Book expectedResult = new Book(inputISBN, inputTitle, inputAuthor, inputDescription, inputPublisher, inputYearPublishing, inputType);
            Book actualResult = ctr.CreateBook(inputISBN, inputTitle, inputAuthor, inputDescription, inputPublisher, inputYearPublishing, inputType);
            // Assert
            Assert.AreEqual(expectedResult.ISBN, actualResult.ISBN);
            Assert.AreEqual(expectedResult.Title, actualResult.Title);
            Assert.AreEqual(expectedResult.Author, actualResult.Author);
            Assert.AreEqual(expectedResult.Description, actualResult.Description);
            Assert.AreEqual(expectedResult.Publisher, actualResult.Publisher);
            Assert.AreEqual(expectedResult.YearPublishing, actualResult.YearPublishing);
            Assert.AreEqual(expectedResult.Type, actualResult.Type);
        }
    }
}
