using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using BeeseChurger.SqlBuilder.Misc;
using FluentAssertions;

namespace BeeseChurger.SqlBuilder.Tests
{
    public class ExtensionMethodTests
    {
        [InlineData("blahblah", "'blahblah'")]
        [InlineData(123, "123")]
        [Theory]
        public void ToSqlParameter_ShouldReturnCorrectly(object input, string expected)
        {
            input.ToSqlParameter().Should().Be(expected);
        }

        [InlineData(new[] { "a", "b", "c" }, "('a','b','c')")]
        [InlineData(new[] { "sdkjhfas" }, "('sdkjhfas')")]
        [Theory]
        public void ToInClause_ShouldReturnCorrectly(string[] input, string expected)
        {
            var result = input.ToInClause();
            result.Should().Be(expected);


        }
        [Fact]
        public void BuilderWithInlineToInClauseShouldReturn()
        {

            var arr = new[] { "a", "b", "c" };

            var query = SelectBuilder.Init()
                           .Select("*")
                           .From("dbo.table")
                           .WhereIn("x", arr)
                           .Build();
            query.Should().Be("SELECT * FROM dbo.table WHERE x IN ('a','b','c') ;");
        }
    }
}
