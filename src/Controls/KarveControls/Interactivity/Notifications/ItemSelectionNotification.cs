using System.Collections;
using System.Windows.Input;
using KarveCommon.Generic;
using System;

namespace KarveControls.Interactivity.Notifications
{
    /// <summary>
    ///  ItemSelectionNotification is used when you need to select an item from a grid of elements. 
    /// </summary>
    public sealed class ItemSelectionNotification : BaseNotification, IDisposable
    {
        private object _incrementalList;
        private long _gridIdentifier;
        private ICommand _gridInitCommand;

        public ItemSelectionNotification()
        {
            this.SelectedItem = null;
        }
        /// <summary>
        ///  Constructor for a list of items.
        /// </summary>
        /// <param name="items">A list of items.</param>
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
        /// <summary>
        ///  Set or Get the grid parameters changed.
        /// </summary>
        public ICommand GridParamChangedCommand { set; get; }
        /// <summary>
        ///  Set or get the grid parametes.
        /// </summary>
        public KarveGridParameters GridParameters { set; get; }
        /// <summary>
        ///  Set or Get the assist properties
        /// </summary>
        public string AssistProperites { set; get; }
        /// <summary>
        ///  Set or Get the selected item.
        /// </summary>
        public object SelectedItem { get; set; }

        /// <summary>
        ///  Dispose the list
        /// </summary>
        public void Dispose()
        {
           /* 
            * This clear directly every incremental list o list that we can have as item.
            */
           if (_incrementalList != null)
            {
                var type = _incrementalList.GetType();
                var methods = type.GetMethods();
                foreach (var m in methods)
                {
                    if (m.Name == "Clear")
                    {
                        m.Invoke(_incrementalList,null);
                    }
                    
                }
            }
        }
    }
}
