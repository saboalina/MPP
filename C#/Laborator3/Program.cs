using Laborator4.domain;
using Laborator4.repository;
using Laborator4.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laborator4
{
    static class Program
    {
        [STAThread]
        static void Main()
        {

            AngajatDBRepository angajatRepo = new AngajatDBRepository();
            ZboruriDBRepository zborRepo = new ZboruriDBRepository();
            BiletDBRepository biletRepo = new BiletDBRepository();

            Service service = new Service(angajatRepo, zborRepo, biletRepo);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogInPage(service));
        }
    }
}
