using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesTaxDemo
{
    public class SalesTaxable : TaxableItem
    {
        public SalesTaxable(IItem item):base(item){}
        public override double TaxPercentage
        {
            get
            {
                return base.TaxPercentage + 10;
            }
        }
    }
}
