using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System.ComponentModel;
using Prism.Commands;
using System.Collections.ObjectModel;
using Prism.Mvvm;

namespace KarveControls
{
    /// <summary>
    ///  MonthData is an entity to be used for displaying each month.
    /// </summary>
    public class MonthData: BindableBase
    {
        
        /// <summary>
        ///  Set or Get the year month data. i.e 2018.01 
        /// </summary>
        public string YearMonth
        { set
            {
                _yearMonth = value;
                RaisePropertyChanged();
            }
            get
            {
                return _yearMonth;
            }
        }
        /// <summary>
        ///  Set or Get the SelectedDayCommand. 
        ///  The SelectedDayCommand is a command that it gets executed when the user clicks on a day. 
        /// </summary>
        public ICommand SelectedDayCommand {
            set
            {
                _selectedDay = value;
                RaisePropertyChanged();
            }
            get
            {
                return _selectedDay;
            }
        }
        /// <summary>
        /// Set or Get the MonthIndex. The index ranges from 1 to 12.
        /// </summary>
        public int MonthIndex { set {
                _monthIdx = value;
                RaisePropertyChanged();
            } get {
               return _monthIdx;
            }
        }
        /// <summary>
        ///  Set or Get the reset command. The reset command should be used for cleaning up after a change of DaysOff property. 
        ///  </summary>
        public ICommand Reset
        {
            set
            {
                _reset = value;
                RaisePropertyChanged();
            }
            get
            {
                return _reset;
            }
        }
        /// <summary>
        ///  Set or Get the list of the days off in this current month.
        /// </summary>
        public IEnumerable<int> DaysOff {
            set
            {
                _daysOff = value;
                RaisePropertyChanged();
            }
            get
            {
                return _daysOff;
            }
        }

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
        private IEnumerable<int> _daysOff;
        private string _yearMonth;
        private ICommand _selectedDay;
        private int _monthIdx;
        private ICommand _reset;
        private int _rowIdx;
        private int _colIdx;
    }
    /// <summary>
    ///  Control that displays and notify changes of a year calendar.
    /// </summary>
    public class HolidayCalendar : Control, INotifyPropertyChanged
    {
        /// <summary>
        ///  Describes the type of change that it might happen to the holiday collection.
        /// </summary>
        public enum Status {
            /// <summary>
            /// Retrieve the current holidays.
            /// </summary>
            CurrentHolidays,
            /// <summary>
            /// Retrieve the changed value.
            /// </summary>
            ChangedValue,
            /// <summary>
            /// Retrieve the previous value.
            /// </summary>
            PreviousValue,
            /// <summary>
            /// Retrieve the state of the action in the change dictionary.
            /// </summary>
            ActionState,
            /// <summary>
            /// The current action is a delete.
            /// </summary>
            ActionDelete,
            /// <summary>
            /// The current action is an add.
            /// </summary>
            ActionAdd
        };

        private readonly ICommand _resetCommand;
        /// <summary>
        ///  Dependency properties command.You can set the command and then execute when a selection change. 
        ///  It will give you back the list of valid vacations.
        /// </summary>
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(HolidayCalendar), new FrameworkPropertyMetadata(null));

        /// <summary>
        ///  Default noop operation used just for initalizatoin
        /// </summary>
        private void OnNoop() {}

        /// <summary>
        ///  Set or Get the command property. The command will be executed at each change.
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
        ///  Dependency property for the year.
        /// </summary>
        public static readonly DependencyProperty YearDependencyProperty = DependencyProperty.Register("Year", typeof(string), typeof(HolidayCalendar), new PropertyMetadata(string.Empty, OnYearChanged));
        
        /// <summary>
        /// Generate the visual calendar and initialize the change command  to detect when a click on the month
        ///  has been done.
        /// </summary>
        /// <param name="d">Dependency Object</param>
        /// <param name="e">Dependency Properties</param>

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
            //
            //
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
        /// <summary>
        ///  Dependnecy property fro the last holiday.
        /// </summary>
        public static readonly DependencyProperty LastHolidaysDependencyProperty = DependencyProperty.Register("LastHolidays", typeof(IEnumerable<DateTime>), typeof(HolidayCalendar), new PropertyMetadata(new ObservableCollection<DateTime>()));
     

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
        private Dictionary<int, List<DateTime>> CovertToBucketList(IEnumerable<DateTime> inList)
        {
            var hashData = new Dictionary<int, List<DateTime>>();
            foreach (var data in inList)
            {
                if (hashData.ContainsKey(data.Month))
                {
                    var tmp = new List<DateTime>();
                    hashData.TryGetValue(data.Month, out tmp);
                    tmp.Add(data);
                    hashData[data.Month] = tmp;
                }
                else
                {
                    var tmp = new List<DateTime>();
                    tmp.Add(data);
                    hashData.Add(data.Month, tmp);
                }
            }
            return hashData;

        }
        private IEnumerable<int> ExtractDays(List<DateTime> dataList)
        {
            var days = new ObservableCollection<int>();

            foreach(var data in dataList)
            {
                days.Add(data.Day);
            }
            return days;
        }
        private void ChangeData(object newValue)
        {
            var value = newValue as IEnumerable<DateTime>;

            var hashData = CovertToBucketList(value);

            if (value != null)
            {

                foreach (var index in _months.Keys)
                {
                    if (hashData.ContainsKey(index))
                    {
                        var tmp = ExtractDays(hashData[index]);
                        // ordering using linq.
                        _months[index].DaysOff = tmp.OrderBy(x=>x).ToList();
                    }
                    else
                    {
                        DoPerformReset(index);
                    }
                }
                Months = _months.Values;
            }
        }
        private void DoPerformReset(int index)
        {
            if ((_months[index].DaysOff != null) && (_months[index].DaysOff.Count() > 0))
            {
                if (_months[index].Reset != null)
                {
                    _months[index].Reset.Execute(null);
                }
            }
        }
        private IDictionary<int, MonthData> _months = new Dictionary<int, MonthData>()
        {
            {1, new MonthData(){ RowIdx=0, ColIdx = 0, MonthIndex = 1, YearMonth="2018.01", DaysOff=new ObservableCollection<int>() }},
           {2, new MonthData(){ ColIdx = 1, RowIdx = 0, MonthIndex = 2, YearMonth="2018.02", DaysOff=new ObservableCollection<int>() }},
          {3, new MonthData(){ ColIdx = 2, RowIdx = 0, MonthIndex = 3, YearMonth="2018.03", DaysOff=new ObservableCollection<int>(),  }},
             {4, new MonthData(){ ColIdx = 3, RowIdx = 0,MonthIndex = 4, YearMonth="2018.04", DaysOff=new ObservableCollection<int>()  }},
 {5, new MonthData(){ColIdx = 0, RowIdx = 1, MonthIndex = 5, YearMonth="2018.05", DaysOff=new ObservableCollection<int>(), }},
 {6, new MonthData(){ColIdx =1, RowIdx = 1, MonthIndex = 6, YearMonth="2018.06", DaysOff=new ObservableCollection<int>() }},
 {7, new MonthData(){ColIdx = 2, RowIdx = 1, MonthIndex = 7, YearMonth="2018.07", DaysOff=new ObservableCollection<int>() }},
 {8, new MonthData(){ColIdx = 3, RowIdx = 1, MonthIndex = 8, YearMonth="2018.08", DaysOff=new ObservableCollection<int>()}},
 {9, new MonthData(){ ColIdx = 0, RowIdx = 2, MonthIndex = 9, YearMonth="2018.09", DaysOff=new ObservableCollection<int>() }},
 {10, new MonthData(){ ColIdx = 1, RowIdx = 2, MonthIndex = 10, YearMonth="2018.10", DaysOff=new ObservableCollection<int>() }},
 {11, new MonthData(){ ColIdx = 2, RowIdx = 2,MonthIndex =11, YearMonth="2018.11", DaysOff=new ObservableCollection<int>() }},
 {12, new MonthData(){ ColIdx = 3, RowIdx = 2,MonthIndex = 12, YearMonth="2018.12", DaysOff=new ObservableCollection<int>() }}

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
                    holiday.Add(value.Item1);
                    Holidays = holiday;
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
                            var item = itemFound.FirstOrDefault();
                            if (item != null)
                            {
                                Holidays.Remove(item);
                                // delete.
                                dictionary[Status.ActionState] = Status.ActionDelete;
                            }
                        }
                    }
                    else
                    {
                        ObservableCollection<DateTime> newHolidays = new ObservableCollection<DateTime>();
                        newHolidays.Add(value.Item1);
                        // new
                        dictionary[Status.ActionState] = Status.ActionAdd;
                        Holidays = new ObservableCollection<DateTime>(newHolidays.Union(Holidays));
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
        ///  Get or Set the year selected.
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

        /// <summary>
        ///  Get or Set the Months selected.
        /// </summary>
        public IEnumerable<MonthData> Months
        {
            set { _monthData = value; RaisePropertyChanged("Months"); }
            get { return _monthData; }
        }
            
           
        /// <summary>
        ///  Set or Get the current holidays.
        /// </summary>
        public ObservableCollection<DateTime> Holidays
        {
            get
            {
                return (ObservableCollection<DateTime>)GetValue(HolidayDependencyProperty);
            }
            set
            {
                SetValue(HolidayDependencyProperty, value);
            }
        }
        /// <summary>
        /// Set or Get the former value of the holidays in order to revert changes. 
        /// At the beginning the last holidays is equal to holidays.  
        /// </summary>
        public ObservableCollection<DateTime> LastHolidays
        {
            get
            {
                return (ObservableCollection<DateTime>)GetValue(LastHolidaysDependencyProperty);
            }
            set
            {
                SetValue(LastHolidaysDependencyProperty, value);
            }
        }
        /// <summary>
        ///  Constructor 
        /// </summary>
        public HolidayCalendar()
        {
            /*
             * This might be weird at first but in this case we have a way to initialize the databinding.
             * Internally the DataMonth control will modify the binding to point out to the correct function.
             * The data binding is a two way binding, so all it will get reflected to upper level. 
             */
            _resetCommand = new DelegateCommand(OnNoop);
            for (int i = 1; i <= 12; ++i)
            {
                _months[i].Reset = _resetCommand;
            }
            Months = _months.Values;
        }
        /// <summary>
        ///  Control constructor.
        /// </summary>
        static HolidayCalendar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HolidayCalendar),
                                                           new FrameworkPropertyMetadata(typeof(HolidayCalendar)));
        }
        private IEnumerable<MonthData> months = new List<MonthData>();
        private IEnumerable<MonthData> _monthData;
    }
}
