using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesTaxDemo
{
    public class ChocolateBar : SalesTaxDemo.Item
    {
        public override string Description
        {
            get
            {
                if (this.Quantity > 1) return "chocolate bars";
                else return "chocolate bar";
            }
        }
        public ChocolateBar(double price) : base(price) { }
        
    }
}
