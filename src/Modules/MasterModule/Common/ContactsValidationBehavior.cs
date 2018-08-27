using System;
using System.Collections.Generic;
using System.Windows.Interactivity;
using KarveControls;
using KarveDataServices.ViewObjects;
using Syncfusion.UI.Xaml.Grid;

namespace MasterModule.Common {

    public class ContactsValidationBehavior : Behavior<SfDataGrid>
    {
        private ContactsViewObject lastChangedObject = null;
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.CurrentCellValidating += AssociatedObject_CurrentCellValidating;
            this.AssociatedObject.RowValidating += AssociatedObject_RowValidating;
        }


        void AssociatedObject_RowValidating(object sender, RowValidatingEventArgs args)
        {
            var data = args.RowData as ContactsViewObject;
            if (data == null)
            {
                args.ErrorMessages.Add("General", "Invalid insert");
                args.IsValid = false;
                return;
            }
          
            if (lastChangedObject == null)
            {
                lastChangedObject = data;
            }
            Dictionary<string, object> objectName = new Dictionary<string, object>();
            objectName["DataObject"] = ControlExt.GetDataSource(AssociatedObject);
            objectName["ChangedValue"] = data;
            objectName["PreviousValue"] = lastChangedObject;
        }
        void AssociatedObject_CurrentCellValidating(object sender, CurrentCellValidatingEventArgs args)
        {
           
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.CurrentCellValidating -= AssociatedObject_CurrentCellValidating;
            this.AssociatedObject.RowValidating -= AssociatedObject_RowValidating;
        }
    }
}