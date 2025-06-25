using System.Numerics;

namespace Utte.NumberSet;

/// <summary>
/// Interface for building sets of numberlike objects of type T. The sets are immutable and every operation on them creates new sets
/// T has to implement IAdditionOperators&lt;T, T, T&gt;, ISubtractionOperators&lt;T, T, T&gt;, IComparisonOperators&lt;T, T, bool&gt;
/// The structure of the sets are INumberSet&lt;T&gt; which contains a collection of INumberSetElement&lt;T&gt;
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IBoundedSet<T>: IEquatable<INumberSetElement<T>>, IEquatable<INumberSet<T>> where T : IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>, IComparisonOperators<T, T, bool>
{

    // *********************** Properties ***********************

    /// <summary>
    /// Lower bound of the lowest element in the set
    /// </summary>
    T LowerBound { get; }

    /// <summary>
    /// Upper bound of the highest element in the set
    /// </summary>
    T UpperBound { get; }

    /// <summary>
    /// Indicates if the set is closed, i.e. contains all it's bounds
    /// </summary>
    bool IsClosed { get; }

    /// <summary>
    /// Indicates if the set is open, i.e. contains none of it's bounds
    /// </summary>
    bool IsOpen { get; }

    /// <summary>
    /// Indication if the set is the empty set
    /// </summary>
    bool IsEmpty { get; }

    /// <summary>
    /// Returns the measure of the whole set, for a set with elements it is the sum of the elements measure
    /// </summary>
    T Measure { get; }

    // *********************** Methods ***********************

    /// <summary>
    /// Returns an INumberSet containing all points in at least one of the set and an IBoundedSet
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    INumberSet<T> Union(IBoundedSet<T> other);

    /// <summary>
    /// Returns an INumberSet containing all points in both of the set and an IBoundedSet
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    INumberSet<T> Intersection(IBoundedSet<T> other);

    /// <summary>
    /// Checks if the set shares any part with an IBoundedSet
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    bool Intersects(IBoundedSet<T> other);

    /// <summary>
    /// Returns an INumberSet containing all points in the set that is not in an IBoundedSet
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    INumberSet<T> Difference(IBoundedSet<T> other);

    /// <summary>
    /// Checks if the point other is within the set
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    bool Contains(T other);

    /// <summary>
    /// Checks if the whole of an IBoundedSet is within the set
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    bool Contains(IBoundedSet<T> other);
}
