using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KarveControls.Generic
{
    /// <summary>
    /// ComponentEx is  an object to store a data field and and a data source.
    /// </summary>
    public class ComponentEx: DependencyObject
    {
        private object dataFieldValue;

        /// <summary>
        /// Dependency property for the data field.
        /// </summary>
        public static DependencyProperty DataFieldDependencyProperty =
           DependencyProperty.RegisterAttached(
               "DataField",
               typeof(string),
               typeof(ComponentEx),
               new PropertyMetadata(string.Empty, OnDataFieldExChanged));
        /// <summary>
        ///  Dependency properties for the data source.
        /// </summary>
        public static DependencyProperty DataSourceDependencyProperty =
         DependencyProperty.RegisterAttached(
         "DataSource",
         typeof(object),
         typeof(ComponentEx),
         new PropertyMetadata(null, OnDataSourceChanged));
        /// <summary>
        ///  This returns the data field.
        /// </summary>
        /// <param name="dataField">Name of the field</param>
        /// <returns></returns>
        public static string GetDataField(DependencyObject dataField)
        {
            return (string)dataField.GetValue(DataFieldDependencyProperty);
        }
        /// <summary>
        /// Set the value of the field.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetDataField(DependencyObject obj, string value)
        {
            obj.SetValue(DataFieldDependencyProperty, value);
        }

        /// <summary>
        /// Get or Set the data source
        /// </summary>
        /// <param name="obj">Dependency object to be setted</param>
        /// <returns></returns>
        public static object GetDataSource(DependencyObject obj)
        {
            return obj.GetValue(DataSourceDependencyProperty);
        }
        /// <summary>
        /// Set or Get the data source
        /// </summary>
        /// <param name="obj">Dependency object to be set</param>
        /// <param name="value">Value to be set</param>
        public static void SetDataSource(DependencyObject obj, object value)
        {
            obj.SetValue(DataSourceDependencyProperty, value);
        }
        /// <summary>
        /// Data Field call back when a field has been changed
        /// </summary>
        /// <param name="d">Dependency object to be set</param>
        /// <param name="e">Event that happens in a dependency object</param>
        private static void OnDataFieldExChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            object currentSource = d.GetValue(DataSourceDependencyProperty);
            string currentDataField = (string)d.GetValue(DataFieldDependencyProperty);
            ComponentFiller filler = new ComponentFiller();

            if (currentSource != null)
            {
                if (!string.IsNullOrEmpty(currentDataField))
                {
                    if (currentSource is DataTable)
                    {
                        DataTable itemSource = (DataTable)currentSource;
                        string valueToFill = filler.FetchDataFieldValue(itemSource, currentDataField);
                        if (d is TextBox)
                        {
                            TextBox box = (TextBox)d;
                            box.Text = valueToFill;
                        }
                        if (d is TextBlock)
                        {
                            TextBlock block = (TextBlock)d;
                            block.Text = valueToFill;

                        }
                        if (d is Image)
                        {
                            object objectValueToFill = filler.FetchDataFieldObject(itemSource, currentDataField);
                            Image currentImage = (Image)d;
                            currentImage.Source = new BitmapImage(new Uri((string)objectValueToFill, UriKind.Relative));
                        }
                    }
                    else
                    {
                        var valueObject = filler.FetchDataFieldFromObject(currentSource, currentDataField);
                        if (d is TextBox)
                        {
                            TextBox box = (TextBox)d;
                            box.Text = valueObject as string;
                        }
                        if (d is TextBlock)
                        {
                            TextBlock block = (TextBlock)d;
                            block.Text = valueObject as string;

                        }
                        if (d is Image)
                        {
                            Image currentImage = (Image)d;
                            currentImage.Source = new BitmapImage(new Uri((string)valueObject, UriKind.Relative));
                        }
                    }

                }

            }
        }

        /// <summary>
        ///  This field send us a data field in case of a data source.
        /// </summary>
        /// <param name="d">Dependency object</param>
        /// <param name="e">Data Source</param>
        private static void OnDataSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            object currentObject = d.GetValue(DataSourceDependencyProperty);
            string dataField = (string)d.GetValue(DataFieldDependencyProperty);
            ComponentFiller filler = new ComponentFiller();

            if (currentObject is DataTable)
            {
                DataTable table = (DataTable)currentObject;

                if (d is Image)
                {
                    object current = filler.FetchDataFieldObject(table, dataField);
                    Image currentImage = (Image)d;
                    byte[] value = current as byte[];
                    if (value != null)
                    {
                        filler.FillImageSource(value, ref currentImage);
                    }
                }
                else
                {
                    string value = filler.FetchDataFieldValue(table, dataField);
                    if (d is TextBlock)
                    {
                        TextBlock block = (TextBlock)d;
                        block.Text = value;
                    }
                    if (d is TextBox)
                    {
                        TextBox box = (TextBox)d;
                        box.Text = value;
                    }
                }
            }
            else
            {
                // it is an object and we look for the property specified in the datafield.
                Type t = currentObject.GetType();
                PropertyInfo propInfo = t.GetProperty(dataField);
                object currentFieldValue = filler.FetchDataFieldFromObject(currentObject, dataField);
                if (currentFieldValue!=null)
                {
                    // currentFieldValue is not null. 
                    if (d is Image)
                    {
                        Image currentImage = (Image)d;
                        byte[] value = currentFieldValue as byte[];
                        if (value != null)
                        {
                            filler.FillImageSource(value, ref currentImage);
                        }
                      //  d = currentImage;
                    }
                    else
                    {
                        string value = currentFieldValue as string;
                        if (d is TextBlock)
                        {
                            TextBlock block = (TextBlock)d;
                            block.Text = value;
                        }
                        if (d is TextBox)
                        {
                            TextBox box = (TextBox)d;
                            box.Text = value;
                        }
                    }
                }
            }

        }
    }
}
