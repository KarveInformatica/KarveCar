using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    static class ComponentUtils
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
            Type dataType = dataObject.GetType();
            // Get the string Value of the object.
            PropertyInfo valuePropType = dataType.GetProperty(ValueString);
            object valueObject = null;
            if (valuePropType != null)
            {
                valueObject = valuePropType.GetValue(dataObject);
            }
            if (valueObject != null)
            {
                Type valueType = valueObject.GetType();
                PropertyInfo info = valueType.GetProperty(dataField.ToUpper());
                // ok we get the field to be used and changed
                if (info != null)
                {
                    value = info.GetValue(valueObject) as string;
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
        public static Object GetPropValue(Object obj, String propName)
        {
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

        public static void SetPropValue(Object obj, String propName, object value)
        {
            string[] nameParts = propName.Split('.');
            if (nameParts.Length == 1)
            {
               obj.GetType().GetProperty(propName).SetValue(obj, value);
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
                        info.SetValue(obj,currentValue);
                    }
                    obj = info.GetValue(obj, null);
                    ++i;
                }
            }
        }

    }
}
