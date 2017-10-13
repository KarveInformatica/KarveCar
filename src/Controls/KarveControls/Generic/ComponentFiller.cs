using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace KarveControls.Generic
{
    internal class ComponentFiller
    {

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
                    if (!DBNull.Value.Equals(currentValue))
                    {
                        if (currentValue is Int16)
                        {
                            Int16 value = (Int16) currentValue;
                            isEnabled = value != 0;


                        }
                        if (currentValue is Int32)
                        {
                            Int32 value = (Int32) currentValue;
                            isEnabled = value != 0;
                        }
                    }
                }

            }
            return isEnabled;
        }

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
                    return (int) value;
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
                        if ((value >=0) && (value <= karveComboBox.Items.Count))
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
