using System;

namespace BeeseChurger.SqlBuilder.Builders.Delete
{
    public interface IWhereBuilder : ISqlQueryBuilder
    {
        /// <summary>
        /// The And Method
        /// 
        /// Use this method after a where to add an AND expression
        /// </summary>
        /// <param name="where">string representation of the and expression</param>
        IWhereBuilder And(FormattableString where);
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
        IWhereBuilder Or(FormattableString where);
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
