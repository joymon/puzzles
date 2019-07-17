using System;

namespace HighestProductOfTripletInArray
{
    public class HighestProductOfTripletInAnArrayFinder
    {
        public int[] Find(int[] input)
        {
            ThrowExceptionIfInputsIsInValid(input);
            //return FindByFindingNumbers(input);
            return FindByFindingIndexes(input);
        }
        private static int[] FindByFindingIndexes(int[] input)
        {
            int lowestIndex = -1;
            int secondLowestIndex = -1;
            int highestIndex = -1;
            int secondHighestIndex = -1;
            int thirdHighestIndex = -1;
            for (int currentIndex = 0; currentIndex < input.Length; currentIndex++)
            {
                //Adjust lowest indexes
                if (lowestIndex == -1) lowestIndex = currentIndex;
                else if (input[currentIndex] <= input[lowestIndex])
                {
                    secondLowestIndex = lowestIndex;
                    lowestIndex = currentIndex;
                }
                else if (secondLowestIndex==-1 || input[currentIndex] < input[secondLowestIndex])
                {
                    secondLowestIndex = currentIndex;
                }
                
                //Adjust higeste indexes
                if(highestIndex==-1 || input[currentIndex] > input[highestIndex])
                {
                    thirdHighestIndex = secondHighestIndex;
                    secondHighestIndex = highestIndex;
                    highestIndex = currentIndex;
                }
                else if (secondHighestIndex == -1 || input[currentIndex] >= input[secondHighestIndex])
                {
                    thirdHighestIndex = secondHighestIndex;
                    secondHighestIndex = currentIndex;
                    }
                else if(thirdHighestIndex ==-1 || input[currentIndex] >= input[thirdHighestIndex])
                {
                    thirdHighestIndex = currentIndex;
                }

            }
            if (input[lowestIndex] * input[secondLowestIndex] * input[highestIndex] > input[highestIndex] * input[secondHighestIndex] * input[thirdHighestIndex])
            {
                return new int[3] { input[lowestIndex], input[secondLowestIndex], input[highestIndex] };
            }
            else
            {
                return new int[3] { input[thirdHighestIndex], input[secondHighestIndex], input[highestIndex] };
            }
        }

        private static int[] FindByFindingNumbers(int[] input)
        {
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
                if (thirdHighest == secondHighest && i < thirdHighest)
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

        private static void ThrowExceptionIfInputsIsInValid(int[] input)
        {
            if (input.Length < 3) throw new ArgumentOutOfRangeException($"There are only {input.Length} elements. Need minimum 3");
        }
    }
}
