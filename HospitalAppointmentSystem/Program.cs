using HospitalAppointmentSystem.Models;
using HospitalAppointmentSystem.Services;
using HospitalAppointmentSystem.Exceptions;
using HospitalAppointmentSystem.Helper;


var doctorService = new DoctorService();
var appointmentService = new AppointmentService();
var emailService = new EmailService();



var fileService = new FileService();
var data = fileService.LoadData();

while (true)
{
    try
    {
        Console.WriteLine("---------------Hospital Admission System------------------\n");

        string firstName;
        while (true)
        {
            Console.Write("Enter your name: ");
            firstName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(firstName) || firstName.Any(char.IsDigit))
            {
                throw new InvalidNameInputException();


            }
            else break;
        }

        string lastName;
        while (true)
        {
            Console.Write("Enter your surname: ");
            lastName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(lastName) || lastName.Any(char.IsDigit))
            {
                throw new InvalidSurnameInputException();

            }
            else break;
        }

        string email;
        while (true)
        {
            Console.Write("Enter your email: ");
            email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email) || !email.EndsWith("@gmail.com"))
            {
                throw new InvalidEmailInputException();

            }
            else break;
        }

        Console.Write("Enter your phone number : ");
        string phone = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(phone) || !phone.All(char.IsDigit) || phone.Length < 10)
        {
            throw new InvalidPhoneNumberException();
        }

        var patient = new Patient
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Phone = phone
        };

        data.Patients.Add(patient);
        Console.Clear();

        string[] departments = { "Pediatrics", "Traumatology", "Stomatology" };
        Console.WriteLine("\nDepartments:");
        for (int i = 0; i < departments.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {departments[i]}");
        }

        int depChoice;
        do
        {
            Console.Write("Choose a department (1-3): ");
        } while (!int.TryParse(Console.ReadLine(), out depChoice) || depChoice < 1 || depChoice > 3);

        string selectedDepartment = departments[depChoice - 1];

        var doctors = doctorService.GetDoctorsByDepartment(selectedDepartment);

        Console.WriteLine($"\n{selectedDepartment} department's doctors:");
        for (int i = 0; i < doctors.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {doctors[i]}");
        }

        int doctorChoice;
        do
        {
            Console.Write("Choose a doctor: ");
        } while (!int.TryParse(Console.ReadLine(), out doctorChoice) || doctorChoice < 1 || doctorChoice > doctors.Count);

        var selectedDoctor = doctors[doctorChoice - 1];

        DateTime appointmentDate;
        do
        {
            Console.Write("Enter the date of receipt (yyyy-mm-dd): ");
        } while (!DateTime.TryParse(Console.ReadLine(), out appointmentDate) || appointmentDate.Date < DateTime.Today);

        while (true)
        {
            Console.WriteLine("\nPossible time intervals:");
            var appointmentsForDoctor = appointmentService.GetAppointmentsByDoctorAndDate(selectedDoctor.Id, appointmentDate);

            for (int i = 0; i < appointmentService.TimeSlots.Length; i++)
            {
                string timeSlot = appointmentService.TimeSlots[i];
                bool isReserved = appointmentsForDoctor.Any(a => a.TimeSlot == timeSlot);
                Console.WriteLine($"{i + 1}. {timeSlot} - {(isReserved ? "Reserved" : "Not reserved")}");
            }

            Console.Write("Choose a time: ");
            if (int.TryParse(Console.ReadLine(), out int timeChoice) &&
                timeChoice >= 1 && timeChoice <= appointmentService.TimeSlots.Length)
            {
                string chosenTimeSlot = appointmentService.TimeSlots[timeChoice - 1];
                bool available = appointmentService.IsTimeSlotAvailable(selectedDoctor.Id, appointmentDate, chosenTimeSlot);

                if (available)
                {
                    var appointment = new Appointment
                    {
                        PatientId = patient.Id,
                        DoctorId = selectedDoctor.Id,
                        Date = appointmentDate,
                        TimeSlot = chosenTimeSlot
                    };
                    data.Appointments.Add(appointment);

                    fileService.SaveData(data);


                    Console.WriteLine($"\nThank you {patient.FirstName} {patient.LastName}, " +
                    $"you have made an appointment with Dr. {selectedDoctor.FirstName} {selectedDoctor.LastName} on {appointmentDate:dd.MM.yyyy}" +
                    $" at {chosenTimeSlot} interval.");

                    emailService.SendAppointmentConfirmation(patient, selectedDoctor, appointmentDate, chosenTimeSlot);

                    break;
                }
                else
                {
                    Console.WriteLine("This time is already reserved, please choose another time.");
                }
            }
            else
            {
                throw new InvalidChoice();
            }
        }
        Console.Clear();

        Console.WriteLine("\nFor new users, the program returns to the beginning...\n");
        Thread.Sleep(3000);
        Console.Clear();


    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        Thread.Sleep(3000);
        Console.Clear();
    }
    

}


