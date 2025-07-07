using HospitalAppointmentSystem.Models;

namespace HospitalAppointmentSystem.Interfaces
{
    public interface IPatientService
    {
        void AddPatient(Patient patient);
        Patient GetPatientByEmail(string email);
    }
}
