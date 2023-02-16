using System.Numerics;
using Utte.NumberSet;

namespace NumberSet
{

    /// <summary>
    /// Interface for constructing elements of a set which is a set in itself. The interface is used as part of INumberSet
    /// T has to implement IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>, IComparisonOperators<T, T, bool>
    /// An open INumberSetElement have IncludeLowerBound = false and IncludeUpperBound = false
    /// An open INumberSetElement have IncludeLowerBound = true and IncludeUpperBound = true
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface INumberSetElement<T> : IBoundedSet<T> where T : IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>, IComparisonOperators<T, T, bool>
    {
        /// <summary>
        /// Indicates if the lower bound is part of the INumberSetElement
        /// </summary>
        bool IncludeLowerBound { get; }

        /// <summary>
        /// Indicates if the upper bound is part of the INumberSetElement
        /// </summary>
        bool IncludeUpperBound { get; }
    }
}
