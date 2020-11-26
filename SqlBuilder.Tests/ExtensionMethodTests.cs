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
    }
}
