using System;
using System.Collections.Generic;
using fightagency;
using model;

namespace persistence
{
    public interface FlightRepository : Repository<int, Flight>
    {
        List<Flight> FindByNameAndTime(String name);

        void update(int id, int availableSeats);
    }
}