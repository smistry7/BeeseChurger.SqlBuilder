using System;
using System.Collections.Generic;
using System.Text;

namespace BeeseChurger.SqlBuilder.Misc
{
    /// <summary>
    /// The SqlInjectionException class.
    /// 
    /// Exception class to be thrown if a SQL Injection is attempted.
    /// </summary>
    public class SqlInjectionException : Exception
    {
        /// <inheritdoc/>
        public SqlInjectionException()
        {

        }
        /// <inheritdoc/>
        public SqlInjectionException(string message) : base(message)
        {

        }
    }
}
