using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace KarveControls.Generic
{
    /// <summary>
    /// This class has the reponsability of filling an image source
    /// </summary>
    /// TODO: create unit testing for the component filler.
    public class ComponentFiller
    {

        /// <summary>
        ///  Class for unpacking the object to a value.
        /// </summary>
        public class UiMetaObject : BindableBase
        {
            private string labelText = string.Empty;
            /// <summary>
            /// Delegate to be assigned in a item
            /// </summary>
            public DelegateCommand<object> ChangedItem { set; get; }
            /// <summary>
            /// DataSource to be used
            /// </summary>
            public object DataSource { set; get; }
            /// <summary>
            /// Data Source Path to be used
            /// </summary>
            public string DataSourcePath { set; get; }
            /// <summary>
            /// Label text to be used.
            /// </summary>
            public string LabelText
            {
                set { labelText = value; }
                get { return labelText; }
            }
        }
        /// <summary>
        /// Fills an image from a bytearray 
        /// </summary>
        /// <param name="arrayOftheImage">Array to be used for filling</param>
        /// <param name="image">Output image to be used</param>
        public void FillImageSource(byte[] arrayOftheImage, ref Image image)
        {
            using (MemoryStream reader = new MemoryStream(arrayOftheImage))
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = reader;
                bitmap.EndInit();
                bitmap.Freeze();
                image.Source = bitmap;
            }

        }
        /// <summary>
        /// Fill the data object with a type
        /// </summary>
        /// <param name="textField">Field of the text.</param>
        /// <param name="dataObject">Data object to be filled.</param>
        /// <param name="dataField">Data field to be filled.</param>
        public void FillDataObject(string textField, string dataField, ref object dataObject)
        {
                try
                {
                    ComponentUtils.SetPropValue(dataObject, "Value."+dataField.ToUpper(), textField);
                    
                }
                catch (Exception e)
                {
                    string msg = e.Message;
                }
            
        }
        /// <summary>
        /// GetCollectionProperties returns a a list of data obects.
        /// </summary>
        /// <param name="itemSource"></param>
        /// <returns></returns>
        public List<UiMetaObject> GetCollectionProperties(object itemSource)
        {
            Type type = itemSource.GetType();
            PropertyInfo[] infos = type.GetProperties();
            List<UiMetaObject> metaObjects = new List<UiMetaObject>();
            for (int i = 0; i < infos.Length; ++i)
            {
                UiMetaObject metaObject = new UiMetaObject();
                metaObject.LabelText = infos[i].Name;
                metaObject.DataSourcePath = infos[i].Name;
                metaObject.DataSource = itemSource;
                metaObjects.Add(metaObject);
            }
            return metaObjects;
        }

        /// <summary>
        ///  This method fills the checkbox value with the value of the itemsource.
        /// </summary>
        /// <param name="itemSource"></param>
        /// <param name="fieldName"></param>
        /// <param name="checkBox"></param>
        /// <returns></returns>
        public bool FetchFillerCheckBox(DataTable itemSource, string fieldName, ref CheckBox checkBox)
        {
            DataColumnCollection dataFieldCollection = itemSource.Columns;
            bool isEnabled = false;
            if (itemSource.Rows.Count > 0)
            {
                DataRow primaryItemSourceRow = itemSource.Rows[0];
                if (dataFieldCollection.Contains(fieldName))
                {


                    object currentValue = primaryItemSourceRow[fieldName];
                    isEnabled = isCheckBoxEnabled(currentValue);

                }

            }
            return isEnabled;
        }

        private bool isCheckBoxEnabled(object currentValue)
        {
            bool isEnabled = false;
            if (!DBNull.Value.Equals(currentValue))
            {
                if (currentValue is Int16)
                {
                    Int16 value = (Int16)currentValue;
                    isEnabled = value != 0;


                }
                if (currentValue is Int32)
                {
                    Int32 value = (Int32)currentValue;
                    isEnabled = value != 0;
                }
            }
            return isEnabled;
        }
        /// <summary>
        /// Returns the name of a datafield from object.
        /// </summary>
        /// <param name="itemSource">The object from which we have to fill the data</param>
        /// <param name="fieldName">The name of the field</param>
        /// <returns></returns>
        public object FetchDataFieldFromObject(object itemSource, string fieldName)
        {
            object value = null;
            if ((itemSource == null) || (string.IsNullOrEmpty(fieldName)))
            {
                return null;
            }
            // this is how this works.
            Type t = itemSource.GetType();
            // we assume that the properties.
            PropertyInfo info = t.GetProperty(fieldName);
            var currentObjectValue = info.GetValue(itemSource);
            if ((currentObjectValue != null) && (!DBNull.Value.Equals(currentObjectValue)))
            {
                value = currentObjectValue;
            }
            return value;
        }
        /// <summary>
        ///  This fetches the data field object from a datatable.
        /// </summary>
        /// <param name="itemSource">DataTable to be injected</param>
        /// <param name="fieldName">Name of the field</param>
        /// <returns>The object representing that field</returns>
        public object FetchDataFieldObject(DataTable itemSource, string fieldName)
        {
            DataColumnCollection dataFieldCollection = itemSource.Columns;
            object value = null;
            if (itemSource.Rows.Count > 0)
            {
                DataRow primaryItemSourceRow = itemSource.Rows[0];
                if (dataFieldCollection.Contains(fieldName))
                {
                    var currentValue = primaryItemSourceRow[fieldName];
                    Type dataType = primaryItemSourceRow.Table.Columns[fieldName].DataType;
                    if ((currentValue != null) && (!DBNull.Value.Equals(currentValue)))
                    {
                        value = currentValue;
                    }

                }
            }
            return value;
        }
        /// <summary>
        /// This fetches the data field object from a datatable.
        /// </summary>
        /// <param name="itemSource">DataTable to be injected</param>
        /// <param name="fieldName">Name of the filed</param>
        /// <returns>A string representation of the obejct stored in the datatable field</returns>
        public string FetchDataFieldValue(DataTable itemSource, string fieldName)
        {
            DataColumnCollection dataFieldCollection = itemSource.Columns;
            string value = "";

            if (itemSource.Rows.Count > 0)
            {
                DataRow primaryItemSourceRow = itemSource.Rows[0];
                if (dataFieldCollection.Contains(fieldName))
                {
                    var currentValue = primaryItemSourceRow[fieldName];
                    Type dataType = primaryItemSourceRow.Table.Columns[fieldName].DataType;
                    if ((currentValue != null) && (!DBNull.Value.Equals(currentValue)))
                    {
                        value = currentValue.ToString();
                    }

                }
            }
            return value;
        }
        /// <summary>
        /// Fill a textbox with the content of a data table 
        /// </summary>
        /// <param name="table">Table to be filled</param>
        /// <param name="fieldName">Field in the table</param>
        /// <param name="textFilledBox">Test to be complete</param>
        /// <returns></returns>
        public bool FillTextBox(DataTable table, string fieldName, ref TextBox textFilledBox)
        {
            if (string.IsNullOrEmpty(fieldName))
                return false;
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                if (row.Table.Columns.Contains(fieldName))
                {
                    textFilledBox.Text = string.Format("{0}", table.Rows[0][fieldName]);

                    return true;
                }
            }
            return false;
        }
        /// <summary>
        ///  Fill a table with the content of a textbox doing type conversion
        /// </summary>
        /// <param name="textFilledBox">Textbox to be used</param>
        /// <param name="fieldName">Field to be filled</param>
        /// <param name="table">Table field</param>
        /// <returns></returns>
        public bool FillTable(TextBox textFilledBox, string fieldName, ref DataTable table)
        {
            string value = textFilledBox.Text;
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            if (string.IsNullOrEmpty(fieldName))
                return false;
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                if (row.Table.Columns.Contains(fieldName))
                {
                    Type dataType = table.Columns[fieldName].DataType;
                    TypeConverter converter = new TypeConverter();
                    object convertedValue = null;
                    if (dataType.Name == "Int16")
                    {
                        Int16 v = 0;
                        if (Int16.TryParse(value, out v))
                        {
                            table.Rows[0][fieldName] = v;
                            return true;
                        }

                    }
                    if (typeof(byte) == dataType)
                    {
                        Byte v = 0;
                        if (Byte.TryParse(value, out v))
                        {
                            table.Rows[0][fieldName] = v;
                            return true;
                        }
                    }
                    else if (dataType.Name == "Int32")
                    {
                        Int32 v = 0;
                        if (Int32.TryParse(value, out v))
                        {
                            table.Rows[0][fieldName] = v;
                            return true;
                        }

                    }
                    else if (dataType.Name == "String")
                    {
                        convertedValue = value;
                    }
                    else
                    {
                        convertedValue = converter.ConvertTo(value, dataType);
                    }
                    if (convertedValue != null)
                    {

                        table.Rows[0][fieldName] = convertedValue;
                        return true;
                    }
                }
            }
            return false;
        }

        private int ConvertToInt(object value)
        {
            int ret = 0;
            if (value != null)
            {
                if (value is int)
                {
                    return (int)value;
                }
                if (value is Int16)
                {
                    return int.Parse(value.ToString());
                }
                if (value is byte)
                {
                    return int.Parse(value.ToString());
                }
            }
            return ret;
        }
        internal void FillComboxBox(DataTable itemSource, string dataField, ref ComboBox karveComboBox)
        {
            if (itemSource != null)
            {
                DataRow row = itemSource.Rows[0];
                if (row.Table.Columns.Contains(dataField))
                {
                    object currentValue = itemSource.Rows[0][dataField];
                    if (currentValue != null)
                    {
                        // check if it is an integer or a byte and force to int.
                        int value = ConvertToInt(currentValue);
                        if ((value >= 0) && (value <= karveComboBox.Items.Count))
                        {
                            // count the number of controls.
                            karveComboBox.SelectedIndex = value;
                        }
                    }
                }
            }
        }
    }
}
