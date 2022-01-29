using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator4.domain.validators
{
    class AngajatValidator : IValidator<Angajat>
    {
        public void Validate(Angajat e)
        {
            StringBuilder err = new StringBuilder();
            if (e.id.Length == 0)
                err.Append("id angajat invalid!\n");
            if (e.nume.Length == 0)
                err.Append("nume angajat invalid\n");
            if (e.prenume.Length == 0)
                err.Append("prenume angajat invalid\n");
            if (e.parola.Length == 0)
                err.Append("parola angajat invalid\n");
            if (err.Length > 0)
                throw new ValidationException(err.ToString());

        }
    }
}
