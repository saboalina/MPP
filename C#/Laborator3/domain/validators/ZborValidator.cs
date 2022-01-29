using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator3.domain.validators
{
    class ZborValidator : IValidator<Zbor>
    {
        public void Validate(Zbor e)
        {
            StringBuilder err = new StringBuilder();
            if (e.id <= 0)
                err.Append("id zbor invalid\n");
            if (e.destinatie.Length == 0)
                err.Append("destinatie zbor invalida\n");
            if (e.aeroport.Length == 0)
                err.Append("aeroport zbor invalid\n");
            if (e.nrLocuriDisponibile <=0)
                err.Append("nr locuri zbor invalid\n");
            if (err.Length > 0)
                throw new ValidationException(err.ToString());
        }
    }
}
