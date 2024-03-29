﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Models
{
    public class PurchanseProviderFactoryProvider
    {
        private IEnumerable<Type> facories;
        public PurchanseProviderFactoryProvider()
        {
            facories = Assembly.GetAssembly(typeof(PurchanseProviderFactoryProvider))
                .GetTypes()
                .Where(t=> typeof(IPurchaseProviderFactory).IsAssignableFrom(t));
        }
        public IPurchaseProviderFactory CreateFactorFor(string name)
        {
            var factory = facories.Single(x=>x.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()));

            return (IPurchaseProviderFactory)Activator.CreateInstance(factory);
        }

    }
}
