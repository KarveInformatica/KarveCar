using System.Windows.Controls;
using KarveCommon.Generic;

namespace KarveCar.Model.Generic
{
    /// <summary>
    /// Plantilla con la info de los TabItem:<para/>
    /// genericobscollection -> GenericObservableCollection con la información original recogida de la BBDD<para/>
    /// tabitem              -> TabItem que contendrá el usercontrol que corresponda<para/>
    /// </summary>
    public class TemplateInfoTabItem : GenericPropertyChanged
    {
        #region Constructores
        public TemplateInfoTabItem() { }

        public TemplateInfoTabItem(TabItem tabitem)
        {
            this.tabitem = tabitem;
        }

        public TemplateInfoTabItem(GenericObservableCollection genericobscollection, TabItem tabitem)
        {
            this.genericobscollection = genericobscollection;
            this.tabitem = tabitem;
        }
        #endregion

        #region Propiedades
        private GenericObservableCollection genericobscollection;
        public GenericObservableCollection GenericObsCollection
        {
            get
            {
                return genericobscollection;
            }
            set
            {
                genericobscollection = value;
                OnPropertyChanged("GenericObsCollection");
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
