using System;

namespace Task_4_1
{
    public class DiagonalMatrix<T>
    {
        private readonly T[] _diagonal;
        public int Size => _diagonal.Length;

        public DiagonalMatrix(int size, params T[] diagonal)
        {
            if (size < 0)
            {
                throw new ArgumentException("Invalid size value.");
            }

            _diagonal = new T[size];
            if (size != 0 && diagonal != null)
            {
                diagonal.CopyTo(_diagonal, 0);
            }
        }

        public T this[int i, int j]
        {
            get => i == j && IsIndexCorrect(i) ? _diagonal[i] : default;
            set
            {
                if (i == j && IsIndexCorrect(i))
                {
                    T oldValue = _diagonal[i];
                    _diagonal[i] = value;

                    if (oldValue != null && !oldValue.Equals(_diagonal[i]))
                    {
                        OnElementChanged(new ElementChangedEventArgs<T>(i, j, oldValue, value));
                    }
                }
            }
        }

        private bool IsIndexCorrect(int i)
        {
            return i >= 0 && i < Size ? true : throw new IndexOutOfRangeException("Invalid index value.");
        }

        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;

        protected virtual void OnElementChanged(ElementChangedEventArgs<T> e)
        {
            ElementChanged?.Invoke(this, e);
        }

        public override string ToString()
        {
            var result = string.Empty;
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    result += $"{this[i, j], -5}";
                }

                result += "\n";
            }

            return result;
        }
    }
}
