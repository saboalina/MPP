using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2C.domain
{
    class Zbor:Entity<int>
    {
        public String destinatie { get; set; } 
        public String dataSiOraPlecarii { get; set; }
        public String aeroport { get; set; }
        public int nrLocuriDisponibile { get; set; }

        public override string ToString()
        {
            return destinatie+" "+dataSiOraPlecarii+" "+aeroport+" "+nrLocuriDisponibile;
        }
    }
}
