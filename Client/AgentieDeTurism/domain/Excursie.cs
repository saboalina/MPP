using System;

namespace model
{
    public class Excursie : Entity<int>
    {
        public String ObiectivTuristic { get; set; }
        public String Firma { get; set; }
        public DateTime Ora { get; set; }
        public float Pret { get; set; }
        public int NrLocuri { get; set; }

        public override string ToString()
        {
            return ID + ";" + ObiectivTuristic + ";" + Firma + ";" + Ora + ";" + Pret + ";" + NrLocuri;
        }
    }
}