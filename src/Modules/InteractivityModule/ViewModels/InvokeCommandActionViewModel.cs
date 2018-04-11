

using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using KarveDataServices.DataTransferObject;


namespace Karve.Interactivity.ViewModels
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

        public string SelectedItemText
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
                this.SelectedItemText = obj.FirstOrDefault().ToString();
            }
        }
    }
}
