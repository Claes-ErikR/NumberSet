using System.Numerics;
using Utte.NumberSet;

namespace NumberSet
{
    public interface INumberSetElement<T> : IBoundedSet<T> where T : IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>, IComparisonOperators<T, T, bool>
    {
        bool IncludeLowerBound { get; }
        bool IncludeUpperBound { get; }
    }
}
