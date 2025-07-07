namespace HospitalAppointmentSystem.Models
{
    public class Doctor
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Experience { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"Dr. {FirstName} {LastName} | {Department} | {Experience} experiance year.";
        }
    }
}
