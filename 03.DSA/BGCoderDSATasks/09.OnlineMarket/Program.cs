using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _09.OnlineMarket
{
    class Product
    {
        public Product(string name, decimal price, string type)
        {
            this.ProductName = name;
            this.ProductPrice = price;
            this.ProductType = type;
        }

        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductType { get; set; }

        public override string ToString()
        {
            return string.Format("{0}({1:G29})", this.ProductName, this.ProductPrice);
        }

    }

    class ProductComparerByName : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            int compareByName = x.ProductName.CompareTo(y.ProductName);
            if (compareByName == 0)
            {
                int compareByPrice = x.ProductPrice.CompareTo(y.ProductPrice);
                if (compareByPrice == 0)
                {
                    return x.ProductType.CompareTo(y.ProductType);
                }
                return compareByPrice;
            }
            return compareByName;
        }
    }

    class ProductComparerByPrice : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            int compareByPrice = x.ProductPrice.CompareTo(y.ProductPrice);
            return compareByPrice;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var products = new OrderedDictionary<decimal, OrderedSet<Product>>();
            var productTypes = new Dictionary<string, OrderedBag<Product>>();


            string line;
            while ((line = Console.ReadLine()) != "end")
            {
                var parts = line.Split(new string[] { " ", "by" }, 100, StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];

                switch (command)
                {
                    case "add":
                        Add(parts, products, productTypes);
                        break;
                    case "filter":
                        string filterBy = parts[1];
                        switch (filterBy)
                        {
                            case "price":
                                string rangeFormat = parts[2];
                                decimal minPrice = 0;
                                decimal maxPrice = 5001;
                                if (rangeFormat == "to")
                                {
                                    maxPrice = decimal.Parse(parts[3]);
                                }
                                else
                                {
                                    minPrice = decimal.Parse(parts[3]);
                                    if (parts.Count() == 6) // from TO ..
                                    {
                                        maxPrice = decimal.Parse(parts[5]);
                                    }
                                }
                                var productsByPrice =  products.Range(minPrice, true, maxPrice, true).Take(10).SelectMany(x => x.Value).Take(10);
                                PrintCollection(productsByPrice);
                                break;
                            case "type":
                                string wantedType = parts[2];
                                if (productTypes.ContainsKey(wantedType))
                                {
                                    var productsByType = productTypes[wantedType].Take(10);
                                    PrintCollection(productsByType);
                                }
                                else
                                {
                                    Console.WriteLine("Error: Type {0} does not exists", wantedType);
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private static void PrintCollection(IEnumerable<Product> collection)
        {
            Console.WriteLine("Ok: {0}", string.Join(", ", collection));
        }



        static void Add(string[] parameters, OrderedDictionary<decimal, OrderedSet<Product>> products,
            Dictionary<string, OrderedBag<Product>> productByTypes)
        {
            string name = parameters[1];
            decimal price = decimal.Parse(parameters[2]);
            string type = parameters[3];

            var newProduct = new Product(name, price, type);
            if (!products.ContainsKey(price))
            {
                products[price] = new OrderedSet<Product>(new ProductComparerByName());
            }

            if (!products[price].Contains(newProduct))
            {

                products[price].Add(newProduct);
                Console.WriteLine("Ok: Product {0} added successfully", newProduct.ProductName);

                if (!productByTypes.ContainsKey(type))
                {
                    productByTypes[type] = new OrderedBag<Product>(new ProductComparerByPrice());
                }
                productByTypes[type].Add(newProduct);


            }
            else
            {
                Console.WriteLine("Error: Product {0} already exists", newProduct.ProductName);
            }
        }

    }
}
