using KarveDataServices.DataObjects;

namespace DataAccessLayer.DataObjects
{
    internal class ContactsData : IContactsData
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Nif { get; set; }
        public int? Branch { get; set; }
        public byte? Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string User { get; set; }
        public object ObjectValue { get; set; }
    }
}