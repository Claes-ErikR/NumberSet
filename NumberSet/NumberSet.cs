﻿using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Text;
using Utte.NumberSet.Extensions;

namespace Utte.NumberSet;

/// <summary>
/// Implementation of a set using NumberSetElement as parts.
/// Every INumberSetElement in the collection is disjunct and sorted in order.
/// T has to implement IAdditionOperators&lt;T, T, T&gt;, ISubtractionOperators&lt;T, T, T&gt;, IComparisonOperators&lt;T, T, bool&gt;, IParsable&lt;T&gt;
/// The Empty set is considered part of any set but only equal to itself
/// A NumberSet can only be created through static Create/CreateEmpty methods
/// An explicit cast to NumberSetElement exists using the first element in NumberSet as the new NumberSetElement
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed class NumberSet<T> : INumberSet<T>, IParsable<NumberSet<T>>, IEqualityOperators<NumberSet<T>, NumberSetElement<T>, bool>, IEqualityOperators<NumberSet<T>, NumberSet<T>, bool>, IFormattable where T : IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>, IComparisonOperators<T, T, bool>, IParsable<T>, IFormattable
{

    // *********************** Private members ***********************

    private readonly List<INumberSetElement<T>> _elements;

    // *********************** Constructors ***********************
    
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
    /// Data are set from NumberSetElement&lt;T&gt;.Empty
    /// </summary>
    private NumberSet()
    {
        _elements = new List<INumberSetElement<T>>() { NumberSetElement<T>.Empty };
        LowerBound = _elements[0].LowerBound;
        UpperBound = _elements[_elements.Count - 1].UpperBound;
        IsClosed = _elements[0].IncludeUpperBound;
        IsOpen = _elements[0].IsOpen;
        IsEmpty = true;
        Measure = _elements[0].Measure;
        Count = 1;
    }

    // *********************** Create methods ***********************

    /// <summary>
    /// Creates a NumberSet from an arbitrary number of INumberSetElement arguments.
    /// Overlapping/touching elements are joined.
    /// Empty elements are ignored.
    /// If only empty arguments are supplied, an empty set is created.
    /// The added elements are sorted.
    /// </summary>
    /// <param name="elements"></param>
    /// <returns></returns>
    public static NumberSet<T> Create(params INumberSetElement<T>?[] elements)
    {
        return CreateNumberSet(elements);
    }

    /// <summary>
    /// Creates a NumberSet from a list of INumberSetElement.
    /// Overlapping/touching elements are joined.
    /// Empty and null elements are ignored.
    /// If only empty arguments/an empty list/null are supplied, an empty set is created.
    /// The added elements are sorted.
    /// </summary>
    /// <param name="elements"></param>
    /// <returns></returns>
    public static NumberSet<T> Create(IEnumerable<INumberSetElement<T>?> elements)
    {
        return CreateNumberSet(elements);
    }

    /// <summary>
    /// Creates a NumberSet from a list of INumberSetElement.
    /// Overlapping/touching elements are joined.
    /// Empty and null elements are ignored.
    /// If only empty arguments/an empty list/null are supplied, an empty set is created.
    /// The added elements are sorted.
    /// </summary>
    /// <param name="elements"></param>
    /// <returns></returns>
    private static NumberSet<T> CreateNumberSet(IEnumerable<INumberSetElement<T>?> elements) 
    {
        if(elements == null) return Empty;
        List<INumberSetElement<T>> workListElements = new List<INumberSetElement<T>>();
        foreach (var element in elements)
            Add(workListElements, element);

        if (workListElements.Count == 0) return Empty;

        var isClosed = true;
        var isOpen = true;
        T measure = Empty.Measure;
        foreach (var element in workListElements)
        {
            isClosed = isClosed && element.IsClosed;
            isOpen = isOpen && element.IsOpen;
            measure = measure == null ? element.Measure : measure + element.Measure;
        }

        return new NumberSet<T>(workListElements, isClosed, isOpen, measure);
    }

    // *********************** Properties ***********************
    
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
    /// Indicates if the set is the empty set
    /// </summary>
    public bool IsEmpty { get; }

    /// <summary>
    /// Returns the measure of the set, the measure of a NumberSet is the sum of the measure of all its elements
    /// </summary>
    public T Measure { get; }

    /// <summary>
    /// Returns the number of elements in the set
    /// </summary>
    public int Count { get; }

    // *********************** Methods ***********************

    // Union

    /// <summary>
    /// Returns an INumberSet containing all points in at least one of the set and an IBoundedSet
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
    /// Returns an INumberSet containing all points in at least one of the set and an INumberSet set
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    private INumberSet<T> Union(INumberSet<T> other)
    {
        var elements = new List<INumberSetElement<T>>();
        for (var i = 0; i < Count; i++)
            elements.Add(this[i]);
        for (var i = 0; i < other.Count; i++)
            elements.Add(other[i]);

        return NumberSet<T>.Create(elements);
    }

    /// <summary>
    /// Returns an INumberSet containing all points in at least one of the set and an INumberSetElement set
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    private INumberSet<T> Union(INumberSetElement<T> other)
    {
        return other.Union(this);
    }

    // Intersection

    /// <summary>
    /// Returns an INumberSet containing all points in both of the set and an IBoundedSet
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
    /// Returns an INumberSet containing all points in both of the set and an INumberSet set
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    private INumberSet<T> Intersection(INumberSet<T> other)
    {
        var elements = new List<INumberSetElement<T>>();
        for (var i = 0; i < Count; i++)
            for (var j = 0; j < other.Count; j++)
            {
                var intersection = NumberSetElement<T>.CreateIntersection(this[i], other[j]);
                elements.Add(intersection);
            }
        return NumberSet<T>.Create(elements);
    }

    /// <summary>
    /// Returns an INumberSet containing all points in both of the set and an INumberSetElement set
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    private INumberSet<T> Intersection(INumberSetElement<T> other)
    {
        var elements = new List<INumberSetElement<T>>();
        for (var i = 0; i < Count; i++)
        {
            var intersection = NumberSetElement<T>.CreateIntersection(this[i], other);
            elements.Add(intersection);
        }
        return NumberSet<T>.Create(elements);
    }

    // Intersects

    /// <summary>
    /// Checks if the set shares any part with an IBoundedSet
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
    /// Checks if the set shares any part with an INumberSet
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    private bool Intersects(INumberSet<T> other)
    {
        if (IsEmpty || other.IsEmpty) return true;
        for (int i = 0; i < Count; i++)
            if (this[i].Intersects(other))
                return true;

        return false;
    }

    /// <summary>
    /// Checks if the set shares any part with an INumberSetElement
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    private bool Intersects(INumberSetElement<T> other)
    {
        if (IsEmpty || other.IsEmpty) return true;
        for (int i = 0; i < Count; i++)
            if (!NumberSetElement<T>.CreateIntersection(this[i], other).IsEmpty)
                return true;

        return false;
    }

    // Difference

    /// <summary>
    /// Returns an INumberSet containing all points in the set that is not in an IBoundedSet
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
    /// Returns an INumberSet containing all points in the set that is not in an INumberSet set
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    private INumberSet<T> Difference(INumberSet<T> other)
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
    /// Returns an INumberSet containing all points in the set that is not in an INumberSetElement set
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    private INumberSet<T> Difference(INumberSetElement<T> other)
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
    /// Checks if the point other is within the set
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
    /// Checks if the whole of an IBoundedSet is within the set
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
    /// Checks if the whole of an INumberSet is within the set
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    private bool Contains(INumberSet<T> other)
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
    /// Checks if the whole of an INumberSetElement is within the set
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    private bool Contains(INumberSetElement<T> other)
    {
        if (IsEmpty) return other.IsEmpty;
        if (other.IsEmpty) return true;
        for (int i = 0; i < Count; i++)
            if (_elements[i].Contains(other))
                return true;

        return false;
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
    /// Creates a string representation of the instance on the form (x, y); [z, w] ... x/z is lower bound and y/w is upper bound.
    /// Parenthesis are used to indicate if bounds are included. ( or ) means lower/upper bound is not included while
    /// [ or ] means lower/upper bound is included. Each element in the instance is represented by one pair of numbers
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return ToString(null, null);
    }

    /// <summary>
    /// Creates a string representation of the instance on the form (x, y); [z, w] ... x/z is lower bound and y/w is upper bound.
    /// Parenthesis are used to indicate if bounds are included. ( or ) means lower/upper bound is not included while
    /// [ or ] means lower/upper bound is included. Each element in the instance is represented by one pair of numbers. For cultures
    /// with comma separator in numbers, a ; is used in each element instead of , i.e. (x; y) instead of (x, y)
    /// </summary>
    /// <param name="format"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public string ToString(string? format, IFormatProvider? provider)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(((NumberSetElement<T>)_elements[0]).ToString(format, provider));
        for (int i = 1; i < _elements.Count; i++)
        {
            sb.Append("; ");
            sb.Append(((NumberSetElement<T>)_elements[i]).ToString(format, provider));
        }

        return sb.ToString();
    }

    // *********************** Parse ***********************

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
        if (s == "Empty") return (NumberSet<T>)NumberSet<T>.Empty;

        var trimmedString = s.Trim();
        string[] parts = trimmedString.Split(';');

        var elements = new List<INumberSetElement<T>>();
        if (provider.GetNumberSetElementSeparator() != ';')
        {
            foreach (var part in parts)
            {
                if (NumberSetElement<T>.TryParse(part, provider, out NumberSetElement<T>? element))
                {
                    if (!element.IsEmpty)
                        elements.Add(element);
                }
                else
                {
                    throw new ArgumentException("Could not parse element " + part);
                }
            }
        }
        else
        {
            for(int i = 0; i <  parts.Length; i += 2)
            {
                var part = parts[i] + ";" + parts[i + 1];
                if (NumberSetElement<T>.TryParse(part, provider, out NumberSetElement<T>? element))
                {
                    if (!element.IsEmpty)
                        elements.Add(element);
                }
                else
                {
                    throw new ArgumentException("Could not parse element " + part);
                }
            }
        }

        return NumberSet<T>.Create(elements);
    }

    /// <summary>
    /// Extracts a NumberSet from a string. The string is expected to be on the form (x, y); [z, w] ... where x/z is lower bound and y/w is upper bound.
    /// Parenthesis are used to indicate if bounds are included. ( or ) means lower/upper bound is not included while [ or ] means lower/upper bound is included.
    /// Each element in the instance produces one pair of numbers. Current culture is used for the parsing
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static NumberSet<T> Parse(string s)
    {
        return Parse(s, null);
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
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out NumberSet<T> result)
    {
        try
        {
            if (s == null)
                result = (NumberSet<T>)Empty;
            else
                result = NumberSet<T>.Parse(s, provider);
            return true;
        }
        catch
        {
            result = null;
            return false;
        }
    }

    /// <summary>
    /// Tries to extract a NumberSet from a string. The string is expected to be on the form (x, y); [z, w] ... where x/z is lower bound and y/w is upper bound.
    /// Parenthesis are used to indicate if bounds are included. ( or ) means lower/upper bound is not included while [ or ] means lower/upper bound is included.
    /// Each element in the instance produces one pair of numbers. Current culture is used for the parsing
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse([NotNullWhen(true)] string? s, [MaybeNullWhen(false)] out NumberSet<T> result)
    {
        try
        {
            if (s == null)
                result = (NumberSet<T>)Empty;
            else
                result = NumberSet<T>.Parse(s);
            return true;
        }
        catch
        {
            result = null;
            return false;
        }
    }

    // *********************** Enumerator ***********************
    
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

    // *********************** Static members ***********************

    /// <summary>
    /// Returns the empty set
    /// </summary>
    public static NumberSet<T> Empty { get; }

    // *********************** Static constructor ***********************

    /// <summary>
    /// Creates an empty set for the Empty static property
    /// </summary>
    static NumberSet()
    {
        Empty = new NumberSet<T>();
    }

    // *********************** Static support methods ***********************

    /// <summary>
    /// Adds element to workListElements.
    /// If element is overlapping/touching any elements they are joined.
    /// If element is empty it is ignored.
    /// The added element is added in sorted order.
    /// </summary>
    /// <param name="workListElements"></param>
    /// <param name="element"></param>
    private static void Add(List<INumberSetElement<T>> workListElements, INumberSetElement<T>? element)
    {
        if (element != null && !element.IsEmpty)
        {
            var newElement = element;
            int index = 0;
            while (index < workListElements.Count)
            {
                var connectedUnion = CreateConnectedUnion(newElement, workListElements[index]);
                if (!connectedUnion.IsEmpty)
                {
                    newElement = connectedUnion;
                    workListElements.RemoveAt(index);
                }
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
            if (insertIndex == int.MinValue)
                workListElements.Add(newElement);
            else
                workListElements.Insert(insertIndex, newElement);
        }
    }

    /// <summary>
    /// Support method for NumberSet.
    /// It creates a NumberSetElement that is the set of points that belong to at least one of the INumberSetElement arguments.
    /// If the two arguments are disjunkt the empty set is returned
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    private static INumberSetElement<T> CreateConnectedUnion(INumberSetElement<T> left, INumberSetElement<T> right)
    {
        if (left.LowerBound > right.UpperBound || left.UpperBound < right.LowerBound) return NumberSetElement<T>.Empty;

        if (left.LowerBound == right.UpperBound && !left.IncludeLowerBound && !right.IncludeUpperBound) return NumberSetElement<T>.Empty;

        if (left.UpperBound == right.LowerBound && !left.IncludeUpperBound && !right.IncludeLowerBound) return NumberSetElement<T>.Empty;

        var lowerBound = left.LowerBound < right.LowerBound ? left.LowerBound : right.LowerBound;
        var includeLowerBound = left.LowerBound == right.LowerBound ? (left.IncludeLowerBound || right.IncludeLowerBound) : (left.LowerBound < right.LowerBound ? left.IncludeLowerBound : right.IncludeLowerBound);
        var upperBound = left.UpperBound > right.UpperBound ? left.UpperBound : right.UpperBound;
        var includeUpperBound = left.UpperBound == right.UpperBound ? (left.IncludeUpperBound || right.IncludeUpperBound) : (left.UpperBound > right.UpperBound ? left.IncludeUpperBound : right.IncludeUpperBound);

        return NumberSetElement<T>.Create(lowerBound, upperBound, includeLowerBound, includeUpperBound);
    }

    // *********************** Cast ***********************

    /// <summary>
    /// Provides an explicit cast from NumberSet to NumberSet Element
    /// </summary>
    /// <param name="numberSet"></param>
    public static explicit operator NumberSetElement<T>(NumberSet<T>? numberSet)
    {
        if (numberSet == null) return NumberSetElement<T>.Empty;
        return (NumberSetElement<T>)numberSet[0];
    }

    /// <summary>
    /// Provides an implicit cast from string to NumberSet
    /// </summary>
    /// <param name="numberSetString"></param>
    public static implicit operator NumberSet<T>(string? numberSetString)
    {
        if (numberSetString == null)
            return Empty;
        else
            return Parse(numberSetString);
    }

    /// <summary>
    /// Provides an implicit cast from T to NumberSet
    /// </summary>
    /// <param name="number"></param>
    public static implicit operator NumberSet<T>(T number)
    {
        return NumberSet<T>.Create(NumberSetElement<T>.Create(number, number, true, true));
    }

    // *********************** Operators ***********************

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
}
