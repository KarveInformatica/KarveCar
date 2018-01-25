using System;

namespace KarveDataServices.DataTransferObject
{

    public class ClientZoneDto : BaseDto
    {
        /// <summary>
        ///  Code of the zone
        /// </summary>
        public string Code { set; get; }
        /// <summary>
        ///  Name of the zone.
        /// </summary>
        public string Name { set; get; }

    }

}