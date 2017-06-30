using BasketTest.Vouchers;
using BasketTest.Vouchers.Validation;
using FluentAssertions;
using Moq;
using System.Linq;
using Xunit;

namespace BasketTest.Tests
{
    public class VoucherValidatorTests
    {
        private VoucherValidator _validator;
        private Mock<IValidationRule> _validationRule;

        public VoucherValidatorTests()
        {
            _validationRule = new Mock<IValidationRule>();
            _validator = new VoucherValidator(new[] { _validationRule.Object });
        }

        [Fact]
        public void Validate_ShouldReturnInvalidVouchers()
        {
            var voucher = new OfferVoucher(5, 50);
            var products = new[] { new Product(50)};
            var vouchers = new[] { voucher };
            var invalid = new[] { new InvalidVoucherDecorator(voucher, "") };

            _validationRule.Setup(o => o.Validate(products, vouchers)).Returns(invalid);

            var result = _validator.Validate(products, vouchers);

            result.invalidVouchers.Should().HaveCount(1);
            result.validVouchers.Should().HaveCount(0);

            result.invalidVouchers.Should().Contain(invalid);
        }

        [Fact]
        public void Validate_ShouldReturnValidVoucher()
        {
            var voucher = new OfferVoucher(5, 50);
            var products = new[] { new Product(50) };
            var vouchers = new[] { voucher };

            _validationRule.Setup(o => o.Validate(products, vouchers)).Returns(Enumerable.Empty<InvalidVoucherDecorator>());

            var result = _validator.Validate(products, vouchers);

            result.invalidVouchers.Should().HaveCount(0);
            result.validVouchers.Should().HaveCount(1);
            result.validVouchers.Should().Contain(vouchers);
        }
    }
}
