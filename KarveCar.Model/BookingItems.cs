namespace KarveCar.Model
{
    public class BookingItems
    {
        public string Id { set; get; }
        public string ConceptId { set; get; }
        public string ConceptName { set; get; }
        public Unity Unity { set; get; }
        public bool Included { get; internal set; }
        public decimal? Subtotal { get; set; }
    }
}