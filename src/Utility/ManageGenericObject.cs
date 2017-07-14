using iAnywhere.Data.SQLAnywhere;
using KRibbon.Model.Generic;
using KRibbon.Model.Sybase;
using System;
using System.Collections.Generic;
using System.Reflection;
using static KRibbon.Model.Generic.RecopilatorioEnumerations;

namespace KRibbon.Utility
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
        {   //Se crea el GenericObservableCollection auxiliar que se devolverá, donde se irá añadiendo la info recuperada de la BBDD (SADataReader dr)
            GenericObservableCollection auxobscollection = new GenericObservableCollection();
            //Se recorre el SADataReader para obtener sus valores según el tipo de objeto recibido por params
            while (dr.Read())
            {   //Se recuperan las propiedades e instanciamos un nuevo objeto del tipo del objeto recibido por params
                var properties = GetProperties(obj);
                object newobj  = CreateObject(obj);

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
                                case ETiposDatoColumnaDB.DBbool:
                                    break;
                                case ETiposDatoColumnaDB.DBbyte: //byte en C# = tinyint en la DB
                                    PropertySetValue(newobj, item.nombrepropiedadobj, ValidateData.GetByte(dr[item.nombrecolumnadb] as byte?));
                                    break;
                                case ETiposDatoColumnaDB.DBsmallint:
                                    break;
                                case ETiposDatoColumnaDB.DBint:
                                    PropertySetValue(newobj, item.nombrepropiedadobj, ValidateData.GetInt(dr[item.nombrecolumnadb] as int?));
                                    break;
                                case ETiposDatoColumnaDB.DBlong:
                                    break;
                                case ETiposDatoColumnaDB.DBdecimal:
                                    break;
                                case ETiposDatoColumnaDB.DBdouble:
                                    break;
                                case ETiposDatoColumnaDB.DBdate:
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
            return auxobscollection;
        }

        /// <summary>
        /// Crea un objeto del tipo del objeto(objoriginal) pasado por params
        /// </summary>
        /// <typeparam name="T">Tipo genérico de la class del objeto</typeparam>
        /// <param name="objoriginal">Objeto original del cual instanciaremos un nuevo objeto según su tipo</param>
        /// <returns></returns>
        private static T CreateObject<T>(T objoriginal)
        {
            //T newobject = (T)Activator.CreateInstance(objoriginal.GetType());
            //foreach (var prop in objoriginal.GetType().GetProperties())
            //{
            //    prop.SetValue(newobject, prop.GetValue(objoriginal, null), null);
            //}

            return (T)Activator.CreateInstance(objoriginal.GetType()); //newobject;
        }

        /// <summary>
        /// Devuelve una colección de las propiedades del objeto(obj) pasado por params
        /// </summary>
        /// <param name="obj">Objeto del cual obtendremos una colección de sus propiedades</param>
        /// <returns></returns>
        private static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }

        /// <summary>
        /// Añade un valor(value) recuperado de la DB mediante el SADataReader, a la propiedad(nombrepropiedadobj) 
        /// pasada por params del objeto(obj) pasado también por params
        /// </summary>
        /// <param name="obj">El objeto al cual añadimos el valor recuperado desde el SADataReader</param>
        /// <param name="nombrepropiedad">Nombre de la propiedad del objeto a la cual le añadiremos el valor recuperado desde el SADataReader</param>
        /// <param name="value">Valor recuperado desde el SADataReader, que añadiremos al objeto</param>
        private static void PropertySetValue(object obj, string nombrepropiedad, object value)
        {
            try
            {
                Type tipo = obj.GetType();
                foreach (PropertyInfo info in tipo.GetProperties())
                {
                    if (info.Name == nombrepropiedad)
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
    }
}
