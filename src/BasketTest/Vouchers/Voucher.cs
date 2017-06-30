using System;

namespace BasketTest.Vouchers
{
    public abstract class Voucher
    {
        public readonly decimal Value;

        private const int _minValue = 0;

        public Voucher(decimal value)
        {
            if (value < _minValue) throw new ArgumentOutOfRangeException($"Value must be greater than {_minValue}.");

            Value = value;
        }
    }
}
