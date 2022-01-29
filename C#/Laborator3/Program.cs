using Laborator3.domain;
using Laborator3.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laborator3
{
    static class Program
    {
        [STAThread]
        static void Main()
        {

            //log4net.Config.XmlConfigurator.Configure();

            AngajatDBRepository repoEmployee = new AngajatDBRepository();
            ZboruriDBRepository repoFLights = new ZboruriDBRepository();
            BiletDBRepository repoTickets = new BiletDBRepository();

            Angajat angajat = new Angajat("numeAngajat100", "prenumeAngajat100","parola100");
            angajat.id = "100";
            repoEmployee.Save(angajat);

            Zbor zbor = new Zbor("destinatie100", DateTime.Now, "aeroport100", 100);
            zbor.id = 100;
            repoFLights.Save(zbor);

            Bilet bilet = new Bilet("numeClient100", "numeTuristi100", "adresaClient100", 100, 100);
            bilet.id = 100;
            repoTickets.Save(bilet);

            // Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form1());
        }
    }
}
