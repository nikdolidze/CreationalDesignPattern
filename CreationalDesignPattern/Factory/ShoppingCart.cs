using Factory.Models.Ecommerce;
using Factory.Models.Shipping;
using Factory.Models.Shipping.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class ShoppingCart
    {
        private readonly Order order;
        private readonly ShippingProviderFactory shipingProviderFactory;

        public ShoppingCart(Order order, ShippingProviderFactory shipingProviderFactory)
        {
            this.order = order;
            this.shipingProviderFactory = shipingProviderFactory;
        }

        public string Finalize()
        {
          var shippingProvider  = shipingProviderFactory.GetShippingProvider(order.Sender.Country);

            order.ShippingStatus = ShippingStatus.ReadyForShippment;

            return shippingProvider.GenerateShippingLabelFor(order);
        }
    }
}
