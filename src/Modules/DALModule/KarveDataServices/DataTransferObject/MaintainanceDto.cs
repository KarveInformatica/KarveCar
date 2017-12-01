using System;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  Mantenaince dto
    /// </summary>
    public class MaintainanceDto
    {

        public MaintainanceDto()
        {
            
        }
        public MaintainanceDto(MaintainanceDto lastChangedObject)
        {
            if (lastChangedObject != null)
            {
                MaintananceName = lastChangedObject.MaintananceName;
                MaintananceCode = lastChangedObject.MaintananceCode;
                LastMaintananceDate = lastChangedObject.LastMaintananceDate;
                LastMaintananceKMs = lastChangedObject.LastMaintananceKMs;
                NextMaintananceKMs = lastChangedObject.NextMaintananceKMs;
                NextMaintananceDate = lastChangedObject.NextMaintananceDate;
                Observation = lastChangedObject.Observation;
            }
        }

        /// <summary>
        ///  Code of mantianance
        /// </summary>
        public string MaintananceCode { set; get; }
        /// <summary>
        ///  Name of mantianance
        /// </summary>
        public string MaintananceName { set; get; }
        /// <summary>
        ///  Fecha mantainance.
        /// </summary>
        public DateTime LastMaintananceDate { set; get; }
        /// <summary>
        /// Last mantainance kms.
        /// </summary>
        public string LastMaintananceKMs { set; get; }
        /// <summary>
        ///  Next mainatnace date.
        /// </summary>
        public DateTime  NextMaintananceDate { set; get; }
        /// <summary>
        ///  Next manintanance kms.
        /// </summary>
        public string NextMaintananceKMs { set; get; }
        /// <summary>
        /// Observation
        /// </summary>
        public string Observation { set; get; }

    }
}