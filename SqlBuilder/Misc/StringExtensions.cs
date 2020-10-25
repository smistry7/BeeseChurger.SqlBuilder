using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Misc
{
    public static class StringExtensions
    {
        public static string ToSqlParameter(this object parameter)
        {
            string returnString;
            if (parameter is string || parameter is DateTime)
            {
                returnString = $"'{parameter}'";
            }
            else
            {
                returnString = parameter.ToString();
            }
            return returnString;
        }
    }
}
