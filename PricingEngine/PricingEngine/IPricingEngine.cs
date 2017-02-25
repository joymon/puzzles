using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingEngine
{
    public interface IPricingEngine
    {
        IEnumerable<Product> DoPricing(IEnumerable<ProductSpec> products, IEnumerable<CompetitorProduct> compProducts);
    }
}
