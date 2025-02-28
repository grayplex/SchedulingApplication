using SchedulingApplication.Models;
using SchedulingApplication.Utilities;
using System;
using System.Data;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SchedulingApplication
{
    public partial class AppointmentDetailsForm : Form
    {
        private Appointment _appointment;

        public AppointmentDetailsForm(Appointment appointment)
        {
            InitializeComponent();
            _appointment = appointment;
            LoadAppointmentDetails();
        }

        private void LoadAppointmentDetails()
        {
            try
            {
                // Set the title
                this.Text = $"Appointment Details - {_appointment.Title}";

                // Basic Information
                lblAppointmentId.Text = _appointment.AppointmentId.ToString();
                lblTitle.Text = _appointment.Title;
                lblCustomer.Text = _appointment.Customer?.CustomerName ?? "Unknown";
                lblConsultant.Text = _appointment.User?.UserName ?? "Unknown";
                lblType.Text = _appointment.Type;

                // Ensure times are treated as UTC from database
                DateTime utcStart = DateTime.SpecifyKind(_appointment.Start, DateTimeKind.Utc);
                DateTime utcEnd = DateTime.SpecifyKind(_appointment.End, DateTimeKind.Utc);

                // Convert to user's local time for display
                DateTime localStart = utcStart.ToLocalTime();
                DateTime localEnd = utcEnd.ToLocalTime();

                // Display times in user's timezone
                lblStart.Text = localStart.ToString("MM/dd/yyyy hh:mm tt");
                lblEnd.Text = localEnd.ToString("MM/dd/yyyy hh:mm tt");
                lblTimeZone.Text = $"(Time Zone: {TimeZoneInfo.Local.DisplayName})";

                // Additional Details
                txtDescription.Text = _appointment.Description;
                lblLocation.Text = _appointment.Location;
                lblContact.Text = _appointment.Contact;
                lblUrl.Text = _appointment.Url;

                // Audit Information
                lblCreatedBy.Text = $"{_appointment.CreatedBy} on {_appointment.CreateDate.ToString("MM/dd/yyyy hh:mm tt")}";
                lblLastUpdated.Text = $"{_appointment.LastUpdateBy} on {_appointment.LastUpdate.ToString("MM/dd/yyyy hh:mm tt")}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointment details: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Open the appointment editor
            var editorForm = new AppointmentEditorForm(_appointment, false);
            if (editorForm.ShowDialog() == DialogResult.OK)
            {
                // Reload the details
                LoadAppointmentDetails();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}