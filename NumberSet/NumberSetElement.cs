using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utte.NumberSet;

namespace NumberSet
{
    public class NumberSetElement<T> : INumberSetElement<T> where T : ISubtractionOperators<T, T, T>, IComparisonOperators<T, T, bool>
    {
        private NumberSetElement(T lowerbound, T upperbound, bool includelowerbound, bool includeupperbound) : 
            this(lowerbound, upperbound, includelowerbound, includeupperbound, false)
        {
        }

        private NumberSetElement(T lowerbound, T upperbound, bool includelowerbound, bool includeupperbound, bool isempty)
        {
            LowerBound = lowerbound;
            UpperBound = upperbound;
            IncludeLowerBound = includelowerbound;
            IncludeUpperBound = includeupperbound;
            IsClosed = includelowerbound && includeupperbound;
            IsOpen = !includeupperbound && !includelowerbound;
            Measure = upperbound - lowerbound;
            IsEmpty = isempty;
        }

        public static NumberSetElement<T> Create(T lowerbound, T upperbound, bool includelowerbound, bool includeupperbound)
        {
            if (lowerbound == upperbound && (!includelowerbound || !includeupperbound))
                 return CreateEmpty();
            else if (lowerbound > upperbound)
                return CreateEmpty();
            else
                return new NumberSetElement<T>(lowerbound, upperbound, includelowerbound, includeupperbound);
        }

        public static NumberSetElement<T> CreateEmpty()
        {
            return new NumberSetElement<T>(default(T), default(T), false, false, true);
        }

        public bool IncludeLowerBound { get; }

        public bool IncludeUpperBound { get; }

        public T LowerBound { get; }

        public T UpperBound { get; }

        public bool IsClosed { get; }

        public bool IsOpen { get; }

        public bool IsEmpty { get; }

        public T Measure { get; }

        INumberSet<T> IBoundedSet<T>.Difference(INumberSet<T> other)
        {
            throw new NotImplementedException();
        }

        INumberSet<T> IBoundedSet<T>.Difference(INumberSetElement<T> other)
        {
            throw new NotImplementedException();
        }

        INumberSet<T> IBoundedSet<T>.Intersection(INumberSet<T> other)
        {
            throw new NotImplementedException();
        }

        INumberSet<T> IBoundedSet<T>.Intersection(INumberSetElement<T> other)
        {
            throw new NotImplementedException();
        }

        INumberSet<T> IBoundedSet<T>.SymmetricDifference(INumberSet<T> other)
        {
            throw new NotImplementedException();
        }

        INumberSet<T> IBoundedSet<T>.SymmetricDifference(INumberSetElement<T> other)
        {
            throw new NotImplementedException();
        }

        INumberSet<T> IBoundedSet<T>.Union(INumberSet<T> other)
        {
            throw new NotImplementedException();
        }

        INumberSet<T> IBoundedSet<T>.Union(INumberSetElement<T> other)
        {
            throw new NotImplementedException();
        }
    }
}
