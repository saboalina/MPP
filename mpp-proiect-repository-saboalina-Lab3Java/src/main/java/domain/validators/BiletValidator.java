package domain.validators;

import domain.Bilet;

public class BiletValidator implements Validator<Bilet>{
    @Override
    public void validate(Bilet entity) throws ValidationException {
        StringBuilder err = new StringBuilder();
        if (entity.getId() <= 0)
            err.append("id bilet invalid\n");
        if(entity.getNumeClient().length()==0)
            err.append("nume client invalid\n");
        if(entity.getNumeTuristi().length()==0)
            err.append("nume turisti invalid\n");
        if(entity.getAdresaClient().length()==0)
            err.append("adresa client invalida\n");
        if (entity.getNrLocuri() <= 0)
            err.append("nr locuri invalid\n");
        if (entity.getZborId() <= 0)
            err.append("id zbor invalid\n");
        if(err.length() > 0)
            throw new ValidationException(err.toString());

    }
}
