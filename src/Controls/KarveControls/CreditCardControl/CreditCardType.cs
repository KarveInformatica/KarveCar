using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KarveControls
{

    public enum CardType
    {
        Unknown = 0,
        MasterCard = 1,
        VISA = 2,
        Amex = 3,
        Discover = 4,
        DinersClub = 5,
        JCB = 6,
        enRoute = 7
    }

    public class CreditCardDetector
    {
        // Class to hold credit card type information
        private class CardTypeInfo
        {
            public CardTypeInfo(string regEx, int length, CardType type)
            {
                RegEx = regEx;
                Length = length;
                Type = type;
            }

            public string RegEx { get; set; }
            public int Length { get; set; }
            public CardType Type { get; set; }
        }
        private static CardTypeInfo[] _cardTypeInfo =
        {
        new CardTypeInfo("^(51|52|53|54|55)", 16, CardType.MasterCard),
        new CardTypeInfo("^(4)", 16, CardType.VISA),
        new CardTypeInfo("^(4)", 13, CardType.VISA),
        new CardTypeInfo("^(34|37)", 15, CardType.Amex),
        new CardTypeInfo("^(6011)", 16, CardType.Discover),
        new CardTypeInfo("^(300|301|302|303|304|305|36|38)",
                   14, CardType.DinersClub),
        new CardTypeInfo("^(3)", 16, CardType.JCB),
        new CardTypeInfo("^(2131|1800)", 15, CardType.JCB),
        new CardTypeInfo("^(2014|2149)", 15, CardType.enRoute),
        };
        public static CardType GetCardType(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber))
            {
                return CardType.Unknown;
            }
            foreach (CardTypeInfo info in _cardTypeInfo)
            {
                if (info != null)
                {
                    if (cardNumber.Length == info.Length &&
                        Regex.IsMatch(cardNumber, info.RegEx))
                        return info.Type;
                }
            }

            return CardType.Unknown;
        }
    }
    
}
