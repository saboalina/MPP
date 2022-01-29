package domain.validators;

import domain.Flight;

public class FlightValidator implements Validator<Flight> {
    @Override
    public void validate(Flight entity) throws ValidationException {
        String err="";
        //validate entity
        if(entity.getId()<0)
            err+="Null flight id!\n";
        if(entity.getDestination().compareTo("")==0)
            err+="Null destination!\n";
        if(entity.getDepartureDate().compareTo("")==0)
            err+="Null departure date!\n";
        if(entity.getDepartureTime().compareTo("")==0)
            err+="Null departure time!\n";
        if(entity.getAirport().compareTo("")==0)
            err+="Null airport!\n";
        if(entity.getAvailableSeats()<0)
            err+="Null available seats!\n";
        if (!err.equals(""))
            throw new ValidationException(err);
    }
}
