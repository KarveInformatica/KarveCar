namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  This is a dto that maps the code and activity.
    /// </summary>
    internal class VehicleActivitiesDto
    {
        public string Code { get; set; }
        public string Activity { get; set; }
        public string LastModification { get; set; }
        public string User { get; set; }
        public bool Compute { set; get; }
    }
}