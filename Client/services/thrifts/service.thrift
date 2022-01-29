namespace java flightagency
namespace csharp flightagency

struct Employee{
    1:string username,
    2:string password,
    3:string name
}
struct Flight{
    1:i32 id,
    2:string destination,
    3:string departureDate,
    4:string departureTime,
    5:string airport,
    6:i32 availableSeats,

}
struct Ticket{
    1:i32 id,
    2:string clientName,
    3:string touristsName,
    4:string clientAddress,
    5:i32 noSeats,
    6:i32 flightId,
}

service IService
{
    Employee findOne(1: string username),

    list<Employee> findAll(),

    Employee getEmployee(1:string username, 2:string password),

    list<Flight> getAllFlights(),

    list<Ticket> getAllTickets(),

    list<Flight> filter(1:string airport, 2:string departureDate),

    void login(1:Employee employee),

    void logout(1:i32 port),

    void addTicket(1:Ticket ticket),

    void addObserver(1:i32 port),

    void removeObserver(1: i32 port),

    void notifyServer()
}

service MainWindowController{
    void update(1:list<Flight> flights)
}