using KarveCommon.Generic;
using System;
using System.Data;
using System.Reflection;

namespace KarveCar.Utility
{
    public class ManageDataTable
    {
        /// <summary>
        /// Convierte un GenericObservableCollection en un DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static DataTable ConvertObsCollectionToDataTable<T>(GenericObservableCollection obscollection)
        {
            DataTable datatable = new DataTable();
            if (obscollection.GenericObsCollection.Count > 0)
            {
                Type type = typeof(T);
                PropertyInfo[] properties = type.GetProperties();
                object temp;
                DataRow datarow;

                for (int i = 0; i < properties.Length; i++)
                {
                    datatable.Columns.Add(properties[i].Name, Nullable.GetUnderlyingType(properties[i].PropertyType) ?? properties[i].PropertyType);
                    datatable.Columns[i].AllowDBNull = true;
                }

                //Populate the table
                foreach (var item in obscollection.GenericObsCollection)
                {
                    datarow = datatable.NewRow();
                    datarow.BeginEdit();

                    for (int i = 0; i < properties.Length; i++)
                    {
                        temp = properties[i].GetValue(item, null);
                        if (temp == null || temp.ToString().Equals("0") || String.IsNullOrEmpty(temp.ToString()) || 
                            (temp.GetType().Name == "Char" && ((char)temp).Equals('\0')))
                        {
                            datarow[properties[i].Name] = (object)DBNull.Value;
                        }
                        else
                        {
                            datarow[properties[i].Name] = temp;
                        }
                    }

                    datarow.EndEdit();
                    datatable.Rows.Add(datarow);
                    datatable.AcceptChanges();
                }
            }
            return datatable;
        }

        public static DataRow ConvertObjectToDataRowView<T>(object obj)
        {
            DataRow datarow = null;

            if (obj != null)
            {
                Type type = typeof(T);
                PropertyInfo[] properties = type.GetProperties();
                object objtemp;

                datarow.BeginEdit();

                for (int i = 0; i < properties.Length; i++)
                {
                    objtemp = properties[i].GetValue(obj, null);
                    if (objtemp == null || objtemp.ToString().Equals("0") || String.IsNullOrEmpty(objtemp.ToString()) ||
                        (objtemp.GetType().Name == "Char" && ((char)objtemp).Equals('\0')))
                    {
                        datarow[properties[i].Name] = (object)DBNull.Value;
                    }
                    else
                    {
                        datarow[properties[i].Name] = objtemp;
                    }
                }
                datarow.EndEdit();
            }
            return datarow;
        }

        /// <summary>
        /// Convierte un DataRowView en un object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <returns></returns>
        public static T ConvertDataRowViewToObject<T>(DataRowView datarowview) where T : new()
        {
            T obj = new T();
            if (datarowview != null)
            {
                // go through each datacolumn
                foreach (DataColumn datacolumn in datarowview.DataView.Table.Columns)
                {
                    // find the property for the column
                    PropertyInfo property = obj.GetType().GetProperty(datacolumn.ColumnName);

                    // if exists, set the value
                    if (property != null && datarowview.Row[datacolumn] != DBNull.Value)
                    {
                        property.SetValue(obj, datarowview.Row[datacolumn], null);
                    }
                }
            }
            return obj;
        }

        public static DataRowView CloneDataRowView(DataRowView datarowview)
        {
            DataRow datarow = datarowview.Row;

            DataRowView datarowviewclone = datarow.Table.DefaultView.AddNew();

            for (int i = 0; i < datarow.ItemArray.Length; i++)
            {
                datarowviewclone.Row[i] = datarow[i];
            }

            return datarowviewclone;
        }

        /// <summary>
        /// Añade un object en un DataTable (object->DataRow->DataTable)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static void AddObjectToDataTable<T>(object obj, DataTable datatable)
        {
            if (obj != null)
            {
                Type type = typeof(T);
                PropertyInfo[] properties = type.GetProperties();
                object objtemp;

                //Populate the table
                DataRow datarow = datatable.NewRow();
                datarow.BeginEdit();

                for (int i = 0; i < properties.Length; i++)
                {
                    objtemp = properties[i].GetValue(obj, null);
                    if (objtemp == null || objtemp.ToString().Equals("0") || String.IsNullOrEmpty(objtemp.ToString()) ||
                        (objtemp.GetType().Name == "Char" && ((char)objtemp).Equals('\0')))
                    {
                        datarow[properties[i].Name] = (object)DBNull.Value;
                    }
                    else
                    {
                        datarow[properties[i].Name] = objtemp;
                    }
                }

                datarow.EndEdit();
                datatable.Rows.Add(datarow);
                datatable.AcceptChanges();
            }
        }

        public static DataTable AddDataRowViewToDataTable(DataRowView datarow, DataTable datatablesource)
        {
            DataTable datatable = new DataTable();
            if (datarow != null)
            {
                datatable = datatablesource.Clone();
                datatable.ImportRow(datarow.Row);
            }
            return datatable;
        }

        /// <summary>
        /// Modifica un DataRowView con los valores de un object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static void UpdateDataRowViewWithObject<T>(object obj, DataRowView datarowview)
        {
            if (obj != null && datarowview != null)
            {
                Type type = typeof(T);
                PropertyInfo[] properties = type.GetProperties();
                object objtemp;

                for (int i = 0; i < properties.Length; i++)
                {
                    objtemp = properties[i].GetValue(obj, null);
                    if (objtemp == null || objtemp.ToString().Equals("0") || String.IsNullOrEmpty(objtemp.ToString()) ||
                        (objtemp.GetType().Name == "Char" && ((char)objtemp).Equals('\0')))
                    {
                        datarowview[properties[i].Name] = (object)DBNull.Value;
                    }
                    else
                    {
                        datarowview[properties[i].Name] = objtemp;
                    }
                }
            }
        }

        /// <summary>
        /// Devuelve un DataRow del DataTable pasado por params, según su codigo(string) y la propiedad de éste, también pasados por params
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="dataTable"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public static DataRowView FindDataRowViewInDataTableByString(string codigo, DataTable dataTable, string property)
        {
            DataRowView datarowview = null;
            foreach (DataRowView datarowviewtemp in dataTable.DefaultView)
            {
                if (string.Equals(datarowviewtemp.Row.Field<string>(property), codigo, StringComparison.OrdinalIgnoreCase))
                {
                    datarowview = datarowviewtemp;
                    break;
                }
            }
            return datarowview;
        }

        /// <summary>
        /// Devuelve un DataRow del DataTable pasado por params, según su codigo(int) y la propiedad de éste, también pasados por params
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="dataTable"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public static DataRowView FindDataRowViewByCodigoInDataTableByInt(int codigo, DataTable dataTable, string property)
        {
            DataRowView dataRowView = null;
            foreach (DataRowView tempRowView in dataTable.DefaultView)
            {
                if (tempRowView.Row.Field<int>(property) == codigo)
                {
                    dataRowView = tempRowView;
                    break;
                }
            }
            return dataRowView;
        }

        /// <summary>
        /// Devuelve un DataRow del DataTable pasado por params, según su codigo(byte) y la propiedad de éste, también pasados por params
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="dataTable"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public static DataRowView FindDataRowViewBInDataTableByByte(byte codigo, DataTable dataTable, string property)
        {
            DataRowView dataRowView = null;
            foreach (DataRowView tempRowView in dataTable.DefaultView)
            {
                if (tempRowView.Row.Field<byte>(property) == codigo)
                {
                    dataRowView = tempRowView;
                    break;
                }
            }
            return dataRowView;
        }
    }
}
