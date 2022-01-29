package domain;

public class Angajat extends Entity<String>{

    private String nume;
    private String prenume;
    private String parola;

    public Angajat(String nume, String prenume, String parola) {
        this.nume = nume;
        this.prenume = prenume;
        this.parola = parola;
    }

    public String getNume() {
        return nume;
    }

    public String getPrenume() {
        return prenume;
    }

    public String getParola() {
        return parola;
    }
}
