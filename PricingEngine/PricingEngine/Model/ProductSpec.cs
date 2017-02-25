using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;

namespace PricingEngine
{
    [ExcludeFromCodeCoverage]
    public class ProductSpec
    {
        public string ProductCode { get; private set; }
        public SupplyDemandIndicator Supply { get; private set; }
        public SupplyDemandIndicator Demand { get; private set; }
        public ProductSpec(string code, SupplyDemandIndicator supply, SupplyDemandIndicator demand)
        {
            this.ProductCode = code;
            this.Supply = supply;
            this.Demand = demand;
        }
#if DEBUG
        public override string ToString()
        {
            return $"{ProductCode} {Supply} {Demand}";
        }
    }
#endif

}