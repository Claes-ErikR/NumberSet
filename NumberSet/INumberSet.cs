using Utte.NumberSet;

namespace NumberSet
{
    public interface INumberSet<T> : IBoundedSet<T>, IReadOnlyList<INumberSetElement<T>>, IEquatable<INumberSetElement<T>>, IEquatable<INumberSet<T>>
    {

    }
}
