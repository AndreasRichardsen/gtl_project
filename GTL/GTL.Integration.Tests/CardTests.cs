using System;
using GTL.BLL;
using NUnit.Framework;

namespace GTL.Integration.Tests
{
    [TestFixture]
    public class CardTests
    {
        [Test]
        public void InsertNewCard_Success_Returns_True()
        {
            string inputIssueDate = DateTime.Now.ToString("yyyy-MM-dd");

            CardController cardCtr = new CardController();

            bool result = cardCtr.InsertNewCard(inputIssueDate);

            Assert.IsTrue(result);
        }

        [Test]
        public void DeleteCardByCardNo_Success_Returns_True()
        {
            long inputCardNo = 2;
            CardController cardCtr = new CardController();

            bool result = cardCtr.DeleteCardByCardNo(inputCardNo);

            Assert.IsTrue(result);
        }
    }
}
