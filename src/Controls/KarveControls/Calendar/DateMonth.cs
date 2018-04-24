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

    sealed class DateMonth : Control, INotifyPropertyChanged
    {

        public static readonly DependencyProperty MonthIndexDependencyProperty =
DependencyProperty.Register(
"MonthIndex", typeof(int),
typeof(DateMonth), new FrameworkPropertyMetadata(1));

        public static readonly DependencyProperty DaysOffDependencyProperty =
DependencyProperty.Register(
"DaysOff", typeof(IEnumerable<int>),
typeof(DateMonth), new FrameworkPropertyMetadata(new List<int>()));

        public static readonly DependencyProperty MonthNameDependencyProperty = DependencyProperty.Register("MonthName", typeof(string), typeof(DateMonth), new PropertyMetadata(string.Empty));
        private List<string> dayWeek = new List<string>()
        { "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa"};

        private List<string> _monthGrid = new List<string>()
{ String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty
        };
        private List<string> _dayweek;

        public event PropertyChangedEventHandler PropertyChanged;

        public static readonly DependencyProperty YearMonthDependencyProperty = DependencyProperty.Register("YearMonth", typeof(string), typeof(DateMonth), new FrameworkPropertyMetadata(string.Empty));


        /// <summary>
        /// This is called when the tree for the DataField is generated.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            HandleChangedMonthYear();
        }
        /// <summary>
        ///  Set or Get the month index
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
        /// <summary>
        ///  Set or Get the list of vacation days
        /// </summary>
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
        /// <summary>
        ///  Set or get the Year and Month string. A yearmonth string is like "2008.01"
        /// </summary>
        public string YearMonth
        {
            get
            {
              
                return (string)GetValue(YearMonthDependencyProperty);
            }
            set
            {
                SetValue(YearMonthDependencyProperty, value);
            }
        }
        /// <summary>
        ///  Set or get the name of the month.
        /// </summary>
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
        /// <summary>
        ///  Dependency Property for the selected day command
        /// </summary>
        public static readonly DependencyProperty SelectedDayCommandDependencyProperty = DependencyProperty.Register("SelectedDayCommand", typeof(ICommand), typeof(DateMonth), new FrameworkPropertyMetadata(null));

        /// <summary>
        ///  Set or get the selected day command. The selected day command is a command launched for selecting a day.
        /// </summary>
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
 
        private string[] YearMonthArray()
        {
            char[] sep = new char[1] { '.' };
            var value = YearMonth;
            string[] yearmonth = value.Split(sep);
            return yearmonth;
        }
        private void HandleChangedMonthYear()
        {

            int day = 1;
            string[] yearMonth = YearMonthArray();
            var year = Convert.ToInt16(yearMonth[0]);
            var month = Convert.ToInt16(yearMonth[1]);
            DateTime firstDayMonth = new DateTime(year, month, day);
            // now i shall generate the numbers.
            DayOfWeek dayOfWeek = firstDayMonth.DayOfWeek;
            MonthName = firstDayMonth.ToString("Y");
            int currentIterator = (int)dayOfWeek;
            int numdays = computeNumberDays(year, month - 1);
            int j = 1;
            for (int k = currentIterator; k < 38; ++k)
            {
                if (j > numdays)
                    break;

                _monthGrid[k] = string.Format("{0}", j);
                if (DaysOff.Contains<int>(j))
                {
                    HighlightOffDay(j, k);
                }
                else
                {
                    HighlightWorkingDay(j, k);
                }
                j++;
            }
            RaisePropertyChanged("MonthGrid");
        }
        private void HighlightOffDay(int j, int k)
        {
            var partToChange = string.Format("PART_Day_{0}", k);
            TextBlock text = GetTemplateChild(partToChange) as TextBlock;
            if (text != null)
            {
                SelectedDay.SetIsDaySelected(text, true);
                SelectedDay.SetDayIndex(text, k);
                text.MouseLeftButtonDown += Text_MouseLeftButtonDown;
                if (text != null)
                {
                    text.Background = Brushes.Yellow;
                }
            }
        }

        private Tuple<DateTime, bool> CreateCommand(int day, bool enable)
        {
           
            var value = YearMonthArray();
            var year = Convert.ToInt16(value[0]);
            var month = Convert.ToInt16(value[1]);
            DateTime firstDayMonth = new DateTime(year, month, day);
            Tuple<DateTime, bool> tuple = new Tuple<DateTime, bool>(firstDayMonth, enable);
            return tuple;
        }
        private void Text_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock currentButton = sender as TextBlock;

            if (currentButton != null)
            {
                int day = SelectedDay.GetDayIndex(currentButton);
                var param = CreateCommand(day, false);
                List<int> daysOff = DaysOff.ToList();


                if (SelectedDay.GetIsDaySelected(currentButton))
                {
                    currentButton.Background = Brushes.White;
                    daysOff.Remove(day);
                    SelectedDay.SetIsDaySelected(currentButton, false);
                }
                else
                {
                    param = CreateCommand(day, true);
                    currentButton.Background = Brushes.Yellow;
                    daysOff.Add(SelectedDay.GetDayIndex(currentButton));
                    SelectedDay.SetIsDaySelected(currentButton, true);
                }
                DaysOff = daysOff;

                if (SelectedDayCommand != null)
                {
                    SelectedDayCommand.Execute(param);
                }
            }
        }

        private void HighlightWorkingDay(int j, int k)
        {

            var partToChange = string.Format("PART_Day_{0}", k);
            TextBlock text = GetTemplateChild(partToChange) as TextBlock;

            if (text != null)
            {
                text.MouseLeftButtonDown += Text_MouseLeftButtonDown;
                SelectedDay.SetIsDaySelected(text, false);
                SelectedDay.SetDayIndex(text, k);
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
