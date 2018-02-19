using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System.ComponentModel;
using Prism.Commands;

namespace KarveControls
{
    public class MonthData
    {
        private int _rowIdx;
        private int _colIdx;

        public int RowIdx
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
        public int ColIdx
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

        private IEnumerable<MonthData> months = new List<MonthData>();
        /* public static readonly DependencyProperty MonthsDependencyProperty =
 DependencyProperty.Register(
 "Months", typeof(IEnumerable<int>),
 typeof(HolidayCalendar), new FrameworkPropertyMetadata(new List<int>()));*/
        /// <summary>
        ///  Dependency properties for the month name
        /// </summary>
        public static readonly DependencyProperty YearDependencyProperty = DependencyProperty.Register("Year", typeof(string), typeof(HolidayCalendar), new PropertyMetadata(string.Empty, OnYearChanged));

        private static void OnYearChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var currentYear = d.GetValue(YearDependencyProperty) as string;
            var calendar = d as HolidayCalendar;
            for (int i = 0; i<12; ++i)
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
                if (calendar!=null)
                {
                    calendar.ChangeYearMonth(i+1, currentMonth);
                }
            }
            calendar.RaisePropertyChanged("Months");


        }

        private void ChangeYearMonth(int i, string currentMonth)
        {
            _months[i].YearMonth = currentMonth;
            _months[i].MonthIndex = i;
        }

        /// <summary>
        ///  Dependency properties for the holiday
        /// </summary>
        public static readonly DependencyProperty HolidayDependencyProperty = DependencyProperty.Register("Holidays", typeof(IEnumerable<DateTime>), typeof(HolidayCalendar), new PropertyMetadata(new List<DateTime>(), OnHolidaysChanged));

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
                _months[i].DaysOff = new List<int>();
            }
        }
        private void ChangeData(object newValue)
        {
            var value = newValue as List<DateTime>;
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
            {1, new MonthData(){ RowIdx=0, ColIdx = 0, MonthIndex = 1, YearMonth="2018.01", DaysOff=new List<int>(), SelectedDayCommand=new DelegateCommand<object>(OnJanuaryChange) }},
           {2, new MonthData(){ ColIdx = 1, RowIdx = 0, MonthIndex = 2, YearMonth="2018.02", DaysOff=new List<int>(), SelectedDayCommand=new DelegateCommand<object>(OnFebChange) }},
          {3, new MonthData(){ ColIdx = 2, RowIdx = 0, MonthIndex = 3, YearMonth="2018.03", DaysOff=new List<int>(), SelectedDayCommand=new DelegateCommand<object>(OnMarChange) }},
             {4, new MonthData(){ ColIdx = 3, RowIdx = 0,MonthIndex = 4, YearMonth="2018.04", DaysOff=new List<int>(), SelectedDayCommand=new DelegateCommand<object>(OnAprChange) }},
 {5, new MonthData(){ColIdx = 0, RowIdx = 1, MonthIndex = 5, YearMonth="2018.05", DaysOff=new List<int>(), SelectedDayCommand=new DelegateCommand<object>(OnMayChange) }},
 {6, new MonthData(){ColIdx =1, RowIdx = 1, MonthIndex = 6, YearMonth="2018.06", DaysOff=new List<int>(), SelectedDayCommand=new DelegateCommand<object>(OnJunChange) }},
 {7, new MonthData(){ColIdx = 2, RowIdx = 1, MonthIndex = 7, YearMonth="2018.07", DaysOff=new List<int>(), SelectedDayCommand=new DelegateCommand<object>(OnJulyChange) }},
 {8, new MonthData(){ColIdx = 3, RowIdx = 1, MonthIndex = 8, YearMonth="2018.08", DaysOff=new List<int>(), SelectedDayCommand=new DelegateCommand<object>(OnAugChange) }},
 {9, new MonthData(){ ColIdx = 0, RowIdx = 2, MonthIndex = 9, YearMonth="2018.09", DaysOff=new List<int>(), SelectedDayCommand=new DelegateCommand<object>(OnSeptChange) }},
 {10, new MonthData(){ ColIdx = 1, RowIdx = 2, MonthIndex = 10, YearMonth="2018.10", DaysOff=new List<int>(), SelectedDayCommand=new DelegateCommand<object>(OnOctChange) }},
 {11, new MonthData(){ ColIdx = 2, RowIdx = 2,MonthIndex =11, YearMonth="2018.11", DaysOff=new List<int>(), SelectedDayCommand=new DelegateCommand<object>(OnNovChange) }},
 {12, new MonthData(){ ColIdx = 3, RowIdx = 2,MonthIndex = 12, YearMonth="2018.12", DaysOff=new List<int>(), SelectedDayCommand=new DelegateCommand<object>(OnDicChange) }}

        };

        private static void OnDicChange(object obj)
        {
            
        }

        private static void OnNovChange(object obj)
        {
            
        }

        private static void OnOctChange(object obj)
        {
            
        }

        private static void OnSeptChange(object obj)
        {
            
        }

        private static void OnAugChange(object obj)
        {
            
        }

        private static void OnJulyChange(object obj)
        {
            throw new NotImplementedException();
        }

        private static void OnJunChange(object obj)
        {
            
        }

        private static void OnMayChange(object obj)
        {
            
        }

        private static void OnAprChange(object obj)
        {
            
        }

        private static void OnMarChange(object obj)
        {
            
        }

        private static void OnFebChange(object obj)
        {
            
        }

        private static void OnJanuaryChange(object obj)
        {

        }

       
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///  Month index selected.
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
        ///  Month index selected.
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
    }
}
