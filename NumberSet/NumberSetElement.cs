using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utte.NumberSet;
using System.Diagnostics.CodeAnalysis;

namespace NumberSet
{
    public class NumberSetElement<T> : INumberSetElement<T>, IParsable<NumberSetElement<T>> where T : ISubtractionOperators<T, T, T>, IComparisonOperators<T, T, bool>, IParsable<T>
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

        public bool Equals(INumberSetElement<T>? other)
        {
            return LowerBound == other.LowerBound && UpperBound== other.UpperBound && IncludeLowerBound == other.IncludeLowerBound && IncludeUpperBound == other.IncludeUpperBound;
        }

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
    }
}
