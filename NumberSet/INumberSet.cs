using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utte.NumberSet;

namespace NumberSet
{
    public interface INumberSet<T> : IBoundedSet<T>, IReadOnlyList<INumberSetElement<T>>, IEquatable<INumberSet<T>>
    {

    }
}
