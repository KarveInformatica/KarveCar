using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveControls;
using KarveCommon.Validation;
using CreditCardValidator;
namespace KarveTest.KarveControls
{
    [TestFixture]
    class TestCreditCardDetector
    {
        [Test]
        public void Should_Detect_AValidVisa()
        {
            var number = "4012888888881881";
            var type = KarveCreditCardDetector.GetCardType(number);
            Assert.AreEqual(CardIssuer.Visa, type);
        }
        [Test]
        public void Should_Detect_AFakeVisa()
        {
            var number = "40128888888818";
            var type = KarveCreditCardDetector.GetCardType(number);
            Assert.AreNotEqual(CardIssuer.Visa, type);
        }
        [Test]
        public void Should_Detect_AValidMasterCard()
        {
            var number = "5105105105105100";
            var type = KarveCreditCardDetector.GetCardType(number);
            Assert.AreEqual(CardIssuer.MasterCard, type);
        }
        [Test]
        public void Should_Detect_AValidAmexCard()
        {
            var number = "371449635398431";
            var type = KarveCreditCardDetector.GetCardType(number);
            Assert.AreEqual(CardIssuer.AmericanExpress, type);
        }
        [Test]
        public void Should_Detect_AValidDiners()
        {
            var number = "30569309025904";
            var type = KarveCreditCardDetector.GetCardType(number);
            Assert.AreEqual(CardIssuer.DinersClub, type);
        }

    }
}
