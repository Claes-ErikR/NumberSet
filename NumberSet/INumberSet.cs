using System.Numerics;
using Utte.NumberSet;

namespace NumberSet
{
    public interface INumberSet<T> : IBoundedSet<T>, IReadOnlyList<INumberSetElement<T>> where T : IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>, IComparisonOperators<T, T, bool>
    {

    }
}
