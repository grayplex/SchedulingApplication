using System;
using System.Windows.Forms;

namespace SchedulingApplication.Utilities
{
    public static class TimeZoneHelper
    {
        // Constants
        private const string BUSINESS_TIMEZONE_ID = "Eastern Standard Time";

        // Current display timezone preference - defaults to local
        private static bool _useBusinessTimezone = false;

        // Event for when timezone preference changes
        public static event EventHandler TimezonePreferenceChanged;

        // Property to get/set timezone preference
        public static bool UseBusinessTimezone
        {
            get { return _useBusinessTimezone; }
            set
            {
                if (_useBusinessTimezone != value)
                {
                    _useBusinessTimezone = value;
                    TimezonePreferenceChanged?.Invoke(null, EventArgs.Empty);
                }
            }
        }

        // Get the active timezone based on preference
        public static TimeZoneInfo ActiveTimeZone
        {
            get
            {
                return _useBusinessTimezone ? BusinessTimeZone : LocalTimeZone;
            }
        }

        // Get the local timezone
        public static TimeZoneInfo LocalTimeZone
        {
            get { return TimeZoneInfo.Local; }
        }

        // Get the business timezone (EST)
        public static TimeZoneInfo BusinessTimeZone
        {
            get
            {
                try
                {
                    return TimeZoneInfo.FindSystemTimeZoneById(BUSINESS_TIMEZONE_ID);
                }
                catch
                {
                    MessageBox.Show("Business timezone (Eastern Standard Time) not found. Falling back to UTC.",
                        "Timezone Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return TimeZoneInfo.Utc;
                }
            }
        }

        // Convert a database UTC time to the display timezone
        public static DateTime ConvertFromUtc(DateTime utcDateTime)
        {
            // Ensure the datetime is in UTC
            var utcTime = DateTime.SpecifyKind(utcDateTime, DateTimeKind.Utc);
            return TimeZoneInfo.ConvertTimeFromUtc(utcTime, ActiveTimeZone);
        }

        // Convert a display timezone time to UTC for database storage
        public static DateTime ConvertToUtc(DateTime displayDateTime)
        {
            // Convert based on active timezone
            return TimeZoneInfo.ConvertTimeToUtc(displayDateTime, ActiveTimeZone);
        }

        // Check if a time is within business hours (9 AM - 5 PM EST, weekdays)
        public static bool IsWithinBusinessHours(DateTime utcDateTime)
        {
            // Convert to business time
            var businessTime = TimeZoneInfo.ConvertTimeFromUtc(
                DateTime.SpecifyKind(utcDateTime, DateTimeKind.Utc),
                BusinessTimeZone);

            // Check if weekday
            bool isWeekday = businessTime.DayOfWeek != DayOfWeek.Saturday &&
                             businessTime.DayOfWeek != DayOfWeek.Sunday;

            // Check if between 9 AM and 5 PM
            bool isBusinessHours = businessTime.Hour >= 9 && businessTime.Hour < 17;

            return isWeekday && isBusinessHours;
        }

        // Format a datetime for display with timezone info
        public static string FormatWithTimezone(DateTime dateTime)
        {
            string tzName = ActiveTimeZone.IsDaylightSavingTime(dateTime) ?
                ActiveTimeZone.DaylightName : ActiveTimeZone.StandardName;

            return $"{dateTime:MM/dd/yyyy hh:mm tt} ({tzName})";
        }
    }
}