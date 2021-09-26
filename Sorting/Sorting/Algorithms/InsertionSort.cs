using Sorting.Algorithms.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Sorting.Algorithms
{
    public class InsertionSort : ISort
    {
        public List<int> Sort(List<int> input)
        {
            if (input.Count == 1)
            {
                return input;
            }

            for (int mainIndex = 0; mainIndex < input.Count - 1; mainIndex++)
            {
                for (int innerIndex = mainIndex + 1; innerIndex > 0; innerIndex--)
                {
                    if (input[innerIndex - 1] > input[innerIndex])
                    {
                        int temp = input[innerIndex - 1];
                        input[innerIndex - 1] = input[innerIndex];
                        input[innerIndex] = temp;
                    }
                }
            }

            return input.ToList();
        }
    }
}
