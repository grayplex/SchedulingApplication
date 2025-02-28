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
        private ContextMenuStrip startTimeMenuUser;
        private ContextMenuStrip startTimeMenuBusiness;
        private ContextMenuStrip endTimeMenuUser;
        private ContextMenuStrip endTimeMenuBusiness;

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

            SetupTimezoneOptions();

            // Setup event handlers
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            dtStart.ValueChanged += DtStart_ValueChanged;
        }

        // Helper method to set only the time portion while keeping the date
        private void SetTimeOnly(DateTimePicker picker, int hour, int minute, bool isPM)
        {
            DateTime currentDate = picker.Value.Date;
            DateTime newTime = currentDate.AddHours(isPM && hour != 12 ? hour + 12 : hour).AddMinutes(minute);
            picker.Value = newTime;
        }

        // Helper method to set the end time based on the start time plus a duration
        private void SetDuration(int minutes)
        {
            dtEnd.Value = dtStart.Value.AddMinutes(minutes);
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

        private void SetupTimezoneOptions()
        {
            // Get the user's timezone info
            TimeZoneInfo userTimeZone = TimeZoneHelper.GetUserTimeZone();

            // Update the radio button text to show the actual timezone
            rbUserTimezone.Text = $"User's Timezone ({userTimeZone.DisplayName})";

            // Create the context menus for the user's timezone
            startTimeMenuUser = new ContextMenuStrip();
            startTimeMenuUser.Items.Add("9:00 AM", null, (s, e) => SetUserTimeFromBusiness(9, 0));
            startTimeMenuUser.Items.Add("10:00 AM", null, (s, e) => SetUserTimeFromBusiness(10, 0));
            startTimeMenuUser.Items.Add("11:00 AM", null, (s, e) => SetUserTimeFromBusiness(11, 0));
            startTimeMenuUser.Items.Add("12:00 PM", null, (s, e) => SetUserTimeFromBusiness(12, 0));
            startTimeMenuUser.Items.Add("1:00 PM", null, (s, e) => SetUserTimeFromBusiness(13, 0));
            startTimeMenuUser.Items.Add("2:00 PM", null, (s, e) => SetUserTimeFromBusiness(14, 0));
            startTimeMenuUser.Items.Add("3:00 PM", null, (s, e) => SetUserTimeFromBusiness(15, 0));
            startTimeMenuUser.Items.Add("4:00 PM", null, (s, e) => SetUserTimeFromBusiness(16, 0));

            // Create context menu for business hours
            startTimeMenuBusiness = new ContextMenuStrip();
            startTimeMenuBusiness.Items.Add("9:00 AM", null, (s, e) => SetTimeOnly(dtStart, 9, 0, false));
            startTimeMenuBusiness.Items.Add("10:00 AM", null, (s, e) => SetTimeOnly(dtStart, 10, 0, false));
            startTimeMenuBusiness.Items.Add("11:00 AM", null, (s, e) => SetTimeOnly(dtStart, 11, 0, false));
            startTimeMenuBusiness.Items.Add("12:00 PM", null, (s, e) => SetTimeOnly(dtStart, 12, 0, true));
            startTimeMenuBusiness.Items.Add("1:00 PM", null, (s, e) => SetTimeOnly(dtStart, 1, 0, true));
            startTimeMenuBusiness.Items.Add("2:00 PM", null, (s, e) => SetTimeOnly(dtStart, 2, 0, true));
            startTimeMenuBusiness.Items.Add("3:00 PM", null, (s, e) => SetTimeOnly(dtStart, 3, 0, true));
            startTimeMenuBusiness.Items.Add("4:00 PM", null, (s, e) => SetTimeOnly(dtStart, 4, 0, true));

            // Create context menus for duration
            endTimeMenuUser = new ContextMenuStrip();
            endTimeMenuUser.Items.Add("30 Minutes", null, (s, e) => SetDuration(30));
            endTimeMenuUser.Items.Add("1 Hour", null, (s, e) => SetDuration(60));
            endTimeMenuUser.Items.Add("1.5 Hours", null, (s, e) => SetDuration(90));
            endTimeMenuUser.Items.Add("2 Hours", null, (s, e) => SetDuration(120));

            endTimeMenuBusiness = new ContextMenuStrip();
            endTimeMenuBusiness.Items.Add("30 Minutes", null, (s, e) => SetDuration(30));
            endTimeMenuBusiness.Items.Add("1 Hour", null, (s, e) => SetDuration(60));
            endTimeMenuBusiness.Items.Add("1.5 Hours", null, (s, e) => SetDuration(90));
            endTimeMenuBusiness.Items.Add("2 Hours", null, (s, e) => SetDuration(120));

            // Set initial context menus based on selected radio button
            UpdateContextMenus();

            // Add event handlers for radio button changes
            rbUserTimezone.CheckedChanged += (s, e) => UpdateContextMenus();
            rbBusinessTimezone.CheckedChanged += (s, e) => UpdateContextMenus();
        }

        private void UpdateContextMenus()
        {
            if (rbUserTimezone.Checked)
            {
                dtStart.ContextMenuStrip = startTimeMenuUser;
                dtEnd.ContextMenuStrip = endTimeMenuUser;
            }
            else
            {
                dtStart.ContextMenuStrip = startTimeMenuBusiness;
                dtEnd.ContextMenuStrip = endTimeMenuBusiness;
            }
        }

        private void SetUserTimeFromBusiness(int businessHour, int minute)
        {
            // Create a DateTime in business timezone (Eastern Time)
            TimeZoneInfo businessTZ = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime businessDateTime = DateTime.Now.Date.AddHours(businessHour).AddMinutes(minute);

            // Convert to UTC then to user's local time
            DateTime userDateTime = TimeZoneInfo.ConvertTime(businessDateTime, businessTZ, TimeZoneHelper.GetUserTimeZone());

            // Keep the date part from the current dtStart but use the time from our conversion
            DateTime result = dtStart.Value.Date.Add(userDateTime.TimeOfDay);
            dtStart.Value = result;
        }

        private bool ValidateAppointment()
        {
            // Clear previous validation
            lblValidation.Text = string.Empty;
            lblValidation.Visible = false;

            // Validate required fields
            if (cboCustomer.SelectedItem == null)
            {
                lblValidation.Text = "Customer is required.";
                lblValidation.Visible = true;
                cboCustomer.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                lblValidation.Text = "Title is required.";
                lblValidation.Visible = true;
                txtTitle.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                lblValidation.Text = "Description is required.";
                lblValidation.Visible = true;
                txtDescription.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                lblValidation.Text = "Location is required.";
                lblValidation.Visible = true;
                txtLocation.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContact.Text))
            {
                lblValidation.Text = "Contact is required.";
                lblValidation.Visible = true;
                txtContact.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboType.Text))
            {
                lblValidation.Text = "Type is required.";
                lblValidation.Visible = true;
                cboType.Focus();
                return false;
            }

            // URL is not required, but if provided should be valid
            if (!string.IsNullOrWhiteSpace(txtUrl.Text))
            {
                try
                {
                    // Simple URL validation - just check if it's a valid URI format
                    var uri = new Uri(txtUrl.Text);
                }
                catch
                {
                    lblValidation.Text = "URL format is invalid.";
                    lblValidation.Visible = true;
                    txtUrl.Focus();
                    return false;
                }
            }

            // Validate date/time
            if (dtEnd.Value <= dtStart.Value)
            {
                lblValidation.Text = "End time must be after start time.";
                lblValidation.Visible = true;
                dtEnd.Focus();
                return false;
            }

            // Duration should be at least 15 minutes
            TimeSpan duration = dtEnd.Value - dtStart.Value;
            if (duration.TotalMinutes < 15)
            {
                lblValidation.Text = "Appointment must be at least 15 minutes long.";
                lblValidation.Visible = true;
                dtEnd.Focus();
                return false;
            }

            // Validate business hours (in Eastern Time)
            DateTime startEST;
            DateTime endEST;

            // Check which timezone radio button is selected
            if (rbBusinessTimezone.Checked)
            {
                // If business timezone is selected, we can use the values directly
                startEST = dtStart.Value;
                endEST = dtEnd.Value;
            }
            else
            {
                // If user timezone is selected, convert to business timezone
                startEST = TimeZoneHelper.ToBusinessHoursTimeZone(dtStart.Value);
                endEST = TimeZoneHelper.ToBusinessHoursTimeZone(dtEnd.Value);
            }

            // Check for weekday
            if (startEST.DayOfWeek == DayOfWeek.Saturday ||
                startEST.DayOfWeek == DayOfWeek.Sunday ||
                endEST.DayOfWeek == DayOfWeek.Saturday ||
                endEST.DayOfWeek == DayOfWeek.Sunday)
            {
                lblValidation.Text = "Appointments must be on weekdays (Monday through Friday).";
                lblValidation.Visible = true;
                dtStart.Focus();
                return false;
            }

            // Check business hours (9 AM to 5 PM)
            var businessStart = new TimeSpan(9, 0, 0);
            var businessEnd = new TimeSpan(17, 0, 0);

            if (startEST.TimeOfDay < businessStart)
            {
                lblValidation.Text = "Appointment start time must be after 9:00 AM Eastern Time.";
                lblValidation.Visible = true;
                dtStart.Focus();
                return false;
            }

            if (endEST.TimeOfDay > businessEnd)
            {
                lblValidation.Text = "Appointment end time must be before 5:00 PM Eastern Time.";
                lblValidation.Visible = true;
                dtEnd.Focus();
                return false;
            }

            // Display a warning if the appointment is in the past
            if (dtStart.Value < DateTime.Now)
            {
                DialogResult result = MessageBox.Show(
                    "This appointment is scheduled in the past. Are you sure you want to continue?",
                    "Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    return false;
                }
            }

            // Check for overlapping appointments for the same user
            var userStartTime = dtStart.Value;
            var userEndTime = dtEnd.Value;

            var overlappingAppointments = Program.DbContext.Appointments
                .Where(a => a.UserId == LoginForm.LoggedInUser.UserId &&
                            a.AppointmentId != _appointment.AppointmentId &&
                            (
                                (a.Start <= userStartTime && a.End > userStartTime) ||
                                (a.Start < userEndTime && a.End >= userEndTime) ||
                                (a.Start >= userStartTime && a.End <= userEndTime)
                            ))
                .ToList();

            if (overlappingAppointments.Any())
            {
                lblValidation.Text = "This appointment overlaps with an existing appointment.";
                lblValidation.Visible = true;

                // Show details of the overlapping appointment
                var overlap = overlappingAppointments.First();
                DateTime overlapStart = TimeZoneHelper.ToUserTime(overlap.Start);
                DateTime overlapEnd = TimeZoneHelper.ToUserTime(overlap.End);

                MessageBox.Show(
                    $"Overlapping appointment found:\n" +
                    $"Title: {overlap.Title}\n" +
                    $"Time: {overlapStart:MMM d, yyyy h:mm tt} - {overlapEnd:h:mm tt}",
                    "Scheduling Conflict",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

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

        private void DtStart_ValueChanged(object sender, EventArgs e)
        {
            if (dtEnd.Value <= dtStart.Value)
            {
                dtEnd.Value = dtStart.Value.AddHours(1);
            }
        }
    }
}