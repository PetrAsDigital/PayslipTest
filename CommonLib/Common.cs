using System;

namespace CommonLib
{
    public class Common
    {
        public static int ConvertToInt(string value)
        {
            int result;

            if (!int.TryParse(value, out result))
                throw new Exception($"Cannot convert {value} to Integer!");

            return result;
        }

        public static double ConvertToDouble(string value)
        {
            double result;

            if (!double.TryParse(value, out result))
                throw new Exception($"Cannot convert {value} to Double!");

            return result;
        }

        public static DateTime ConvertToDateTime(string value)
        {
            DateTime result;

            if (!DateTime.TryParse(value, out result))
                throw new Exception($"Cannot convert {value} to DateTime!");

            return result;
        }
    }
}
