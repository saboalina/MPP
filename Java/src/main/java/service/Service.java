package service;

import domain.Angajat;
import domain.Bilet;
import domain.Zbor;
import repository.AngajatDBRepository;
import repository.BiletDBRepository;
import repository.ZborDBRepository;

import java.time.LocalDate;
import java.util.List;

public class Service {

    private AngajatDBRepository angajatDBRepository;
    private ZborDBRepository zborDBRepository;
    private BiletDBRepository biletDBRepository;

    public Service(AngajatDBRepository angajatDBRepository, ZborDBRepository zborDBRepository, BiletDBRepository biletDBRepository) {
        this.angajatDBRepository = angajatDBRepository;
        this.zborDBRepository = zborDBRepository;
        this.biletDBRepository = biletDBRepository;
    }

    public Angajat findOne(String username){
        return angajatDBRepository.findOne(username);
    }

    public Iterable<Angajat> findAll() {
        return angajatDBRepository.findAll();
    }

    public Angajat getAngajat(String username, String parola) {
        for (Angajat a:findAll())
            if(a.getId().equals(username) && a.getParola().equals(parola))
                return a;
        return null;
    }

    public Iterable<Zbor> getAllZboruri() {
        return zborDBRepository.findAll();
    }

    public Iterable<Bilet> getAllBilete() {
        return biletDBRepository.findAll();
    }

    public void addBilet(Bilet bilet){
        biletDBRepository.save(bilet);
        Zbor zbor=zborDBRepository.findOne(bilet.getZborId());
        zbor.setNrLocuriDisponibile(zbor.getNrLocuriDisponibile()-bilet.getNrLocuri());
        zborDBRepository.update(zbor);
    }

    public List<Zbor> filterByAeroport(String aeroport, LocalDate data){
        return zborDBRepository.filterByAeroport(aeroport, data);
    }
}
