package domain;

public class Bilet extends Entity<Integer>{

    private String numeClient;
    private String numeTuristi;
    private String adresaClient;
    private Integer nrLocuri;
    private Integer zborId;

    public Bilet(String numeClient, String numeTuristi, String adresaClient, Integer nrLocuri, Integer zborId) {
        this.numeClient = numeClient;
        this.numeTuristi = numeTuristi;
        this.adresaClient = adresaClient;
        this.nrLocuri = nrLocuri;
        this.zborId = zborId;
    }

    public String getNumeClient() {
        return numeClient;
    }

    public String getNumeTuristi() {
        return numeTuristi;
    }

    public String getAdresaClient() {
        return adresaClient;
    }

    public Integer getNrLocuri() {
        return nrLocuri;
    }

    public Integer getZborId() {
        return zborId;
    }
}
