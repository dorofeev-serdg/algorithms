using System;
using System.Diagnostics;
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

            while (inputLine != ExitKey.ToLowerInvariant())
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
                        (new TestExecution()).AreAllTestSetsCorrect(testCases, new InsertionSort());
                        break;
                    }
                }
                inputLine = Console.ReadLine()?.ToLowerInvariant();
            }
        }
    }
}
