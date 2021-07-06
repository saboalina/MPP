package domain.validators;

import domain.Angajat;

public class AngajatValidator implements Validator<Angajat> {
    @Override
    public void validate(Angajat entity) throws ValidationException {
        StringBuilder err = new StringBuilder();
        if (entity.getId().length()==0)
            err.append("id angajat invalid\n");
        if(entity.getNume().length()==0)
            err.append("nume angajat invalid\n");
        if(entity.getPrenume().length()==0)
            err.append("prenume angajat invalid\n");
        if(entity.getParola().length()==0)
            err.append("parola angajat invalida\n");
        if(err.length() > 0)
            throw new ValidationException(err.toString());
    }
}
