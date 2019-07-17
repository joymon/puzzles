using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
namespace HighestProductOfTripletInArray.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private HighestProductOfTripletInAnArrayFinder finder = new HighestProductOfTripletInAnArrayFinder();
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenThereAreLessThan3ElementsInArray_ThrowArgumentOutOfRangeException()
        {
            var finder = new HighestProductOfTripletInAnArrayFinder();
            int[] result = finder.Find(new int[] { 1, 2 });
        }

        [TestMethod]
        public void WhenThereAre3ElementsInArray_ReturnTheSameElements()
        {
            var finder = new HighestProductOfTripletInAnArrayFinder();
            int[] result = finder.Find(new int[] { 1, 2, 3 });
            Assert.AreEqual(true, result[0] == 1 && result[1] == 2 && result[2] == 3);
        }

        [TestMethod]
        public void WhenThereAre3_2_1ElementsInArray_ReturnTheSameElements()
        {
            var finder = new HighestProductOfTripletInAnArrayFinder();
            int[] result = finder.Find(new int[] { 3, 2, 1 });
            Assert.AreEqual(6, result.Aggregate((x, y) => x * y));
        }
        [TestMethod]
        public void WhenThereAre_10_3_5_6_20_ElementsInArray_ReturnTheSameElements()
        {
            int[] arr = { 10, 3, 5, 6, 20 };
            int[] result = this.finder.Find(arr);
            Assert.AreEqual(1200, result.Aggregate((x, y) => x * y));
        }
        [TestMethod]
        public void WhenThereAreMinus_Neg10_Neg3_Neg5_Neg6_Neg20_ElementsInArray_ReturnTheSameElements()
        {
            int[] arr = { -10, -3, -5, -6, -20 };
            int[] result = this.finder.Find(arr);
            Assert.AreEqual(-90, result.Aggregate((x, y) => x * y));
        }
        [TestMethod]
        public void WhenThereAreMinus_Neg10_Neg3_Neg5_0_Neg20_ElementsInArray_Return_Neg10_Neg5_Neg20()
        {
            int[] arr = { -10, -3, -5, 0, -20 };
            int[] result = this.finder.Find(arr);
            Assert.AreEqual(-10*-5*-20, result.Aggregate((x, y) => x * y));
        }
        [TestMethod]
        public void WhenThereAre_1_4_3_6_7_0_ElementsInArray_ReturnTheSameElements()
        {
            int[] arr = { 1, -4, 3, -6, 7, 0 };
            int[] result = this.finder.Find(arr);
            Assert.AreEqual(168, result.Aggregate((x, y) => x * y));
        }
        [TestMethod]
        public void WhenThereAre_Neg5_Neg7_4_2_1_9_ElementsInArray_Return_Neg5_Neg7_9()
        {
            int[] arr = { -5, -7, 4, 2, 1, 9 };  // Max Product of 3 numbers = -5 * -7 * 9
            int[] result = this.finder.Find(arr);
            Assert.AreEqual(-5 * -7 * 9, result.Aggregate((x, y) => x * y));
        }
        [TestMethod]
        public void WhenThereAre_4_5_Neg19_3_ElementsInArray_Return_4_5_3()
        {
            int[] arr = { 4, 5, -19, 3 };       // Max Product of 3 numbers = 4 * 5 * 3
            int[] result = this.finder.Find(arr);
            Assert.AreEqual(4 * 5 * 3, result.Aggregate((x, y) => x * y));
        }
        [TestMethod]
        public void WhenThereAre_4_4_Neg19_3_ElementsInArray_Return_4_4_3()
        {
            int[] arr = { 4, 4, -19, 3 };       // Max Product of 3 numbers = 4 * 4 * 3
            int[] result = this.finder.Find(arr);
            Assert.AreEqual(4 * 4 * 3, result.Aggregate((x, y) => x * y));
        }
    }
}
