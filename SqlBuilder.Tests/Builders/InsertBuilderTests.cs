using FluentAssertions;
using System;
using System.Collections.Generic;
using BeeseChurger.SqlBuilder.Misc;
using Xunit;

namespace BeeseChurger.SqlBuilder.Tests.Builders
{
    public class InsertBuilderTests
    {
        [Fact]
        public void BuildShouldReturnCorrectString()
        {

            var dt = DateTime.Now;
            var builder = InsertBuilder
                .InsertInto("table", new string[] { "col1", "col2", "col3" })
                .Values(new object[] { 1, "skdajhfla", dt });

            builder.Build().Should().Be($"INSERT INTO table (col1, col2, col3 ) VALUES (1, 'skdajhfla', {dt.ToSqlParameter()} ) ;");
        }
        [Fact]
        public void ShouldBuildCorrectStringMultipleValue()
        {
            var dt = DateTime.Now;
            var builder = InsertBuilder
                .InsertInto("table", new string[] { "col1", "col2", "col3" })
                .Value(1)
                .Value("skdajhfla")
                .Value(dt);

            builder.Build().Should().Be($"INSERT INTO table (col1, col2, col3 ) VALUES (1, 'skdajhfla', {dt.ToSqlParameter()} ) ;");
        }
        [Fact]
        public void ShouldBuildCorrectStringNoColumns()
        {
            var dt = DateTime.Now;
            var builder = InsertBuilder
                .InsertInto("table")
                .Value(1)
                .Value("skdajhfla")
                .Value(dt);

            builder.Build().Should().Be($"INSERT INTO table VALUES (1, 'skdajhfla', {dt.ToSqlParameter()} ) ;");
        }
        [Fact]
        public void ShouldHandleNullsCorrectly()
        {
            var builder = InsertBuilder
                .InsertInto("table", new[] { "col1", "col2", "col3" })
                .Value(null)
                .Value("dsfkjnakl")
                .Value(31);
            builder.Build().Should().Be($"INSERT INTO table (col1, col2, col3 ) VALUES (NULL, 'dsfkjnakl', 31 ) ;");
        }

    }
}
