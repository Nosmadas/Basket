using BasketTest.Vouchers;
using BasketTest.Vouchers.Validation;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Linq;
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

        [Fact]
        public void Add_ProductIsAddedThenShouldContainProduct()
        {
            var product = new Product(9.99m);
            _valueCalculator.Setup(o => o.CalculateValue(It.IsAny<IEnumerable<Product>>(), It.IsAny<IEnumerable<Voucher>>())).Returns(9.99m);
            _voucherValidator.Setup(o => o.Validate(It.IsAny<IEnumerable<Product>>(), It.IsAny<IEnumerable<Voucher>>())).Returns((Enumerable.Empty<Voucher>(), Enumerable.Empty<Voucher>()));

            _basket.Add(product);

            _basket.Products.Count.Should().Be(1);
            _basket.Products.Should().Contain(product);
        }

        [Fact]
        public void Add_VoucherIsAddedThenShouldContainVoucher()
        {
            var voucher = new GiftVoucher(10);
            _valueCalculator.Setup(o => o.CalculateValue(It.IsAny<IEnumerable<Product>>(), It.IsAny<IEnumerable<Voucher>>())).Returns(0);
            _voucherValidator.Setup(o => o.Validate(It.IsAny<IEnumerable<Product>>(), It.IsAny<IEnumerable<Voucher>>())).Returns((Enumerable.Empty<Voucher>(), Enumerable.Empty<Voucher>()));

            _basket.Add(voucher);

            _basket.Vouchers.Count.Should().Be(1);
            _basket.Vouchers.Should().Contain(voucher);
        }

        [Fact]
        public void Remove_ProductIsRemovedThenShouldNotContainProduct()
        {
            var product = new Product(9.99m);
            _valueCalculator.Setup(o => o.CalculateValue(It.IsAny<IEnumerable<Product>>(), It.IsAny<IEnumerable<Voucher>>())).Returns(9.99m);
            _voucherValidator.Setup(o => o.Validate(It.IsAny<IEnumerable<Product>>(), It.IsAny<IEnumerable<Voucher>>())).Returns((Enumerable.Empty<Voucher>(), Enumerable.Empty<Voucher>()));

            _basket.Add(product);

            _basket.Products.Count.Should().Be(1);
            _basket.Products.Should().Contain(product);

            _basket.Remove(product);

            _basket.Products.Count.Should().Be(0);
            _basket.Products.Should().NotContain(product);
        }

        [Fact]
        public void Remove_VoucherIsRemovedThenShouldNotContainVoucher()
        {
            var voucher = new GiftVoucher(10);
            _valueCalculator.Setup(o => o.CalculateValue(It.IsAny<IEnumerable<Product>>(), It.IsAny<IEnumerable<Voucher>>())).Returns(0);
            _voucherValidator.Setup(o => o.Validate(It.IsAny<IEnumerable<Product>>(), It.IsAny<IEnumerable<Voucher>>())).Returns((Enumerable.Empty<Voucher>(), Enumerable.Empty<Voucher>()));

            _basket.Add(voucher);

            _basket.Vouchers.Count.Should().Be(1);
            _basket.Vouchers.Should().Contain(voucher);

            _basket.Remove(voucher);

            _basket.Vouchers.Count.Should().Be(0);
            _basket.Vouchers.Should().NotContain(voucher);
        }

        [Fact]
        public void Add_ProductShouldUpdateTotal()
        {
            var product = new Product(10);
            _valueCalculator.Setup(o => o.CalculateValue(It.IsAny<IEnumerable<Product>>(), It.IsAny<IEnumerable<Voucher>>())).Returns(10);
            _voucherValidator.Setup(o => o.Validate(It.IsAny<IEnumerable<Product>>(), It.IsAny<IEnumerable<Voucher>>())).Returns((Enumerable.Empty<Voucher>(), Enumerable.Empty<Voucher>()));

            _basket.Add(product);

            _basket.TotalValue.Should().Be(10);
        }

        [Fact]
        public void Add_VoucherShouldUpdateTotal()
        {
            var voucher = new GiftVoucher(10);
            _valueCalculator.Setup(o => o.CalculateValue(It.IsAny<IEnumerable<Product>>(), It.IsAny<IEnumerable<Voucher>>())).Returns(0);
            _voucherValidator.Setup(o => o.Validate(It.IsAny<IEnumerable<Product>>(), It.IsAny<IEnumerable<Voucher>>())).Returns((Enumerable.Empty<Voucher>(), Enumerable.Empty<Voucher>()));

            _basket.Add(voucher);

            _basket.TotalValue.Should().Be(0);
        }

        [Fact]
        public void Remove_ProductShouldUpdateTotal()
        {
            var product = new Product(10);
            _valueCalculator.Setup(o => o.CalculateValue(It.IsAny<IEnumerable<Product>>(), It.IsAny<IEnumerable<Voucher>>())).Returns(10);
            _voucherValidator.Setup(o => o.Validate(It.IsAny<IEnumerable<Product>>(), It.IsAny<IEnumerable<Voucher>>())).Returns((Enumerable.Empty<Voucher>(), Enumerable.Empty<Voucher>()));

            _basket.Add(product);

            _basket.TotalValue.Should().Be(10);

            _valueCalculator.Setup(o => o.CalculateValue(It.IsAny<IEnumerable<Product>>(), It.IsAny<IEnumerable<Voucher>>())).Returns(5);

            _basket.Remove(product);
            _basket.TotalValue.Should().Be(5);
        }

        [Fact]
        public void Remove_VoucherShouldUpdateTotal()
        {
            var voucher = new GiftVoucher(5);
            var product = new Product(10);

            _valueCalculator.Setup(o => o.CalculateValue(It.IsAny<IEnumerable<Product>>(), It.IsAny<IEnumerable<Voucher>>())).Returns(5);
            _voucherValidator.Setup(o => o.Validate(It.IsAny<IEnumerable<Product>>(), It.IsAny<IEnumerable<Voucher>>())).Returns((Enumerable.Empty<Voucher>(), Enumerable.Empty<Voucher>()));

            _basket.Add(product);
            _basket.Add(voucher);

            _basket.TotalValue.Should().Be(5);

            _valueCalculator.Setup(o => o.CalculateValue(It.IsAny<IEnumerable<Product>>(), It.IsAny<IEnumerable<Voucher>>())).Returns(10);

            _basket.Remove(voucher);
            _basket.TotalValue.Should().Be(10);
        }
    }
}
