using BeeseChurger.SqlBuilder.Builders;
using BeeseChurger.SqlBuilder.Builders.Select;
using BeeseChurger.SqlBuilder.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeseChurger.SqlBuilder
{
    /// <summary>
    /// The SelectBuilder fluent builder class.
    /// </summary>
    public sealed class SelectBuilder : ISelectBuilder, IFromBuilder, IWhereBuilder, IJoinBuilder, IOrderByBuilder
    {
        private StringBuilder _sql;

        private SelectBuilder()
        {
            _sql = new StringBuilder();
            _sql.Append("SELECT ");
        }
        /// <summary>
        /// The Init Method 
        /// 
        /// Use this to initialise a new SelectBuilder statement.
        /// </summary>
        /// <returns></returns>
        public static ISelectBuilder Init() => new SelectBuilder();

        /// <inheritdoc/>
        public ISelectBuilder Select(string select)
        {
            _sql.Append($"{select}, ");
            return this;
        }

        /// <inheritdoc/>
        public IFromBuilder From(string table)
        {
            _sql.RemoveTrailingComma();
            _sql.Append($"FROM {table} ");
            return this;
        }

        /// <inheritdoc/>
        public IWhereBuilder Where(FormattableString where)
        {
            _sql.Append($"WHERE {where.HandleSqlInjection()} ");
            return this;
        }

        

        /// <inheritdoc/>
        public IWhereBuilder Where(string field, object value)
        {
            if (value != null)
            {
                _sql.Append($"WHERE {field} = {value.ToSqlParameter()} ");
            }
            return this;
        }
        /// <inheritdoc/>
        public IWhereBuilder WhereIn<T>(string field, IEnumerable<T> list)
        {
            _sql.Append($"WHERE {field} IN {list.ToInClause()} ");
            return this;
        }

        /// <inheritdoc/>
        public IWhereBuilder And(FormattableString where)
        {
            if (_sql.ToString().Contains("WHERE"))
            {
                _sql.Append($"AND {where.HandleSqlInjection()} ");
            }
            else
            {
                Where(where);
            }

            return this;
        }

        /// <inheritdoc/>
        public IWhereBuilder And(string field, object value)
        {
            if (value != null)
            {
                if (_sql.ToString().Contains("WHERE"))
                {
                    _sql.Append($"AND {field} = {value.ToSqlParameter()} ");
                }
                else
                {
                    Where(field, value);
                }
            }
            return this;
        }

        /// <inheritdoc/>
        public IWhereBuilder Or(FormattableString where)
        {
            if (_sql.ToString().Contains("WHERE"))
            {
                _sql.Append($"OR {where.HandleSqlInjection()} ");
            }
            else
            {
                Where(where);
            }
            return this;
        }

        /// <inheritdoc/>
        public IWhereBuilder Or(string field, object value)
        {
            if (value != null)
            {
                if (_sql.ToString().Contains("WHERE"))
                {
                    _sql.Append($"OR {field} = {value.ToSqlParameter()} ");
                }
                else
                {
                    Where(field, value);
                }
            }
            return this;
        }

        /// <inheritdoc/>
        public IJoinBuilder InnerJoin(string joiningTable)
        {
            _sql.Append($"INNER JOIN {joiningTable} ");
            return this;
        }

        /// <inheritdoc/>
        public IJoinBuilder RightJoin(string joiningTable)
        {
            _sql.Append($"RIGHT JOIN {joiningTable} ");
            return this;
        }

        /// <inheritdoc/>
        public IJoinBuilder LeftJoin(string joiningTable)
        {
            _sql.Append($"LEFT JOIN {joiningTable} ");
            return this;
        }

        /// <inheritdoc/>
        public IFromBuilder On(string on)
        {
            _sql.Append($"ON {on} ");
            return this;
        }

        /// <inheritdoc/>
        public IOrderByBuilder OrderBy(string field)
        {
            _sql.Append($"ORDER BY {field} ");
            return this;
        }

        /// <inheritdoc/>
        public IFromBuilder Ascending()
        {
            _sql.Append("ASC ");
            return this;
        }

        /// <inheritdoc/>
        public IFromBuilder Descending()
        {
            _sql.Append("DESC ");
            return this;
        }


        /// <inheritdoc/>
        public ISqlQueryBuilder Paginate(int pageNumber, int pageSize)
        {
            _sql.Append($"OFFSET {(pageNumber - 1) * pageSize} ROWS FETCH NEXT {pageSize} ROWS ONLY ");
            return this;
        }

        /// <inheritdoc/>
        public string Build()
        {
            _sql.Append(";");
            return _sql.ToString();
        }

   
    }
}