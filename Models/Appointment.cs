using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchedulingApplication.Utilities;

namespace SchedulingApplication.Models
{
    public class Appointment : BaseEntity
    {
        private DateTime _start;
        private DateTime _end;

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
        public DateTime Start
        {
            get { return _start; }
            set
            {
                _start = value;
                OnPropertyChanged();
                // Also notify that the local times have changed
                OnPropertyChanged(nameof(LocalStart));
                OnPropertyChanged(nameof(LocalStartTime));
                OnPropertyChanged(nameof(LocalStartDate));
                OnPropertyChanged(nameof(IsWithinBusinessHours));
            }
        }

        [Required]
        [Column("end")]
        public DateTime End
        {
            get { return _end; }
            set
            {
                _end = value;
                OnPropertyChanged();
                // Also notify that the local times have changed
                OnPropertyChanged(nameof(LocalEnd));
                OnPropertyChanged(nameof(LocalEndTime));
                OnPropertyChanged(nameof(IsWithinBusinessHours));
            }
        }

        // Navigation Properties
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        // Computed properties for the UI

        /// <summary>
        /// Gets the start time in the user's local timezone
        /// </summary>
        [NotMapped]
        public DateTime LocalStart
        {
            get { return TimeZoneHelper.UtcToLocal(Start); }
        }

        /// <summary>
        /// Gets the end time in the user's local timezone
        /// </summary>
        [NotMapped]
        public DateTime LocalEnd
        {
            get { return TimeZoneHelper.UtcToLocal(End); }
        }

        /// <summary>
        /// Gets the start time formatted for display in the user's local timezone
        /// </summary>
        [NotMapped]
        public string LocalStartTime
        {
            get { return LocalStart.ToString("hh:mm tt"); }
        }

        /// <summary>
        /// Gets the end time formatted for display in the user's local timezone
        /// </summary>
        [NotMapped]
        public string LocalEndTime
        {
            get { return LocalEnd.ToString("hh:mm tt"); }
        }

        /// <summary>
        /// Gets the start date formatted for display in the user's local timezone
        /// </summary>
        [NotMapped]
        public string LocalStartDate
        {
            get { return LocalStart.ToString("MM/dd/yyyy"); }
        }

        /// <summary>
        /// Gets the full start date and time formatted for display
        /// </summary>
        [NotMapped]
        public string LocalStartDateTime
        {
            get { return LocalStart.ToString("MM/dd/yyyy hh:mm tt"); }
        }

        /// <summary>
        /// Gets the full end date and time formatted for display
        /// </summary>
        [NotMapped]
        public string LocalEndDateTime
        {
            get { return LocalEnd.ToString("MM/dd/yyyy hh:mm tt"); }
        }

        /// <summary>
        /// Gets the appointment duration in minutes
        /// </summary>
        [NotMapped]
        public int DurationMinutes
        {
            get { return (int)(End - Start).TotalMinutes; }
        }

        /// <summary>
        /// Gets whether this appointment is within business hours
        /// </summary>
        [NotMapped]
        public bool IsWithinBusinessHours
        {
            get
            {
                // Convert to business time
                DateTime startBusiness = TimeZoneHelper.UtcToBusinessTime(Start);
                DateTime endBusiness = TimeZoneHelper.UtcToBusinessTime(End);

                // Check weekday for both start and end
                bool isWeekday = startBusiness.DayOfWeek != DayOfWeek.Saturday &&
                                startBusiness.DayOfWeek != DayOfWeek.Sunday &&
                                endBusiness.DayOfWeek != DayOfWeek.Saturday &&
                                endBusiness.DayOfWeek != DayOfWeek.Sunday;

                // Check business hours (9 AM to 5 PM)
                TimeSpan businessStart = new TimeSpan(9, 0, 0);
                TimeSpan businessEnd = new TimeSpan(17, 0, 0);

                bool isWithinHours = startBusiness.TimeOfDay >= businessStart &&
                                    endBusiness.TimeOfDay <= businessEnd;

                return isWeekday && isWithinHours;
            }
        }

        /// <summary>
        /// Checks if this appointment overlaps with another appointment
        /// </summary>
        public bool OverlapsWith(Appointment other)
        {
            return (Start <= other.Start && End > other.Start) ||
                   (Start < other.End && End >= other.End) ||
                   (Start >= other.Start && End <= other.End);
        }

        /// <summary>
        /// Creates a copy of this appointment
        /// </summary>
        public Appointment CreateCopy()
        {
            return new Appointment
            {
                CustomerId = this.CustomerId,
                UserId = this.UserId,
                Title = this.Title,
                Description = this.Description,
                Location = this.Location,
                Contact = this.Contact,
                Type = this.Type,
                Url = this.Url,
                Start = this.Start,
                End = this.End,
                CreateDate = DateTime.UtcNow,
                CreatedBy = this.CreatedBy,
                LastUpdate = DateTime.UtcNow,
                LastUpdateBy = this.LastUpdateBy
            };
        }
    }
}