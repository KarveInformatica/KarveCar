using System;

namespace KarveCar.Model
{
    public class Flight
    {
        public string Number { set; get; }
        public string DeparturePlace { set; get; }
        public string ArrivalPlace { set; get; }
        public TimeSpan DepartureTime { set; get; }
        public TimeSpan ArrivalTime { set; get; }
        public DateTime DepartureDate { set; get; }
        public DateTime ArrivalDate { set; get; }
    }
}