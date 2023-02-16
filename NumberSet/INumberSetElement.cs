using Utte.NumberSet;

namespace NumberSet
{
    public interface INumberSetElement<T> : IBoundedSet<T>, IEquatable<INumberSetElement<T>>, IEquatable<INumberSet<T>>
    {
        bool IncludeLowerBound { get; }
        bool IncludeUpperBound { get; }
    }
}
