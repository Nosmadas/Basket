using BasketTest.Vouchers;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace BasketTest.Tests
{
    public class ProductValueCalculatorTests
    {
        public class GivenProducts
        {
            private ProductValueCalculator _valueCalculator = new ProductValueCalculator();

            [Fact]
            public void ThenCalculateTotalValue()
            {
                var products = new[]
                {
                    new Product(10),
                    new Product(20)
                };

                var total = _valueCalculator.CalculateValue(products, Enumerable.Empty<Voucher>());

                total.Should().Be(30);
            }

            [Fact]
            public void AndGiftVoucherThenDeductFromTotalValue()
            {
                var products = new[]
                {
                    new Product(10),
                    new Product(20)
                };

                var vouchers = new[] { new GiftVoucher(10) };

                var total = _valueCalculator.CalculateValue(products, vouchers);

                total.Should().Be(20);
            }

            [Fact]
            public void AndOfferVoucherThenDeductFromTotalValue()
            {
                var products = new[]
   {
                    new Product(10),
                    new Product(20)
                };

                var vouchers = new[] { new OfferVoucher(10, 30) };

                var total = _valueCalculator.CalculateValue(products, vouchers);

                total.Should().Be(20);
            }

            [Fact]
            public void AndCategoryOfferVoucherThenDeductFromTotalValue()
            {
                var products = new[]
                {
                    new Product(5, ProductCategory.HeadGear),
                    new Product(20)
                };

                var vouchers = new[] { new OfferVoucher(10, 20, ProductCategory.HeadGear) };

                var total = _valueCalculator.CalculateValue(products, vouchers);

                total.Should().Be(20);
            }
        }
    }
}
