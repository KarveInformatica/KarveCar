

using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using KarveDataServices.ViewObjects;
using Prism.Mvvm;
using Prism.Commands;

namespace KarveControls.Interactivity.ViewModels
{
    public class InvokeCommandActionViewModel : BindableBase
    {
        private BaseViewObject selectedItemText;

        public InvokeCommandActionViewModel()
        {
            this.Items = new List<BaseViewObject>();
            
            // This command will be executed when the selection of the ListBox in the view changes.
            this.SelectedCommand = new DelegateCommand<object[]>(this.OnItemSelected);
        }

        public IList<BaseViewObject> Items { get; set; }

        public ICommand SelectedCommand { get; private set; }

        public BaseViewObject SelectedItem
        {
            get
            {
                return this.selectedItemText;
            }
            private set
            {
                this.SetProperty(ref this.selectedItemText, value);
            }
        }

        private void OnItemSelected(object[] obj)
        {
            if (obj != null && obj.Count() > 0)
            {
                var current = obj.FirstOrDefault() as BaseViewObject;
                if (current != null)
                {
                    this.SelectedItem =current;
                }
            }
        }
    }
}
