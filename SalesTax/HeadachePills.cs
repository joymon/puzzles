using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesTaxDemo
{
    public class HeadachePills:Item
    {
        public override string Description
        {
            get
            {
                if (this.Quantity > 1) return "packet of headache pills";
                else return "packet of headache pills";
            }
        }
        public HeadachePills(double price):base(price){}

    }
}
