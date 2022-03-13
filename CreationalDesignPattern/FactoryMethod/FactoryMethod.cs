using System;

/*
 Factory method idea is that this patern  lets a class differ instantiation to one or more sublacces.
the intent of the factory method pattern is to define an interface for crating an object but let sublasses decide which class to instantiate.
  Factory method lets a class defer instantiation to sublasses.
            use cases:
                when you dont know in advance which type of object you code should work with.
                when class want its subclass to specify the object it crates
 */
namespace FactoryMethod
{
    public abstract class DiscountService
    {
        public abstract int DiscountPercentage { get; }
        public override string ToString()
        {
            return GetType().Name;
        }
    }

    public class CountryDicountService : DiscountService
    {
        private readonly string _countryIdentifier;

        public CountryDicountService(string countryIdentifier)
        {
            this._countryIdentifier = countryIdentifier;
        }
        public override int DiscountPercentage
        {

            get
            {
                switch (_countryIdentifier)
                {
                    // if you're from Belgium, you get a better discount :)
                    case "BE":
                        return 20;
                    default:
                        return 10;
                }
            }
        }
    }
    public class CoudeDiscountService : DiscountService
    {
        private readonly Guid _code;

        public CoudeDiscountService(Guid code)
        {
            this._code = code;
        }
        public override int DiscountPercentage
        {
            // each code returns the same fixed percentage, but a code is only 
            // valid once - include a check to so whether the code's been used before
            // ... 
            get => 15;
        }
    }

    public abstract class DiscountFactory
    {
        public abstract DiscountService CraeteDiscountService();
    }
    public class CountryDiscountFactory : DiscountFactory
    {
        private readonly string countryIdentidier;

        public CountryDiscountFactory(string countryIdentidier)
        {
            this.countryIdentidier = countryIdentidier;
        }
        public override DiscountService CraeteDiscountService()
        {
            return new CountryDicountService(countryIdentidier);
        }
    }
    public class CodeDiscountFactory : DiscountFactory
    {
        private readonly Guid guid;

        public CodeDiscountFactory(Guid guid)
        {
            this.guid = guid;
        }
        public override DiscountService CraeteDiscountService()
        {
            return new CoudeDiscountService(guid);
        }
    }
}
