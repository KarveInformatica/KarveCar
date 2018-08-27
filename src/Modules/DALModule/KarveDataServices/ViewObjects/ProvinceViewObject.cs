using System.ComponentModel.DataAnnotations;
using KarveDataServices.DataObjects;

namespace KarveDataServices.ViewObjects
{
    public class ProvinceViewObject : BaseViewObjectDefaultName, IProvinceData
    {
        /// <summary>
        /// Code
        /// </summary>
        [Display(GroupName = "Codigo")]
        public override string Code { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [Display(GroupName = "Provincia")]
        public override string Name { get; set; }
        /// <summary>
        ///  Code of the country. It is a redondant field
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        ///  Capital of the province
        /// </summary>
        public string Capital { get; set; }
        // Prefix of the province.
        public string Prefix { get; set; }
        // value of the province.
        public CountryViewObject CountryValue { set; get; }
        public bool Valid { get; set; }

        public bool IsInvalid()
        {
            if ((Code != null) && (Code.Length > 8))
            {
                ErrorList.Add(ConstantDataError.NameTooLong);
                return true;
            }
            if ((Name != null) && (Name.Length >35))
            {
                ErrorList.Add(ConstantDataError.NameTooLong);
                return true;
            }
            if ((Capital != null) && (Capital.Length > 35))
            {
                ErrorList.Add(ConstantDataError.NameTooLong);
                return true;
            }
            return false;
        }
        public override bool HasErrors { get => IsInvalid(); set => base.HasErrors = value; }
    }
}