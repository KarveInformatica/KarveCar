using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommonInterfaces;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  Base Data Transfer Object use foreach object we need.
    /// A data transfer object shall have no state.
    /// </summary>
    [Serializable]
    public class BaseDto : IValueObject, INotifyDataErrorInfo, IRevertibleChangeTracking
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
        /// <summary>
        ///  Validation chain.
        /// </summary>
        public IValidationChain<BaseDto> ValidationChain 
            { get; set;}
        public IEnumerable GetErrors(string propertyName)
        {
          return new ArrayList();
        }
        public bool HasErrors { get; }
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public virtual void AcceptChanges()
        {
        }
        public virtual bool IsChanged { get; }
        public virtual void RejectChanges()
        {
        }
    }
}
