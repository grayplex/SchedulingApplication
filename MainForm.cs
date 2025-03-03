using SchedulingApplication.Models;
using SchedulingApplication.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchedulingApplication
{
    public partial class MainForm : Form
    {
        private User _currentUser;
        private List<Appointment> _upcomingAppointments;

        public MainForm()
        {
            InitializeComponent();

            // Load user data
            _currentUser = LoginForm.LoggedInUser;
            lblWelcome.Text = string.Format(LocalizationManager.GetTranslation("WelcomeMessage"), _currentUser.UserName);

            // Show user's time zone info
            lblTimeZone.Text = $"Your time zone: {TimeZoneHelper.LocalTimeZone}";

            TimeZoneHelper.TimezonePreferenceChanged += TimezonePreferenceChanged_Handler;

            UpdateTimezoneInfo();

            // Load upcoming appointments
            LoadUpcomingAppointments();

            // Set initial view to Calendar
            ShowCalendarView();

            // Check for upcoming appointments alert
            CheckForUpcomingAppointments();

            chkUseBusinessTime.CheckedChanged += ChkUseBusinessTime_CheckedChanged;
            chkUseBusinessTime.Checked = TimeZoneHelper.UseBusinessTimezone;
        }

        private void LoadUpcomingAppointments()
        {
            try
            {
                var today = DateTime.Today;
                var appointments = Program.DbContext.Appointments
                    .Where(a => a.UserId == _currentUser.UserId && a.Start >= today)
                    .OrderBy(a => a.Start)
                    .Take(10)
                    .ToList();

                _upcomingAppointments = appointments;

                // Update the list in the sidebar
                lstUpcomingAppointments.Items.Clear();
                foreach (var appointment in _upcomingAppointments)
                {
                    var localStart = TimeZoneHelper.ConvertFromUtc(appointment.Start);

                    lstUpcomingAppointments.Items.Add(new ListViewItem
                    {
                        Text = appointment.Title,
                        SubItems =
                    {
                        localStart.ToString("MM/dd/yyyy hh:mm tt")
                    }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading upcoming appointments: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckForUpcomingAppointments()
        {
            try
            {
                // Current time in UTC (for database comparison)
                DateTime nowUtc = DateTime.UtcNow;

                // 15 minutes from now in UTC
                DateTime thresholdUtc = nowUtc.AddMinutes(15);

                // Query appointments in the next 15 minutes
                var upcomingAppointments = Program.DbContext.Appointments
                    .Include("Customer")
                    .Where(a => a.UserId == _currentUser.UserId &&
                              a.Start > nowUtc &&
                              a.Start <= thresholdUtc)
                    .OrderBy(a => a.Start)
                    .ToList();

                if (upcomingAppointments.Any())
                {
                    // Show alert dialog with the upcoming appointments
                    var alertForm = new AppointmentAlertForm(upcomingAppointments);
                    alertForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking for upcoming appointments: {ex.Message}");
            }
        }

        private void BtnCalendar_Click(object sender, EventArgs e)
        {
            ShowCalendarView();
        }

        private void BtnAppointments_Click(object sender, EventArgs e)
        {
            ShowAppointmentsView();
        }

        private void BtnCustomers_Click(object sender, EventArgs e)
        {
            ShowCustomersView();
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
            ShowReportsView();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                LocalizationManager.GetTranslation("LogoutConfirmation"),
                LocalizationManager.GetTranslation("Logout"),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Clear the current user
                _currentUser = null;

                // Hide the main form
                this.Hide();

                // Show login window again
                var loginForm = new LoginForm();
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Reload data with new user
                    _currentUser = LoginForm.LoggedInUser;
                    lblWelcome.Text = string.Format(LocalizationManager.GetTranslation("WelcomeMessage"), _currentUser.UserName);
                    lblUser.Text = $"Logged in as: {_currentUser.UserName}";

                    LoadUpcomingAppointments();
                    ShowCalendarView();

                    // Show the main form again
                    this.Show();
                }
                else
                {
                    // Close application if login canceled
                    Application.Exit();
                }
            }
        }

        private void ShowCalendarView()
        {
            SetActiveButton(btnCalendar);
            pnlContent.Controls.Clear();

            var calendarView = new CalendarUserControl
            {
                Dock = DockStyle.Fill
            };
            pnlContent.Controls.Add(calendarView);
        }

        private void ShowAppointmentsView()
        {
            SetActiveButton(btnAppointments);
            pnlContent.Controls.Clear();

            var appointmentsView = new AppointmentsUserControl
            {
                Dock = DockStyle.Fill
            };
            pnlContent.Controls.Add(appointmentsView);
        }

        private void ShowCustomersView()
        {
            SetActiveButton(btnCustomers);
            pnlContent.Controls.Clear();

            var customersView = new CustomersUserControl
            {
                Dock = DockStyle.Fill
            };
            pnlContent.Controls.Add(customersView);
        }

        private void ShowReportsView()
        {
            SetActiveButton(btnReports);
            pnlContent.Controls.Clear();

            var reportsView = new ReportsUserControl
            {
                Dock = DockStyle.Fill
            };
            pnlContent.Controls.Add(reportsView);
        }

        private void SetActiveButton(Button activeButton)
        {
            // Reset all buttons
            btnCalendar.BackColor = SystemColors.Control;
            btnAppointments.BackColor = SystemColors.Control;
            btnCustomers.BackColor = SystemColors.Control;
            btnReports.BackColor = SystemColors.Control;

            // Highlight active button
            activeButton.BackColor = SystemColors.ControlLight;
        }

        private void ChkUseBusinessTime_CheckedChanged(object sender, EventArgs e)
        {
            // Update the timezone preference
            TimeZoneHelper.UseBusinessTimezone = chkUseBusinessTime.Checked;
        }

        private void UpdateTimezoneInfo()
        {
            // Update the timezone label in the status bar
            lblTimeZone.Text = $"Timezone: {TimeZoneHelper.ActiveTimeZone.DisplayName}";
        }

        private void TimezonePreferenceChanged_Handler(object sender, EventArgs e)
        {
            // Update timezone info display
            UpdateTimezoneInfo();

            // Refresh the upcoming appointments list
            LoadUpcomingAppointments();

            // Refresh the active view as well, since it might need to display times
            RefreshActiveView();
        }

        private void RefreshActiveView()
        {
            // Determine which view is currently active and refresh it
            if (pnlContent.Controls.Count > 0)
            {
                if (pnlContent.Controls[0] is CalendarUserControl calendarView)
                {
                    calendarView.RefreshData();
                }
                else if (pnlContent.Controls[0] is AppointmentsUserControl appointmentsView)
                {
                    appointmentsView.RefreshData();
                }
                else if (pnlContent.Controls[0] is CustomersUserControl customersView)
                {
                    customersView.RefreshData();
                }
            }
        }
    }
}
