using System;
using System.Collections.Generic;
using System.Diagnostics;
using Sorting.Algorithms.Interfaces;

namespace Sorting.Environment
{
    public class TestExecution
    {
        public List<TestResult> AreAllTestSetsCorrect(List<TestSet<int>> testSets, ISort sortingAlgorythm)
        {
            if (testSets == null)
            {
                throw new ApplicationException($"Input parameter {nameof(testSets)} is NULL");
            }

            var results = new List<TestResult>();

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

                var currentTestResult = new TestResult(testSet.Input.Count);

                Stopwatch testSetStopwatch = new Stopwatch();
                testSetStopwatch.Start();
                
                var sortedCollection = sortingAlgorythm.Sort(testSet.Input);

                testSetStopwatch.Stop();
                currentTestResult.ExecutionTimeMs = testSetStopwatch.ElapsedMilliseconds;

                if (sortedCollection == null)
                {
                    throw new ApplicationException("Sorted output collection is NULL");
                }

                if (sortedCollection.Count != testSet.Output.Count)
                {
                    currentTestResult.IsOutputResultValid = false;
                    break;
                }

                for (int i = 0; i < testSet.Output.Count; i++)
                {
                    currentTestResult.IsOutputResultValid = currentTestResult.IsOutputResultValid && sortedCollection[i].Equals(testSet.Output[i]);
                }

                results.Add(currentTestResult);
            }

            return results;
        }
    }
}
