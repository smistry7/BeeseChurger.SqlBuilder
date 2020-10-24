using System;
using Xunit;
using System.Reflection;
using SqlBuilder.Interfaces;
using FluentAssertions;

namespace SqlBuilder.Tests
{
    public class PublicMethodsTests
    {
        [Fact]
        public void ShouldBeAbleToFromAfterSelect()
        {
            var builder = new SelectBuilder()
                .Select("*");
            var interfaceMethods = builder
                .GetType()
                .GetInterface(nameof(ISelectBuilder))
                .GetMethods(BindingFlags.Public | BindingFlags.Instance);
            interfaceMethods.Should().Contain(x => x.Name == "From");
        }
    }
}
