namespace BasketTest.Vouchers
{
    public class InvalidVoucherDecorator : Voucher
    {
        public readonly Voucher Voucher;
        public readonly string Message;

        public InvalidVoucherDecorator(Voucher voucher, string message) : base(0)
        {
            Voucher = voucher;
            Message = message;
        }
    }
}
