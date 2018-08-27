namespace KarveCar.Model
{
    public class Address
    {
        public string City { set; get; }
        public string Zip { set; get; }
        public Province  Province { set; get; }
        public Country Country { set; get; }
    }
}