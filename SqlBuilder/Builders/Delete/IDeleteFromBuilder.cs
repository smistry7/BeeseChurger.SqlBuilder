using System;
using System.Collections.Generic;
using System.Text;

namespace BeeseChurger.SqlBuilder.Builders.Delete
{
    public interface IDeleteFromBuilder : ISqlQueryBuilder
    {
        /// <summary>
        /// The Where Method
        /// 
        /// Use this method to add a where expression 
        /// </summary>
        /// <example>
        /// This sample shows how to call the Where method.
        /// <code>
        /// builder.Where("Name LIKE '%abc%'");
        /// </code>
        /// </example>
        /// <param name="where">String representation of the where expression</param>
        IWhereBuilder Where(string where);
        /// <summary>
        /// The Where Method
        /// </summary>
        /// <example>
        /// This example shows how to call the where method
        /// <code>
        /// builder.Where("Name", "john");
        /// </code>
        /// </example>
        /// <param name="field">Field to be compared</param>
        /// <param name="value">Value the field should equal</param>
        IWhereBuilder Where(string field, object value);
    }
    public interface IWhereBuilder : ISqlQueryBuilder
    {
        /// <summary>
        /// The And Method
        /// 
        /// Use this method after a where to add an AND expression
        /// </summary>
        /// <param name="where">string representation of the and expression</param>
        IWhereBuilder And(string where);
        /// <summary>
        /// The And method
        /// 
        /// Use this method after a where to add an AND expression
        /// </summary>
        /// <param name="field">Field/column to compare</param>
        /// <param name="value">Value to set it equal to</param>
        IWhereBuilder And(string field, object value);
        /// <summary>
        /// The Or Method
        /// 
        /// Use this method after a where to add an OR expression
        /// </summary>
        /// <param name="where">string representation of the or expression</param>
        IWhereBuilder Or(string where);
        /// <summary>
        /// The Or method
        /// 
        /// Use this method after a where to add an OR expression
        /// </summary>
        /// <param name="field">Field/column to compare</param>
        /// <param name="value">Value to set it equal to</param>
        IWhereBuilder Or(string field, object value);

    }
}
