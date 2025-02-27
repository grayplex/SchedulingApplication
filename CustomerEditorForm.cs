using SchedulingApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace SchedulingApplication
{
    public partial class CustomerEditorForm : Form
    {
        private Customer _customer;
        private Address _address;
        private bool _isNewCustomer;
        private string _validationMessage;

        public CustomerEditorForm(Customer customer, bool isNewCustomer)
        {
            InitializeComponent();
            _isNewCustomer = isNewCustomer;

            // Update title based on mode
            this.Text = isNewCustomer ? "Add New Customer" : "Edit Customer";
            lblWindowTitle.Text = this.Text;

            if (isNewCustomer)
            {
                // Create a new customer with defaults
                _customer = customer;

                // Create a new address
                _address = new Address
                {
                    CreateDate = DateTime.Now,
                    CreatedBy = LoginForm.LoggedInUser?.UserName ?? "system",
                    LastUpdate = DateTime.Now,
                    LastUpdateBy = LoginForm.LoggedInUser?.UserName ?? "system"
                };
            }
            else
            {
                // Edit existing customer
                _customer = customer;
                _address = customer.Address;

                // Populate fields with existing data
                txtCustomerName.Text = _customer.CustomerName;
                chkActive.Checked = _customer.Active;

                if (_address != null)
                {
                    txtAddress1.Text = _address.AddressLine;
                    txtAddress2.Text = _address.AddressLine2;
                    txtPostalCode.Text = _address.PostalCode;
                    txtPhone.Text = _address.Phone;
                }
            }

            // Load reference data
            LoadCountries();
        }

        private void LoadCountries()
        {
            try
            {
                var countries = Program.DbContext.Countries
                    .OrderBy(c => c.CountryName)
                    .ToList();
                cboCountry.DataSource = countries;
                cboCountry.DisplayMember = "CountryName";
                cboCountry.ValueMember = "CountryId";

                // Set initial selection if editing
                if (!_isNewCustomer && _address?.City?.Country != null)
                {
                    cboCountry.SelectedValue = _address.City.CountryId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading countries: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCities()
        {
            try
            {
                if (cboCountry.SelectedValue != null)
                {
                    int countryId = (int)cboCountry.SelectedValue;
                    var cities = Program.DbContext.Cities
                        .Where(c => c.CountryId == countryId)
                        .OrderBy(c => c.CityName)
                        .ToList();
                    cboCity.DataSource = cities;
                    cboCity.DisplayMember = "CityName";
                    cboCity.ValueMember = "CityId";

                    // Set initial selection if editing
                    if (!_isNewCustomer && _address?.CityId > 0)
                    {
                        cboCity.SelectedValue = _address.CityId;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading cities: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateCustomer()
        {
            _validationMessage = string.Empty;
            lblValidationMessage.Text = string.Empty;
            lblValidationMessage.Visible = false;

            // Trim values to handle whitespace
            string customerName = txtCustomerName.Text?.Trim() ?? "";
            string addressLine = txtAddress1.Text?.Trim() ?? "";
            string addressLine2 = txtAddress2.Text?.Trim() ?? "";
            string postalCode = txtPostalCode.Text?.Trim() ?? "";
            string phone = txtPhone.Text?.Trim() ?? "";

            // Required fields - check after trimming
            if (string.IsNullOrWhiteSpace(customerName))
            {
                _validationMessage = "Customer name is required.";
                lblValidationMessage.Text = _validationMessage;
                lblValidationMessage.Visible = true;
                return false;
            }

            if (string.IsNullOrWhiteSpace(addressLine))
            {
                _validationMessage = "Address is required.";
                lblValidationMessage.Text = _validationMessage;
                lblValidationMessage.Visible = true;
                return false;
            }

            if (cboCity.SelectedItem == null)
            {
                _validationMessage = "City is required.";
                lblValidationMessage.Text = _validationMessage;
                lblValidationMessage.Visible = true;
                return false;
            }

            if (string.IsNullOrWhiteSpace(postalCode))
            {
                _validationMessage = "Postal code is required.";
                lblValidationMessage.Text = _validationMessage;
                lblValidationMessage.Visible = true;
                return false;
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                _validationMessage = "Phone number is required.";
                lblValidationMessage.Text = _validationMessage;
                lblValidationMessage.Visible = true;
                return false;
            }

            // Phone number format validation - only digits and dashes
            if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^[0-9\-]+$"))
            {
                _validationMessage = "Phone number can only contain digits and dashes.";
                lblValidationMessage.Text = _validationMessage;
                lblValidationMessage.Visible = true;
                return false;
            }

            // Update trimmed values back to the text boxes
            txtCustomerName.Text = customerName;
            txtAddress1.Text = addressLine;
            txtAddress2.Text = addressLine2;
            txtPostalCode.Text = postalCode;
            txtPhone.Text = phone;

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate customer data
                if (!ValidateCustomer())
                {
                    return;
                }

                using (var transaction = Program.DbContext.Database.BeginTransaction())
                {
                    try
                    {
                        // Update customer properties
                        _customer.CustomerName = txtCustomerName.Text.Trim();
                        _customer.Active = chkActive.Checked;

                        // Update address properties
                        _address.AddressLine = txtAddress1.Text.Trim();
                        _address.AddressLine2 = txtAddress2.Text.Trim();
                        _address.PostalCode = txtPostalCode.Text.Trim();
                        _address.Phone = txtPhone.Text.Trim();
                        _address.CityId = (int)cboCity.SelectedValue;

                        // Set audit fields
                        if (_isNewCustomer)
                        {
                            _customer.CreateDate = DateTime.Now;
                            _customer.CreatedBy = LoginForm.LoggedInUser?.UserName ?? "system";
                        }

                        _customer.LastUpdate = DateTime.Now;
                        _customer.LastUpdateBy = LoginForm.LoggedInUser?.UserName ?? "system";

                        // Handle address
                        if (_isNewCustomer)
                        {
                            // Add new address
                            Program.DbContext.Addresses.Add(_address);
                            Program.DbContext.SaveChanges();

                            // Link address to customer
                            _customer.AddressId = _address.AddressId;
                            Program.DbContext.Customers.Add(_customer);
                        }
                        else
                        {
                            // Update address
                            _address.LastUpdate = DateTime.Now;
                            _address.LastUpdateBy = LoginForm.LoggedInUser?.UserName ?? "system";
                            Program.DbContext.Entry(_address).State = EntityState.Modified;

                            // Update customer
                            Program.DbContext.Entry(_customer).State = EntityState.Modified;
                        }

                        Program.DbContext.SaveChanges();
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
                _validationMessage = $"Error saving customer: {ex.Message}";
                lblValidationMessage.Text = _validationMessage;
                lblValidationMessage.Visible = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Load cities based on selected country
            LoadCities();
        }
    }
}