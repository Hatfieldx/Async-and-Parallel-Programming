using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace part2
{
    class Shop
    {
        private BlockingCollection<Product> ProductsB;

        public Shop()
        {
            ProductsB = new BlockingCollection<Product>();
        }
        
        public ConcurrentQueue<Product> Products { get; set; } = new ConcurrentQueue<Product>();
       
        public void MakeAnOrder(string name, int count)
        {
            ProductsB.TryAdd(new Product {Name = name, Quantity = count });

            //Console.WriteLine(new string(' ', 20) + $"{name} added");
        }

        public void ProcessOrders()
        {
            while (!ProductsB.IsAddingCompleted)
            {
                if (ProductsB.TryTake(out Product item))
                {
                    Console.WriteLine(item.Name);
                }
            }

            if (ProductsB.IsCompleted)
            {
                ProductsB.Dispose();
            }            
        }

        public void BuyingComplete()
        {
            ProductsB.CompleteAdding();
        }
    }
}
