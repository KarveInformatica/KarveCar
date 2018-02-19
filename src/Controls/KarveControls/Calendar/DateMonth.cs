using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace KarveControls
{
    [TemplatePart(Name = "PART_Day_1", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_2", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_3", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_4", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_5", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_6", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_7", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_8", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_9", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_10", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_11", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_12", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_13", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_14", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_15", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_16", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_17", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_18", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_19", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_20", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_21", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_22", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_23", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_24", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_25", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_26", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_27", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_28", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_29", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_30", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_31", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_32", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_33", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Day_34", Type = typeof(TextBlock))]

    class DateMonth : Control, INotifyPropertyChanged
    {

        public static readonly DependencyProperty MonthIndexDependencyProperty =
DependencyProperty.Register(
"MonthIndex", typeof(int),
typeof(DateMonth), new FrameworkPropertyMetadata(1));

        public static readonly DependencyProperty DaysOffDependencyProperty =
DependencyProperty.Register(
"DaysOff", typeof(IEnumerable<int>),
typeof(DateMonth), new FrameworkPropertyMetadata(new List<int>(),OnYearMonthChange));

        public static readonly DependencyProperty MonthNameDependencyProperty = DependencyProperty.Register("MonthName", typeof(string), typeof(DateMonth), new PropertyMetadata(string.Empty));
        private List<string> dayWeek = new List<string>()
        { "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa"};

        private List<string> _monthGrid = new List<string>()
{ String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty
        };
        private List<string> _dayweek;
        private int _rowIdx;
        private int _colIdx;

        public event PropertyChangedEventHandler PropertyChanged;

        public static readonly DependencyProperty YearMonthDependencyProperty = DependencyProperty.Register("YearMonth", typeof(string), typeof(DateMonth), new FrameworkPropertyMetadata(string.Empty,OnYearMonthChange));


        /// <summary>
        ///  Month index selected.
        /// </summary>
        public int MonthIndex
        {
            get
            {
                return (int)GetValue(MonthIndexDependencyProperty);
            }
            set
            {
                SetValue(MonthIndexDependencyProperty, value);
            }
        }


        public IEnumerable<int> DaysOff
        {
            get
            {
                return (IEnumerable<int>)GetValue(DaysOffDependencyProperty);
            }
            set
            {
                SetValue(DaysOffDependencyProperty, value);
            }
        }


        public string YearMonth
        {
            get
            {
                return (string) GetValue(YearMonthDependencyProperty);
            }
            set
            {
                SetValue(YearMonthDependencyProperty, value);
            }
        }
      
        public string MonthName
        {
            get
            {
                return (string)GetValue(MonthNameDependencyProperty);
            }
            set
            {
                SetValue(MonthNameDependencyProperty, value);
            }
        }
        public static readonly DependencyProperty SelectedDayCommandDependencyProperty = DependencyProperty.Register("SelectedDayCommand", typeof(ICommand), typeof(DateMonth), new FrameworkPropertyMetadata(null));


        public ICommand SelectedDayCommand
        {
            get
            {
                return (ICommand)GetValue(SelectedDayCommandDependencyProperty);
            }
            set
            {
                SetValue(SelectedDayCommandDependencyProperty, value);
            }
        }
        private static void OnYearMonthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DateMonth control = d as DateMonth;
            if (control != null)
            {
                control.HandleChangedMonthYear(e.NewValue);
            }
        }
        private void HandleChangedMonthYear(object newValue)
        {
          
            char[] sep = new char[1] { '.' };
            var value = YearMonth;
            int day = 1;
            if (value == null)
            {
                return;
            }
            string[] yearmonth = value.Split(sep);
            if (yearmonth.Length != 2)
            {
                return;
            }
            var year = Convert.ToInt16(yearmonth[0]);
            var month = Convert.ToInt16(yearmonth[1]);
            DateTime firstDayMonth = new DateTime(year,month, day);
       
                   
            // now i shall generate the numbers.
            DayOfWeek dayOfWeek = firstDayMonth.DayOfWeek;
            MonthName= firstDayMonth.ToString("Y");
            int currentIterator = (int)dayOfWeek;
            int numdays = computeNumberDays(year, month - 1);
            int j = 1;
            for (int k = currentIterator; k < 38; ++k)
            {
                 if (j > numdays)
                    break;
                 
                _monthGrid[k] = string.Format("{0}", j);
                if (DaysOff.Contains<int>(k))
                {
                    HighlightOffDay(k);
                }
                else
                {
                    HighlightWorkingDay(k);
                }
                j++;
            }
            RaisePropertyChanged("MonthGrid");
        }
        private void HighlightOffDay(int k)
        {
    
              var partToChange = string.Format("PART_Day_{0}", k);
                TextBlock text = GetTemplateChild(partToChange) as TextBlock;
                if (text!=null)
                {
                    text.Background = Brushes.Yellow;
                }
            
        }
        private void HighlightWorkingDay(int k)
        {
                var partToChange = string.Format("PART_Day_{0}", k);
                TextBlock text = GetTemplateChild(partToChange) as TextBlock;
                if (text != null)
                {
                    text.Background = Brushes.White;
                }
            
        }

        private int computeNumberDays(int year, int month)
        {
            int[] numDays = new int[12]
            {
                31,28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31
            };
            if ((isLeapYear(year)) && (month == 2))
            {
                return 29;
            }
            return numDays[month];
        }
        private bool isLeapYear(int year)
        {
            bool leap = ((year % 4) == 0);
            return leap;
        }

        public DateMonth()
        {
            DayWeek = dayWeek;
        }
        static DateMonth()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DateMonth),
                                                           new FrameworkPropertyMetadata(typeof(DateMonth)));
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public List<string> DayWeek
        {
            set
            {
                _dayweek = value;
                RaisePropertyChanged("DayWeek");
            }
            get
            {
                return _dayweek;
            }
        }
        public List<string> MonthGrid
        {
            set
            {
                _monthGrid = value;
                RaisePropertyChanged("MonthGrid");
            }
            get
            {
                return _monthGrid;
            }
        }
    }
}
