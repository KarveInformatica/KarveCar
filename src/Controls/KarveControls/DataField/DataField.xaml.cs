using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using KarveControls.Generic;

namespace KarveControls
{
    /// <summary>
    /// DataField Control definitions.
    /// </summary>
    public partial class DataField : UserControl
    {
        /// <summary>
        /// Routed Event fired when any change in data field happen.
        /// </summary>
        public static readonly RoutedEvent DataFieldChangedEvent =
            EventManager.RegisterRoutedEvent(
                "DataFieldChanged",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(DataField));

        /// <summary>
        ///  Event triggered when a data field changes.
        /// </summary>
        public event RoutedEventHandler DataFieldChanged
        {
            add { AddHandler(DataFieldChangedEvent, value); }
            remove { RemoveHandler(DataFieldChangedEvent, value); }
        }

        #region CommonPart
        /// <summary>
        ///  It is true if the text content has been changed.
        /// </summary>
        private bool _textContentChanged = false;
        /// <summary>
        /// Data Table to be used.
        /// </summary>
        private object _itemSource;
        /// <summary>
        /// Data object to be used.
        /// </summary>
        private object _dataObject;
        /// <summary>
        /// Component filler to be used.
        /// </summary>
        private readonly ComponentFiller _filler = new ComponentFiller();
        /// <summary>
        /// Field empty to be used.
        /// </summary>
        private string _dataField = string.Empty;
      

        #region Description
        /// <summary>
        ///  Component description.
        /// </summary>
        public static readonly DependencyProperty DescriptionDependencyProperty =
            DependencyProperty.Register(
                "Description",
                typeof(string),
                typeof(DataField),
                new PropertyMetadata(String.Empty));

        #endregion
        /// <summary>
        ///  Database primary key
        /// </summary>
        #region PrimaryKey
        public static readonly DependencyProperty PrimaryKeyDependencyProperty = 
            DependencyProperty.Register("PrimaryKey", 
                typeof(object),
                typeof(DataField), 
                new PropertyMetadata(null)
                );
        #endregion

        /// <summary>
        /// Data object dependency properties.
        /// </summary>
        public static readonly DependencyProperty DataObjectDependencyProperty =
            DependencyProperty.Register("DataObject", typeof(object), typeof(DataField), new PropertyMetadata(null, OnItemSourceDoChanged));
        /// <summary>
        ///  This returns a data object.
        /// </summary>
        public object DataObject
        {
            get { return GetValue(DataObjectDependencyProperty); }
            set { SetValue(DataObjectDependencyProperty, value); }
        }

        /// <summary>
        /// Data object dependency properties.
        /// </summary>
        public static readonly DependencyProperty DataAllowedDependencyProperty =
            DependencyProperty.Register("DataAllowed", typeof(ControlExt.DataType), typeof(DataField), new PropertyMetadata(ControlExt.DataType.Any, OnDataAllowedChanged));

        private static void OnDataAllowedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataField data = d as DataField;
            data?.OnDataAllowedChanged(e);
        }

        private void OnDataAllowedChanged(DependencyPropertyChangedEventArgs e)
        {
            ControlExt.DataType dataType = (ControlExt.DataType)e.NewValue;
           
        }

        #region
        /// <summary>
        /// DataAllowed.
        /// </summary>
        public ControlExt.DataType DataAllowed
        {
            get { return (ControlExt.DataType)GetValue(DataAllowedDependencyProperty); }
            set { SetValue(DataAllowedDependencyProperty, value); }
        }
        #endregion
        #region ItemSource
        /// <summary>
        ///  Item Source. DataTable to be binded with this component.
        /// </summary>
        public static DependencyProperty ItemSourceDependencyProperty
            = DependencyProperty.Register(
                "ItemSource",
                typeof(object),
                typeof(DataField),
                new PropertyMetadata(null, OnItemSourceChanged));
        /// <summary>
        ///  Item Source. DataTable to be binded with this
        /// </summary>
        public object ItemSource
        {
            get { return GetValue(ItemSourceDependencyProperty); }
            set { SetValue(ItemSourceDependencyProperty, value); }
        }

        private static void OnItemSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataField control = d as DataField;
            if (control != null)
            {
                control.OnItemSourceChanged(e);
            }
        }
        /// <summary>
        /// Call back for each change.
        /// </summary>
        /// <param name="d">Dependency Object to be used.</param>
        /// <param name="e">Event triggered by the change/</param>
        private static void OnItemSourceDoChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataField control = d as DataField;
            if (control != null)
            {
                control.OnItemSourceDoChanged(e);
            }
        }

        /// <summary>
        /// This handle the logic for changing the depedency object using a data object.
        /// </summary>
        /// <param name="e"></param>
        private void OnItemSourceDoChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null)
            {
                return;
            }
            if (string.IsNullOrEmpty(_dataField))
                return;

            _dataObject = e.NewValue;
           
            Type dataType = _dataObject.GetType();
            object valueObject = dataType.GetProperty("Value");
            if (valueObject != null)
            {
                string currentValue = "Value." + DataSourcePath.ToUpper();
                object value = ComponentUtils.GetPropValue(_dataObject, currentValue);
                if (value != null)
                {
                    string objectValue = value.ToString();
                    if (DataAllowed == ControlExt.DataType.Email)
                    {
                        objectValue = objectValue.Replace("#", "@");
                    }
                    if (!string.IsNullOrEmpty(objectValue))
                    {
                        TextContent = objectValue;
                    }
                    if (IsReadOnly)
                    {
                        TextField.Background = Brushes.LightCyan;
                    }
                    else
                    {
                        TextField.Background = Brushes.White;
                    }

                }

            }
        }

        /// <summary>
        ///  Call back after the change of the property item source
        /// </summary>
        /// <param name="e">Event to be handled</param>
        protected virtual void OnItemSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null)
                return;

            if (string.IsNullOrEmpty(_dataField))
                return;

            object objectValue = e.NewValue;
            if (objectValue is DataTable)
            {

                DataTable table = e.NewValue as DataTable;

                this._itemSource = table;
                if (!string.IsNullOrEmpty(_dataField))
                {
                    if (table != null)
                    {
                        DataColumnCollection collection = table.Columns;
                        if (collection.Contains(_dataField))
                        {
                            DataRow dataRow = table.Rows[0];
                            string colName = _dataField;
                            string value = _filler.FetchDataFieldValue(table, _dataField);
                            if (DataAllowed == ControlExt.DataType.Email)
                            {
                                value = value.Replace("#", "@");
                            }
                            TextContent = value;
                            if (IsReadOnly)
                            {
                                TextField.Background = Brushes.CadetBlue;

                            }
                            else
                            {
                                TextField.Background = Brushes.White;
                            }
                        }
                    }
                }
            }
        }


        #endregion
        #region TableName
        /// <summary>
        ///  Dependency property for the table name.
        /// </summary>
        public static readonly DependencyProperty DBTableNameDependencyProperty =
            DependencyProperty.Register(
                "TableName",
                typeof(string),
                typeof(DataField),
                new PropertyMetadata(string.Empty));
        /// <summary>
        ///  This is a table name dependency property.
        /// </summary>
        public string TableName
        {
            get { return (string)GetValue(DBTableNameDependencyProperty); }
            set { SetValue(DBTableNameDependencyProperty, value); }
        }

        #endregion
        /// <summary>
        /// Command associated to the changed of a property. It gets triggered when a change happens.
        /// </summary>
        public static readonly DependencyProperty ItemChangedCommandDependencyProperty =
            DependencyProperty.Register(
                "ItemChangedCommand",
                typeof(ICommand),
                typeof(DataField), new PropertyMetadata(null));

        /// <summary>
        ///  Command related to the change of an item.
        /// </summary>
        public ICommand ItemChangedCommand
        {
            get { return (ICommand) GetValue(ItemChangedCommandDependencyProperty); }
            set { SetValue(ItemChangedCommandDependencyProperty, value);
            }
        }

        #region UpperCaseChange
        /// <summary>
        ///  Uppercase dependency properties.
        /// </summary>
        public static readonly DependencyProperty UpperCaseDependencyProperty =
            DependencyProperty.Register(
                "UpperCase",
                typeof(bool),
                typeof(DataField),
                new PropertyMetadata(false, OnUpperCaseChange));

        private static void OnUpperCaseChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataField control = d as DataField;
            if (control != null)
            {
                control.OnUpperCaseChanged(e);
            }
        }

        private void OnUpperCaseChanged(DependencyPropertyChangedEventArgs e)
        {
            bool value = Convert.ToBoolean(e.NewValue);
            if (value)
            {
               TextContent = TextField.Text.ToUpper();
            }
        }
        /// <summary>
        ///  UpperCase property.
        /// </summary>
        public bool UpperCase
        {
            get { return (bool)GetValue(UpperCaseDependencyProperty); }
            set { SetValue(UpperCaseDependencyProperty, value); }
        }
        #endregion
        #region IsReadOnly

        public static readonly DependencyProperty IsReadOnlyDependencyProperty =
            DependencyProperty.Register(
                "IsReadOnly",
                typeof(bool),
                typeof(DataField),
                new PropertyMetadata(false, IsReadOnlyDependencyPropertyChange));

        private static void IsReadOnlyDependencyPropertyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataField control = d as DataField;
            if (control != null)
            {
                control.OnIsReadOnlyChanged(e);
            }
        }

        private void OnIsReadOnlyChanged(DependencyPropertyChangedEventArgs e)
        {
            bool value = Convert.ToBoolean(e.NewValue);
            if (value)
            {
                this.TextField.IsReadOnly = value;
            }
        }

        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyDependencyProperty); }
            set { SetValue(IsReadOnlyDependencyProperty, value); }
        }
        #endregion
        #region DataField

        public static DependencyProperty DataFieldDependencyProperty =
            DependencyProperty.Register(
                "DataSourcePath",
                typeof(string),
                typeof(DataField),
                new PropertyMetadata(string.Empty, DataFieldPropertyChanged));

        private static void DataFieldPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataField dataField = d as DataField;
            dataField.OnDataFieldPropertyChanged(e);
        }
        /// <summary>
        ///  Path of the data.
        /// </summary>
        public string DataSourcePath
        {
            get { return (string)GetValue(DataFieldDependencyProperty); }
            set { SetValue(DataFieldDependencyProperty, value); }
        }

       

        /// <summary>
        /// This data field property.
        /// </summary>
        /// <param name="e">Dependency Property parameter.</param>
        public void OnDataFieldPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            _dataField = e.NewValue as string;
            if (_dataObject != null)
            {
                TextContent= ComponentUtils.GetTextDo(this.DataObject, _dataField, DataAllowed);
            }
            DataTable itemSource = _itemSource as DataTable;
            if (itemSource != null)
            {
                if (!string.IsNullOrEmpty(_dataField))
                {
                    DataColumnCollection collection = itemSource.Columns;
                    if (collection.Contains(_dataField))
                    {
                        string value = _filler.FetchDataFieldValue(itemSource, _dataField);
                        if (!string.IsNullOrEmpty(value))
                        {
                            if (DataAllowed == ControlExt.DataType.Email)
                            {
                                value = value.Replace("#", "@");
                            }
                            TextContent = value;
                        }
                    }
                }
            }
        }
        #endregion
        #endregion
        #region AllowedEmpty
        public static readonly DependencyProperty AllowedEmptyDependencyProperty =
            DependencyProperty.Register(
                "AllowedEmpty",
                typeof(bool),
                typeof(DataField),
                new PropertyMetadata(false));
        /// <summary>
        ///  AllowedEmpty dependency property.
        /// </summary>
        public bool AllowedEmpty
        {
            get { return (bool)GetValue(AllowedEmptyDependencyProperty); }
            set { SetValue(AllowedEmptyDependencyProperty, value); }
        }

        #endregion

        #region TextContent Property
        public static readonly DependencyProperty TextContentDependencyProperty =
            DependencyProperty.Register(
                "TextContent",
                typeof(string),
                typeof(DataField),
                new PropertyMetadata(string.Empty, OnTextContentChange));
       
        /// <summary>
        /// TextContent. This is the content of the text.
        /// </summary>
        public string TextContent
        {
            get { return (string)GetValue(TextContentDependencyProperty); }
            set { SetValue(TextContentDependencyProperty, value); }
        }


        private static void OnTextContentChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataField control = d as DataField;
            if (control != null)
            {
                control.OnTextContentPropertyChanged(e);
            }
        }

        private void OnTextContentPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            // type validation is missing here.
            string value = e.NewValue as string;
            this.TextField.Text = value;
            if ((_itemSource!=null) && (!String.IsNullOrEmpty(this._dataField)))
            {
                if (!string.IsNullOrEmpty(value))
                {
                    // here we go.
                   string tmpValue = value;
                    if (DataAllowed == ControlExt.DataType.Email)
                    {
                        tmpValue = value.Replace("@", "#");
                    }
                    DataTable itemSource = (DataTable) _itemSource;
                    itemSource.Rows[0][_dataField] = tmpValue;
                }
            }
            if ((_dataObject != null) && 
                (!String.IsNullOrEmpty(this._dataField)))
            {
                // ok now we set the value
             //  _filler.FillDataObject(value,DataSourcePath,ref _dataObject);
            }
        }
        #endregion
        #region LabelVisible
        /// <summary>
        /// Dependency property for the label visibility.
        /// </summary>
        public static readonly DependencyProperty LabelVisibleDependencyProperty =
            DependencyProperty.Register("LabelVisible",
                typeof(bool),
                typeof(DataField),
                new PropertyMetadata(false, OnLabelVisibleChange));

        /// <summary>
        ///  Property to set the label visible for a data field.
        /// </summary>
        public bool LabelVisible
        {
            get { return (bool)GetValue(LabelVisibleDependencyProperty); }
            set { SetValue(LabelVisibleDependencyProperty, value); }
        }

        private static void OnLabelVisibleChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataField control = d as DataField;
            if (control != null)
            {
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
                this.LabelField.Visibility = Visibility.Collapsed;
            }
        }
        #endregion
        #region LabelText
        public static readonly DependencyProperty LabelTextDependencyProperty =
            DependencyProperty.Register(
                "LabelText",
                typeof(string),
                typeof(DataField),
                new PropertyMetadata(string.Empty, OnLabelTextChange));
        /// <summary>
        ///  Label text dependency property.
        /// </summary>
        public string LabelText
        {
            get { return (string)GetValue(LabelTextDependencyProperty); }
            set { SetValue(LabelTextDependencyProperty, value); }
        }
        private static void OnLabelTextChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataField control = d as DataField;
            if (control != null)
            {
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
                typeof(DataField),
                new PropertyMetadata(string.Empty, OnLabelTextWidthChange));
        /// <summary>
        /// Width of the label text.
        /// </summary>
        public string LabelTextWidth
        {
            get { return (string)GetValue(LabelTextWidthDependencyProperty); }
            set { SetValue(LabelTextWidthDependencyProperty, value); }
        }
        private static void OnLabelTextWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataField control = d as DataField;
            if (control != null)
            {
                control.OnLabelTextWidthChanged(e);
            }
        }

        private void OnLabelTextWidthChanged(DependencyPropertyChangedEventArgs e)
        {
            double value = Convert.ToDouble(e.NewValue);
            LabelField.Width = value;
        }

        #endregion
      
        #region TextContentWidth

        public string TextContentWidth
        {
            get { return (string)GetValue(TextContentWidthDependencyProperty); }
            set {  SetValue(TextContentWidthDependencyProperty, value); }
        }

        public static readonly DependencyProperty TextContentWidthDependencyProperty =
            DependencyProperty.Register(
                "TextContentWidth",
                typeof(string),
                typeof(DataField), new PropertyMetadata(string.Empty, OnTextContentWidthChange));

        private static void OnTextContentWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataField control = d as DataField;
            if (control != null)
            {
                control.OnTextContentWidthPropertyChanged(e);
            }
        }
        private void OnTextContentWidthPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            string tmpValue = e.NewValue as string;
            double valueName = Convert.ToDouble(tmpValue);
            TextField.Width = valueName;
        }
        #endregion


        #region DataFieldHeight 
        public static readonly DependencyProperty DataFieldHeightDependencyProperty =
            DependencyProperty.Register(
                "DataFieldHeight",
                typeof(string),
                typeof(DataField),
                new PropertyMetadata("40", OnDataFieldHeightChange));
        /// <summary>
        /// Height of the datafield textbox.
        /// </summary>
        public string DataFieldHeight
        {
            get { return (string)GetValue(DataFieldHeightDependencyProperty); }
            set { SetValue(DataFieldHeightDependencyProperty, value); }
        }
        private static void OnDataFieldHeightChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataField control = d as DataField;
            if (control != null)
            {
                control.OnDataFieldHeightChanged(e);
            }
        }

        private void OnDataFieldHeightChanged(DependencyPropertyChangedEventArgs e)
        {
            double value = Convert.ToDouble(e.NewValue);
            LabelField.Height = value;
            TextField.Height = value;
        }

        #endregion
        /// <summary>
        ///  Constant for changed value index
        ///  TODO: See where they are used and move from here.
        /// </summary>
        public static string CHANGED_VALUE = "ChangedValue";
        /// <summary>
        ///  Constant for the field value.
        /// </summary>
        public static string FIELD = "Field";
        /// <summary>
        ///  Constant for the field data table
        /// </summary>
        public static string DATATABLE = "DataTable";
        /// <summary>
        ///  Constant for the table name field.
        /// </summary>
        public static string TABLENAME = "TableName";
        /// <summary>
        /// Constant for the data object.
        /// </summary>
        public static string DATAOBJECT = "DataObject";
        /// <summary>
        ///  Simple field with associated the database field. 
        /// This is pretty useful for creating automagically the query to send to the data layer and bind the data.
        /// </summary>
        public DataField()
        {

            Stopwatch startStopWatch = new Stopwatch();
            startStopWatch.Start();
            InitializeComponent();
            this.TextContentWidth = "100";
            this.LabelTextWidth = "50";
            this.Height = 25;
            LabelVisible = true;
            TextField.IsReadOnly = false;
            TextField.TextChanged += TextField_TextChanged;
            TextField.GotFocus += TextField_GotFocus;
            GotFocus += DataField_GotFocus;
            LostFocus += DataField_LostFocus;
            DataFieldContent.DataContext = this;
            startStopWatch.Stop();
            long value = startStopWatch.ElapsedMilliseconds;
        }

        private void TextField_TextChanged(object sender, TextChangedEventArgs e)
        {
            _textContentChanged = true;
            RaiseEvent(e);
        }

        private void DataField_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((TextField.Text.Length > 0) && (_textContentChanged))
            {
                DataFieldEventArgs ev = new DataFieldEventArgs(DataFieldChangedEvent)
                {
                    FieldData = TextField.Text
                };
                IDictionary<string, object> valueDictionary = new Dictionary<string, object>
                {
                    [TABLENAME] = TableName,
                    [FIELD] = DataSourcePath,
                    [DATATABLE] = ItemSource,
                    [CHANGED_VALUE] = TextField.Text
                };
                _filler.FillDataObject(TextField.Text, DataSourcePath, ref _dataObject);
                DataObject = _dataObject;
                valueDictionary[DATAOBJECT] = DataObject;
                ev.ChangedValuesObjects = valueDictionary;
                if (this.ItemChangedCommand != null)
                {
                    if (ItemChangedCommand.CanExecute(valueDictionary))
                    {
                           ItemChangedCommand.Execute(valueDictionary);
                    }
                }
                else
                {
                    RaiseEvent(ev);
                }
                _textContentChanged = false;
            }
        }

        private void TextField_GotFocus(object sender, RoutedEventArgs e)
        {
            _textContentChanged = false;
            this.TextField.SelectAll();
            RaiseEvent(e);
        }

        private void DataField_GotFocus(object sender, RoutedEventArgs e)
        {
            TextField.Focus();
        }
    }
}
