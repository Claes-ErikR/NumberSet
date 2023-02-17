using System.Collections;
using System.Numerics;
using System.Text;

namespace NumberSet
{

    /// <summary>
    /// Implementation of a set using NumberSetElement as parts.
    /// Every INumberSetElement in the collection is disjunct and sorted in order.
    /// T has to implement IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>, IComparisonOperators<T, T, bool>, IParsable<T>
    /// The Empty set is considered part of any set but only equal to itself
    /// A NumberSet can only be created through static Create/CreateEmpty methods
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NumberSet<T> : INumberSet<T>, IParsable<NumberSet<T>>, IEqualityOperators<NumberSet<T>, NumberSetElement<T>, bool>, IEqualityOperators<NumberSet<T>, NumberSet<T>, bool> where T : IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>, IComparisonOperators<T, T, bool>, IParsable<T>
    {
        private List<INumberSetElement<T>> _elements;

        // Constructors

        /// <summary>
        /// Constructs a NumberSet from a list with isClosed, isOpen and measure calculated
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="isClosed"></param>
        /// <param name="isOpen"></param>
        /// <param name="measure"></param>
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

        /// <summary>
        /// Constructs an empty numberset
        /// </summary>
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

        /// <summary>
        /// Creates a NumberSet from an arbitrary number of INumberSetElement arguments.
        /// Overlapping/touching elements are joined.
        /// Empty elements are ignored.
        /// If only empty arguments are supplied, an empty set is created.
        /// The added elements are sorted.
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        public static NumberSet<T> Create(params INumberSetElement<T>[] elements)
        {
            return CreateNumberSet(elements);
        }

        /// <summary>
        /// Creates a NumberSet from a list of INumberSetElement.
        /// Overlapping/touching elements are joined.
        /// Empty elements are ignored.
        /// If only empty arguments/an empty list/null are supplied, an empty set is created.
        /// The added elements are sorted.
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        public static NumberSet<T> Create(IEnumerable<INumberSetElement<T>> elements)
        {
            return CreateNumberSet(elements);
        }

        /// <summary>
        /// Creates a NumberSet from a list of INumberSetElement.
        /// Overlapping/touching elements are joined.
        /// Empty elements are ignored.
        /// If only empty arguments/an empty list/null are supplied, an empty set is created.
        /// The added elements are sorted.
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        private static NumberSet<T> CreateNumberSet(IEnumerable<INumberSetElement<T>> elements) 
        {
            if(elements == null) return CreateEmpty();
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
                measure = measure == null ? element.Measure : measure + element.Measure;
            }

            return new NumberSet<T>(workListElements, isClosed, isOpen, measure);
        }

        /// <summary>
        /// Creates an empty NumberSet
        /// </summary>
        /// <returns></returns>
        public static NumberSet<T> CreateEmpty()
        {
            return new NumberSet<T>();
        }

        // Create support methods

        /// <summary>
        /// Adds element to workListElements.
        /// If element is overlapping/touching any elements they are joined.
        /// If element is empty it is ignored.
        /// The added element is added in sorted order.
        /// </summary>
        /// <param name="workListElements"></param>
        /// <param name="element"></param>
        private static void Add(List<INumberSetElement<T>> workListElements, INumberSetElement<T> element)
        {
            if (element != null && !element.IsEmpty)
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

        /// <summary>
        /// Returns element at index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public INumberSetElement<T> this[int index]
        {
            get
            {
                return _elements[index];
            }
        }

        /// <summary>
        /// Returns the lower bound of the first element in the set. I.e. the lower bound of the whole set
        /// </summary>
        public T LowerBound { get; }

        /// <summary>
        /// Returns the upper bound of the last element in the set. I.e. the upper bound of the whole set
        /// </summary>
        public T UpperBound { get; }

        /// <summary>
        /// Indicates if the set is closed, a NumberSet is closed if all its elements are closed
        /// </summary>
        public bool IsClosed { get; }

        /// <summary>
        /// Indicates if the set is open, a NumberSet is open if all its elements are open
        /// </summary>
        public bool IsOpen { get; }

        /// <summary>
        /// Indicates if the instance is the empty set
        /// </summary>
        public bool IsEmpty { get; }

        /// <summary>
        /// Returns the measure of the instance, the measure of a NumberSet is the sum of the measure of all its elements
        /// </summary>
        public T Measure { get; }

        /// <summary>
        /// Returns the number of elements in the instance
        /// </summary>
        public int Count { get; }

        // *********** Methods ***********

        // Union

        /// <summary>
        /// Returns an INumberSet containing all points in at least one of the instance and INumberSet sets
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public INumberSet<T> Union(INumberSet<T> other)
        {
            var elements = new List<INumberSetElement<T>>();
            for (var i = 0; i < Count; i++)
                elements.Add(this[i]);
            for (var i = 0; i < other.Count; i++)
                elements.Add(other[i]);

            return NumberSet<T>.Create(elements);
        }

        /// <summary>
        /// Returns an INumberSet containing all points in at least one of the instance and INumberSetElement sets
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public INumberSet<T> Union(INumberSetElement<T> other)
        {
            return other.Union(this);
        }

        // Intersect

        /// <summary>
        /// Returns an INumberSet containing all points in both of the instance and INumberSet sets
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns an INumberSet containing all points in both of the instance and INumberSetElement sets
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Checks if the instance shares any part with an INumberSet
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Intersects(INumberSet<T> other)
        {
            if (IsEmpty || other.IsEmpty) return true;
            for (int i = 0; i < Count; i++)
                if (this[i].Intersects(other))
                    return true;

            return false;

        }

        /// <summary>
        /// Checks if the instance shares any part with an INumberSetElement
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Intersects(INumberSetElement<T> other)
        {
            if (IsEmpty || other.IsEmpty) return true;
            for (int i = 0; i < Count; i++)
                if (!NumberSetElement<T>.CreateIntersection(this[i], other).IsEmpty)
                    return true;

            return false;
        }

        // Difference

        /// <summary>
        /// Returns an INumberSet containing all points in the instance that is not in the INumberSet set
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns an INumberSet containing all points in the instance that is not in the INumberSetElement set
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
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

        // Contains

        /// <summary>
        /// Checks if the point other is within the instance
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Contains(T other)
        {
            if (IsEmpty) return false;
            for (int i = 0; i < Count; i++)
                if (_elements[i].Contains(other))
                    return true;

            return false;
        }

        /// <summary>
        /// Checks if the whole INumberSet is within the instance
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Checks if the whole INumberSetElement is within the instance
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Contains(INumberSetElement<T> other)
        {
            if (IsEmpty) return other.IsEmpty;
            if (other.IsEmpty) return true;
            for (int i = 0; i < Count; i++)
                if (_elements[i].Contains(other))
                    return true;

            return false;
        }

        //Equality

        /// <summary>
        /// Compares the instance to an object for equality
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is INumberSetElement<T>)
                return Equals((INumberSetElement<T>)obj);
            if (obj is INumberSet<T>)
                return Equals((INumberSet<T>)obj);
            return false;
        }

        /// <summary>
        /// Compares the instance to an INumberSetElement for equality
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(INumberSetElement<T>? other)
        {
            if (other == null) return false;
            if (Count != 1) return false;
            return this[0].Equals(other);
        }

        /// <summary>
        /// Compares the instance to an INumberSet for equality
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(INumberSet<T>? other)
        {
            if (other == null) return false;
            if (Count != other.Count) return false;
            for (int i = 0; i < Count; i++)
                if (!this[i].Equals(other[i]))
                    return false;

            return true;
        }

        /// <summary>
        /// Compares a NumberSet to a NumberSetElement for equality
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(NumberSet<T>? left, NumberSetElement<T>? right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Compares a NumberSet to a NumberSetElement for inequality
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(NumberSet<T>? left, NumberSetElement<T>? right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Compares two NumberSets for equality
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(NumberSet<T>? left, NumberSet<T>? right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Compares two NumberSets for inequality
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(NumberSet<T>? left, NumberSet<T>? right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Get hashcode calculated from string representation of the instance
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        // Text

        /// <summary>
        /// Creates a string representation of the instance on the form (x, y); [z, w] ... x/z is lower bound and y/w is upper bound.
        /// Parenthesis are used to indicate if bounds are included. ( or ) means lower/upper bound is not included while
        /// [ or ] means lower/upper bound is included. Each element in the instance is represented by one pair of numbers
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Extracts a NumberSet from a string. The string is expected to be on the form (x, y); [z, w] ... where x/z is lower bound and y/w is upper bound.
        /// Parenthesis are used to indicate if bounds are included. ( or ) means lower/upper bound is not included while [ or ] means lower/upper bound is included.
        /// Each element in the instance produces one pair of numbers
        /// </summary>
        /// <param name="s"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// Tries to extract a NumberSet from a string. The string is expected to be on the form (x, y); [z, w] ... where x/z is lower bound and y/w is upper bound.
        /// Parenthesis are used to indicate if bounds are included. ( or ) means lower/upper bound is not included while [ or ] means lower/upper bound is included.
        /// Each element in the instance produces one pair of numbers
        /// </summary>
        /// <param name="s"></param>
        /// <param name="provider"></param>
        /// <param name="result"></param>
        /// <returns></returns>
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

        // Enumerator

        /// <summary>
        /// Returns enumerator for the instance
        /// </summary>
        /// <returns></returns>
        public IEnumerator<INumberSetElement<T>> GetEnumerator()

        {
            return _elements.GetEnumerator();
        }

        /// <summary>
        /// Returns enumerator for the instance
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
