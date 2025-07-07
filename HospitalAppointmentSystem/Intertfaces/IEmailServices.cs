using HospitalAppointmentSystem.Models;


namespace HospitalAppointmentSystem.Interfaces
{
    public interface IEmailService
    {
        void SendAppointmentConfirmation(Patient patient, Doctor doctor, DateTime date, string timeSlot);
    }
}
