using System;

namespace Task_4_1
{
    public static class DiagonalMatrixHelper
    {
        public delegate T Sum<T>(T a, T b);

        public static DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> a, DiagonalMatrix<T> b, Sum<T> sum)
        {
            if (a != null)
            {
                a = new DiagonalMatrix<T>(a.Size);
            }
            else if (b != null)
            {
                b = new DiagonalMatrix<T>(b.Size);
            }
            else
            {
                throw new ArgumentNullException("Matrix cannot be null.");
            }

            if (a.Size < b.Size)
            {
                (a, b) = (b, a);
            }

            var data = new T[a.Size];
            for (var i = 0; i < b.Size; i++)
            {
                data[i] = sum(a[i, i], b[i, i]);
            }

            for (var i = b.Size; i < a.Size; i++)
            {
                data[i] = a[i, i];
            }

            return new DiagonalMatrix<T>(a.Size, data);
        }
    }
}
