using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ExtendedGrid.Classes
{
    public class SummaryColumnSettings:DependencyObject
    {
       

        public ObservableCollection<ISummaryOperands> SummaryOperands
        {
            get
            {
                if (GetValue(SummaryOperandsProperty)==null)
                    return new ObservableCollection<ISummaryOperands>();
                return (ObservableCollection<ISummaryOperands>)GetValue(SummaryOperandsProperty);
            }
            set
            {
                SetValue(SummaryOperandsProperty, value);

            }
        }

        public static readonly DependencyProperty SummaryOperandsProperty = DependencyProperty.Register(
            "SummaryOperands", typeof (ObservableCollection<ISummaryOperands>),typeof(DataGridColumn),new PropertyMetadata(new ObservableCollection<ISummaryOperands>()));
    }
}
