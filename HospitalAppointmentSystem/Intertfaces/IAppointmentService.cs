
using HospitalAppointmentSystem.Models;

namespace HospitalAppointmentSystem.Interfaces
{
    public interface IAppointmentService
    {
        bool IsTimeSlotAvailable(Doctor doctor, DateTime date, string timeSlot);
        bool BookAppointment(Patient patient, Doctor doctor, DateTime date, string timeSlot);
        List<Appointment> GetAppointmentsByDoctorAndDate(Doctor doctor, DateTime date);
    }
}
