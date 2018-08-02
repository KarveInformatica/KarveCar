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
        private object _incrementalList;
        private long _gridIdentifier;
        private ICommand _gridInitCommand;

        public ItemSelectionNotification()
        {
            this.SelectedItem = null;
        }
        


        public ItemSelectionNotification(IEnumerable items)
            : this()
        {
            Items = items;
         
        }
        /// <summary>
        /// IncrementalList of utems.
        /// </summary>
        public object Items
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
