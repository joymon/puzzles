using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingEngine.ConsoleRunner
{
    class ConsoleBasedInputReader:IInputReader
    {

        internal static IEnumerable<ProductSpec> GetInputProductSpecsFromConsole()
        {
            Console.WriteLine("Enter number of products:");
            int prodCount = Convert.ToInt32(Console.ReadLine());
            return Enumerable.Range(1, prodCount).Select(number =>
            {
                Console.WriteLine($"Enter product {number} in the format 'productcode supply demand' eg: flashdrive H L :");
                string[] stringElements = Console.ReadLine().Split(' ');
                return new ProductSpec(stringElements[0],
                    stringElements[1].ToSupplyDemandIndicator(),
                    stringElements[2].ToSupplyDemandIndicator()
                    );
            });
        }
        internal static IEnumerable<CompetitorProduct> GetInputCompetitorProducts()
        {
            Console.WriteLine("Enter number of competitor products");
            int cpCount = Convert.ToInt32(Console.ReadLine());
            return Enumerable.Range(1, cpCount).Select(number => {
                Console.WriteLine($"Enter competitor product {number} in the format 'productcode competitorcode competitorprice' eg: ssd X 10.0");
                string[] stringElements = Console.ReadLine().Split(' ');
                return new CompetitorProduct(stringElements[0],
                    stringElements[1],
                    Convert.ToDouble(stringElements[2])
                    );
            });
        }

        Tuple<IEnumerable<ProductSpec>, IEnumerable<CompetitorProduct>> IInputReader.Get()
        {
            return new Tuple<IEnumerable<ProductSpec>, IEnumerable<CompetitorProduct>>(GetInputProductSpecsFromConsole().ToList(), 
                GetInputCompetitorProducts().ToList());
        }
    }
}
