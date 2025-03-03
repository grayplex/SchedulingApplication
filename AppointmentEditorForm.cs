using SchedulingApplication.Models;
using SchedulingApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace SchedulingApplication
{
    public partial class AppointmentEditorForm : Form
    {
        private readonly Appointment _appointment;
        private readonly bool _isNewAppointment;
        //private string _validationMessage;
        private List<Customer> _customers;
        private List<string> _appointmentTypes;
        private ContextMenuStrip _commonTimesMenu;
        private ContextMenuStrip _durationMenu;
        //private ContextMenuStrip startTimeMenuUser;
        //private ContextMenuStrip startTimeMenuBusiness;
        //private ContextMenuStrip endTimeMenuUser;
        //private ContextMenuStrip endTimeMenuBusiness;
        //private bool _businessTimezoneActive = false;
        //private TimeZoneInfo _businessTimeZone;
        //private TimeZoneInfo _userTimeZone;
        private readonly Dictionary<Control, bool> _requiredFields = new Dictionary<Control, bool>();
        private readonly Dictionary<Control, Color> _originalColors = new Dictionary<Control, Color>();
        private readonly Color InvalidFieldColor = Color.MistyRose;
        private readonly Color ValidFieldColor = Color.White;
        private readonly Color RequiredLabelColor = Color.FromArgb(192, 0, 0); // Dark red



        public AppointmentEditorForm(Appointment appointment, bool isNewAppointment)
        {
            InitializeComponent();

            // Initialize main properties
            _appointment = appointment;
            _isNewAppointment = isNewAppointment;

            // Set window title
            Text = isNewAppointment ? "Add New Appointment" : "Edit Appointment";
            lblWindowTitle.Text = Text;

            RegisterRequiredFields();

            // Load reference data
            LoadReferenceData();

            // Setup quick menus for time selection
            SetupTimeMenus();

            // Populate fields
            PopulateAppointmentFields();

            // Setup event handlers
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            dtStart.ValueChanged += DtStart_ValueChanged;
            //rbUserTimezone.CheckedChanged += RbUserTimezone_CheckedChanged;
            //rbBusinessTimezone.CheckedChanged += RbBusinessTimezone_CheckedChanged;
            txtTitle.TextChanged += RequiredField_Changed;
            txtDescription.TextChanged += RequiredField_Changed;
            txtLocation.TextChanged += RequiredField_Changed;
            txtContact.TextChanged += RequiredField_Changed;
            txtUrl.TextChanged += RequiredField_Changed;
            cboCustomer.SelectedIndexChanged += RequiredField_Changed;
            cboType.SelectedIndexChanged += RequiredField_Changed;

            ValidateAllFields();
        }

        private void RegisterRequiredFields()
        {
            _requiredFields[txtTitle] = false;
            _requiredFields[txtDescription] = false;
            _requiredFields[txtLocation] = false;
            _requiredFields[txtContact] = false;
            _requiredFields[txtUrl] = false;
            _requiredFields[cboCustomer] = false;
            _requiredFields[cboType] = false;

            // store original colors
            foreach (var control in _requiredFields.Keys)
            {
                _originalColors[control] = control.BackColor;
            }

            // Style the labels
            StyleRequiredFieldLabels();
        }

        private void StyleRequiredFieldLabels()
        {
            // Add asterisks and make required field labels red
            lblTitle.Text += " *";
            lblTitle.ForeColor = RequiredLabelColor;

            lblDescription.Text += " *";
            lblDescription.ForeColor = RequiredLabelColor;

            lblLocation.Text += " *";
            lblLocation.ForeColor = RequiredLabelColor;

            lblContact.Text += " *";
            lblContact.ForeColor = RequiredLabelColor;

            lblUrl.Text += " *";
            lblUrl.ForeColor = RequiredLabelColor;

            lblCustomer.Text += " *";
            lblCustomer.ForeColor = RequiredLabelColor;

            lblType.Text += " *";
            lblType.ForeColor = RequiredLabelColor;

            // Add a legend for required fields
            Label lblRequiredLegend = new Label
            {
                Text = "* Required Field",
                ForeColor = RequiredLabelColor,
                AutoSize = true,
                Location = new Point(20, 590)
            };
            this.pnlContent.Controls.Add(lblRequiredLegend);
        }

        private void RequiredField_Changed(object sender, EventArgs e)
        {
            if (sender is Control control && _requiredFields.ContainsKey(control))
            {
                ValidateControl(control);
                UpdateSaveButtonState();
            }
        }

        private void ValidateControl(Control control)
        {
            bool isValid = false;

            if (control is TextBox textBox)
            {
                isValid = !string.IsNullOrWhiteSpace(textBox.Text);
            }
            else if (control is ComboBox comboBox)
            {
                isValid = comboBox.SelectedItem != null;
            }

            // Update the control's appearance
            control.BackColor = isValid ? ValidFieldColor : InvalidFieldColor;

            // Update validation state
            _requiredFields[control] = isValid;
        }

        private void ValidateAllFields()
        {
            foreach (var control in _requiredFields.Keys.ToList())
            {
                ValidateControl(control);
            }
            UpdateSaveButtonState();
        }

        private void UpdateSaveButtonState()
        {
            // Enable the save button only if all required fields are valid
            btnSave.Enabled = _requiredFields.Values.All(valid => valid);
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

                    // Set type (with fallback if not in the list)
                    if (!string.IsNullOrEmpty(_appointment.Type) && _appointmentTypes.Contains(_appointment.Type))
                    {
                        cboType.SelectedItem = _appointment.Type;
                    }
                    else if (!string.IsNullOrEmpty(_appointment.Type))
                    {
                        // Add the custom type if it's not in the standard list
                        _appointmentTypes.Add(_appointment.Type);
                        cboType.DataSource = null;
                        cboType.DataSource = _appointmentTypes;
                        cboType.SelectedItem = _appointment.Type;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reference data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupTimeMenus()
        {
            // Create context menus for time selection
            _commonTimesMenu = new ContextMenuStrip();
            _durationMenu = new ContextMenuStrip();

            // Create time options that reflect business hours in the current timezone
            UpdateTimeMenuOptions();

            // Common business hour start times (in local timezone)
            /*
            _commonTimesMenu.Items.Add("9:00 AM", null, (s, e) => SetTimeOnly(dtStart, 9, 0));
            _commonTimesMenu.Items.Add("10:00 AM", null, (s, e) => SetTimeOnly(dtStart, 10, 0));
            _commonTimesMenu.Items.Add("11:00 AM", null, (s, e) => SetTimeOnly(dtStart, 11, 0));
            _commonTimesMenu.Items.Add("12:00 PM", null, (s, e) => SetTimeOnly(dtStart, 12, 0));
            _commonTimesMenu.Items.Add("1:00 PM", null, (s, e) => SetTimeOnly(dtStart, 13, 0));
            _commonTimesMenu.Items.Add("2:00 PM", null, (s, e) => SetTimeOnly(dtStart, 14, 0));
            _commonTimesMenu.Items.Add("3:00 PM", null, (s, e) => SetTimeOnly(dtStart, 15, 0));
            _commonTimesMenu.Items.Add("4:00 PM", null, (s, e) => SetTimeOnly(dtStart, 16, 0));
            */

            // Common durations
            _durationMenu.Items.Add("30 Minutes", null, (s, e) => SetDuration(30));
            _durationMenu.Items.Add("1 Hour", null, (s, e) => SetDuration(60));
            _durationMenu.Items.Add("1.5 Hours", null, (s, e) => SetDuration(90));
            _durationMenu.Items.Add("2 Hours", null, (s, e) => SetDuration(120));

            // Assign menus to date time pickers
            dtStart.ContextMenuStrip = _commonTimesMenu;
            dtEnd.ContextMenuStrip = _durationMenu;

            // Subscribe to Timezone change event
            TimeZoneHelper.TimezonePreferenceChanged += (s, e) => UpdateTimeMenuOptions();
        }

        private void UpdateTimeMenuOptions()
        {
            // Clear existing items
            _commonTimesMenu.Items.Clear();

            // Business hours in UTC (14:00 - 22:00)
            DateTime utcBusinessStart = DateTime.SpecifyKind(DateTime.UtcNow.Date.AddHours(14), DateTimeKind.Utc);
            DateTime utcBusinessEnd = DateTime.SpecifyKind(DateTime.UtcNow.Date.AddHours(22), DateTimeKind.Utc);

            // Convert UTC business hours to the active timezone
            DateTime localBusinessStart = TimeZoneHelper.ConvertFromUtc(utcBusinessStart);
            DateTime localBusinessEnd = TimeZoneHelper.ConvertFromUtc(utcBusinessEnd);

            // Get hour range in local timezone
            int startHour = localBusinessStart.Hour;
            int endHour = localBusinessEnd.Hour;

            // Create menu items for each hour in the business hour range
            for (int hour = startHour; hour < endHour; hour++)
            {
                int displayHour = hour > 12 ? hour - 12 : hour;
                string amPm = hour >= 12 ? "PM" : "AM";
                string timeText = $"{displayHour}:00 {amPm}";

                // For 12 AM/PM special case
                if (displayHour == 0)
                {
                    timeText = $"12:00 {amPm}";
                }

                // Create the menu item with a closure to capture the current hour
                int capturedHour = hour;
                _commonTimesMenu.Items.Add(timeText, null, (s, e) => SetTimeOnly(dtStart, capturedHour, 0));
            }
        }

        private void PopulateAppointmentFields()
        {
            try
            {
                // If editing existing appointment
                if (!_isNewAppointment)
                {
                    // Populate fields
                    txtTitle.Text = _appointment.Title;
                    txtDescription.Text = _appointment.Description;
                    txtLocation.Text = _appointment.Location;
                    txtContact.Text = _appointment.Contact;
                    txtUrl.Text = _appointment.Url;

                    // Convert from UTC to local for display
                    DateTime localStart = TimeZoneHelper.ConvertFromUtc(_appointment.Start);
                    DateTime localEnd = TimeZoneHelper.ConvertFromUtc(_appointment.End);

                    dtStart.Value = localStart;
                    dtEnd.Value = localEnd;
                }
                else
                {
                    // Default values for new appointments
                    // Start with today's date at 9:00 AM
                    dtStart.Value = DateTime.Today.AddHours(9);
                    dtEnd.Value = DateTime.Today.AddHours(10);  // 1 hour meeting by default
                }

                lblTimezoneSelection.Text = $"Times shown in: {TimeZoneHelper.ActiveTimeZone.DisplayName}";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error populating appointment fields: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper method to set only the time portion while keeping the date
        private void SetTimeOnly(DateTimePicker picker, int hour, int minute)
        {
            DateTime currentDate = picker.Value.Date;
            DateTime newTime = currentDate.AddHours(hour).AddMinutes(minute);
            picker.Value = newTime;
        }

        // Helper method to set the end time based on the start time plus a duration
        private void SetDuration(int minutes)
        {
            dtEnd.Value = dtStart.Value.AddMinutes(minutes);
        }

        private void DtStart_ValueChanged(object sender, EventArgs e)
        {
            // Ensure end time is after start time
            if (dtEnd.Value <= dtStart.Value)
            {
                dtEnd.Value = dtStart.Value.AddHours(1);
            }
        }

        private void DtEnd_ValueChanged(object sender, EventArgs e)
        {
            // Ensure end time is after start time
            if (dtEnd.Value <= dtStart.Value)
            {
                MessageBox.Show("End time must be after start time.", "Invalid Time",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtEnd.Value = dtStart.Value.AddHours(1);
            }
        }

        private bool ValidateAppointment()
        {
            // Clear previous validation
            lblValidation.Text = string.Empty;
            lblValidation.Visible = false;

            // First check if all required fields are valid
            if (!_requiredFields.Values.All(valid => valid))
            {
                lblValidation.Text = "Please fill in all required fields.";
                lblValidation.Visible = true;
                return false;
            }

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

            // Validate business hours
            DateTime startTime, endTime;

            startTime = dtStart.Value;
            endTime = dtEnd.Value;

            // Check for weekday
            if (startTime.DayOfWeek == DayOfWeek.Saturday ||
                startTime.DayOfWeek == DayOfWeek.Sunday ||
                endTime.DayOfWeek == DayOfWeek.Saturday ||
                endTime.DayOfWeek == DayOfWeek.Sunday)
            {
                lblValidation.Text = "Appointments must be on weekdays (Monday through Friday).";
                lblValidation.Visible = true;
                dtStart.Focus();
                return false;
            }

            // Check business hours (9 AM to 5 PM)
            //var businessStart = new TimeSpan(9, 0, 0);
            //var businessEnd = new TimeSpan(17, 0, 0);
            var utcBusnessStart = new TimeSpan(14, 0, 0);
            var utcBusinessEnd = new TimeSpan(22, 0, 0);
            var utcStartTime = TimeZoneHelper.ConvertToUtc(startTime);
            var utcEndTime = TimeZoneHelper.ConvertToUtc(endTime);

            if (utcStartTime.TimeOfDay < utcBusnessStart || utcStartTime.TimeOfDay >= utcBusinessEnd)
            {
                lblValidation.Text = "Appointment start time must be between 9:00 AM and 5:00 PM Eastern Time.";
                lblValidation.Visible = true;
                dtStart.Focus();
                return false;
            }

            if (utcEndTime.TimeOfDay <= utcBusnessStart || utcEndTime.TimeOfDay > utcBusinessEnd)
            {
                lblValidation.Text = "Appointment end time must be between 9:00 AM and 5:00 PM Eastern Time.";
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
            DateTime startUtc, endUtc;

            // Convert local time to UTC
            startUtc = TimeZoneHelper.ConvertToUtc(dtStart.Value);
            endUtc = TimeZoneHelper.ConvertToUtc(dtEnd.Value);

            var overlappingAppointments = Program.DbContext.Appointments
                .Where(a => a.UserId == LoginForm.LoggedInUser.UserId &&
                            a.AppointmentId != _appointment.AppointmentId &&
                            (
                                (a.Start <= startUtc && a.End > startUtc) ||
                                (a.Start < endUtc && a.End >= endUtc) ||
                                (a.Start >= startUtc && a.End <= endUtc)
                            ))
                .ToList();

            if (overlappingAppointments.Any())
            {
                lblValidation.Text = "This appointment overlaps with an existing appointment.";
                lblValidation.Visible = true;

                // Show details of the overlapping appointment
                var overlap = overlappingAppointments.First();
                DateTime overlapStartLocal = TimeZoneHelper.ConvertFromUtc(overlap.Start);
                DateTime overlapEndLocal = TimeZoneHelper.ConvertFromUtc(overlap.End);

                MessageBox.Show(
                    $"Overlapping appointment found:\n" +
                    $"Title: {overlap.Title}\n" +
                    $"Time: {overlapStartLocal:MM/dd/yyyy hh:mm tt} - {overlapEndLocal:hh:mm tt}",
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
                // Validate all fields first
                ValidateAllFields();

                // Validate appointment
                if (!ValidateAppointment())
                {
                    return;
                }

                // Convert from display time to UTC for storage
                _appointment.Start = TimeZoneHelper.ConvertToUtc(dtStart.Value);
                _appointment.End = TimeZoneHelper.ConvertToUtc(dtEnd.Value);

                // Update appointment properties
                _appointment.CustomerId = (int)cboCustomer.SelectedValue;
                _appointment.UserId = LoginForm.LoggedInUser.UserId;
                _appointment.Title = txtTitle.Text.Trim();
                _appointment.Description = txtDescription.Text.Trim();
                _appointment.Location = txtLocation.Text.Trim();
                _appointment.Contact = txtContact.Text.Trim();
                _appointment.Type = cboType.Text;
                _appointment.Url = txtUrl.Text.Trim();

                // Set audit fields
                if (_isNewAppointment)
                {
                    _appointment.CreateDate = DateTime.UtcNow;
                    _appointment.CreatedBy = LoginForm.LoggedInUser.UserName;
                }

                _appointment.LastUpdate = DateTime.UtcNow;
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
                            Program.DbContext.Entry(existingAppointment).CurrentValues.SetValues(_appointment);
                            if (existingAppointment == null)
                            {
                                throw new Exception("Appointment not found.");
                            }
                            /*
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
                            */
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