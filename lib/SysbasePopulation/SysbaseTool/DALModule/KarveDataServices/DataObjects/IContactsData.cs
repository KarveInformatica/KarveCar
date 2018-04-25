namespace KarveDataServices.DataObjects
{
    public interface IContactsData
    {
        int Code { get; set; }
        string Name { get; set; }
        string Nif { get; set; }
        int? Branch { get; set; }
        byte? Position { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        string Fax { get; set; }
        string User { get; set; }
        object ObjectValue { get; set; }
    }
}