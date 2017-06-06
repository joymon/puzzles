using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesTaxDemo
{
    public class MusicCD : Item
    {
        public override string Description
        {
            get
            {
                if (this.Quantity > 1) return "music CDs";
                else return "music CD";
            }
        }
        public MusicCD(double price):base(price){}
    }
}
