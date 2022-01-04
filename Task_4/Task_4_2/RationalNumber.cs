using System;

namespace Task_4_2
{
    public sealed class RationalNumber : IComparable<RationalNumber>
    {
        private readonly int _numerator;
        private readonly int _denominator;

        public RationalNumber(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.");
            }

            if (denominator < 0)
            {
                numerator *= -1;
                denominator *= -1;
            }

            if (GCD(numerator, denominator) != 1)
            {
                var gcd = GCD(numerator, denominator);
                numerator /= gcd;
                denominator /= gcd;
            }

            _numerator = numerator;
            _denominator = denominator;
        }

        private static int GCD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a | b;
        }

        public int CompareTo(RationalNumber other)
        {
            if (other == null) return 1;

            return (_numerator * other._denominator).CompareTo(other._numerator * _denominator);
        }

        public override bool Equals(object obj)
        {
            return obj is RationalNumber number &&
                   _numerator == number._numerator &&
                   _denominator == number._denominator;
        }

        public override int GetHashCode()
        {
            return _numerator ^ _denominator;
        }

        public override string ToString()
        {
            return _numerator.ToString() + "/" + _denominator.ToString();
        }

        public static RationalNumber operator +(RationalNumber a, RationalNumber b)
        {
            if (a == null || b == null)
            {
                throw new ArgumentNullException("Rational number cannot be null");
            }

            return new RationalNumber(a._numerator * b._denominator + b._numerator * a._denominator, a._denominator * b._denominator);
        }

        public static RationalNumber operator -(RationalNumber a, RationalNumber b)
        {
            if (a == null || b == null)
            {
                throw new ArgumentNullException("Rational number cannot be null");
            }

            return new RationalNumber(a._numerator * b._denominator - b._numerator * a._denominator, a._denominator * b._denominator);
        }

        public static RationalNumber operator *(RationalNumber a, RationalNumber b)
        {
            if (a == null || b == null)
            {
                throw new ArgumentNullException("Rational number cannot be null");
            }

            return new RationalNumber(a._numerator * b._numerator, a._denominator * b._denominator);
        }

        public static RationalNumber operator /(RationalNumber a, RationalNumber b)
        {
            if (a == null || b == null)
            {
                throw new ArgumentNullException("Rational number cannot be null");
            }

            return new RationalNumber(a._numerator * b._denominator, a._denominator * b._numerator);
        }

        public static explicit operator double(RationalNumber a)
        {
            if (a == null)
            {
                throw new ArgumentNullException("Rational number cannot be null");
            }

            return (double)a._numerator / a._denominator;
        }

        public static implicit operator RationalNumber(int x)
            => new(x, 1);
    }
}
