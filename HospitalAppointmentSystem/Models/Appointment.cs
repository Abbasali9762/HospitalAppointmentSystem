
namespace HospitalAppointmentSystem.Models
{
    public class Appointment
    {
        public string Id { get; set; }
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public DateTime Date { get; set; }
        public string TimeSlot { get; set; }
    }
}
