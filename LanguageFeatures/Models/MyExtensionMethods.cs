﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalPrices(this IEnumerable<Product> products)
        {
            decimal total = 0;
            foreach (Product prod in products)
            {
                total += prod?.Price ?? 0;
            }
            return total;
        }
        public static IEnumerable<Product> FilterByPrice(this IEnumerable<Product> productEnum, decimal minimumPrice)
        {
            foreach(Product prod in productEnum)
            {
                // Yield dient zum hinzufügen von Kriterien um ein Resultatmenge zu reduzieren.
                if((prod?.Price ?? 0) >= minimumPrice)
                {
                    yield return prod;
                }
            }
        }
    }
}
