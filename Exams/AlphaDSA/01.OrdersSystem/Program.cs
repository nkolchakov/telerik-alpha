using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

// sort bags by name
namespace _01.OrdersSystem
{
    public class Order : IComparable<Order>
    {
        public Order(string name, decimal price, string consumer)
        {
            this.Name = name;
            this.Price = price;
            this.Consumer = consumer;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Consumer { get; set; }

        public int CompareTo(Order other)
        {
            int nameCompare = this.Name.CompareTo(other.Name);
            if (nameCompare == 0)
            {
                int consumerCompare = this.Consumer.CompareTo(other.Consumer);
                if (consumerCompare == 0)
                {
                    return this.Price.CompareTo(other.Price);
                }
                return consumerCompare;
            }
            return nameCompare;
        }

        public override string ToString()
        {
            return "{" + String.Format("{0};{1};{2:0.00}", this.Name, this.Consumer, this.Price) + "}";
        }
    }
    class Program
    {
        static Dictionary<string, OrderedBag<Order>> productsByConsumer = new Dictionary<string, OrderedBag<Order>>();
        static OrderedDictionary<decimal, OrderedBag<Order>> productsByPrice = new OrderedDictionary<decimal, OrderedBag<Order>>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var parts = Console.ReadLine().Split(new char[] { ' ' }, 2);
                string command = parts[0];
                var propsAsStr = parts[1];

                switch (command)
                {
                    case "AddOrder":
                        var props = propsAsStr.Split(';');
                        Add(props);
                        break;
                    case "DeleteOrders":
                        RemoveByConsumer(propsAsStr);
                        break;
                    case "FindOrdersByPriceRange":
                        decimal[] fromTo = propsAsStr.Split(';').Select(decimal.Parse).ToArray();
                        decimal from = fromTo[0];
                        decimal to = fromTo[1];
                        FindOrdersByPriceRange(from, to);
                        break;
                    case "FindOrdersByConsumer":
                        FindOrdersByConsumer(propsAsStr);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void FindOrdersByConsumer(string consumer)
        {
            if (productsByConsumer.ContainsKey(consumer) && productsByConsumer[consumer].Count > 0)
            {
                OrderedBag<Order> result = productsByConsumer[consumer];
                Console.WriteLine(string.Join("\n", result));
            }
            else
            {
                Console.WriteLine("No orders found");
            }
        }


        private static void FindOrdersByPriceRange(decimal from, decimal to)
        {
            IEnumerable<OrderedBag<Order>> bagResults = productsByPrice.Range(from, true, to, true).Values;
            var orders = bagResults.SelectMany(b => b).OrderBy(b => b.Name).ToArray();
            if (orders.Length == 0)
            {
                Console.WriteLine("No orders found");
                return;
            }
            foreach (var order in orders)
            {

                Console.WriteLine(string.Join("\n", order));
            }
        }

        static void Add(string[] props)
        {
            string name = props[0];
            decimal price = decimal.Parse(props[1]);
            string consumer = props[2];

            Order newOrder = new Order(name, price, consumer);
            if (!productsByConsumer.ContainsKey(consumer))
            {
                productsByConsumer[consumer] = new OrderedBag<Order>();
            }

            productsByConsumer[consumer].Add(newOrder);

            if (!productsByPrice.ContainsKey(price))
            {
                productsByPrice[price] = new OrderedBag<Order>();
            }

            productsByPrice[price].Add(newOrder);

            Console.WriteLine("Order added");
        }

        static void RemoveByConsumer(string consumer)
        {
            if (productsByConsumer.ContainsKey(consumer) && productsByConsumer[consumer].Count > 0)
            {
                int count = 0;

                while (productsByConsumer[consumer].Count > 0)
                {
                    Order order = productsByConsumer[consumer][0];

                    productsByPrice[order.Price].Remove(order);
                    productsByConsumer[consumer].Remove(order);

                    count++;
                }

                Console.WriteLine("{0} orders deleted", count);
            }
            else
            {
                Console.WriteLine("No orders found");
            }


        }
    }
}
