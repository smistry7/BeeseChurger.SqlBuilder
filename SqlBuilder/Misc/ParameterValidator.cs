using System;
using System.Collections.Generic;
using System.Text;

namespace BeeseChurger.SqlBuilder.Misc
{
    /// <summary>
    /// ParameterValidator class
    /// 
    /// This class contains extension methods to validate SQL parameters.
    /// </summary>
    public static class ParameterValidator
    {
        /// <summary>
        /// Check if the given string contains any SQL injection keywords.
        /// </summary>
        /// <param name="userInput">String to be passed as a parameter.</param>
        /// <returns>True if it does contain any of the keywords, False if not.</returns>
        public static bool ContainsSqlInjection(this string userInput)
        {
            bool isSQLInjection = false;
            string[] sqlCheckList = {"--",";--",";","/*","*/","@@","@","char","nchar","varchar","nvarchar",
                "alter","begin","cast","create","cursor", "declare","delete","drop","end","exec","execute",
                "fetch","insert","kill","select","sys","sysobjects","syscolumns","table","update"
            };

            string CheckString = userInput.Replace("'", "''");

            for (int i = 0; i <= sqlCheckList.Length - 1; i++)
            {
                if ((CheckString.IndexOf(sqlCheckList[i], StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    isSQLInjection = true;
                }
            }
            return isSQLInjection;
        }
        /// <summary>
        /// Checks all arguments in a formattable string for SQL injection.
        /// </summary>
        /// <param name="str">Formattable string to be passed to the database.</param>
        /// <returns>True if it does contain any of the keywords, False if not.</returns>
        public static bool ContainsSqlInjection(this FormattableString str)
        {
            bool containsSqlInjection = false;
            var args = str.GetArguments();
            foreach (var arg in args)
            {
                if (arg.ToString().ContainsSqlInjection())
                {
                    containsSqlInjection = true;
                }
            }
            return containsSqlInjection;
        }
    }
}
