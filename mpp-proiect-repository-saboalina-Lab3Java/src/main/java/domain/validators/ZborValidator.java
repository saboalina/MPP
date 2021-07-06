package domain.validators;

import domain.Zbor;

public class ZborValidator implements  Validator<Zbor> {
    @Override
    public void validate(Zbor entity) throws ValidationException {
        StringBuilder err = new StringBuilder();
        if (entity.getId() <= 0)
            err.append("Id zbor invalid\n");
        if(entity.getDestinatie().length()==0)
            err.append("destinatie zbor invalida\n");
        if(entity.getAeroport().length()==0)
            err.append("aeroport zbor invalid\n");
        if (entity.getNrLocuriDisponibile() <= 0)
            err.append("nr locuri zbor invalid\n");
        if(err.length() > 0)
            throw new ValidationException(err.toString());

    }
}
