using System;

namespace HighestProductOfTripletInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 10, 3, 5, 6, 20 };
            Console.WriteLine($"Result is {new HighestProductOfTripletInAnArrayFinder().Find(arr)}");
            Console.ReadLine();
        }
    }
}
