using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;

namespace PricingEngine
{
    public class CompetitorProduct
    {
        public string ProductCode { get; private set; }
        public string CompetitorCode { get; private set; }
        public double Price { get; private set; }
        public CompetitorProduct(string code, string competitorCode, double price)
        {
            this.ProductCode = code;
            this.CompetitorCode = competitorCode;
            this.Price = price;
        }
#if DEBUG
        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return $"{ProductCode} {CompetitorCode} {Price}";
        }
#endif

    }
}