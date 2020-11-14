using System.Collections.Generic;

namespace BeeseChurger.SqlBuilder.Builders.Insert
{
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
    }
}