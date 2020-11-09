using System;
using System.Data;
using System.Runtime.CompilerServices;

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
        public static string ToSqlParameter(this object str, SqlDbType dbType)
        {
            string returnString;
            switch (dbType)
            {
                case SqlDbType.VarChar:
                    returnString = $"'{str}'";
                    break;
                case SqlDbType.DateTime:
                    returnString = $"'{((DateTime)str).ToString("yyyy-MM-dd h:mm tt")}'";
                    break;
                default:
                    returnString = $"{str}";
                    break;
            }
            return returnString;
        }

    }
}