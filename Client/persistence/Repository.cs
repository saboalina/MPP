using System.Collections.Generic;
using model;

namespace persistence
{
    public interface Repository<ID, TE>
    {
        TE FindOne(ID id);
        IEnumerable<TE> FindAll();
        void Save(TE entity);
    }
}