using SchedulingApplication.Models;
using SchedulingApplication.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchedulingApplication
{
    public partial class LoginForm : Form
    {
        private string _username;
        private string _password;
        private string _errorMessage;
        private bool _isLoading;
        private string _userLocation;
        private string _currentLanguage;

        public static User LoggedInUser { get; private set; }

        public LoginForm()
        {
            InitializeComponent();

            // Initialize location and language
            _currentLanguage = LocalizationManager.CurrentCulture == "en-US" ? "English" : "Español";
            _userLocation = string.Format(LocalizationManager.GetTranslation("YourLocation"), LocalizationManager.UserLocation);

            // Subscribe to language changes
            LocalizationManager.LanguageChanged += OnLanguageChanged;

            // Update UI with localized text
            UpdateFormText();
        }

        private void OnLanguageChanged(object sender, EventArgs e)
        {
            UpdateFormText();
        }

        private void UpdateFormText()
        {
            this.Text = LocalizationManager.GetTranslation("LoginWindowTitle");
            lblTitle.Text = LocalizationManager.GetTranslation("ApplicationTitle");
            lblUsername.Text = LocalizationManager.GetTranslation("Username");
            lblPassword.Text = LocalizationManager.GetTranslation("Password");
            btnLogin.Text = LocalizationManager.GetTranslation("LoginButton");
            btnCancel.Text = LocalizationManager.GetTranslation("CancelButton");
            lblLocation.Text = string.Format(LocalizationManager.GetTranslation("YourLocation"), LocalizationManager.UserLocation);
            btnToggleLanguage.Text = _currentLanguage;
        }

        private void btnToggleLanguage_Click(object sender, EventArgs e)
        {
            LocalizationManager.ToggleLanguage();
            _currentLanguage = LocalizationManager.CurrentCulture == "en-US" ? "English" : "Español";
            btnToggleLanguage.Text = _currentLanguage;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                _isLoading = true;

                // Show loading indicator
                panelLoading.Visible = true;
                Application.DoEvents();

                // Get username and password
                _username = txtUsername.Text;
                _password = txtPassword.Text;

                // Perform DB operations on background thread so progress bar animates correctly
                Task.Run(() =>
                {
                    try
                    {
                        // DB operations
                        var user = Program.DbContext.Users
                            .FirstOrDefault(u => u.UserName == _username && u.Password == _password && u.Active);

                        // Update UI on the UI thread
                        this.Invoke((MethodInvoker)delegate
                        {
                            if (user != null)
                            {
                                // Set the logged-in user globally
                                LoggedInUser = user;

                                // Log successful login
                                LoginLogger.LogLogin(_username);

                                // Close with success
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                // Invalid creds
                                lblError.Text = LocalizationManager.GetTranslation("InvalidCredentials");
                                panelLoading.Visible = false;
                                _isLoading = false;
                            }
                        });
                    }
                    catch (Exception ex)
                    {
                        // Handle execptions and update UI on UI thread
                        this.Invoke((MethodInvoker)delegate
                        {
                            lblError.Text = LocalizationManager.GetTranslation("LoginError", ex.Message);
                            panelLoading.Visible = false;
                            _isLoading = false;
                        });
                    }
                });
            }
            catch (Exception ex)
            {
                lblError.Text = LocalizationManager.GetTranslation("LoginError", ex.Message);
                panelLoading.Visible = false;
                _isLoading = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            // Unsubscribe from events
            LocalizationManager.LanguageChanged -= OnLanguageChanged;
        }
    }
}
