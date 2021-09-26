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
        private const string InsertionSortKey = "1";
        private const string AllSortKey = "A";
        private const string ExitKey = "X";

        static void Main(string[] args)
        {
            Console.WriteLine($"Please select the sorting algorithm.");
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
                    case (InsertionSortKey):
                    {
                        var testResults = (new TestExecution()).AreAllTestSetsCorrect(testCases, new InsertionSort());

                        if (!testResults.All(x => x.IsOutputResultValid == true))
                        {
                            PrintNotificationAboutInvalidSortResult();
                            shouldBreakBeDone = true;
                        }
                        else
                        {
                            PrintExecutionResults(testResults, nameof(InsertionSort));
                        }
                        break;
                    }
                }
                inputLine = Console.ReadLine()?.ToLowerInvariant();
            }
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
