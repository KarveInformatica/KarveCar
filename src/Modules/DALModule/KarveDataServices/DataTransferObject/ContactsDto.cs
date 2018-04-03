namespace KarveDataServices.DataTransferObject
{
    public enum StateDto {  Clean = 0, Dirty = 1, Dead = 2}
    public class ContactsDto: BaseDto
    {
	    public string ContactsKeyId { set; get;}
	    public string ContactName { set; get;}
    	public string Nif {set; get;}
        public string Responsability { get; set; }
        public string Telefono { get; set; }
        public string Movil { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string LastMod { get; set; }
        public string CurrentDelegation { get; set; }
        [PrimaryKey]
        public string ContactId { get; set; }
        // 0 added, 1, modified, 2 deleted;
        public int State { get; set; }
    }
}