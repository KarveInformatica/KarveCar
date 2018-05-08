using Prism.Interactivity.InteractionRequest;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using KarveControls.Annotations;
using KarveDataServices.DataTransferObject;
using Syncfusion.UI.Xaml.CellGrid.Helpers;
using Syncfusion.UI.Xaml.Grid;

namespace KarveControls.Interactivity.Notifications
{
    public class ItemSelectionNotification : Confirmation, INotifyPropertyChanged
    {
        private object[] _items;
        private IncrementalList<object> _incrementalList;
   
        public ItemSelectionNotification()
        {
            _incrementalList = new IncrementalList<object>(LoadMoreItems);
            this.SelectedItem = null;
        }
        protected void LoadMoreItems(uint count, int baseIndex)
        {
            var list = _items.Skip(baseIndex).Take(100).ToList();
            if (Items is IncrementalList<object> summary)
            {
                summary.LoadItems(list);
            }
        }


        public ItemSelectionNotification(IEnumerable items)
            : this()
        {
            _items = items as object[] ?? items.Cast<object>().ToArray();
            Items= new IncrementalList<object>(LoadMoreItems) { MaxItemCount = _items.ToList<object>().Count()};
            var item = _items.ToList<object>().Take(100);
            Items.LoadItems(item);
        }
        public IncrementalList<object> Items { get => _incrementalList;
            set
            {

                _incrementalList = value;
                OnPropertyChanged("Items");
                 
            }
                                              }
        public string AssistProperites { set; get; }

        public object SelectedItem { get; set; }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
