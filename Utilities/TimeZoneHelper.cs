using System;

namespace SchedulingApplication.Utilities
{
    /// <summary>
    /// Helper class for managing timezone conversions throughout the application.
    /// The application follows these timezone conventions:
    /// - Database stores all times in UTC
    /// - UI displays times in the user's local timezone
    /// - Business hours are defined in Eastern Time
    /// </summary>
    public static class TimeZoneHelper
    {
        // Constants for timezone IDs
        private const string BUSINESS_TIMEZONE_ID = "Eastern Standard Time";

        /// <summary>
        /// Gets the user's local timezone
        /// </summary>
        /// <returns>The user's local TimeZoneInfo</returns>
        public static TimeZoneInfo GetLocalTimeZone()
        {
            try
            {
                return TimeZoneInfo.Local;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting local timezone: {ex.Message}. Falling back to UTC.");
                return TimeZoneInfo.Utc;
            }
        }

        /// <summary>
        /// Gets the business timezone (Eastern Time)
        /// </summary>
        /// <returns>The business TimeZoneInfo</returns>
        public static TimeZoneInfo GetBusinessTimeZone()
        {
            try
            {
                return TimeZoneInfo.FindSystemTimeZoneById(BUSINESS_TIMEZONE_ID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting business timezone: {ex.Message}. Falling back to UTC.");
                return TimeZoneInfo.Utc;
            }
        }

        /// <summary>
        /// Converts UTC time to the user's local time
        /// </summary>
        /// <param name="utcTime">DateTime in UTC</param>
        /// <returns>DateTime in user's local timezone</returns>
        public static DateTime UtcToLocal(DateTime utcTime)
        {
            if (utcTime.Kind != DateTimeKind.Utc)
                utcTime = DateTime.SpecifyKind(utcTime, DateTimeKind.Utc);

            return TimeZoneInfo.ConvertTimeFromUtc(utcTime, GetLocalTimeZone());
        }

        /// <summary>
        /// Converts user's local time to UTC
        /// </summary>
        /// <param name="localTime">DateTime in user's local timezone</param>
        /// <returns>DateTime in UTC</returns>
        public static DateTime LocalToUtc(DateTime localTime)
        {
            if (localTime.Kind != DateTimeKind.Local && localTime.Kind != DateTimeKind.Unspecified)
                localTime = DateTime.SpecifyKind(localTime, DateTimeKind.Local);

            return TimeZoneInfo.ConvertTimeToUtc(localTime, GetLocalTimeZone());
        }

        /// <summary>
        /// Converts UTC time to business time (Eastern Time)
        /// </summary>
        /// <param name="utcTime">DateTime in UTC</param>
        /// <returns>DateTime in Eastern Time</returns>
        public static DateTime UtcToBusinessTime(DateTime utcTime)
        {
            if (utcTime.Kind != DateTimeKind.Utc)
                utcTime = DateTime.SpecifyKind(utcTime, DateTimeKind.Utc);

            return TimeZoneInfo.ConvertTimeFromUtc(utcTime, GetBusinessTimeZone());
        }

        /// <summary>
        /// Converts business time (Eastern Time) to UTC
        /// </summary>
        /// <param name="businessTime">DateTime in Eastern Time</param>
        /// <returns>DateTime in UTC</returns>
        public static DateTime BusinessTimeToUtc(DateTime businessTime)
        {
            return TimeZoneInfo.ConvertTimeToUtc(businessTime, GetBusinessTimeZone());
        }

        /// <summary>
        /// Converts local time to business time (Eastern Time)
        /// </summary>
        /// <param name="localTime">DateTime in user's local timezone</param>
        /// <returns>DateTime in Eastern Time</returns>
        public static DateTime LocalToBusinessTime(DateTime localTime)
        {
            // Convert local to UTC first, then to business time
            DateTime utcTime = LocalToUtc(localTime);
            return UtcToBusinessTime(utcTime);
        }

        /// <summary>
        /// Checks if a given time (in local timezone) falls within business hours
        /// Business hours are 9:00 AM - 5:00 PM Eastern Time, Monday through Friday
        /// </summary>
        /// <param name="localTime">DateTime in user's local timezone to check</param>
        /// <returns>True if within business hours, false otherwise</returns>
        public static bool IsWithinBusinessHours(DateTime localTime)
        {
            // Convert to business timezone
            DateTime businessTime = LocalToBusinessTime(localTime);

            // Check if it's a weekday
            bool isWeekday = businessTime.DayOfWeek != DayOfWeek.Saturday &&
                            businessTime.DayOfWeek != DayOfWeek.Sunday;

            // Check if it's between 9 AM and 5 PM
            bool isBusinessHours = businessTime.Hour >= 9 && businessTime.Hour < 17;

            return isWeekday && isBusinessHours;
        }

        /// <summary>
        /// Formats a DateTime with the user's timezone information
        /// </summary>
        /// <param name="dateTime">The DateTime to format</param>
        /// <param name="format">Optional format string (defaults to "MM/dd/yyyy hh:mm tt")</param>
        /// <returns>Formatted string with timezone information</returns>
        public static string FormatWithTimeZone(DateTime dateTime, string format = "MM/dd/yyyy hh:mm tt")
        {
            TimeZoneInfo userTimeZone = GetLocalTimeZone();
            bool isDST = userTimeZone.IsDaylightSavingTime(dateTime);
            string dstIndicator = isDST ? " (DST)" : "";

            return $"{dateTime.ToString(format)} ({userTimeZone.DisplayName}{dstIndicator})";
        }
    }
}