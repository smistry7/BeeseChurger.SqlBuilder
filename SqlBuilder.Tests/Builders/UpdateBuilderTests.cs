using FluentAssertions;
using System;
using Xunit;
using BeeseChurger.SqlBuilder.Misc;

namespace BeeseChurger.SqlBuilder.Tests.Builders
{
    public class UpdateBuilderTests
    {
        [Fact]
        public void ShouldBuildUpdateQuery()
        {
            var dateTime = DateTime.Now;
            var builder = UpdateBuilder
                .Update("dbo.table")
                .Set("company", "dummyCompany")
                .Set("LastUpdatedDate", dateTime)
                .Where("id", 5)
                .And($"foreignId LIKE 'AB15'");
            builder.Build().Should()
                .Be($"UPDATE dbo.table SET company = 'dummyCompany', " +
                $"LastUpdatedDate = {dateTime.ToSqlParameter()} WHERE id = 5 AND foreignId LIKE 'AB15' ;");
        }
        [Fact]
        public void ShouldHandleNullsCorrectly()
        {
            var builder = UpdateBuilder.Update("table")
                .Set("x", null).Where("id", 4);
            builder.Build().Should().Be("UPDATE table SET x = NULL WHERE id = 4 ;");
        }
    }
}
