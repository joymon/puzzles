using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingEngine
{
    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (action == null) throw new ArgumentNullException(nameof(action));

            foreach (T item in source)
            {
                action(item);
            }
        }
        /// <summary>
        /// Extension method converts string to SupplyDemandIndicator
        /// </summary>
        /// <exception cref="InvalidCastException">If the input is not 'H' or 'L'</exception>
        /// <param name="indicator"></param>
        /// <returns></returns>
        public static SupplyDemandIndicator ToSupplyDemandIndicator(this string indicator)
        {
            if (indicator.Equals("H", StringComparison.OrdinalIgnoreCase))
            {
                return SupplyDemandIndicator.High;
            }
            else if(indicator.Equals("L",StringComparison.OrdinalIgnoreCase))
            {
                return SupplyDemandIndicator.Low;
            }
            else
            {
                throw new InvalidCastException("Not able to convert input string to SupplyDemandIndicator");
            }
        }
    }
}
