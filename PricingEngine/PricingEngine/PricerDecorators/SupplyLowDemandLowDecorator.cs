using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingEngine
{
    internal class SupplyLowDemandLowDecorator : PricerDecorator
    {
        private const int PercentageToAdd = 10;

        public SupplyLowDemandLowDecorator(IPricer pricer) : base(pricer)
        {
        }

        public override Product DoPrice(ProductSpec productSpec, IEnumerable<CompetitorProduct> compProducts)
        {
            Product product = base.DoPrice(productSpec, compProducts);
            if (productSpec.Demand == SupplyDemandIndicator.Low && productSpec.Supply == SupplyDemandIndicator.Low)
            {
                return new Product(productSpec, product.Price + (product.Price * SupplyLowDemandLowDecorator.PercentageToAdd / 100));
            }
            else
            {
                return product;
            }
        }
    }
}
