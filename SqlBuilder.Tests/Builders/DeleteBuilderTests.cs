using BeeseChurger.SqlBuilder.Misc;
using FluentAssertions;
using System;
using Xunit;

namespace BeeseChurger.SqlBuilder.Tests.Builders
{
    public class DeleteBuilderTests
    {
        [Fact]
        public void BuildReturnsCorrectString()
        {
            var builder1 = DeleteBuilder.DeleteFrom("table").Where("id", 5);

            builder1.Build().Should().Be("DELETE FROM table WHERE id = 5 ;");
            var date = DateTime.Now.AddYears(-14);
            var builder2 = DeleteBuilder.DeleteFrom("table2").Where("age > 14").Or($"birthday < {date.ToSqlParameter()}");
            builder2.Build().Should().Be($"DELETE FROM table2 WHERE age > 14 OR birthday < {date.ToSqlParameter()} ;");

        }
    }
}