using SchedulingApplication.Models;
using SchedulingApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SchedulingApplication
{
    public partial class AppointmentAlertForm : Form
    {
        private List<Appointment> _upcomingAppointments;

        public AppointmentAlertForm(List<Appointment> upcomingAppointments)
        {
            InitializeComponent();
            _upcomingAppointments = upcomingAppointments;

            // Set form title
            this.Text = "Upcoming Appointment Alert";
            lblHeader.Text = "Upcoming Appointment Alert";

            // Populate the list view
            PopulateAppointmentsList();

            // Setup event handlers
            btnViewDetails.Click += BtnViewDetails_Click;
            btnClose.Click += BtnClose_Click;
        }

        private void PopulateAppointmentsList()
        {
            // Clear existing items
            lstAppointments.Items.Clear();

            // Populate list with appointments
            foreach (var appointment in _upcomingAppointments)
            {
                var item = new ListViewItem(new[] {
                    appointment.LocalStartTime,
                    appointment.Title,
                    appointment.Customer?.CustomerName ?? "Unknown Customer"
                });

                // Style the item
                item.Font = new Font(lstAppointments.Font, FontStyle.Bold);

                lstAppointments.Items.Add(item);
            }

            // Update appointments count label
            lblAppointmentCount.Text = $"Upcoming Appointments: {_upcomingAppointments.Count}";

            // Add additional information about timeframe
            if (_upcomingAppointments.Count > 0)
            {
                // Calculate minutes until first appointment
                var firstAppt = _upcomingAppointments[0];
                var minutesUntil = (int)(firstAppt.LocalStart - DateTime.Now).TotalMinutes;

                lblHeader.Text += $" - {minutesUntil} minute{(minutesUntil != 1 ? "s" : "")} from now";
            }
        }

        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            // If there are appointments, show details of the first one
            if (_upcomingAppointments.Count > 0)
            {
                var detailsForm = new AppointmentDetailsForm(_upcomingAppointments[0]);
                detailsForm.ShowDialog(this);
            }

            // Close this alert window
            Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}