﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Models.Shipping.Factories
{
    public abstract class ShippingProviderFactory
    {
        public abstract ShippingProvider CreateShippingProvider(string country);

        public ShippingProvider GetShippingProvider(string country)
        {
            var provider = CreateShippingProvider(country);
            if (country == "Sweeden" && provider.InsuranceOptions.ProviderHasInsurance)
            {
                provider.RequireSignature = false;
            }
            return provider;
        }
    }

    public class StandardShippingProviderFactory : ShippingProviderFactory
    {
        public override ShippingProvider CreateShippingProvider(string country)
        {
            ShippingProvider shippingProvider;
            #region Create Shipping Provider

            if (country == "Australia")
            {
                #region Australia Post Shipping Provider
                var shippingCostCalculator = new ShippingCostCalculator(
                    internationalShippingFee: 250,
                    extraWeightFee: 500
                )
                {
                    ShippingType = ShippingType.Standard
                };

                var customsHandlingOptions = new CustomsHandlingOptions
                {
                    TaxOptions = TaxOptions.PrePaid
                };

                var insuranceOptions = new InsuranceOptions
                {
                    ProviderHasInsurance = false,
                    ProviderHasExtendedInsurance = false,
                    ProviderRequiresReturnOnDamange = false
                };

                shippingProvider = new AustraliaPostShippingProvider("CLIENT_ID",
                    "SECRET",
                    shippingCostCalculator,
                    customsHandlingOptions,
                    insuranceOptions);
                #endregion
            }
            else if (country == "Sweden")
            {
                #region Swedish Postal Service Shipping Provider
                var shippingCostCalculator = new ShippingCostCalculator(
                    internationalShippingFee: 50,
                    extraWeightFee: 100
                )
                {
                    ShippingType = ShippingType.Express
                };

                var customsHandlingOptions = new CustomsHandlingOptions
                {
                    TaxOptions = TaxOptions.PayOnArrival
                };

                var insuranceOptions = new InsuranceOptions
                {
                    ProviderHasInsurance = true,
                    ProviderHasExtendedInsurance = false,
                    ProviderRequiresReturnOnDamange = false
                };

                shippingProvider = new SwedishPostalServiceShippingProvider("API_KEY",
                    shippingCostCalculator,
                    customsHandlingOptions,
                    insuranceOptions);
                #endregion
            }
            else
            {
                throw new NotSupportedException("No shipping provider found for origin country");
            }
            #endregion

            return shippingProvider;
        }
    }
    public class GlobalExpressShipingProciderFactory : ShippingProviderFactory
    {
        public override ShippingProvider CreateShippingProvider(string country)
        {
            return new GlobalExpressShipingProvider();
        }
    }

}
