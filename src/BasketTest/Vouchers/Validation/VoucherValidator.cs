using System.Collections.Generic;
using System.Linq;

namespace BasketTest.Vouchers.Validation
{
    public class VoucherValidator : IVoucherValidator
    {
        private IEnumerable<IValidationRule> _validationRules;

        public VoucherValidator(IEnumerable<IValidationRule> validationRules)
        {
            _validationRules = validationRules;
        }

        public (IEnumerable<Voucher> validVouchers, IEnumerable<Voucher> invalidVouchers) Validate(IEnumerable<Product> products, IEnumerable<Voucher> vouchers)
        {
            var validVouchers = new List<Voucher>();
            var invalidVouchers = new List<InvalidVoucherDecorator>();

            foreach (var rule in _validationRules)
                invalidVouchers.AddRange(rule.Validate(products, vouchers));

            validVouchers.AddRange(vouchers.Where(voucher => !invalidVouchers.Select(inv => inv.Voucher).Contains(voucher)));

            return (validVouchers, invalidVouchers);
        }
    }
}
