namespace Sorting.Environment
{
    public class TestResult
    {
        public TestResult(long inputLength, bool isOutputResultValid = true, long executionTimeMs = 0)
        {
            IsOutputResultValid = isOutputResultValid;
            ExecutionTimeMs = executionTimeMs;
            InputLength = inputLength;
        }

        public bool IsOutputResultValid { get; set; }
        public long ExecutionTimeMs { get; set; }
        public long InputLength { get; set; }
    }
}
