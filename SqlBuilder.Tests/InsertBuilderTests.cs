using FluentAssertions;
using System;
using System.Collections.Generic;
using BeeseChurger.SqlBuilder.Misc;
using Xunit;

namespace BeeseChurger.SqlBuilder.Tests
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
    }
}
