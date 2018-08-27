namespace KarveCar.Model
{
    public class Office
    {
        public Address OfficeAddress
        {
            set;
            get;
        }
        public Company Company { set; get; }
        public Zone Zone { set; get; }
    }
}