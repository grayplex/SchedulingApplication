using SchedulingApplication.Models;
using SchedulingApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace SchedulingApplication
{
    public partial class CustomerAppointmentsForm : Form
    {
        private Customer _customer;
        private List<Appointment> _appointments;
        private Appointment _selectedAppointment;

        public CustomerAppointmentsForm(Customer customer)
        {
            InitializeComponent();
            _customer = customer;

            // Set form title
            this.Text = $"Appointments for {customer.CustomerName}";
            lblCustomerName.Text = customer.CustomerName;

            // Setup event handlers
            cbFilter.SelectedIndexChanged += FilterChanged;
            dgvAppointments.SelectionChanged += DgvAppointments_SelectionChanged;
            dgvAppointments.CellDoubleClick += DgvAppointments_CellDoubleClick;
            btnViewDetails.Click += BtnViewDetails_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnAddAppointment.Click += BtnAddAppointment_Click;
            btnClose.Click += BtnClose_Click;

            // Initialize filter options
            cbFilter.Items.AddRange(new string[] {
                "All",
                "Upcoming",
                "Past",
                "This Month",
                "This Year"
            });
            cbFilter.SelectedIndex = 1; // Default to Upcoming
        }

        private void LoadAppointments()
        {
            try
            {
                // Start with query for this customer's appointments
                var query = Program.DbContext.Appointments
                    .Include(a => a.User)
                    .Where(a => a.CustomerId == _customer.CustomerId);

                // Get current time in UTC for database comparisons
                var nowUtc = DateTime.UtcNow;

                // Get dates for this month and year in UTC
                var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
                var startOfMonthUtc = TimeZoneHelper.LocalToUtc(startOfMonth);
                var endOfMonthUtc = TimeZoneHelper.LocalToUtc(endOfMonth);

                var startOfYear = new DateTime(DateTime.Now.Year, 1, 1);
                var endOfYear = new DateTime(DateTime.Now.Year, 12, 31, 23, 59, 59);
                var startOfYearUtc = TimeZoneHelper.LocalToUtc(startOfYear);
                var endOfYearUtc = TimeZoneHelper.LocalToUtc(endOfYear);

                // Apply filter
                switch (cbFilter.SelectedItem.ToString())
                {
                    case "Upcoming":
                        query = query.Where(a => a.Start >= nowUtc);
                        break;
                    case "Past":
                        query = query.Where(a => a.Start < nowUtc);
                        break;
                    case "This Month":
                        query = query.Where(a => a.Start >= startOfMonthUtc && a.Start <= endOfMonthUtc);
                        break;
                    case "This Year":
                        query = query.Where(a => a.Start >= startOfYearUtc && a.Start <= endOfYearUtc);
                        break;
                }

                // Order and execute query
                _appointments = query.OrderBy(a => a.Start).ToList();

                // Clear existing rows
                dgvAppointments.Rows.Clear();

                // Populate grid
                foreach (var appt in _appointments)
                {
                    dgvAppointments.Rows.Add(
                        appt.AppointmentId,
                        appt.Title,
                        appt.User?.UserName ?? "Unknown",
                        appt.Type,
                        appt.LocalStartDateTime,
                        appt.LocalEndDateTime,
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
            LoadAppointments();
        }

        private void DgvAppointments_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvAppointments.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < _appointments.Count)
                {
                    _selectedAppointment = _appointments[selectedIndex];
                    UpdateButtonStates();
                }
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

        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            if (_selectedAppointment != null)
            {
                var detailsForm = new AppointmentDetailsForm(_selectedAppointment);
                detailsForm.ShowDialog(this);

                // Refresh after viewing in case it was edited
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
                        var appointmentToRemove = Program.DbContext.Appointments
                            .Find(_selectedAppointment.AppointmentId);

                        if (appointmentToRemove != null)
                        {
                            Program.DbContext.Appointments.Remove(appointmentToRemove);
                            Program.DbContext.SaveChanges();

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

        private void BtnAddAppointment_Click(object sender, EventArgs e)
        {
            // Create a new appointment for this customer
            // Default to starting now and lasting 1 hour
            var startTime = DateTime.Now;
            var endTime = startTime.AddHours(1);

            // Convert to UTC for storage
            var startUtc = TimeZoneHelper.LocalToUtc(startTime);
            var endUtc = TimeZoneHelper.LocalToUtc(endTime);

            var appointment = new Appointment
            {
                CustomerId = _customer.CustomerId,
                UserId = LoginForm.LoggedInUser.UserId,
                Start = startUtc,
                End = endUtc
            };

            var editorForm = new AppointmentEditorForm(appointment, true);
            if (editorForm.ShowDialog() == DialogResult.OK)
            {
                LoadAppointments();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            LoadAppointments();
        }
    }
}