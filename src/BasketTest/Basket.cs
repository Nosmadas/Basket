using BasketTest.Vouchers;
using BasketTest.Vouchers.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BasketTest
{
    public class Basket
    {
        public IList<Product> Products { get; } = new List<Product>();
        public IList<Voucher> Vouchers { get; } = new List<Voucher>();
        public IList<string> ErrorMessages { get; private set; } = new List<string>();

        public decimal TotalValue { get; private set; }

        private IValueCalculator _valueCalculator;
        private IVoucherValidator _voucherValidator;

        public Basket(IVoucherValidator voucherValidator, IValueCalculator valueCalculator)
        {
            _voucherValidator = voucherValidator ?? throw new ArgumentNullException(nameof(voucherValidator));
            _valueCalculator = valueCalculator ?? throw new ArgumentNullException(nameof(valueCalculator));
        }

        public void Add(Product product)
        {
            Products.Add(product);
            CalculateValue();
        }

        public void Add(Voucher voucher)
        {
            Vouchers.Add(voucher);
            CalculateValue();
        }

        public void Remove(Product product)
        {
            Products.Remove(product);
            CalculateValue();
        }

        public void Remove(Voucher voucher)
        {
            Vouchers.Remove(voucher);
            CalculateValue();
        }

        private void CalculateValue()
        {
            var result = _voucherValidator.Validate(Products, Vouchers);

            ErrorMessages = result.invalidVouchers?.OfType<InvalidVoucherDecorator>()?.Select(invalid => invalid.Message).ToList(); // show messages

            TotalValue = _valueCalculator.CalculateValue(Products, result.validVouchers);
        }
    }
}