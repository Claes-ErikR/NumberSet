using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utte.NumberSet;

namespace NumberSet
{
    interface INumberSetElement<T> : IBoundedSet<T>
    {
        bool IncludeLowerBound { get; }
        bool IncludeUpperBound { get; }
    }
}
