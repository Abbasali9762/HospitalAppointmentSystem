namespace HospitalAppointmentSystem.Exceptions;

public class InvalidPhoneNumberException : Exception
{
    public InvalidPhoneNumberException() : base("The phone number was entered incorrectly!") { }
}