using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using KarveCommon.Generic;

namespace KarveCommon.Generic
{
    public class GenericObjectHelper
    {      
        static readonly string HelperColumn = "ControlCambioDataGrid"; 

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
                    if (!info.Name.ToString().Equals(GenericObjectHelper.HelperColumn))
                    {
                        dic.Add(info.Name.ToString(), PropertyGetValue(obj, info.Name.ToString()));
                    }                    
                }                
            }
            catch (Exception e)
            {
                // FIXME: antipattern.
                throw e;
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
            catch (Exception e)
            {
                throw new KarveCommonException(e.Message);
                // FIXME: fixed the exception handling .
                //ErrorsDB.MessageError(e);
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
            catch (Exception e)
            {
                throw  new KarveCommonException(e.Message);
                //ErrorsDB.MessageError(e);
            }
            return value;        
        }
    }
}
