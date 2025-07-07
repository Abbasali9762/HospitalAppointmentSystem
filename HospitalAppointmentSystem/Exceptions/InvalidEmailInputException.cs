namespace HospitalAppointmentSystem.Exceptions;

public class InvalidEmailInputException : Exception
{
    public InvalidEmailInputException() : base("Email entered in incorrect format!") {}
}
