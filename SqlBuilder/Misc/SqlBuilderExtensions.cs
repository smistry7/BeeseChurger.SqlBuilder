using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace BeeseChurger.SqlBuilder.Misc
{
    /// <summary>
    /// The SqlBuilderHelper class
    /// </summary>
    public static class SqlBuilderExtensions
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
                parameter = parameter.ToString().HandleSqlInjection();
                returnString = $"'{parameter}'";
            }
            else if (parameter is DateTime)
            {
                returnString = $"'{((DateTime)parameter).ToString("s")}'";
            }
            else if (parameter is bool)
            {
                returnString = (bool)parameter ? "1" : "0";
            }
            else
            {
                returnString = parameter.ToString();
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
                    parameter = parameter.ToString().HandleSqlInjection();
                    returnString = $"'{parameter}'";
                    break;
                case SqlDbType.DateTime:
                    returnString = $"'{((DateTime)parameter).ToString("s")}'";
                    break;
                case SqlDbType.Bit:
                    returnString = (bool)parameter ? "1" : "0";
                    break;
                default:
                    returnString = $"{parameter}";
                    break;
            }
            return returnString;
        }

        /// <summary>
        /// This can be used to convert a list to an in clause when using any of the Builders
        /// </summary>
        /// <typeparam name="T">Type of collection being used</typeparam>
        /// <param name="list"></param>
        /// <returns>String representation to be passed to the database as an in clause</returns>
        public static string ToInClause<T>(this IEnumerable<T> list)
        {
            var arr = list.Select(x => x.ToSqlParameter()).ToArray();
            var values = $"({string.Join(",", arr)})";
            return values;
        }
    }
}