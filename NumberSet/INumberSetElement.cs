using System.Numerics;

namespace Utte.NumberSet;

/// <summary>
/// Interface for constructing elements of a set which is a set in itself. The interface is used as part of INumberSet
/// T has to implement IAdditionOperators&lt;T, T, T&gt;, ISubtractionOperators&lt;T, T, T&gt;, IComparisonOperators&lt;T, T, bool&gt;
/// An open INumberSetElement have IncludeLowerBound = false and IncludeUpperBound = false
/// A closed INumberSetElement have IncludeLowerBound = true and IncludeUpperBound = true
/// </summary>
/// <typeparam name="T"></typeparam>
public interface INumberSetElement<T> : IBoundedSet<T> where T : IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>, IComparisonOperators<T, T, bool>
{

    // *********************** Properties ***********************

    /// <summary>
    /// Indicates if the lower bound is part of the INumberSetElement
    /// </summary>
    bool IncludeLowerBound { get; }

    /// <summary>
    /// Indicates if the upper bound is part of the INumberSetElement
    /// </summary>
    bool IncludeUpperBound { get; }
}
