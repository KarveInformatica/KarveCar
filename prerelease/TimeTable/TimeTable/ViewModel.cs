using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace TimeTable
{

    public class Day
    {
        public string DayName { set; get; }
        public TimeSpan OpenTime { set; get; }
        public TimeSpan CloseTime { set; get; }
    };
    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Day> _collection = new ObservableCollection<Day>()
        {
            new Day{ DayName="Lunes", OpenTime = new TimeSpan(8,0,0), CloseTime= new TimeSpan(12,0,0) },
            new Day{ DayName="Martes", OpenTime = new TimeSpan(8,0,0), CloseTime= new TimeSpan(12,0,0) },
            new Day{ DayName="Miercoles", OpenTime = new TimeSpan(8,0,0), CloseTime= new TimeSpan(12,0,0) },
            new Day{ DayName="Jueves", OpenTime = new TimeSpan(8,0,0), CloseTime= new TimeSpan(12,0,0) },
            new Day{ DayName="Viernes", OpenTime = new TimeSpan(8,0,0), CloseTime= new TimeSpan(12,0,0) },
            new Day{ DayName="Sabado", OpenTime = new TimeSpan(8,0,0), CloseTime= new TimeSpan(12,0,0) },
            new Day{ DayName="Domingo", OpenTime = new TimeSpan(8,0,0), CloseTime= new TimeSpan(12,0,0) }
        };

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void OnChangeProperty(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<Day> Days
        {
            set
            {
                _collection = value;
                OnChangeProperty("Days");
            }
            get
            {
             return _collection;
            }
        }
        public ViewModel()
        {
            Days = _collection;
        }

    }
}
