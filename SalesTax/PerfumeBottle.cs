using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesTaxDemo
{
    public class PerfumeBottle : Item
    {
        public override string Description
        {
            get
            {
                if (this.Quantity > 1)
                    return "bottles of perfume";
                else
                    return "bottle of perfume";
            }
        }
        public PerfumeBottle(double price):base(price) { }
    }
}
