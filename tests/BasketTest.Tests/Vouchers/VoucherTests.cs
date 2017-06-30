using BasketTest.Vouchers;
using FluentAssertions;
using System;
using Xunit;

namespace BasketTest.Tests
{
    public class VoucherTests
    {
        [Fact]
        public void Constructor_GivenPositiveValueDoNotThrow()
        {
            Action act = () => new GiftVoucher(10m);
            act.ShouldNotThrow();
        }

        [Fact]
        public void Constructor_GivenNegativeValueThrowArgumentOutOfRangeException()
        {
            Action act = () => new GiftVoucher(-1m);
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }
    }
}
