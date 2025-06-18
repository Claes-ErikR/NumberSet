using System.Numerics;

namespace Utte.NumberSet
{

    /// <summary>
    /// Interface for building sets of numberlike objects of type T. The sets are immutable and every operation on them creates new sets
    /// T has to implement IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>, IComparisonOperators<T, T, bool>
    /// The structure of the sets are INumberSet<T> which contains a collection of INumberSetElement<T>
    /// A single T instance is considered a point
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBoundedSet<T>: IEquatable<INumberSetElement<T>>, IEquatable<INumberSet<T>> where T : IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>, IComparisonOperators<T, T, bool>
    {
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

        /// <summary>
        /// Returns an INumberSet containing all points in at least one of the IBoundedSets
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        INumberSet<T> Union(IBoundedSet<T> other);

        /// <summary>
        /// Returns an INumberSet containing all points in both of the IBoundedSets
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        INumberSet<T> Intersection(IBoundedSet<T> other);

        /// <summary>
        /// Checks if the IBoundedSet shares any part with an INumberSet
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        bool Intersects(INumberSet<T> other);

        /// <summary>
        /// Checks if the IBoundedSet shares any part with an INumberSetElement
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        bool Intersects(INumberSetElement<T> other);

        /// <summary>
        /// Returns an INumberSet containing all points in the IBoundedSet that is not in the INumberSet set
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        INumberSet<T> Difference(INumberSet<T> other);

        /// <summary>
        /// Returns an INumberSet containing all points in the IBoundedSet that is not in the INumberSetElement set
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        INumberSet<T> Difference(INumberSetElement<T> other);

        /// <summary>
        /// Checks if the point other is within the IBoundedSet
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        bool Contains(T other);

        /// <summary>
        /// Checks if the whole INumberSet is within the IBoundedSet
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        bool Contains(INumberSet<T> other);

        /// <summary>
        /// Checks if the whole INumberSetElement is within the IBoundedSet
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        bool Contains(INumberSetElement<T> other);
    }
}
