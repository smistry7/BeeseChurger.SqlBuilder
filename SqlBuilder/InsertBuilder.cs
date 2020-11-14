using BeeseChurger.SqlBuilder.Builders;
using BeeseChurger.SqlBuilder.Builders.Insert;
using BeeseChurger.SqlBuilder.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeseChurger.SqlBuilder
{
    public class InsertBuilder : IInsertBuilder, IValuesBuilder
    {
        private StringBuilder _sql;
        public InsertBuilder()
        {
            _sql = new StringBuilder();
        }
        public IValuesBuilder InsertInto(string table, IEnumerable<string> columns)
        {
            _sql.Append($"INSERT INTO {table} (");
            foreach(var column in columns)
            {
                _sql.Append($"{column}, ");
            }
            _sql.RemoveTrailingComma();
            _sql.Append(") ");
            return this;
        }

        public ISqlQueryBuilder Values(object[] values)
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
