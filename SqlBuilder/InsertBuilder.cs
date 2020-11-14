using BeeseChurger.SqlBuilder.Builders;
using BeeseChurger.SqlBuilder.Builders.Insert;
using BeeseChurger.SqlBuilder.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeseChurger.SqlBuilder
{
    public sealed class InsertBuilder : IValuesBuilder
    {
        private StringBuilder _sql;
        private InsertBuilder(string table, IEnumerable<string> columns)
        {
            _sql = new StringBuilder();
            _sql.Append($"INSERT INTO {table} (");
            foreach (var column in columns)
            {
                _sql.Append($"{column}, ");
            }
            _sql.RemoveTrailingComma();
            _sql.Append(") ");
        }

        public static IValuesBuilder InsertInto(string table, IEnumerable<string> columns)
        {

            return new InsertBuilder(table, columns);
        }

        public ISqlQueryBuilder Values(IEnumerable<object> values)
        {
            _sql.Append("VALUES (");
            foreach(var value in values)
            {
                _sql.Append($"{value.ToSqlParameter()}, ");
            }
            _sql.RemoveTrailingComma();
            _sql.Append(") ");
            return this;
        }

        public string Build()
        {
            _sql.Append(";");
            return _sql.ToString();
        }
    }
}
