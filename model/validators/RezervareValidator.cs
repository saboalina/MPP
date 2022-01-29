using System.Text;
using System.Text.RegularExpressions;

namespace model.validators
{
    public class RezervareValidator : IValidator<Ticket>
    {
        public void Validate(Ticket e)
        {
            StringBuilder err = new StringBuilder();
            if (e.NoSeats < 1)
                err.Append("You need to book at least a seat!\n");
            if (e.TouristsName.Length < 1)
                err.Append("Invalid phone number!\n");
            if (e.ClientName.Length == 0)
                err.Append("Invalid Name!\n");
            if (err.Length > 0)
                throw new ValidationException(err.ToString());
        }
    }
}