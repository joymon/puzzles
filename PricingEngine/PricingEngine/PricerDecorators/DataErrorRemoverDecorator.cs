using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PricingEngine
{
    public class DataErrorRemoverDecorator : PricerDecorator
    {
        public DataErrorRemoverDecorator(IPricer pricer) : base(pricer)
        {
        }

        public override Product DoPrice(ProductSpec product, IEnumerable<CompetitorProduct> compProducts)
        {
            var filtered = compProducts.Where(cp => cp.Price < GetAvgPricePlus50PercentageOfAverage(compProducts));
            return base.DoPrice(product, filtered);
        }

        private static double GetAvgPricePlus50PercentageOfAverage(IEnumerable<CompetitorProduct> compProducts)
        {
            return compProducts.Average(cpForAverage => cpForAverage.Price) + compProducts.Average(cpForAverage => cpForAverage.Price) / 2;
        }
    }
}