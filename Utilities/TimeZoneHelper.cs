using System;

namespace SchedulingApplication.Utilities
{
    public static class TimeZoneHelper
    {
        private const string DatabaseTimeZoneId = "UTC";
        private const string BusinessHoursTimeZoneId = "Eastern Standard Time";

        public static TimeZoneInfo GetUserTimeZone()
        {
            try
            {
                return TimeZoneInfo.Local;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting local time zone: {ex.Message}. Falling back to UTC.");
                return TimeZoneInfo.Utc;
            }
        }

        public static DateTime ToUserTime(DateTime dbTime)
        {
            try
            {
                TimeZoneInfo userTimeZone = GetUserTimeZone();
                return TimeZoneInfo.ConvertTimeFromUtc(dbTime, userTimeZone);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting to user time: {ex.Message}");
                return dbTime;
            }
        }

        public static DateTime ToDatabaseTime(DateTime userTime)
        {
            try
            {
                TimeZoneInfo userTimeZone = GetUserTimeZone();
                return TimeZoneInfo.ConvertTimeToUtc(userTime, userTimeZone);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting to database time: {ex.Message}");
                return userTime;
            }
        }

        public static DateTime ToBusinessHoursTimeZone(DateTime userTime)
        {
            try
            {
                TimeZoneInfo businessHoursTimeZone = TimeZoneInfo.FindSystemTimeZoneById(BusinessHoursTimeZoneId);
                TimeZoneInfo userTimeZone = GetUserTimeZone();

                DateTime utcTime = TimeZoneInfo.ConvertTimeToUtc(userTime, userTimeZone);
                return TimeZoneInfo.ConvertTimeFromUtc(utcTime, businessHoursTimeZone);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting to business hours time zone: {ex.Message}");
                return userTime;
            }
        }

        public static string FormatWithTimeZone(DateTime dateTime)
        {
            TimeZoneInfo userTimeZone = GetUserTimeZone();
            bool isDST = userTimeZone.IsDaylightSavingTime(dateTime);
            string dstIndicator = isDST ? " (DST)" : "";

            return $"{dateTime:MM/dd/yyyy hh:mm tt} ({userTimeZone.DisplayName}{dstIndicator})";
        }

        public static bool IsWithinBusinessHours(DateTime userTime)
        {
            try
            {
                DateTime businessTime = ToBusinessHoursTimeZone(userTime);

                bool isWeekday = businessTime.DayOfWeek != DayOfWeek.Saturday &&
                               businessTime.DayOfWeek != DayOfWeek.Sunday;
                bool isBusinessHours = businessTime.Hour >= 9 && businessTime.Hour < 17;

                return isWeekday && isBusinessHours;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking business hours: {ex.Message}");
                return false;
            }
        }
    }
}