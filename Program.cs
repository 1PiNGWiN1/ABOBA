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
            Shop shop = new Shop(seller,buyer);
            bool isWork = true;
            int money = 100;

            while (isWork == true)
            {
                Console.WriteLine($"Ваши средства: {money} руб.");

                Console.WriteLine($"\nТовары на прилавке: \n");

                seller.ShowProducts();

                Console.WriteLine($"\nВыберите пункт взаимодействия:" +
                    $"\n{ShowProductsCommand}. Купить товар " +
                    $"\n{ShowBagCommand}. Посмотреть свою сумку " +
                    $"\n{ExitCommand}. Выход\n");

                switch (Console.ReadLine())
                {
                    case ShowProductsCommand:
                        //seller.SaleProducts(ref money);
                        //buyer.PutInBag();
                        shop.TrySellProducts(ref money);
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

    class Shop
    {
        private Seller _seller;
        private Buyer _buyer;

        public Shop(Seller seller, Buyer buyer)
        {
            _seller = seller;
            _buyer = buyer;
        }

        public void TrySellProducts(ref int money)
        {
            if (_seller.ProductsCount() == 0)
            {
                Console.WriteLine("\nВ магазине нет товаров!\n");
                return;
            }
                      
            (bool IsFound,Product Product) productInfo = _seller.IsProductExists();

            if (productInfo.IsFound == false)
            {
                Console.WriteLine("\nДанного товара нет в магазине\n");
            }
            else
            {
                if (productInfo.Product.Price > money)
                {
                    Console.WriteLine("\nНедостаточного денег для покупки товара\n");                    
                }
                else
                {
                    
                    Console.WriteLine("\nТовар куплен!\n");
                    money -= productInfo.Product.Price;
                    _seller.ProductOut(productInfo.Product);
                    _buyer.PutInBag(productInfo.Product);
                }
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

    abstract class Human
    {
        protected List<Product> _products;

        public void ShowProducts()
        {
            foreach (Product product in _products)
            {
                product.ShowInfo();
            }
        }
    }

    class Seller : Human
    {
        public Seller()
        {
            _products = new List<Product>();
            CreateProducts();
        }

        public List<Product> GiveProducts()
        {
            List<Product> products = new List<Product>(_products);
            return products;
        }

        public int ProductsCount()
        {
            return _products.Count;
        }

        private void CreateProducts()
        {
            /*1*/
            _products.Add(new Product("Мыло твердое", 15, 245));
            /*2*/
            _products.Add(new Product("Мыло жидкое", 15, 245));
            /*3*/
            _products.Add(new Product("Пена для бритья", 15, 245));
            /*4*/
            _products.Add(new Product("Гель для душа", 15, 245));
            /*5*/
            _products.Add(new Product("Шампунь для головы", 15, 245));
            /*6*/
            _products.Add(new Product("Полотенце", 15, 245));
            /*7*/
            _products.Add(new Product("Зубная щётка", 15, 245));
            /*8*/
            _products.Add(new Product("Зубная паста", 15, 245));
            /*9*/
            _products.Add(new Product("Бритва", 15, 245));
            /*0*/
            _products.Add(new Product("Гель для бритья", 15, 245));
        }

        public (bool, Product) IsProductExists()
        {
            Console.WriteLine("\nВведите наименование товара: \n");
            string input = Console.ReadLine();

            foreach (Product product in _products)
            {
                if (product.Name == input)
                {
                    return (true,product);
                }                
            }

            return (false, null);
        }

        public void ProductOut (Product product)
        {
            _products.Remove(product);
        }
    }

    class Buyer : Human
    {
        public Buyer()
        {
            _products = new List<Product>();
        }

        public void PutInBag(Product product)
        {
            _products.Add(product);
        }

        public void LookInBag()
        {
            if (_products.Count == 0)
            {
                Console.WriteLine($"В инвентаре пусто!");
            }    

            foreach (Product product in _products)
            {
                Console.Write($"{product.Name} ");
            }
        }
    }
}