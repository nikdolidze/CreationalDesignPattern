using Factory;
using Factory.Models;
using Factory.Models.Ecommerce;
using Factory.Models.Shipping.Factories;
using FactoryMethod;
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

            FactoryMethod();
            Singlenton();
            Factory();
            SimpleFactory();

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
    }
}
