using BasketTest.Vouchers;
using System.Collections.Generic;

namespace BasketTest
{
    public interface IValueCalculator
    {
        decimal CalculateValue(IEnumerable<Product> products, IEnumerable<Voucher> vouchers);
    }
}
