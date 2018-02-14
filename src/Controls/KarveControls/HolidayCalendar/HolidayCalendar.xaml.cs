using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Nager.Date;
using System.Globalization;
using System.Threading;
using System.ComponentModel;
using Prism.Commands;

namespace KarveControls.HolidayCalendar
{
    /// <summary>
    /// Interaction logic for HolidayCalendar.xaml
    /// </summary>
    public partial class HolidayCalendar : UserControl, INotifyPropertyChanged
       {
        /// <summary>
        /// 
        /// </summary>
        public static DependencyProperty DataChangedCommandDependencyProperty
       = DependencyProperty.Register(
           "DataChangedCommand",
           typeof(ICommand),
           typeof(HolidayCalendar));
        /// <summary>
        ///  Date changed command
        /// </summary>
        public ICommand DateChangedCommand {

            set
            {
                SetValue(DataChangedCommandDependencyProperty, value);
            }
            get
            {
                return (ICommand)GetValue(DataChangedCommandDependencyProperty);
            }
        }
        /// <summary>
        ///  This expose country code dependency property.
        /// </summary>
        public static DependencyProperty CountryCodeDependencyProperty
            = DependencyProperty.Register(
                "CountryCode",
                typeof(string),
                typeof(HolidayCalendar));
        /// <summary>
        ///  CountryCode
        /// </summary>
        public string CountryCode
        {
            set
            {
                SetValue(CountryCodeDependencyProperty, value);
            }
            get
            {
                return (string)GetValue(CountryCodeDependencyProperty);
            }
        }
        /// <summary>
        ///  Set the culture info dependency property.
        /// </summary>
        public static DependencyProperty CultureInfoDependencyProperty
            = DependencyProperty.Register(
                "CultureInfo",
                typeof(CultureInfo),
                typeof(HolidayCalendar), new PropertyMetadata(new CultureInfo("es-ES")));
        /// <summary>
        ///  CultureInfo
        /// </summary>
        public CultureInfo CultureInfo
        {
            set
            {
                SetValue(CultureInfoDependencyProperty, value);
            }
            get
            {
                return (CultureInfo)GetValue(CultureInfoDependencyProperty);
            }
        }
        /// <summary>
        ///  Public source that populate the collection of calendars.
        /// </summary>
        public IEnumerable<HolidayPerMonth> ItemSource
        {
            get
            {
                return _itemSource;
            }
            set {
                _itemSource = value;
                OnPropertyChanged("ItemSource");
            }
        }

        /// <summary>
        /// Change date
        /// </summary>
        /// <param name="value">Value object to be changed.</param>
        private void OnChangedDate(object value)
        {
        } 

        /// <summary>
        /// This is the holiday per month descriptor.
        /// </summary>
        public class HolidayPerMonth
        {
            public int Month { set; get; }
            public string MonthName { set; get; }
            public List<DateTime> Holidays { set; get; }
            public ICommand Command { set; get; }

        }
        /// <summary>
        ///  Property Changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = delegate {};
       
        /// <summary>
        ///  Constructor of the calendar.
        /// </summary>
        public HolidayCalendar()
        {
            InitializeComponent();
            this.DataContext = this.HolidayCalendarLayout;
            CountryCode = "ES";
            ItemSource = PopulateCalendar();
        }
        /// <summary>
        ///  This populate a calendar  list for each month.
        /// </summary>
        /// <returns>A list of calendar</returns>
        private IEnumerable<HolidayPerMonth> PopulateCalendar()
        {
            var holidayCollection = new List<HolidayPerMonth>();
            var code = CountryCode;
            Thread.CurrentThread.CurrentCulture = CultureInfo;
            string[] monthNames = System.Globalization.CultureInfo.CurrentCulture
        .DateTimeFormat.MonthGenitiveNames;
            if (string.IsNullOrEmpty(code))
            {
                code = "ES";
            }
            var now = DateTime.Now.Year;
            var publicHolidays = DateSystem.GetPublicHoliday(code, now);
            var orderedValues = publicHolidays.OrderBy(x => x.Date.Month);
            var perMonth = new Dictionary<int, List<DateTime>>();
            foreach (var value in orderedValues)
            {
                if (perMonth.ContainsKey(value.Date.Month))
                {
                    var listValue = new List<DateTime>();
                    perMonth.TryGetValue(value.Date.Month, out listValue);
                    listValue.Add(value.Date);
                    perMonth.Remove(value.Date.Month);
                    perMonth.Add(value.Date.Month, listValue);
                }
                else
                {
                    var listValue = new List<DateTime>();
                    listValue.Add(value.Date);
                    perMonth.Add(value.Date.Month, listValue);
                }
            }
            foreach (var key in perMonth.Keys)
            {
                HolidayPerMonth holidayPerMonth = new HolidayPerMonth();
                holidayPerMonth.Month = key;
                holidayPerMonth.Command = new DelegateCommand<object>(OnChangedDate);
                holidayPerMonth.MonthName = monthNames[key-1];
                var holidays = new List<DateTime>();
                perMonth.TryGetValue(key, out holidays);
                holidayPerMonth.Holidays = holidays;
                holidayCollection.Add(holidayPerMonth);
            }
            return holidayCollection;
        }
        /// <summary>
        ///  List of the source holidays.
        /// </summary>
        private IEnumerable<HolidayPerMonth> _itemSource = new List<HolidayPerMonth>();
        /// <summary>
        ///  This raise notification 
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
