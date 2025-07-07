namespace HospitalAppointmentSystem.Exceptions;

public class InvalidSurnameInputException : Exception
{
    public InvalidSurnameInputException() : base("Surname entered incorrectly!") { }
}