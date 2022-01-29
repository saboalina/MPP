using System;

namespace model
{
    public class Rezervare : Entity<int>
    {
        public String NumeClient { get; set; }
        public String NrTelefon { get; set; }
        public int NrBilete { get; set; }
        
        public Excursie Excursie { get; set; }

        public override string ToString()
        {
            return ID + ";" + NumeClient + ";" + NrTelefon + ";" + NrBilete + ";" + Excursie.ToString();
        }
    }
}