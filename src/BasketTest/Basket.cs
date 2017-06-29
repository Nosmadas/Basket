using System.Collections.Generic;
using System.Linq;

namespace BasketTest
{
    public class Basket
    {
        public IList<Product> Products { get; } = new List<Product>();
        public IList<Voucher> Vouchers { get; } = new List<Voucher>();

        public void Add(Product product) => Products.Add(product);

        public void Add(Voucher voucher) => Vouchers.Add(voucher);

        public decimal CalculateValue() => Products.Sum(o => o.Value);
    }
}
