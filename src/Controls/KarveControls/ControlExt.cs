using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using KarveControls.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Windows.Interactivity;
using ICommand = System.Windows.Input.ICommand;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using Syncfusion.UI.Xaml.Grid.ScrollAxis;
using Prism.Commands;

namespace KarveControls
{
    public class NullCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return false;
        }

        public void Execute(object parameter)
        {
            return;
        }
    }
    /// <summary>
    ///  This is a list of attached properties to be associated to each karve control.
    /// </summary>
    public class ControlExt
    {

        private static string lastTextBoxValue = "";

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
        /// <summary>
        ///  DataType to be allowed.
        /// </summary>
        public enum DataType
        {
            /// <summary>
            ///  Double kind of data.
            /// </summary>
            DoubleField,
            /// <summary>
            /// Integer field of the component.
            /// </summary>
            IntegerField,
            /// <summary>
            ///  Nif field of the component.
            /// </summary>
            NifField,
            /// <summary>
            ///  Iban field of the component.
            /// </summary>
            IbanField,
            /// <summary>
            ///  Any other kind of field control.
            /// </summary>
            Any,
            /// <summary>
            ///  Email kind field of the control.
            /// </summary>
            Email,
            /// <summary>
            ///  Phone field of the control.
            /// </summary>
            Phone,
            /// <summary>
            /// Bank Account of the control.
            /// </summary>
            BankAccount,
            /// <summary>
            ///  Swift field of the control.
            /// </summary>
            Swift,
            /// <summary>
            ///  Datatime field of the contorl.
            /// </summary>
            DateTime
        }

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
            passwordBox.PasswordChanged -= PasswordChanged;

            if (!(bool)GetIsUpdating(passwordBox))
            {
                passwordBox.Password = (string)e.NewValue;
                // here the value of the password is changed.
               
            }
            passwordBox.PasswordChanged += PasswordChanged;
        }

        public static readonly DependencyProperty AttachProperty =
        DependencyProperty.RegisterAttached("Attach",
        typeof(bool), typeof(ControlExt), new PropertyMetadata(false, Attach));

        private static readonly DependencyProperty IsUpdatingProperty =
           DependencyProperty.RegisterAttached("IsUpdating", typeof(bool),
           typeof(ControlExt));

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
            PasswordBox passwordBox = sender as PasswordBox;

            if (passwordBox == null)
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
                objectName["PreviousValue"] = lastPassBoxValue;
                lastPassBoxValue = passwordBox.Password;
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
                new FrameworkPropertyMetadata(new NullCommand(), PropertyChangedCb));

        /// <summary>
        ///  Set the item changed command, Attached behaviour for the component.
        /// </summary>
        /// <param name="d">Depedency property</param>
        /// <param name="e">Value</param>
        public static void SetItemChangedCommand(UIElement ext, ICommand command)
        {
            ext.SetValue(ItemChangedCommandProperty,command);
        }

        /// <summary>
        ///  Get item changed command.
        /// </summary>
        /// <param name="d">Dependency Properties</param>
        /// <param name="e">Value</param>
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
            if (dependencyObject is SfDataGrid)
            {
                SfDataGrid currentDataGrid = dependencyObject as SfDataGrid;
              //  currentDataGrid.CurrentCellEndEdit += CurrentDataGrid_CurrentCellEndEdit;
                currentDataGrid.RecordDeleted += CurrentDataGrid_RecordDeleted;
                currentDataGrid.AddNewRowInitiating += CurrentDataGrid_AddNewRowInitiating;
                currentDataGrid.RowValidated += CurrentDataGrid_RowValidated;
            }
            if (dependencyObject is DataArea)
            {
                DataArea dataArea = dependencyObject as DataArea;
                dataArea.ItemChangedCommand = GetItemChangedCommand(dataArea);
                dataArea.DataSource = GetDataSource(dataArea);
                dataArea.DataSourcePath = GetDataSourcePath(dataArea);
                return;
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
                checkBox.DataFieldCheckBoxChanged += CheckBox_DataFieldCheckBoxChanged;
                return;
            }
            if (dependencyObject is CheckBox)
            {
                CheckBox checkBox = dependencyObject as CheckBox;
                checkBox.Checked += CheckBox_Checked;
                checkBox.Unchecked += CheckBox_Unchecked;
                checkBox.Click += checkBox_Clicked;
                return;
            }
            if (dependencyObject is ComboBox)
            {
                ComboBox comboBox = dependencyObject as ComboBox;
                if (comboBox != null)
                {
                    // here we do the combox box.
                    comboBox.SelectionChanged += ComboBox_SelectionChanged;

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
                    values.Add("ChangedValue", false);
                    values.Add("PreviousValue", true);
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
                    values.Add("ChangedValue", true);
                    values.Add("PreviousValue", false);
                    command.Execute(values);
                }
            }
        }

        private static void CurrentDataGrid_RowValidated(object sender, RowValidatedEventArgs e)
        {
            SfDataGrid dataGrid = sender as SfDataGrid;
            var command = dataGrid?.GetValue(ItemChangedCommandProperty) as ICommand;
            if ((command != null) && (dataGrid!=null))
            {
                IDictionary<string, object> objectName = new Dictionary<string, object>();
                objectName["DataObject"] = GetDataSource(dataGrid);
                objectName["DataSourcePath"] = GetDataSourcePath(dataGrid);
                objectName["ChangedValue"] = dataGrid.GetRecordAtRowIndex(e.RowIndex);
                objectName["PreviousValue"] = lastChangedRow;
                objectName["Operation"] = ControlExt.GridOp.Update;
                objectName["DeletedItems"] = false;
                objectName["LastRowId"] = dataGrid.GetLastRowIndex();
                lastChangedRow = dataGrid.GetRecordAtRowIndex(e.RowIndex);
                command.Execute(objectName);
            }
        }

        private static void CurrentDataGrid_AddNewRowInitiating(object sender, AddNewRowInitiatingEventArgs e)
        {
           
            SfDataGrid dataGrid = sender as SfDataGrid;
            var command = dataGrid?.GetValue(ItemChangedCommandProperty) as ICommand;
            if ((command != null) && (dataGrid !=null))
            {
                IDictionary<string, object> objectName = new Dictionary<string, object>();
                objectName["DataObject"] = GetDataSource(dataGrid);
                objectName["DataSourcePath"] = GetDataSourcePath(dataGrid);
                objectName["ChangedValue"] = e.NewObject;
                objectName["PreviousValue"] = lastChangedRow;
                objectName["Operation"] = ControlExt.GridOp.Insert;
                objectName["DeletedItems"] = false;
                objectName["LastRowId"] = dataGrid.GetLastRowIndex();
                command.Execute(objectName);
            }
            // lastChangedRow = dataGrid.Get;
        }

        private static void CurrentDataGrid_RecordDeleted(object sender, RecordDeletedEventArgs e)
        {
            SfDataGrid dataGrid = sender as SfDataGrid;
            if (dataGrid != null)
            {
                IDictionary<string, object> objectName = new Dictionary<string, object>();
              
                var command = dataGrid.GetValue(ItemChangedCommandProperty) as ICommand;
                if (command != null)
                {
                    objectName["DataObject"] = GetDataSource(dataGrid);
                    objectName["DataSourcePath"] = GetDataSourcePath(dataGrid);
                    objectName["ChangedValue"] = e.Items;
                    objectName["DeletedItems"] = true;
                    objectName["Operation"] = ControlExt.GridOp.Insert;
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
                    IDictionary<string, object> objectName = new Dictionary<string, object>();
                    objectName["DataObject"] = GetDataSource(textBox);
                    objectName["DataSourcePath"] = GetDataSourcePath(textBox);
                    objectName["ChangedValue"] = textBox.Text;
                    objectName["PreviousValue"] = lastTextBoxValue;
                    lastTextBoxValue = textBox.Text;
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
            var dataFieldCheckBox = sender as DataFieldCheckBox;
            if (dataFieldCheckBox != null)
            {
                var command = dataFieldCheckBox.GetValue(ItemChangedCommandProperty) as ICommand;
                
                if (command != null)
                {
                    var sourceObject = GetDataSource(dataFieldCheckBox);
                    var sourceObjectPath = GetDataSourcePath(dataFieldCheckBox);
                  
                    ComponentUtils.SetPropValue(sourceObject, sourceObjectPath, dataFieldCheckBox.IsChecked);
                    SetDataSource(dataFieldCheckBox, sourceObject);
                    IDictionary<string, object> objectName = new Dictionary<string, object>();
                    objectName["DataObject"] = sourceObject;
                    objectName["DataSourcePath"] = sourceObjectPath;
                    objectName["ChangedValue"] = dataFieldCheckBox.IsChecked;
                    command.Execute(objectName);
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

        
        #endregion

        
        #region DataSource        
        /// <summary>
        ///  DataSource: data table or data object associaed with this control.
        /// </summary>
        public static DependencyProperty DataSourceDependencyProperty
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
           
            if (propValue != null)
            {
                DateTime timeValue = DateTime.Now;
                if (propValue is string)
                {
                    try
                    {
                        timeValue = DateTime.Parse(propValue as string);
                    }
                    catch (Exception e)
                    {
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

            if(d is DataArea)
            {
                DataArea dataArea = (DataArea)d;
                CheckAndAssignText(dataArea, sourceNew, path);
                dataArea.DataSource = e.NewValue;
               // dataArea.DataSourcePath = path;
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
                if (dataPicker != null)
                {
                    CheckAndAssignDate(dataPicker, sourceNew, path);
                }
            }

        }
        /// <summary>
        ///  Get DataSource 
        /// </summary>
        /// <param name="ds">Data Source</param>
        /// <returns></returns>
        
        public static object GetDataSource(DependencyObject ds)
        {
           return ds.GetValue(DataSourceDependencyProperty);
        }
        /// <summary>
        /// Set DataSource
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="item"></param>
        public static void SetDataSource(DependencyObject ds, object item)
        {
            ds.SetValue(DataSourceDependencyProperty, item);
        }

        /// <summary>
        /// DataSource Path
        /// </summary>
        /// <param name="dspm">Data Source Path</param>
        /// <param name="item">Item to set</param>
        public static void SetDataSourcePath(DependencyObject dspm, string item)
        {
            dspm.SetValue(DataSourcePathDependencyProperty, item);
        }
        /// <summary>
        /// Get the data source path.
        /// </summary>
        /// <param name="dps"></param>
        /// <returns></returns>
        public static string  GetDataSourcePath(DependencyObject dps)
        {
            return (string)dps.GetValue(DataSourcePathDependencyProperty);
        }
        
        /// <summary>
        ///  Data Source Path to be used.
        /// </summary>
        public static DependencyProperty DataSourcePathDependencyProperty
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
       
        private static object lastChangedRow;
        private static object lastPassBoxValue;
    }
}
