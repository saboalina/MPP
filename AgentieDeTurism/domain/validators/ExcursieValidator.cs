using System.Text;

namespace model.validators
{
    public class ExcursieValidator : IValidator<Excursie>
    {
        public void Validate(Excursie e)
        {
            StringBuilder err = new StringBuilder();
            if(e.Firma.Length == 0)
                err.Append("Firma nu poate fi gol!\n");
            if(e.ObiectivTuristic.Length == 0)
                err.Append("Obiectiv turistic nu poate fi gol!\n");
            if(e.NrLocuri < 1)
                err.Append("Trebuie sa rezervati cel putin 1 loc!\n");
            if(e.Pret < 0)
                err.Append("Pretul trebuie sa fie pozitiv!\n");
            if (err.Length > 0)
                throw new ValidationException(err.ToString());
        }
    }
}