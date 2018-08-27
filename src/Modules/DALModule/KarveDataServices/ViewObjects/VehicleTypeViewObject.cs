using System;

namespace KarveDataServices.ViewObjects
{
    /// <summary>
    /// VehicleTypeViewObject.
    /// </summary>
    public class VehicleTypeViewObject: BaseViewObjectDefaultName
    {
        public DateTime TerminationDate { set; get; }
        public int? OfferMargin { set; get; }
        public string WebName { set; get; }
        bool IsInvalid()
        {
            var errors = base.HasErrors;
            if (!errors)
            {
                if ((WebName != null) && (WebName.Length > 35))
                {
                    return true;
                }
            }
            return errors;
        }
        public override bool HasErrors { get => IsInvalid(); set => base.HasErrors = value; }
    }
}