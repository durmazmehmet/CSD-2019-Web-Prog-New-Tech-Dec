using CSD.AppointmentApp.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace CSD.AppointmentApp.ValidationAttributes
{
    public class NoBookingBeforeNowAttribute : ValidationAttribute //bir datetime türünün üzerinde çalışabilir
    {
        public override bool IsValid(object value)
        {
            if (value is ClientViewModel cvm)
                return cvm.Date > DateTime.Now;

            if (value is DateTime date)
                return date > DateTime.Now;

            return false;
        }
    }
}
