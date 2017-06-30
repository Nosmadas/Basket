namespace BasketTest.Vouchers
{
    public class OfferVoucher : Voucher
    {
        public readonly ProductCategory? Category;
        public readonly decimal Threshold;

        public OfferVoucher(decimal value, decimal threshold, ProductCategory? category = null) : base(value)
        {
            Category = category;
            Threshold = threshold;
        }
    }
}
