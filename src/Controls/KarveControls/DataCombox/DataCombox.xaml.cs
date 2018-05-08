using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using KarveCommon.Generic;
using KarveControls.Generic;
using Prism.Commands;
using static KarveControls.ControlExt;

namespace KarveControls
{
    /// <summary>
    /// Interaction logic for DataCombox.xaml
    /// </summary>
    public partial class DataCombox : UserControl
    {
        private ObservableCollection<string> _currentItems = new ObservableCollection<string>();
        private DataTable _itemSource = new DataTable();
        private string _dataField = "";
        private string _tableName = "";
        private DataType _dataAllowed;
        private ICommand _selectionChangedCommand;

        public static readonly RoutedEvent DataComboxChangedEvent =
            EventManager.RegisterRoutedEvent(
                "DataComboxChanged",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(DataCombox));

        /// <summary>
        ///  Property Changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }



        public class DataComboxEventArgs : RoutedEventArgs
        {
            private object _fieldData;
            private IDictionary<string, object> _changedValues = new Dictionary<string, object>();
            public object FieldData
            {
                get { return _fieldData; }
                set { _fieldData = value; }
            }
            public IDictionary<string, object> ChangedValuesObjects
            {
                get { return _changedValues; }
                set { _changedValues = value; }
            }
            public DataComboxEventArgs() : base()
            {
            }
            public DataComboxEventArgs(RoutedEvent routedEvent) : base(routedEvent)
            {
            }
        }
        public DataCombox()
        {
            InitializeComponent();
            ComboBoxChangedSelection = new DelegateCommand<object>(OnSelectedItemCommand);
            this.ComboLayout.DataContext = this;
        }
        private void OnSelectedItemCommand(object obj)
        {
            // in this case we shall prepare an event an raise up to the view model.
            DataComboxEventArgs ev = new DataComboxEventArgs(DataComboxChangedEvent)
            {
                FieldData = obj
            };
            IDictionary<string, object> valueDictionary = new Dictionary<string, object>
            {
                ["TableName"] = TableName,
                ["Field"] = DataField,
                ["DataTable"] = ItemSource,
                ["ChangedValue"] = obj
            };
            ev.ChangedValuesObjects = valueDictionary;
            RaiseEvent(ev);
        }

        public static DependencyProperty ItemsDependencyProperty =
            DependencyProperty.Register(
                "Items",
                typeof(ObservableCollection<string>),
                typeof(DataCombox),
                new PropertyMetadata(null, OnItemsDependencyProperty));

        private static void OnItemsDependencyProperty(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataCombox dataCombox = d as DataCombox;
            dataCombox.OnPropertyChanged("Items");
        }

        public ObservableCollection<string> Items
        {
            get { return _currentItems; }
            set { _currentItems = value; }
        }
        #region ItemSource

        public static DependencyProperty ItemSourceDependencyProperty
            = DependencyProperty.Register(
                "ItemSource",
                typeof(DataTable),
                typeof(DataCombox),
                new PropertyMetadata(new DataTable(), OnItemSourceChanged));

        public DataTable ItemSource
        {
            get { return (DataTable)GetValue(ItemSourceDependencyProperty); }
            set { SetValue(ItemSourceDependencyProperty, value); }
        }
        private static void OnItemSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DataCombox control)
            {
                control.OnPropertyChanged("ItemSource");
                control.OnItemSourceChanged(e);
            }
        }

        public ICommand ComboBoxChangedSelection
        {
            set { _selectionChangedCommand = value; }
            get { return _selectionChangedCommand; }
        }
        protected virtual void OnItemSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            DataTable table = e.NewValue as DataTable;
            this._itemSource = table;
            if (!string.IsNullOrEmpty(_dataField))
            {
                if (table != null)
                {
                    var componentFiller = new ComponentFiller();
                    componentFiller.FillComboxBox(table, _dataField, ref this.KarveComboBox);
                }
            }
        }
        #endregion

        #region TableName
        public static readonly DependencyProperty DBTableNameDependencyProperty =
            DependencyProperty.Register(
                "TableName",
                typeof(string),
                typeof(DataCombox),
                new PropertyMetadata(string.Empty, OnTableNameChange));
        private static void OnTableNameChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataCombox control = d as DataCombox;
            if (control != null)
            {
                control.OnPropertyChanged("TableName");
                control.OnTableNameChanged(e);
            }
        }
        public string TableName
        {
            get { return (string)GetValue(DBTableNameDependencyProperty); }
            set { SetValue(DBTableNameDependencyProperty, value); }
        }
        protected virtual void OnTableNameChanged(DependencyPropertyChangedEventArgs e)
        {
            _tableName = e.NewValue as string;
        }
        #endregion
        #region DataField

        public static DependencyProperty DataFieldDependencyProperty =
            DependencyProperty.Register(
                "DataField",
                typeof(string),
                typeof(DataCombox),
                new PropertyMetadata(string.Empty, OnDataFieldChanged));

        public string DataField
        {
            get { return (string)GetValue(DataFieldDependencyProperty); }
            set { SetValue(DataFieldDependencyProperty, value); }
        }
        private static void OnDataFieldChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DataCombox controlDataRadio)
            {
                controlDataRadio.OnPropertyChanged("DataField");
                controlDataRadio.OnDataFieldPropertyChanged(e);
            }
        }
        private void OnDataFieldPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            _dataField = e.NewValue as string;
            if (_itemSource != null)
            {
                if (!string.IsNullOrEmpty(_dataField))
                {
                    DataColumnCollection collection = _itemSource.Columns;
                    if (collection.Contains(_dataField))
                    {
                        ComponentFiller componentFiller = new ComponentFiller();
                        componentFiller.FillComboxBox(_itemSource, _dataField, ref KarveComboBox);
                    }
                }
            }
        }
        #endregion

        #region Description

        public static readonly DependencyProperty DescriptionDependencyProperty =
            DependencyProperty.Register(
                "Description",
                typeof(string),
                typeof(DataCombox),
                new PropertyMetadata(String.Empty));

        #endregion

        #region DataAllowed

        public static readonly DependencyProperty DataAllowedDependencyProperty =
            DependencyProperty.Register(
                "DataAllowed",
                typeof(DataType),
                typeof(DataCombox),
                new PropertyMetadata(DataType.Any, OnDataAllowedChange));

        public DataType DataAllowed
        {
            get { return (DataType)GetValue(DataAllowedDependencyProperty); }
            set { SetValue(DataAllowedDependencyProperty, value); }
        }

        private static void OnDataAllowedChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataCombox control = d as DataCombox;
            if (control != null)
            {
                control.OnPropertyChanged("DataAllowed");
                control.OnDataAllowedChange(e);
            }
        }
        protected virtual void OnDataAllowedChange(DependencyPropertyChangedEventArgs e)
        {
            DataType type = (DataType) Enum.Parse(typeof(DataType), e.NewValue.ToString());
            _dataAllowed = type;
        }

        #endregion
        
        #region LabelVisible

        public static readonly DependencyProperty LabelVisibleDependencyProperty =
            DependencyProperty.Register("LabelVisible",
                typeof(bool),
                typeof(DataCombox),
                new PropertyMetadata(false, OnLabelVisibleChange));

        public bool LabelVisible
        {
            get { return (bool)GetValue(LabelVisibleDependencyProperty); }
            set { SetValue(LabelVisibleDependencyProperty, value); }
        }

        private static void OnLabelVisibleChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataCombox control = d as DataCombox;
            if (control != null)
            {
                control.OnPropertyChanged("LabelVisible");
                control.OnLabelVisibleChanged(e);
            }
        }
        
        private void OnLabelVisibleChanged(DependencyPropertyChangedEventArgs e)
        {
            bool value = Convert.ToBoolean(e.NewValue);
            if (value)
            {
                
                this.LabelField.Visibility = Visibility.Visible;
            }
            else
            {
                this.LabelField.Visibility = Visibility.Hidden;
            }
        }
        #endregion
        #region LabelText
        public static readonly DependencyProperty LabelTextDependencyProperty =
            DependencyProperty.Register(
                "LabelText",
                typeof(string),
                typeof(DataCombox),
                new PropertyMetadata(string.Empty, OnLabelTextChange));

        public string LabelText
        {
            get { return (string)GetValue(LabelTextDependencyProperty); }
            set { SetValue(LabelTextDependencyProperty, value); }
        }
        private static void OnLabelTextChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataCombox control = d as DataCombox;
            if (control != null)
            {
                control.OnPropertyChanged("LabelText");
                control.OnLabelTextChanged(e);
            }
        }
        private void OnLabelTextChanged(DependencyPropertyChangedEventArgs e)
        {
            string label = e.NewValue as string;
            this.LabelField.Text = label;
        }
        #endregion
        #region LabelTextWidth 
        public readonly static DependencyProperty LabelTextWidthDependencyProperty =
            DependencyProperty.Register(
                "LabelTextWidth",
                typeof(string),
                typeof(DataCombox),
                new PropertyMetadata(string.Empty, OnLabelTextWidthChange));

        public string LabelTextWidth
        {
            get { return (string)GetValue(LabelTextWidthDependencyProperty); }
            set { SetValue(LabelTextWidthDependencyProperty, value); }
        }
        private static void OnLabelTextWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataCombox control = d as DataCombox;
            if (control != null)
            {
                control.OnPropertyChanged("LabelTextWidth");
                control.OnLabelTextWidthChanged(e);
            }
        }

        private void OnLabelTextWidthChanged(DependencyPropertyChangedEventArgs e)
        {
            double value = Convert.ToDouble(e.NewValue);
            LabelField.Width = value;
        }

        #endregion

        #region ContentWidth

        public string ContentWidth
        {
            get { return (string)GetValue(ContentWidthDependencyProperty); }
            set { SetValue(ContentWidthDependencyProperty, value); }
        }

        public readonly static DependencyProperty ContentWidthDependencyProperty =
            DependencyProperty.Register(
                "ContentWidth",
                typeof(string),
                typeof(DataCombox), new PropertyMetadata(string.Empty, OnContentWidthChange));

        private static void OnContentWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataCombox control = d as DataCombox;
            if (control != null)
            {
                control.OnPropertyChanged("ContentWidth");
                control.OnTextContentWidthPropertyChanged(e);
            }
        }
        private void OnTextContentWidthPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            string tmpValue = e.NewValue as string;
            double valueName = Convert.ToDouble(tmpValue);
            KarveComboBox.Width = valueName;
        }
        #endregion


        #region DataFieldHeight 
        public readonly static DependencyProperty DataFieldHeightDependencyProperty =
            DependencyProperty.Register(
                "DataFieldHeight",
                typeof(string),
                typeof(DataCombox),
                new PropertyMetadata("40", OnDataFieldHeightChange));

        public string DataFieldHeight
        {
            get { return (string)GetValue(DataFieldHeightDependencyProperty); }
            set { SetValue(DataFieldHeightDependencyProperty, value); }
        }
        private static void OnDataFieldHeightChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataCombox control = d as DataCombox;
            if (control != null)
            {
                control.OnPropertyChanged("DataFieldHeight");
                control.OnDataFieldHeightChanged(e);
            }
        }

        private void OnDataFieldHeightChanged(DependencyPropertyChangedEventArgs e)
        {
            double value = Convert.ToDouble(e.NewValue);
            LabelField.Height = value;
            KarveComboBox.Height = value;
        }

        #endregion

        public ObservableCollection<string> CurrentItems
        {
            get
            {   
                return (ObservableCollection<string>) GetValue(ItemsDependencyProperty);
            }
            set
            {
                SetValue(ItemsDependencyProperty, value);
            }
        }
        

    }
}
