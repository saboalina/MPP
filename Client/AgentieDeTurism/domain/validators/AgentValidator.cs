using System;
using System.Text;
using Microsoft.VisualBasic;

namespace model.validators
{
    public class AgentValidator : IValidator<Agent>
    {
        public void Validate(Agent e)
        {
            StringBuilder err = new StringBuilder();
            if (e.ID <= 0)
                err.Append("Id trebuie sa fie pozitiv!\n");
            if (e.Username.Length == 0)
                err.Append("Username nu poate fi gol!\n");
            if (e.Password.Length < 5)
                err.Append("Password trebuie sa contina cel putin 5 caractere!\n");
            if (err.Length > 0)
                throw new ValidationException(err.ToString());
        }
    }
}