using System.Collections.Generic;
using Sorting.Algorithms.Interfaces;

namespace Sorting.Algorithms
{
    public class InsertionSort : ISort
    {
        public List<int> Sort(List<int> input)
        {
            int inputLength = input.Count;

            for (int i = 1; i < inputLength; ++i)
            {
                int key = input[i];
                int j = i - 1;

                while (j >= 0 && input[j] > key)
                {
                    input[j + 1] = input[j];
                    j = j - 1;
                }

                input[j + 1] = key;
            }

            return input;
        }
    }
}
