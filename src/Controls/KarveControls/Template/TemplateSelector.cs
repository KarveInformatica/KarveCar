using System.Windows;
using System.Windows.Controls;
using KarveControls.UIObjects;

namespace KarveControls.Template
{
    /// <summary>
    /// Template selector for the items and group of collection that appear in the code
    /// </summary>
    
    public class TemplateSelector : DataTemplateSelector
    {
        private DataTemplate _dataField;
        private DataTemplate _dualDataField;
        private DataTemplate _searchTextBox;
        private DataTemplate _dualFieldSearchTextBox;
        private DataTemplate _doubleDataField;
        private DataTemplate _dualFieldAfterSearchTextBox;
        private DataTemplate _multipleDataFields;
        private DataTemplate _emailDataTemplate;
        private DataTemplate _groupBoxDataField;
        private DataTemplate _dataAreaTemplate;
        private DataTemplate _dataFieldCheckBox;
        private DataTemplate _dataFieldPickerBox;
        private DataTemplate _dataComboxTemplate;

        public TemplateSelector()
        {
            _dataField = new DataTemplate();
            _dualDataField = new DataTemplate();
            _searchTextBox = new DataTemplate();
            _dualFieldSearchTextBox = new DataTemplate();
            _doubleDataField = new DataTemplate();
            _multipleDataFields = new DataTemplate();
            _emailDataTemplate = new DataTemplate();
            _groupBoxDataField = new DataTemplate();
            _dataAreaTemplate = new DataTemplate();
            _dataFieldCheckBox = new DataTemplate();
            _dataFieldPickerBox = new DataTemplate();
           
        }

        public DataTemplate DataFieldTemplate
        {
            get { return _dataField; }
            set { _dataField = value; }
        }
        public DataTemplate DualDataFieldTemplate
        {
            get { return _dualDataField; }
            set { _dualDataField = value; }
        }
        public DataTemplate SearchTextBoxTemplate
        {
            get { return _searchTextBox; }
            set { _searchTextBox = value; }
            
        }

        public DataTemplate MultipleDataFieldTemplate
        {
            get { return _multipleDataFields; }
            set { _multipleDataFields = value; }
        }
        public DataTemplate DualFieldSearchTemplate
        {
            get { return _dualFieldSearchTextBox; }
            set { _dualFieldSearchTextBox = value; }
        }

        public DataTemplate DoubleDataTemplate
        {
            get { return _doubleDataField; }
            set { _doubleDataField = value; }

        }

        public DataTemplate EmailDataTemplate
        {
            get { return _emailDataTemplate; }
            set { _emailDataTemplate = value; }
        }

        public DataTemplate  DualFieldAfterSearchTemplate
        {
            get { return _dualFieldAfterSearchTextBox; }
            set { _dualFieldAfterSearchTextBox = value; }
        }

        public DataTemplate GroupBoxTemplate
        {
            get { return _groupBoxDataField; }
            set { _groupBoxDataField = value; }
        }

        public DataTemplate PickerFieldTemplate
        {
            get { return _dataFieldPickerBox; }
            set { _dataFieldPickerBox = value; }
        }

        public DataTemplate DataAreaTemplate
        {
            get { return _dataAreaTemplate; }
            set { _dataAreaTemplate = value; }
        }
       
  
        /*
         * 
         *    DataFieldCheckBox ="{StaticResource ResourceKey=DataFieldCheckBoxTemplate}"
                                       PickerField="{StaticResource ResourceKey=DataFieldPickerTemplate}"
                                       DataAreaField="{StaticResource ResourceKey=DataAreaTemplate}"
         */
        public DataTemplate DataFieldCheckBox
        {
            get { return _dataFieldCheckBox; }
            set { _dataFieldCheckBox = value; }
        }

        public DataTemplate PickerField
        {
            get { return _dataFieldCheckBox; }
            set { _dataFieldCheckBox = value; }
        }

        public DataTemplate DataAreaField
        {
            get { return _dataAreaTemplate; }
            set { _dataAreaTemplate = value; }
        }

        public DataTemplate DataComboxBoxTemplate
        {
            get { return _dataComboxTemplate; }
            set { _dataComboxTemplate = value; }
        }
        //You override this function to select your data template based in the given item
        public override System.Windows.DataTemplate SelectTemplate(object item,
            System.Windows.DependencyObject container)
        {

            if (item is UiDataFieldCheckBox)
            {
                return _dataFieldCheckBox;
            }
            if (item is UiDataCombox)
            {
                return _dataComboxTemplate;
            }
             if (item is UiDataArea)
            {
                return _dataAreaTemplate;
            }
            if (item is UiDatePicker)
            {
                return _dataFieldPickerBox;
            }
            if (item is UiDataFieldCheckBox)
            {
                return _dataFieldCheckBox;
            }
            if (item is UiSearchTextObject)
            {
                return _searchTextBox;
            }
            if (item is UiDualDfSearchTextObject)
            {
                return _dualFieldSearchTextBox;
            }
            if (item is UiDualDfObject)
            {
                return _dualDataField;
            }
            if (item is UiEmailDataField)
            {
                return _emailDataTemplate;
            }
            if (item is UiDualDfAfterSearchBoxObject)
            {
                return _dualFieldAfterSearchTextBox;
            }
            if (item is UiDoubleDfObject)
            {
                return _doubleDataField;
            }
            if (item is UiGroupBoxMultipleObject)
            {
                return _groupBoxDataField;
            }
            if (item is UiMultipleDfObject)
            {
                return _multipleDataFields;
            }
            if (item is UiDfObject)
            {
                return _dataField;
            }      
            return base.SelectTemplate(item, container);
        }
    }
}
