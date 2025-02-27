using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingApplication.Utilities
{
    public static class LoginLogger
    {
        private const string LogFileName = "Login_History.txt";

        public static void LogLogin(string username)
        {
            try
            {
                // Format the log entry: timestamp and username
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string logEntry = $"{timestamp} - User '{username}' logged in\n";

                // Get the full path to the log file (in the application directory)
                string logFilePath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    LogFileName);

                // Append the log entry to the file (create if doesn't exist)
                File.AppendAllText(logFilePath, logEntry, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                // Log error to console but don't disrupt the login process
                Console.WriteLine($"Error logging login: {ex.Message}");
            }
        }
    }
}
