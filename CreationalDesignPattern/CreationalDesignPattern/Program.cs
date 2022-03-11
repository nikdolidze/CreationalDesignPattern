using SimpleFactory;
using SimpleFactory.ConcreateFactory;
using SimpleFactory.Country;

namespace CreationalDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
