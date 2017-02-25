using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PricingEngine.Tests
{
    [TestClass]
    public class PricerDecorator_DoPricing
    {
        [TestMethod][ExpectedException(typeof (ArgumentNullException))]
        public void WhenNullIsPassedToConstructor_ThrowArguementException()
        {
            DataErrorRemoverDecorator deco = new DataErrorRemoverDecorator(null);
        }
    }
}
