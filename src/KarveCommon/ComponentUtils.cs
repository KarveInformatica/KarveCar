using System;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using KarveCommon.Generic;


namespace KarveCommon
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
        public static string GetTextDo(object dataObject, string dataField, DataType dataAllowed)
        {
            var value = "";
            if (dataObject == null)
            {
                return string.Empty;
            }
            var dataType = dataObject.GetType();
            var currentPropertyValue = GetPropValue(dataObject, dataField);
            // Get the string Value of the object.
            var valuePropType = dataType.GetProperty(ValueString);
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
                var valueType = valueObject.GetType();
                var currentField = dataField;
                var info = valueType.GetProperty(currentField);
                if (info == null)
                {
                    currentField = currentField.ToUpper();
                    info = valueType.GetProperty(currentField);
                }
                // ok we get the field to be used and changed
                if (info == null)
                {
                    return value;
                }
                var tmpValue = info.GetValue(valueObject);
                value = (tmpValue != null) ? tmpValue.ToString() : "";
                // since internally we have problems with email. 
                if ((dataAllowed == DataType.Email))
                {
                    value = value.Replace("#", "@");
                }
            }

            return value;
        }
        /// <summary>
        /// Creates an ImageSource object from a file on disk.
        /// </summary>
        /// <param name="file">The full path to the file that should be loaded.</param>
        /// <param name="forcePreLoad">if set to <c>true</c> the image file will be decoded and fully loaded when created.</param>
        /// <returns>A frozen image source object representing the loaded image.</returns>
        public static ImageSource CreateImageSource(string file, bool forcePreLoad)
        {
            if (forcePreLoad)
            {
                var src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri(file, UriKind.Absolute);
                src.CacheOption = BitmapCacheOption.OnLoad;
                src.EndInit();
                src.Freeze();
                return src;
            }
            else
            {
                var src = new BitmapImage(new Uri(file, UriKind.Absolute));
                src.Freeze();
                return src;
            }
        }
       /// <summary>
       /// Get property value.
       /// </summary>
       /// <param name="obj">Object name of the property.</param>
       /// <param name="prop">Property to be used.</param>
       /// <returns>Extract the value of the object</returns>
        public static object GetPropValue(object obj, string prop)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (prop==null)
                return null;

            var propName = prop.Trim();
            if (string.IsNullOrEmpty(propName))
            {
                return null;

            }

            var nameParts = propName.Split('.');
            if (nameParts.Length == 1)
            {
                var typeInfo = obj.GetType();
                var info = typeInfo.GetProperty(propName);
                return info == null ? null : info.GetValue(obj, null);
            }
            foreach (var part in nameParts)
            {
                if (obj == null) { return null; }

                var type = obj.GetType();
                var info = type.GetProperty(part);
                if (info == null) { return null; }
                obj = info.GetValue(obj, null);
            }
            return obj;
        }

        /// <summary>
        /// Set a value of a property, in case it is a prefix value. update the upper object.
        /// </summary>
        /// <param name="obj">Value of the object</param>
        /// <param name="propName">Name of the property</param>
        /// <param name="value">Value of the property</param>
        /// <param name="valuePrefix">True if it has prefix or not</param>
        public static void SetPropValue(object obj, string propName, object value, bool valuePrefix = false)
        {
            Contract.Requires((obj != null) &&
                              (value != null) &&
                              !string.IsNullOrEmpty(propName));



            if (string.IsNullOrEmpty(propName))
            {
                return;
            }
            var tmp = obj;
            var nameParts = propName.Split('.');
            if (nameParts.Length == 1)
            {
                var type = obj.GetType();
                var info = type.GetProperty(propName);
                
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
                    // This is wanted. We need to provide  a default
#pragma warning disable 0168
                    catch (Exception e)
                    {
#pragma warning restore 0168
                        var var = value.ToString();
                        info.SetValue(obj, var);
                    }
                }
                
            }
            var i = 1;
            foreach (var part in nameParts)
            {
                if (obj == null)
                {
                    continue;
                }
                var type = obj.GetType();

                var info = type.GetProperty(part);
                var currentValue = value;
                if ((info != null) && (i == nameParts.Length))
                {
                    var type1 = info.GetType();
                    if (info.PropertyType.FullName != null && info.PropertyType.FullName.Contains("Byte"))
                    {
                        currentValue = Convert.ToByte(currentValue);
                    }
                    if (info.PropertyType.FullName != null && info.PropertyType.FullName.Contains("String"))
                    {
                        if (currentValue is bool)
                        {
                            currentValue = (bool)currentValue ? "1" : "0";
                        }
                        currentValue = Convert.ToString(currentValue);
                    }
                    if (info.PropertyType.FullName != null && info.PropertyType.FullName.Contains("Int32"))
                    {
                        currentValue = Convert.ToInt32(currentValue);
                    }
                    if (info.PropertyType.FullName != null && info.PropertyType.FullName.Contains("Int16"))
                    {
                        currentValue = Convert.ToInt16(currentValue);
                    }
                    if (info.PropertyType.FullName != null && info.PropertyType.FullName.Contains("Decimal"))
                    {
                        currentValue = Convert.ToDecimal(currentValue);
                    }
                    if (info.PropertyType.FullName != null && info.PropertyType.FullName.Contains("DateTime"))
                    {
                        currentValue = Convert.ToDateTime(value);
                    }
                    if (info.PropertyType.FullName != null && info.PropertyType.FullName.Contains("Double"))
                    {
                        currentValue = Convert.ToDouble(currentValue);
                    }
                    if (info.PropertyType.FullName != null && info.PropertyType.FullName.Contains("Single"))
                    {
                        currentValue = Convert.ToSingle(currentValue);
                    }

                    info.SetValue(obj, currentValue);
                    if ((i - 2) >= 0)
                    {
                        var t = tmp.GetType();
                        var valueProperty = t.GetProperty(nameParts[i - 2]);
                        valueProperty?.SetValue(tmp, obj);
                    }
                }
                if ((info != null))
                {
                    tmp = obj;
                    obj = info.GetValue(obj, null);
                }
                ++i;
            }
        }

    }
}
