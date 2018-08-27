using System;

namespace KarveDataServices.ViewObjects
{
    
    /// <summary>
    /// Date time of the holiday date. It allows to say which holiday is possible. 
    /// </summary>
    public class HolidayViewObject: BaseViewObject, IComparable
    {

        /// <summary>
        ///  Set or get the OFICINA property.
        /// </summary>

        public string OFICINA { get; set; }

        /// <summary>
        ///  Set or get the FESTIVO property.
        /// </summary>

        public DateTime FESTIVO { get; set; }

        /// <summary>
        ///  Set or get the PARTE_DIA property.
        /// </summary>

        public byte? PARTE_DIA { get; set; }

        /// <summary>
        ///  Set or get the HORA_DESDE property.
        /// </summary>

        public TimeSpan? HORA_DESDE { get; set; }
    
        /// <summary>
        ///  Set or get the HORA_HASTA property.
        /// </summary>

        public TimeSpan? HORA_HASTA { get; set; }

        public int CompareTo(object obj)
        {
            if (obj is HolidayViewObject tmp)
            {
                return tmp.FESTIVO.CompareTo(this.FESTIVO);
            }
            return 1;
        }
        public bool IsInvalid()
        {
            if ((OFICINA != null) && (OFICINA.Length > 2))
            {
                ErrorList.Add(ConstantDataError.NameTooLong);
                return true;
            }
            return false;
        }
        public override bool HasErrors { get => IsInvalid(); set => base.HasErrors = value; }
    }
}