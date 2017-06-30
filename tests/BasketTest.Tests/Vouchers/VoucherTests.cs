using BasketTest.Vouchers;
using FluentAssertions;
using System;
using Xunit;

namespace BasketTest.Tests
{
    public class VoucherTests
    {
        public class GivenPositiveValue
        {
            [Fact]
            public void ThenDoNotThrow()
            {
                Action act = () => new GiftVoucher(10);
                act.ShouldNotThrow();
            }
        }

        public class GivenNegativeValue
        {
            [Fact]
            public void ThenThrowArgumentOutOfRangeException()
            {
                Action act = () => new GiftVoucher(-1);
                act.ShouldThrow<ArgumentOutOfRangeException>();
            }
        }
    }
}
