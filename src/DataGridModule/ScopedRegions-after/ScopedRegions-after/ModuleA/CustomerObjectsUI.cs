using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Mvvm;

namespace ModuleA
{

    public class CustomerUIObjects : ObservableCollection<CustomerUIObject>
    {
        protected override void InsertItem(int index, CustomerUIObject item)
        {
            base.InsertItem(index, item);

            // handle any EndEdit events relating to this item
            item.ItemEndEdit += new ItemEndEditEventHandler(ItemEndEditHandler);
        }

        void ItemEndEditHandler(IEditableObject sender)
        {
            // simply forward any EndEdit events
            if (ItemEndEdit != null)
            {
                ItemEndEdit(sender);
            }
        }

        #region events

        public event ItemEndEditEventHandler ItemEndEdit;

        #endregion
    }

    public delegate void ItemEndEditEventHandler(IEditableObject sender);

    /// <summary>
    /// A customer object that implements the various interfaces required by the UI framework. The 
    /// IEditableObject interface is implemented so that we know that the DataGrid commits changes to this object
    /// </summary>
    public class CustomerUIObject : BindableBase, IEditableObject
    {
        // this object is backed by the dataobject
        private CustomerDataObject customer;


        public CustomerUIObject()
        {
            customer = new CustomerDataObject();
        }

        public CustomerUIObject(CustomerDataObject customer)
        {
            this.customer = customer;
        }

        public CustomerDataObject GetDataObject()
        {
            return customer;
        }

        public string ID
        {
            get
            {
                return customer.Id;
            }
            set
            {
                customer.Id = value;
                RaisePropertyChanged("Customers");

            }
        }

        public string CompanyName
        {
            get
            {
                return customer.CompanyName;
            }
            set
            {
                customer.CompanyName = value;
                RaisePropertyChanged("CompanyName");
            }
        }

        public string ContactName
        {
            get
            {
                return customer.ContactName;
            }
            set
            {
                customer.ContactName = value;
                RaisePropertyChanged("ContactName");
            }
        }

        #region events

        public event ItemEndEditEventHandler ItemEndEdit;

        #endregion

        #region IEditableObject Members

        public void BeginEdit()
        {
        }

        public void CancelEdit()
        {
        }

        public void EndEdit()
        {
            if (ItemEndEdit != null)
            {
                ItemEndEdit(this);
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #endregion
    }
    
}
