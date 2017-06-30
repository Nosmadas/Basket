using System.Collections.Generic;

namespace BasketTest.Vouchers.Validation
{
    public interface IVoucherValidator
    {
        (IEnumerable<Voucher> validVouchers, IEnumerable<Voucher> invalidVouchers) Validate(IEnumerable<Product> products, IEnumerable<Voucher> vouchers);
    }
}
