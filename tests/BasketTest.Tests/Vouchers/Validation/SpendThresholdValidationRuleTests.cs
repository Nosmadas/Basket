using BasketTest.Vouchers;
using BasketTest.Vouchers.Validation;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace BasketTest.Tests.Vouchers.Validation
{
    public class SpendThresholdValidationRuleTests
    {
        private SpendThresholdValidationRule _rule = new SpendThresholdValidationRule();

        [Fact]
        public void Validate_DoNotThrowIfNoProducts()
        {
            Action act = () =>_rule.Validate(Enumerable.Empty<Product>(), Enumerable.Empty<Voucher>());
            act.ShouldNotThrow();
        }

        [Fact]
        public void Validate_GivenValidVoucherReturnEmptyEnumerable()
        {
            var products = new[]
            {
                new Product(50)
            };

            var voucher = new[]
            {
                new OfferVoucher(5, 40)
            };

            var result = _rule.Validate(products, voucher);
            result.Should().NotBeNull();
            result.Count().Should().Be(0);
        }

        [Fact]
        public void Validate_GivenInvalidVoucherReturnInvalidItem()
        {
            var products = new[]
            {
                new Product(10)
            };

            var vouchers = new[]
            {
                new OfferVoucher(5, 40)
            };

            var result = _rule.Validate(products, vouchers);
            result.Should().NotBeNull();
            result.Count().Should().Be(1);
            result.ElementAt(0).Voucher.Should().Be(vouchers.ElementAt(0));
            result.ElementAt(0).Value.Should().Be(0);
        }
    }
}
