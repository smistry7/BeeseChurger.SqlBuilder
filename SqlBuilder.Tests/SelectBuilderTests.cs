﻿using FluentAssertions;
using Newtonsoft.Json.Converters;
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
        [Fact]
        public void BuildReturnsCorrectStringWithAndOr()
        {
            var builder = new SelectBuilder()
                .Select("*")
                .From("wherever")
                .Where("abc = 'xyz'")
                .And("cor = 12")
                .Or("x LIKE 'sad'");

            builder.Build().Should().Be("SELECT * FROM wherever WHERE abc = 'xyz' AND cor = 12 OR x LIKE 'sad' ");

        }
        [Fact]
        public void BuildReturnsCorrectStringKitchenSink()
        {
            var builder = new SelectBuilder()
                .Select("t1.blah")
                .From("table1 t1")
                .InnerJoin("table2 t2")
                .On("t1.id = t2.t1Id")
                .LeftJoin("table3 t3")
                .On("t1.id = t3.t1Id")
                .Where("t1.id = 4")
                .And("t1.name like 'Shyam'")
                .OrderBy("t2.field")
                .Ascending();
            builder.Build().Should()
                .Be("SELECT t1.blah FROM table1 t1 INNER JOIN table2 t2 ON t1.id = t2.t1Id " +
                "LEFT JOIN table3 t3 ON t1.id = t3.t1Id WHERE t1.id = 4 AND t1.name like 'Shyam' ORDER BY t2.field ASC ");

        }
    }
}