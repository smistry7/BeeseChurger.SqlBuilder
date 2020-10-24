using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SqlBuilder.Tests
{
    public class SelectBuilderTests
    {
        [Fact]
        public void BuildReturnsCorrectString()
        {
            var builder = new SelectBuilder()
                .Select("*")
                .From("table")
                .Where("x = 2")
                .And("y = 'John'");
            builder.Build().Should().Be("SELECT * FROM table WHERE x = 2 AND y = 'John' ");
        }
        [Fact]
        public void BuildReturnsCorrectStringWithJoin()
        {
            var builder = new SelectBuilder()
                .Select("*")
                .From("table1 t1")
                .InnerJoin("table2 t2")
                .On("t1.name = t2.name");
            builder.Build().Should().Be("SELECT * FROM table1 t1 INNER JOIN table2 t2 ON t1.name = t2.name ");
        }
        [Fact]
        public void BuildReturnsCorrectStringWithOrderBy()
        {
            var builder = new SelectBuilder()
                .Select("*")
                .From("table1")
                .Where("id = 1")
                .OrderBy("AddedDate")
                .Ascending();
            builder.Build().Should().Be("SELECT * FROM table1 WHERE id = 1 ORDER BY AddedDate ASC ");
        }
    }
}
