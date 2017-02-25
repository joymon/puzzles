using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingEngine
{
    public enum SupplyDemandIndicator { Low,High}
    public class Product
    {
        public double Price { get; private set; }
        public ProductSpec Spec { get; private set; }
        public Product(ProductSpec spec, double price)
        {
            this.Spec = spec;
            this.Price = price;
        }
    }
}
