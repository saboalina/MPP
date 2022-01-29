using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator3.domain
{
    public class Zbor:Entity<int>
    {
        public String destinatie { get; set; } 
        public DateTime dataSiOraPlecarii { get; set; }
        public String aeroport { get; set; }
        public int nrLocuriDisponibile { get; set; }

        public Zbor(string destinatie, DateTime dataSiOraPlecarii, string aeroport, int nrLocuriDisponibile)
        {
            this.destinatie = destinatie;
            this.dataSiOraPlecarii = dataSiOraPlecarii;
            this.aeroport = aeroport;
            this.nrLocuriDisponibile = nrLocuriDisponibile;
        }

        public override string ToString()
        {
            return destinatie+" "+dataSiOraPlecarii+" "+aeroport+" "+nrLocuriDisponibile;
        }
    }
}
