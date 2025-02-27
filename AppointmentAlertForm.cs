using SchedulingApplication.Models;
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
                    appointment.Start.ToString("hh:mm tt"),
                    appointment.Title,
                    appointment.Customer?.CustomerName ?? "Unknown Customer"
                });

                // Style the item
                item.Font = new Font(lstAppointments.Font, FontStyle.Bold);

                lstAppointments.Items.Add(item);
            }

            // Update appointments count label
            lblAppointmentCount.Text = $"Upcoming Appointments: {_upcomingAppointments.Count}";
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

        private void InitializeComponent()
        {
            // Create components
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblAppointmentCount = new System.Windows.Forms.Label();
            this.lstAppointments = new System.Windows.Forms.ListView();
            this.colTime = new System.Windows.Forms.ColumnHeader();
            this.colTitle = new System.Windows.Forms.ColumnHeader();
            this.colCustomer = new System.Windows.Forms.ColumnHeader();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = Color.FromArgb(255, 87, 34); // Orange accent
            this.lblHeader.Dock = DockStyle.Top;
            this.lblHeader.Font = new Font("Arial", 12, FontStyle.Bold);
            this.lblHeader.ForeColor = Color.White;
            this.lblHeader.Padding = new Padding(10);
            this.lblHeader.Text = "Upcoming Appointment Alert";
            this.lblHeader.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // lblAppointmentCount
            // 
            this.lblAppointmentCount.Dock = DockStyle.Top;
            this.lblAppointmentCount.Padding = new Padding(10);
            this.lblAppointmentCount.Text = "Upcoming Appointments: 0";

            // 
            // lstAppointments
            // 
            this.lstAppointments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTime,
            this.colTitle,
            this.colCustomer});
            this.lstAppointments.Dock = DockStyle.Fill;
            this.lstAppointments.FullRowSelect = true;
            this.lstAppointments.GridLines = true;
            this.lstAppointments.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            this.lstAppointments.View = View.Details;

            // 
            // colTime
            // 
            this.colTime.Text = "Time";
            this.colTime.Width = 100;

            // 
            // colTitle
            // 
            this.colTitle.Text = "Title";
            this.colTitle.Width = 200;

            // 
            // colCustomer
            // 
            this.colCustomer.Text = "Customer";
            this.colCustomer.Width = 200;

            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnViewDetails.Location = new Point(300, 350);
            this.btnViewDetails.Text = "View Details";

            // 
            // btnClose
            // 
            this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnClose.Location = new Point(400, 350);
            this.btnClose.Text = "Close";

            // 
            // AppointmentAlertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnViewDetails);
            this.Controls.Add(this.lstAppointments);
            this.Controls.Add(this.lblAppointmentCount);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Appointment Alert";
        }
    }
}