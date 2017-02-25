using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingEngine.ConsoleRunner
{
    class PricingRunner
    {
        internal void Run(string[] args)
        {

            IInputReader reader = GetInputReaderBasedOnCommandLineArgs(args);
            Tuple<IEnumerable<ProductSpec>, IEnumerable<CompetitorProduct>> input;
            try
            {
                input = reader.Get();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The inputs are no in the right format. Details {ex}");


                throw;
            }
            var resultProducts = PricingEngineFactory.Get().DoPricing(input.Item1, input.Item2);
            resultProducts.ForEach(result => Console.WriteLine(result.Price));
        }

        private static IInputReader GetInputReaderBasedOnCommandLineArgs(string[] args)
        {
            IInputReader reader = null;
            if (args.Length == 1)
            {
                if (File.Exists(args[0]))
                {
                    reader = new FileInputReader(args[0]);
                }
                else
                {
                    Console.WriteLine("Wrong arguments.");
                }
            }
            else
            {
                reader = new ConsoleBasedInputReader();
            }
            return reader;
        }
    }
}
