using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesTaxDemo
{
    public abstract class TaxableItem : Item
    {
        IItem _item;
        public override int Quantity
        {
            get
            {
                return _item.Quantity;
            }
            set
            {
                _item.Quantity = value;
            }
        }
        public override double TaxPercentage
        {
            get
            {
                return _item.TaxPercentage;
            }
        }
        protected TaxableItem(IItem item):base(item.Price)
        {
            _item = item;
        }
        public override string Description
        {
            get
            {
                return  _item.Description;
            }
        }
    }
}
