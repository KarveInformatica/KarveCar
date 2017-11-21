using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using KarveControls.Generic;
using KarveControls;
using Telerik.Charting.Styles;
using System.Data;
using System.Windows.Input;
using System.Diagnostics.Contracts;
namespace KarveControls
{
    /// <summary>
    ///  This is a list of attached properties to be associated to each karve control.
    /// </summary>
    public class ControlExt: DependencyObject
    {
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
        public static readonly DependencyProperty ItemChangedCommandDependencyProperty =
            DependencyProperty.RegisterAttached(
                "ItemChangedCommand",
                typeof(DataType),
                typeof(ControlExt),
                new PropertyMetadata(DataType.Any));
        /// <summary>
        ///  Kind of data allowed for this component.
        /// </summary>
        public ICommand ItemChangedCommand
        {
            get { return (ICommand)GetValue(ItemChangedCommandDependencyProperty); }
            set { SetValue(ItemChangedCommandDependencyProperty, value); }
        }
        /// <summary>
        ///  Set the item changed command
        /// </summary>
        /// <param name="d">Depedency property</param>
        /// <param name="e">Value</param>
        public static void SetItemChangedCommand(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.SetValue(ItemChangedCommandDependencyProperty, e);
        }
        /// <summary>
        ///  Get item changed command.
        /// </summary>
        /// <param name="d">Dependency Properties</param>
        /// <param name="e">Value</param>
        /// <returns></returns>
        public static ICommand GetItemChangedCommand(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            return (ICommand) d.GetValue(ItemChangedCommandDependencyProperty);
        }

        #endregion

        #region DataAllowed
        /// <summary>
        ///  This is the kind of data allowd.
        /// </summary>
        public static readonly DependencyProperty DataAllowedDependencyProperty =
            DependencyProperty.RegisterAttached(
                "DataAllowed",
                typeof(DataType),
                typeof(ControlExt),
                new PropertyMetadata(DataType.Any));
        /// <summary>
        ///  Kind of data allowed for this component.
        /// </summary>
        public DataType DataAllowed
        {
            get { return (DataType) GetValue(DataAllowedDependencyProperty); }
            set { SetValue(DataAllowedDependencyProperty, value); }
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
                if (propValue.GetType().IsAssignableFrom(typeof(int)))
                {
                    // here we have a tinyint.
                    value = Convert.ToInt32(propValue);
                    dataFieldCheckBox.IsChecked = value == 0;
                   
                }
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
            DateTime timeValue = DateTime.Now;
            if (propValue != null)
            {


                if (propValue is string)
                {
                    try
                    {
                        timeValue = DateTime.Parse(propValue as string);
                    } catch (Exception e)
                    {
                        timeValue = DateTime.Now;
                    }
                }
                if (timeValue != null)
                {
                    dataDatePicker.DateContent = timeValue;
                }
                else
                {
                    dataDatePicker.DateContent = DateTime.Now;
                }
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
            if (d is DataArea)
            {
                DataArea dataArea = (DataArea)d;
                dataArea.DataSource = e.NewValue;
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
                    var propValue = filler.FetchDataFieldObject(currentTable, path);
                    

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
        #region TableName
        /// <summary>
        ///  Dependency property associated with the name of the table.
        /// </summary>
        public static readonly DependencyProperty DbTableNameDependencyProperty =
            DependencyProperty.RegisterAttached(
                "TableName",
                typeof(string),
                typeof(ControlExt),
                new PropertyMetadata(string.Empty));

        /// <summary>
        ///  Set or Get the name of the table associated to this control.
        /// </summary>
        public string TableName
        {
            get { return (string) GetValue(DbTableNameDependencyProperty); }
            set { SetValue(DbTableNameDependencyProperty, value); }
        }
        #endregion
    }
}
