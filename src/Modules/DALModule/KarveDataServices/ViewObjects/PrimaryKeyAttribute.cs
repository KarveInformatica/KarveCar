using System;
using System.Reflection;

namespace KarveDataServices.ViewObjects
{
     public class PrimaryKeyAttribute : Attribute
    {
        public static PropertyInfo SearchAttribute<T>(T entity)
        {
            PropertyInfo var = null;
            if (entity != null)
            {

                PropertyInfo[] props = entity.GetType().GetProperties();
                foreach (PropertyInfo prop in props)
                {
                        object[] attrs = prop.GetCustomAttributes(true);
                        foreach (object attr in attrs)
                        {
                            PrimaryKeyAttribute key = attr as PrimaryKeyAttribute;
                            if ((key != null))
                            {
                                return prop;
                            }
                        }
                }
               var = props[0];
            }
            return var;
        }
    }
}