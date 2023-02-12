﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Utte.NumberSet;

namespace NumberSet
{
    public interface INumberSetElement<T> : IBoundedSet<T>, IEquatable<INumberSetElement<T>>
    {
        bool IncludeLowerBound { get; }
        bool IncludeUpperBound { get; }
    }
}
