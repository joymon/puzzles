using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PricingEngine
{
    public class PromotionDecorator : PricerDecorator
    {
        public PromotionDecorator(IPricer pricer) : base(pricer)
        {
        }

        public override Product DoPrice(ProductSpec product, IEnumerable<CompetitorProduct> compProducts)
        {
            var filtered = compProducts.Where(cp => cp.Price > compProducts.Average(cpForAverage => cpForAverage.Price) / 2);
            return base.DoPrice(product, filtered);
        }
    }
}