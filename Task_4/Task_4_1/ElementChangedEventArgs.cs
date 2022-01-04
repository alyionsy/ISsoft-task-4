using System;

namespace Task_4_1
{
    public class ElementChangedEventArgs<T> : EventArgs
    {
        public int IndexI { get; }
        public int IndexJ { get; }
        public T OldValue { get; }
        public T NewValue { get; }

        public ElementChangedEventArgs(int i, int j, T oldValue, T newValue) => (IndexI, IndexJ, OldValue, NewValue) = (i, j, oldValue, newValue);
    }
}
