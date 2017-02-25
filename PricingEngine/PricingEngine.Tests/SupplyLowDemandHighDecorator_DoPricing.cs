using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Moq;

namespace PricingEngine.Tests
{
    /// <summary>
    /// Summary description for PromotionDecorator
    /// </summary>
    [TestClass]
    
    public class SupplyLowDemandHighDecorator_DoPricing
    {

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void WhenChosenProductHasSupplyLowAndDemandHigh_IncreasePriceBy5Percentage()
        {
            ProductSpec specs = new ProductSpec("mp3player", SupplyDemandIndicator.Low, SupplyDemandIndicator.High);
            IList<CompetitorProduct> compList = new List<CompetitorProduct>()
            {
                new CompetitorProduct("mp3player","X",16.0),
                new CompetitorProduct("mp3player","Y",10.0),
                new CompetitorProduct("mp3player","Z",12.0),
            };
            Mock<IPricer> mockPricer = new Mock<IPricer>();
            mockPricer.Setup(m => m.DoPrice(specs, It.IsAny<IEnumerable<CompetitorProduct>>())).Returns(new Product(specs, 10));


            IPricer pricer = new SupplyLowDemandHighDecorator(mockPricer.Object);

            Product product = pricer.DoPrice(specs, compList);
                
            Assert.AreEqual(10.5, product.Price, "The SupplyLowDemandHighDecorator didn't worked.Actual value {0}",product.Price);
        }
        [TestMethod]
        public void WhenChosenProductHasNoSupplyLowAndDemandHigh_DontChangePrice()
        {
            ProductSpec specs = new ProductSpec("mp3player", SupplyDemandIndicator.High, SupplyDemandIndicator.High);
            IList<CompetitorProduct> compList = new List<CompetitorProduct>()
            {
                new CompetitorProduct("mp3player","X",16.0),
                new CompetitorProduct("mp3player","Y",10.0),
                new CompetitorProduct("mp3player","Z",12.0),
            };
            Mock<IPricer> mockPricer = new Mock<IPricer>();
            mockPricer.Setup(m => m.DoPrice(specs, It.IsAny<IEnumerable<CompetitorProduct>>())).Returns(new Product(specs, 10));


            IPricer pricer = new SupplyLowDemandHighDecorator(mockPricer.Object);

            Product product = pricer.DoPrice(specs, compList);

            Assert.AreEqual(10, product.Price, "The SupplyLowDemandHighDecorator didn't worked.Actual value {0}", product.Price);
        }
    }
}
