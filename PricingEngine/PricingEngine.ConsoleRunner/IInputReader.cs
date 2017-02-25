using System;
using System.Collections.Generic;

namespace PricingEngine.ConsoleRunner
{
    internal interface IInputReader
    {
        Tuple<IEnumerable<ProductSpec>, IEnumerable<CompetitorProduct>> Get();
    }
}