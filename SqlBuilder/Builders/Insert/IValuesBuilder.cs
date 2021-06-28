using System.Collections.Generic;

namespace BeeseChurger.SqlBuilder.Builders.Insert
{
    /// <summary>
    /// The IValuesBuilder interface.
    /// 
    /// To be used for adding values to your InsertBuilder
    /// </summary>
    public interface IValuesBuilder : ISqlQueryBuilder
    {
        /// <summary>
        /// The Values Method
        /// 
        /// Use this after an insert into method to provide the values to insert into the table.
        /// </summary>
        /// <param name="values">Collection of values in the order of the columns previously provided.</param>
        /// <returns></returns>
        ISqlQueryBuilder Values(IEnumerable<object> values);
        /// <summary>
        /// The Value Method
        /// 
        /// Use this to add a single value to your insert into command.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        IValuesBuilder Value(object value);
    }
}