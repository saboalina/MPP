using Laborator4.domain;
using Laborator4.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator4.service
{
    public class Service
    {

        AngajatDBRepository angajatRepo;
        ZboruriDBRepository zborRepo;
        BiletDBRepository biletRepo;

        public Service(AngajatDBRepository angajatRepo,
                            ZboruriDBRepository zborRepo,
                            BiletDBRepository biletRepo)
        {
            this.angajatRepo = angajatRepo;
            this.zborRepo = zborRepo;
            this.biletRepo = biletRepo;
        }
        public Angajat findOne(String username)
        {
            return angajatRepo.FindOne(username);
        }

        public IEnumerable<Zbor> findAllZboruri()
        {
            return zborRepo.FindAll();
        }

        public IEnumerable<Bilet> findAllBilete()
        {
            return biletRepo.FindAll();
        }

        public IEnumerable<Angajat> findAllAngajati()
        {
            return angajatRepo.FindAll();
        }

        public void addBilet(Bilet bilet)
        {
            biletRepo.Save(bilet);
            Zbor zbor = zborRepo.findOne(bilet.zborId);
            zbor.nrLocuriDisponibile=zbor.nrLocuriDisponibile - bilet.nrLocuri;
            zborRepo.Update(zbor);
        }



        public Angajat getAngajat(String username, String parola)
        {
            Angajat a = null;
            IEnumerable<Angajat> angajati = findAllAngajati();
            angajati.ToList().ForEach(
                x =>
                {
                    if (x.id.Equals(username) && x.parola.Equals(parola))
                        a = x;
                });
            return a;
        }

        public IEnumerable<Zbor> FilterByDestinatie(String aeroport, DateTime data)
        {
            
            return zborRepo.FilterByDestinatie(aeroport, data);
        }

    }
}
