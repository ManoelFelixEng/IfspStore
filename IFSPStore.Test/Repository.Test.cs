using IFSPStore.Domain.Entities;
using IFSPStore.Repository.Context;
using IFSPStore.Repository.Repository;
using System.Text.Json;

namespace IFSPStore.Test
{
    [TestClass]
    public sealed class RepositoryTest
    {

        [TestMethod]
        public void TestCategory()
        {
            using (var context = new IFSPStoreContext())
            {
                Console.WriteLine("Connected!");

                var category1 = new Category(1, "Carne");
                var category2 = new Category(2, "Bebidas");
                var category3 = new Category(3, "Doce");

                context.Categories.Add(category1);
                context.Categories.Add(category2);
                context.Categories.Add(category3);

                context.SaveChanges();
                Console.WriteLine("Inser done!");
            }
            using (var context = new IFSPStoreContext())
            {
                foreach (var cat in context.Categories)
                {
                    Console.WriteLine(JsonSerializer.Serialize(cat));

                }
                Console.WriteLine("List Done!");
            }
        }
        [TestMethod]
        public void TestCity()
        {
            using (var context = new IFSPStoreContext())
            {
                Console.WriteLine("Connected!");

                var city1 = new City(1, "São Paulo", "SP");
                var city2 = new City(2, "Campina", "SP");
                var city3 = new City(3, "Macuco", "RJ");

                context.Cities.Add(city1);
                context.Cities.Add(city2);
                context.Cities.Add(city3);

                context.SaveChanges();
                Console.WriteLine("Inser done!");
            }
            using (var context = new IFSPStoreContext())
            {
                foreach (var cat in context.Cities)
                {
                    Console.WriteLine(JsonSerializer.Serialize(cat));

                }
                Console.WriteLine("List Done!");
            }
        }

        [TestMethod]
        public void TestCustomer()
        {
            using (var context = new IFSPStoreContext())
            {
                Console.WriteLine("Connected!");

                var city1 = context.Cities.Find(1);
                var city2 = context.Cities.Find(2);
                var city3 = context.Cities.Find(3);

                var customer1 = new Customer(1, "Raissa", "Rua João Trevisan, nº1663", "Cenrtro", "BI3024954", city1);
                var customer2 = new Customer(2, "Diego", "Rua Jose Catilio, nº533", "Cenrtro", "BI3025845", city2);
                var customer3 = new Customer(3, "Gabriel", "Rua Abramo Gon, nº227", "Cenrtro", "BI3021955", city3);

                context.Customers.Add(customer1);
                context.Customers.Add(customer2);
                context.Customers.Add(customer3);

                context.SaveChanges();
                Console.WriteLine("Inser done!");
            }
            using (var context = new IFSPStoreContext())
            {
                foreach (var cat in context.Customers)
                {
                    Console.WriteLine(JsonSerializer.Serialize(cat));

                }
                Console.WriteLine("List Done!");
            }
        }

        [TestMethod]
        public void TestProduct()
        {
            using (var context = new IFSPStoreContext())
            {
                Console.WriteLine("Connected!");

                var dataTime = DateTime.Now;
                var category1 = context.Categories.Find(1);
                var category2 = context.Categories.Find(2);
                var category3 = context.Categories.Find(2);

                var product1 = new Product(1, "Coca-Cola 2L", 11.9m, 50m, dataTime, "UN",  category2);
                var product2 = new Product(2, "KitKat", 3.49m, 50m, dataTime, "UN", category3);
                var product3 = new Product(3, "Macarrão Parafuso", 4.9m, 50m, dataTime, "UN", category1);

                context.Products.Add(product1);
                context.Products.Add(product2);
                context.Products.Add(product3);

                context.SaveChanges();
                Console.WriteLine("Inser done!");
            }
            using (var context = new IFSPStoreContext())
            {
                foreach (var cat in context.Products)
                {
                    Console.WriteLine(JsonSerializer.Serialize(cat));

                }
                Console.WriteLine("List Done!");
            }
        }
        [TestMethod]
        public void TestUser()
        {
            using (var context = new IFSPStoreContext())
            {
                Console.WriteLine("Connected!");
                var dataTime = DateTime.Now;

                var user1 = new User(1, "Arthur", "12345", "arthur15", "arthurpires374@gmail.com", dataTime, dataTime, true);
                var user2 = new User(2, "Andreia", "12345", "andreia15", "andreipires374@gmail.com", dataTime, dataTime, true);

                context.Users.Add(user1);
                context.Users.Add(user2);

                context.SaveChanges();
                Console.WriteLine("Inser done!");
            }
            using (var context = new IFSPStoreContext())
            {
                foreach (var cat in context.Users)
                {
                    Console.WriteLine(JsonSerializer.Serialize(cat));

                }
                Console.WriteLine("List Done!");
            }

        }
        [TestMethod]
        public void TestSale()
        {
            using (var context = new IFSPStoreContext())
            {
                Console.WriteLine("Connected!");

                var dateTime = DateTime.Now;
                var saleman1 = context.Users.Find(1);
                var saleman2 = context.Users.Find(2);
                var costumer1 = context.Customers.Find(1);
                var costumer2 = context.Customers.Find(2);
                var costumer3 = context.Customers.Find(3);

                var sale1 = new Sale(1, dateTime, 59.5m, saleman1, costumer1);
                var sale2 = new Sale(2, dateTime, 34.9m, saleman2, costumer2);
                var sale3 = new Sale(3, dateTime, 9.8m, saleman1, costumer3);

                context.Sales.Add(sale1);
                context.Sales.Add(sale2);
                context.Sales.Add(sale3);

                context.SaveChanges();
                Console.WriteLine("Inser done!");
            }
            using (var context = new IFSPStoreContext())
            {
                foreach (var cat in context.Sales)
                {
                    Console.WriteLine(JsonSerializer.Serialize(cat));

                }
                Console.WriteLine("List Done!");
            }
        }
        [TestMethod]
        public void TestSaleItem()
        {
            using (var context = new IFSPStoreContext())
            {
                Console.WriteLine("Connected!");

                var sale1 = context.Sales.Find(1);
                var sale2 = context.Sales.Find(2);
                var sale3 = context.Sales.Find(3);
                var product1 = context.Products.Find(1);
                var product2 = context.Products.Find(2);
                var product3 = context.Products.Find(3);

                decimal quantity1 = 5m;
                decimal quantity2 = 10m;
                decimal quantity3 = 2m;

                decimal unitPrice1 = product1.Price;
                decimal unitPrice2 = product2.Price;
                decimal unitPrice3 = product3.Price;

                decimal totalPrice1 = quantity1 * unitPrice1;
                decimal totalPrice2 = quantity2 * unitPrice2;
                decimal totalPrice3 = quantity3 * unitPrice3;

                var saleItem1 = new SaleItem(1, quantity1, unitPrice1, totalPrice1, sale1, product1);
                var saleItem2 = new SaleItem(2, quantity2, unitPrice2, totalPrice2, sale2, product2);
                var saleItem3 = new SaleItem(3, quantity3, unitPrice3, totalPrice3, sale3, product3);

                context.SaleItens.Add(saleItem1);
                context.SaleItens.Add(saleItem2);
                context.SaleItens.Add(saleItem3);

                context.SaveChanges();
                Console.WriteLine("Inser done!");
            }
            using (var context = new IFSPStoreContext())
            {
                foreach (var cat in context.SaleItens)
                {
                    Console.WriteLine(JsonSerializer.Serialize(cat));

                }
                Console.WriteLine("List Done!");
            }
        }

        [TestMethod]

        public void TestProduuctRepository()
        {
            var context = new IFSPStoreContext();
            var _categoryRepository = new BaseRepository<Category>(context);
            var _productRepository = new BaseRepository<Product>(context);

            var category1 = new Category();
            category1.Name = "Enlatados";
            _categoryRepository.Insert(category1);
            var category2 = new Category();
            category2.Name = "Saudáveis";
            _categoryRepository.Insert(category2);

            var prod1 = new Product();
            prod1.Name = "Sardinha";
            prod1.Price = 10.55m;
            prod1.Quantity = 55m;
            prod1.SalesUnit = "Lata";
            prod1.DateShop = DateTime.Now;
            prod1.Category = category1;
            _productRepository.Insert(prod1);

            var prod2 = new Product();
            prod2.Name = "Whey Protein";
            prod1.Price = 155.55m;
            prod2.Quantity = 61m;
            prod2.SalesUnit = "Pote";
            prod2.DateShop = DateTime.Now;
            prod2.Category = category2;
            _productRepository.Insert(prod2);


        }
    }
}
