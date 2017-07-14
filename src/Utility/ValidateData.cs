using iAnywhere.Data.SQLAnywhere;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KarveCar.Utility
{
    public class ValidateData
    {
        public static string GetString(string value)
        {
            try
            {
                return String.IsNullOrEmpty(value) ? "" : value;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static byte GetByte(byte value)
        {
            try
            {
                return value;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static object GetByte(byte? value)
        {
            try
            {
                return value.HasValue ? value : 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static int GetInt(int value)
        {
            try
            {
                return value;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static object GetInt(int? value)
        {
            try
            {
                return value.HasValue ? value : 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
