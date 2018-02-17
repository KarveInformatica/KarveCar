using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace TimeTable
{

    public class Day
    {
        public string DayName { set; get; }
        public string OpenTime { set; get; }
        public string CloseTime { set; get; }
    };
    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Day> _collection = new ObservableCollection<Day>()
        {
            new Day{ DayName="Lunes", OpenTime = new TimeSpan(8,0,0).ToString(), CloseTime= new TimeSpan(12,0,0).ToString() },
            new Day{ DayName="Martes", OpenTime = new TimeSpan(8,0,0).ToString(), CloseTime= new TimeSpan(12,0,0).ToString() },
            new Day{ DayName="Miercoles", OpenTime = new TimeSpan(8,0,0).ToString(), CloseTime= new TimeSpan(12,0,0).ToString() },
            new Day{ DayName="Jueves", OpenTime = new TimeSpan(8,0,0).ToString(), CloseTime= new TimeSpan(12,0,0).ToString() },
            new Day{ DayName="Viernes", OpenTime = new TimeSpan(8,0,0).ToString(), CloseTime= new TimeSpan(12,0,0).ToString() },
            new Day{ DayName="Sabado", OpenTime = new TimeSpan(8,0,0).ToString(), CloseTime= new TimeSpan(12,0,0).ToString() },
            new Day{ DayName="Domingo", OpenTime = new TimeSpan(8,0,0).ToString(), CloseTime= new TimeSpan(12,0,0).ToString() }
        };
        ObservableCollection<Day> collection = new ObservableCollection<Day>();
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void OnChangeProperty(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<Day> DayTimes
        {
            set
            {
                collection = value;
                OnChangeProperty("DayTimes");
            }
            get
            {
             return collection;
            }
        }
        public ViewModel()
        {
           DayTimes = _collection;
        }

    }
}
