using Laborator3.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator3.repository
{
    interface IRepository<ID, E> where E : Entity<ID>
    {
        IEnumerable<E> FindAll();

        E Save(E entity);

        E Update(E entity);
    }
}
