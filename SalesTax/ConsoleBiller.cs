using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace SalesTaxDemo
{
    public class ConsoleBiller : IBiller
    {
        public void Generate(IEnumerable<IItem> items)
        {
            double salesTaxes = 0, totalCost = 0;
            foreach (IItem item in items)
            {
                double itemCost = item.CalculateCost();
                totalCost += itemCost;
                salesTaxes += item.TaxAmount; //Can call TaxAmount as the CalculateTax already sets this.
                string itemLine = string.Format(CultureInfo.CurrentCulture,"{0} {1}: {2:0.00}", item.Quantity, item.Description, itemCost);
                Console.WriteLine(itemLine);
            }
            Console.WriteLine("Sales Taxes :{0:0.00}", salesTaxes);
            Console.WriteLine("Total: {0:0.00}", totalCost);
        }
    }
}
