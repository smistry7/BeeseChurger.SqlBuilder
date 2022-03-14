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
        public static string HandleSqlInjection(this string userInput)
        {
            string[] sqlCheckList = { "--",";--",";","/*","*/","@@" };

            string CheckString = userInput.Replace("'", "''");

            for (int i = 0; i <= sqlCheckList.Length - 1; i++)
            {
                if (CheckString.IndexOf(sqlCheckList[i], StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    CheckString = CheckString.Replace(sqlCheckList[i], "");
                }
            }
            return CheckString;
        }
        /// <summary>
        /// Checks all arguments in a formattable string for SQL injection.
        /// </summary>
        /// <param name="str">Formattable string to be passed to the database.</param>
        /// <returns>True if it does contain any of the keywords, False if not.</returns>
        public static string HandleSqlInjection(this FormattableString str)
        {
            var args = str.GetArguments();
            var result = "";
            for (int i = 0; i < args.Length; i++)
            {
                var newArg = str.GetArgument(i).ToSqlParameter();
                result = str.ToString().Replace(str.GetArgument(i)!.ToString(), newArg.ToString());
            }
            if(args.Length == 0)
            {
                result = str.ToString();
            }
            return result;
        }
    }
}
