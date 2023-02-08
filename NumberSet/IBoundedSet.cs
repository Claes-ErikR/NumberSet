using NumberSet;

namespace Utte.NumberSet
{
    interface IBoundedSet<T>
    {
        T LowerBound { get; }
        T UpperBound { get; }
        bool IsClosed { get; }
        bool IsOpen { get; }
        bool IsEmpty { get; }
        T Measure { get; }
        INumberSet<T> Union(INumberSet<T> other);
        INumberSet<T> Union(INumberSetElement<T> other);
        INumberSet<T> Intersection(INumberSet<T> other);
        INumberSet<T> Intersection(INumberSetElement<T> other);
        INumberSet<T> Difference(INumberSet<T> other);
        INumberSet<T> Difference(INumberSetElement<T> other);
        INumberSet<T> SymmetricDifference(INumberSet<T> other);
        INumberSet<T> SymmetricDifference(INumberSetElement<T> other);
    }
}
