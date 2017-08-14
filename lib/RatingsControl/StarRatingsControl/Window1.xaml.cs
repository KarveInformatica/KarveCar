using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StarRatingsControl
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                ratings1.Value = Decimal.Parse(txtValue.Text);
                ratings1.NumberOfStars = Int32.Parse(txtNumStars.Text);
                ratings1.BackgroundColor = Brushes.White;
                ratings1.StarForegroundColor = Brushes.Orange;
                ratings1.StarOutlineColor = Brushes.DarkGray;


                ratings2.Value = Decimal.Parse(txtValue.Text);
                ratings2.NumberOfStars = Int32.Parse(txtNumStars.Text);
                ratings2.BackgroundColor = Brushes.LightGray;
                ratings2.StarForegroundColor = Brushes.Black;
                ratings2.StarOutlineColor = Brushes.Black;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Try typing some correct numbers, and give it a chance");
            }
        }
    }
}
