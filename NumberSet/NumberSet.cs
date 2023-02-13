using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Utte.NumberSet;

namespace NumberSet
{
    public class NumberSet<T> : INumberSet<T>, IParsable<NumberSet<T>> where T : IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>, IComparisonOperators<T, T, bool>, IParsable<T>
    {
        private List<INumberSetElement<T>> _elements;

        private NumberSet(List<INumberSetElement<T>> elements, bool isClosed, bool isOpen, T measure)
        {
            _elements = elements;
            LowerBound = _elements[0].LowerBound;
            UpperBound = _elements[_elements.Count - 1].UpperBound;
            IsClosed = isClosed;
            IsOpen = isOpen;
            IsEmpty = false;
            Measure = measure;
            Count = _elements.Count;
        }

        private NumberSet()
        {
            _elements = new List<INumberSetElement<T>>() { NumberSetElement<T>.CreateEmpty() };
            LowerBound = _elements[0].LowerBound;
            UpperBound = _elements[_elements.Count - 1].UpperBound;
            IsClosed = _elements[0].IncludeUpperBound;
            IsOpen = _elements[0].IsOpen;
            IsEmpty = true;
            Measure = _elements[0].Measure;
            Count = 1;
        }

        public static NumberSet<T> Create(IEnumerable<INumberSetElement<T>> elements)
        {
            List<INumberSetElement<T>> workListElements = new List<INumberSetElement<T>>();
            foreach (var element in elements)
                Add(workListElements, element);

            if (workListElements.Count == 0) return CreateEmpty();

            var isClosed = true;
            var isOpen = true;
            T measure = default;
            foreach (var element in workListElements)
            {
                isClosed = isClosed && element.IsClosed;
                isOpen = isOpen && element.IsOpen;
                measure = measure + element.Measure;
            }

            return new NumberSet<T>(workListElements, isClosed, isOpen, measure);
        }

        public static NumberSet<T> CreateEmpty()
        {
            return new NumberSet<T>();
        }


        private static void Add(List<INumberSetElement<T>> workListElements, INumberSetElement<T> element)
        {
            if (!element.IsEmpty)
            {
                var newElement = element;
                var intersectList = new List<INumberSetElement<T>>();
                int index = 0;
                while(index < workListElements.Count)
                {
                    var connectedUnion = NumberSetElement<T>.CreateConnectedUnion(newElement, workListElements[index]);
                    if(!connectedUnion.IsEmpty)
                    {
                        newElement = connectedUnion;
                        intersectList.Add(workListElements[index]);
                        workListElements.RemoveAt(index);
                    }
                    else if (newElement.Contains(workListElements[index]))
                        workListElements.RemoveAt(index);
                    else
                        index++;
                }
                var insertIndex = int.MinValue;
                for (int i = 0; i < workListElements.Count; i++)
                {
                    if (newElement.LowerBound < workListElements[i].LowerBound)
                    {
                        insertIndex = i;
                        break;
                    }
                }
                if(insertIndex == int.MinValue)
                    workListElements.Add(newElement);
                else
                    workListElements.Insert(insertIndex, newElement);
            }
        }

        public INumberSetElement<T> this[int index]
        {
            get
            {
                return _elements[index];
            }
        }

        public T LowerBound { get; }

        public T UpperBound { get; }

        public bool IsClosed { get; }

        public bool IsOpen { get; }

        public bool IsEmpty { get; }

        public T Measure { get; }

        public int Count { get; }

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

        IEnumerator<INumberSetElement<T>> IEnumerable<INumberSetElement<T>>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
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

        public override string ToString() 
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_elements[0].ToString());
            for (int i = 1; i < _elements.Count; i++)
            {
                sb.Append("; ");
                sb.Append(_elements[i].ToString());
            }

            return sb.ToString();
        }

        public bool Equals(INumberSet<T>? other)
        {
            if(other == null) return false;
            if(Count != other.Count) return false;
            for (int i = 0; i < Count; i++)
                if (!this[i].Equals(other[i]))
                    return false;

            return true;
        }

        public static NumberSet<T> Parse(string s, IFormatProvider? provider)
        {
            if (s == "Empty") return NumberSet<T>.CreateEmpty();

            var trimmedString = s.Trim();
            string[] parts = trimmedString.Split(';');

            var elements = new List<INumberSetElement<T>>();
            foreach (var part in parts)
            {
                if(NumberSetElement<T>.TryParse(part, null, out NumberSetElement<T> element))
                {
                    if(!element.IsEmpty)
                        elements.Add(element);
                }
                else
                {
                    throw new ArgumentException("Could not parse element " + part);
                }
            }

            return NumberSet<T>.Create(elements);
        }

        public static bool TryParse(string? s, IFormatProvider? provider, out NumberSet<T> result)
        {
            try
            {
                result = NumberSet<T>.Parse(s, provider);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
    }
}
