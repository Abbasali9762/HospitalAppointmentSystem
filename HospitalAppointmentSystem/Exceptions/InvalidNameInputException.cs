namespace HospitalAppointmentSystem.Exceptions;

public class InvalidNameInputException : Exception
{
    public InvalidNameInputException() : base("Name entered incorrectly!") { }
}