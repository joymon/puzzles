using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PricingEngine;
namespace PricingEngine.Tests
{
    [TestClass]
    public class Extensions_ToSupplyDemandIndicator
    {
        [TestMethod]
        public void WhenInputIsH_ReturnHigh()
        {
            SupplyDemandIndicator result = "H".ToSupplyDemandIndicator();
            Assert.AreEqual(SupplyDemandIndicator.High, result, $"Extensions_ToSupplyDemandIndicator is not working. Actual {result}");
        }
        [TestMethod]
        public void WhenInputIsL_ReturnHigh()
        {
            SupplyDemandIndicator result = "L".ToSupplyDemandIndicator();
            Assert.AreEqual(SupplyDemandIndicator.Low, result, $"Extensions_ToSupplyDemandIndicator is not working. Actual {result}");
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void WhenInputIsWrong_ThrowInvalidCastException()
        {
            SupplyDemandIndicator result = "J".ToSupplyDemandIndicator();
        }

    }
}
