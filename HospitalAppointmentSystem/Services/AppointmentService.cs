using HospitalAppointmentSystem.Models;


namespace HospitalAppointmentSystem.Services
{
    public class AppointmentService
    {
        private readonly List<Appointment> _appointments = new List<Appointment>();

        public readonly string[] TimeSlots = { "09:00-11:00", "12:00-14:00", "15:00-17:00" };

        public bool IsTimeSlotAvailable(string doctorId, DateTime date, string timeSlot)
        {
            return !_appointments.Any(a =>
                a.DoctorId == doctorId &&
                a.Date.Date == date.Date &&
                a.TimeSlot == timeSlot);
        }

        public void AddAppointment(Appointment appointment)
        {
            appointment.Id = Guid.NewGuid().ToString();
            _appointments.Add(appointment);
        }

        public List<Appointment> GetAppointmentsByDoctorAndDate(string doctorId, DateTime date)
        {
            return _appointments
                .Where(a => a.DoctorId == doctorId && a.Date.Date == date.Date)
                .ToList();
        }
    }
}
