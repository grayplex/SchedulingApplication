using SchedulingApplication.Models;
using SchedulingApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace SchedulingApplication
{
    public partial class ReportsUserControl : UserControl
    {
        // Data collections
        private List<User> _consultants;
        private List<int> _years;
        private List<Appointment> _consultantSchedule;
        private List<CustomerAppointmentStats> _customerStats;
        private List<AppointmentTypeByMonth> _appointmentTypesByMonth;

        // Selected values
        private User _selectedConsultant;
        private int _selectedYear;

        public ReportsUserControl()
        {
            InitializeComponent();

            // Setup event handlers
            btnAppointmentTypes.Click += BtnAppointmentTypes_Click;
            btnConsultantSchedule.Click += BtnConsultantSchedule_Click;
            btnCustomerStats.Click += BtnCustomerStats_Click;
            cbConsultant.SelectedIndexChanged += CbConsultant_SelectedIndexChanged;
            cbYear.SelectedIndexChanged += CbYear_SelectedIndexChanged;

            // Load initial data
            LoadReferenceData();
        }

        private void LoadReferenceData()
        {
            try
            {
                // Load consultants
                _consultants = Program.DbContext.Users
                    .Where(u => u.Active)
                    .OrderBy(u => u.UserName)
                    .ToList();

                cbConsultant.DataSource = new BindingSource(_consultants, null);
                cbConsultant.DisplayMember = "UserName";
                cbConsultant.ValueMember = "UserId";

                // Generate years list
                _years = Enumerable.Range(DateTime.Now.Year - 5, 6).ToList();
                cbYear.DataSource = _years;
                cbYear.SelectedItem = DateTime.Now.Year;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reference data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAppointmentTypes_Click(object sender, EventArgs e)
        {
            GenerateAppointmentTypesReport();
        }

        private void GenerateAppointmentTypesReport()
        {
            try
            {
                int selectedYear = (int)cbYear.SelectedItem;

                // Get start and end dates for the selected year
                var startDate = new DateTime(selectedYear, 1, 1);
                var endDate = new DateTime(selectedYear, 12, 31);

                // Get all appointments for the year
                var appointments = Program.DbContext.Appointments
                    .Where(a => a.Start >= startDate && a.Start <= endDate)
                    .ToList();

                // Group by month and type
                _appointmentTypesByMonth = appointments
                    .GroupBy(a => new { Month = a.Start.Month, Type = a.Type ?? "Unspecified" })
                    .Select(g => new AppointmentTypeByMonth
                    {
                        Month = g.Key.Month,
                        MonthName = GetMonthName(g.Key.Month),
                        Type = g.Key.Type,
                        Count = g.Count()
                    })
                    .OrderBy(a => a.Month)
                    .ThenBy(a => a.Type)
                    .ToList();

                // Populate DataGridView
                dgvReport.DataSource = _appointmentTypesByMonth;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating appointment types report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnConsultantSchedule_Click(object sender, EventArgs e)
        {
            GenerateConsultantScheduleReport();
        }

        private void GenerateConsultantScheduleReport()
        {
            try
            {
                if (_selectedConsultant == null)
                {
                    MessageBox.Show("Please select a consultant.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get all appointments for the selected consultant
                _consultantSchedule = Program.DbContext.Appointments
                    .Include(a => a.Customer)
                    .Where(a => a.UserId == _selectedConsultant.UserId)
                    .OrderBy(a => a.Start)
                    .ToList();

                // Convert times to user's local time
                foreach (var appointment in _consultantSchedule)
                {
                    appointment.Start = TimeZoneHelper.ToUserTime(appointment.Start);
                    appointment.End = TimeZoneHelper.ToUserTime(appointment.End);
                }

                // Populate DataGridView
                dgvReport.DataSource = _consultantSchedule;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating consultant schedule report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCustomerStats_Click(object sender, EventArgs e)
        {
            GenerateCustomerStatsReport();
        }

        private void GenerateCustomerStatsReport()
        {
            try
            {
                var appointments = Program.DbContext.Appointments
                    .Include(a => a.Customer)
                    .ToList();

                var now = DateTime.Now;

                _customerStats = appointments
                    .GroupBy(a => new { a.CustomerId, a.Customer.CustomerName })
                    .Select(g => new CustomerAppointmentStats
                    {
                        CustomerId = g.Key.CustomerId,
                        CustomerName = g.Key.CustomerName,
                        TotalAppointments = g.Count(),
                        LastAppointment = g.Where(a => a.Start < now)
                                           .OrderByDescending(a => a.Start)
                                           .FirstOrDefault()?.Start,
                        NextAppointment = g.Where(a => a.Start >= now)
                                           .OrderBy(a => a.Start)
                                           .FirstOrDefault()?.Start,
                        AverageDuration = g.Average(a => (a.End - a.Start).TotalMinutes),
                        MostCommonType = g.GroupBy(a => a.Type)
                                          .OrderByDescending(typeGroup => typeGroup.Count())
                                          .Select(typeGroup => typeGroup.Key)
                                          .FirstOrDefault() ?? "None"
                    })
                    .OrderBy(s => s.CustomerName)
                    .ToList();

                // Populate DataGridView
                dgvReport.DataSource = _customerStats;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating customer stats report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CbConsultant_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedConsultant = cbConsultant.SelectedItem as User;
        }

        private void CbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedYear = (int)cbYear.SelectedItem;
        }

        private string GetMonthName(int month)
        {
            return new DateTime(2000, month, 1).ToString("MMMM");
        }
    }

    // Support classes (these can be moved to a separate file if preferred)
    public class AppointmentTypeByMonth
    {
        public int Month { get; set; }
        public string MonthName { get; set; }
        public string Type { get; set; }
        public int Count { get; set; }
    }
}