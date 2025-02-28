using SchedulingApplication.Models;
using SchedulingApplication.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SchedulingApplication
{
    public partial class CalendarUserControl : UserControl
    {
        private DateTime _selectedDate;
        private DateTime _displayMonth;
        private List<Appointment> _selectedDateAppointments;
        private Appointment _selectedAppointment;

        public CalendarUserControl()
        {
            InitializeComponent();

            // Initialize to current date
            _selectedDate = DateTime.Today;
            _displayMonth = new DateTime(_selectedDate.Year, _selectedDate.Month, 1);
            _selectedDateAppointments = new List<Appointment>();

            // Setup event handlers
            btnPreviousMonth.Click += BtnPreviousMonth_Click;
            btnNextMonth.Click += BtnNextMonth_Click;
            btnViewDetails.Click += BtnViewDetails_Click;
            btnAddAppointment.Click += BtnAddAppointment_Click;
            dgvAppointments.CellClick += DgvAppointments_CellClick;

            // Update the UI
            UpdateCalendarDisplay();
            UpdateMonthDisplay();
            LoadSelectedDayAppointments();
        }

        private void DgvAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _selectedDateAppointments.Count)
            {
                _selectedAppointment = _selectedDateAppointments[e.RowIndex];
                // Enable or disable buttons based on selection
                btnViewDetails.Enabled = (_selectedAppointment != null);
            }
        }

        private void BtnPreviousMonth_Click(object sender, EventArgs e)
        {
            // Go to previous month
            _displayMonth = _displayMonth.AddMonths(-1);
            UpdateMonthDisplay();
            UpdateCalendarDisplay();
        }

        private void BtnNextMonth_Click(object sender, EventArgs e)
        {
            // Go to next month
            _displayMonth = _displayMonth.AddMonths(1);
            UpdateMonthDisplay();
            UpdateCalendarDisplay();
        }

        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            if (_selectedAppointment != null)
            {
                // Show appointment details
                var detailsForm = new AppointmentDetailsForm(_selectedAppointment);
                detailsForm.ShowDialog();

                // Refresh data after viewing in case edits were made
                LoadSelectedDayAppointments();
            }
        }

        private void BtnAddAppointment_Click(object sender, EventArgs e)
        {
            // Create a new appointment for the selected day
            var appointment = new Appointment
            {
                Start = _selectedDate.Date.AddHours(9), // Default to 9 AM
                End = _selectedDate.Date.AddHours(10),  // Default to 1 hour duration
                UserId = LoginForm.LoggedInUser.UserId
            };

            // Show the appointment editor
            var editorForm = new AppointmentEditorForm(appointment, true);
            if (editorForm.ShowDialog() == DialogResult.OK)
            {
                // Refresh the calendar and appointments
                UpdateCalendarDisplay();
                LoadSelectedDayAppointments();
            }
        }

        private void UpdateCalendarDisplay()
        {
            // Clear existing calendar buttons
            pnlCalendar.Controls.Clear();

            // Get the first day of the month
            DateTime firstDayOfMonth = new DateTime(_displayMonth.Year, _displayMonth.Month, 1);

            // Determine what day of the week the first day is (0 = Sunday, 1 = Monday, etc.)
            int firstDayOfWeek = (int)firstDayOfMonth.DayOfWeek;

            // Get the number of days in the month
            int daysInMonth = DateTime.DaysInMonth(_displayMonth.Year, _displayMonth.Month);

            // Get appointments for the month to highlight days with appointments
            var appointmentsInMonth = GetAppointmentsForMonth(_displayMonth);
            var daysWithAppointments = appointmentsInMonth.Select(a => a.Start.Date).Distinct().ToList();

            // Create day buttons
            for (int day = 1; day <= daysInMonth; day++)
            {
                // Create a date for this day
                DateTime currentDate = new DateTime(_displayMonth.Year, _displayMonth.Month, day);

                // Create a button for this day
                Button dayButton = new Button
                {
                    Text = day.ToString(),
                    Size = new Size(40, 40),
                    Tag = currentDate, // Store the date in the Tag property
                    FlatStyle = FlatStyle.Flat
                };

                // Set the position (0 = Sunday, 1 = Monday, etc.)
                int position = day + firstDayOfWeek - 1;
                int row = position / 7;
                int col = position % 7;
                dayButton.Location = new Point(col * 40, row * 40);

                // Style the button based on properties
                if (currentDate.Date == DateTime.Today.Date)
                {
                    dayButton.BackColor = Color.LightBlue; // Today's date
                    dayButton.Font = new Font(dayButton.Font, FontStyle.Bold);
                }
                else if (currentDate.Date == _selectedDate.Date)
                {
                    dayButton.BackColor = Color.FromArgb(214, 233, 248); // Selected date
                }

                // Check if this day has any appointments
                if (daysWithAppointments.Contains(currentDate.Date))
                {
                    dayButton.ForeColor = Color.FromArgb(0, 120, 212);
                    dayButton.Font = new Font(dayButton.Font, FontStyle.Bold);
                }

                // Add click event handler
                dayButton.Click += DayButton_Click;

                // Add the button to the panel
                pnlCalendar.Controls.Add(dayButton);
            }
        }

        private void UpdateMonthDisplay()
        {
            // Update the month/year label
            lblMonthYear.Text = _displayMonth.ToString("MMMM yyyy");
        }

        private void DayButton_Click(object sender, EventArgs e)
        {
            // Update the selected date
            Button clickedButton = (Button)sender;
            _selectedDate = (DateTime)clickedButton.Tag;

            // Update the UI
            UpdateCalendarDisplay();
            LoadSelectedDayAppointments();
        }

        private void LoadSelectedDayAppointments()
        {
            try
            {
                // Update the selected date display
                lblSelectedDate.Text = _selectedDate.ToString("dddd, MMMM d, yyyy");

                // Get appointments for the selected day
                _selectedDateAppointments = GetAppointmentsForDay(_selectedDate);

                // Clear the DataGridView
                dgvAppointments.DataSource = null;
                dgvAppointments.Rows.Clear();

                if (_selectedDateAppointments.Count > 0)
                {
                    // Convert appointment times from database (UTC) to user's local time
                    foreach (var appointment in _selectedDateAppointments)
                    {
                        // Ensure UTC kind is set explicitly
                        appointment.Start = DateTime.SpecifyKind(appointment.Start, DateTimeKind.Utc);
                        appointment.End = DateTime.SpecifyKind(appointment.End, DateTimeKind.Utc);

                        // Convert to local time
                        DateTime localStart = TimeZoneInfo.ConvertTimeFromUtc(appointment.Start, TimeZoneInfo.Local);
                        DateTime localEnd = TimeZoneInfo.ConvertTimeFromUtc(appointment.End, TimeZoneInfo.Local);

                        // Use temporary variables for display only - don't modify the original appointment
                        int rowIndex = dgvAppointments.Rows.Add(
                            localStart.ToString("hh:mm tt"),
                            appointment.Title,
                            appointment.Customer?.CustomerName ?? "Unknown",
                            appointment.Type
                        );
                    }
                }

                // Show/hide no appointments message and update buttons
                lblNoAppointments.Visible = _selectedDateAppointments.Count == 0;
                dgvAppointments.Visible = _selectedDateAppointments.Count > 0;
                btnViewDetails.Enabled = false; // Initially disable until an appointment is selected
                _selectedAppointment = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Appointment> GetAppointmentsForMonth(DateTime month)
        {
            try
            {
                // Get the start and end dates for the month
                DateTime startDate = new DateTime(month.Year, month.Month, 1);
                DateTime endDate = startDate.AddMonths(1).AddDays(-1);

                // Query appointments for the current user in this month
                var appointments = Program.DbContext.Appointments
                    .Where(a => a.UserId == LoginForm.LoggedInUser.UserId &&
                           a.Start >= startDate && a.Start <= endDate)
                    .OrderBy(a => a.Start)
                    .ToList();

                return appointments;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving appointments: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Appointment>();
            }
        }

        private List<Appointment> GetAppointmentsForDay(DateTime day)
        {
            try
            {
                // Convert local day to UTC day range for database query
                DateTime startDate = DateTime.SpecifyKind(day.Date, DateTimeKind.Local).ToUniversalTime();
                DateTime endDate = startDate.AddDays(1).AddSeconds(-1);

                // Query appointments for the current user on this day in UTC time
                var appointments = Program.DbContext.Appointments
                    .Where(a => a.UserId == LoginForm.LoggedInUser.UserId &&
                           a.Start >= startDate && a.Start <= endDate)
                    .OrderBy(a => a.Start)
                    .ToList();

                return appointments;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving appointments: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Appointment>();
            }
        }

        // Method to refresh data from outside the control
        public void RefreshData()
        {
            UpdateCalendarDisplay();
            LoadSelectedDayAppointments();
        }
    }
}