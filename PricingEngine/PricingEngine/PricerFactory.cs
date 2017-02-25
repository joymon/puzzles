using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingEngine
{
    internal static class PricerFactory
    {
        /// <summary>
        /// Creates IPricer object with required decorators.
        /// </summary>
        /// <returns></returns>
        /// <remarks>Better use BoundaryValueDecorator instead of 2 separate decorators. 
        /// If we use 2 separate decorators the first one will remove items and the average will change in second decorator.
        /// So it wont remove other boundary items.</remarks>
        internal static IPricer Get()
        {
            IPricer pricer = new CompetitivePricer();
            pricer = new SupplyLowDemandLowDecorator(pricer);
            pricer = new SupplyLowDemandHighDecorator(pricer);
            pricer = new SupplyHighDemandLowDecorator(pricer);
            pricer = new BoundaryValueDecorator(pricer);
            return pricer;
        }
    }
}
