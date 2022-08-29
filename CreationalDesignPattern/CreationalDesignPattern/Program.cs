using AbstractFactory;
using Builder;
using Builder_Pattern;
using Factory;
using Factory.Models;
using Factory.Models.Ecommerce;
using Factory.Models.Shipping.Factories;
using FactoryMethod;
using Prototype;
using SimpleFactory;
using SimpleFactory.ConcreateFactory;
using SimpleFactory.Country;
using Singlenton;
using System;
using System.Collections.Generic;

namespace CreationalDesignPattern
{


    internal class Program
    {
        static void Main(string[] args)
        {


            var manager = new Manager("Cindy");
            var managerClone =(Manager) manager.Clone();

            Console.WriteLine($"Manager was cloned : {managerClone.Name}");

            var employee = new Employee("Kevin", manager);
            var employeeClone = (Employee)employee.Clone();
            Console.WriteLine($"Employee was  cloned {employeeClone.Name}" +
                $"With Manager {employeeClone.Manager.Name}");



            Builder2();
            Builder();
            AbstractFactory();
            FactoryMethod();
            Singlenton();
            Factory();
            SimpleFactory();

        }
        public static void Builder2()
        {
            var items = new List<FurnitureItem>
            {
                new FurnitureItem("Sectional Couch", 55.5, 22.4, 78.6, 35.0),
                new FurnitureItem("Nightstand", 25.0, 12.4, 20.0, 10.0),
                new FurnitureItem("Dining Table", 105.0, 35.4, 100.6, 55.5),
            };

            var inventoryBuilder = new DailyReportBuilder(items);
            //var director = new InventoryBuildDirector(inventoryBuilder);

            //director.BuildCompleteReport();
            //var directorReport = inventoryBuilder.GetDailyReport();
            //Console.WriteLine(directorReport.Debug());

            var fluentReport = inventoryBuilder.AddTitle().AddDimensions().AddLogistics(DateTime.Now).GetDailyReport();
            Console.WriteLine(fluentReport.Debug());
        }
        public static void Builder()
        {
            var garage = new Garage();

            var miniBuilder = new MiniBuilder();
            var bmwBuilder = new BMWBuilder();

            garage.Construct(miniBuilder);
            Console.WriteLine(miniBuilder.Car.ToString());
            // or: 
            garage.Show();

            garage.Construct(bmwBuilder);
            Console.WriteLine(bmwBuilder.Car.ToString());
            // or: 
            garage.Show();

            Console.ReadKey();
        }
        public static void Factory()
        {
            #region Create Order
            Console.Write("Recipient Country: ");
            var recipientCountry = Console.ReadLine().Trim();

            Console.Write("Sender Country: ");
            var senderCountry = Console.ReadLine().Trim();

            Console.Write("Total Order Weight: ");
            var totalWeight = Convert.ToInt32(Console.ReadLine().Trim());

            var order = new Order
            {
                Recipient = new Address
                {
                    To = "Filip Ekberg",
                    Country = recipientCountry
                },

                Sender = new Address
                {
                    To = "Someone else",
                    Country = senderCountry
                },

                TotalWeight = totalWeight
            };

            order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m), 1);
            order.LineItems.Add(new Item("CONSULTING", "Building a website", 100m), 1);
            #endregion
            IPurchaseProviderFactory purchaseProviderFactory;

            var factoryProvider = new PurchanseProviderFactoryProvider();
            purchaseProviderFactory = factoryProvider.CreateFactorFor(order.Sender.Country);

            //if(order.Sender.Country == "Sweed")
            //{
            //    purchaseProviderFactory = new SwedenPurchaseProviderFactory();
            //}
            //else if(order.Sender.Country == "Australia")
            //{
            //    purchaseProviderFactory= new AustralianPurchaseProviderFactory();
            //}
            //else
            //{
            //    throw new Exception();
            //}


            var cart = new ShoppingCart(order, purchaseProviderFactory);

            var shippingLabel = cart.Finalize();

            Console.WriteLine(shippingLabel);
        }
        public static void SimpleFactory()
        {
            ICountry country1 = CountryFactory.CrateCountry(CountryEnum.Georgia);
            country1.GetCountry();

            ICountry country2 = CountryFactory.CrateCountry(CountryEnum.Usa);
            country2.GetCountry();

        }
        public static void Singlenton()
        {
            var instance1 = logger.Instance;
            var instance2 = logger.Instance;
            if (instance1 == instance2 && instance2 == logger.Instance)
            {
                Console.WriteLine("instances are same");
            }

            instance1.Log($"message from {nameof(instance1)}");
            instance1.Log($"message from {nameof(instance2)}");
            logger.Instance.Log($"message from {nameof(logger.Instance)}");

            Console.Read();
        }
        public static void FactoryMethod()
        {

            var factories = new List<DiscountFactory> {
                   new CodeDiscountFactory(Guid.NewGuid()),
                   new CountryDiscountFactory("BE") };

            foreach (var factory in factories)
            {
                var discountService = factory.CraeteDiscountService();
                Console.WriteLine($"Percentage {discountService.DiscountPercentage} " +
                    $"coming from {discountService}");
            }

            Console.ReadKey();

        }
        public static void AbstractFactory()
        {

            var belgiumShoppingCartPurchaseFactory = new BelgiumShoppingCartPurchaseFactory();
            var shoppingCartForBelgium = new ShoppingCartClinet(belgiumShoppingCartPurchaseFactory);
            shoppingCartForBelgium.CalculateCosts();

            var franceShoppingCartPurchaseFactory = new FranceShoppingCartPurchaseFactory();
            var shoppingCartForFrance = new ShoppingCartClinet(franceShoppingCartPurchaseFactory);
            shoppingCartForFrance.CalculateCosts();

            Console.ReadKey();
        }
    }
}
