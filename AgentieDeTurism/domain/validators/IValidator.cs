﻿namespace model.validators
{
    public interface IValidator<E>
    {
        void Validate(E e);
    }
}