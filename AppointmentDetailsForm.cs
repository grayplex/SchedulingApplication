﻿using SchedulingApplication.Models;
using SchedulingApplication.Utilities;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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
                lblType.Text = _appointment.Type ?? "";

                // Times - Display in user's local time
                lblStart.Text = _appointment.DisplayStartDateTime;
                lblEnd.Text = _appointment.DisplayEndDateTime;

                // Add timezone information
                TimeZoneInfo userTimeZone = TimeZoneHelper.ActiveTimeZone;
                lblTimeZone.Text = $"(Time Zone: {userTimeZone.DisplayName})";

                // Additional Details
                txtDescription.Text = _appointment.Description;
                lblLocation.Text = _appointment.Location ?? "";
                lblContact.Text = _appointment.Contact ?? "";
                lblUrl.Text = _appointment.Url ?? "";

                // Add business hours indicator
                if (!_appointment.IsWithinBusinessHours)
                {
                    pnlWarning.Visible = true;
                    lblTimeZone.Location = new Point(lblTimeZone.Location.X, lblTimeZone.Location.Y + 20);
                    lblEnd.Location = new Point(lblEnd.Location.X, lblEnd.Location.Y + 20);
                    lblStart.Location = new Point(lblStart.Location.X, lblStart.Location.Y + 20);
                    lblEndLabel.Location = new Point(lblEndLabel.Location.X, lblEndLabel.Location.Y + 20);
                    lblStartLabel.Location = new Point(lblStartLabel.Location.X, lblStartLabel.Location.Y + 20);
                }

                // Audit Information
                lblCreatedBy.Text = $"{_appointment.CreatedBy} on {_appointment.CreateDate}";
                lblLastUpdated.Text = $"{_appointment.LastUpdateBy} on {_appointment.LastUpdate}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointment details: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            // Open the appointment editor
            var editorForm = new AppointmentEditorForm(_appointment, false);
            if (editorForm.ShowDialog() == DialogResult.OK)
            {
                // If the appointment was edited, refresh this form
                // First, reload the appointment from the database to get updated data
                _appointment = Program.DbContext.Appointments.Find(_appointment.AppointmentId);

                // Reload the details
                LoadAppointmentDetails();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}