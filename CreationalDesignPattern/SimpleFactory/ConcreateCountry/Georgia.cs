using SimpleFactory.Country;
using System;

namespace SimpleFactory.ConcreateCountry
{
    public class Georgia : ICountry
    {
        public void GetCountry()
        {
            Console.WriteLine("Country Georgia created");
        }
    }
}
