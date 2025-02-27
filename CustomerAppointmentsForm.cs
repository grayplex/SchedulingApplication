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
                var query = Program.DbContext.Appointments
                    .Include(a => a.User)
                    .Where(a => a.CustomerId == _customer.CustomerId);

                // Apply filter
                switch (cbFilter.SelectedItem.ToString())
                {
                    case "Upcoming":
                        query = query.Where(a => a.Start >= DateTime.Now);
                        break;
                    case "Past":
                        query = query.Where(a => a.Start < DateTime.Now);
                        break;
                    case "This Month":
                        var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                        var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
                        query = query.Where(a => a.Start >= startOfMonth && a.Start <= endOfMonth);
                        break;
                    case "This Year":
                        var startOfYear = new DateTime(DateTime.Now.Year, 1, 1);
                        var endOfYear = new DateTime(DateTime.Now.Year, 12, 31);
                        query = query.Where(a => a.Start >= startOfYear && a.Start <= endOfYear);
                        break;
                }

                // Order and execute query
                _appointments = query.OrderBy(a => a.Start).ToList();

                // Convert times to user's local time
                foreach (var appointment in _appointments)
                {
                    appointment.Start = TimeZoneHelper.ToUserTime(appointment.Start);
                    appointment.End = TimeZoneHelper.ToUserTime(appointment.End);
                }

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
                        appt.Start.ToString("MM/dd/yyyy hh:mm tt"),
                        appt.End.ToString("MM/dd/yyyy hh:mm tt"),
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
            var appointment = new Appointment
            {
                CustomerId = _customer.CustomerId,
                UserId = LoginForm.LoggedInUser.UserId,
                Start = DateTime.Today.AddHours(9), // Default to 9 AM
                End = DateTime.Today.AddHours(10)   // Default to 1 hour duration
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