using HospitalAppointmentSystem.Models;

namespace HospitalAppointmentSystem.Interfaces
{
    public interface IDoctorService
    {
        List<Doctor> GetDoctorsByDepartment(string department);
        Doctor GetDoctorByName(string firstName, string lastName);
    }
}
