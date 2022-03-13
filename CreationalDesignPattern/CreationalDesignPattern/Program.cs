﻿using Factory;
using Factory.Models;
using Factory.Models.Ecommerce;
using Factory.Models.Shipping.Factories;
using SimpleFactory;
using SimpleFactory.ConcreateFactory;
using SimpleFactory.Country;
using System;

namespace CreationalDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
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




            SimpleFactory();

        }

        public static void SimpleFactory()
        {
            ICountry country1 = CountryFactory.CrateCountry(CountryEnum.Georgia);
            country1.GetCountry();

            ICountry country2 = CountryFactory.CrateCountry(CountryEnum.Usa);
            country2.GetCountry();

        }
    }
}
