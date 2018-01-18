using System;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    /// VehicleTypeDto.
    /// </summary>
    public class VehicleTypeDto
    {
        public string Code { set; get; }
        public DateTime TerminationDate { set; get; }
        public string Name { set; get; }
        public int? OfferMargin { set; get; }
        public string WebName { set; get; }
        public string LastModification { get; set; }
    }
}