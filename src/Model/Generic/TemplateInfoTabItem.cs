using System.Windows.Controls;

namespace KarveCar.Model.Generic
{
    /// <summary>
    /// Plantilla con la info de los TabItem:<para/>
    /// obscollectionorigin -> GenericObservableCollection con la información original recogida de la BBDD<para/>
    /// obscollectioncopy   -> GenericObservableCollection donde se efectuarán los cambios CRUD<para/>
    /// tabitem             -> TabItem que contendrá el usercontrol que corresponda<para/>
    /// </summary>
    public class TemplateInfoTabItem : GenericPropertyChanged
    {
        #region Constructores
        public TemplateInfoTabItem() { }

        public TemplateInfoTabItem(GenericObservableCollection obscollectionorigin)
        {
            this.obscollectionorigin = obscollectionorigin;
        }

        public TemplateInfoTabItem(TabItem tabitem)
        {
            this.tabitem = tabitem;
        }

        public TemplateInfoTabItem(GenericObservableCollection obscollectionorigin, GenericObservableCollection obscollectioncopy, TabItem tabitem)
        {
            this.obscollectionorigin = obscollectionorigin;
            this.obscollectioncopy   = obscollectioncopy;
            this.tabitem = tabitem;
        }
        #endregion

        #region Propiedades
        private GenericObservableCollection obscollectionorigin;
        public GenericObservableCollection ObsCollectionOrigin
        {
            get
            {
                return obscollectionorigin;
            }
            set
            {
                obscollectionorigin = value;
                OnPropertyChanged("ObsCollectionOrigin");
            }
        }

        private GenericObservableCollection obscollectioncopy;
        public GenericObservableCollection ObsCollectionCopy
        {
            get
            {
                return obscollectioncopy;
            }
            set
            {
                obscollectioncopy = value;
                OnPropertyChanged("ObsCollectionCopy");

            }
        }

        private TabItem tabitem;        
        public TabItem TabItem
        {
            get
            {
                return tabitem;
            }
            set
            {
                tabitem = value;
                OnPropertyChanged("TabItem");
            }
        }
        #endregion
    }
}
