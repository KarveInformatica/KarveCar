namespace KarveDataServices.DataObjects
{
    public interface IBranchesData
    {
        int Code { get; set; }
        string Name { get; set; }
        string Address { get; set; }
        string Address2 { get; set; }
        string CodeProvince { get; set; }
        string City { get; set; }
        string Email { get; set; }
        string CodeAgent { get; set; }
        string LastModified { get; set; }
        string User { get; set; }
        object ObjectValue { get; set; }
    }
}