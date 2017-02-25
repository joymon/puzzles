using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PricingEngine
{
    public abstract class PricerDecorator : IPricer
    {
        protected IPricer pricer;

        public PricerDecorator(IPricer pricer)
        {
            if (pricer == null) throw new ArgumentNullException(nameof(pricer));
            this.pricer = pricer;
        }

        public virtual Product DoPrice(ProductSpec product, IEnumerable<CompetitorProduct> compProducts)
        {
            return pricer.DoPrice(product, compProducts);
        }
    }
}