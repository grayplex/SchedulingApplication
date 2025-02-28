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
        private bool _businessTimezoneActive = false;
        private TimeZoneInfo _businessTimeZone;
        private TimeZoneInfo _userTimeZone;

        public AppointmentEditorForm(Appointment appointment, bool isNewAppointment)
        {
            InitializeComponent();

            // Initialize main properties
            _appointment = appointment;
            _isNewAppointment = isNewAppointment;

            // When loading an appointment
            LogTimeInfo("Original Start from DB", _appointment.Start);
            LogTimeInfo("After UTC conversion", DateTime.SpecifyKind(_appointment.Start, DateTimeKind.Utc));
            LogTimeInfo("After local conversion", TimeZoneInfo.ConvertTimeFromUtc(
                DateTime.SpecifyKind(_appointment.Start, DateTimeKind.Utc),
                TimeZoneInfo.Local));

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
            rbUserTimezone.CheckedChanged += RbUserTimezone_CheckedChanged;
            rbBusinessTimezone.CheckedChanged += RbBusinessTimezone_CheckedChanged;
        }

        private void LogTimeInfo(string label, DateTime time)
        {
            Console.WriteLine($"{label}: {time} - Kind: {time.Kind} - " +
                              $"Local: {TimeZoneInfo.Local.DisplayName} - " +
                              $"UTC Offset: {TimeZoneInfo.Local.GetUtcOffset(time)}");
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
                // Make sure the times are correctly identified as UTC times from the database
                DateTime utcStart = DateTime.SpecifyKind(_appointment.Start, DateTimeKind.Utc);
                DateTime utcEnd = DateTime.SpecifyKind(_appointment.End, DateTimeKind.Utc);

                // Initialize fields based on which timezone is active
                if (rbBusinessTimezone.Checked)
                {
                    // Convert to business time
                    TimeZoneInfo businessTZ = TimeZoneHelper.GetBusinessTimeZone();
                    DateTime businessStart = TimeZoneInfo.ConvertTimeFromUtc(utcStart, businessTZ);
                    DateTime businessEnd = TimeZoneInfo.ConvertTimeFromUtc(utcEnd, businessTZ);

                    // Populate the date pickers
                    dtStart.Value = businessStart;
                    dtEnd.Value = businessEnd;
                }
                else
                {
                    // Convert to user's local time
                    DateTime localStart = TimeZoneInfo.ConvertTimeFromUtc(utcStart, TimeZoneInfo.Local);
                    DateTime localEnd = TimeZoneInfo.ConvertTimeFromUtc(utcEnd, TimeZoneInfo.Local);

                    // Populate the date pickers
                    dtStart.Value = localStart;
                    dtEnd.Value = localEnd;
                }

                // Set other fields
                txtTitle.Text = _appointment.Title;
                txtDescription.Text = _appointment.Description;
                txtLocation.Text = _appointment.Location;
                txtContact.Text = _appointment.Contact;
                txtUrl.Text = _appointment.Url;
            }
            else
            {
                // Default times for new appointments
                if (rbBusinessTimezone.Checked)
                {
                    // Default to 9 AM business time
                    TimeZoneInfo businessTZ = TimeZoneHelper.GetBusinessTimeZone();
                    DateTime businessStart = DateTime.Today.AddHours(9);
                    DateTime businessEnd = businessStart.AddHours(1);

                    dtStart.Value = businessStart;
                    dtEnd.Value = businessEnd;
                }
                else
                {
                    // Default to 9 AM EST converted to local time
                    DateTime estTime = DateTime.Today.AddHours(9);
                    DateTime localStart = TimeZoneHelper.BusinessToUserTime(estTime);

                    dtStart.Value = localStart;
                    dtEnd.Value = localStart.AddHours(1);
                }
            }
        }

        private void SetupTimezoneOptions()
        {
            // Get the timezone information
            _businessTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            _userTimeZone = TimeZoneHelper.GetUserTimeZone();

            // Update the radio button text to show the actual timezone
            rbUserTimezone.Text = $"User's Timezone ({_userTimeZone.DisplayName})";
            rbBusinessTimezone.Text = $"Business (EST)";

            // Set initial state based on the default selection
            _businessTimezoneActive = rbBusinessTimezone.Checked;

            // Create the initial context menus
            CreateContextMenus();

            // Add event handlers for radio button changes
            rbUserTimezone.CheckedChanged += (s, e) => {
                if (rbUserTimezone.Checked)
                {
                    _businessTimezoneActive = false;
                    UpdateTimeDisplays();
                    CreateContextMenus();
                }
            };

            rbBusinessTimezone.CheckedChanged += (s, e) => {
                if (rbBusinessTimezone.Checked)
                {
                    _businessTimezoneActive = true;
                    UpdateTimeDisplays();
                    CreateContextMenus();
                }
            };
        }

        private void CreateContextMenus()
        {
            // Clear existing menus
            startTimeMenuUser?.Dispose();
            startTimeMenuBusiness?.Dispose();
            endTimeMenuUser?.Dispose();
            endTimeMenuBusiness?.Dispose();

            if (_businessTimezoneActive)
            {
                // Create business hours context menu (9am-5pm EST)
                ContextMenuStrip startMenu = new ContextMenuStrip();
                startMenu.Items.Add("9:00 AM", null, (s, e) => SetTimeOnly(dtStart, 9, 0, false));
                startMenu.Items.Add("10:00 AM", null, (s, e) => SetTimeOnly(dtStart, 10, 0, false));
                startMenu.Items.Add("11:00 AM", null, (s, e) => SetTimeOnly(dtStart, 11, 0, false));
                startMenu.Items.Add("12:00 PM", null, (s, e) => SetTimeOnly(dtStart, 12, 0, true));
                startMenu.Items.Add("1:00 PM", null, (s, e) => SetTimeOnly(dtStart, 1, 0, true));
                startMenu.Items.Add("2:00 PM", null, (s, e) => SetTimeOnly(dtStart, 2, 0, true));
                startMenu.Items.Add("3:00 PM", null, (s, e) => SetTimeOnly(dtStart, 3, 0, true));
                startMenu.Items.Add("4:00 PM", null, (s, e) => SetTimeOnly(dtStart, 4, 0, true));
                dtStart.ContextMenuStrip = startMenu;

                // Create duration context menu
                ContextMenuStrip endMenu = new ContextMenuStrip();
                endMenu.Items.Add("30 Minutes", null, (s, e) => SetDuration(30));
                endMenu.Items.Add("1 Hour", null, (s, e) => SetDuration(60));
                endMenu.Items.Add("1.5 Hours", null, (s, e) => SetDuration(90));
                endMenu.Items.Add("2 Hours", null, (s, e) => SetDuration(120));
                dtEnd.ContextMenuStrip = endMenu;
            }
            else
            {
                // Create context menu with business hours converted to user's timezone
                ContextMenuStrip startMenu = new ContextMenuStrip();

                // Convert each business hour to user timezone and add to menu
                for (int hour = 9; hour <= 16; hour++)
                {
                    // Create a business time at the specified hour
                    DateTime businessTime = DateTime.Today.AddHours(hour);

                    // Convert to user's timezone
                    DateTime userTime = TimeZoneHelper.BusinessToUserTime(businessTime);

                    // Format the time string
                    string timeString = userTime.ToString("h:mm tt");

                    // Add to menu - display the user time but when clicked, it will set the equivalent business time
                    int businessHour = hour; // Capture the current hour in the loop
                    startMenu.Items.Add(timeString, null, (s, e) => SetUserTimeFromBusiness(businessHour, 0));
                }
                dtStart.ContextMenuStrip = startMenu;

                // Create duration context menu - same as business
                ContextMenuStrip endMenu = new ContextMenuStrip();
                endMenu.Items.Add("30 Minutes", null, (s, e) => SetDuration(30));
                endMenu.Items.Add("1 Hour", null, (s, e) => SetDuration(60));
                endMenu.Items.Add("1.5 Hours", null, (s, e) => SetDuration(90));
                endMenu.Items.Add("2 Hours", null, (s, e) => SetDuration(120));
                dtEnd.ContextMenuStrip = endMenu;
            }
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
            // Create a business time at the specified hour
            DateTime businessDateTime = DateTime.Today.AddHours(businessHour).AddMinutes(minute);

            // Convert to user's local time
            DateTime userDateTime = TimeZoneHelper.BusinessToUserTime(businessDateTime);

            // Keep the date part from the current dtStart but use the time from our conversion
            DateTime result = dtStart.Value.Date.Add(userDateTime.TimeOfDay);
            dtStart.Value = result;
        }

        private void UpdateTimeDisplays()
        {
            // Store current values
            DateTime currentStartValue = dtStart.Value;
            DateTime currentEndValue = dtEnd.Value;

            // Convert times based on which radio button is selected
            if (rbBusinessTimezone.Checked && !_businessTimezoneActive)
            {
                // Convert from user time to business time
                DateTime businessStart = TimeZoneHelper.UserToBusinessTime(currentStartValue);
                DateTime businessEnd = TimeZoneHelper.UserToBusinessTime(currentEndValue);

                // Update the displayed times - prevent event triggers
                dtStart.ValueChanged -= DtStart_ValueChanged;
                dtEnd.ValueChanged -= DtEnd_ValueChanged;

                dtStart.Value = businessStart;
                dtEnd.Value = businessEnd;

                dtStart.ValueChanged += DtStart_ValueChanged;
                dtEnd.ValueChanged += DtEnd_ValueChanged;

                _businessTimezoneActive = true;
            }
            else if (!rbBusinessTimezone.Checked && _businessTimezoneActive)
            {
                // Convert from business time to user time
                DateTime userStart = TimeZoneHelper.BusinessToUserTime(currentStartValue);
                DateTime userEnd = TimeZoneHelper.BusinessToUserTime(currentEndValue);

                // Update the displayed times - prevent event triggers
                dtStart.ValueChanged -= DtStart_ValueChanged;
                dtEnd.ValueChanged -= DtEnd_ValueChanged;

                dtStart.Value = userStart;
                dtEnd.Value = userEnd;

                dtStart.ValueChanged += DtStart_ValueChanged;
                dtEnd.ValueChanged += DtEnd_ValueChanged;

                _businessTimezoneActive = false;
            }
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
                startEST = TimeZoneHelper.UserToBusinessTime(dtStart.Value);
                endEST = TimeZoneHelper.UserToBusinessTime(dtEnd.Value);
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

                // Get the displayed times
                DateTime startInDisplayedTimezone = dtStart.Value;
                DateTime endInDisplayedTimezone = dtEnd.Value;

                // Convert to UTC for database storage based on which timezone is being displayed
                DateTime startUtc, endUtc;

                LogTimeInfo("Before save - display time", dtStart.Value);
                LogTimeInfo("Before save - UTC time for DB", startInDisplayedTimezone);

                // Convert to UTC for database storage - handling the current timezone context
                if (rbBusinessTimezone.Checked)
                {
                    // Converting from business timezone to UTC
                    TimeZoneInfo businessTz = TimeZoneHelper.GetBusinessTimeZone();

                    // Explicitly use unspecified kind
                    DateTime unspecifiedStart = DateTime.SpecifyKind(startInDisplayedTimezone, DateTimeKind.Unspecified);
                    DateTime unspecifiedEnd = DateTime.SpecifyKind(endInDisplayedTimezone, DateTimeKind.Unspecified);

                    // Direct conversion to UTC
                    startUtc = TimeZoneInfo.ConvertTimeToUtc(unspecifiedStart, businessTz);
                    endUtc = TimeZoneInfo.ConvertTimeToUtc(unspecifiedEnd, businessTz);
                }
                else
                {
                    // Converting from user timezone to UTC
                    TimeZoneInfo userTz = TimeZoneInfo.Local;

                    // Explicitly use unspecified kind
                    DateTime unspecifiedStart = DateTime.SpecifyKind(startInDisplayedTimezone, DateTimeKind.Unspecified);
                    DateTime unspecifiedEnd = DateTime.SpecifyKind(endInDisplayedTimezone, DateTimeKind.Unspecified);

                    // Direct conversion to UTC
                    startUtc = TimeZoneInfo.ConvertTimeToUtc(unspecifiedStart, userTz);
                    endUtc = TimeZoneInfo.ConvertTimeToUtc(unspecifiedEnd, userTz);
                }

                // Log for debugging
                Console.WriteLine($"Saving to DB - Original: {startInDisplayedTimezone} - UTC: {startUtc} - Kind: {startUtc.Kind}");

                // Update appointment with UTC times
                _appointment.Start = startUtc;
                _appointment.End = endUtc;

                // Update appointment properties
                _appointment.CustomerId = (int)cboCustomer.SelectedValue;
                _appointment.UserId = LoginForm.LoggedInUser.UserId;
                _appointment.Title = txtTitle.Text;
                _appointment.Description = txtDescription.Text;
                _appointment.Location = txtLocation.Text;
                _appointment.Contact = txtContact.Text;
                _appointment.Type = cboType.Text;
                _appointment.Url = txtUrl.Text;

                // Set audit fields
                if (_isNewAppointment)
                {
                    _appointment.CreateDate = DateTime.UtcNow;
                    _appointment.CreatedBy = LoginForm.LoggedInUser.UserName;
                }

                _appointment.LastUpdate = DateTime.UtcNow;
                _appointment.LastUpdateBy = LoginForm.LoggedInUser.UserName;

                // Save to database with transaction
                using (var transaction = Program.DbContext.Database.BeginTransaction())
                {
                    try
                    {
                        // Rest of the saving logic...

                        // After successfully saving
                        transaction.Commit();
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
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

        private void DtEnd_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void RbBusinessTimezone_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTimeDisplays();
            UpdateContextMenus();
        }

        private void RbUserTimezone_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTimeDisplays();
            UpdateContextMenus();
        }
    }
}