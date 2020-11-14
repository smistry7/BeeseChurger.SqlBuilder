using BeeseChurger.SqlBuilder.Builders;
using BeeseChurger.SqlBuilder.Builders.Update;
using BeeseChurger.SqlBuilder.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeseChurger.SqlBuilder
{
    public sealed class UpdateBuilder : IUpdateBuilder, ISetBuilder, IWhereBuilder
    {
        private StringBuilder _sql;
        private UpdateBuilder(string table)
        {
            _sql = new StringBuilder();
            _sql.Append($"UPDATE {table} SET ");
        }

        public static ISetBuilder Update(string table)
        {
            var builder = new UpdateBuilder(table);
            return builder;
        }
        public ISetBuilder Set(string sets)
        {
            _sql.Append($"{sets} ");
            return this;
        }
        public ISetBuilder Set(string field, object value)
        {
            _sql.Append($"{field} = {value.ToSqlParameter()}, ");
            return this;
        }
        public IWhereBuilder Where(string where)
        {
            _sql.RemoveTrailingComma();
            _sql.Append($"WHERE {where} ");
            return this;
        }
        public IWhereBuilder Where(string field, object value)
        {
            _sql.RemoveTrailingComma();
            _sql.Append($"WHERE {field} = {value.ToSqlParameter()} ");
            return this;
        }
        public IWhereBuilder And(string where)
        {
            _sql.Append($"AND {where} ");
            return this;
        }
        public IWhereBuilder And(string field, object value)
        {
            _sql.Append($"AND {field} = {value.ToSqlParameter()} ");
            return this;
        }
        public IWhereBuilder Or(string where)
        {
            _sql.Append($"AND {where} ");
            return this;
        }
        public IWhereBuilder Or(string field, object value)
        {
            _sql.Append($"AND {field} = {value.ToSqlParameter()} ");
            return this;
        }
        public string Build()
        {
             _sql.RemoveTrailingComma();
            _sql.Append(";");
            return _sql.ToString();
        }
       
    }
}
