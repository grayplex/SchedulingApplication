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
    public partial class AppointmentEditorForm : Form
    {
        private Appointment _appointment;
        private bool _isNewAppointment;
        private string _validationMessage;
        private List<Customer> _customers;
        private List<string> _appointmentTypes;

        public AppointmentEditorForm(Appointment appointment, bool isNewAppointment)
        {
            InitializeComponent();

            // Initialize main properties
            _appointment = appointment;
            _isNewAppointment = isNewAppointment;

            // Set window title
            Text = isNewAppointment ? "Add New Appointment" : "Edit Appointment";

            // Load reference data
            LoadReferenceData();

            // Populate fields
            PopulateAppointmentFields();

            // Setup event handlers
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void LoadReferenceData()
        {
            try
            {
                // Load customers
                _customers = Program.DbContext.Customers
                    .Where(c => c.Active)
                    .OrderBy(c => c.CustomerName)
                    .ToList();
                cboCustomer.DataSource = _customers;
                cboCustomer.DisplayMember = "CustomerName";
                cboCustomer.ValueMember = "CustomerId";

                // Appointment types
                _appointmentTypes = new List<string>
                {
                    "Initial Consultation",
                    "Follow-up",
                    "Planning Session",
                    "De-Briefing",
                    "Presentation",
                    "Other"
                };
                cboType.DataSource = _appointmentTypes;

                // If editing, set initial selection
                if (!_isNewAppointment)
                {
                    // Set customer
                    cboCustomer.SelectedValue = _appointment.CustomerId;
                    cboType.SelectedItem = _appointment.Type;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reference data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateAppointmentFields()
        {
            // If editing existing appointment
            if (!_isNewAppointment)
            {
                // Convert times to user's local time
                _appointment.Start = TimeZoneHelper.ToUserTime(_appointment.Start);
                _appointment.End = TimeZoneHelper.ToUserTime(_appointment.End);

                // Populate fields
                txtTitle.Text = _appointment.Title;
                txtDescription.Text = _appointment.Description;
                txtLocation.Text = _appointment.Location;
                txtContact.Text = _appointment.Contact;
                txtUrl.Text = _appointment.Url;

                dtStart.Value = _appointment.Start;
                dtEnd.Value = _appointment.End;
            }
            else
            {
                // Default times for new appointments
                dtStart.Value = DateTime.Today.AddHours(9);  // 9 AM
                dtEnd.Value = DateTime.Today.AddHours(10);   // 10 AM
            }
        }

        private bool ValidateAppointment()
        {
            // Clear previous validation
            lblValidation.Text = string.Empty;

            // Validate required fields
            if (cboCustomer.SelectedItem == null)
            {
                lblValidation.Text = "Customer is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                lblValidation.Text = "Title is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                lblValidation.Text = "Description is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                lblValidation.Text = "Location is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContact.Text))
            {
                lblValidation.Text = "Contact is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboType.Text))
            {
                lblValidation.Text = "Type is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUrl.Text))
            {
                lblValidation.Text = "URL is required.";
                return false;
            }

            // Validate date/time
            if (dtEnd.Value <= dtStart.Value)
            {
                lblValidation.Text = "End time must be after start time.";
                return false;
            }

            // Validate business hours (in Eastern Time)
            var startEST = TimeZoneHelper.ToBusinessHoursTimeZone(dtStart.Value);
            var endEST = TimeZoneHelper.ToBusinessHoursTimeZone(dtEnd.Value);

            // Check for weekday
            if (startEST.DayOfWeek == DayOfWeek.Saturday ||
                startEST.DayOfWeek == DayOfWeek.Sunday ||
                endEST.DayOfWeek == DayOfWeek.Saturday ||
                endEST.DayOfWeek == DayOfWeek.Sunday)
            {
                lblValidation.Text = "Appointments must be on weekdays.";
                return false;
            }

            // Check business hours
            var businessStart = new TimeSpan(9, 0, 0);
            var businessEnd = new TimeSpan(17, 0, 0);

            if (startEST.TimeOfDay < businessStart ||
                startEST.TimeOfDay > businessEnd ||
                endEST.TimeOfDay < businessStart ||
                endEST.TimeOfDay > businessEnd)
            {
                lblValidation.Text = "Appointments must be between 9 AM and 5 PM Eastern Time.";
                return false;
            }

            // Check for overlapping appointments for the same user
            var overlappingAppointments = Program.DbContext.Appointments
                .Where(a => a.UserId == LoginForm.LoggedInUser.UserId &&
                            a.AppointmentId != _appointment.AppointmentId &&
                            (
                                (a.Start <= dtStart.Value && a.End > dtStart.Value) ||
                (a.Start < dtEnd.Value && a.End >= dtEnd.Value) ||
                                (a.Start >= dtStart.Value && a.End <= dtEnd.Value)
                            ))
                .ToList();

            if (overlappingAppointments.Any())
            {
                lblValidation.Text = "This appointment overlaps with an existing appointment.";
                return false;
            }

            return true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate appointment
                if (!ValidateAppointment())
                {
                    return;
                }

                // Convert start and end times from local to UTC
                var startTime = TimeZoneHelper.ToDatabaseTime(dtStart.Value);
                var endTime = TimeZoneHelper.ToDatabaseTime(dtEnd.Value);

                // Update appointment properties
                _appointment.CustomerId = (int)cboCustomer.SelectedValue;
                _appointment.UserId = LoginForm.LoggedInUser.UserId;
                _appointment.Title = txtTitle.Text;
                _appointment.Description = txtDescription.Text;
                _appointment.Location = txtLocation.Text;
                _appointment.Contact = txtContact.Text;
                _appointment.Type = cboType.Text;
                _appointment.Url = txtUrl.Text;
                _appointment.Start = startTime;
                _appointment.End = endTime;

                // Set audit fields
                if (_isNewAppointment)
                {
                    _appointment.CreateDate = DateTime.Now;
                    _appointment.CreatedBy = LoginForm.LoggedInUser.UserName;
                }

                _appointment.LastUpdate = DateTime.Now;
                _appointment.LastUpdateBy = LoginForm.LoggedInUser.UserName;

                // Save to database
                using (var transaction = Program.DbContext.Database.BeginTransaction())
                {
                    try
                    {
                        if (_isNewAppointment)
                        {
                            Program.DbContext.Appointments.Add(_appointment);
                        }
                        else
                        {
                            var existingAppointment = Program.DbContext.Appointments.Find(_appointment.AppointmentId);
                            if (existingAppointment == null)
                            {
                                throw new Exception("Appointment not found.");
                            }

                            // Update all properties
                            existingAppointment.CustomerId = _appointment.CustomerId;
                            existingAppointment.UserId = _appointment.UserId;
                            existingAppointment.Title = _appointment.Title;
                            existingAppointment.Description = _appointment.Description;
                            existingAppointment.Location = _appointment.Location;
                            existingAppointment.Contact = _appointment.Contact;
                            existingAppointment.Type = _appointment.Type;
                            existingAppointment.Url = _appointment.Url;
                            existingAppointment.Start = _appointment.Start;
                            existingAppointment.End = _appointment.End;
                            existingAppointment.LastUpdate = _appointment.LastUpdate;
                            existingAppointment.LastUpdateBy = _appointment.LastUpdateBy;
                        }

                        Program.DbContext.SaveChanges();
                        transaction.Commit();

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Error saving appointment: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}