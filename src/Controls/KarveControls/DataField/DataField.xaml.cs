using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using KarveControls.Generic;
using static KarveControls.CommonControl;

namespace KarveControls
{
    /// <summary>
    /// DataField Component Definition.
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

        private bool _textContentChanged = false;
        /// <summary>
        ///  Event triggered when a data field changes.
        /// </summary>
        public event RoutedEventHandler DataFieldChanged
        {
            add { AddHandler(DataFieldChangedEvent, value); }
            remove { RemoveHandler(DataFieldChangedEvent, value); }
        }

        #region CommonPart


        private object _itemSource;
        private readonly ComponentFiller _filler = new ComponentFiller();
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

        #region DataAllowed
        /// <summary>
        ///  Kind of data allowed in this component.
        /// </summary>
        public static readonly DependencyProperty DataAllowedDependencyProperty =
            DependencyProperty.Register(
                "DataAllowed",
                typeof(DataType),
                typeof(DataField),
                new PropertyMetadata(DataType.Any));
        
        /// <summary>
        ///  DataType allowed in this component.
        /// </summary>
        public DataType DataAllowed
        {
            get { return (DataType) GetValue(DataAllowedDependencyProperty); }
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
        ///  Item Source. DataTable to be binded with this component.
        /// </summary>
        public DataTable ItemSource
        {
            get { return (DataTable) GetValue(ItemSourceDependencyProperty); }
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
        /// This handle the logic for changing the depedency object using a data object.
        /// </summary>
        /// <param name="e"></param>
        private void OnItemSourceDoChanged(DependencyPropertyChangedEventArgs e)
        {
            object dataObject = e.NewValue;
            Type dataType = dataObject.GetType();
            // now with the reflection we get the field.
            PropertyInfo info = dataType.GetProperty(DBField);
            // ok we get the field to be used and changed
            if (info != null)
            {
                string value = info.GetValue(dataObject) as string;
                // since internally we have problems with email. 
                if ((value != null) && (DataAllowed == DataType.Email))
                {
                    value = value.Replace("#", "@");
                }
                TextField.Text = value;
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
                            if (DataAllowed == DataType.Email)
                            {
                                value = value.Replace("#", "@");
                            }
                            TextField.Text = value;
                            TextField.Visibility = Visibility.Visible;
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
            else
            {
                // ok it is an object
                 OnItemSourceDoChanged(e);
            }
        }


        #endregion
        #region TableName
        public static readonly DependencyProperty DBTableNameDependencyProperty =
            DependencyProperty.Register(
                "TableName",
                typeof(string),
                typeof(DataField),
                new PropertyMetadata(string.Empty));
        public string TableName
        {
            get { return (string)GetValue(DBTableNameDependencyProperty); }
            set { SetValue(DBTableNameDependencyProperty, value); }
        }

        #endregion
        /// <summary>
        /// Command associated to the changed of a property. It gets triggered when a change happens.
        /// </summary>
        public static DependencyProperty ItemChangedCommandDependencyProperty =
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
               TextField.Text = TextField.Text.ToUpper();
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
                "DBField",
                typeof(string),
                typeof(DataField),
                new PropertyMetadata(string.Empty, DataFieldPropertyChanged));

        private static void DataFieldPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataField dataField = d as DataField;
            dataField.OnDataFieldPropertyChanged(e);
        }

        public string DBField
        {
            get { return (string)GetValue(DataFieldDependencyProperty); }
            set { SetValue(DataFieldDependencyProperty, value); }
        }

        private int valuePass = 0;
        /// <summary>
        /// This data field property.
        /// </summary>
        /// <param name="e"></param>
        public void OnDataFieldPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            _dataField = e.NewValue as string;
            valuePass++;
            if (this._itemSource != null)
            {
                DataTable itemSource = _itemSource as DataTable;
                if (!string.IsNullOrEmpty(_dataField))
                {
                        DataColumnCollection collection = itemSource.Columns;
                        if (collection.Contains(_dataField))
                        {
                            string value = _filler.FetchDataFieldValue(itemSource, _dataField);
                            if (!string.IsNullOrEmpty(value))
                            {
                                if (DataAllowed == DataType.Email)
                                {
                                    value = value.Replace("#", "@");
                                }
                                TextContent = value;
                                //  BindingOperations.ClearBinding(this.TextField, TextBox.TextProperty);
                                // TODO adding the right validation rule for the stuff.
                                // SetDynamicBinding(ref _itemSource, null);
                                // TextField.Text = dataRow[colName] as string;
                                TextField.Visibility = Visibility.Visible;
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
                    if (DataAllowed == DataType.Email)
                    {
                        tmpValue = value.Replace("@", "#");
                    }
                    DataTable itemSource = (DataTable) _itemSource;
                    itemSource.Rows[0][_dataField] = tmpValue;
                }
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
                this.LabelField.Visibility = Visibility.Hidden;
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
        ///  Simple field with associated the database field. 
        /// This is pretty useful for creating automagically the query to send to the data layer and bind the data.
        /// </summary>
        public DataField()
        {
            InitializeComponent();
            LabelVisible = true;
            TextField.IsReadOnly = false;
            TextField.TextChanged += TextField_TextChanged;
            TextField.GotFocus += TextField_GotFocus;
            GotFocus += DataField_GotFocus;
            LostFocus += DataField_LostFocus;
            DataFieldContent.DataContext = this;
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
                    DataFieldEventArgs ev = new DataFieldEventArgs(DataFieldChangedEvent);
                    ev.FieldData = TextField.Text;
                    IDictionary<string, object> valueDictionary = new Dictionary<string, object>();
                    valueDictionary["TableName"] = TableName;
                    valueDictionary["Field"] = DBField;
                    valueDictionary["DataTable"] = ItemSource;
                    valueDictionary["ChangedValue"] = TextField.Text;
                    ev.ChangedValuesObjects = valueDictionary;
                if (this.ItemChangedCommand != null)
                {
                    if (ItemChangedCommand.CanExecute(valueDictionary))
                    {
                        ItemChangedCommand.Execute(valueDictionary);
                    }
                }
                    RaiseEvent(ev);
                }
                _textContentChanged = false;
            
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
