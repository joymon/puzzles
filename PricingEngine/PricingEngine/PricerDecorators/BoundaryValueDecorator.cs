using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingEngine
{
    public class BoundaryValueDecorator : PricerDecorator
    {
        public BoundaryValueDecorator(IPricer pricer) : base(pricer)
        {
        }

        public override Product DoPrice(ProductSpec product, IEnumerable<CompetitorProduct> compProducts)
        {
            var filtered = compProducts.Where(cp =>
                cp.Price < GetAvgPricePlus50PercentageOfAverage(compProducts)
                &&
                cp.Price > GetAvgPriceMinus50PercentageOfAverage(compProducts));
            return base.DoPrice(product, filtered);
        }

        private static double GetAvgPricePlus50PercentageOfAverage(IEnumerable<CompetitorProduct> compProducts)
        {
            return compProducts.Average(cpForAverage => cpForAverage.Price) + (FiftyPercentageOfAveragePrice(compProducts));
        }

        private static double FiftyPercentageOfAveragePrice(IEnumerable<CompetitorProduct> compProducts)
        {
            return compProducts.Average(cpForAverage => cpForAverage.Price) * 50 / 100;
        }

        private static double GetAvgPriceMinus50PercentageOfAverage(IEnumerable<CompetitorProduct> compProducts)
        {
            return compProducts.Average(cpForAverage => cpForAverage.Price) - FiftyPercentageOfAveragePrice(compProducts);
        }
    }
}
