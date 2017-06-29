using FluentAssertions;
using Xunit;

namespace BasketTest.Tests
{
    public class AcceptanceTests
    {
        private Basket _basket = new Basket();

        [Fact]
        public void GivenProductsAndGiftVoucherThenCalculateBasketValue()
        {
            var hat = new Product(10.50m);
            var jumper = new Product(54.65m);
            var giftVoucher = new GiftVoucher(5m);

            _basket.Add(hat);
            _basket.Add(jumper);
            _basket.Add(giftVoucher);

            _basket.CalculateValue().Should().Be(60.15m);
        }

        [Fact]
        public void GivenProductsAndInapplicableOfferVoucherThenCalculateBasketValue()
        {
            var hat = new Product(25m);
            var jumper = new Product(26m);
            var offerVoucher = new OfferVoucher(5m, 50m, ProductCategory.HeadGear);

            _basket.Add(hat);
            _basket.Add(jumper);
            _basket.Add(offerVoucher);

            _basket.CalculateValue().Should().Be(51m);
        }

        [Fact]
        public void GivenProductsAndApplicableOfferVoucherThenCalculateBasketValue()
        {
            var hat = new Product(25);
            var jumper = new Product(26);
            var headLight = new Product(3.50m, ProductCategory.HeadGear);
            var offerVoucher = new OfferVoucher(5m, 50m, ProductCategory.HeadGear);

            _basket.Add(hat);
            _basket.Add(jumper);
            _basket.Add(headLight);
            _basket.Add(offerVoucher);

            _basket.CalculateValue().Should().Be(51m);
        }

        [Fact]
        public void GivenProductsInapplicableOfferVocherAndApplicableGiftVoucherThenCalculateBasketValue()
        {
            var hat = new Product(25);
            var jumper = new Product(26);
            var giftVoucher = new GiftVoucher(5m);
            var offerVoucher = new OfferVoucher(5m, 50m);

            _basket.Add(hat);
            _basket.Add(jumper);
            _basket.Add(giftVoucher);
            _basket.Add(offerVoucher);

            _basket.CalculateValue().Should().Be(41m);
        }

        [Fact]
        public void GivenGiftVoucherProductAndInapplicableOfferVoucherThenCalculateBasketValue()
        {
            var hat = new Product(25m);
            var giftVoucher = new Product(30m, ProductCategory.GiftVoucher);
            var offerVoucher = new OfferVoucher(5m, 50);

            _basket.Add(hat);
            _basket.Add(giftVoucher);
            _basket.Add(offerVoucher);

            _basket.CalculateValue().Should().Be(55m);
        }
    }
}