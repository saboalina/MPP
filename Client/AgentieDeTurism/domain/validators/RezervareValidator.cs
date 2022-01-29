using System.Text;
using System.Text.RegularExpressions;

namespace model.validators
{
    public class RezervareValidator : IValidator<Rezervare>
    {
        public void Validate(Rezervare e)
        {
            StringBuilder err = new StringBuilder();
            if (e.NrBilete < 1)
                err.Append("Trebuie sa rezervati cel putin un bilet!\n");
            if (e.NrTelefon.Length < 10)
                err.Append("Numar de telefon invalid!\n");
            if (e.NumeClient.Length == 0)
                err.Append("Nume Client invalid!\n");
            if (err.Length > 0)
                throw new ValidationException(err.ToString());
        }
    }
}