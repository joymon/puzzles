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
    public class HighestProductOfTripletInAnArrayFinder
    {
        public int[] Find(int[] input)
        {
            if (input.Length < 3) throw new ArgumentOutOfRangeException($"There are only {input.Length} elements. Need minimum 3");
            int lowest = input[0];
            int secondLowest = input[0];
            int highest = input[0];
            int secondHighest = input[0];
            int thirdHighest = input[0];

            foreach (int i in input)
            {
                if (i < lowest)
                {
                    secondLowest = lowest;
                    lowest = i;
                }
                else if (i < secondLowest)
                {
                    secondLowest = i;
                }
                if (i > highest)
                {
                    thirdHighest = secondHighest;
                    secondHighest = highest;
                    highest = i;
                }
                else if (i > secondHighest)
                {
                    thirdHighest = secondHighest;
                    secondHighest = i;
                }
                else if (i > thirdHighest)
                {
                    thirdHighest = i;
                }
                //Handling initial condition hacks. This may not work if duplicate value present.
                // Try with keeping index instead of values to handle unfilled positions.
                if(thirdHighest == secondHighest && i<thirdHighest)
                {
                    thirdHighest = i;
                }
                if (highest == secondHighest && i < secondHighest)
                {
                    secondHighest = i;
                    thirdHighest = i;
                }
            }
            if (lowest * secondLowest * highest > highest * secondHighest * thirdHighest)
            {
                return new int[3] { lowest, secondLowest, highest };
            }
            else
            {
                return new int[3] { thirdHighest, secondHighest, highest };
            }
        }
    }
}
