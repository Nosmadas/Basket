using System;
using System.Collections.Generic;
using System.Linq;

namespace BasketTest.Vouchers.Validation
{
    public class NotApplicableCategoryRule : IValidationRule
    {
        public IEnumerable<InvalidVoucherDecorator> Validate(IEnumerable<Product> products, IEnumerable<Voucher> vouchers)
        {
            var applicableVouchers = vouchers.OfType<OfferVoucher>();

            var invalid = new List<InvalidVoucherDecorator>();

            if (applicableVouchers?.Any() ?? false)
            {
                foreach (var voucher in applicableVouchers)
                {
                    if (!products.Any(o => o.Category == voucher.Category))
                        invalid.Add(new InvalidVoucherDecorator(voucher, $"There are no {voucher.Category.ToString()} products in your basket."));
                }
            }

            return invalid;
        }
    }
}
