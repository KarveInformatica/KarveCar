using CreditCardValidator;

namespace KarveControls
{
    public class KarveCreditCardDetector
    {
        public static CardIssuer GetCardType(string cardNumber)
        {
            if (!string.IsNullOrEmpty(cardNumber))
            {
                CreditCardDetector detector = new CreditCardDetector(cardNumber);
                return detector.Brand;
            }
            return CardIssuer.Unknown;
        }
    }

}
