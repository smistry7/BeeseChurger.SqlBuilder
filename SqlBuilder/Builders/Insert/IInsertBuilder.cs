using System.Collections.Generic;

namespace BeeseChurger.SqlBuilder.Builders.Insert
{
    public interface IInsertBuilder
    {
        /// <summary>
        /// The Insert Into method
        /// 
        /// Use this to initialise an insert into query with a table and column names.
        /// </summary>
        /// <param name="table">string representation of the table name</param>
        /// <param name="columns">Collection of strings for each column in the table</param>
        IValuesBuilder InsertInto(string table, IEnumerable<string> columns);
    }
}