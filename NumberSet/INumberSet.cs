using System.Numerics;
using Utte.NumberSet;

namespace NumberSet
{

    /// <summary>
    /// Interface for constructing sets of numberlike objects of type T. It is built of a collection of INumberSetElement and is immutable.
    /// Every INumberSetElement in the collection should be disjunct and sorted in order.
    /// T has to implement IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>, IComparisonOperators<T, T, bool>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface INumberSet<T> : IBoundedSet<T>, IReadOnlyList<INumberSetElement<T>> where T : IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>, IComparisonOperators<T, T, bool>
    {
    }
}
