using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PricingEngine;
using System.IO;

namespace PricingEngine.ConsoleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            new PricingRunner().Run(args);
            Console.WriteLine("Completed. Any key to exit");
            Console.ReadLine();
        }

       
    }
}
