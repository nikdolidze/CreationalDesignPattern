using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Models.Ecommerce.Summary
{
    public interface ISumary
    {
        string CraeteOrderSummary(Order order);
        void Send();
    }

    public class EmailSummary : ISumary
    {
        public string CraeteOrderSummary(Order order)
        {
            throw new NotImplementedException();
        }

        public void Send()
        {
            throw new NotImplementedException();
        }
    }

    public class CsvSummary : ISumary
    {
        public string CraeteOrderSummary(Order order)
        {
            return "this is Csv summary";
        }

        public void Send()
        {
            throw new NotImplementedException();
        }
    }
}
