﻿using NumberSet;
using System.Numerics;

namespace Utte.NumberSet
{
    public interface IBoundedSet<T>: IEquatable<INumberSetElement<T>>, IEquatable<INumberSet<T>> where T : IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>, IComparisonOperators<T, T, bool>
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
        bool Contains(T other);
        bool Contains(INumberSet<T> other);
        bool Contains(INumberSetElement<T> other);
        bool Intersects(INumberSet<T> other);
        bool Intersects(INumberSetElement<T> other);
    }
}
