using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interactivity;
using KarveControls;
using KarveDataServices.DataTransferObject;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.Windows.Forms.Tools;

namespace MasterModule.Common
{

        public class MaintenanceValidationBehavior : Behavior<SfDataGrid>
    {

            private MaintainanceDto lastChangedObject = null;

            protected override void OnAttached()
            {
                base.OnAttached();
                this.AssociatedObject.CurrentCellValidating += AssociatedObject_CurrentCellValidating;
                this.AssociatedObject.RowValidating += AssociatedObject_RowValidating;
            }

          
            void AssociatedObject_RowValidating(object sender, RowValidatingEventArgs args)
            {
                var data = args.RowData as MaintainanceDto;
                if (data == null)
                {
                    args.ErrorMessages.Add("General","Invalid insert");
                    args.IsValid = false;
                    return;
                }
                decimal codeValue = 0;
                if (!decimal.TryParse(data.MaintananceCode, out codeValue))
                {
                    args.ErrorMessages.Add("MainteanceCode", "Code no valido");
                    args.IsValid = false;
                }
                if (codeValue <=0)
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
                objectName["PreviousValue"] = new MaintainanceDto(lastChangedObject);
               
            }
            void AssociatedObject_CurrentCellValidating(object sender, CurrentCellValidatingEventArgs args)
            {
                if (args.Column.MappingName == "Maintainance" && Convert.ToDecimal(args.NewValue) <=0)
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
