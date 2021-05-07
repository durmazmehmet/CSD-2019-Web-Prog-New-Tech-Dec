using System;
using CSD.AppointmentApp.Entities;
using CSD.AppointmentApp.ValidationAttributes;

namespace CSD.AppointmentApp.ViewModels
{
    public class ClientViewModel
    {
        public Client Client { get; set; } = new Client();

        [NoBookingBeforeNow(ErrorMessage = "Please select a future date")]
        [NoAppointmentOnSunday(ErrorMessage = "No appointment on Sunday")]
        public DateTime Date { get; set; } = DateTime.Now;

        [MustBeTrue(ErrorMessage = "You must agree to terms and conditions to continue...")]
        public bool ClientAgreement { get; set; }
    }
}