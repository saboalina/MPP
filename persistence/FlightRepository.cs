using System;
using System.Collections.Generic;
using model;

namespace persistence
{
    public interface IExcursieRepository : IRepository<int, Flight>
    {
        List<Flight> FindByNameAndTime(String name);

        void update(int id, int nrLocuri);
    }
}