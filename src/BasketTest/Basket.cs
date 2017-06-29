using System.Collections.Generic;
using System.Linq;

namespace BasketTest
{
    public class Basket
    {
        public IList<Product> Products { get; } = new List<Product>();

        public void Add(Product product) => Products.Add(product);

        public decimal CalculateValue() => Products.Sum(o => o.Value);
    }
}
