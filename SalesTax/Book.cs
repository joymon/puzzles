using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesTaxDemo
{
    public class Book:Item
    {
        public override string Description
        {
            get
            {
                if (this.Quantity > 1) return "books";
                else return "book";
            }
        }
        public Book(double price):base(price){}
    }
}
