using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PricingEngine
{
    /// <summary>
    /// Finds the competitive price from most occuring lowest competitor price. If there is no price, returs <see cref="CompetitivePricer.PriceReplacementIfPriceNotFound"/> as price
    /// </summary>
    public class CompetitivePricer : IPricer
    {
        private const int PriceReplacementIfPriceNotFound = -1;

        Product IPricer.DoPrice(ProductSpec product, IEnumerable<CompetitorProduct> compProducts)
        {
            var cpgInFrequentOrder= compProducts.GroupBy(cp => cp.Price)
                .OrderByDescending(cpg => cpg.Count())
                .ThenBy(cpg=>cpg.Key)
                .FirstOrDefault();
            return new Product(product, cpgInFrequentOrder==null? CompetitivePricer.PriceReplacementIfPriceNotFound : cpgInFrequentOrder.Key);
        }
    }
}