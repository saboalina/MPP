using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2C.domain
{
    class Angajat:Entity<String>
    {
        public String Nume { get; set; }
        public String Prenume { get; set; }
        public String Parola { get; set; }

        public override string ToString()
        {
            return Nume+" "+Prenume;
        }
    }
}
