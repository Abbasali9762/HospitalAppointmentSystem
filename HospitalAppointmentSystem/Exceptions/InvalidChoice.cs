namespace HospitalAppointmentSystem.Exceptions;

public class InvalidChoice : Exception
{
    public InvalidChoice() : base("If it's not difficult, make the right choice!") { }
}
