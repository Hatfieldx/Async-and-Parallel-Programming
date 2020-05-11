using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace part2
{
    class Shop
    {
        private ConcurrentDictionary<String, Order> orders;
        private Random _random;

        public Shop()
        {
            _random = new Random();
            orders = new ConcurrentDictionary<String, Order>();
        }

        public void MakeAnOrder(string customerName)
        {
            Product p = new Product {
                Name = $"prod name {_random.Next(1, 10)}",
                Quantity = _random.Next(1, 50)
            };


        }
    }
}
