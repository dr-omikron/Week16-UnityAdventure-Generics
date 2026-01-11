using System;

namespace Develop._1._1.Wallet
{
    public class ReactiveVariable<T1, T2> where T2 : IEquatable<T2>
    {
        public event Action<T1, T2> Changed;

        private readonly T1 _key;
        private T2 _value;

        public ReactiveVariable()
        {
            _value = default;
            _key = default;
        }

        public ReactiveVariable(T1 key, T2 value)
        {
            _key = key;
            _value = value;
        }

        public T1 Key => _key;

        public T2 Value
        {
            get => _value;
            set
            {
                T2 oldValue = _value;
                _value = value;

                if (_value.Equals(oldValue) == false)
                    Changed?.Invoke(_key, _value);
            }
        }
    }
}
