using Lab2C.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2C.repository
{
    interface IRepository<ID, E> where E : Entity<ID>
    {
        E FindOne(ID id);
        IEnumerable<E> FindAll();
        E Save(E entity);
    }
}
