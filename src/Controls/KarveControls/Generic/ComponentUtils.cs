using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KarveControls.Generic
{
    /// <summary>
    /// Utility functions to be spread in all the component. 
    /// TODO. Thinking to merge the component utils with the component filler.
    /// </summary>
    public static class ComponentUtils
    {
        private const string ValueString = "Value";

        /// <summary>
        /// Get Text from data object using reflection and the opportune conversion. 
        /// </summary>
        /// <param name="dataObject">Data object to be used.</param>
        /// <param name="dataField">Field name to be used.</param>
        /// <param name="dataAllowed">Kind of data to be used.</param>
        /// <returns></returns>
        public static string GetTextDo(object dataObject, string dataField, ControlExt.DataType dataAllowed)
        {
            string value = "";
            if (dataObject == null)
            {
                return string.Empty;
            }
            Type dataType = dataObject.GetType();
            var currentPropertyValue = GetPropValue(dataObject, dataField);
            // Get the string Value of the object.
            PropertyInfo valuePropType = dataType.GetProperty(ValueString);
            object valueObject = null;

            if (currentPropertyValue != null)
            {
                return currentPropertyValue.ToString();
            }
            if (valuePropType == null)
            {
                return string.Empty;
            }

            valueObject =
                valuePropType.GetValue(dataObject);

            if (valueObject != null)
            {
                Type valueType = valueObject.GetType();
                var currentField = dataField;
                PropertyInfo info = valueType.GetProperty(currentField);
                if (info == null)
                {
                    currentField = currentField.ToUpper();
                    info = valueType.GetProperty(currentField);
                }
                // ok we get the field to be used and changed
                if (info != null)
                {
                    object tmpValue = info.GetValue(valueObject);
                    value = (tmpValue != null) ? tmpValue.ToString() : "";
                    // since internally we have problems with email. 
                    if ((value != null) && (dataAllowed == ControlExt.DataType.Email))
                    {
                        value = value.Replace("#", "@");
                    }
                }
            }

            return value;
        }

        /// <summary>
        ///  GetPropertiesValue.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propName"></param>
        /// <returns></returns>
        public static Object GetPropValue(Object obj, String prop)
        {
            if (prop==null)
                return null;
            if (obj == null)
                return null;
            var propName = prop.Trim();
            if (string.IsNullOrEmpty(propName))
            {
                return null;

            }
            if (obj == null)
            {
                return null;
            }
            string[] nameParts = propName.Split('.');
            if (nameParts.Length == 1)
            {
                Type typeInfo = obj.GetType();
                PropertyInfo info = typeInfo.GetProperty(propName);
                if (info == null)
                    return null;
                return info.GetValue(obj, null);
            }
            foreach (String part in nameParts)
            {
                if (obj == null) { return null; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) { return null; }
                obj = info.GetValue(obj, null);
            }
            return obj;
        }

        /// <summary>
        /// Set a value of a property, in case it is a prefix value. update the upper object.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propName"></param>
        /// <param name="value"></param>
        /// <param name="valuePrefix"></param>
        public static void SetPropValue(object obj, String propName, object value, bool valuePrefix = false)
        {
            Contract.Requires((obj != null) &&
                              (value != null) &&
                              !string.IsNullOrEmpty(propName));



            if (string.IsNullOrEmpty(propName))
            {
                return;
            }
            var tmp = obj;
            string[] nameParts = propName.Split('.');
            if (nameParts.Length == 1)
            {
                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(propName);
                var currentValue = value;
                if (value is bool)
                {
                    currentValue = Convert.ToByte(value);
                }
                if (info != null)
                {
                    try
                    {
                        info.SetValue(obj, currentValue);
                    }
                    catch(Exception e)
                    {
                        string var = value.ToString();
                        info.SetValue(obj, var);
                    }
                }
                //obj.GetType().GetProperty(propName).SetValue(obj, value);
            }
            int i = 1;
            foreach (String part in nameParts)
            {

                if (obj != null)
                {
                    Type type = obj.GetType();

                    PropertyInfo info = type.GetProperty(part);
                    object currentValue = value;
                    if ((info != null) && (i == nameParts.Length))
                    {
                        Type type1 = info.GetType();
                        if (info.PropertyType.FullName.Contains("Byte"))
                        {
                            currentValue = Convert.ToByte(currentValue);
                        }
                        if (info.PropertyType.FullName.Contains("String"))
                        {
                            if (currentValue.GetType() == typeof(bool))
                            {
                                currentValue = (bool)currentValue ? "1" : "0";
                            }
                            currentValue = Convert.ToString(currentValue);
                        }
                        if (info.PropertyType.FullName.Contains("Int32"))
                        {
                            currentValue = Convert.ToInt32(currentValue);
                        }
                        if (info.PropertyType.FullName.Contains("Int16"))
                        {
                            currentValue = Convert.ToInt16(currentValue);
                        }
                        if (info.PropertyType.FullName.Contains("Decimal"))
                        {
                            currentValue = Convert.ToDecimal(currentValue);
                        }
                        if (info.PropertyType.FullName.Contains("DateTime"))
                        {
                            currentValue = Convert.ToDateTime(value);
                        }
                        if (info.PropertyType.FullName.Contains("Double"))
                        {
                            currentValue = Convert.ToDouble(currentValue);
                        }
                        if (info.PropertyType.FullName.Contains("Single"))
                        {
                            currentValue = Convert.ToSingle(currentValue);
                        }

                        if (info != null)
                        {
                            info.SetValue(obj, currentValue);
                            if ((i - 2) >= 0)
                            {
                                Type t = tmp.GetType();
                                PropertyInfo valueProperty = t.GetProperty(nameParts[i - 2]);
                                valueProperty?.SetValue(tmp, obj);
                            }
                        }
                    }
                    if ((obj != null) && (info != null))
                    {
                        tmp = obj;
                        obj = info.GetValue(obj, null);
                    }
                    ++i;
                }
            }
        }

    }
}
