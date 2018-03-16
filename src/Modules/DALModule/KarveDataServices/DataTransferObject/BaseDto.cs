using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommonInterfaces;
using System.Windows.Input;
using Prism.Mvvm;
using Syncfusion.Windows.Shared;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  Base Data Transfer Object use foreach object we need.
    /// A data transfer object shall have no state.
    /// </summary>
    [Serializable]
    public class BaseDto : NotificationObject, IValueObject, INotifyDataErrorInfo, IRevertibleChangeTracking 
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
        ///  This specify if the dto is dirty.
        /// </summary>
        public virtual bool IsDirty { set; get; }
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
        /// <summary>
        /// Get if there are validation erros
        /// </summary>
        public virtual bool HasErrors { get; set; }
        /// <summary>
        ///  Event handler fired in case any data error.
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        /// <summary>
        ///  Confirm the changes.
        /// </summary>
        public virtual void AcceptChanges()
        {
        }
        /// <summary>
        ///  The data object is just changed.
        /// </summary>
        public virtual bool IsChanged { get; set; }
        /// <summary>
        ///  You can reject the changes.
        /// </summary>
        public virtual void RejectChanges()
        {
        }
        /// <summary>
        ///  FIXME: thismakes sense?
        /// </summary>
        public ICommand DeleteCommand { get; set; }
        
    }
}
