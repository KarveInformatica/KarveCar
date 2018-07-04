using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Globalization;
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

    // DateMonth control is a control that it will show a month in a calendar

    internal sealed class DateMonth : Control, INotifyPropertyChanged
    {

        public static readonly DependencyProperty MonthIndexDependencyProperty =
DependencyProperty.Register(
"MonthIndex", typeof(int),
typeof(DateMonth), new FrameworkPropertyMetadata(1));

        public static readonly DependencyProperty DaysOffDependencyProperty =
DependencyProperty.Register(
"DaysOff", typeof(IEnumerable<int>),
typeof(DateMonth), new FrameworkPropertyMetadata(new ObservableCollection<int>(), OnDaysChanged));



        public static readonly DependencyProperty MonthNameDependencyProperty = DependencyProperty.Register("MonthName", typeof(string), typeof(DateMonth), new PropertyMetadata(string.Empty));

        private List<string> dayWeek = new List<string>();
        // localized version of dayWeek. 
        // At the beginning in the constructor we will provide you the correct one.
        private List<string> dayWeek_en = new List<string>()
        { "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa"};
        private List<string> dayWeek_es = new List<string>()
        { "Do", "Lu", "Ma", "Mi", "Ju", "Vi", "Sa"};
        private List<string> dayWeek_it = new List<string>()
        { "Do", "Lu", "Ma", "Mi", "Gi", "Ve", "Sa"};
        private List<string> dayWeek_de = new List<string>()
        { "Su", "Mo", "Di", "Mi", "Do", "Fr", "Sa"};
        /// <summary>
        ///  Dependency Property for the selected day command
        /// </summary>
        public static readonly DependencyProperty ResetCommandProperty = DependencyProperty.Register("ResetCommand", typeof(ICommand), typeof(DateMonth));

        private List<string> _monthGrid = new List<string>()
{ String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty
        };
        private List<string> _dayweek;

        private ICommand _resetCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public static readonly DependencyProperty YearMonthDependencyProperty = DependencyProperty.Register("YearMonth", typeof(string), typeof(DateMonth), new FrameworkPropertyMetadata(string.Empty));


        /// <summary>
        /// Method to be called when the visual tree is generated. 
        /// Draw the calendar days following the culture of the current thread.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var apply = Thread.CurrentThread.CurrentUICulture;
            SetCulture(apply);     
            HandleChangedMonthYear();
            _resetCommand = new DelegateCommand(OnReset);
        }
        private void SetCulture(CultureInfo apply)
        {
            var lang = apply.TwoLetterISOLanguageName.ToUpper();
            switch(lang)
            {
                case "ES": { _dayweek = dayWeek_es; break; }
                case "EN": { _dayweek = dayWeek_en; break; }
                case "DE": { _dayweek = dayWeek_de; break; }
                case "IT": { _dayweek = dayWeek_it; break; }
                default:
                    _dayweek = dayWeek_en;
                    break;
            }
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

        /// <summary>
        ///  Set or get the selected day command. The selected day command is a command launched for selecting a day.
        /// </summary>
        public ICommand ResetCommand
        {
            get
            {
                return (ICommand)GetValue(ResetCommandProperty);
            }
            set
            {
                SetValue(ResetCommandProperty, value);
            }
        }


        private string[] YearMonthArray()
        {
            char[] sep = new char[1] { '.' };
            var value = YearMonth;
            string[] yearmonth = value.Split(sep);
            return yearmonth;
        }
        private static void OnDaysChanged(DependencyObject d, DependencyPropertyChangedEventArgs eventArgs)
        {
             DateMonth m = d as DateMonth;
             var currentCollection = eventArgs.NewValue as IEnumerable<int>;
             m?.Reload(currentCollection);
        }

        private void OnReset()
        {
            Reload(new List<int>());
        }
        private void Reload(IEnumerable<int> days)
        {
            var day = 1;
            var daysOff = days;
            var yearMonth = YearMonthArray();
            if ((yearMonth.Length == 2) && (!string.IsNullOrEmpty(yearMonth[0])) && (!string.IsNullOrEmpty(yearMonth[1])))
            {
                var year = Convert.ToInt16(yearMonth[0]);
                var month = Convert.ToInt16(yearMonth[1]);
                var firstDayMonth = new DateTime(year, month, day);
                MonthName = firstDayMonth.ToString("Y");
                int currentIterator = (int)firstDayMonth.DayOfWeek;
                var numdays = computeNumberDays(year, month - 1);
                var j = 1;
                for (int k = currentIterator; k < 38; ++k)
                {
                    if (j++ > numdays)
                        break;
                    CorrectSelection(k, daysOff);

                }
                // just only if are different.
                if (!daysOff.SequenceEqual(DaysOff))
                {
                    var tmp = daysOff.Intersect(DaysOff);
                    DaysOff = tmp;
                }
            }
        }
        private void HandleChangedMonthYear()
        {

            int day = 1;
            string[] yearMonth = YearMonthArray();
            if ((yearMonth.Length == 2) && (!string.IsNullOrEmpty(yearMonth[0])) && (!string.IsNullOrEmpty(yearMonth[1])))
            {

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
                int mIndex = MonthIndex;
                // i shall check if i can stay on the ranges.

                var value = YearMonthArray();
                var year = Convert.ToInt16(value[0]);
                var month = Convert.ToInt16(value[1]);
                day = filterLimit(day, mIndex, year);
                var param = CreateCommand(day, false);
                List<int> daysOff = DaysOff.ToList();
                // avoid correction if it i have just clicked.


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
                    daysOff.Add(day);
                    SelectedDay.SetIsDaySelected(currentButton, true);
                }
                DaysOff = daysOff;
                // this make in a way that the reset command is internally called.

                if ((_resetCommand != null) && (!_resetCommand.Equals(ResetCommand)))
                {
                    ResetCommand = _resetCommand;
                }
                if (SelectedDayCommand != null)
                {
                    SelectedDayCommand.Execute(param);
                }
            }
        }




        private int filterLimit(int day, int month, int year)
        {
            int[] numDays = new int[12]
             {
                31,28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31
             };

            var maxDay = numDays[month - 1];
            if ((isLeapYear(year)) && (month == 2))
            {
                maxDay = 29;
            }

            var firstDay = new DateTime(year, month, 1);
            var dayWeek = firstDay.DayOfWeek;
            switch (dayWeek)
            {
                case DayOfWeek.Sunday:
                    {
                        day = day + 1;
                        break;
                    }
                case DayOfWeek.Tuesday:
                    {
                        day = day - 1;
                        break;
                    }
                case DayOfWeek.Wednesday:
                    {
                        day = day - 2;
                        break;
                    }
                case DayOfWeek.Thursday:
                    {
                        day = day - 3;
                        break;
                    }
                case DayOfWeek.Friday:
                    {
                        day = day - 4;
                        break;
                    }
                case DayOfWeek.Saturday:
                    {
                        day = day - 5;
                        break;
                    }
            }
            if (day > maxDay)
            {
                return maxDay;
            }

            return day;
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
        private void CorrectSelection(int k, IEnumerable<int> newSelected)
        {


            var partToChange = string.Format("PART_Day_{0}", k);
            TextBlock text = GetTemplateChild(partToChange) as TextBlock;
            var value = YearMonthArray();
            var year = Convert.ToInt16(value[0]);
            var month = Convert.ToInt16(value[1]);
            int day = SelectedDay.GetDayIndex(text);

            // this keys keep in account the offset used while drawing.
            var effectiveKey = filterLimit(day, MonthIndex, year);
            if (text != null)
            {
                if (SelectedDay.GetIsDaySelected(text))
                {
                    // looking for a selected value that it shall be not selected anymore.
                    if (!newSelected.Contains(effectiveKey))
                    {
                        SelectedDay.SetIsDaySelected(text, false);
                        text.Background = Brushes.White;
                    }
                }


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
        /// <summary>
        ///  Set or Get the DayWeek.
        /// </summary>
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
        /// <summary>
        ///  Set or Get the MonthGrid.
        /// </summary>
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
