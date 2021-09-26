using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting.Environment
{
    public class TestCase
    {
        private static int[] InputIntLengthes = new[] {10, }; // 100, 1000, 1_000_000, 10_000_000};
        public static List<TestSet<int>> GetStandardTestSets()
        {
            var result = new List<TestSet<int>>();
            //{
            //    new TestSet<int>() // empty case
            //    {
            //        Input = new List<int>() { },
            //        Output = new List<int>() { }
            //    },
            //    new TestSet<int>() 
            //    {
            //        Input = new List<int>() { 0 },
            //        Output = new List<int>() { 0 }
            //    },
            //    new TestSet<int>()
            //    {
            //        Input = new List<int>() { 1, 0 },
            //        Output = new List<int>() { 0, 1 }
            //    },
            //    new TestSet<int>()
            //    {
            //        Input = new List<int>() { -1, 1, 0 },
            //        Output = new List<int>() { 1, 0, 1 }
            //    },
            //};

            result.AddRange(GetStandardRandomTestSetOfLength());

            return result;
        }

        public static List<TestSet<int>> GetStandardRandomTestSetOfLength()
        {
            var result = new List<TestSet<int>>();
            foreach (var count in InputIntLengthes.ToList())
            {
                result.Add(GetRandomTestSetOfLength(count));
            }

            return result;
        }

        public static TestSet<int> GetRandomTestSetOfLength(int length)
        {
            var inputList = new List<int>();
            var random = new Random();
            var result = new List<TestSet<int>>();
            for (int i = 0; i < length; i++)
            {
                inputList.Add(random.Next(int.MinValue, int.MaxValue));
            }

            return new TestSet<int>()
            {
                Input = inputList,
                Output = inputList.OrderBy(x => x).ToList()
            };
        }
    }
}
