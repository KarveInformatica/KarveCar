using System;
using System.Collections.Generic;
using System.Windows.Interactivity;
using KarveControls;
using KarveCommon.Generic;
using KarveDataServices.ViewObjects;
using Syncfusion.UI.Xaml.Grid;

namespace MasterModule.Common
{
    class DelegationValidationBehavior: Behavior<SfDataGrid>
    {
        private BranchesViewObject lastChangedObject = null;

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.CurrentCellValidating += AssociatedObject_CurrentCellValidating;
            this.AssociatedObject.RowValidating += AssociatedObject_RowValidating;
        }


        void AssociatedObject_RowValidating(object sender, RowValidatingEventArgs args)
        {
            var data = args.RowData as BranchesViewObject;
            if (data == null)
            {
                args.ErrorMessages.Add("General", "Invalid insert");
                args.IsValid = false;
                return;
            }
           
            
            long codeValue = Convert.ToInt64(data.BranchId);
            if (codeValue <= 0)
            {
                args.ErrorMessages.Add("ErrorCode", "Code no valido");
                args.IsValid = false;
            }
           
          
            if (lastChangedObject == null)
            {
                lastChangedObject = data;
            }
            Dictionary<string, object> objectName = new Dictionary<string, object>();
            objectName["DataObject"] = ControlExt.GetDataSource(AssociatedObject);
            objectName["ChangedValue"] = data;
            objectName["PreviousValue"] = new BranchesViewObject(lastChangedObject);

        }
        void AssociatedObject_CurrentCellValidating(object sender, CurrentCellValidatingEventArgs args)
        {
            if (args.Column.MappingName == "BranchId" && Convert.ToDecimal(args.NewValue) <= 0)
            {
                args.ErrorMessage = "Invalid code";
                args.IsValid = false;
            }
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.CurrentCellValidating -= AssociatedObject_CurrentCellValidating;
            this.AssociatedObject.RowValidating -= AssociatedObject_RowValidating;
        }
    }
}
