using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ViewResult> Index()
        {
            long? length = await MyAsyncMethods.GetPageLength();
            List<string> results = new List<string>();

            /*
             * Null-Condition-Operator:
             * Kann nur auf Properties die Null sein können angewendet werden.
             * Der Operator verhindert das Null Properties verarbeitet werden und
             * damit eine NullReferenceException ausgelöst wird.
             * Coalescing-Operrator (Coalescing = Verschmelzung):
             * Mit dem ?? kann ein Fallbackwert implementiert werden.
             */
            foreach (Product p in Product.GetProducts())
            {
                string name = p?.Name ?? "<No Name>";
                decimal? price = p?.Price ?? 0;
                string relatedName = p?.Related?.Name ?? "<None>";
                // Stringaufbau mit Formatmethode
                //results.Add(string.Format("Name: {0}, Price: {1}, Related: {2}", name, price, relatedName));
                // String-Interpolation: Direktes Einbinden von Variablennamen in ein String.
                results.Add($"Name: {name}, Price: {price}, Related: {relatedName}");
            }

            Product[] productArray =
            {
                new Product() {Name = "Kayak", Price = 275M },
                new Product() { Name = "Lifejacket", Price = 48.95M }
            };

            Product[] yieldArray =
{
                new Product() {Name = "Kayak", Price = 275M },
                new Product() { Name = "Lifejacket", Price = 48.95M },
                new Product() { Name = "Soccer ball", Price = 19.50M },
                new Product() { Name = "Corner flag", Price = 34.95M }
            };

           

            ShoppingCart cart = new ShoppingCart() { Products = Product.GetProducts() };
            decimal cartTotal = cart.TotalPrices();
            decimal arrayTotal = productArray.TotalPrices();
            decimal yieldTotal = yieldArray.FilterByPrice(20).TotalPrices();

            results.Add(string.Format($"Total: {cartTotal:C2} TotalArray: {arrayTotal:C2} YieldArrayTotal: {yieldTotal:C2}"));
            results.Add($"Length: {length}");

            return View(results);
        }
    }
}
