using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingEngine
{
    public class PricingEngine : IPricingEngine
    {
        /// <summary>
        /// Does the pricing by calling required components
        /// </summary>
        /// <param name="products"></param>
        /// <param name="compProducts"></param>
        /// <returns></returns>
        IEnumerable<Product> IPricingEngine.DoPricing(IEnumerable<ProductSpec> products, IEnumerable<CompetitorProduct> compProducts)
        {
            var result = products.Select((prod) =>
            {
                IPricer pricer = PricerFactory.Get();
                return pricer.DoPrice(prod, compProducts.Where(cp => cp.ProductCode == prod.ProductCode));
            });
            return result;
        }
    }
}
