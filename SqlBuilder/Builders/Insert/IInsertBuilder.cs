using System.Collections.Generic;

namespace BeeseChurger.SqlBuilder.Builders.Insert
{
    public interface IInsertBuilder
    {
        IValuesBuilder InsertInto(string table, IEnumerable<string> columns);
    }
}