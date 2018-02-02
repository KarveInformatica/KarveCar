using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  Base Data Transfer Object use foreach object that we need..
    /// </summary>
    [Serializable]
    public class BaseDto : IValueObject
    {
        public BaseDto()
        {
        }
        /// <summary>
        ///  LastModification
        /// </summary>
        public string LastModification { set; get; }
        /// <summary>
        ///  User
        /// </summary>
        public string User { set; get; }

        /// <summary>
        ///  This return the value of the object itself.
        /// </summary>
        public virtual BaseDto Value { get { return this; } }
    }
}
