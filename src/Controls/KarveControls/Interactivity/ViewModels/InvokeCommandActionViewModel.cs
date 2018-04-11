

using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using KarveDataServices.DataTransferObject;
using Prism.Mvvm;
using Prism.Commands;

namespace KarveControls.Interactivity.ViewModels
{
    public class InvokeCommandActionViewModel : BindableBase
    {
        private BaseDto selectedItemText;

        public InvokeCommandActionViewModel()
        {
            this.Items = new List<BaseDto>();
            
            // This command will be executed when the selection of the ListBox in the view changes.
            this.SelectedCommand = new DelegateCommand<object[]>(this.OnItemSelected);
        }

        public IList<BaseDto> Items { get; set; }

        public ICommand SelectedCommand { get; private set; }

        public BaseDto SelectedItem
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
                var current = obj.FirstOrDefault() as BaseDto;
                if (current != null)
                {
                    this.SelectedItem =current;
                }
            }
        }
    }
}
