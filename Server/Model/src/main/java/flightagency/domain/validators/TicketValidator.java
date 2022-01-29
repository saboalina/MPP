package flightagency.domain.validators;

import flightagency.domain.Ticket;

public class TicketValidator implements Validator<Ticket> {
    @Override
    public void validate(Ticket entity) throws ValidationException {
        String err="";
        //validate entity
        if(entity.getId()<0)
            err+="Null ticket id!\n";
        if(entity.getClientName().compareTo("")==0)
            err+="Null client name!\n";
        if(entity.getTouristsName().compareTo("")==0)
            err+="Null tourists name!\n";
        if(entity.getClientAddress().compareTo("")==0)
            err+="Null client address!\n";
        if(entity.getNoSeats()<0)
            err+="Null number of seats!\n";
        if(entity.getFlightId()<0)
            err+="Null flight id!\n";
        if (!err.equals(""))
            throw new ValidationException(err);
    }
}
