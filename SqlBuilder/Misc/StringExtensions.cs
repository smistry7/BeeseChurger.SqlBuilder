using System;

namespace BeeseChurger.SqlBuilder.Misc
{
    public static class StringExtensions
    {
        public static string ToSqlParameter(this object parameter)
        {
            string returnString;
            if (parameter is string)
            {
                returnString = $"'{parameter}'";
            }
            else if (parameter is DateTime)
            {
                returnString = $"'{((DateTime)parameter).ToString("yyyy-MM-dd h:mm tt")}'";
            }
            else
            {
                returnString = parameter.ToString();
            }
            return returnString;
        }
    }
}