using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KarveControls
{
    public class CreditCardControlExt : Control
    {
        /// <summary>
        ///  default ctor.
        /// </summary>
        public static readonly DependencyProperty CardHolderProperty =
          DependencyProperty.Register(
              "CardHolder",
              typeof(string),
              typeof(CreditCardControlExt),
              new PropertyMetadata(string.Empty));

        public string CardHolder
        {
            get { return (string)GetValue(CardHolderProperty); }
            set { SetValue(CardHolderProperty, value); }
        }

        public static readonly DependencyProperty CardNumberProperty =
     DependencyProperty.Register(
         "CardNumber",
         typeof(string),
         typeof(CreditCardControlExt),
         new PropertyMetadata(string.Empty, OnChangedNumber));

        private static void OnChangedNumber(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            const string defaultPath = "/KarveControls;component/Images/creditcard.png";
            var newNumber = e.NewValue as string;
            var cardPath = defaultPath;
            var value = CreditCardDetector.GetCardType(newNumber);
            switch (value)
            {
                case CardType.MasterCard:
                    cardPath = "/KarveControls;component/Images/mastercard.jpeg";
                    break;
                case CardType.VISA:
                    cardPath = "/KarveControls;component/Images/visa.png";
                    break;
                case CardType.Amex:
                    cardPath = "/KarveControls;component/Images/amex.png";
                    break;
                case CardType.Discover:
                    cardPath = "/KarveControls;component/Images/discover.png";
                    break;
                case CardType.DinersClub:
                    cardPath = "/KarveControls;component/Images/diners.png";
                    break;
                case CardType.JCB:
                    cardPath = "/KarveControls;component/Images/jcb.png";
                    break;
                default:
                    break;
            }
            if (d is CreditCardControlExt ext)
            {
                ext.CardImagePath = cardPath;
            }
        }
        private static bool IsMasterCard(string card)
        {
            return ((card.StartsWith("5")) || (card.StartsWith("2")));
        }
        public static bool IsAmex(string amex)
        {
            // Valid length: 15 digits. 
            // First digit must be a 3 and second digit must be a 4 or 7.
           return (amex.StartsWith("34")) || (amex.StartsWith("37"));
        }   

        public string CardNumber
        {
            get { return (string)GetValue(CardNumberProperty); }
            set { SetValue(CardNumberProperty, value); }
        }

        public static readonly DependencyProperty CardImagePathProperty =
  DependencyProperty.Register(
      "CardImagePath",
      typeof(string),
      typeof(CreditCardControlExt),
      new PropertyMetadata(string.Empty));
        public string CardImagePath
        {
            get { return (string)GetValue(CardImagePathProperty); }
            set { SetValue(CardImagePathProperty, value); }
        }


        public static readonly DependencyProperty VisibilitySecurityProperty =
   DependencyProperty.Register(
       "VisibilitySecurity",
       typeof(Visibility),
       typeof(CreditCardControlExt),
       new PropertyMetadata(Visibility.Visible));
        public Visibility VisibilitySecurity
        {
            get { return (Visibility)GetValue(VisibilitySecurityProperty); }
            set { SetValue(VisibilitySecurityProperty, value); }
        }

        public static readonly DependencyProperty VisibilityTokenProperty =
DependencyProperty.Register(
 "VisibilityToken",
 typeof(Visibility),
 typeof(CreditCardControlExt),
 new PropertyMetadata(Visibility.Visible));
        public Visibility VisibilityToken
        {
            get { return (Visibility)GetValue(VisibilityTokenProperty); }
            set { SetValue(VisibilityTokenProperty, value); }
        }

        public static readonly DependencyProperty ExpiryMonthProperty =
     DependencyProperty.Register(
         "ExpiryMonth",
         typeof(string),
         typeof(CreditCardControlExt),
         new PropertyMetadata(string.Empty));

        public string ExpiryMonth
        {
            get { return (string)GetValue(ExpiryMonthProperty); }
            set { SetValue(ExpiryMonthProperty, value); }
        }
        public static readonly DependencyProperty ExpiryYearProperty =
            DependencyProperty.Register(
            "ExpiryYear",
             typeof(string),
            typeof(CreditCardControlExt),
            new PropertyMetadata(string.Empty));

        public string ExpiryYear
        {
            get { return (string)GetValue(ExpiryYearProperty); }
            set { SetValue(ExpiryYearProperty, value); }
        }

        public static readonly DependencyProperty FirstCodeProperty =
        DependencyProperty.Register(
    "FirstCode",
     typeof(string),
    typeof(CreditCardControlExt),
    new PropertyMetadata(string.Empty));

        public string FirstCode
        {
            get { return (string)GetValue(FirstCodeProperty); }
            set { SetValue(FirstCodeProperty, value); }
        }

        public static readonly DependencyProperty SecondCodeProperty =
        DependencyProperty.Register(
    "SecondCode",
     typeof(string),
    typeof(CreditCardControlExt),
    new PropertyMetadata(string.Empty));

        public string SecondCode
        {
            get { return (string)GetValue(SecondCodeProperty); }
            set { SetValue(SecondCodeProperty, value); }
        }


        public static readonly DependencyProperty AssistCommandProperty =
        DependencyProperty.Register(
    "AssistCommand",
     typeof(ICommand),
    typeof(CreditCardControlExt),
    new PropertyMetadata(null));

        public ICommand AssistCommand
        {
            get { return (ICommand)GetValue(AssistCommandProperty); }
            set { SetValue(AssistCommandProperty, value); }
        }
        public static readonly DependencyProperty ItemChangedCommandProperty =
       DependencyProperty.Register(
   "ItemChangedCommand",
    typeof(ICommand),
   typeof(CreditCardControlExt),
   new PropertyMetadata(null));

        public ICommand ItemChangedCommand
        {
            get { return (ICommand)GetValue(ItemChangedCommandProperty); }
            set { SetValue(ItemChangedCommandProperty, value); }
        }

        public static readonly DependencyProperty DataObjectProperty =
       DependencyProperty.Register(
   "DataObject",
    typeof(object),
   typeof(CreditCardControlExt),
   new PropertyMetadata(null));

        public object DataObject
        {
            get { return GetValue(DataObjectProperty); }
            set { SetValue(DataObjectProperty, value); }
        }
        public static readonly DependencyProperty CreditCardViewProperty =
DependencyProperty.Register(
"CreditCardView",
typeof(object),
typeof(CreditCardControlExt),
new PropertyMetadata(null));

        public object CreditCardView
        {
            get { return GetValue(DataObjectProperty); }
            set { SetValue(DataObjectProperty, value); }
        }
        public CreditCardControlExt() : base()
        {
        }
        static CreditCardControlExt()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CreditCardControlExt), new FrameworkPropertyMetadata(typeof(CreditCardControlExt)));

        }
    }
}
