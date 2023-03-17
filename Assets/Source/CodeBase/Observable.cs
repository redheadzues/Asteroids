using System;

namespace Assets.Source.CodeBase
{
    public class Observable<T> : IReadOnlyObservable<T>
    {
        private T _value;

        public T Value
        {
            get => _value;

            set
            {
                _value = value;
                ValueChanged?.Invoke(_value);
            }
        }

        public event Action<T> ValueChanged;

        public Observable(T value)
        {
            Value = value;
        }   
    }

    public interface IReadOnlyObservable<T>
    {
        event Action<T> ValueChanged;
        public T Value { get; }
    }
}
