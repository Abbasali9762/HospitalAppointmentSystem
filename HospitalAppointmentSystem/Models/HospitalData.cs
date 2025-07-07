using System.Text.Json;

namespace HospitalAppointmentSystem.Models
{
    public class HospitalData
    {
        public List<Patient> Patients { get; set; } = new();
        public List<Doctor> Doctors { get; set; } = new();
        public List<Appointment> Appointments { get; set; } = new();
    }

    }
