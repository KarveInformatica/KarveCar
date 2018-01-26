namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  This is a dto that maps the code and activity.
    /// </summary>
    public class VehicleActivitiesDto: BaseDto
    {
        /// <summary>
        ///  Activity code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        ///  Activity
        /// </summary>
        public string Activity { get; set; }
        /// <summary>
        ///  Compute a value
        /// </summary>
        public bool Compute { set; get; }
        /// <summary>
        ///  is an activity alquiler
        /// </summary>
        public byte? ActityAlquiler { get; set; }
        /// <summary>
        ///  Assurance value.
        /// </summary>
        public decimal? Assurance { get; set; }
        public string ActivitySigle { get; set; }
    }
}