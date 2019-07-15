using System;

namespace Dominos.Common.Classes
{
    public static class Utility
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
    }
}