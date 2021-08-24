using System.Collections.Generic;

namespace Sorting.Algorithms.Interfaces
{
    public interface ISort
    {
        List<T> Sort<T>(List<T> input);
    }
}
