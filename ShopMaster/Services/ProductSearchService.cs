using ShopMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMaster.Services
{
    public static class ProductSearchService
    {
        // Uses Func<Product, bool> for flexible filtering
        public static List<Product> SearchProducts(
            List<Product> products,
            Func<Product, bool> filter)
        {
            var result = new List<Product>();

            foreach (var product in products)
            {
                if (filter(product))
                    result.Add(product);
            }

            return result;
        }
    }
}
