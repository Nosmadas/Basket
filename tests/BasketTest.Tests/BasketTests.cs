using FluentAssertions;
using Xunit;

namespace BasketTest.Tests
{
    public class BasketTests
    {
        public class GivenBasketIsEmpty
        {
            private Basket _basket = new Basket();

            [Fact]
            public void WhenProductIsAddedThenShouldContainProduct()
            {
                var product = new Product(9.99m);

                _basket.Add(product);

                _basket.Products.Count.Should().Be(1);
                _basket.Products.Should().Contain(product);
            }
        }

        public class GivenBasketHasProducts
        {
            private Basket _basket = new Basket();

            [Fact]
            public void ThenCalculateTotal()
            {
                _basket.Add(new Product(10));
                _basket.Add(new Product(20));

                _basket.CalculateValue().Should().Be(30);
            }
        }
    }
}
