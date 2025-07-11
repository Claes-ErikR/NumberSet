﻿using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Text;
using Utte.NumberSet.Extensions;

namespace Utte.NumberSet;

/// <summary>
/// Implementation of elements of a set which is a set in itself. NumberSetElement is used as part of NumberSet
/// T has to implement IAdditionOperators&lt;T, T, T&gt;, ISubtractionOperators&lt;T, T, T&gt;, IComparisonOperators&lt;T, T, bool&gt;, IParsable&lt;T&gt;
/// The Empty set is considered part of any set but only equal to itself
/// A NumberSetElement can only be created through static Create/CreateEmpty methods
/// Infinities are treated as the smallest/largest possible number and can be excluded or included in the set
/// NaN is not allowed as bounds and results in an empty set being created, a NaN point is regarded as not belonging to any set
/// An implicit cast to NumberSet exists
/// An instance can be deconstructed into LowerBound and UpperBound or into LowerBound, UpperBound, IncludeLowerBound and IncludeUpperBound
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed class NumberSetElement<T> : INumberSetElement<T>, IParsable<NumberSetElement<T>>, IEqualityOperators<NumberSetElement<T>, NumberSetElement<T>, bool>, IEqualityOperators<NumberSetElement<T>, NumberSet<T>, bool>, IFormattable where T : IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>, IComparisonOperators<T, T, bool>, IParsable<T>, IFormattable
{

    // *********************** Constructors ***********************

    /// <summary>
    /// Constructs a non-empty NumberSetElement
    /// </summary>
    /// <param name="lowerbound"></param>
    /// <param name="upperbound"></param>
    /// <param name="includelowerbound"></param>
    /// <param name="includeupperbound"></param>
    private NumberSetElement(T lowerbound, T upperbound, bool includelowerbound, bool includeupperbound)
    {
        LowerBound = lowerbound;
        UpperBound = upperbound;
        IncludeLowerBound = includelowerbound;
        IncludeUpperBound = includeupperbound;
        IsClosed = includelowerbound && includeupperbound;
        IsOpen = !includeupperbound && !includelowerbound;
        Measure = upperbound - lowerbound;
        IsEmpty = false;
    }

    /// <summary>
    /// Creates an empty set
    /// LowerBound and UpperBound are set to default for T
    /// IncludeLowerBound and IncludeUpperBound are set to false
    /// Measure will be the default for T
    /// </summary>
    private NumberSetElement()
    {
        LowerBound = default!;
        UpperBound = default!;
        IncludeLowerBound = false;
        IncludeUpperBound = false;
        IsClosed = false;
        IsOpen = true;
        Measure = default!;
        IsEmpty = true;
    }

    // *********************** Create methods ***********************

    /// <summary>
    /// Creates a non-empty set of the parameters are valid. Invalid parameters that constructs an empty set are:
    /// - lowerbound > upperbound
    /// - lowerbound equal to upperbound and at least one of includelowerbound and includeupperbound is false
    /// - lowerbound or upperbound is null
    /// Infinities are treated as the smallest/largest possible number and can be excluded or included in the set
    /// If T is float or double and lowerbound or upperbound is NaN an empty set is returned
    /// </summary>
    /// <param name="lowerbound"></param>
    /// <param name="upperbound"></param>
    /// <param name="includelowerbound"></param>
    /// <param name="includeupperbound"></param>
    /// <returns></returns>
    public static NumberSetElement<T> Create(T lowerbound, T upperbound, bool includelowerbound, bool includeupperbound)
    {
        if (lowerbound == null || upperbound == null)
            return Empty;
        else if (CheckIfNaN(lowerbound) || CheckIfNaN(upperbound))
            return Empty;
        else if (lowerbound == upperbound && (!includelowerbound || !includeupperbound))
            return Empty;
        else if (lowerbound > upperbound)
            return Empty;
        else
            return new NumberSetElement<T>(lowerbound, upperbound, includelowerbound, includeupperbound);
    }

    // *********************** Properties ***********************

    /// <summary>
    /// Indicates if the LowerBound is part of the set element
    /// </summary>
    public bool IncludeLowerBound { get; }

    /// <summary>
    /// Indicates if the UpperBound is part of the set element
    /// </summary>
    public bool IncludeUpperBound { get; }

    /// <summary>
    /// Returns the lower bound of the set element
    /// </summary>
    public T LowerBound { get; }

    /// <summary>
    /// Returns the upper bound of the set element
    /// </summary>
    public T UpperBound { get; }

    /// <summary>
    /// Indicates if both lower and upper bounds are part of the set element
    /// </summary>
    public bool IsClosed { get; }

    /// <summary>
    /// Indicates if none of the lower and upper bounds are part of the set element
    /// </summary>
    public bool IsOpen { get; }

    /// <summary>
    /// Indicates if the set element is the empty set
    /// </summary>
    public bool IsEmpty { get; }

    /// <summary>
    /// Returns the measure (UpperBound - LowerBound) of the set element
    /// </summary>
    public T Measure { get; }

    // *********************** Methods ***********************

    // Union

    /// <summary>
    /// Returns an INumberSet containing all points in at least one of the set element and an IBoundedSet
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public INumberSet<T> Union(IBoundedSet<T> other)
    {
        if (other is INumberSet<T>) return Union((INumberSet<T>)other);
        if (other is INumberSetElement<T>) return Union((INumberSetElement<T>)other);
        throw new ArgumentException(string.Format("Only types implementing {0}<{2}> or {1}<{2}> allowed", nameof(INumberSet<T>), nameof(INumberSetElement<T>), nameof(T)));
    }

    /// <summary>
    /// Returns an INumberSet containing all points in at least one of the set element and an INumberSet set
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    private INumberSet<T> Union(INumberSet<T> other)
    {
        var list = new List<INumberSetElement<T>>();
        list.Add(this);
        for (int i = 0; i < other.Count; i++)
            list.Add(other[i]);
        return NumberSet<T>.Create(list);
    }

    /// <summary>
    /// Returns an INumberSet containing all points in at least one of the set element and an INumberSetElement set
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    private INumberSet<T> Union(INumberSetElement<T> other)
    {
        return NumberSet<T>.Create(this, other);
    }

    // Intersect

    /// <summary>
    /// Returns an INumberSet containing all points in both of the set element and an IBoundedSet set
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public INumberSet<T> Intersection(IBoundedSet<T> other)
    {
        if (other is INumberSet<T>) return Intersection((INumberSet<T>)other);
        if (other is INumberSetElement<T>) return Intersection((INumberSetElement<T>)other);
        throw new ArgumentException(string.Format("Only types implementing {0}<{2}> or {1}<{2}> allowed", nameof(INumberSet<T>), nameof(INumberSetElement<T>), nameof(T)));
    }

    /// <summary>
    /// Returns an INumberSet containing all points in both of the set element and an INumberSet set
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    private INumberSet<T> Intersection(INumberSet<T> other)
    {
        var elements = new List<INumberSetElement<T>>();
        for (var i = 0; i < other.Count; i++)
        {
            var intersection = CreateIntersection(this, other[i]);
            elements.Add(intersection);
        }
        return NumberSet<T>.Create(elements);
    }

    /// <summary>
    /// Returns an INumberSet containing all points in both of the set element and an INumberSetElement set
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    private INumberSet<T> Intersection(INumberSetElement<T> other)
    {
        return NumberSet<T>.Create(CreateIntersection(this, other));
    }

    // Intersects

    /// <summary>
    /// Checks if the set element shares any part with an IBoundedSet set
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Intersects(IBoundedSet<T> other)
    {
        if (other is INumberSet<T>) return Intersects((INumberSet<T>)other);
        if (other is INumberSetElement<T>) return Intersects((INumberSetElement<T>)other);
        throw new ArgumentException(string.Format("Only types implementing {0}<{2}> or {1}<{2}> allowed", nameof(INumberSet<T>), nameof(INumberSetElement<T>), nameof(T)));
    }

    /// <summary>
    /// Checks if the set element shares any part with an INumberSet set
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    private bool Intersects(INumberSet<T> other)
    {
        if (IsEmpty || other.IsEmpty) return true;
        for (int i = 0; i < other.Count; i++)
            if (Intersects(other[i]))
                return true;

        return false;
    }

    /// <summary>
    /// Checks if the set element shares any part with an INumberSetElement set
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    private bool Intersects(INumberSetElement<T> other)
    {
        if (IsEmpty || other.IsEmpty) return true;
        return CreateIntersection(this, other).IsEmpty == false;
    }

    // Difference

    /// <summary>
    /// Returns an INumberSet containing all points in the set element that is not in an IBoundedSet set
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public INumberSet<T> Difference(IBoundedSet<T> other)
    {
        if (other is INumberSet<T>) return Difference((INumberSet<T>)other);
        if (other is INumberSetElement<T>) return Difference((INumberSetElement<T>)other);
        throw new ArgumentException(string.Format("Only types implementing {0}<{2}> or {1}<{2}> allowed", nameof(INumberSet<T>), nameof(INumberSetElement<T>), nameof(T)));
    }

    /// <summary>
    /// Returns an INumberSet containing all points in the set element that is not in an INumberSet set
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    private INumberSet<T> Difference(INumberSet<T> other)
    {
        if (IsEmpty || other.IsEmpty) return NumberSet<T>.Create(this);
        var difference = RemoveIntersections(this, other);
        return NumberSet<T>.Create(difference);
    }

    /// <summary>
    /// Returns an INumberSet containing all points in the set element that is not in an INumberSetElement set
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    private INumberSet<T> Difference(INumberSetElement<T> other)
    {
        if (IsEmpty || other.IsEmpty) return NumberSet<T>.Create(this);
        var intersection = CreateIntersection(this, other);
        if(intersection.IsEmpty)
            return NumberSet<T>.Create(this);
        else if (intersection.Equals(this))
            return NumberSet<T>.Empty;
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

    /// <summary>
    /// Checks if the point other is within the set element
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Contains(T other)
    {
        if (IsEmpty) return false;
        if (other == LowerBound && IncludeLowerBound) return true;
        if (other == UpperBound && IncludeUpperBound) return true;
        return other > LowerBound && other < UpperBound;
    }

    /// <summary>
    /// Checks if the whole of an IBoundedSet is within the set element
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Contains(IBoundedSet<T> other)
    {
        if (other is INumberSet<T>) return Contains((INumberSet<T>)other);
        if (other is INumberSetElement<T>) return Contains((INumberSetElement<T>)other);
        throw new ArgumentException(string.Format("Only types implementing {0}<{2}> or {1}<{2}> allowed", nameof(INumberSet<T>), nameof(INumberSetElement<T>), nameof(T)));
    }

    /// <summary>
    /// Checks if the whole of an INumberSet is within the set element
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    private bool Contains(INumberSet<T> other)
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

    /// <summary>
    /// Checks if the whole of an INumberSetElement is within the set element
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    private bool Contains(INumberSetElement<T> other)
    {
        if (IsEmpty) return other.IsEmpty;
        if (other.IsEmpty) return true;
        if (other.LowerBound < LowerBound) return false;
        if (other.UpperBound > UpperBound) return false;
        if (other.LowerBound == LowerBound && other.IncludeLowerBound && !IncludeLowerBound) return false;
        if (other.UpperBound == UpperBound && other.IncludeUpperBound && !IncludeUpperBound) return false;
        return true;
    }

    // *********************** Equality implementation ***********************

    /// <summary>
    /// Compares the instance to an object for equality
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
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
        if (IsEmpty) return other.IsEmpty;
        if (other.IsEmpty) return false;
        return LowerBound == other.LowerBound && UpperBound== other.UpperBound && IncludeLowerBound == other.IncludeLowerBound && IncludeUpperBound == other.IncludeUpperBound;
    }

    /// <summary>
    /// Compares the instance to an INumberSet for equality
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(INumberSet<T>? other)
    {
        if(other == null) return false;
        if (other.Count != 1) return false;
        return Equals(other[0]);
    }

    // *********************** GetHashCode ***********************

    /// <summary>
    /// Get hashcode calculated from string representation of the instance
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return ToString(null, CultureInfo.InvariantCulture).GetHashCode();
    }

    // *********************** ToString ***********************

    /// <summary>
    /// Creates a string representation of the instance on the form (x, y). x is lower bound and y is upper bound.
    /// Parenthesis are used to indicate if bounds are included. ( or ) means lower/upper bound is not included while
    /// [ or ] means lower/upper bound is included
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return ToString(null, null);
    }

    /// <summary>
    /// Creates a string representation of the instance on the form (x, y). x is lower bound and y is upper bound.
    /// Parenthesis are used to indicate if bounds are included. ( or ) means lower/upper bound is not included while
    /// [ or ] means lower/upper bound is included. For cultures with comma separator in numbers, a ; is used instead
    /// of , i.e. (x; y) instead of (x, y)
    /// </summary>
    /// <param name="format"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public string ToString(string? format, IFormatProvider? provider)
    {
        if (IsEmpty) return "Empty";
        var builder = new StringBuilder();
        builder.Append(IncludeLowerBound ? "[" : "(");
        builder.Append(LowerBound.ToString(format, provider));
        builder.Append(provider.GetNumberSetElementSeparator());
        builder.Append(' ');
        builder.Append(UpperBound.ToString(format, provider));
        builder.Append(IncludeUpperBound ? "]" : ")");

        return builder.ToString();
    }

    // *********************** Parse ***********************

    /// <summary>
    /// Extracts a NumberSetElement from a string. The string is expected to be on the form (x, y) where x is lower bound and y is upper bound.
    /// Parenthesis are used to indicate if bounds are included. ( or ) means lower/upper bound is not included while [ or ] means lower/upper bound is included
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static NumberSetElement<T> Parse(string s, IFormatProvider? provider)
    {
        if(s == "Empty") return Empty;

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
        
        var separator = provider.GetNumberSetElementSeparator();

        var indexOfSeparator = numbersPart.IndexOf(separator);
        var lowerBoundString = numbersPart.Substring(0, indexOfSeparator).Trim();
        T? lowerBound;
        if (!T.TryParse(lowerBoundString, provider, out lowerBound))
            throw new ArgumentException("Unable to read lower bound of set");

        var upperBoundString = numbersPart.Substring(indexOfSeparator + 1, numbersPart.Length - (indexOfSeparator + 1)).Trim();
        T? upperBound;
        if (!T.TryParse(upperBoundString, provider, out upperBound))
            throw new ArgumentException("Unable to read lower bound of set");

        return NumberSetElement<T>.Create(lowerBound, upperBound, includeLowerBound, includeUpperBound);
    }

    /// <summary>
    /// Extracts a NumberSetElement from a string. The string is expected to be on the form (x, y) where x is lower bound and y is upper bound.
    /// Parenthesis are used to indicate if bounds are included. ( or ) means lower/upper bound is not included while [ or ] means lower/upper bound is included.
    /// Current culture is used for the parsing
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static NumberSetElement<T> Parse(string s)
    {
        return Parse(s, null);
    }

    /// <summary>
    /// Tries to extract a NumberSetElement from a string. The string is expected to be on the form (x, y) where x is lower bound and y is upper bound.
    /// Parenthesis are used to indicate if bounds are included. ( or ) means lower/upper bound is not included while [ or ] means lower/upper bound is included
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out NumberSetElement<T> result)
    {
        try
        {
            if (s == null)
                result = Empty;
            else
                result = NumberSetElement<T>.Parse(s, provider);
            return true;
        }
        catch 
        {
            result = null;
            return false; 
        }
    }

    /// <summary>
    /// Tries to extract a NumberSetElement from a string. The string is expected to be on the form (x, y) where x is lower bound and y is upper bound.
    /// Parenthesis are used to indicate if bounds are included. ( or ) means lower/upper bound is not included while [ or ] means lower/upper bound is included.
    /// Current culture is used for the parsing
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse([NotNullWhen(true)] string? s, [MaybeNullWhen(false)] out NumberSetElement<T> result)
    {
        try
        {
            if (s == null)
                result = Empty;
            else
                result = NumberSetElement<T>.Parse(s);

            return true;
        }
        catch
        {
            result = null;
            return false;
        }
    }

    // *********************** Deconstruct ***********************

    /// <summary>
    /// Deconstructs the set element into its bounds
    /// </summary>
    /// <param name="lowerbound"></param>
    /// <param name="upperbound"></param>
    public void Deconstruct(out T lowerbound, out T upperbound)
    {
        lowerbound = LowerBound;
        upperbound = UpperBound;
    }

    /// <summary>
    /// Deconstructs the set element into its bounds and if the bounds are included
    /// </summary>
    /// <param name="lowerbound"></param>
    /// <param name="upperbound"></param>
    /// <param name="includelowerbound"></param>
    /// <param name="includeupperbound"></param>
    public void Deconstruct(out T lowerbound, out T upperbound, out bool includelowerbound, out bool includeupperbound)
    {
        lowerbound = LowerBound;
        upperbound = UpperBound;
        includelowerbound = IncludeLowerBound;
        includeupperbound = IncludeUpperBound;
    }

    // *********************** Static members ***********************

    /// <summary>
    /// Returns the empty set
    /// </summary>
    public static NumberSetElement<T> Empty { get; }

    // *********************** Static constructor ***********************

    /// <summary>
    /// Creates an empty set for the Empty static property
    /// </summary>
    static NumberSetElement()
    {
        Empty = new NumberSetElement<T>();
    }

    // *********************** Static support methods ***********************

    /// <summary>
    /// Checks if point is double.NaN or float.NaN
    /// </summary>
    /// <param name="point"></param>
    /// <returns></returns>
    private static bool CheckIfNaN(T point)
    {
        var doublePoint = point as double?;
        if (doublePoint.HasValue && double.IsNaN(doublePoint.Value)) return true;

        var floatPoint = point as float?;
        if (floatPoint.HasValue && float.IsNaN(floatPoint.Value)) return true;

        return false;
    }

    /// <summary>
    /// Support method for NumberSetElement and NumberSet.
    /// It creates a NumberSetElement that is the set of points that belong to both INumberSetElement arguments.
    /// If there are no points in both arguments the empty set is returned
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    internal static INumberSetElement<T> CreateIntersection(INumberSetElement<T> left, INumberSetElement<T> right)
    {
        if (left.LowerBound > right.UpperBound || left.UpperBound < right.LowerBound) return Empty;
        if (left.LowerBound == right.UpperBound)
        {
            if (left.IncludeLowerBound && right.IncludeUpperBound)
                return Create(left.LowerBound, left.LowerBound, true, true);
            else
                return Empty;
        }
        if (left.UpperBound == right.LowerBound)
        {
            if (left.IncludeUpperBound && right.IncludeLowerBound)
                return Create(left.UpperBound, left.UpperBound, true, true);
            else
                return Empty;
        }
        var lowerBound = left.LowerBound > right.LowerBound ? left.LowerBound : right.LowerBound;
        var includeLowerBound = left.LowerBound ==  right.LowerBound ? (left.IncludeLowerBound && right.IncludeLowerBound) : (left.LowerBound > right.LowerBound ? left.IncludeLowerBound : right.IncludeLowerBound);
        var upperBound = left.UpperBound < right.UpperBound ? left.UpperBound : right.UpperBound;
        var includeUpperBound = left.UpperBound == right.UpperBound ? (left.IncludeUpperBound && right.IncludeUpperBound) : (left.UpperBound < right.UpperBound ? left.IncludeUpperBound : right.IncludeUpperBound);

        return Create(lowerBound, upperBound, includeLowerBound, includeUpperBound);
    }

    /// <summary>
    /// Support method for NumberSetElement and NumberSet.
    /// It creates a list of INumberSetElement that is the set of points that belong to the INumberSetElement argument but not the INumberSet argument.
    /// If there are no such points the empty set is returned as the only element in the list
    /// </summary>
    /// <param name="element"></param>
    /// <param name="numberSet"></param>
    /// <returns></returns>
    internal static List<INumberSetElement<T>> RemoveIntersections(INumberSetElement<T> element, INumberSet<T> numberSet)
    {
        var result = new List<INumberSetElement<T>>();
        var intersection = element.Intersection(numberSet);
        if (intersection.IsEmpty)
            result.Add(element);
        else if (intersection.Equals(element))
            result.Add(Empty);
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

    // *********************** Cast ***********************

    /// <summary>
    /// Provides an implicit cast from NumberSetElement to NumberSet
    /// </summary>
    /// <param name="element"></param>
    public static implicit operator NumberSet<T>(NumberSetElement<T>? element)
    {
        if (element == null) return NumberSet<T>.Empty;
        return NumberSet<T>.Create(element);
    }

    /// <summary>
    /// Provides an implicit cast from string to NumberSetElement
    /// </summary>
    /// <param name="element"></param>
    public static implicit operator NumberSetElement<T>(string? element)
    {
        if (element == null)
            return Empty;
        else
            return Parse(element);
    }

    /// <summary>
    /// Provides an implicit cast from T to NumberSetElement
    /// </summary>
    /// <param name="number"></param>
    public static implicit operator NumberSetElement<T>(T number)
    {
        return NumberSetElement<T>.Create(number, number, true, true);
    }

    // *********************** Operators ***********************

    /// <summary>
    /// Compares two NumberSetElements for equality
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(NumberSetElement<T>? left, NumberSetElement<T>? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    /// Compares two NumberSetElements for inequality
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(NumberSetElement<T>? left, NumberSetElement<T>? right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Compares a NumberSetElement to a NumberSet for equality
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(NumberSetElement<T>? left, NumberSet<T>? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    /// Compares a NumberSetElement to a NumberSet for inequality
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(NumberSetElement<T>? left, NumberSet<T>? right)
    {
        return !(left == right);
    }
}