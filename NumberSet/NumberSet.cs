using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Utte.NumberSet;

namespace NumberSet
{
    public class NumberSet<T> : INumberSet<T>, IParsable<NumberSet<T>> where T : IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>, IComparisonOperators<T, T, bool>, IParsable<T>
    {
        private List<INumberSetElement<T>> _elements;

        // Constructors

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

        // Create methods

        public static NumberSet<T> Create(params INumberSetElement<T>[] elements)
        {
            return CreateNumberSet(elements);
        }

        public static NumberSet<T> Create(IEnumerable<INumberSetElement<T>> elements)
        {
            return CreateNumberSet(elements);
        }

        private static NumberSet<T> CreateNumberSet(IEnumerable<INumberSetElement<T>> elements) 
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

        // Create support methods

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

        // *********** Properties ***********

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

        // *********** Methods ***********

        // Union

        public INumberSet<T> Union(INumberSet<T> other)
        {
            var elements = new List<INumberSetElement<T>>();
            for (var i = 0; i < Count; i++)
                elements.Add(this[i]);
            for (var i = 0; i < other.Count; i++)
                elements.Add(other[i]);

            return NumberSet<T>.Create(elements);
        }

        public INumberSet<T> Union(INumberSetElement<T> other)
        {
            return other.Union(this);
        }

        // Intersect

        public INumberSet<T> Intersection(INumberSet<T> other)
        {
            var elements = new List<NumberSetElement<T>>();
            for (var i = 0; i < Count; i++)
            {
                for (var j = 0; j < other.Count; j++)
                {
                    var intersection = NumberSetElement<T>.CreateIntersection(this[i], other[j]);
                    elements.Add(intersection);
                }
            }
            return NumberSet<T>.Create(elements);
        }

        public INumberSet<T> Intersection(INumberSetElement<T> other)
        {
            var elements = new List<NumberSetElement<T>>();
            for (var i = 0; i < Count; i++)
            {
                var intersection = NumberSetElement<T>.CreateIntersection(this[i], other);
                elements.Add(intersection);
            }
            return NumberSet<T>.Create(elements);
        }

        public bool Intersects(INumberSet<T> other)
        {
            if (IsEmpty || other.IsEmpty) return true;
            for (int i = 0; i < Count; i++)
                if (this[i].Intersects(other))
                    return true;

            return false;

        }

        public bool Intersects(INumberSetElement<T> other)
        {
            if (IsEmpty || other.IsEmpty) return true;
            for (int i = 0; i < Count; i++)
                if (!NumberSetElement<T>.CreateIntersection(this[i], other).IsEmpty)
                    return true;

            return false;
        }

        // Difference

        public INumberSet<T> Difference(INumberSet<T> other)
        {
            if (IsEmpty || other.IsEmpty) return this;
            var elements = new List<INumberSetElement<T>>();
            for (int i = 0; i < Count; i++)
            {
                var difference = NumberSetElement<T>.RemoveIntersections(this[i], other);
                for (int k = 0; k < difference.Count; k++)
                    elements.Add(difference[k]);
            }

            return NumberSet<T>.Create(elements);
        }

        public INumberSet<T> Difference(INumberSetElement<T> other)
        {
            if (IsEmpty || other.IsEmpty) return this;
            var elements = new List<INumberSetElement<T>>();
            for (int i = 0; i < Count; i++)
            {
                var difference = this[i].Difference(other);
                for (int k = 0; k < difference.Count; k++)
                    elements.Add(difference[k]);
            }

            return NumberSet<T>.Create(elements);
        }

        public INumberSet<T> SymmetricDifference(INumberSet<T> other)
        {
            throw new NotImplementedException();
        }

        public INumberSet<T> SymmetricDifference(INumberSetElement<T> other)
        {
            throw new NotImplementedException();
        }

        // Contains

        public bool Contains(T other)
        {
            if (IsEmpty) return false;
            for (int i = 0; i < Count; i++)
                if (_elements[i].Contains(other))
                    return true;

            return false;
        }

        public bool Contains(INumberSet<T> other)
        {
            if (IsEmpty) return other.IsEmpty;
            if (other.IsEmpty) return true;

            var workList = new List<INumberSetElement<T>>();
            for (int i = 0; i < other.Count; i++)
                workList.Add(other[i]);

            for (int i = 0; i < Count; i++)
            {
                var item = this[i];
                int k = 0;
                while(k< workList.Count)
                {
                    if (item.Contains(workList[k]))
                        workList.RemoveAt(k);
                    else
                        k++;
                }
            }

            return workList.Count == 0;
        }

        public bool Contains(INumberSetElement<T> other)
        {
            if (IsEmpty) return other.IsEmpty;
            if (other.IsEmpty) return true;
            for (int i = 0; i < Count; i++)
                if (_elements[i].Contains(other))
                    return true;

            return false;
        }

        // Equality

        public bool Equals(INumberSet<T>? other)
        {
            if (other == null) return false;
            if (Count != other.Count) return false;
            for (int i = 0; i < Count; i++)
                if (!this[i].Equals(other[i]))
                    return false;

            return true;
        }

        // Text

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

        public static NumberSet<T> Parse(string s, IFormatProvider? provider)
        {
            if (s == "Empty") return NumberSet<T>.CreateEmpty();

            var trimmedString = s.Trim();
            string[] parts = trimmedString.Split(';');

            var elements = new List<INumberSetElement<T>>();
            foreach (var part in parts)
            {
                if (NumberSetElement<T>.TryParse(part, null, out NumberSetElement<T> element))
                {
                    if (!element.IsEmpty)
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

        // Enumerator                                                                              <- Not finished

        IEnumerator<INumberSetElement<T>> IEnumerable<INumberSetElement<T>>.GetEnumerator()

        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
