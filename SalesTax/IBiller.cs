using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesTaxDemo
{
    public interface IBiller
    {
        void Generate(IEnumerable <IItem> items);
    }
    
}
