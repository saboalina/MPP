using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2C.domain.validators
{
    public interface IValidator<E>
    {
        void Validate(E e);
    }
}
