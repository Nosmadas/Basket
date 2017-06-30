using System.Collections.Generic;
using System.Linq;

namespace BasketTest.Vouchers.Validation
{
    public class SpendThresholdValidationRule : IValidationRule
    {
        public IEnumerable<InvalidVoucherDecorator> Validate(IEnumerable<Product> products, IEnumerable<Voucher> vouchers)
        {
            var applicableVouchers = vouchers.OfType<OfferVoucher>();
            var productsSum = products.Where(o => o.Category != ProductCategory.GiftVoucher).Sum(o => o.Value);

            var invalid = new List<InvalidVoucherDecorator>();

            if (applicableVouchers?.Any() ?? false)
            {
                foreach (var voucher in applicableVouchers)
                {
                    if (productsSum < voucher.Threshold)
                    {
                        invalid.Add(new InvalidVoucherDecorator(voucher,
                            $"“You have not reached the spend threshold. " +
                            $"Spend another {((voucher.Threshold - productsSum) + 0.01m).ToString("C")} " +
                            $"to receive {voucher.Value.ToString("C")} discount from your basket total.”"));
                    }
                }
            }

            return invalid;
        }
    }
}
