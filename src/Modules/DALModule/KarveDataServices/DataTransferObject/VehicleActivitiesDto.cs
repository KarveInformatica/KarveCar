namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  This is a dto that maps the code and activity.
    /// </summary>
    public class VehicleActivitiesDto: BaseDto
    {
        public string Code { get; set; }
        public string Activity { get; set; }
        public bool Compute { set; get; }
    }
}