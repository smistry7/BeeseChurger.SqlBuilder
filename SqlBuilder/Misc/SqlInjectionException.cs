using System;
using System.Collections.Generic;
using System.Text;

namespace BeeseChurger.SqlBuilder.Misc
{
    public class SqlInjectionException : Exception
    {
        public SqlInjectionException()
        {

        }
        public SqlInjectionException(string message) : base(message)
        {

        }
    }
}
