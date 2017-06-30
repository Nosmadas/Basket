using System.Collections.Generic;

namespace BasketTest.Vouchers.Validation
{
    public interface IValidationRule
    {
        IEnumerable<InvalidVoucherDecorator> Validate(IEnumerable<Product> products, IEnumerable<Voucher> vouchers);
    }
}
