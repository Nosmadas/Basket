using FluentAssertions;
using System;
using Xunit;

namespace BasketTest.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Constructor_GivenPositiveValueDoNotThrow()
        {
            Action act = () => new Product(10m);
            act.ShouldNotThrow();
        }

        [Fact]
        public void Constructor_GivenNegativeValueThrowArgumentOutOfRangeException()
        {
            Action act = () => new Product(-1m);
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }
    }
}
