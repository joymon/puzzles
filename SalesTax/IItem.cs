using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesTaxDemo
{
    public interface IItem
    {

        string Name
        {
            get;
            set;
        }

        double Price
        {
            get;
        }

        double TaxPercentage
        {
            get;
        }
        double TaxAmount { get; }
        int Quantity { get; set; }
        double CalculateTaxAmount();
        double CalculateCost();
        string Description { get; }
    }
}
