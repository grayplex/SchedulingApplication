using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchedulingApplication.Utilities;

namespace SchedulingApplication.Models
{
    public class Appointment : BaseEntity
    {
        [Key]
        [Column("AppointmentId")]
        public int AppointmentId { get; set; }

        [Required]
        [Column("customerId")]
        public int CustomerId { get; set; }

        [Required]
        [Column("userId")]
        public int UserId { get; set; }

        [StringLength(255)]
        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("location")]
        public string Location { get; set; }

        [Column("contact")]
        public string Contact { get; set; }

        [Column("type")]
        public string Type { get; set; }

        [StringLength(255)]
        [Column("url")]
        public string Url { get; set; }

        [Required]
        [Column("start")]
        public DateTime Start { get; set; }

        [Required]
        [Column("end")]
        public DateTime End { get; set; }

        // Navigation Properties
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        // Computed for UI
        [NotMapped]
        public DateTime DisplayStart
        {
            get { return TimeZoneHelper.ConvertFromUtc(Start); }
        }

        [NotMapped]
        public DateTime DisplayEnd
        {
            get { return TimeZoneHelper.ConvertFromUtc(End); }
        }

        [NotMapped]
        public string DisplayStartTime
        {
            get { return DisplayStart.ToString("hh:mm tt"); }
        }

        [NotMapped]
        public string DisplayEndTime
        {
            get { return DisplayEnd.ToString("hh:mm tt"); }
        }

        [NotMapped]
        public string DisplayStartDateTime
        {
            get { return TimeZoneHelper.FormatWithTimezone(DisplayStart); }
        }

        [NotMapped]
        public string DisplayEndDateTime
        {
            get { return TimeZoneHelper.FormatWithTimezone(DisplayEnd); }
        }

        [NotMapped]
        public bool IsWithinBusinessHours
        {
            get
            {
                return TimeZoneHelper.IsWithinBusinessHours(Start) &&
                         TimeZoneHelper.IsWithinBusinessHours(End);
            }
        }
    }
}