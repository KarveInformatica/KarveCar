using Prism.Interactivity.InteractionRequest;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using KarveCommon.Generic;
using KarveControls.Annotations;
using KarveDataServices.DataTransferObject;
using Syncfusion.UI.Xaml.CellGrid.Helpers;
using Syncfusion.UI.Xaml.Grid;

namespace KarveControls.Interactivity.Notifications
{
    /// <summary>
    ///  ItemSelectionNotification. 
    /// </summary>
    public class ItemSelectionNotification : Confirmation, INotifyPropertyChanged
    {
        private readonly object[] _items;
        private IncrementalList<object> _incrementalList;
        private long _gridIdentifier;
        private ICommand _gridInitCommand;

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
        /// <summary>
        /// IncrementalList of utems.
        /// </summary>
        public IncrementalList<object> Items
        {
            get => _incrementalList;
            set
            {

                _incrementalList = value;
                OnPropertyChanged("Items");

            }

        }
        /// <summary>
        ///  Identifier of the grid.
        /// </summary>
        public long GridIdentifier
        {
            set {
                _gridIdentifier = value;
                OnPropertyChanged("GridIdentifier");
            }
            get { return _gridIdentifier; }
        }
        /// <summary>
        ///  Initializer of the grid command
        /// </summary>
        public ICommand GridInitCommand {
            set
            {
                _gridInitCommand = value;
                OnPropertyChanged("GridInitCommand");
            }
            get { return _gridInitCommand; }
        }
        public ICommand GridParamChangedCommand { set; get; }
        public KarveGridParameters GridParameters { set; get; }
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
