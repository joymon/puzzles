using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace PricingEngine.Tests
{
    /// <summary>
    /// Summary description for PromotionDecorator
    /// </summary>
    [TestClass]
    public class BoundaryValueDecorator_DoPricing

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
        public void WhenInputContainsPriceWhichIsHigherThanAveragePlus50PercentageOfAveragePrice_DoNotConsider()
        {

            ProductSpec specs = new ProductSpec("mp3player", SupplyDemandIndicator.Low, SupplyDemandIndicator.High);
            IList<CompetitorProduct> compList = new List<CompetitorProduct>()
            {
                                  new CompetitorProduct("mp3player","U",10.0),
                new CompetitorProduct("mp3player","V",10.0),
                new CompetitorProduct("mp3player","W",15.0),
                new CompetitorProduct("mp3player","X",55.0),
                new CompetitorProduct("mp3player","Y",15.0),
                new CompetitorProduct("mp3player","Z",15.0),
              
            };
            Mock<IPricer> mockPricer = new Mock<IPricer>();
            mockPricer.Setup(m => m.DoPrice(specs, It.IsAny<IEnumerable<CompetitorProduct>>())).Returns(new Product(specs, 10));

            IPricer pricer = new BoundaryValueDecorator(mockPricer.Object);
            Product product = pricer.DoPrice(specs, compList);

            mockPricer.Verify(m => m.DoPrice(specs,
                                             It.Is<IEnumerable<CompetitorProduct>>(s => s.FirstOrDefault(cp=>cp.CompetitorCode=="X") == null))
                            );
        }
        [TestMethod]
        public void WhenInputContainsPriceWhichIsLowerThanAverageMinus50PercentageOfAveragePrice_DoNotConsider()
        {

            ProductSpec specs = new ProductSpec("mp3player", SupplyDemandIndicator.Low, SupplyDemandIndicator.High);
            IList<CompetitorProduct> compList = new List<CompetitorProduct>()
            {
                new CompetitorProduct("mp3player","W",19.0),
                new CompetitorProduct("mp3player","X",1.0),
                new CompetitorProduct("mp3player","Y",15.0),
                new CompetitorProduct("mp3player","Z",15.0),
            };
            Mock<IPricer> mockPricer = new Mock<IPricer>();
            mockPricer.Setup(m => m.DoPrice(specs, It.IsAny<IEnumerable<CompetitorProduct>>())).Returns(new Product(specs, 10));

            IPricer pricer = new BoundaryValueDecorator(mockPricer.Object);
            Product product = pricer.DoPrice(specs, compList);

            mockPricer.Verify(m => m.DoPrice(specs,
                                             It.Is<IEnumerable<CompetitorProduct>>(s => s.FirstOrDefault(cp => cp.CompetitorCode == "X") == null))
                            );
        }
    }
}
