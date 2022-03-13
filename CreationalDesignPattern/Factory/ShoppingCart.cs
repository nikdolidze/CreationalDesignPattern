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
        private readonly IPurchaseProviderFactory purchaseProviderFactory;
        private readonly ShippingProviderFactory shipingProviderFactory;

        public ShoppingCart(Order order, ShippingProviderFactory shipingProviderFactory)
        {
            this.order = order;
            this.shipingProviderFactory = shipingProviderFactory;
        }
        public ShoppingCart(Order order, IPurchaseProviderFactory purchaseProviderFactory)
        {
            this.order = order;
            this.purchaseProviderFactory = purchaseProviderFactory;
        }
        

        public string Finalize()
        {
         var shippingProviderodl  = shipingProviderFactory.GetShippingProvider(order.Sender.Country);
          var shippingProvider  = purchaseProviderFactory.CrateShipingProvider(order);

            var invoice = purchaseProviderFactory.CrateInvoice(order);
            
            var summary = purchaseProviderFactory.CrateSummary(order);
            summary.Send();


            order.ShippingStatus = ShippingStatus.ReadyForShippment;

            return shippingProvider.GenerateShippingLabelFor(order);
        }
    }
}
