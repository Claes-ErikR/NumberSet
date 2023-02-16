using System.Numerics;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace NumberSet
{
    public class NumberSetElement<T> : INumberSetElement<T>, IParsable<NumberSetElement<T>>, IEqualityOperators<NumberSetElement<T>, NumberSetElement<T>, bool>, IEqualityOperators<NumberSetElement<T>, NumberSet<T>, bool> where T : IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>, IComparisonOperators<T, T, bool>, IParsable<T>
    {

        // Constructors

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

        // Create methods

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

        // *********** Properties ***********

        public bool IncludeLowerBound { get; }

        public bool IncludeUpperBound { get; }

        public T LowerBound { get; }

        public T UpperBound { get; }

        public bool IsClosed { get; }

        public bool IsOpen { get; }

        public bool IsEmpty { get; }

        public T Measure { get; }

        // *********** Methods ***********

        // Union

        public INumberSet<T> Union(INumberSet<T> other)
        {
            var list = new List<INumberSetElement<T>>();
            list.Add(this);
            for (int i = 0; i < other.Count; i++)
                list.Add(other[i]);
            return NumberSet<T>.Create(list);
        }

        public INumberSet<T> Union(INumberSetElement<T> other)
        {
            return NumberSet<T>.Create(this, other);
        }

        // Intersect

        public INumberSet<T> Intersection(INumberSet<T> other)
        {
            var elements = new List<NumberSetElement<T>>();
            for (var i = 0; i < other.Count; i++)
            {
                var intersection = CreateIntersection(this, other[i]);
                elements.Add(intersection);
            }
            return NumberSet<T>.Create(elements);
        }

        public INumberSet<T> Intersection(INumberSetElement<T> other)
        {
            return NumberSet<T>.Create(CreateIntersection(this, other));
        }

        public bool Intersects(INumberSet<T> other)
        {
            if (IsEmpty || other.IsEmpty) return true;
            for (int i = 0; i < other.Count; i++)
                if (Intersects(other[i]))
                    return true;

            return false;
        }

        public bool Intersects(INumberSetElement<T> other) // Empty set always intersects sets
        {
            if (IsEmpty || other.IsEmpty) return true;
            return CreateIntersection(this, other).IsEmpty == false;
        }

        // Difference

        public INumberSet<T> Difference(INumberSet<T> other)
        {
            if (IsEmpty || other.IsEmpty) return NumberSet<T>.Create(this);
            var difference = RemoveIntersections(this, other);
            return NumberSet<T>.Create(difference);
        }

        public INumberSet<T> Difference(INumberSetElement<T> other)
        {
            if (IsEmpty || other.IsEmpty) return NumberSet<T>.Create(this);
            var intersection = CreateIntersection(this, other);
            if(intersection.IsEmpty)
                return NumberSet<T>.Create(this);
            else if (intersection.Equals(this))
                return NumberSet<T>.CreateEmpty();
            else
            {
                if(LowerBound == intersection.LowerBound && IncludeLowerBound == intersection.IncludeLowerBound)
                {
                    var lowerBound = intersection.UpperBound;
                    var includeLowerBound = !intersection.IncludeUpperBound;
                    return NumberSet<T>.Create(NumberSetElement<T>.Create(lowerBound, UpperBound, includeLowerBound, IncludeUpperBound));
                }
                else if(UpperBound == intersection.UpperBound && IncludeUpperBound == intersection.IncludeUpperBound)
                {
                    var upperBound = intersection.LowerBound;
                    var includeUpperBound = !intersection.IncludeLowerBound;
                    return NumberSet<T>.Create(NumberSetElement<T>.Create(LowerBound, upperBound, IncludeLowerBound, includeUpperBound));
                }
                else
                {
                    var element1 = NumberSetElement<T>.Create(LowerBound, intersection.LowerBound, IncludeLowerBound, !intersection.IncludeLowerBound);
                    var element2 = NumberSetElement<T>.Create(intersection.UpperBound, UpperBound, !intersection.IncludeUpperBound, IncludeUpperBound);
                    return NumberSet<T>.Create(element1, element2);
                }
            }
        }

        // Contains

        public bool Contains(T other)
        {
            if (IsEmpty) return false;
            if (other == LowerBound && IncludeLowerBound) return true;
            if (other == UpperBound && IncludeUpperBound) return true;
            return other > LowerBound && other < UpperBound;
        }

        public bool Contains(INumberSet<T> other) // Empty set is contained, meaning is subset
        {
            if (IsEmpty) return other.IsEmpty;
            if (other.IsEmpty) return true;
            if (other.LowerBound < LowerBound) return false;
            if (other.UpperBound > UpperBound) return false;
            var otherIncludeLowerBound = other[0].IncludeLowerBound;
            if (other.LowerBound == LowerBound && otherIncludeLowerBound && !IncludeLowerBound) return false;
            var otherIncludeUpperBound = other[other.Count - 1].IncludeUpperBound;
            if (other.UpperBound == UpperBound && otherIncludeUpperBound && !IncludeUpperBound) return false;
            return true;
        }

        public bool Contains(INumberSetElement<T> other)
        {
            if (IsEmpty) return other.IsEmpty;
            if (other.IsEmpty) return true;
            if (other.LowerBound < LowerBound) return false;
            if (other.UpperBound > UpperBound) return false;
            if (other.LowerBound == LowerBound && other.IncludeLowerBound && !IncludeLowerBound) return false;
            if (other.UpperBound == UpperBound && other.IncludeUpperBound && !IncludeUpperBound) return false;
            return true;
        }

        // Equality

        /// <summary>
        /// Compares the instance to an object
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

        public bool Equals(INumberSetElement<T>? other)
        {
            return other == null ? false : LowerBound == other.LowerBound && UpperBound== other.UpperBound && IncludeLowerBound == other.IncludeLowerBound && IncludeUpperBound == other.IncludeUpperBound;
        }

        public bool Equals(INumberSet<T>? other)
        {
            if(other == null) return false;
            if (other.Count != 1) return false;
            return Equals(other[0]);
        }

        public static bool operator ==(NumberSetElement<T>? left, NumberSetElement<T>? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(NumberSetElement<T>? left, NumberSetElement<T>? right)
        {
            return !(left == right);
        }

        public static bool operator ==(NumberSetElement<T>? left, NumberSet<T>? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(NumberSetElement<T>? left, NumberSet<T>? right)
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

        public override string ToString()
        {
            if (IsEmpty) return "Empty";
            var builder = new StringBuilder();
            builder.Append(IncludeLowerBound ? "[" : "(");
            builder.Append(LowerBound.ToString());
            builder.Append(", ");
            builder.Append(UpperBound.ToString());
            builder.Append(IncludeUpperBound ? "]" : ")");
            
            return builder.ToString();
        }

        public static NumberSetElement<T> Parse(string s, IFormatProvider? provider)
        {
            if(s == "Empty") return NumberSetElement<T>.CreateEmpty();

            var trimmedString = s.Trim();
            var includeLowerBound = false;
            if (trimmedString[0] == '[' || trimmedString[0] == '(')
                includeLowerBound = trimmedString[0] == '[';
            else
                throw new ArgumentException("Set must start with [ or (");

            var includeUpperBound = false;
            var lastCharacter = trimmedString[trimmedString.Length- 1];
            if (lastCharacter == ']' || lastCharacter == ')')
                includeUpperBound = lastCharacter == ']';
            else
                throw new ArgumentException("Set must end with ] or )");

            var numbersPart = trimmedString.Substring(1, trimmedString.Length - 2);
            var indexOfSeparator = numbersPart.IndexOf(',');
            var lowerBoundString = numbersPart.Substring(0, indexOfSeparator).Trim();
            T lowerBound;
            if (!T.TryParse(lowerBoundString, null, out lowerBound))
                throw new ArgumentException("Unable to read lower bound of set");

            var upperBoundString = numbersPart.Substring(indexOfSeparator + 1, numbersPart.Length - (indexOfSeparator + 1)).Trim();
            T upperBound;
            if (!T.TryParse(upperBoundString, null, out upperBound))
                throw new ArgumentException("Unable to read lower bound of set");

            return NumberSetElement<T>.Create(lowerBound, upperBound, includeLowerBound, includeUpperBound);
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out NumberSetElement<T> result)
        {
            try
            {
                result = NumberSetElement<T>.Parse(s, provider);
                return true;
            }
            catch 
            {
                result = null;
                return false; 
            }
        }

        // Support methods

        internal static NumberSetElement<T> CreateIntersection(INumberSetElement<T> left, INumberSetElement<T> right)
        {

            if (left.LowerBound > right.UpperBound || left.UpperBound < right.LowerBound) return CreateEmpty();
            if (left.LowerBound == right.UpperBound)
            {
                if (left.IncludeLowerBound && right.IncludeUpperBound)
                    return Create(left.LowerBound, left.LowerBound, true, true);
                else
                    return CreateEmpty();
            }
            if (left.UpperBound == right.LowerBound)
            {
                if (left.IncludeUpperBound && right.IncludeLowerBound)
                    return Create(left.UpperBound, left.UpperBound, true, true);
                else
                    return CreateEmpty();
            }
            var lowerBound = left.LowerBound > right.LowerBound ? left.LowerBound : right.LowerBound;
            var includeLowerBound = left.LowerBound ==  right.LowerBound ? (left.IncludeLowerBound && right.IncludeLowerBound) : (left.LowerBound > right.LowerBound ? left.IncludeLowerBound : right.IncludeLowerBound);
            var upperBound = left.UpperBound < right.UpperBound ? left.UpperBound : right.UpperBound;
            var includeUpperBound = left.UpperBound == right.UpperBound ? (left.IncludeUpperBound && right.IncludeUpperBound) : (left.UpperBound < right.UpperBound ? left.IncludeUpperBound : right.IncludeUpperBound);

            return Create(lowerBound, upperBound, includeLowerBound, includeUpperBound);
        }

        internal static NumberSetElement<T> CreateConnectedUnion(INumberSetElement<T> left, INumberSetElement<T> right)
        {

            if (left.LowerBound > right.UpperBound || left.UpperBound < right.LowerBound) return CreateEmpty();

            if (left.LowerBound == right.UpperBound && !left.IncludeLowerBound && !right.IncludeUpperBound) return CreateEmpty();

            if (left.UpperBound == right.LowerBound && !left.IncludeUpperBound && !right.IncludeLowerBound) return CreateEmpty();

            var lowerBound = left.LowerBound < right.LowerBound ? left.LowerBound : right.LowerBound;
            var includeLowerBound = left.LowerBound == right.LowerBound ? (left.IncludeLowerBound || right.IncludeLowerBound) : (left.LowerBound < right.LowerBound ? left.IncludeLowerBound : right.IncludeLowerBound);
            var upperBound = left.UpperBound > right.UpperBound ? left.UpperBound : right.UpperBound;
            var includeUpperBound = left.UpperBound == right.UpperBound ? (left.IncludeUpperBound || right.IncludeUpperBound) : (left.UpperBound > right.UpperBound ? left.IncludeUpperBound : right.IncludeUpperBound);

            return Create(lowerBound, upperBound, includeLowerBound, includeUpperBound);
        }

        internal static List<INumberSetElement<T>> RemoveIntersections(INumberSetElement<T> element, INumberSet<T> numberSet)
        {
            var result = new List<INumberSetElement<T>>();
            var intersection = element.Intersection(numberSet);
            if (intersection.IsEmpty)
                result.Add(element);
            else if (intersection.Equals(element))
                result.Add(NumberSetElement<T>.CreateEmpty());
            else
            {
                if (!(element.LowerBound == intersection[0].LowerBound && element.IncludeLowerBound == intersection[0].IncludeLowerBound))
                    result.Add(NumberSetElement<T>.Create(element.LowerBound, intersection[0].LowerBound, element.IncludeLowerBound, !intersection[0].IncludeLowerBound));
                for (int i = 0; i < intersection.Count - 1; i++)
                    result.Add(NumberSetElement<T>.Create(intersection[i].UpperBound, intersection[i + 1].LowerBound, !intersection[i].IncludeUpperBound, !intersection[i + 1].IncludeLowerBound));
                if (!(element.UpperBound == intersection[intersection.Count - 1].UpperBound && element.IncludeUpperBound == intersection[intersection.Count - 1].IncludeUpperBound))
                    result.Add(NumberSetElement<T>.Create(intersection[intersection.Count - 1].UpperBound, element.UpperBound, !intersection[intersection.Count - 1].IncludeUpperBound, element.IncludeUpperBound));
            }
            return result;
        }
    }
}