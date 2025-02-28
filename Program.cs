using SchedulingApplication.Data;
using SchedulingApplication.Utilities;
using System;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchedulingApplication
{
    static class Program
    {
        private static ApplicationDbContext _dbContext;

        public static ApplicationDbContext DbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    _dbContext = new ApplicationDbContext();
                }
                return _dbContext;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppDomain.CurrentDomain.SetData("EntityFramework.TimeZoneOffset", TimeZoneInfo.Local.BaseUtcOffset);


            try
            {
                // Initialize localization before showing any UI
                Console.WriteLine("Initializing localization...");
                LocalizationManager.Initialize();

                // Handle any unhandled exceptions
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                Application.ThreadException += Application_ThreadException;

                // Show login window
                Console.WriteLine("Creating login window");
                var loginForm = new LoginForm();
                Console.WriteLine("Showing login window");
                DialogResult loginResult = loginForm.ShowDialog();

                Console.WriteLine($"Login result: {loginResult}");

                // If login was successful, show main window
                if (loginResult == DialogResult.OK)
                {
                    try
                    {
                        Console.WriteLine("Creating main window...");
                        var mainForm = new MainForm();

                        Console.WriteLine("Showing main window...");
                        Application.Run(mainForm);
                    }
                    catch (Exception mainEx)
                    {
                        Console.WriteLine($"ERROR creating main window: {mainEx.Message}");
                        Console.WriteLine($"Stack trace: {mainEx.StackTrace}");
                        MessageBox.Show($"Error creating main window: {mainEx.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
                else
                {
                    // Login was cancelled or failed, so exit app
                    Console.WriteLine("Login canceled or failed. Shutting down application.");
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR during application startup: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                MessageBox.Show($"Error during application startup: {ex.Message}", "Startup Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception exception)
            {
                MessageBox.Show($"An unhandled exception occurred: {exception.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Console.WriteLine($"UNHANDLED UI EXCEPTION: {e.Exception.Message}");
            Console.WriteLine($"Stack trace: {e.Exception.StackTrace}");
            MessageBox.Show($"An unhandled exception occurred: {e.Exception.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
