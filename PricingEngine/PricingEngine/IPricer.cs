using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PricingEngine
{

    public interface IPricer
    {
        Product DoPrice(ProductSpec product, IEnumerable<CompetitorProduct> compProducts);
    }

}