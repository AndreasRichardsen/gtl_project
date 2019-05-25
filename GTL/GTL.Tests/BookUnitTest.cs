using System;
using GTL.BLL;
using GTL.DAL.Models;
using NUnit.Framework;

namespace GTL.Tests
{
    [TestFixture]
    public class BookUnitTest
    {
       // [Test]
        public void CreateBook_Object_Returns_Book()
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

        //[Test]
        public void CanLoanBook_By_Type_Return_True()
        {
            // Arrange
            string inputType = "Normal";
            BookController ctr = new BookController();
            // Act
            bool expectedResult = true;
            bool actualResult = ctr.CanLoanBookByType(inputType);
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        //[Test]
        public void CanLoanBookCopy_Availability_Returns_True()
        {
            bool isAvailable = false;
            BookController ctr = new BookController();
            bool expectedResult = true;

            bool actualResult = ctr.VerifyCopyAvailable(isAvailable);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
