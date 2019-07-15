using System;

namespace Dominos.Common.Helpers
{
    public static class ValueTypeHelper
    {
        public static bool IsNull(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsNotNull(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public static bool IsNotNull(this DateTime value)
        {
            return (value != null && value != default(DateTime)) ? true : false;
        }

        public static bool IsNull(this DateTime value)
        {
            return (value == null || value == default(DateTime)) ? true : false;
        }

        public static int ToInt(this object value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return (int)decimal.MinusOne;
            }
        }

        public static string AddBearerIfNotExist(this string value)
        {
            if (value != null && !value.ToLower().StartsWith("bearer"))
            {
                value = $"bearer {value}";
            }
            return value;
        }

        public static string RemoveBearerIfExist(this string value)
        {
            if (value != null && value.ToLower().StartsWith("bearer"))
            {
                value = value.ToLower().Replace("bearer", "").Trim();
            }
            return value;
        }

        public static string ToUpperFirstChar(this string value)
        {
            if (value.IsNotNull())
            {
                var firstChar = value[0].ToString().ToUpper();
                value = $"{firstChar}{value.Substring(1)}";
            }
            return value;
        }
    }
}