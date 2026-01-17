namespace Develop._1._2.Timer
{
    using System;

    namespace Develop.Example2
    {
        public interface IReadOnlyVariable<T>
        {
            event Action<T, T> Changed;
            public T Value { get; }
        }
    }
}
