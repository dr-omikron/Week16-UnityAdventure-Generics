using System;

namespace Develop._3.Inventory
{
    public class Item : IReadOnlyItem
    {
        private readonly string _negativeCountExceptionMessage = "Count must be greater than zero";

        public Item(string name, int count)
        {
            Name = name;
            Count = count;
        }

        public string Name { get; }
        public int Count { get; private set; }

        public void Add(int count)
        {
            if(count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count), _negativeCountExceptionMessage);

            Count += count;
        }

        public void Sub(int count)
        {
            if(count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count), _negativeCountExceptionMessage);

            Count -= count;
        }
    }
}
