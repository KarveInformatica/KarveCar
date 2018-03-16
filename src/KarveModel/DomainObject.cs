using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveModel
{
    public abstract class DomainObject : INotifyDataErrorInfo, IRevertibleChangeTracking
    {
        /// <summary>
        ///  This spots errors 
        /// </summary>
        public bool HasErrors { get; set; }
        /// <summary>
        ///  This set if it is changed or not
        /// </summary>
        public bool IsChanged { get; set; }
        /// <summary>
        ///  This sets if there are errors.
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        /// <summary>
        ///  Accept changes.
        /// </summary>
        public abstract void AcceptChanges();
        /// <summary>
        ///  Retrieve any error 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public  abstract IEnumerable GetErrors(string propertyName);
        /// <summary>
        ///  This can reject changes.
        /// </summary>
        public abstract void RejectChanges();
    }
}
