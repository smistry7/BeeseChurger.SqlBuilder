using System;
using System.Collections.Generic;
using System.Text;

namespace BeeseChurger.SqlBuilder.Misc
{
    public static class ParameterValidator
    {
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
