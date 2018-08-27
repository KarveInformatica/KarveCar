using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.ViewObjects
{
    /// <summary>
    ///  This is a dto that maps the code and activity.
    /// </summary>
    public class VehicleActivitiesViewObject : BaseViewObject
    {
        /// <summary>
        ///  Set or Get the activities.
        /// </summary>
        [Display(Name = "Codigo")]

        public override string Code {set; get;}
        
        /// <summary>
        ///  Set or Get the activities.
        /// </summary>
        [Display(Name ="Actividad")]
        public string Activity {
            get
            {
                return base.Name;
            }
            set
            {
                base.Name = value;

            }
        }
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
        bool IsInvalid()
        {
            if ((Activity != null) && (Activity.Length > 35))
            {
                ErrorList.Add(ConstantDataError.NameTooLong);
                return true;
            }
            return false;
        }
        public override bool HasErrors { get => IsInvalid(); set => base.HasErrors = value; }
    }
}