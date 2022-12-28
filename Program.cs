using System;
using System.Collections.Generic;

namespace IJunior.OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ShowProductsCommand = "1";
            const string ShowBagCommand = "2";
            const string ExitCommand = "3";

            Seller seller = new Seller();
            Buyer buyer = new Buyer();
            bool isWork = true;
            int money = 100;

            while (isWork == true)
            {
                Console.WriteLine($"Ваши средства: {money} руб.");

                Console.WriteLine($"\nТовары на прилавке: \n");
                seller.ShowGoods();

                Console.WriteLine($"Выберите пункт взаимодействия:" +
                    $"\n{ShowProductsCommand}. Купить товар " +
                    $"\n{ShowBagCommand}. Посмотреть свою сумку " +
                    $"\n{ExitCommand}. Выход\n");

                switch (Console.ReadLine())
                {
                    case ShowProductsCommand:
                        //buyer.PutInBag(seller.TransferGoods(ref money));
                        break;

                    case ShowBagCommand:
                        buyer.LookInBag();
                        break;

                    case ExitCommand:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Неккоректный ввод!");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Product
    {
        public string Name { get; private set; }
        public int Price { get; private set; }
        public int Count { get; private set; }

        public Product(string name, int price, int count)
        {
            Name = name;
            Price = price;
            Count = count;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} - {Price} руб.");
        }
    }

    class Human
    {
        public List<Product> _products = new List<Product>();

        public void ShowGoods()
        {
            foreach (Product product in _products)
            {
                product.ShowInfo();
            }
        }
    }

    class Seller : Human
    {
        private List<Product> _products = new List<Product>();

        public Seller()
        {
            CreateProducts();
        }

        private void CreateProducts()
        {
            Random random = new Random();
            int minRandomCount = 10;
            int maxRandomCount = 145;
            int FixPrice = 15;
            int maxProducts = 10;
            List<string> productsNames = new List<string> () 
            { 
                "Мыло твердое",
                "Мыло жидкое",
                "Полотенце",
                "Бритва",
                "Пена для бритья",
                "Гель для душа",
                "Шампунь для головы",
                "Зубная паста",
                "Зубная щетка",
                "Вехотка"
            };

            for (int i = 0; i < maxProducts; i++)
            {
                string productName = productsNames[random.Next(productsNames.Count)];               

                Product product = new Product(productName, FixPrice, random.Next(minRandomCount,maxRandomCount));

                foreach(Product product1 in _products)
                {
                    
                }

                _products.Add(product);
            }
        }

        //private void SaleProducts(ref int money)
        //{
        //    if (base._products.Count > 0)
        //    {
        //        bool isFound = false;
        //        Console.WriteLine("\nВведите наименование товара: \n");
        //        string input = Console.ReadLine();

        //        foreach (Product product in base._products)
        //        {
        //            if (product.Name == input && product.Price <= money)
        //            {
        //                Console.WriteLine("\nТовар куплен!\n");
        //                money -= product.Price;
        //                _products = product;
        //                base._products.Remove(product);
        //                isFound = true;
        //                break;
        //            }
        //            else if (product.Name == input && product.Price > money)
        //            {
        //                Console.WriteLine("\nНедостаточного денег для покупки товара\n");
        //                isFound = true;
        //                break;
        //            }
        //        }

        //        if (isFound == false)
        //        {
        //            Console.WriteLine("\nДанного товара нет в магазине\n");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("\nВ магазине нет товаров!\n");
        //    }
        //}

        //public Product TransferGoods(ref int money)
        //{
        //    SaleProducts(ref money);
        //    return _products;
        //}

        private int ReadInt()
        {
            int result = 0;
            while (int.TryParse(Console.ReadLine(), out result) == false) ;
            return result;
        }
    }

    class Buyer : Human
    {
        public void PutInBag(Product goods)
        {
            _products.Add(goods);
        }

        public void LookInBag()
        {
            foreach (Product product in _products)
            {
                Console.Write($"{product.Name}");
            }
        }
    }
}