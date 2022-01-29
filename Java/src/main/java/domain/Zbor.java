package domain;
import java.sql.Date;

public class Zbor extends Entity<Integer>{
    private String destinatie;
    private Date dataSiOraPlecarii;
    private String aeroport;
    private Integer nrLocuriDisponibile;

    public Zbor(String destinatie, Date dataSiOraPlecarii, String aeroport, Integer nrLocuriDisponibile) {
        this.destinatie = destinatie;
        this.dataSiOraPlecarii = dataSiOraPlecarii;
        this.aeroport = aeroport;
        this.nrLocuriDisponibile = nrLocuriDisponibile;
    }

    public String getDestinatie() {
        return destinatie;
    }

    public Date getDataSiOraPlecarii() {
        return dataSiOraPlecarii;
    }

    public String getAeroport() {
        return aeroport;
    }

    public Integer getNrLocuriDisponibile() {
        return nrLocuriDisponibile;
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
