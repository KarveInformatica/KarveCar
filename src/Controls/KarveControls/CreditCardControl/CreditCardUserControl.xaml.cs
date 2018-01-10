using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// KarveControls.CreditCardUserControl

namespace KarveControls
{
    /// <summary>
    /// Interaction logic for CreditCardUserControl.xaml
    /// </summary>
    public partial class CreditCardUserControl : UserControl
    {
        /// <summary>
        ///  CardOwner. This is the owern of the credit card.
        /// </summary>
        public static readonly DependencyProperty CreditCardDependencyProperty =
           DependencyProperty.Register(
               "CardOwner",
               typeof(string),
               typeof(CreditCardUserControl),
               new PropertyMetadata(string.Empty));
        /// <summary>
        ///  This is the card number. The number of the card.
        /// </summary>
        public static readonly DependencyProperty CreditNumberDependencyProperty =
         DependencyProperty.Register(
             "CardNumber",
             typeof(string),
             typeof(CreditCardUserControl),
             new PropertyMetadata(string.Empty));
        /// <summary>
        ///  The expiry month the month of the card.
        /// </summary>
        public static readonly DependencyProperty ExpiryMonthDependencyProperty =
         DependencyProperty.Register(
             "ExpiryMonth",
             typeof(string),
             typeof(CreditCardUserControl),
             new PropertyMetadata(string.Empty));

        /// <summary>
        ///  Expiry year is the year of the card.
        /// </summary>
        public static readonly DependencyProperty ExpiryYearDependencyProperty =
         DependencyProperty.Register(
             "ExpiryYear",
             typeof(string),
             typeof(CreditCardUserControl),
             new PropertyMetadata(string.Empty));

        /// <summary>
        ///  Security code of the card.
        /// </summary>
        public static readonly DependencyProperty SecurityCodeDependencyProperty =
         DependencyProperty.Register(
             "SecurityCode",
             typeof(string),
             typeof(CreditCardUserControl),
             new PropertyMetadata(string.Empty));
        /// <summary>
        ///  Postal code 
        /// </summary>
        public static readonly DependencyProperty PostalCodeDependencyProperty =
         DependencyProperty.Register(
             "PostalCode",
             typeof(string),
             typeof(CreditCardUserControl),
             new PropertyMetadata(string.Empty));

        public CreditCardUserControl()
        {
            InitializeComponent();
        }
    }
}
