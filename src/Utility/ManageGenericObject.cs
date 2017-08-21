using iAnywhere.Data.SQLAnywhere;
using KarveCar.Model.Generic;
using KarveCar.Model.Sybase;
using KarveCommon.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using static KarveCommon.Generic.RecopilatorioEnumerations;

namespace KarveCar.Utility
{
    public class ManageGenericObject
    {
        /// <summary>
        /// Devuelve una GenericObservableCollection con la info recibida de la BBDD (SADataReader dr), teniendo en cuenta la 
        /// info (List<TemplateInfoDB> templateinfodb) del tipo de dato (object obj) recibidos por params.
        /// También valida el tipo de dato 
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="templateinfodb"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static GenericObservableCollection GetObservableCollectionFromSADataReader(SADataReader dr, List<TemplateInfoDB> templateinfodb, object obj)
        {   
            //Se crea el GenericObservableCollection auxiliar que se devolverá, donde se irá añadiendo la info recuperada de la BBDD (SADataReader dr)
            GenericObservableCollection auxobscollection = new GenericObservableCollection();
            try
            {
                //Se recorre el SADataReader para obtener sus valores según el tipo de objeto recibido por params
                while (dr.Read())
                {   //Se recuperan las propiedades e instanciamos un nuevo objeto del tipo del objeto recibido por params
                    var properties = GetProperties(obj);
                    object newobj = CreateObject(obj);

                    //Se recorre la lista de propiedades del objeto recibido por params
                    foreach (var prop in properties)
                    {   //De cada propiedad del objeto recibido por params, se recorre su List<TemplateInfoDB> templateinfodb
                        foreach (var item in templateinfodb)
                        {   //Se comprueba que el tipo de la propiedad del objeto recibido por params esté incluida en el List<TemplateInfoDB> templateinfodb
                            if (item.nombrepropiedadobj == prop.Name)
                            {   //Se añade el dato recuperado de la DB mediante el SADataReader a la propiedad(item.nombrepropiedadobj) 
                                //del nuevo objeto(newobj), validando el dato según su tipo(ValidateData.***)
                                switch (item.tipodatocolumnadb)
                                {
                                    case ETiposDatoColumnaDB.DBstring:
                                        PropertySetValue(newobj, item.nombrepropiedadobj, ValidateData.GetString(dr[item.nombrecolumnadb] as string));
                                        break;
                                    case ETiposDatoColumnaDB.DBchar:
                                        PropertySetValue(newobj, item.nombrepropiedadobj, ValidateData.GetChar(dr[item.nombrecolumnadb] as char?));
                                        break;
                                    case ETiposDatoColumnaDB.DBbool:
                                        break;
                                    case ETiposDatoColumnaDB.DBbyte: //byte en C# = tinyint en la DB
                                        PropertySetValue(newobj, item.nombrepropiedadobj, ValidateData.GetByte(dr[item.nombrecolumnadb] as byte?));
                                        break;
                                    case ETiposDatoColumnaDB.DBshort:
                                        PropertySetValue(newobj, item.nombrepropiedadobj, ValidateData.GetShort(dr[item.nombrecolumnadb] as short?));
                                        break;
                                    case ETiposDatoColumnaDB.DBint:
                                        PropertySetValue(newobj, item.nombrepropiedadobj, ValidateData.GetInt(dr[item.nombrecolumnadb] as int?));
                                        break;
                                    case ETiposDatoColumnaDB.DBlong:
                                        PropertySetValue(newobj, item.nombrepropiedadobj, ValidateData.GetLong(dr[item.nombrecolumnadb] as long?));
                                        break;
                                    case ETiposDatoColumnaDB.DBdecimal:
                                        PropertySetValue(newobj, item.nombrepropiedadobj, ValidateData.GetDecimal(dr[item.nombrecolumnadb] as decimal?));
                                        break;
                                    case ETiposDatoColumnaDB.DBdouble:
                                        PropertySetValue(newobj, item.nombrepropiedadobj, ValidateData.GetDouble(dr[item.nombrecolumnadb] as double?));
                                        break;
                                    case ETiposDatoColumnaDB.DBdate:
                                        PropertySetValue(newobj, item.nombrepropiedadobj, ValidateData.GetDate(dr[item.nombrecolumnadb] as DateTime?));
                                        break;
                                    case ETiposDatoColumnaDB.DBdatetime:
                                        break;
                                    case ETiposDatoColumnaDB.DBsmalldatetime:
                                        break;
                                    case ETiposDatoColumnaDB.DBtime:
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                    auxobscollection.GenericObsCollection.Add(newobj); //Se añade el nuevo objeto del tipo recibido por params, a la ObservableCollection
                }
            }
            catch (SAException e)
            {
                ErrorsDB.MessageError(e);
            }
            return auxobscollection;
        }

        /// <summary>
        /// Crea un objeto del tipo del objeto(objoriginal) pasado por params
        /// </summary>
        /// <typeparam name="T">Tipo genérico de la class del objeto</typeparam>
        /// <param name="objoriginal">Objeto original del cual instanciaremos un nuevo objeto según su tipo</param>
        /// <returns></returns>
        public static T CreateObject<T>(T objoriginal)
        {
            return (T)Activator.CreateInstance(objoriginal.GetType());
        }

        /// <summary>
        /// Devuelve una colección de las propiedades del objeto(obj) pasado por params
        /// </summary>
        /// <param name="obj">Objeto del cual obtendremos una colección de sus propiedades</param>
        /// <returns></returns>
        public static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }

        /// <summary>
        /// Devuelve la propiedad (index) de una PropertyInfo[] pasado por params
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static PropertyInfo GetProperty(PropertyInfo[] properties, int index)
        {
            int j = 0;
            PropertyInfo info = null;
            foreach (var prop in properties)
            {
                if (j == index)
                {
                    info = prop;
                    break;
                }
                j++;
            }
            return info;
        }

        /// <summary>
        /// Convierte el object pasado por params en un string.ToUpper() como el ejemplo: [key1, value1];[ke2, value2]...
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string PropertyConvertToDictionary(object obj)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            try
            {
                Type tipo = obj.GetType();

                foreach (PropertyInfo info in tipo.GetProperties())
                {
                    if (!info.Name.ToString().Equals("ControlCambioDataGrid") && !info.Name.ToString().Equals("UltimaModificacion") && !info.Name.ToString().Equals("Usuario"))
                    {
                        dic.Add(info.Name.ToString(), PropertyGetValue(obj, info.Name.ToString()));
                    }                    
                }                
            }
            catch (Exception e)
            {
                ErrorsGeneric.MessageError(e);
            }
            string ret = string.Join(";", dic);
            return ret.ToUpper();
        }

        /// <summary>
        /// Añade un valor(value), a la propiedad(nombrepropiedadobj) del objeto(obj) pasado por params
        /// </summary>
        /// <param name="obj">El objeto al cual añadimos el valor</param>
        /// <param name="nombrepropiedad">Nombre de la propiedad del objeto a la cual le añadiremos el valor</param>
        /// <param name="value">Valor que añadiremos al objeto</param>
        public static void PropertySetValue(object obj, string property, object value)
        {
            try
            {
                Type tipo = obj.GetType();
                
                foreach (PropertyInfo info in tipo.GetProperties())
                {
                    if (info.Name == property)
                    {
                        info.SetValue(obj, value, null);
                    }
                }
            }
            catch (SAException e)
            {
                ErrorsDB.MessageError(e);
            }
        }

        /// <summary>
        /// Devuelve el valor(value) de la propiedad(nombrepropiedadobj) del objeto(obj) pasado por params
        /// </summary>
        /// <param name="obj">El objeto del cual recibimos el valor</param>
        /// <param name="property">Nombre de la propiedad del objeto a la cual le añadiremos el valor</param>
        /// <returns></returns>
        public static object PropertyGetValue(object obj, string property)
        {
            object value = null;
            try
            {
                Type tipo = obj.GetType();

                foreach (PropertyInfo info in tipo.GetProperties())
                {
                    if (info.Name == property)
                    {
                        value = info.GetValue(obj);
                    }
                }
            }
            catch (SAException e)
            {
                ErrorsDB.MessageError(e);
            }
            return value;        
        }

        /// <summary>
        /// Convierte una GenericObservableCollection en un DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static DataTable ObsCollectionToDataTable<T>(GenericObservableCollection collection)
        {
            DataTable datatable = new DataTable();
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
            foreach (var item in collection.GenericObsCollection)
            {
                datarow = datatable.NewRow();
                datarow.BeginEdit();

                for (int i = 0; i < properties.Length; i++)
                {
                    temp = properties[i].GetValue(item, null);
                    if (temp == null || (temp.GetType().Name == "Char" && ((char)temp).Equals('\0')))
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
            return datatable;
        }

        /// <summary>
        /// Convierte un DataRowView en un object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <returns></returns>
        public static T DataRowViewToObject<T>(DataRowView datarowview) where T : new()
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
    }
}
