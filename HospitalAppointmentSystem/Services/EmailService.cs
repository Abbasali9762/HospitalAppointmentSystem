using HospitalAppointmentSystem.Interfaces;
using HospitalAppointmentSystem.Models;
using System;
using System.Net;
using System.Net.Mail;

namespace HospitalAppointmentSystem.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly int _smtpPort = 587;
        private readonly string _smtpUsername = "abbaseli.sixelizade.2010@gmail.com";
        private readonly string _smtpPassword = "hnyv xwni dgnd fuda";

        public void SendAppointmentConfirmation(Patient patient, Doctor doctor, DateTime date, string timeSlot)
        {
            try
            {
                var fromAddress = new MailAddress(_smtpUsername, "Hospital System");
                var toAddress = new MailAddress(patient.Email, $"{patient.FirstName} {patient.LastName}");

                string subject = "Reception Reservation Confirmation";
                string body = $@"Hello {patient.FirstName} {patient.LastName},

You have successfully made a reception reservation.

Doctor: Dr. {doctor.FirstName} {doctor.LastName}
Department: {doctor.Department}
Date: {date:dd.MM.yyyy}
Time: {timeSlot}

We ask that you register 15 minutes before arriving at the hospital.

Sincerely,
Hospital Admistration";

                using (var smtp = new SmtpClient
                {
                    Host = _smtpServer,
                    Port = _smtpPort,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, _smtpPassword)
                })
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }

                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while sending the email: " + ex.Message);
            }
        }
    }
}
