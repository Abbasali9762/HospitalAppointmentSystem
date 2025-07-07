using HospitalAppointmentSystem.Models;


namespace HospitalAppointmentSystem.Services
{
    public class DoctorService
    {
        public List<Doctor> Doctors { get; private set; }

        public DoctorService()
        {
            Doctors = new List<Doctor>
    {
        new Doctor { Id = "1", FirstName = "Emily", LastName = "Smith", Experience = 5, Department = "Pediatrics", Email = "emily.smith@example.com" },
        new Doctor { Id = "2", FirstName = "Michael", LastName = "Johnson", Experience = 7, Department = "Pediatrics", Email = "michael.johnson@example.com" },
        new Doctor { Id = "3", FirstName = "Olivia", LastName = "Brown", Experience = 4, Department = "Pediatrics", Email = "olivia.brown@example.com" },

        new Doctor { Id = "4", FirstName = "James", LastName = "Williams", Experience = 10, Department = "Traumatology", Email = "james.williams@example.com" },
        new Doctor { Id = "5", FirstName = "Sophia", LastName = "Jones", Experience = 8, Department = "Traumatology", Email = "sophia.jones@example.com" },

        new Doctor { Id = "6", FirstName = "Daniel", LastName = "Garcia", Experience = 6, Department = "Dentistry", Email = "daniel.garcia@example.com" },
        new Doctor { Id = "7", FirstName = "Liam", LastName = "Martinez", Experience = 9, Department = "Dentistry", Email = "liam.martinez@example.com" },
        new Doctor { Id = "8", FirstName = "Ethan", LastName = "Davis", Experience = 5, Department = "Dentistry", Email = "ethan.davis@example.com" },
        new Doctor { Id = "9", FirstName = "Isabella", LastName = "Lopez", Experience = 7, Department = "Dentistry", Email = "isabella.lopez@example.com" },
    };
    }


        public List<Doctor> GetDoctorsByDepartment(string department)
        {
            return Doctors.Where(d => d.Department == department).ToList();
        }

        public Doctor GetDoctorById(string id)
        {
            return Doctors.FirstOrDefault(d => d.Id == id);
        }
    }
}
