using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveControls;
namespace KarveTest.KarveControls
{
    [TestFixture]
    class TestCreditCardDetector
    {
        [Test]
        public void Should_Detect_AValidVisa()
        {

        }
        [Test]
        public void Should_Detect_AValidMasterCard()
        {
           // CreditCardDetector.GetCardType("");
        }
       
        public void Should_Return_ANullCard()
        {
            CreditCardDetector.GetCardType(null);
        }

    }
}
