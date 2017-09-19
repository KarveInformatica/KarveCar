using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using KarveControls.UIObjects;
using System.Windows.Controls;

namespace WpfUpdater
{
    public class TemplateSelector : DataTemplateSelector
    {
        private DataTemplate _dataField;
        private DataTemplate _dualDataField;
        private DataTemplate _searchTextBox;
        private DataTemplate _dualFieldSearchTextBox;
        private DataTemplate _dataGridTemplate;
        private DataTemplate _dualFieldAfterSearchTextBox;

        public TemplateSelector()
        {
            _dataField = new DataTemplate();
            _dualDataField = new DataTemplate();
            _searchTextBox = new DataTemplate();
            _dualFieldSearchTextBox = new DataTemplate();
            _dataGridTemplate = new DataTemplate();
        }

        public DataTemplate DataField
        {
            get { return _dataField; }
            set { _dataField = value; }
        }
        public DataTemplate DualDataField
        {
            get { return _dualDataField; }
            set { _dualDataField = value; }
        }
        public DataTemplate SearchTextBox
        {
            get { return _searchTextBox; }
            set { _searchTextBox = value; }
            
        }

        public DataTemplate DualFieldSearchTextBox
        {
            get { return _dualFieldSearchTextBox; }
            set { _dualFieldSearchTextBox = value; }
        }

        public DataTemplate DualFieldAfterSeachBox
        {
            get { return _dualFieldAfterSearchTextBox; }
            set { _dualFieldAfterSearchTextBox = value; }
        }

        //You override this function to select your data template based in the given item
        public override System.Windows.DataTemplate SelectTemplate(object item,
            System.Windows.DependencyObject container)
        {

            if (item is UserInterfaceSearchTextObject)
            {
                return _searchTextBox;
            }
            if (item is UserInterfaceDualDfSearchBox)
            {
                return _dualFieldSearchTextBox;
            }
            if (item is UserInterfaceDualDfObject)
            {
                return _dualDataField;
            }
            if (item is UserInterfaceDfObject)
            {
                return _dataField;
            }
            if (item is UserInterfaceDataGrid)
            {
                return _dataGridTemplate;
            }
            if (item is UiDualDfAfterSearchBox)
            return base.SelectTemplate(item, container);
        }
    }
}
