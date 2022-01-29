using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2C.domain
{
    class Bilet:Entity<int>
    {
        public String numeClient { get; set; }
        public String numeTuristi { get; set; }
        public String adresaClient { get; set; }
        public int nrLocuri { get; set; }
        public int zborId { get; set; }

        public override string ToString()
        {
            return ID + " " + numeClient + " " + numeTuristi + " " + adresaClient + " " + nrLocuri + " " + zborId;
        }
    }
}
