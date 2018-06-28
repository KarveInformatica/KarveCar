using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System.ComponentModel;
using Prism.Commands;
using KarveControls.Calendar;
using System.Collections.ObjectModel;

namespace KarveControls
{
    public class MonthData
    {

        private int _rowIdx;
        private int _colIdx;
        // this shall be internal
        internal int RowIdx
        {
            get
            {
                return _rowIdx;
            }
            set
            {
                _rowIdx = value;
            }
        }
        internal int ColIdx
        {
            get
            {
                return _colIdx;
            }
            set
            {
                _colIdx = value;
            }
        }
        public string YearMonth { set; get; }
        public ICommand SelectedDayCommand { set; get; }
        public int MonthIndex { set; get; }
        public IEnumerable<int> DaysOff { set; get; }
    }
    public class HolidayCalendar : Control, INotifyPropertyChanged
    {

        public enum Status { CurrentHolidays, ChangedValue, PreviousValue, ActionState, ActionDelete, ActionAdd };

        /// <summary>
        ///  Dependency properties command.You can set the command and then execute when a selection change. 
        ///  It will give you back the list of valid vacations;
        /// </summary>
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(HolidayCalendar), new FrameworkPropertyMetadata(null));

        /// <summary>
        ///  Command property.
        /// </summary>
        public ICommand Command
        {
            get
            {
                return (ICommand) GetValue(CommandProperty);
            }
            set
            {
                SetValue(CommandProperty, value);
            }
        }
        /// <summary>
        ///  Dependency properties for the Year. 
        ///  You can set the year and from them you can generate thecalendar.
        /// </summary>
        public static readonly DependencyProperty YearDependencyProperty = DependencyProperty.Register("Year", typeof(string), typeof(HolidayCalendar), new PropertyMetadata(string.Empty, OnYearChanged));
        
        
        /// <summary>
        /// Generate the visual calendar and initialize the change command  to detect when a click on the month
        ///  has been done.
        /// </summary>
        /// <param name="d">Dependency Object</param>
        /// <param name="e">Dependnecy Properties</param>

        private static void OnYearChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var currentYear = d.GetValue(YearDependencyProperty) as string;
            var calendar = d as HolidayCalendar;
            for (int i = 0; i < 12; ++i)
            {
                var currentMonth = string.Empty;
                if (i < 9)
                {
                    currentMonth = currentYear + "." + "0" + (i + 1).ToString();
                }
                else
                {
                    currentMonth = currentYear + "." + (i + 1).ToString();
                }
                if (calendar != null)
                {
                    calendar.ChangeYearMonth(i + 1, currentMonth);
                }

            }

            if (calendar == null)
            { return;}
            calendar.RaisePropertyChanged("Months");
        }

        private void ChangeYearMonth(int i, string currentMonth)
        {
            _months[i].YearMonth = currentMonth;
            _months[i].MonthIndex = i;
            _months[i].SelectedDayCommand = new DelegateCommand<Tuple<DateTime, bool>>(OnHolidayChange);
        }

        /// <summary>
        ///  Dependency propriety for the Holidays. It sets the holidays during the year.
        /// </summary>
        public static readonly DependencyProperty HolidayDependencyProperty = DependencyProperty.Register("Holidays", typeof(IEnumerable<DateTime>), typeof(HolidayCalendar), new PropertyMetadata(new ObservableCollection<DateTime>(), OnHolidaysChanged));

        private static void OnHolidaysChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HolidayCalendar calendar = d as HolidayCalendar;
            calendar.ChangeData(e.NewValue);
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void ClearHoliday()
        {
            for (int i = 0; i < 12; i++)
            {
                if (_months.ContainsKey(i))
                {
                    _months[i].DaysOff = new List<int>();
                }
            }
        }
        private void ChangeData(object newValue)
        {
            var value = newValue as IEnumerable<DateTime>;
            if (value != null)
            {
                ClearHoliday();
                foreach (var data in value)
                {
                  
                    var dayList = _months[data.Month].DaysOff;
                    if ((dayList != null) && (!dayList.Contains<int>(data.Day)))
                    {
                        var list = _months[data.Month].DaysOff.ToList<int>();
                        list.Add(data.Day);
                        _months[data.Month].DaysOff = list;
                    }
                }
                RaisePropertyChanged("Months");
            }
        }

        private IDictionary<int, MonthData> _months = new Dictionary<int, MonthData>()
        {
            {1, new MonthData(){ RowIdx=0, ColIdx = 0, MonthIndex = 1, YearMonth="2018.01", DaysOff=new List<int>() }},
           {2, new MonthData(){ ColIdx = 1, RowIdx = 0, MonthIndex = 2, YearMonth="2018.02", DaysOff=new List<int>() }},
          {3, new MonthData(){ ColIdx = 2, RowIdx = 0, MonthIndex = 3, YearMonth="2018.03", DaysOff=new List<int>(),  }},
             {4, new MonthData(){ ColIdx = 3, RowIdx = 0,MonthIndex = 4, YearMonth="2018.04", DaysOff=new List<int>()  }},
 {5, new MonthData(){ColIdx = 0, RowIdx = 1, MonthIndex = 5, YearMonth="2018.05", DaysOff=new List<int>(), }},
 {6, new MonthData(){ColIdx =1, RowIdx = 1, MonthIndex = 6, YearMonth="2018.06", DaysOff=new List<int>() }},
 {7, new MonthData(){ColIdx = 2, RowIdx = 1, MonthIndex = 7, YearMonth="2018.07", DaysOff=new List<int>() }},
 {8, new MonthData(){ColIdx = 3, RowIdx = 1, MonthIndex = 8, YearMonth="2018.08", DaysOff=new List<int>()}},
 {9, new MonthData(){ ColIdx = 0, RowIdx = 2, MonthIndex = 9, YearMonth="2018.09", DaysOff=new List<int>() }},
 {10, new MonthData(){ ColIdx = 1, RowIdx = 2, MonthIndex = 10, YearMonth="2018.10", DaysOff=new List<int>() }},
 {11, new MonthData(){ ColIdx = 2, RowIdx = 2,MonthIndex =11, YearMonth="2018.11", DaysOff=new List<int>() }},
 {12, new MonthData(){ ColIdx = 3, RowIdx = 2,MonthIndex = 12, YearMonth="2018.12", DaysOff=new List<int>() }}

        };

        private void OnHolidayChange(Tuple<DateTime, bool> value)
        {
            IDictionary<Status, object> dictionary = new Dictionary<Status, object>();

            var holiday = Holidays;
            if (holiday != null)
            {
                dictionary[Status.PreviousValue] = holiday;
                //case base
                if ((holiday.Count() == 0) && (value != null) && (value.Item2 == true))
                {
                    Holidays = holiday.Union(new List<DateTime>() { value.Item1 });
                    // new.
                    dictionary[Status.ActionState] = Status.ActionAdd;
                }
                else
                {

                    var itemFound = holiday.Where<DateTime>(x => x.DayOfYear == value.Item1.DayOfYear);
                    if (itemFound.Any())
                    {
                        if (!value.Item2)
                        {
                            Holidays = Holidays.Except(itemFound);
                            // delete.
                            dictionary[Status.ActionState] = Status.ActionDelete;
                        }
                    }
                    else
                    {
                        List<DateTime> newHolidays = new List<DateTime>();
                        newHolidays.Add(value.Item1);
                        // new
                        dictionary[Status.ActionState] = Status.ActionAdd;
                        Holidays = Holidays.Union<DateTime>(newHolidays);
                    }
                }
                if (Command != null)
                {
                    dictionary[Status.ChangedValue] = value;
                    dictionary[Status.CurrentHolidays] = Holidays;
                    Command.Execute(dictionary);
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///  Year selected
        /// </summary>
        public string Year
        {
            get
            {
                return (string)GetValue(YearDependencyProperty);
            }
            set
            {
                SetValue(YearDependencyProperty, value);
            }
        }

        public IEnumerable<MonthData> Months => _months.Values;
        /// <summary>
        ///  Holiday during the year.
        /// </summary>
        public IEnumerable<DateTime> Holidays
        {
            get
            {
                return (IEnumerable<DateTime>)GetValue(HolidayDependencyProperty);
            }
            set
            {
                SetValue(HolidayDependencyProperty, value);
            }
        }
        public HolidayCalendar()
        {
            RaisePropertyChanged("Months");
        }
        static HolidayCalendar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HolidayCalendar),
                                                           new FrameworkPropertyMetadata(typeof(HolidayCalendar)));
        }
        private IEnumerable<MonthData> months = new List<MonthData>();

    }
}
