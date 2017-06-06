using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesTaxDemo
{
    abstract public class Item : IItem
    {
        public string Name { get; set; }
        public virtual double Price { get; private set; }
        public virtual double TaxPercentage { get { return 0; } }
        public virtual double TaxAmount { get; private set; }
        public abstract string Description { get; }
        public virtual int Quantity { get; set; }

        protected Item(double price)
        {
            this.Price = price;
        }

        public virtual double CalculateCost()
        {
            this.TaxAmount = CalculateTaxAmount();
            double costWithTax = Price * Quantity + this.TaxAmount;
            return costWithTax;
        }

        public double CalculateTaxAmount()
        {
            double actualTaxAmount = TaxPercentage * Price / 100;
            double actualTaxAmountOfAllItems = actualTaxAmount * Quantity;
            return RoundUpToPoint05(actualTaxAmountOfAllItems);
        }

        private static double RoundUpToPoint05(double taxAmount)
        {
            //According to the description, it round to nearest .05 .But the sample outputs shows ceiling.
            return Math.Ceiling(20 * taxAmount) / 20.0;
        }
    }
}