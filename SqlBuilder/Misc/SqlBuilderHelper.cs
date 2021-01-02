using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;

namespace BeeseChurger.SqlBuilder.Misc
{
    /// <summary>
    /// The SqlBuilderHelper class
    /// </summary>
    public static class SqlBuilderHelper
    {
        /// <summary>
        /// The ToSqlParameter extension method
        /// 
        /// Extension method to convert an object to a string 
        /// representation of if you were to use it as a SQL parameter
        /// </summary>
        /// <param name="parameter">SQL Parameter to be converted</param>
        /// <returns>String representation of the parameter as a SQL parameter</returns>
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
            else if (parameter is bool)
            {
                returnString = (bool)parameter ? "1" : "0";
            }
            else
            {
                returnString = parameter.ToString();
            }
            if (returnString.ContainsSqlInjection())
            {
                throw new SqlInjectionException($"SQL Injection attempt: {returnString}");
            }
            return returnString;
        }
        /// <summary>
        /// The ToSqlParameter extension method
        /// 
        /// Extension method to convert an object to a string 
        /// representation of if you were to use it as a SQL parameter
        /// </summary>
        /// <param name="parameter">Sql Parameter to be converted.</param>
        /// <param name="dbType">Database type that it should be passed as.</param>
        /// <returns>String representation of the parameter to be passed to the database.</returns>
        public static string ToSqlParameter(this object parameter, SqlDbType dbType)
        {
            string returnString;
            switch (dbType)
            {
                case SqlDbType.VarChar:
                    returnString = $"'{parameter}'";
                    break;
                case SqlDbType.DateTime:
                    returnString = $"'{((DateTime)parameter).ToString("yyyy-MM-dd h:mm tt")}'";
                    break;
                case SqlDbType.Bit:
                    returnString = (bool)parameter ? "1" : "0";
                    break;
                default:
                    returnString = $"{parameter}";
                    break;
            }
            if (returnString.ContainsSqlInjection())
            {
                throw new SqlInjectionException($"SQL Injection attempt: {returnString}");
            }
            return returnString;
        }
        /// <summary>
        /// Extension method to remove a trailing comma
        /// Removes trailing comma at the second to last position in a string builder
        /// </summary>
        /// <param name="sb"></param>
        public static void RemoveTrailingComma(this StringBuilder sb)
        {
            if (sb.ToString().EndsWith(", "))
            {
                sb = sb.Remove(sb.Length - 2, 1);
            }
        }
        /// <summary>
        /// Check for SQLInjection and throw Exception if attempt is found.
        /// </summary>
        /// <param name="where">Formattable string to be passed to the database.</param>
        public static void CheckSqlInjection(FormattableString where)
        {
            if (where.ContainsSqlInjection())
            {
                throw new SqlInjectionException($"Sql injection attempt : {where}");
            }
        }
    }
}