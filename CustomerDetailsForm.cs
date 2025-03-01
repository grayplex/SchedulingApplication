using SchedulingApplication.Models;
using System;
using System.Windows.Forms;

namespace SchedulingApplication
{
    public partial class CustomerDetailsForm : Form
    {
        private Customer _customer;

        public CustomerDetailsForm(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
            LoadCustomerDetails();
        }

        private void LoadCustomerDetails()
        {
            try
            {
                // Set the title
                this.Text = $"Customer Details - {_customer.CustomerName}";

                // Basic Information
                lblCustomerId.Text = _customer.CustomerId.ToString();
                lblCustomerName.Text = _customer.CustomerName;
                lblActive.Text = _customer.Active ? "Active" : "Inactive";

                // Address Information
                lblAddress1.Text = _customer.Address.AddressLine;
                lblAddress2.Text = _customer.Address.AddressLine2 ?? "";
                lblCity.Text = _customer.Address.City?.CityName ?? "Unknown";
                lblCountry.Text = _customer.Address.City?.Country?.CountryName ?? "Unknown";
                lblPostalCode.Text = _customer.Address.PostalCode;
                lblPhone.Text = _customer.Address.Phone;

                // Audit Information
                lblCreatedBy.Text = $"{_customer.CreatedBy} on {_customer.CreateDate.ToString("MM/dd/yyyy hh:mm tt")}";
                lblLastUpdated.Text = $"{_customer.LastUpdateBy} on {_customer.LastUpdate.ToString("MM/dd/yyyy hh:mm tt")}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customer details: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnViewAppointments_Click(object sender, EventArgs e)
        {
            try
            {
                var appointmentsForm = new CustomerAppointmentsForm(_customer);
                appointmentsForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening appointments: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            // Open the customer editor
            var editorForm = new CustomerEditorForm(_customer, false);
            if (editorForm.ShowDialog() == DialogResult.OK)
            {
                // Reload the details
                LoadCustomerDetails();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}