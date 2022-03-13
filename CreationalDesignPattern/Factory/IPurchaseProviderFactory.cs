using Factory.Models.Ecommerce;
using Factory.Models.Ecommerce.Invoice;
using Factory.Models.Ecommerce.Summary;
using Factory.Models.Shipping;
using Factory.Models.Shipping.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public interface IPurchaseProviderFactory
    {
        ShippingProvider CrateShipingProvider(Order order);
        IInvoice CrateInvoice(Order order);
        ISumary CrateSummary(Order order);
    }

    public class AustralianPurchaseProviderFactory : IPurchaseProviderFactory
    {
        public IInvoice CrateInvoice(Order order)
        {
            return new GSTInvoice();
        }

        public ShippingProvider CrateShipingProvider(Order order)
        {
            var shipingProviderFactory = new StandardShippingProviderFactory();
            return shipingProviderFactory.CreateShippingProvider(order.Sender.Country);
        }

        public ISumary CrateSummary(Order order)
        {
            return new CsvSummary();
        }
    }
    public class SwedenPurchaseProviderFactory : IPurchaseProviderFactory
    {
        public IInvoice CrateInvoice(Order order)
        {
            if (order.Recipient.Country != order.Sender.Country)
            {
                return new NoVatInvoice();
            }
            return new VATInvoice();
        }

        public ShippingProvider CrateShipingProvider(Order order)
        {
            ShippingProviderFactory shippingProviderFactory;
            if (order.Recipient.Country != order.Sender.Country)
            {
              shippingProviderFactory = new GlobalExpressShipingProciderFactory();
            }
            else
            {
                shippingProviderFactory=new StandardShippingProviderFactory();
            }
            return shippingProviderFactory.CreateShippingProvider(order.Sender.Country);
        }

        public ISumary CrateSummary(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
