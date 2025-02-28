using System;

namespace SchedulingApplication.Utilities
{
    public static class TimeZoneHelper
    {
        private const string BusinessHoursTimeZoneId = "Eastern Standard Time";

        public static TimeZoneInfo GetUserTimeZone()
        {
            return TimeZoneInfo.Local;
        }

        public static TimeZoneInfo GetBusinessTimeZone()
        {
            return TimeZoneInfo.FindSystemTimeZoneById(BusinessHoursTimeZoneId);
        }

        // Convert UTC time to local time
        public static DateTime ToUserTime(DateTime utcTime)
        {
            // Ensure we're working with UTC time
            DateTime normalizedUtc = DateTime.SpecifyKind(utcTime, DateTimeKind.Utc);
            return normalizedUtc.ToLocalTime();
        }

        // Convert local time to UTC
        public static DateTime ToDatabaseTime(DateTime localTime)
        {
            // Ensure we're working with local time
            DateTime normalizedLocal = DateTime.SpecifyKind(localTime, DateTimeKind.Local);
            return normalizedLocal.ToUniversalTime();
        }

        // Convert between Business (EST) and User timezones
        public static DateTime BusinessToUserTime(DateTime businessTime)
        {
            // Convert from business timezone to user's timezone
            TimeZoneInfo businessTz = GetBusinessTimeZone();
            TimeZoneInfo userTz = GetUserTimeZone();

            // Use unspecified kind to avoid conflicts
            DateTime unspecifiedTime = DateTime.SpecifyKind(businessTime, DateTimeKind.Unspecified);

            // First to UTC then to user's timezone
            return TimeZoneInfo.ConvertTime(unspecifiedTime, businessTz, userTz);
        }

        public static DateTime UserToBusinessTime(DateTime userTime)
        {
            // Convert from user timezone to business timezone
            TimeZoneInfo businessTz = GetBusinessTimeZone();
            TimeZoneInfo userTz = GetUserTimeZone();

            // Use unspecified kind to avoid conflicts
            DateTime unspecifiedTime = DateTime.SpecifyKind(userTime, DateTimeKind.Unspecified);

            // Direct conversion between timezones
            return TimeZoneInfo.ConvertTime(unspecifiedTime, userTz, businessTz);
        }

        // Check if a time falls within business hours when converted to EST
        public static bool IsWithinBusinessHours(DateTime localTime)
        {
            // Convert to business timezone
            DateTime businessTime = UserToBusinessTime(localTime);

            // Check if it's a weekday between 9am-5pm
            bool isWeekday = businessTime.DayOfWeek != DayOfWeek.Saturday &&
                             businessTime.DayOfWeek != DayOfWeek.Sunday;
            bool isBusinessHours = businessTime.Hour >= 9 && businessTime.Hour < 17;

            return isWeekday && isBusinessHours;
        }
    }
}