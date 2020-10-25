using FluentAssertions;
using SqlBuilder.Interfaces;
using System.Reflection;
using Xunit;

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