using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PricingEngine.Tests
{
    [TestClass]
    public class PricingEngineFactory_Get
    {
        [TestMethod]
        public void WhenGetIsCalled_ReturnValidIPricingEngine()
        {
            IPricingEngine engine = PricingEngineFactory.Get();
            Assert.IsInstanceOfType(engine, typeof(IPricingEngine),"PricingEngineFactory not working");
        }
    }
}
