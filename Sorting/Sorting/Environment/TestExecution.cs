using System;
using System.Collections.Generic;
using Sorting.Algorithms.Interfaces;

namespace Sorting.Environment
{
    public class TestExecution
    {
        public bool AreAllTestSetsCorrect(List<TestSet<int>> testSets, ISort sortingAlgorythm)
        {
            bool result = true;
            if (testSets == null)
            {
                throw new ApplicationException($"Input parameter {nameof(testSets)} is NULL");
            }

            if (sortingAlgorythm == null)
            {
                throw new ApplicationException($"Input parameter {nameof(sortingAlgorythm)} is NULL");
            }

            foreach (var testSet in testSets)  
            {
                if (testSet == null)
                {
                    throw new ApplicationException("TestSet is NULL");
                }

                if (testSet.Input == null)
                {
                    throw new ApplicationException("TestSet->Input is NULL");
                }

                if (testSet.Output == null)
                {
                    throw new ApplicationException("TestSet->Output is NULL");
                }

                var sortedCollection = sortingAlgorythm.Sort(testSet.Input);

                if (sortedCollection == null)
                {
                    throw new ApplicationException("Sorted output collection is NULL");
                }

                if (sortedCollection.Count != testSet.Output.Count)
                {
                    result = false;
                    break;
                }

                for (int i = 0; i < testSet.Output.Count; i++)
                {
                    result = result && sortedCollection[i].Equals(testSet.Output[i]);
                }

            }

            return result;
        }
    }
}
