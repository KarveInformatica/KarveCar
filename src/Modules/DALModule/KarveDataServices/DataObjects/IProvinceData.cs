namespace KarveDataServices.DataObjects
{
    public interface IProvinceData
    {
        /// <summary>
        ///  code of the type
        /// </summary>
        string Code { get; set; }
        // name of the province
        string Name { get; set; }
        // country code of the province.
        string Country { get; set; }
    }
}