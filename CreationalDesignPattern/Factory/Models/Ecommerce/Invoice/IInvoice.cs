using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Models.Ecommerce.Invoice
{
    public interface IInvoice
    {
        public byte[] GenerateInvoice();
    }
    public class GSTInvoice : IInvoice
    {
        public byte[] GenerateInvoice()
        {
            return Encoding
                    .Default
                    .GetBytes("Hello world from GST invoice");
        }
    }

    public class NoVatInvoice : IInvoice
    {
        public byte[] GenerateInvoice()
        {
            return Encoding
                    .Default
                    .GetBytes("Hello world from NoVat invoice");
        }
    }

    public class VATInvoice : IInvoice
    {
        public byte[] GenerateInvoice()
        {
            return Encoding
                    .Default
                    .GetBytes("Hello world from VAT invoice");
        }
    }
}
