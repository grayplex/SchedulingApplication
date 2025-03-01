using SchedulingApplication.Models;
using SchedulingApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace SchedulingApplication
{
    public partial class AppointmentsUserControl : UserControl
    {
        private List<Appointment> _appointments;
        private Appointment _selectedAppointment;

        public AppointmentsUserControl()
        {
            InitializeComponent();

            // Subscribe to timezone changes
            TimeZoneHelper.TimezonePreferenceChanged += (s, e) => LoadAppointments();

            // Setup event handlers
            cbTimeFilter.SelectedIndexChanged += FilterChanged;
            dtStart.ValueChanged += FilterChanged;
            dtEnd.ValueChanged += FilterChanged;
            btnAddAppointment.Click += BtnAddAppointment_Click;
            btnViewDetails.Click += BtnViewDetails_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            dgvAppointments.CellClick += DgvAppointments_CellClick;
            dgvAppointments.CellDoubleClick += DgvAppointments_CellDoubleClick;

            // Initialize time filter options
            cbTimeFilter.Items.AddRange(new string[] {
                "All Appointments",
                "This Week",
                "This Month",
                "By Date Range"
            });
            //cbTimeFilter.SelectedIndex = 1; // Default to This Week
            cbTimeFilter.SelectedIndex = 0; // All appointments for testing

            // Set date pickers to current values
            dtStart.Value = DateTime.Today;
            dtEnd.Value = DateTime.Today.AddDays(7);

            // Initial load
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            try
            {
                var query = Program.DbContext.Appointments
                    .Include(a => a.Customer)
                    .Include(a => a.User)
                    .Where(a => a.UserId == LoginForm.LoggedInUser.UserId);

                // Apply filter based on selected option
                switch (cbTimeFilter.SelectedItem.ToString())
                {
                    case "This Week":
                        var today = DateTime.Today;
                        var startOfWeek = today.AddDays(-(int)today.DayOfWeek);
                        var endOfWeek = startOfWeek.AddDays(7);

                        // Convert local dates to UTC for database query
                        var startOfWeekUtc = TimeZoneHelper.ConvertToUtc(startOfWeek);
                        var endOfWeekUtc = TimeZoneHelper.ConvertToUtc(endOfWeek);

                        query = query.Where(a => a.Start >= startOfWeekUtc && a.Start < endOfWeekUtc);
                        break;

                    case "This Month":
                        var startOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                        var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

                        // Convert local dates to UTC for database query
                        var startOfMonthUtc = TimeZoneHelper.ConvertToUtc(startOfMonth);
                        var endOfMonthUtc = TimeZoneHelper.ConvertToUtc(endOfMonth);

                        query = query.Where(a => a.Start >= startOfMonthUtc && a.Start <= endOfMonthUtc);
                        break;

                    case "By Date Range":
                        // Convert selected dates to UTC for database query
                        var startDateUtc = TimeZoneHelper.ConvertToUtc(dtStart.Value.Date);
                        var endDateUtc = TimeZoneHelper.ConvertToUtc(dtEnd.Value.Date.AddDays(1).AddSeconds(-1));

                        query = query.Where(a => a.Start >= startDateUtc && a.Start <= endDateUtc);
                        break;
                }

                // Order and execute query
                _appointments = query.OrderBy(a => a.Start).ToList();

                // Clear existing rows
                dgvAppointments.Rows.Clear();

                // Populate grid with data
                foreach (var appt in _appointments)
                {
                    dgvAppointments.Rows.Add(
                        appt.AppointmentId,
                        appt.Title,
                        appt.Customer?.CustomerName ?? "Unknown",
                        appt.Type,
                        appt.DisplayStartDateTime,
                        appt.DisplayEndDateTime,
                        appt.Location
                    );
                }

                // Update button states
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            // Enable/disable date range fields
            bool useDateRange = cbTimeFilter.SelectedItem.ToString() == "By Date Range";
            dtStart.Enabled = useDateRange;
            dtEnd.Enabled = useDateRange;

            // Reload appointments with current filter
            LoadAppointments();
        }

        private void BtnAddAppointment_Click(object sender, EventArgs e)
        {
            // Create a new appointment for the current user
            var appointment = new Appointment
            {
                Start = DateTime.UtcNow, // Will be converted to local in the form
                End = DateTime.UtcNow.AddHours(1),
                UserId = LoginForm.LoggedInUser.UserId
            };

            var editorForm = new AppointmentEditorForm(appointment, true);
            if (editorForm.ShowDialog() == DialogResult.OK)
            {
                // Refresh appointments
                LoadAppointments();
            }
        }

        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            if (_selectedAppointment != null)
            {
                var detailsForm = new AppointmentDetailsForm(_selectedAppointment);
                detailsForm.ShowDialog();

                // Refresh in case the appointment was edited from the details screen
                LoadAppointments();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedAppointment != null)
            {
                var editorForm = new AppointmentEditorForm(_selectedAppointment, false);
                if (editorForm.ShowDialog() == DialogResult.OK)
                {
                    // Refresh appointments
                    LoadAppointments();
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedAppointment != null)
            {
                var result = MessageBox.Show(
                    $"Are you sure you want to delete the appointment '{_selectedAppointment.Title}'?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Remove the appointment from the database
                        var appointmentToRemove = Program.DbContext.Appointments
                            .Find(_selectedAppointment.AppointmentId);

                        if (appointmentToRemove != null)
                        {
                            Program.DbContext.Appointments.Remove(appointmentToRemove);
                            Program.DbContext.SaveChanges();

                            // Refresh appointments
                            LoadAppointments();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting appointment: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DgvAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _appointments.Count)
            {
                _selectedAppointment = _appointments[e.RowIndex];
                UpdateButtonStates();
            }
        }

        private void DgvAppointments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _appointments.Count)
            {
                _selectedAppointment = _appointments[e.RowIndex];
                BtnViewDetails_Click(sender, e);
            }
        }

        private void UpdateButtonStates()
        {
            bool appointmentSelected = _selectedAppointment != null;
            btnViewDetails.Enabled = appointmentSelected;
            btnEdit.Enabled = appointmentSelected;
            btnDelete.Enabled = appointmentSelected;
        }

        // Method to refresh data from outside the control
        public void RefreshData()
        {
            LoadAppointments();
        }
    }
}