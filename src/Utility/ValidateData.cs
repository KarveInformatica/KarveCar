using System;

namespace KarveCar.Utility
{
    public class ValidateData
    {
        #region string
        public static void SetString(string value, out bool tryparse, out object datagridvalue)
        {
            tryparse = string.IsNullOrWhiteSpace(value) ? false : true;
            datagridvalue = tryparse ? value : datagridvalue = null;
        }

        public static string GetString(string value)
        {
            try
            {
                return string.IsNullOrWhiteSpace(value) ? string.Empty : value;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        #endregion

        #region char
        public static void SetChar(string value, out bool tryparse, out object datagridvalue)
        {
            char charValue;
            tryparse = char.TryParse(value, out charValue);
            datagridvalue = tryparse ? char.Parse(value) : datagridvalue = null;
        }
        public static char GetChar(char value)
        {
            try
            {
                return value;
            }
            catch (Exception)
            {
                return '\0';
            }
        }
        public static char GetChar(char? value)
        {
            try
            {
                if (value == null || value == '\0')
                {
                    return '\0';
                }
                else
                {
                    return (char) value;
                }
                //return value == null ? ' ' : (char)value; //DBNull.Value : value;
            }
            catch (Exception)
            {
                return '\0'; //(object)DBNull.Value;
            }
        }
        #endregion

        #region bool
        public static void SetBool(string value, out bool tryparse, out object datagridvalue)
        {
            bool charValue;
            tryparse = bool.TryParse(value, out charValue);
            datagridvalue = tryparse ? bool.Parse(value) : datagridvalue = null;
        }
        #endregion

        #region Byte
        public static void SetByte(string value, out bool tryparse, out object datagridvalue)
        {
            byte byteValue;
            tryparse = byte.TryParse(value, out byteValue);
            datagridvalue = tryparse ? byte.Parse(value) : datagridvalue = null;
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
                return value.HasValue ? value : null; //(object)DBNull.Value;
            }
            catch (Exception)
            {
                return null; //(object)DBNull.Value;
            }
        }
        #endregion

        #region short
        public static void SetShort(string value, out bool tryparse, out object datagridvalue)
        {
            short shortValue;
            tryparse = short.TryParse(value, out shortValue);
            datagridvalue = tryparse ? short.Parse(value) : datagridvalue = null;
        }

        public static short GetShort(short value)
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

        public static object GetShort(short? value)
        {
            try
            {
                return value.HasValue ? value : null; //(object)DBNull.Value;
            }
            catch (Exception)
            {
                return null; //(object)DBNull.Value;
            }
        }
        #endregion
        
        #region int
        public static void SetInt(string value, out bool tryparse, out object datagridvalue)
        {
            int intValue;
            tryparse = int.TryParse(value, out intValue);
            datagridvalue = tryparse ? int.Parse(value) : datagridvalue = null;
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
                return value.HasValue ? value : null; //(object)DBNull.Value;
            }
            catch (Exception)
            {
                return null; //(object)DBNull.Value;
            }
        }
        #endregion

        #region long
        public static void SetLong(string value, out bool tryparse, out object datagridvalue)
        {
            long longValue;
            tryparse = long.TryParse(value, out longValue);
            datagridvalue = tryparse ? long.Parse(value) : datagridvalue = null;
        }

        public static long GetLong(long value)
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

        public static object GetLong(long? value)
        {
            try
            {
                return value.HasValue ? value : null; //(object)DBNull.Value;
            }
            catch (Exception)
            {
                return null; //(object)DBNull.Value;
            }
        }
        #endregion

        #region decimal
        public static void SetDecimal(string value, out bool tryparse, out object datagridvalue)
        {
            decimal decimalValue;
            tryparse = decimal.TryParse(value, out decimalValue);
            datagridvalue = tryparse ? decimal.Parse(value) : datagridvalue = null;
        }

        public static decimal GetDecimal(decimal value)
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

        public static object GetDecimal(decimal? value)
        {
            try
            {
                return value.HasValue ? value : null; //(object)DBNull.Value;
            }
            catch (Exception)
            {
                return null; //(object)DBNull.Value;
            }
        }
        #endregion

        #region double
        public static void SetDouble(string value, out bool tryparse, out object datagridvalue)
        {
            double doubleValue;
            tryparse = double.TryParse(value, out doubleValue);
            datagridvalue = tryparse ? double.Parse(value) : datagridvalue = null;
        }

        public static double GetDouble(double value)
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

        public static object GetDouble(double? value)
        {
            try
            {
                return value.HasValue ? value : null; //(object)DBNull.Value;
            }
            catch (Exception)
            {
                return null; //(object)DBNull.Value;
            }
        }
        #endregion

        #region Date
        public static void SetDate(string value, out bool tryparse, out object datagridvalue)
        {
            DateTime doubleValue;
            tryparse = DateTime.TryParse(value, out doubleValue);
            datagridvalue = tryparse ? DateTime.Parse(value) : datagridvalue = null;
        }

        public static DateTime GetDate(DateTime value)
        {
            return value;
        }

        public static object GetDate(DateTime? value)
        {
            try
            {
                return value.HasValue ? value : null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }
}
