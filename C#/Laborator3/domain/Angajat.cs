using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator4.domain
{
    public class Angajat:Entity<String>
    {
        public String nume { get; set; }
        public String prenume { get; set; }
        public String parola { get; set; }

        public Angajat(string nume, string prenume, string parola)
        {
            this.nume = nume;
            this.prenume = prenume;
            this.parola = parola;
        }

        public Angajat()
        {
        }

        public override string ToString()
        {
            return nume+" "+prenume;
        }
    }
}
