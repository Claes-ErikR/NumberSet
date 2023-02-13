using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utte.NumberSet;

namespace NumberSet
{
    public class NumberSet<T> : INumberSet<T>
    {
        public T LowerBound => throw new NotImplementedException();

        public T UpperBound => throw new NotImplementedException();

        public bool IsClosed => throw new NotImplementedException();

        public bool IsOpen => throw new NotImplementedException();

        public bool IsEmpty => throw new NotImplementedException();

        public T Measure => throw new NotImplementedException();

        bool IBoundedSet<T>.Contains(T other)
        {
            throw new NotImplementedException();
        }

        bool IBoundedSet<T>.Contains(INumberSet<T> other)
        {
            throw new NotImplementedException();
        }

        bool IBoundedSet<T>.Contains(INumberSetElement<T> other)
        {
            throw new NotImplementedException();
        }

        INumberSet<T> Utte.NumberSet.IBoundedSet<T>.Difference(INumberSet<T> other)
        {
            throw new NotImplementedException();
        }

        INumberSet<T> Utte.NumberSet.IBoundedSet<T>.Difference(INumberSetElement<T> other)
        {
            throw new NotImplementedException();
        }

        INumberSet<T> Utte.NumberSet.IBoundedSet<T>.Intersection(INumberSet<T> other)
        {
            throw new NotImplementedException();
        }

        INumberSet<T> Utte.NumberSet.IBoundedSet<T>.Intersection(INumberSetElement<T> other)
        {
            throw new NotImplementedException();
        }

        bool IBoundedSet<T>.Intersects(INumberSet<T> other)
        {
            throw new NotImplementedException();
        }

        bool IBoundedSet<T>.Intersects(INumberSetElement<T> other)
        {
            throw new NotImplementedException();
        }

        INumberSet<T> Utte.NumberSet.IBoundedSet<T>.SymmetricDifference(INumberSet<T> other)
        {
            throw new NotImplementedException();
        }

        INumberSet<T> Utte.NumberSet.IBoundedSet<T>.SymmetricDifference(INumberSetElement<T> other)
        {
            throw new NotImplementedException();
        }

        INumberSet<T> Utte.NumberSet.IBoundedSet<T>.Union(INumberSet<T> other)
        {
            throw new NotImplementedException();
        }

        INumberSet<T> Utte.NumberSet.IBoundedSet<T>.Union(INumberSetElement<T> other)
        {
            throw new NotImplementedException();
        }
    }
}
