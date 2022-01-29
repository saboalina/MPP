using System.Collections.Generic;
using model;

namespace persistence
{
    public interface IRepository<ID, TE> where TE : Entity<ID>
    {
        TE FindOne(ID id);
        IEnumerable<TE> FindAll();
        void Save(TE entity);
    }
}