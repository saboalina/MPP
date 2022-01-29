using Laborator4.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator4.repository
{
    interface IRepository<ID, E> where E : Entity<ID>
    {
        IEnumerable<E> FindAll();

        E Save(E entity);

        E Update(E entity);
    }
}
