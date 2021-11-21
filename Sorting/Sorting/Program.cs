using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Sorting.Algorithms;
using Sorting.Environment;

namespace Sorting
{
    class Program
    {
        private const string BubbleSortKey = "1";
        private const string InsertionSortKey = "2";
        private const string AllSortKey = "A";
        private const string ExitKey = "X";

        static void Main(string[] args)
        {
            Console.WriteLine($"Please select the sorting algorithm.");
            Console.WriteLine($"\t {BubbleSortKey} - bubble sorting");
            Console.WriteLine($"\t {InsertionSortKey} - insertion sorting");
            Console.WriteLine($"\t {AllSortKey} - All algorithm testing");
            Console.WriteLine($"Or press {ExitKey} to exit");
            var inputLine = Console.ReadLine()?.ToLowerInvariant();
            bool shouldBreakBeDone = false;

            while (inputLine != ExitKey.ToLowerInvariant() || shouldBreakBeDone)
            {
                Stopwatch testCasesStopwatch = new Stopwatch();
                
                testCasesStopwatch.Start();
                
                var testCases = TestCase.GetStandardTestSets();
                testCasesStopwatch.Stop();
                Console.WriteLine($"It took {testCasesStopwatch.ElapsedMilliseconds} milliseconds to generate test cases");

                switch (inputLine)
                {
                    case (BubbleSortKey):
                    {
                        var testResults = (new TestExecution()).AreAllTestSetsCorrect(testCases, new BubbleSort());
                        shouldBreakBeDone = PrintTestResultForSortingReturnShouldBreakOnDone(testResults, nameof(BubbleSort));

                        break;
                    }

                    case (InsertionSortKey):
                    {
                        var testResults = (new TestExecution()).AreAllTestSetsCorrect(testCases, new InsertionSort());
                        shouldBreakBeDone = PrintTestResultForSortingReturnShouldBreakOnDone(testResults, nameof(InsertionSort));
                        break;
                    }
                }
                inputLine = Console.ReadLine()?.ToLowerInvariant();
            }
        }

        private static bool PrintTestResultForSortingReturnShouldBreakOnDone(List<TestResult> testResults, string soringName)
        {
            bool shouldBreakBeDone = false;
            if (!testResults.All(x => x.IsOutputResultValid == true))
            {
                PrintNotificationAboutInvalidSortResult();
                shouldBreakBeDone = true;
            }
            else
            {
                PrintExecutionResults(testResults, soringName);
            }

            return shouldBreakBeDone;
        }

        private static void PrintNotificationAboutInvalidSortResult()
        {
            Console.WriteLine("The result of a sorting is invalid");
        }

        private static void PrintExecutionResults(List<TestResult> testResult, string sotringName)
        {
            Console.WriteLine($"Execution of a {sotringName} took the following time");
            Console.WriteLine($"Number of input elements : number of milliseconds");
            foreach (var result in testResult)
            {
                Console.WriteLine($"{result.InputLength}\t:\t{result.ExecutionTimeMs}");
            }
        }
    }
}
