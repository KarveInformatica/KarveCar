using System;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    /// VehicleTypeDto.
    /// </summary>
    public class VehicleTypeDto: BaseDtoDefaultName
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