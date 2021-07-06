package domain;

import java.time.LocalDateTime;

public class Zbor extends Entity<Integer>{
    private String destinatie;
    private LocalDateTime dataSiOraPlecarii;
    private String aeroport;
    private Integer nrLocuriDisponibile;

    public Zbor(String destinatie, LocalDateTime dataSiOraPlecarii, String aeroport, Integer nrLocuriDisponibile) {
        this.destinatie = destinatie;
        this.dataSiOraPlecarii = dataSiOraPlecarii;
        this.aeroport = aeroport;
        this.nrLocuriDisponibile = nrLocuriDisponibile;
    }

    public String getDestinatie() {
        return destinatie;
    }

    public LocalDateTime getDataSiOraPlecarii() {
        return dataSiOraPlecarii;
    }

    public String getAeroport() {
        return aeroport;
    }

    public Integer getNrLocuriDisponibile() {
        return nrLocuriDisponibile;
    }
}
