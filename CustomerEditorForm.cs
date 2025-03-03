using SchedulingApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SchedulingApplication
{
    public partial class CustomerEditorForm : Form
    {
        private Customer _customer;
        private Address _address;
        private bool _isNewCustomer;

        private Dictionary<Control, bool> _requiredFields = new Dictionary<Control, bool>();
        private Dictionary<Control, Color> _originalColors = new Dictionary<Control, Color>();
        private readonly Color InvalidFieldColor = Color.MistyRose;
        private readonly Color ValidFieldColor = Color.White;
        private readonly Color RequiredLabelColor = Color.FromArgb(192, 0, 0); // Dark red


        public CustomerEditorForm(Customer customer, bool isNewCustomer)
        {
            InitializeComponent();
            _isNewCustomer = isNewCustomer;

            // Update title based on mode
            this.Text = isNewCustomer ? "Add New Customer" : "Edit Customer";
            lblWindowTitle.Text = this.Text;

            RegisterRequiredFields();

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

            // Setup validation event handlers
            txtCustomerName.TextChanged += RequiredField_Changed;
            txtAddress1.TextChanged += RequiredField_Changed;
            txtPostalCode.TextChanged += RequiredField_Changed;
            txtPhone.TextChanged += RequiredField_Changed;
            cboCity.SelectedIndexChanged += RequiredField_Changed;
            cboCountry.SelectedIndexChanged += RequiredField_Changed;

            // Load reference data
            LoadCountries();

            // Initial validation
            ValidateAllFields();

            // Add handler for the save button
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void RegisterRequiredFields()
        {
            // Register all required fields with initial invalid state
            _requiredFields[txtCustomerName] = false;
            _requiredFields[txtAddress1] = false;
            _requiredFields[txtPostalCode] = false;
            _requiredFields[txtPhone] = false;
            _requiredFields[cboCity] = false;
            _requiredFields[cboCountry] = false;

            // Store original colors
            foreach (var control in _requiredFields.Keys)
            {
                _originalColors[control] = control.BackColor;
            }

            // Style the labels for required fields
            StyleRequiredFieldLabels();
        }

        private void StyleRequiredFieldLabels()
        {
            // Add style for labels that already have asterisks in the designer
            lblCustomerName.ForeColor = RequiredLabelColor;
            lblAddress1.ForeColor = RequiredLabelColor;
            lblCity.ForeColor = RequiredLabelColor;
            lblCountry.ForeColor = RequiredLabelColor;
            lblPostalCode.ForeColor = RequiredLabelColor;
            lblPhone.ForeColor = RequiredLabelColor;

            // Add a legend for required fields
            Label lblRequiredLegend = new Label
            {
                Text = "* Required Field",
                ForeColor = RequiredLabelColor,
                AutoSize = true,
                Location = new Point(20, 430) // Adjust position as needed
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
                // For phone field, add additional validation
                if (control == txtPhone)
                {
                    string phone = textBox.Text.Trim();
                    isValid = !string.IsNullOrWhiteSpace(phone) &&
                             System.Text.RegularExpressions.Regex.IsMatch(phone, @"^[0-9\-]+$");
                }
                else
                {
                    isValid = !string.IsNullOrWhiteSpace(textBox.Text);
                }
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

                ValidateControl(cboCountry);
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
                if (cboCountry.SelectedItem != null)
                {
                    // Get the selected Country object directly
                    if (cboCountry.SelectedItem is Country selectedCountry)
                    {
                        int countryId = selectedCountry.CountryId;

                        var cities = Program.DbContext.Cities
                            .Where(c => c.CountryId == countryId)
                            .OrderBy(c => c.CityName)
                            .ToList();

                        // Store the current selection if there is one
                        object currentSelection = cboCity.SelectedValue;

                        cboCity.DataSource = cities;
                        cboCity.DisplayMember = "CityName";
                        cboCity.ValueMember = "CityId";

                        // Set initial selection if editing
                        if (!_isNewCustomer && _address?.CityId > 0)
                        {
                            cboCity.SelectedValue = _address.CityId;
                        }
                        // If we had a previous selection, try to restore it
                        else if (currentSelection != null)
                        {
                            try
                            {
                                cboCity.SelectedValue = currentSelection;
                            }
                            catch
                            {
                                // If the previous value isn't in the new list, select the first item
                                if (cboCity.Items.Count > 0)
                                    cboCity.SelectedIndex = 0;
                            }
                        }
                    }
                }
                else
                {
                    // Clear the cities list if no country is selected
                    cboCity.DataSource = null;
                    cboCity.Items.Clear();
                }

                ValidateControl(cboCity);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading cities: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateCustomer()
        {
            lblValidationMessage.Text = string.Empty;
            lblValidationMessage.Visible = false;

            // Check if all required fields are valid
            if (!_requiredFields.Values.All(valid => valid))
            {
                lblValidationMessage.Text = "Please fill in all required fields correctly.";
                lblValidationMessage.Visible = true;
                return false;
            }

            // Additional validation can be added here if needed
            return true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateAllFields();

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
                lblValidationMessage.Text = $"Error saving customer: {ex.Message}";
                lblValidationMessage.Visible = true;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void CboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Load cities based on selected country
            LoadCities();
            ValidateControl(cboCountry);
        }
    }
}