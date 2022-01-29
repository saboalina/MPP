using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator3.domain.validators
{
    public interface IValidator<E>
    {
        void Validate(E e);
    }
}
