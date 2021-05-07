using CSD.AppointmentApp.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace CSD.AppointmentApp.ValidationAttributes
{
    public class NoAppointmentOnSundayAttribute : ValidationAttribute //dikkat bunu ancak sınıfın üzerinde çalıştırabiliriz
    {
        public override bool IsValid(object value)
        {
            if (value is ClientViewModel cvm)
                return cvm.Date.DayOfWeek != DayOfWeek.Sunday;

            if (value is DateTime date)
                return date.DayOfWeek != DayOfWeek.Sunday;

            return false;
        }
    }
}
