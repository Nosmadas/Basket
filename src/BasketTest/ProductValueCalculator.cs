using BasketTest.Vouchers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BasketTest
{
    public class ProductValueCalculator : IValueCalculator
    {
        public decimal CalculateValue(IEnumerable<Product> products, IEnumerable<Voucher> vouchers)
        {
            var productsSum = products.Sum(o => o.Value);

            foreach (var voucher in vouchers)
            {
                if ((voucher as OfferVoucher)?.Category.HasValue ?? false)
                {
                    var applicableProducts = products.Where(o => o.Category == (voucher as OfferVoucher)?.Category);

                    var categoryTotal = applicableProducts.Sum(o => o.Value);

                    productsSum -= Math.Min(categoryTotal, voucher.Value);
                }
                else
                {
                    productsSum -= voucher.Value;
                }
            }

            return productsSum;
        }
    }
}
