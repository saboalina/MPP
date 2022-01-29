using fightagency;
using model;

namespace services
{
    public interface IObserver
    {
        void ticketAdded(Ticket ticket);
    }
}