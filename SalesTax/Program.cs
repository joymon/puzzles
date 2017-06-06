using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesTaxDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IBiller calc = new ConsoleBiller();

            IEnumerable<IItem> shoppingBasket1 = GetShoppingBasket1();
            calc.Generate(shoppingBasket1);
            Console.WriteLine(new string('-', 30));

            IEnumerable<IItem> shoppingBasket2 = GetShoppingBasket2();
            calc.Generate(shoppingBasket2);
            Console.WriteLine(new string('-', 30));

            IEnumerable<IItem> shoppingBasket3 = GetShoppingBasket3();
            calc.Generate(shoppingBasket3);
            Console.WriteLine(new string('-', 30));

            //IEnumerable<IItem> shoppingBasketTestMultiple = GetShoppingBasketMultiple();
            //calc.Generate(shoppingBasketTestMultiple);
            //Console.WriteLine(new string('-', 30));

            Console.ReadLine();
        }

        

        static IEnumerable<IItem> GetShoppingBasket1()
        {
            List < IItem > items = new List<IItem>();

            IItem book = new Book(12.49) { Quantity = 1 };
            items.Add(book);

            IItem musicCd = new MusicCD(14.99) { Quantity = 1 };
            musicCd = new SalesTaxable(musicCd);
            items.Add(musicCd);

            IItem chocolateBar = new ChocolateBar(.85) { Quantity = 1 };
            items.Add(chocolateBar);

            return items;
        }

        private static IEnumerable<IItem> GetShoppingBasket2()
        {
            List<IItem> items = new List<IItem>();

            IItem boxOfChocolates = new ChocolateBox(10) { Quantity = 1 };
            boxOfChocolates = new ImportTaxable(boxOfChocolates);
            items.Add(boxOfChocolates);

            IItem perfumeBottle = new PerfumeBottle(47.5) { Quantity = 1 };
            perfumeBottle = new SalesTaxable(perfumeBottle);
            perfumeBottle = new ImportTaxable(perfumeBottle);
            items.Add(perfumeBottle);

            return items;
        }

        private static IEnumerable<IItem> GetShoppingBasket3()
        {
//1 imported bottle of perfume at 27.99
//1 bottle of perfume at 18.99
//1 packet of headache pills at 9.75
//1 box of imported chocolates at 11.25

            List<IItem> items = new List<IItem>();

            IItem perfumeBottle = new PerfumeBottle(27.99) { Quantity = 1 };
            perfumeBottle = new SalesTaxable(perfumeBottle);
            perfumeBottle = new ImportTaxable(perfumeBottle);
            items.Add(perfumeBottle);

            items.Add(new SalesTaxable(new PerfumeBottle(18.99) { Quantity = 1 }));
            items.Add(new HeadachePills(9.75) { Quantity = 1 });
            items.Add(new ImportTaxable(new ChocolateBox(11.25) { Quantity = 1 }));
            return items;
        }
        private static IEnumerable<IItem> GetShoppingBasketMultiple()
        {
            List<IItem> items = new List<IItem>();

            IItem perfumeBottle = new PerfumeBottle(27.99) { Quantity = 2 };
            perfumeBottle = new SalesTaxable(perfumeBottle);
            perfumeBottle = new ImportTaxable(perfumeBottle);
            items.Add(perfumeBottle);

            items.Add(new SalesTaxable(new PerfumeBottle(18.99) { Quantity = 4 }));
            items.Add(new HeadachePills(9.75) { Quantity = 1 });
            items.Add(new ImportTaxable(new ChocolateBox(11.25) { Quantity = 1 }));
            return items;
        }
    }
}
