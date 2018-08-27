using System;

namespace KarveDataServices.ViewObjects
{
    /// <summary>
    ///  Mantenaince viewObject
    /// </summary>
    public class MaintainanceViewObject: BaseViewObject
    {

        public MaintainanceViewObject()
        {
            
        }
        public MaintainanceViewObject(MaintainanceViewObject lastChangedObject)
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
        /// <summary>
        ///  Returns false if the maintenance is not valid 
        /// </summary>
        /// <returns></returns>
        public bool IsInvalid()
        {
            if ((MaintananceName != null) && (MaintananceName.Length > 100))
            {
                ErrorList.Add(ConstantDataError.NameTooLong);
                return true;
            }
            if ((MaintananceCode != null) && (MaintananceCode.Length > 6))
            {
                ErrorList.Add(ConstantDataError.NameTooLong);
                return true;
            }
            if ((Observation != null) && (Observation.Length > 2000))
            {
                ErrorList.Add(ConstantDataError.NameTooLong);
                return true;
            }
            return false;
        }
        public override bool HasErrors { get => IsInvalid(); set => base.HasErrors = value; }

    }
}