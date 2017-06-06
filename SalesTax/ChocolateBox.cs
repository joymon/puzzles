using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesTaxDemo
{
    public class ChocolateBox : SalesTaxDemo.Item
    {
        public override string Description
        {
            get
            {
                if (this.Quantity > 1) return "boxes of chocolates";
                else return "box of chocolates";
            }
        }
        public ChocolateBox(double price) : base(price) { }
        
    }
}
