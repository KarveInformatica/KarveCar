using iAnywhere.Data.SQLAnywhere;
using KarveCar.Model.Generic;
using KarveCar.Model.Sybase;
using KarveCommon.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using DataAccessLayer.DataObjects;
using KarveCar.Properties;
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
                        bool salir = false;
                        foreach (var item in templateinfodb)
                        {   //Se comprueba que el tipo de la propiedad del objeto recibido por params esté incluida en el List<TemplateInfoDB> templateinfodb
                            if (item.nombrepropiedadobj == prop.Name)
                            {   //Se añade el dato recuperado de la DB mediante el SADataReader a la propiedad(item.nombrepropiedadobj) 
                                //del nuevo objeto(newobj), validando el dato según su tipo(ValidateData.***)
                                switch (item.tipodatocolumnadb)
                                {
                                    case ETiposDatoColumnaDB.DBstring:
                                        PropertySetValue(newobj, item.nombrepropiedadobj, ValidateData.GetString(dr[item.nombrecolumnadb] as string));
                                        salir = true;
                                        break;
                                    case ETiposDatoColumnaDB.DBchar:
                                        PropertySetValue(newobj, item.nombrepropiedadobj, ValidateData.GetChar(dr[item.nombrecolumnadb] as char?));
                                        salir = true;
                                        break;
                                    case ETiposDatoColumnaDB.DBbool:
                                        salir = true;
                                        break;
                                    case ETiposDatoColumnaDB.DBbyte: //byte en C# = tinyint en la DB
                                        PropertySetValue(newobj, item.nombrepropiedadobj, ValidateData.GetByte(dr[item.nombrecolumnadb] as byte?));
                                        salir = true;
                                        break;
                                    case ETiposDatoColumnaDB.DBshort:
                                        PropertySetValue(newobj, item.nombrepropiedadobj, ValidateData.GetShort(dr[item.nombrecolumnadb] as short?));
                                        salir = true;
                                        break;
                                    case ETiposDatoColumnaDB.DBint:
                                        PropertySetValue(newobj, item.nombrepropiedadobj, ValidateData.GetInt(dr[item.nombrecolumnadb] as int?));
                                        salir = true;
                                        break;
                                    case ETiposDatoColumnaDB.DBlong:
                                        PropertySetValue(newobj, item.nombrepropiedadobj, ValidateData.GetLong(dr[item.nombrecolumnadb] as long?));
                                        salir = true;
                                        break;
                                    case ETiposDatoColumnaDB.DBdecimal:
                                        PropertySetValue(newobj, item.nombrepropiedadobj, ValidateData.GetDecimal(dr[item.nombrecolumnadb] as decimal?));
                                        salir = true;
                                        break;
                                    case ETiposDatoColumnaDB.DBdouble:
                                        PropertySetValue(newobj, item.nombrepropiedadobj, ValidateData.GetDouble(dr[item.nombrecolumnadb] as double?));
                                        salir = true;
                                        break;
                                    case ETiposDatoColumnaDB.DBdate:
                                        PropertySetValue(newobj, item.nombrepropiedadobj, ValidateData.GetDate(dr[item.nombrecolumnadb] as DateTime?));
                                        salir = true;
                                        break;
                                    case ETiposDatoColumnaDB.DBdatetime:
                                        salir = true;
                                        break;
                                    case ETiposDatoColumnaDB.DBsmalldatetime:
                                        salir = true;
                                        break;
                                    case ETiposDatoColumnaDB.DBtime:
                                        salir = true;
                                        break;
                                    default:
                                        break;
                                }
                                if (salir) break;
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
        public static string PropertyConvertToDictionary(object obj, params string[] properties)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            try
            {
                Type tipo = obj.GetType();

                foreach (PropertyInfo info in tipo.GetProperties())
                {
                    if (!properties.Contains(info.Name))
                    {
                        dic.Add(info.Name, PropertyGetValue(obj, info.Name));
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
                        break;
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
                        break;
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
        /// Compara dos object, excepto las propiedades pasadas por params
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public static bool CompareObjectsExceptProperty<T>(T obj1, T obj2, params string[] properties)
        {
            foreach (PropertyInfo info in typeof(T).GetProperties())
            {

                if (properties.Contains(info.Name))
                {
                    continue;
                }
                    
                object propObj1 = info.GetGetMethod().Invoke(obj1, null);
                object propObj2 = info.GetGetMethod().Invoke(obj2, null);

                if (propObj1 == null)
                {
                    if (propObj2 != null)
                    {
                        return false;
                    }
                }
                else
                {
                    if (!propObj1.Equals(propObj2))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Crea un Clone de un object
        /// </summary>
        /// <param name="objSource"></param>
        /// <returns></returns>
        public static object CloneObject(object objSource)
        {
            //step : 1 Get the type of source object and create a new instance of that type
            Type typeSource = objSource.GetType();
            object objTarget = Activator.CreateInstance(typeSource);

            //Step2 : Get all the properties of source object type
            PropertyInfo[] propertyInfo = typeSource.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            //Step : 3 Assign all source property to taget object's properties
            foreach (PropertyInfo property in propertyInfo)
            {
                //Check whether property can be written to
                if (property.CanWrite)
                {
                    //Step : 4 check whether property type is value type, enum or string type
                    if (property.PropertyType.IsValueType || property.PropertyType.IsEnum || property.PropertyType.Equals(typeof(System.String)))
                    {
                        property.SetValue(objTarget, property.GetValue(objSource, null), null);
                    }
                    //else property type is object/complex types, so need to recursively call this method until the end of the tree is reached
                    else
                    {
                        object objPropertyValue = property.GetValue(objSource, null);
                        if (objPropertyValue == null)
                        {
                            property.SetValue(objTarget, null, null);
                        }
                        else
                        {
                            property.SetValue(objTarget, CloneObject(objPropertyValue), null);
                        }
                    }
                }
            }
            return objTarget;
        }

        /// <summary>
        /// Comprueba si el codigo está vacío, o si el registro (DataRowView) está repetido
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="datarowview"></param>
        /// <returns></returns>
        public static bool CheckCodigo(string codigo, DataRowView datarowview)
        {
            bool exists = false;

            if (codigo.Equals(string.Empty)  || codigo == null)
            {
                MessageBox.Show(Resources.msgInsertarRegistroCampoVacio, Resources.msgInsertarRegistroTitulo,
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                exists = true;
            }
            else if (datarowview != null)
            {
                MessageBox.Show(Resources.msgInsertarRegistroRepetido, Resources.msgInsertarRegistroTitulo,
                                MessageBoxButton.OK, MessageBoxImage.Error);                
                exists = true;
            }

            return exists;
        }

        /// <summary>
        /// Se eliminan los espacios en blanco y de SqlInjection (' /* */ -- ;) del codigo
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public static string GetCodigo(string codigo)
        {
            return codigo.Replace(" ", string.Empty)
                         .Replace("'", string.Empty)
                         .Replace("--", string.Empty)
                         .Replace("/*", string.Empty)
                         .Replace("*/", string.Empty)
                         .Replace(";", string.Empty);
        }

        public static string GetUsuario()
        {
            return "CV";//UserAndDefaultConfig.GetSetting("User");
        }

        public static string GetUltModi()
        {
            DateTime ultmodi = DateTime.Now;
            return ultmodi.ToString("yyyyMMddHH:mm");
        }

        public static string GetDateTimeToString(DateTime? date)
        {
            return (date == null || date.Value.ToString() == string.Empty) ? "NULL" : "'" + date.Value.ToString("yyyy/MM/dd") + "'";
        }
    }
}
