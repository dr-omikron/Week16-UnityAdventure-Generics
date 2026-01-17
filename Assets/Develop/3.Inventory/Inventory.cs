using System;

namespace Develop._3.Inventory
{
    using System.Collections.Generic;
    using System.Linq;

    public class Inventory
    {
        private readonly List<Item> _items;
        private readonly int _maxSize;

        public Inventory(List<Item> items, int maxSize)
        {
            _items = new List<Item>(items);
            _maxSize = maxSize;
        }

        public IReadOnlyList<IReadOnlyItem> Items => _items;
        private int CurrentSize => _items.Sum(item => item.Count);

        public bool TryAdd(Item added)
        {
            if (CanAdd(added) == false)
                return false;

            Item item = _items.FirstOrDefault(item => item.Name == added.Name);

            if(item == null)
            {
                _items.Add(added);
                return true;
            }

            item.Add(added.Count);
            return true;
        }

        public bool TryGetItemsBy(string name, int count, out Item item)
        {
            if(count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be greater than zero");

            item = _items.FirstOrDefault(item => item.Name == name);

            if(item == null)
                return false;

            if(item.Count < count)
                return false;

            if(item.Count - count == 0)
            {
                _items.Remove(item);
                return true;
            }

            item.Sub(count);
            return true;
        }

        private bool CanAdd(Item item) => CurrentSize + item.Count <= _maxSize;
    }

}
