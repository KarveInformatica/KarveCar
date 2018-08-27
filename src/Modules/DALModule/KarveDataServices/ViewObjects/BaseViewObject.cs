using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Input;
using Syncfusion.Windows.Shared;
using KarveCommonInterfaces;
using System.Collections.Generic;
using EmailValidation;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.ViewObjects
{
    /// <inheritdoc />
    /// <summary>
    ///  Base Data Transfer Object use foreach object we need.
    /// A data transfer object shall have no state.
    /// </summary>
    [Serializable]
    public class BaseViewObject : NotificationObject, INotifyDataErrorInfo, IRevertibleChangeTracking, IDisposable
    {
        // this is is possible to detect the errors.
        protected List<string> ErrorList = new List<string>();
        private readonly IDictionary<string, List<string>> ErrorDict = new Dictionary<string, List<string>>();
        private bool _errors;
        protected  string _email= String.Empty;
        protected const int NameSize = 100;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = delegate {};

        public BaseViewObject()
        {
            _errors = false;
            IsNew = false;
            IsDirty = false;
            IsDeleted = false;
            IsChanged = false;

        }

    
      
        public string KeyId { set; get; }

        private bool IsValidEmailField(string data)
        {
           
            return EmailValidator.Validate(data);
        }

        private bool IsValidPhoneField(string data)
        {
            var regexp = new System.Text.RegularExpressions.Regex("[\\+\\-0-9]");
            return regexp.IsMatch(data);
        }

        private bool Validate(object dto)
        {
            var results = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(dto, new ValidationContext(this), results, true);
            return valid;
        }
        /// <summary>
        ///  Set or get the code
        ///  
        /// </summary>
        [DisplayName("Codigo")]
        public virtual string Code
        {
            set; get;
        }
        /// <summary>
        ///  Set or Get the name.
        /// </summary>
        [DisplayName("Nombre")]
        public virtual string Name { set; get; }

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
        ///  This specify if the viewObject is dirty.
        /// </summary>
        public bool IsDirty { set; get; } = false;

        /// <summary>
        ///  This is specifies if the viewObject is new.
        /// </summary>
        public bool IsNew { set; get; } = false;

        /// <summary>
        ///  This is specifies if the viewObject is new.
        /// </summary>
        public bool IsValid { set; get; } = true;

        /// <summary>
        ///  This return the value of the object itself.
        /// </summary>
        public BaseViewObject Value => this;

        /// <summary>
        ///  Validation chain.
        /// </summary>
        public ValidationChain<BaseViewObject> ValidationChain 
            { get; set;}

        /// <summary>
        ///  Get or Set the list of errors.
        /// </summary>
        public IList<string> Errors {
            get {
                var lists = ErrorDict.Values;
                var outList = new List<string>();
                var first = true;
                foreach (var l in lists)
                {
                    outList = l;
                    if (!first)
                    {
                        outList = outList.Union(l).ToList();
                    }
                    first = false;
                }
                return outList;
            }
        }
        /// <summary>
        ///  Set or get the errors for a given property
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public IEnumerable GetErrors(string propertyName)
        {
            List<string> error = new List<string>();
            if (ErrorDict.ContainsKey(propertyName))
            {
                error = ErrorDict[propertyName];
            }
           return error;
        }
        /// <summary>
        ///  Add a new error message for the property.
        /// </summary>
        /// <param name="prop"></param>
        /// <param name="value"></param>
        public void AddMessage(string prop, string value)
        {
            if (!ErrorDict.ContainsKey(prop))
            {
                var list = new List<string>() { value };
                ErrorDict.Add(prop, list);
            }
            else
            {
                var listError = ErrorDict[prop];
                listError.Add(value);
                ErrorDict.Remove(prop);
                ErrorDict.Add(prop, listError);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get if there are validation errors
        /// </summary>
        public virtual bool HasErrors
        {
            get => _errors;
            set => _errors = value;
        }
        
        /// <summary>
        ///  Confirm the changes.
        /// </summary>
        public void AcceptChanges()
        {
        }
        /// <summary>
        ///  The data object is just changed.
        /// </summary>
        public bool IsChanged { get; set; }
        /// <summary>
        ///  You can reject the changes.
        /// </summary>
        public void RejectChanges()
        {
        }
        /// <summary>
        ///  Summary error dispose.
        /// </summary>
        public void Dispose()
        {
            ErrorDict.Clear();

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
