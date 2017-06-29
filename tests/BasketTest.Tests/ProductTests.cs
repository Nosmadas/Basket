using FluentAssertions;
using System;
using Xunit;

namespace BasketTest.Tests
{
    public class ProductTests
    {
        public class GivenPositiveValue
        {
            [Fact]
            public void ThenDoNotThrow()
            {
                Action act = () => new Product(10);
                act.ShouldNotThrow();
            }
        }
         
        public class GivenNegativeValue
        {
            [Fact]
            public void ThenThrowArgumentOutOfRangeException()
            {
                Action act = () => new Product(-1);
                act.ShouldThrow<ArgumentOutOfRangeException>();
            }
        }
    }
}
