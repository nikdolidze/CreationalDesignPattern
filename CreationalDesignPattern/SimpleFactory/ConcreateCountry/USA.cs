using SimpleFactory.Country;
using System;

namespace SimpleFactory.ConcreateCountry
{
    public class USA : ICountry
    {
        public void GetCountry()
        {
            Console.WriteLine("Country USA created");
        }
    }
}
