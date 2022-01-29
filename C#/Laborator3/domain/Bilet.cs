using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator3.domain
{
    public class Bilet:Entity<int>
    {
        public String numeClient { get; set; }
        public String numeTuristi { get; set; }
        public String adresaClient { get; set; }
        public int nrLocuri { get; set; }
        public int zborId { get; set; }

        public Bilet(string numeClient, string numeTuristi, string adresaClient, int nrLocuri, int zborId)
        {
            this.numeClient = numeClient;
            this.numeTuristi = numeTuristi;
            this.adresaClient = adresaClient;
            this.nrLocuri = nrLocuri;
            this.zborId = zborId;
        }

        public override string ToString()
        {
            return id + " " + numeClient + " " + numeTuristi + " " + adresaClient + " " + nrLocuri + " " + zborId;
        }
    }
}
