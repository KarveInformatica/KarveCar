using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Input;
using Syncfusion.Windows.Shared;
using KarveCommonInterfaces;
using System.Collections.Generic;
using EmailValidation;

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
        protected List<string> ErrorList = new List<string>();
        protected const int NameSize = 35;
        protected const int SecondNameSize = 50;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public BaseDto()
        {
            
            HasErrors = false;
        }

        
        public virtual string Name { set; get; }

        public string KeyId { set; get; }

        protected bool IsValidEmailField(string data)
        {
           
            return EmailValidator.Validate(data);
        }
        protected bool IsValidPhoneField(string data)
        {
            System.Text.RegularExpressions.Regex regexp = new System.Text.RegularExpressions.Regex("[\\+\\-0-9]");
            if (regexp.IsMatch(data))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        ///  it is an alias for code
        ///  
        /// </summary>
        public virtual string Code
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
        ///  This is specifies if the dto is new.
        /// </summary>
        public virtual bool IsValid { set; get; } = true;

        /// <summary>
        ///  This return the value of the object itself.
        /// </summary>
        public virtual BaseDto Value { get { return this; } }
        /// <summary>
        ///  Validation chain.
        /// </summary>
        public ValidationChain<BaseDto> ValidationChain 
            { get; set;}

        public virtual IEnumerable GetErrors(string propertyName)
        {
            return ErrorList;
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
            ErrorList.Clear();
            HasErrors = false;
            
        }
        public bool IsDeleted { get; set; }

        /// <summary>
        ///  ShowCommand. 
        /// </summary>
        public ICommand ShowCommand { get; set; }
        public bool IsSelected { get; set; }

        public virtual void ClearErrors()
        {
            Dispose();
        }
    }
}
