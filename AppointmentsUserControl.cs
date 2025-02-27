using SchedulingApplication.Models;
using SchedulingApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Drawing2D;
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

            // Setup event handlers
            cbTimeFilter.SelectedIndexChanged += FilterChanged;
            dtStart.ValueChanged += FilterChanged;
            dtEnd.ValueChanged += FilterChanged;
            btnAddAppointment.Click += BtnAddAppointment_Click;
            btnViewDetails.Click += BtnViewDetails_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            dgvAppointments.SelectionChanged += DgvAppointments_SelectionChanged;

            // Initialize time filter options
            cbTimeFilter.Items.AddRange(new string[] {
                "All Appointments",
                "This Week",
                "This Month",
                "By Date Range"
            });
            cbTimeFilter.SelectedIndex = 1; // Default to This Week
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
                        query = query.Where(a => a.Start >= startOfWeek && a.Start < endOfWeek);
                        break;

                    case "This Month":
                        var startOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                        var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
                        query = query.Where(a => a.Start >= startOfMonth && a.Start <= endOfMonth);
                        break;

                    case "By Date Range":
                        query = query.Where(a => a.Start >= dtStart.Value && a.Start <= dtEnd.Value.AddDays(1).AddSeconds(-1));
                        break;
                }

                // Order and execute query
                _appointments = query.OrderBy(a => a.Start).ToList();

                // Convert times to user's local time
                foreach (var appt in _appointments)
                {
                    appt.Start = TimeZoneHelper.ToUserTime(appt.Start);
                    appt.End = TimeZoneHelper.ToUserTime(appt.End);
                }

                // Clear existing rows
                dgvAppointments.Rows.Clear();

                // Populate grid
                foreach (var appt in _appointments)
                {
                    dgvAppointments.Rows.Add(
                        appt.AppointmentId,
                        appt.Title,
                        appt.Customer?.CustomerName ?? "Unknown",
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
            // Enable/disable date range fields
            dtStart.Enabled = cbTimeFilter.SelectedItem.ToString() == "By Date Range";
            dtEnd.Enabled = cbTimeFilter.SelectedItem.ToString() == "By Date Range";

            // Reload appointments with current filter
            LoadAppointments();
        }

        private void BtnAddAppointment_Click(object sender, EventArgs e)
        {
            // Create a new appointment
            var appointment = new Appointment
            {
                Start = DateTime.Today.AddHours(9), // Default to 9 AM
                End = DateTime.Today.AddHours(10),  // Default to 1 hour duration
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

        // Method to refresh data from outside the control
        public void RefreshData()
        {
            LoadAppointments();
        }

        // InitializeComponent method should be designed in the Designer 
        // It will set up the UI elements like:
        // - DataGridView for appointments
        // - Buttons for actions
        // - Time filter dropdown
        // - Date range pickers
        private void InitializeComponent()
        {
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cbTimeFilter = new System.Windows.Forms.ComboBox();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();

            // Configure DataGridView columns
            dgvAppointments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", Visible = false },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Title", HeaderText = "Title" },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Customer", HeaderText = "Customer" },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Type", HeaderText = "Type" },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Start", HeaderText = "Start" },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "End", HeaderText = "End" },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Location", HeaderText = "Location" }
            });

            // Additional UI setup would go here
            // This is a basic template and would need to be fully implemented in the Designer
        }
    }
}