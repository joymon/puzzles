using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingEngine
{
    internal class SupplyHighDemandLowDecorator : PricerDecorator
    {
        private const int PercentageToDecrease = 5;

        public SupplyHighDemandLowDecorator(IPricer pricer) : base(pricer)
        {
        }

        public override Product DoPrice(ProductSpec productSpec, IEnumerable<CompetitorProduct> compProducts)
        {
            Product product = base.DoPrice(productSpec, compProducts);
            if (productSpec.Supply == SupplyDemandIndicator.High
                &&
                productSpec.Demand == SupplyDemandIndicator.Low)
            {
                return new Product(productSpec, product.Price - (product.Price * SupplyHighDemandLowDecorator.PercentageToDecrease / 100));
            }
            else
            {
                return product;
            }
        }
    }
}
