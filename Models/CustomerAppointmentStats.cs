using System;
namespace SchedulingApplication.Models
{
    public class CustomerAppointmentStats
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int TotalAppointments { get; set; }
        public DateTime? LastAppointment { get; set; }
        public DateTime? NextAppointment { get; set; }
        public double AverageDuration { get; set; } // In minutes
        public string MostCommonType { get; set; }
    }
}
