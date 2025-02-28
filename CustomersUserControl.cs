using SchedulingApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace SchedulingApplication
{
    public partial class CustomersUserControl : UserControl
    {
        private List<Customer> _customers;
        private Customer _selectedCustomer;

        public CustomersUserControl()
        {
            InitializeComponent();

            // Setup event handlers
            btnSearch.Click += BtnSearch_Click;
            btnAddCustomer.Click += BtnAddCustomer_Click;
            btnViewDetails.Click += BtnViewDetails_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnViewAppointments.Click += BtnViewAppointments_Click;
            dgvCustomers.CellClick += DgvCustomers_CellClick;
            dgvCustomers.CellDoubleClick += DgvCustomers_CellDoubleClick;

            // Initial load
            LoadCustomers();
        }

        private void LoadCustomers(string searchTerm = "")
        {
            try
            {
                Console.WriteLine("Loading customers...");
                var query = Program.DbContext.Customers
                    .Include(c => c.Address.City.Country)
                    .AsQueryable();

                Console.WriteLine($"Base query created");

                // Apply search filter if search term is provided
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    var searchTermLower = searchTerm.ToLower();
                    query = query.Where(c =>
                        c.CustomerName.ToLower().Contains(searchTermLower) ||
                        c.Address.AddressLine.ToLower().Contains(searchTermLower) ||
                        c.Address.City.CityName.ToLower().Contains(searchTermLower) ||
                        c.Address.City.Country.CountryName.ToLower().Contains(searchTermLower));
                }

                // Order by customer name
                query = query.OrderBy(c => c.CustomerName);

                // Execute query
                Console.WriteLine("Executing customer query...");
                _customers = query.ToList();
                Console.WriteLine($"Customers found: {_customers.Count}");

                AutoCompleteStringCollection allowedTypes = new AutoCompleteStringCollection();
                // Convert _customers into string array
                foreach ( var customer in _customers )
                {
                    allowedTypes.Add(customer.CustomerName);
                }
                txtSearch.AutoCompleteCustomSource = allowedTypes;
                txtSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;

                // Clear the current grid
                dgvCustomers.DataSource = null;
                dgvCustomers.Rows.Clear();

                // Add rows to the grid
                foreach (var customer in _customers)
                {
                    int rowIndex = dgvCustomers.Rows.Add(
                        customer.CustomerId,
                        customer.CustomerName,
                        customer.Address.AddressLine,
                        customer.Address.City?.CityName ?? "Unknown",
                        customer.Address.City?.Country?.CountryName ?? "Unknown",
                        customer.Address.Phone,
                        customer.Active ? "Active" : "Inactive"
                    );

                    // Set row color based on active status
                    if (!customer.Active)
                    {
                        dgvCustomers.Rows[rowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Gray;
                    }
                }

                // Update button states
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR loading customers: {ex.Message}");
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadCustomers(txtSearch.Text);
        }

        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            // Create a new customer
            var customer = new Customer
            {
                Active = true,
                CreateDate = DateTime.Now,
                CreatedBy = LoginForm.LoggedInUser?.UserName ?? "system",
                LastUpdate = DateTime.Now,
                LastUpdateBy = LoginForm.LoggedInUser?.UserName ?? "system"
            };

            // Open customer editor window
            var editorForm = new CustomerEditorForm(customer, true);
            if (editorForm.ShowDialog() == DialogResult.OK)
            {
                // Refresh list after adding
                LoadCustomers(txtSearch.Text);
            }
        }

        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer != null)
            {
                var detailsForm = new CustomerDetailsForm(_selectedCustomer);
                detailsForm.ShowDialog();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer != null)
            {
                // Open customer editor with existing customer
                var editorForm = new CustomerEditorForm(_selectedCustomer, false);
                if (editorForm.ShowDialog() == DialogResult.OK)
                {
                    // Refresh list after editing
                    LoadCustomers(txtSearch.Text);
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer != null)
            {
                // Check if customer has appointments first
                var hasAppointments = Program.DbContext.Appointments.Any(a => a.CustomerId == _selectedCustomer.CustomerId);

                if (hasAppointments)
                {
                    MessageBox.Show(
                        "This customer has existing appointments. Please delete all appointments for this customer first.",
                        "Cannot Delete Customer",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show(
                    $"Are you sure you want to delete the customer '{_selectedCustomer.CustomerName}'?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Program.DbContext.Customers.Remove(_selectedCustomer);
                        Program.DbContext.SaveChanges();
                        LoadCustomers(txtSearch.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting customer: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnViewAppointments_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer != null)
            {
                var appointmentsForm = new CustomerAppointmentsForm(_selectedCustomer);
                appointmentsForm.ShowDialog();
            }
        }

        private void DgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _customers.Count)
            {
                _selectedCustomer = _customers[e.RowIndex];
                UpdateButtonStates();
            }
        }

        private void DgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _customers.Count)
            {
                _selectedCustomer = _customers[e.RowIndex];
                BtnViewDetails_Click(sender, e);
            }
        }

        private void UpdateButtonStates()
        {
            bool customerSelected = _selectedCustomer != null;
            btnViewDetails.Enabled = customerSelected;
            btnEdit.Enabled = customerSelected;
            btnDelete.Enabled = customerSelected;
            btnViewAppointments.Enabled = customerSelected;
        }

        // Method to refresh data from outside the control
        public void RefreshData()
        {
            LoadCustomers(txtSearch.Text);
        }
    }
}