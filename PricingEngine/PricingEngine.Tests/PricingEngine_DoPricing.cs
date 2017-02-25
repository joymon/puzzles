using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace PricingEngine.Tests
{
    [TestClass]
    public class PricingEngine_DoPricing
    {
        [TestMethod]
        [ExcludeFromCodeCoverage]
        public void WhenInputsAreNormal_RunNormally()
        {
            IList<ProductSpec> specs = new List<ProductSpec>()
            {
                new ProductSpec("mp3player", SupplyDemandIndicator.High, SupplyDemandIndicator.High),
                new ProductSpec("ssd",SupplyDemandIndicator.Low,SupplyDemandIndicator.Low)
            };
            IList<CompetitorProduct> compList = new List<CompetitorProduct>()
            {
                new CompetitorProduct("ssd","W",11.0),
                new CompetitorProduct("ssd","X",12.0),
                new CompetitorProduct("mp3player","X",60.0),
                new CompetitorProduct("mp3player","Y",20.0),
                new CompetitorProduct("mp3player","Z",50.0),
                new CompetitorProduct("ssd","V",10.0),
                new CompetitorProduct("ssd","Y",11.0),
                new CompetitorProduct("ssd","Z",12.0),
            };

            IPricingEngine engine = new PricingEngine();
            IList<Product> prods = engine.DoPricing(specs, compList).ToList();
            Assert.AreEqual(12.1,
                prods.Where(prod => prod.Spec.ProductCode == "ssd").FirstOrDefault().Price,
                "Not equal");
        }
        [TestMethod]
        public void WhenCompetitorPricingAreInBoundaries_UseNegative1AsPriceAsIndication()
        {
            IList<ProductSpec> specs = new List<ProductSpec>()
            {
                new ProductSpec("RAM", SupplyDemandIndicator.High, SupplyDemandIndicator.High),
                new ProductSpec("HDD",SupplyDemandIndicator.Low,SupplyDemandIndicator.Low)
            };
            IList<CompetitorProduct> compList = new List<CompetitorProduct>()
            {
                new CompetitorProduct("RAM","W",1.0),
                new CompetitorProduct("HDD","X",18.0),
                new CompetitorProduct("RAM","Y",100.0),
            };

            IPricingEngine engine = new PricingEngine();
            IList<Product> prods = engine.DoPricing(specs, compList).ToList();
            Assert.AreEqual(-1,
                prods.Where(prod => prod.Spec.ProductCode == "RAM").FirstOrDefault().Price,
                "Not equal");
        }
    }
}
