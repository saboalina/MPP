using System.Collections.Generic;
using fightagency;
using flightagency;

namespace client
{
    public class MainWindowControllerImpl: MainWindowController.Iface
    {
        private Controller ctrl;
        public MainWindowControllerImpl(Controller ctrl)
        {
            this.ctrl = ctrl;
        }
        public void update(List<Flight> flights)
        {
            ctrl.ticketAdded(flights);
        }
        
    }
}