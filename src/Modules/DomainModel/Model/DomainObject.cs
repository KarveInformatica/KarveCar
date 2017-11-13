using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Prism.Mvvm;

namespace Model
{
    /// <summary>
    ///  Domain object foreach 
    /// </summary>
    public abstract class DomainObject: BindableBase, IRevertibleChangeTracking, INotifyDataErrorInfo
    {
        /// <summary>
        ///  Get the errors relative to a property.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        
        public virtual IEnumerable GetErrors(string propertyName)
        {
            return new List<object>();
        }

        /// <summary>
        ///  The model has error due to the validation.
        /// </summary>
        public virtual bool HasErrors { get; }
        /// <summary>
        /// The delegate for the error has been changed.
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        /// <summary>
        /// The value of accepted changes.
        /// </summary>
        public virtual void AcceptChanges()
        {
        }
        /// <summary>
        ///  This domain object has some changed properties.
        /// </summary>
        public virtual bool IsChanged { get; set; }
        /// <summary>
        ///  We reject changes.
        /// </summary>
        public virtual void RejectChanges()
        {
        }
    }
}