using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator4.domain.validators
{
    class BiletValidator : IValidator<Bilet>
    {
        public void Validate(Bilet e)
        {
            StringBuilder err = new StringBuilder();
            if (e.id <= 0)
                err.Append("id bilet invalid\n");
            if (e.numeClient.Length == 0)
                err.Append("nume client bilet invalid\n");
            if (e.numeTuristi.Length == 0)
                err.Append("nume turisti bilet invalid\n");
            if (e.adresaClient.Length == 0)
                err.Append("adresa client bilet invalida\n");
            if (e.nrLocuri <= 0)
                err.Append("nr locuri bilet invalid\n");
            if (e.zborId <= 0)
                err.Append("id zbor bilet invalid\n");
            if (err.Length > 0)
                throw new ValidationException(err.ToString());
        }
    }
}
