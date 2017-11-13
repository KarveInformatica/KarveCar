namespace KarveDataServices.DataTransferObject
{
    public class ContactsDto
    {
	    public string CommissionId { set; get;}
	    public string ContactName { set; get;}
    	public string Nif {set; get;}
        public string Responsability { get; set; }
        public string Telefono { get; set; }
        public string Movil { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string User { get; set; }
        public string LastMod { get; set; }
        public string CurrentDelegation { get; set; }
        public int ContactId { get; set; }
    }
}