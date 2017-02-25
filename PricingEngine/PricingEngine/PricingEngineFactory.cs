using System;

namespace PricingEngine
{
    public static class PricingEngineFactory
    {
        public  static IPricingEngine Get()
        {
            return new PricingEngine();
        }
    }
}