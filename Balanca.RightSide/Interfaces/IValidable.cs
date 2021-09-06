using System;
using System.Collections.Generic;
using System.Text;

namespace Balanca.RightSide
{
    public interface IValidable<T>
    {
        void Validate(T value);
    }
}
