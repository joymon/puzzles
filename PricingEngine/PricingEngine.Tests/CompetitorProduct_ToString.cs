using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PricingEngine.Tests
{
    [TestClass]
    public class CompetitorProduct_ToString
    {
        [TestMethod]
        public void WhenPropertiesHasValues_ReturnValuesSeparatedBySpace()
        {
            global::PricingEngine.CompetitorProduct cp = new global::PricingEngine.CompetitorProduct("a", "b", 12.421);
            Assert.AreEqual("a b 12.421", cp.ToString(), $"ToString is not working.Actual {cp.ToString()}");
        }
    }
}
