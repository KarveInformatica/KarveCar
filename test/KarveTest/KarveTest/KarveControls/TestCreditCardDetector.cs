using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveControls;
using KarveCommon.Validation;
namespace KarveTest.KarveControls
{
    [TestFixture]
    class TestCreditCardDetector
    {
        [Test]
        public void Should_Detect_AValidVisa()
        {
            var number = "4012888888881881";
            var type = CreditCardDetector.GetCardType(number);
            Assert.AreEqual(CardType.VISA, type);
        }
        [Test]
        public void Should_Detect_AFakeVisa()
        {
            var number = "40128888888818";
            var type = CreditCardDetector.GetCardType(number);
            Assert.AreNotEqual(CardType.VISA, type);
        }
        [Test]
        public void Should_Detect_AValidMasterCard()
        {
            var number = "5105105105105100";
            var type = CreditCardDetector.GetCardType(number);
            Assert.AreEqual(CardType.MasterCard, type);
        }
        [Test]
        public void Should_Detect_AValidAmexCard()
        {
            var number = "371449635398431";
            var type = CreditCardDetector.GetCardType(number);
            Assert.AreEqual(CardType.Amex, type);
        }
        [Test]
        public void Should_Detect_AValidDiners()
        {
            var number = "30569309025904";
            var type = CreditCardDetector.GetCardType(number);
            Assert.AreEqual(CardType.DinersClub, type);
        }

        public void Should_Return_ANullCard()
        {
            CreditCardDetector.GetCardType(null);
        }

    }
}
