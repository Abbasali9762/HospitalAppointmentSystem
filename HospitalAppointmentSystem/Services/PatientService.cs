using HospitalAppointmentSystem.Interfaces;
using HospitalAppointmentSystem.Models;

namespace HospitalAppointmentSystem.Services
{
    public class PatientService : IPatientService
    {
        private readonly List<Patient> _patients;

        public PatientService()
        {
            _patients = new List<Patient>();
        }

        public void AddPatient(Patient patient)
        {
            if (_patients.Any(p => p.Email == patient.Email))
                return;

            _patients.Add(patient);
        }

        public Patient GetPatientByEmail(string email)
        {
            return _patients.FirstOrDefault(p => p.Email == email);
        }
    }
}
