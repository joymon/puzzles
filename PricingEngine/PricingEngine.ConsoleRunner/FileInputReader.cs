using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PricingEngine.ConsoleRunner
{
    internal class FileInputReader : IInputReader
    {
        private readonly string path;
        public FileInputReader(string filePath)
        {
            this.path = filePath;
        }

        public Tuple<IEnumerable<ProductSpec>, IEnumerable<CompetitorProduct>> Get()
        {
            using (var sr = new StreamReader(File.OpenRead(path)))
            {
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                IEnumerable<ProductSpec> specs = GetInputProductSpecs(sr).ToList();
                IEnumerable<CompetitorProduct> compProducts = GetInputCompetitorProducts(sr).ToList();
                return new Tuple<IEnumerable<ProductSpec>, IEnumerable<CompetitorProduct>>(specs, compProducts);
            }
        }

        private IEnumerable<CompetitorProduct> GetInputCompetitorProducts(StreamReader sr)
        {
            return Enumerable.Range(1, Convert.ToInt32(sr.ReadLine())).Select(number =>
            {
                string[] prdLineElements = sr.ReadLine().Split(' ');
                return new CompetitorProduct(prdLineElements[0],
                    prdLineElements[1],
                    Convert.ToDouble(prdLineElements[2]));
            });
        }

        private IEnumerable<ProductSpec> GetInputProductSpecs(StreamReader dr)
        {
            return Enumerable.Range(1, Convert.ToInt32(dr.ReadLine())).Select(number =>
            {
                string []prdLineElements = dr.ReadLine().Split(' ');
                var supplyDemandIndicator = prdLineElements[1].ToSupplyDemandIndicator();
                var supplyDemandIndicator1 = prdLineElements[2].ToSupplyDemandIndicator();
                return new ProductSpec(prdLineElements[0],
                    supplyDemandIndicator,
                    supplyDemandIndicator1);
            });
        }

    }
}