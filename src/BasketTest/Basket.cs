using BasketTest.Vouchers;
using BasketTest.Vouchers.Validation;
using System;
using System.Collections.Generic;

namespace BasketTest
{
    public class Basket
    {
        public IList<Product> Products { get; } = new List<Product>();
        public IList<Voucher> Vouchers { get; } = new List<Voucher>();

        private IValueCalculator _valueCalculator;
        private IVoucherValidator _voucherValidator;

        public Basket(IVoucherValidator voucherValidator, IValueCalculator valueCalculator)
        {
            _voucherValidator = voucherValidator ?? throw new ArgumentNullException(nameof(voucherValidator));
            _valueCalculator = valueCalculator ?? throw new ArgumentNullException(nameof(valueCalculator));
        }

        public void Add(Product product) => Products.Add(product);

        public void Add(Voucher voucher) => Vouchers.Add(voucher);

        public decimal CalculateValue()
        {
            var result = _voucherValidator.Validate(Products, Vouchers);
            return _valueCalculator.CalculateValue(Products, result.validVouchers);
        }
    }
}
