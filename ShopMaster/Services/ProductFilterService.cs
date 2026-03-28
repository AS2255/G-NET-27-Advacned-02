using ShopMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMaster.Services
{
    public static class ProductFilterService
    {
        // Uses Predicate<Product> for filtering
        public static List<Product> FilterProducts(
            List<Product> products,
            Predicate<Product> condition)
        {
            var result = new List<Product>();

            foreach (var product in products)
            {
                if (condition(product))
                    result.Add(product);
            }

            return result;
        }
    }
}
