using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2C.domain.validators
{
    class AngajatValidator : IValidator<Angajat>
    {
        public void Validate(Angajat e)
        {
            StringBuilder err = new StringBuilder();
            if (e.ID.Length == 0)
                err.Append("id angajat invalid!\n");
            if (e.Nume.Length == 0)
                err.Append("nume angajat invalid\n");
            if (e.Prenume.Length == 0)
                err.Append("prenume angajat invalid\n");
            if (e.Parola.Length == 0)
                err.Append("parola angajat invalid\n");
            if (err.Length > 0)
                throw new ValidationException(err.ToString());

        }
    }
}
