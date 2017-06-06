using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesTaxDemo
{
    
    public class ImportTaxable : TaxableItem
    {
        public override double TaxPercentage
        {
            get
            {
                return 5 + base.TaxPercentage;
            }
        }
        public override string Description
        {
            get
            {
                return "imported "+ base.Description;
            }
        }
        public ImportTaxable(IItem item):base(item){}
    }
}
