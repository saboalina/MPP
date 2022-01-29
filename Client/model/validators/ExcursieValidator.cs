using System.Text;
using fightagency;

namespace model.validators
{
    public class ExcursieValidator : IValidator<Flight>
    {
        public void Validate(Flight e)
        {
            StringBuilder err = new StringBuilder();
            if(e.Airport.Length == 0)
                err.Append("Firma nu poate fi gol!\n");
            if(e.Destination.Length == 0)
                err.Append("Obiectiv turistic nu poate fi gol!\n");
            if(e.AvailableSeats < 1)
                err.Append("Trebuie sa rezervati cel putin 1 loc!\n");
            // if(e.Price < 0)
            //     err.Append("Pretul trebuie sa fie pozitiv!\n");
            if (err.Length > 0)
                throw new ValidationException(err.ToString());
        }
    }
}