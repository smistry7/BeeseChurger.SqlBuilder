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
        [InlineData("SELECT a, b, c, ", "SELECT a, b, c ")]
        [InlineData("VALUES (a, b, c, ", "VALUES (a, b, c ")]
        [Theory]
        public void RemoveTrailingComma_ShouldReturnCorrectly(object input, string expected)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(input);
            stringBuilder.RemoveTrailingComma();
            stringBuilder.ToString().Should().Be(expected);

        }
        [InlineData(new [] { "a", "b", "c"}, "('a','b','c')")]
        [Theory]
        public void ToInClause_ShouldReturnCorrectly(string[] input, string expected)
        {
            var result = input.ToInClause();
            result.Should().Be(expected);
        }
    }
}
