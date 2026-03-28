using ShopMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMaster.Services
{
    public static class ReportService
    {
        // Uses Action<Product> for flexible printing
        public static void PrintReport(
            List<Product> products,
            Action<Product> printer)
        {
            foreach (var product in products)
            {
                printer(product);
            }
        }

        // Uses Func<Product, TResult> for transformation
        public static List<TResult> TransformProducts<TResult>(
            List<Product> products,
            Func<Product, TResult> transformer)
        {
            var result = new List<TResult>();

            foreach (var product in products)
            {
                result.Add(transformer(product));
            }

            return result;
        }
    }
}
