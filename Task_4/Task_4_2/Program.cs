using System;

namespace Task_4_2
{
    class Program
    {
        static void Main()
        {
            try
            {
                RationalNumber a = new(6, 10);
                RationalNumber b = new(4, -3);
                RationalNumber c = new(3, 3);
                RationalNumber d = new(10, 9);
                RationalNumber e = new(-3, 9);
                //RationalNumber zeroDenominator = new(3, 0);

                Console.WriteLine($"given rational numbers: {a}, {b}, {c}, {d}, {e}");
                Console.WriteLine($"c = {c} equals d = {d}: {c.Equals(d)}");
                Console.WriteLine($"{a} comparing to {d}: {a.CompareTo(d)}");
                Console.WriteLine($"{d} comparing to {b}: {d.CompareTo(b)}");
                Console.WriteLine($"{c} comparing to {d}: {c.CompareTo(d)}\n");

                Console.WriteLine($"{c} + {a} = {c + a}");
                Console.WriteLine($"{e} + {b} = {e + b}");
                Console.WriteLine($"{e} - {b} = {e - b}");
                Console.WriteLine($"{a} * {e} = {a * e}");
                Console.WriteLine($"{a} / {d} = {a / d}");

                double doubleA = (double)a;
                Console.WriteLine($"explicit cast: {a} -> {doubleA}");
                c = 5;
                Console.WriteLine($"implicit cast: 5 -> {c}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
