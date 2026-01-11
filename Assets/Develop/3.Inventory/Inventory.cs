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

        public IReadOnlyList<Item> Items => _items;
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

        public Item GetItemsBy(string name, int count)
        {
            Item item = _items.FirstOrDefault(item => item.Name == name);

            if(item == null)
                throw new ArgumentException("Item not found", name);

            if(item.Count < count)
                throw new ArgumentException("Item count is less than requested", name);

            if(item.Count - count == 0)
            {
                _items.Remove(item);
                return item;
            }

            item.Sub(count);
            return new Item(name, count);
        }

        private bool CanAdd(Item item) => CurrentSize + item.Count <= _maxSize;
    }

}
