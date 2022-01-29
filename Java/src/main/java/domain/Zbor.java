package domain;

import java.time.LocalDate;

public class Zbor extends Entity<Integer>{
    private String destinatie;
    private LocalDate dataSiOraPlecarii;
    //private Local dataSiOraPlecarii;
    private String aeroport;
    private Integer nrLocuriDisponibile;


    public Zbor(String destinatie, LocalDate dataSiOraPlecarii, String aeroport, Integer nrLocuriDisponibile) {
        this.destinatie = destinatie;
        this.dataSiOraPlecarii = dataSiOraPlecarii;
        this.aeroport = aeroport;
        this.nrLocuriDisponibile = nrLocuriDisponibile;
    }

    public String getDestinatie() {
        return destinatie;
    }

    public LocalDate getDataSiOraPlecarii() {
        return dataSiOraPlecarii;
    }

    public String getDataSiOraPlecariiString(){
        return ""+dataSiOraPlecarii;
    }

    public String getAeroport() {
        return aeroport;
    }

    public Integer getNrLocuriDisponibile() {
        return nrLocuriDisponibile;
    }

    public String getNrLocuriDisponibileString(){
        return ""+nrLocuriDisponibile;
    }

    public void setNrLocuriDisponibile(Integer nrLocuriDisponibile) {
        this.nrLocuriDisponibile = nrLocuriDisponibile;
    }

    @Override
    public String toString() {
        return "Zbor{" +
                "destinatie='" + destinatie + '\'' +
                ", dataSiOraPlecarii=" + dataSiOraPlecarii +
                ", aeroport='" + aeroport + '\'' +
                ", nrLocuriDisponibile=" + nrLocuriDisponibile +
                '}';
    }


}
