using System.Collections.Generic;

namespace Sorting.Environment
{
    public class TestSet<T>
    {
        // TODO: replace List with arrays to avoid unnecessary boxing/unboxing
        public List<T> Input { get; set; }
        public List<T> Output { get; set; }
    }
}
