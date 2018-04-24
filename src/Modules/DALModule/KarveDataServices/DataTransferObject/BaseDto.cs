using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Input;
using Syncfusion.Windows.Shared;
using KarveCommonInterfaces;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  Base Data Transfer Object use foreach object we need.
    /// A data transfer object shall have no state.
    /// </summary>
    [Serializable]
    public class BaseDto : NotificationObject, IValueObject, INotifyDataErrorInfo, IRevertibleChangeTracking, IDisposable 
    {
        // the problem is the _email;
        protected string _email;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = delegate { };

        public BaseDto()
        {
            ErrorsChanged += BaseDto_ErrorsChanged;
        }

        private void BaseDto_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
        public string KeyId { set; get; }

        /// <summary>
        ///  it is an alias for code
        ///  
        /// </summary>
        public string CodeId
        {
            set; get;
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
        /// Current User.
        /// </summary>
        public string CurrentUser { set; get; }
        /// <summary>
        ///  This specify if the dto is dirty.
        /// </summary>
        public virtual bool IsDirty { set; get; } = false;

        /// <summary>
        ///  This is specifies if the dto is new.
        /// </summary>
        public virtual bool IsNew { set; get; } = false;

        /// <summary>
        ///  This return the value of the object itself.
        /// </summary>
        public virtual BaseDto Value { get { return this; } }
        /// <summary>
        ///  Validation chain.
        /// </summary>
        public ValidationChain<BaseDto> ValidationChain 
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
        ///  Summary error dispose.
        /// </summary>
        public void Dispose()
        {
            ErrorsChanged -= BaseDto_ErrorsChanged;
        }
        public bool IsDeleted { get; set; }

        /// <summary>
        ///  ShowCommand. 
        /// </summary>
        public ICommand ShowCommand { get; set; }
    }
}
