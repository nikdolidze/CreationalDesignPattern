using SimpleFactory.ConcreateCountry;
using SimpleFactory.Country;
using System;

namespace SimpleFactory.ConcreateFactory
{
    public class CountryFactory
    {
        public static ICountry CrateCountry(CountryEnum country)
        {
            switch (country)
            {
                case CountryEnum.Georgia:
                    return new Georgia();
                case CountryEnum.Usa:
                    return new USA();
                default:
                    throw new ArgumentException("Invalid country");
            }
        }

        public static ICountry CrateCountry(object xiamo)
        {
            throw new NotImplementedException();
        }
    }
}
