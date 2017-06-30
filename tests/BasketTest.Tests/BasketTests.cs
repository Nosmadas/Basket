using BasketTest.Vouchers;
using BasketTest.Vouchers.Validation;
using FluentAssertions;
using Moq;
using Xunit;

namespace BasketTest.Tests
{
    public class BasketTests
    {
        private Basket _basket;

        private Mock<IValueCalculator> _valueCalculator = new Mock<IValueCalculator>();
        private Mock<IVoucherValidator> _voucherValidator = new Mock<IVoucherValidator>();

        public BasketTests()
        {
            _basket = new Basket(_voucherValidator.Object, _valueCalculator.Object);
        }

        public class GivenBasketIsEmpty : BasketTests
        { 
            [Fact]
            public void WhenProductIsAddedThenShouldContainProduct()
            {
                var product = new Product(9.99m);

                _basket.Add(product);

                _basket.Products.Count.Should().Be(1);
                _basket.Products.Should().Contain(product);
            }

            [Fact]
            public void WhenVoucherIsAddedThenShouldContainVoucher()
            {
                var voucher = new GiftVoucher(10);

                _basket.Add(voucher);

                _basket.Vouchers.Count.Should().Be(1);
                _basket.Vouchers.Should().Contain(voucher);
            }
        }
    }
}
