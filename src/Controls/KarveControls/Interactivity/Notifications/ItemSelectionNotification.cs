using Prism.Interactivity.InteractionRequest;
using System.Collections;
using System.Collections.Generic;

namespace KarveControls.Interactivity.Notifications
{
    public class ItemSelectionNotification : Confirmation
    {
        private IList<object> _items;
   
        public ItemSelectionNotification()
        {
            _items = new List<object>();
            this.SelectedItem = null;
        }

        public ItemSelectionNotification(IEnumerable items)
            : this()
        {
            if (items != null)
            {
                foreach (var item in items)
                {
                    this.Items.Add(item);
                }
            }
        }
        public IList<object> Items { get { return _items; }
                                     set { _items = value; }
                                              }
        public string AssistProperites { set; get; }

        public object SelectedItem { get; set; }
    }
}
