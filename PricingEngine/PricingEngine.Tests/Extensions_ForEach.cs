using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PricingEngine;
using System.Collections.Generic;
using System.Linq;

namespace PricingEngine.Tests
{
    [TestClass]
    public class Extensions_ForEach
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenActionIsNull_ThrowException()
        {
            IEnumerable<int> inp = Enumerable.Range(1, 2);
            inp.ForEach(null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenCollectionIsNull_ThrowException()
        {
            IEnumerable<int> inp = null;
            inp.ForEach((a)=>a++);
        }
        [TestMethod]
        public void WhenInNormalCondition_DoActionOnAllElements()
        {
            int actual = 0;
            IEnumerable<int> inp = Enumerable.Range(1, 2);
            inp.ForEach((a) => actual +=a);
            Assert.AreEqual(3, actual,$"ForEach is not working.{actual}");
        }
    }
}
