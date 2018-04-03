using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows;
using KarveCar.Properties;

namespace KarveCar.Utility
{

    /// <summary>
    ///  FIXME. This is literally crap. a bunch of helpers without no logic sense. 
    ///  I have not writtent this code.
    /// </summary>
    public class ManageGenericObject
    {
       
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
           
                Type tipo = obj.GetType();

                foreach (PropertyInfo info in tipo.GetProperties())
                {
                    if (!properties.Contains(info.Name))
                    {
                        dic.Add(info.Name, PropertyGetValue(obj, info.Name));
                    }                    
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

        /// <summary>
        /// Devuelve el valor(value) de la propiedad(nombrepropiedadobj) del objeto(obj) pasado por params
        /// </summary>
        /// <param name="obj">El objeto del cual recibimos el valor</param>
        /// <param name="property">Nombre de la propiedad del objeto a la cual le añadiremos el valor</param>
        /// <returns></returns>
        public static object PropertyGetValue(object obj, string property)
        {
            object value = null;
                Type tipo = obj.GetType();

                foreach (PropertyInfo info in tipo.GetProperties())
                {
                    if (info.Name == property)
                    {
                        value = info.GetValue(obj);
                        break;
                    }
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
