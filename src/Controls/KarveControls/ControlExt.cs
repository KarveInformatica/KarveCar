using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using KarveControls.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using ICommand = System.Windows.Input.ICommand;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using KarveDataServices.ViewObjects;
using System.Linq;
using KarveCommon;
using KarveCommon.Generic;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Controls.Input;
namespace KarveControls
{
   
    /// <summary>
    ///  This is a list of attached properties to be associated to each karve control.
    /// </summary>
    public partial class ControlExt
    {

        private static string _lastTextBoxValue = "";

        public enum GridOp
        {
            /// <summary>
            ///  Insert a row
            /// </summary>
            Insert,
            /// <summary>
            ///  Delete a row
            /// </summary>
            Delete,
            /// <summary>
            ///  Update a row.
            /// </summary>
            Update,
            Any
        }

        public const string AssistName = "AssistTable";
        /// <summary>
        ///  Email data type
        /// </summary>
        public static DataType EmailDataType = DataType.Email;
    
       

        public const string AssistTable = "AssistTable";
        public const string DataFieldFirst = "DataFieldFirst";
        public const string DataFieldSecond = "DataFieldSecond";
        public const string AssistFieldFirst = "AssistFieldFirst";
        public const string AssistFieldSecond = "AssistFieldSecond";
        public const string AssistQuery = "AssistQuery";


        public static readonly DependencyProperty PasswordProperty =
        DependencyProperty.RegisterAttached("Password",
        typeof(string), typeof(ControlExt),
        new PropertyMetadata(string.Empty, OnPasswordPropertyChanged));

        private static void OnPasswordPropertyChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            if (passwordBox != null)
            {
                passwordBox.PasswordChanged -= PasswordChanged;

                if (!(bool) GetIsUpdating(passwordBox))
                {
                    passwordBox.Password = (string) e.NewValue;
                    // here the value of the password is changed.
                }

                passwordBox.PasswordChanged += PasswordChanged;
            }
        }

        public static readonly DependencyProperty AttachProperty =
        DependencyProperty.RegisterAttached("Attach",
        typeof(bool), typeof(ControlExt), new PropertyMetadata(false, Attach));

        private static readonly DependencyProperty IsUpdatingProperty =
           DependencyProperty.RegisterAttached("IsUpdating", typeof(bool),
           typeof(ControlExt));


        private static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.RegisterAttached("SelectedItem", typeof(object),
                typeof(ControlExt), new PropertyMetadata(false, SelectedItemCb));

        private static void SelectedItemCb(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var grid = d as SfDataGrid;
            if (!(d is SfDataGrid)) return;
            grid.SelectionChanged -= Grid_SelectionChanged;
            grid.SelectionChanged += Grid_SelectionChanged;
        }

        private static void Grid_SelectionChanged(object sender, GridSelectionChangedEventArgs e)
        {
            if (!(sender is SfDataGrid grid))
            {
                return;
            }
            var selectedItem = grid.SelectedItem;
            SetSelectedItem(grid, selectedItem);
        }

        public static void SetSelectedItem(DependencyObject dp, object value)
        {
            dp.SetValue(SelectedItemProperty, value);

        }
        public static object GetSelectedItem(DependencyObject dp)
        {
            return dp.GetValue(SelectedItemProperty);

        }


        /// <summary>
        ///  Grid operation property.
        /// </summary>
        private static readonly DependencyProperty  GridOperationProperty =
   DependencyProperty.RegisterAttached("GridOperation", typeof(GridOp),
   typeof(ControlExt), new PropertyMetadata(GridOp.Update));

        public static void SetGridOperation(DependencyObject dp, GridOp op)
        {
            dp.SetValue(GridOperationProperty, op);
        }
        public static GridOp GetGridOperation(DependencyObject dp)
        {
            return (GridOp)dp.GetValue(GridOperationProperty);
        }
        public static void SetAttach(DependencyObject dp, bool value)
        {
            dp.SetValue(AttachProperty, value);
        }

        public static bool GetAttach(DependencyObject dp)
        {
            return (bool)dp.GetValue(AttachProperty);
        }

        public static string GetPassword(DependencyObject dp)
        {
            return (string)dp.GetValue(PasswordProperty);
        }

        public static void SetPassword(DependencyObject dp, string value)
        {
            dp.SetValue(PasswordProperty, value);
        }

        private static bool GetIsUpdating(DependencyObject dp)
        {
            return (bool)dp.GetValue(IsUpdatingProperty);
        }

        private static void SetIsUpdating(DependencyObject dp, bool value)
        {
            dp.SetValue(IsUpdatingProperty, value);
        }
        private static void Attach(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is PasswordBox passwordBox))
                return;

            if ((bool)e.OldValue)
            {
                passwordBox.PasswordChanged -= PasswordChanged;
            }

            if ((bool)e.NewValue)
            {
                passwordBox.PasswordChanged += PasswordChanged;
            }
        }

        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            SetIsUpdating(passwordBox, true);
            SetPassword(passwordBox, passwordBox.Password);
            SetIsUpdating(passwordBox, false);
            // noww we call.
            var command = passwordBox.GetValue(ItemChangedCommandProperty) as ICommand;
            if (command != null)
            {
                IDictionary<string, object> objectName = new Dictionary<string, object>();
                objectName["DataObject"] = GetDataSource(passwordBox);
                objectName["DataSourcePath"] = GetDataSourcePath(passwordBox);
                objectName["ChangedValue"] =  passwordBox.Password;
                objectName["PreviousValue"] = _lastPassBoxValue;
                _lastPassBoxValue = passwordBox.Password;
                command.Execute(objectName);
            }


        }

        #region Description
        /// <summary>
        ///  This is a metadata that describe a component.
        /// </summary>
        public static readonly DependencyProperty DescriptionDependencyProperty =
            DependencyProperty.RegisterAttached(
                "Description",
                typeof(string),
                typeof(ControlExt),
                new PropertyMetadata(String.Empty));
        #endregion


        #region ItemChangedCommand
        /// <summary>
        ///  This is the kind of data allowd.
        /// </summary>
        public static readonly DependencyProperty ItemChangedCommandProperty =
            DependencyProperty.RegisterAttached(
                "ItemChangedCommand",
                typeof(ICommand),
                typeof(ControlExt),
                new FrameworkPropertyMetadata(null, PropertyChangedCb));

        /// <summary>
        ///  Set the item changed command, Attached behaviour for the component.
        /// </summary>
        /// <param name="ext">User Interface to be used</param>
        /// <param name="command">Command to be used</param>
        public static void SetItemChangedCommand(UIElement ext, ICommand command)
        {
            ext.SetValue(ItemChangedCommandProperty,command);
        }
        /// <summary>
        ///  Get item changed command.
        /// </summary>
        /// <param name="ext">Command Value</param>
        /// <returns></returns>
        public static ICommand GetItemChangedCommand(UIElement ext)
        {
            return ext.GetValue(ItemChangedCommandProperty) as ICommand;
        }
        /// <summary>
        ///  This is a property changed util.
        /// </summary>
        /// <param name="dependencyObject"></param>
        /// <param name="eventArgs"></param>
        public static void PropertyChangedCb(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {

            // dry : the change is handled by the PasswordBox properties as well.
            if (dependencyObject is PasswordBox)
            {
                return;
            }
            if (dependencyObject is PercentTextBox)
            {
                PercentTextBox box = dependencyObject as PercentTextBox;
                box.LostFocus += Box_LostFocus1;
                return;
            }
            if (dependencyObject is SfDataGrid currentDataGrid)
            {
                //  currentDataGrid.CurrentCellEndEdit += CurrentDataGrid_CurrentCellEndEdit;
                currentDataGrid.RecordDeleted += CurrentDataGrid_RecordDeleted;
                currentDataGrid.AddNewRowInitiating += CurrentDataGrid_AddNewRowInitiating;
               
                currentDataGrid.RowValidated += CurrentDataGrid_RowValidated;
                currentDataGrid.PreviewKeyDown += CurrentDataGrid_PreviewKeyDown;
            }
            if (dependencyObject is DataArea)
            {
                var dataArea = dependencyObject as DataArea;
                dataArea.ItemChangedCommand = GetItemChangedCommand(dataArea);
                dataArea.DataSource = GetDataSource(dataArea);
                dataArea.DataSourcePath = GetDataSourcePath(dataArea);
                return;
            }
            if (dependencyObject is SfTimePicker)
            {
                SfTimePicker picker = dependencyObject as SfTimePicker;
                picker.ValueChanged += Picker_ValueChanged;
              
            }
            if (dependencyObject is DatePicker datePicker)
            {
                datePicker.SelectedDateChanged += SelectedDate_Changed;
            }
            if (dependencyObject is DataDatePicker)
            {
                DataDatePicker dataDatePicker = dependencyObject as DataDatePicker;
                dataDatePicker.DataDatePickerChanged += DataDatePicker_DataDatePickerChanged;
                return;
            }
            
            if (dependencyObject is TextBox)
            {
                TextBox box = dependencyObject as TextBox;
                box.TextChanged += TextBox_ChangedBehaviour;
                box.LostFocus += Box_LostFocus;
                return;
            }
            if (dependencyObject is DataFieldCheckBox)
            {
                DataFieldCheckBox checkBox = dependencyObject as DataFieldCheckBox;
                var path = ControlExt.GetDataSourcePath(checkBox);
                if (!string.IsNullOrEmpty(path))
                {
                    var tmp = ControlExt.GetDataSource(checkBox);
                    if (tmp != null)
                    {
                        var propValue = ComponentUtils.GetPropValue(tmp, path);
                        if (propValue is string)
                        {
                            byte value = Convert.ToByte(propValue);
                            if (value > 0)
                            {
                                checkBox.IsChecked = true;
                            }
                        }
                        else
                        {
                            checkBox.IsChecked = Convert.ToBoolean(propValue);
                        }
                        
                    }
                    
                }
                 //checkBox.Checked += CheckBox_DataChecked;
                 // checkBox.Unchecked += CheckBox_DataUnChecked;
                 checkBox.DataFieldCheckBoxChanged += CheckBox_DataFieldCheckBoxChanged;
                return;
            }
            if (dependencyObject is CheckBox checkBox1)
            {
                checkBox1.Checked += CheckBox_Checked;
                checkBox1.Unchecked += CheckBox_Unchecked;
                checkBox1.Click += checkBox_Clicked;
                return;
            }
            if (dependencyObject is ComboBox comboBox)
            {
                // here we do the combox box.
                comboBox.SelectionChanged += ComboBox_SelectionChanged;
            }
        }

       

        private static void CurrentDataGrid_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            object dataValue = null;
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                if (sender is SfDataGrid dataGrid)
                {
                    DependencyObject dependencyObject = sender as DependencyObject;
                    var command = dataGrid?.GetValue(ItemChangedCommandProperty) as ICommand;
                    List<object> value = new List<object>();
                    if ((command != null) && (dataGrid != null))
                    {
                        dataValue = dataGrid.SelectedItem;
                        var rowState = GetGridOperation(dependencyObject);
                        if (dataValue != null)
                        {
                            BaseViewObject viewObject = dataValue as BaseViewObject;
                            if (viewObject != null)
                            {
                                viewObject.LastModification = DateTime.Now.ToLongTimeString();
                                if (!viewObject.IsNew)
                                {
                                    viewObject.IsNew = (rowState == GridOp.Insert) ? true : false;

                                }
                                viewObject.IsDirty = true;

                            }
                        }

                        var collection = dataGrid.View.SourceCollection;
                        if (collection is IEnumerable<BaseViewObject> dtoArray)
                        {
                            if (dtoArray.Count() == 0)
                            {
                                return;
                            }
                        }
                        foreach (var c in collection)
                        {
                            BaseViewObject v = c as BaseViewObject;
                            if (v != null)
                            {
                                if (v.IsNew)
                                {
                                    value.Add(c);
                                }
                                else if (v.IsDirty)
                                {
                                    value.Add(c);
                                }
                                else if (v.IsDeleted)
                                {
                                    value.Add(c);
                                }
                            }
                        }

                        IDictionary<string, object> objectName = new Dictionary<string, object>();
                        value.Add(dataValue);
                        objectName["DataObject"] = GetDataSource(dataGrid);
                        objectName["DataSourcePath"] = GetDataSourcePath(dataGrid);
                        objectName["ChangedValue"] = value;
                        objectName["PreviousValue"] = _lastChangedRow;
                        objectName["Operation"] = rowState;
                        objectName["DeletedItems"] = false;
                        objectName["LastRowId"] = dataGrid.GetLastRowIndex();
                        _lastChangedRow = dataValue;
                        command.Execute(objectName);
                        SwitchToUpdate(dependencyObject, rowState);
                    }
                }
            }

        }

        private static void Picker_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var picker = d as SfTimePicker;
            if (picker != null)
            {
                var command = picker.GetValue(ItemChangedCommandProperty) as ICommand;

                if (command != null)
                {

                    var sourceObject = GetDataSource(picker);
                    if (sourceObject != null)
                    {
                        IDictionary<string, object> values = new Dictionary<string, object>();

                        values.Add("DataObject", sourceObject);
                        values.Add("ChangedValue", picker.Value);
                        values.Add("PreviousValue", picker.Value);
                        command.Execute(values);
                    }

                }
            }
        }

        private static void CheckBox_DataChecked(object sender, RoutedEventArgs e)
        {
            var dataFieldCheckBox = sender as DataFieldCheckBox;
            var path = ControlExt.GetDataSourcePath(dataFieldCheckBox);
            if (!string.IsNullOrEmpty(path))
            {
                var tmp = ControlExt.GetDataSource(dataFieldCheckBox);
                if (tmp == null)
                {
                    return;
                }
                var propValue = ComponentUtils.GetPropValue(tmp, path);
                if (dataFieldCheckBox != null)
                {
                    dataFieldCheckBox.IsChecked = true;
                    ControlExt.SetDataSource(dataFieldCheckBox, true);
                    EnforceDoChange(dataFieldCheckBox, path, 1);
                }
            }
        }
        private static void CheckBox_DataUnChecked(object sender, RoutedEventArgs e)
        {
            DataFieldCheckBox dataFieldCheckBox = sender as DataFieldCheckBox;
            var path = ControlExt.GetDataSourcePath(dataFieldCheckBox);
            if (path != null)
            {
                var tmp = ControlExt.GetDataSource(dataFieldCheckBox);
                if (tmp is bool)
                {
                    ControlExt.SetDataSource(dataFieldCheckBox, false);
                    EnforceDoChange(dataFieldCheckBox, path, 0);
                }
            }
        }
        private static void checkBox_Clicked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox!=null)
            {
                if (checkBox.IsChecked.HasValue)
                {
                    checkBox.IsChecked = !checkBox.IsChecked;
                }
                else
                {
                    checkBox.IsChecked = true;
                }
            }
        }
        private static void EnforceDoChange(DependencyObject ds, string fieldName, object valueName)
        {

            if ((valueName != null) && (!string.IsNullOrEmpty(fieldName)))
            {
                var currentObject = GetDataSource(ds);
                string currentValue = string.Empty;
                if (currentObject != null)
                {
                    if (currentObject is BaseViewObject)
                    {
                        // if the object that travels is a data object and not a domain object.
                        currentValue = fieldName.Replace(".Value", "");
                    }
                    else
                    {
                        currentValue = !fieldName.Contains("Value") ? "Value." + fieldName : fieldName;

                    }
                    KarveCommon.ComponentUtils.SetPropValue(currentObject, currentValue, valueName, true);
                }
               // payLoad.DataObject = currentObject;

            }
        }
        private static void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            var command = checkBox?.GetValue(ItemChangedCommandProperty) as ICommand;
           
            if ((command != null) && (checkBox != null))
            {

                var sourceObject = GetDataSource(checkBox);
                if (sourceObject != null)
                {
                    IDictionary<string, object> values = new Dictionary<string, object>();
                   
                    values.Add("DataObject", sourceObject);
                    values.Add("ChangedValue", 0);
                    values.Add("PreviousValue", 1);
                    command.Execute(values);
                }
                 
            }
                
        }

        private static void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            var command = checkBox?.GetValue(ItemChangedCommandProperty) as ICommand;

            if ((command != null) && (checkBox != null))
            {
               
                var sourceObject = GetDataSource(checkBox);
               
                if (sourceObject != null)
                {
                    IDictionary<string, object> values = new Dictionary<string, object>();
                    values.Add("DataObject", sourceObject);
                    values.Add("ChangedValue", 1);
                    values.Add("PreviousValue", 0);
                    command.Execute(values);
                }
            }
        }
        private static void SwitchToUpdate(DependencyObject dependencyObject, GridOp rowState)
        {
            
                SetGridOperation(dependencyObject, GridOp.Update);
            
        }
        /**
         *  The grid insertion or adding, we need to move between two states:
         *  When it gets the event add new row, 
         *  we get the new row event and move the grid operation to insert, 
         *  later when we are in a validation row, we validate the row and that's it.  
         */
        private static void CurrentDataGrid_RowValidated(object sender, RowValidatedEventArgs e)
        {
            SfDataGrid dataGrid = sender as SfDataGrid;
            BaseViewObject viewObject = null;
            DependencyObject dependencyObject = sender as DependencyObject;
            var command = dataGrid?.GetValue(ItemChangedCommandProperty) as ICommand;
            List<object> value = new List<object>();
            if ((command != null) && (dataGrid != null))
            {
                var dataValue = dataGrid.GetRecordAtRowIndex(e.RowIndex);
                var rowState = GetGridOperation(dependencyObject);
                if (dataValue != null)
                {
                    viewObject = dataValue as BaseViewObject;
                    if (viewObject != null)
                    {
                        viewObject.LastModification = DateTime.Now.ToLongTimeString();
                        viewObject.IsNew = (rowState == GridOp.Insert) ? true : false;
                        viewObject.IsDirty = true;

                    }
                }
                
                var collection = dataGrid.View.SourceCollection;

                /*
                if (collection is IEnumerable<BaseViewObject> dtoArray)
                {
                    if (viewObject != null)
                    {
                        if (dtoArray.Count() == 0)
                        {
                            dtoArray = dtoArray.Union(new List<BaseViewObject> { viewObject });
                            collection = dtoArray;
                           return;
                        }
                    }
                }*/

                foreach (var c in collection)
                {
                    BaseViewObject v = c as BaseViewObject;
                    if (v != null)
                    {
                        if (v.IsNew)
                        {
                            value.Add(c);
                        }
                        else if (v.IsDirty)
                        {
                            value.Add(c);
                        }
                        else if (v.IsDeleted)
                        {
                            value.Add(c);
                        }
                    }
                }
                
               
                IDictionary<string, object> objectName = new Dictionary<string, object>();
                value.Add(dataValue);
                objectName["DataObject"] = GetDataSource(dataGrid);
                objectName["DataSourcePath"] = GetDataSourcePath(dataGrid);
                objectName["ChangedValue"] = value;
                objectName["PreviousValue"] = _lastChangedRow;
                objectName["Operation"] = rowState;
                objectName["DeletedItems"] = false;
                objectName["LastRowId"] = dataGrid.GetLastRowIndex();
                _lastChangedRow = dataGrid.GetRecordAtRowIndex(e.RowIndex);
                command.Execute(objectName);
                SwitchToUpdate(dependencyObject, rowState);
                
            }
        }

        private static void CurrentDataGrid_AddNewRowInitiating(object sender, AddNewRowInitiatingEventArgs e)
        {
            SfDataGrid dataGrid = sender as SfDataGrid;
            var command = dataGrid?.GetValue(ItemChangedCommandProperty) as ICommand;
            if ((command != null) && (dataGrid !=null))
            {
                DependencyObject dependencyObject = sender as DependencyObject;
                SetGridOperation(dependencyObject, GridOp.Insert);
            }
           
        }

        private static void CurrentDataGrid_RecordDeleted(object sender, RecordDeletedEventArgs e)
        {
            SfDataGrid dataGrid = sender as SfDataGrid;
            List<object> value = new List<object>();
            if (dataGrid != null)
            {
                IDictionary<string, object> objectName = new Dictionary<string, object>();
                var command = dataGrid.GetValue(ItemChangedCommandProperty) as ICommand;
                if (command != null)
                {
                    var items = e.Items;
                    foreach (var item in items)
                    {
                        BaseViewObject viewObject = item as BaseViewObject;
                        viewObject.IsDeleted = true;
                    }
                    var collection = dataGrid.View.SourceCollection;
                    foreach (var c in collection)
                    {
                        BaseViewObject v = c as BaseViewObject;
                        if (v.IsNew)
                        {
                            value.Add(c);
                        }
                        else if (v.IsDirty)
                        {
                            value.Add(c);
                        }
                        else if (v.IsDeleted)
                        {
                            value.Add(c);
                        }
                    }
 
                   
                    IEnumerable<object> currentValues = value.Union(items);
                    
                    objectName["DataObject"] = GetDataSource(dataGrid);
                    objectName["DataSourcePath"] = GetDataSourcePath(dataGrid);
                    objectName["ChangedValue"] = currentValues;
                    objectName["DeletedItems"] = true;
                    objectName["Operation"] = ControlExt.GridOp.Delete;
                    objectName["DeletedItems"] = false;
                    objectName["LastRowId"] = dataGrid.GetLastRowIndex();
                    command.Execute(objectName);
                }
            }
        }

        private static void CurrentDataGrid_CurrentCellEndEdit(object sender, CurrentCellEndEditEventArgs e)
        {
            SfDataGrid dataGrid = sender as SfDataGrid;
           
            if (dataGrid != null)
            {
                IDictionary<string, object> objectName = new Dictionary<string, object>();
                var command = dataGrid.GetValue(ItemChangedCommandProperty) as ICommand;
                if (command != null)
                {       
                    /*
                  
                    objectName["DataObject"] = GetDataSource(dataGrid);
                    objectName["DataSourcePath"] = GetDataSourcePath(dataGrid);
                    objectName["ChangedValue"] = dataGrid.GetRecordAtRowIndex(e.RowColumnIndex.RowIndex);
                    objectName["PreviousValue"] = lastChangedRow;
                    objectName["Operation"] = ControlExt.GridOp.Update;
                    objectName["DeletedItems"] = false;
                    objectName["LastRowId"] = dataGrid.GetLastRowIndex();
                    lastChangedRow = dataGrid.GetRecordAtRowIndex(e.RowColumnIndex.RowIndex);
                    command.Execute(objectName);
                    */
                }
            }
        }

        private static void Box_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                var command = textBox.GetValue(ItemChangedCommandProperty) as ICommand;
                if (command != null)
                {
                    var dataSource = GetDataSource(textBox);
                    if (dataSource is BaseViewObject dto)
                    {
                        if (dto.HasErrors)
                            return;
                    }
                    IDictionary<string, object> objectName = new Dictionary<string, object>();
                    objectName["DataObject"] = GetDataSource(textBox);
                    objectName["DataSourcePath"] = GetDataSourcePath(textBox);
                    objectName["ChangedValue"] = textBox.Text;
                    objectName["PreviousValue"] = _lastTextBoxValue;
                    _lastTextBoxValue = textBox.Text;
                    command.Execute(objectName);
                }
            }
        }

        private static void Box_LostFocus1(object sender, RoutedEventArgs e)
        {
            var textBox = sender as PercentTextBox;
            if (textBox != null)
            {
                var command = textBox.GetValue(ItemChangedCommandProperty) as ICommand;
                if (command != null)
                {
                    var dataSource = GetDataSource(textBox);
                    if (dataSource is BaseViewObject dto)
                    {
                        if (dto.HasErrors)
                            return;
                    }
                    IDictionary<string, object> objectName = new Dictionary<string, object>();
                    objectName["DataObject"] = GetDataSource(textBox);
                    objectName["DataSourcePath"] = GetDataSourcePath(textBox);
                    objectName["ChangedValue"] = Convert.ToDecimal(textBox.PercentValue);
                    objectName["PreviousValue"] = Convert.ToDecimal(_lastPercentValue);
                    _lastPercentValue = textBox.PercentValue;
                    command.Execute(objectName);
                }
            }
            
        }


        /// <summary>
        ///  SelectionChanged. This event get triggered when the selection change in a property
        /// </summary>
        /// <param name="sender">The sender of the call</param>
        /// <param name="e"> Event args</param>
        private static void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                var command = comboBox.GetValue(ItemChangedCommandProperty) as ICommand;
                if (command != null)
                {
                    IDictionary<string, object> objectName = new Dictionary<string, object>();
                    object dataObject = GetDataSource(comboBox);
                    if (dataObject != null)
                    {
                        string dataPath = GetDataSourcePath(comboBox);
                        if (string.IsNullOrEmpty(dataPath))
                        {
                            int selectedIndex = comboBox.SelectedIndex;
                            ComponentUtils.SetPropValue(dataObject, dataPath, selectedIndex);
                            objectName["ChangedIndex"] = selectedIndex;
                            objectName["ChangedValue"] =  comboBox.SelectedValue;
                        }
                        objectName["DataObject"] = GetDataSource(comboBox);
                        objectName["DataSourcePath"] = GetDataSourcePath(comboBox);
                    }
                    command.Execute(objectName);
                }
            }
        }

        /// <summary>
        ///  DataFieldCheckBoxChanged.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CheckBox_DataFieldCheckBoxChanged(object sender, RoutedEventArgs e)
        {
            var value = e as DataFieldCheckBoxEventArgs;
            var dataFieldCheckBox = sender as DataFieldCheckBox;
            if (dataFieldCheckBox != null)
            {
                var command = dataFieldCheckBox.GetValue(ItemChangedCommandProperty) as ICommand;    
                if (command != null)
                {
                    command.Execute(value.ChangedValuesObjects);
                }
            }
            
        }

       
        private static void TextBox_ChangedBehaviour(object sender, RoutedEventArgs args)
        {
            
        }
        private static void DataDatePicker_DataDatePickerChanged(object sender, RoutedEventArgs e)
        {
            DataDatePicker.DataDatePickerEventArgs args = (DataDatePicker.DataDatePickerEventArgs) e;
            DataDatePicker picker = sender as DataDatePicker;
            if (picker != null)
            {
                ICommand changedCommand =  picker.GetValue(ItemChangedCommandProperty) as ICommand;
                IDictionary<string, object> evArgs = args.ChangedValuesObjects;
                if (changedCommand!=null)
                {
                    changedCommand.Execute(evArgs);
                }
            }
        }

        private static void SelectedDate_Changed(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DatePicker picker = sender as DatePicker;
            if (picker != null)
            {
                ICommand changedCommand = picker.GetValue(ItemChangedCommandProperty) as ICommand;
                if (changedCommand != null)
                {
                    if (picker.SelectedDate != null)
                    {
                        IDictionary<string, object> valueDictionary = new Dictionary<string, object>
                        {
                            ["Field"] = ControlExt.GetDataSourcePath(picker),
                            ["DataObject"] = ControlExt.GetDataSource(picker),
                            ["ChangedValue"] = (DateTime)picker.SelectedDate,
                        };
                        changedCommand.Execute(valueDictionary);
                    }
                }
            }
        }


        #endregion


        #region DataSource        
        /// <summary>
        ///  DataSource: data table or data object associaed with this control.
        /// </summary>
        public static DependencyProperty DataSourceProperty
            = DependencyProperty.RegisterAttached(
                "DataSource",
                typeof(object),
                typeof(ControlExt),
                new UIPropertyMetadata(new object(), DataSourceChanged));
        /// <summary>
        /// CheckAndAssign
        /// </summary>
        /// <param name="dataFieldCheckBox"></param>
        /// <param name="sourceNew"></param>
        /// <param name="path"></param>
        private static void CheckAndAssign(DataFieldCheckBox dataFieldCheckBox, object sourceNew, string path)
        {
            Contract.Requires((dataFieldCheckBox != null) &&
                              (sourceNew != null) &&
                              !string.IsNullOrEmpty(path));

           
            var propValue = ComponentUtils.GetPropValue(sourceNew, path);
            int value = 0;
           
            if (propValue != null)
            {
                if (propValue is string)
                {
                    value = int.Parse(propValue as string);
                    dataFieldCheckBox.IsChecked = value != 0;
                }

                if (propValue is bool)
                {
                    dataFieldCheckBox.IsChecked = (bool)propValue;
                }
                if (propValue is byte)
                {
                    value = Convert.ToByte(propValue);
                    dataFieldCheckBox.IsChecked = value != 0;
                }
                if (propValue.GetType().IsAssignableFrom(typeof(int)))
                {
                    // here we have a tinyint.
                    value = Convert.ToInt32(propValue);
                    dataFieldCheckBox.IsChecked = value != 0;
                   
                }
            }
        }

        /// <summary>
        /// CheckAndAssignText.
        /// </summary>
        /// <param name="dataAreaFiled"></param>
        /// <param name="sourceNew"></param>
        /// <param name="path"></param>
        private static void CheckAndAssignText(DataArea dataAreaFiled, object sourceNew, string path)
        {
            string propValue = ComponentUtils.GetPropValue(sourceNew, path) as string;
            if (!string.IsNullOrEmpty(propValue))
            {
                dataAreaFiled.TextContent = propValue;
            }
        }
        /// <summary>
        /// CheckAndAssignDate
        /// </summary>
        /// <param name="dataDatePicker">DataDatePicker component</param>
        /// <param name="sourceNew">Object to be assigned</param>
        /// <param name="path">Path of the date</param>
        private static void CheckAndAssignDate(DataDatePicker dataDatePicker, object sourceNew, string path)
        {
            Contract.Requires((dataDatePicker != null) &&
                              (sourceNew != null) &&
                              !string.IsNullOrEmpty(path));

            if ((dataDatePicker == null) || 
                (sourceNew == null) ||   
                (string.IsNullOrEmpty(path)))
            {
                return;
            }
            var propValue = ComponentUtils.GetPropValue(sourceNew, path);

            if (propValue == null)
            {
                var otherPath = "Value." + path;
                propValue = ComponentUtils.GetPropValue(sourceNew, otherPath);
            }
            if (propValue != null)
            {
                
                DateTime timeValue = DateTime.Now;
                if (propValue is string)
                {
                    try
                    {
                        timeValue = DateTime.Parse(propValue as string);
                    }
                    // this is wanted. We need to provide a default.
#pragma warning disable 0168
                    catch (Exception e)
                    {
#pragma warning restore 0168
                        timeValue = DateTime.Now;
                    }
                }
                else
                {
                    timeValue = (DateTime)propValue;

                }
                dataDatePicker.DateContent = timeValue;
            }
        }
        private static void DataSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            object sourceNew = e.NewValue;
            string path = GetDataSourcePath(d);
            if (sourceNew == null)
            {
                return;
            }
            if (string.IsNullOrEmpty(path))
            {
                return;
            }
            if (d is DataFieldCheckBox dataFieldCheckBox)
            {
                dataFieldCheckBox.DataObject = sourceNew;
                if (!string.IsNullOrEmpty(path))
                {
                    CheckAndAssign(dataFieldCheckBox, sourceNew, path);

                }
            }

            if(d is DataArea dataArea)
            {
                CheckAndAssignText(dataArea, sourceNew, path);
                dataArea.DataSource = e.NewValue;
                dataArea.DataSourcePath = path;
            }
            if (d is TextBox)
            {
                TextBox box = (TextBox) d;
                string propValue = ComponentUtils.GetPropValue(sourceNew, path) as string;
                if (propValue != null)
                {
                    box.Text = propValue;
                }
            }
            if (d is DataDatePicker dataPicker)
            {
                CheckAndAssignDate(dataPicker, sourceNew, path);
            }

        }
        /// <summary>
        ///  Get DataSource 
        /// </summary>
        /// <param name="ds">Data Source</param>
        /// <returns></returns>
        
        public static object GetDataSource(DependencyObject ds)
        {
           return ds.GetValue(DataSourceProperty);
        }
        /// <summary>
        /// Set DataSource
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="item"></param>
        public static void SetDataSource(DependencyObject ds, object item)
        {
            ds.SetValue(DataSourceProperty, item);
        }

        /// <summary>
        /// DataSource Path
        /// </summary>
        /// <param name="dspm">Data Source Path</param>
        /// <param name="item">Item to set</param>
        public static void SetDataSourcePath(DependencyObject dspm, string item)
        {
            dspm.SetValue(DataSourcePathProperty, item);
        }
        /// <summary>
        /// Get the data source path.
        /// </summary>
        /// <param name="dps"></param>
        /// <returns></returns>
        public static string  GetDataSourcePath(DependencyObject dps)
        {
            return (string)dps.GetValue(DataSourcePathProperty);
        }
        
        /// <summary>
        ///  Data Source Path to be used.
        /// </summary>
        public static DependencyProperty DataSourcePathProperty
            = DependencyProperty.RegisterAttached(
                "DataSourcePath",
                typeof(string),
                typeof(ControlExt),
                new UIPropertyMetadata(string.Empty, DataSourcePathChange));

        private static void DataSourcePathChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            string path = e.NewValue as string ;
            object value = GetDataSource(d);
            ComponentFiller filler = new ComponentFiller();
            if (value != null)
            {
                if (value is DataTable)
                {
                    DataTable currentTable = value as DataTable;
                    filler.FetchDataFieldObject(currentTable, path);
                    

                }
                else
                {
                    var propValue = ComponentUtils.GetPropValue(value, path);
                    if (propValue != null)
                    {
                        ComponentUtils.SetPropValue(value, path, propValue);
                    }
                }
            }
        }

        #endregion
       
        private static object _lastChangedRow;
        private static object _lastPassBoxValue;
        private static object _lastPercentValue;
    }
}
