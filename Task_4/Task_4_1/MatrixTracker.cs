using System;

namespace Task_4_1
{
    public class MatrixTracker<T>
    {
        private readonly DiagonalMatrix<T> _matrix;
        private ElementChangedEventArgs<T> _lastChange;

        public MatrixTracker(DiagonalMatrix<T> matrix)
        {
            if (matrix != null)
            {
                _matrix = matrix;
            }
            else
            {
                throw new ArgumentNullException("Matrix cannot be null.");
            }

            _matrix.ElementChanged += (_, args) => { _lastChange = args; };
        }

        public void Undo()
        {
            if (_lastChange is not default(ElementChangedEventArgs<T>))
            {
                _matrix[_lastChange.IndexI, _lastChange.IndexJ] = _lastChange.OldValue;
                _lastChange = default;
            }
        }
    }
}
