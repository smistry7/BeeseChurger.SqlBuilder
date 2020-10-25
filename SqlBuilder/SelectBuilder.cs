using SqlBuilder.Interfaces;
using System.Text;

namespace SqlBuilder
{
    public class SelectBuilder : ISelectBuilder, IFromBuilder, IWhereBuilder, IJoinBuilder, IOrderByBuilder
    {
        private StringBuilder _sql;

        public SelectBuilder()
        {
            _sql = new StringBuilder();
        }

        public ISelectBuilder Select(string select)
        {
            _sql.Append($"SELECT {select} ");
            return this;
        }

        public IFromBuilder From(string table)
        {
            _sql.Append($"FROM {table} ");
            return this;
        }

        public IWhereBuilder Where(string where)
        {
            _sql.Append($"WHERE {where} ");
            return this;
        }

        public IWhereBuilder And(string where)
        {
            _sql.Append($"AND {where} ");
            return this;
        }

        public IWhereBuilder Or(string where)
        {
            _sql.Append($"OR {where} ");
            return this;
        }

        public IJoinBuilder InnerJoin(string joiningTable)
        {
            _sql.Append($"INNER JOIN {joiningTable} ");
            return this;
        }

        public IJoinBuilder RightJoin(string joiningTable)
        {
            _sql.Append($"RIGHT JOIN {joiningTable} ");
            return this;
        }

        public IJoinBuilder LeftJoin(string joiningTable)
        {
            _sql.Append($"LEFT JOIN {joiningTable} ");
            return this;
        }

        public IFromBuilder On(string on)
        {
            _sql.Append($"ON {on} ");
            return this;
        }

        public IOrderByBuilder OrderBy(string field)
        {
            _sql.Append($"ORDER BY {field} ");
            return this;
        }

        public IFromBuilder Ascending()
        {
            _sql.Append("ASC ");
            return this;
        }

        public IFromBuilder Descending()
        {
            _sql.Append("DESC ");
            return this;
        }

        public string Build()
        {
            return _sql.ToString();
        }
    }
}