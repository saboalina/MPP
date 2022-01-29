package domain.validators;

import domain.Employee;

public class EmployeeValidator implements Validator<Employee>{
    @Override
    public void validate(Employee entity) throws ValidationException {
        String err="";
        //validate entity
        if(entity.getUsername().compareTo("")==0)
            err+="Null username!\n";
        if(entity.getName().compareTo("")==0)
            err+="Null name!\n";
        if(entity.getPassword().compareTo("")==0)
            err+="Null password!\n";
        if (!err.equals(""))
            throw new ValidationException(err);
    }
}
