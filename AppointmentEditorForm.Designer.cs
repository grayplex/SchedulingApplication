using System.Windows.Forms;

namespace SchedulingApplication
{
    partial class AppointmentEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblWindowTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblValidation = new System.Windows.Forms.Label();

            // Basic Information Group
            this.grpBasicInfo = new System.Windows.Forms.GroupBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();

            // Contact Information Group
            this.grpContactInfo = new System.Windows.Forms.GroupBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblContact = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();

            // Schedule Group
            this.grpSchedule = new System.Windows.Forms.GroupBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.pnlHeader.Controls.Add(this.lblWindowTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 60;

            // 
            // lblWindowTitle
            // 
            this.lblWindowTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblWindowTitle.ForeColor = System.Drawing.Color.White;
            this.lblWindowTitle.Location = new System.Drawing.Point(10, 15);
            this.lblWindowTitle.Text = "Add/Edit Appointment";

            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);

            // 
            // pnlButtons
            // 
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Height = 60;
            this.pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[] { this.btnCancel, this.btnSave });

            // 
            // btnSave
            // 
            this.btnSave.Text = "Save";
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.Location = new System.Drawing.Point(400, 15);
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;

            // 
            // btnCancel
            // 
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancel.Location = new System.Drawing.Point(510, 15);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            // 
            // lblValidation
            // 
            this.lblValidation.ForeColor = System.Drawing.Color.Red;
            this.lblValidation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblValidation.Height = 30;

            // Basic Information Group
            // 
            this.grpBasicInfo.Text = "Basic Information";
            this.grpBasicInfo.Dock = System.Windows.Forms.DockStyle.Top;

            // Customer Dropdown
            this.lblCustomer.Text = "Customer:";
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Title Textbox
            this.lblTitle.Text = "Title:";

            // Type Dropdown
            this.lblType.Text = "Type:";
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Description Textbox
            this.lblDescription.Text = "Description:";
            this.txtDescription.Multiline = true;
            this.txtDescription.Height = 80;

            // Contact Information Group
            this.grpContactInfo.Text = "Contact Information";
            this.grpContactInfo.Dock = System.Windows.Forms.DockStyle.Top;

            // Location Textbox
            this.lblLocation.Text = "Location:";

            // Contact Textbox
            this.lblContact.Text = "Contact:";

            // URL Textbox
            this.lblUrl.Text = "URL:";

            // Schedule Group
            this.grpSchedule.Text = "Schedule";
            this.grpSchedule.Dock = System.Windows.Forms.DockStyle.Top;

            // Start Date/Time Picker
            this.lblStartDate.Text = "Start Date/Time:";
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStart.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.dtStart.ShowUpDown = true;

            // End Date/Time Picker
            this.lblEndDate.Text = "End Date/Time:";
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnd.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.dtEnd.ShowUpDown = true;

            // Organize Layout
            this.grpBasicInfo.Controls.AddRange(new System.Windows.Forms.Control[] {
            this.lblCustomer, this.cboCustomer,
            this.lblTitle, this.txtTitle,
            this.lblType, this.cboType,
            this.lblDescription, this.txtDescription
        });

            this.grpContactInfo.Controls.AddRange(new System.Windows.Forms.Control[] {
            this.lblLocation, this.txtLocation,
            this.lblContact, this.txtContact,
            this.lblUrl, this.txtUrl
        });

            this.grpSchedule.Controls.AddRange(new System.Windows.Forms.Control[] {
            this.lblStartDate, this.dtStart,
            this.lblEndDate, this.dtEnd
        });

            this.pnlContent.Controls.AddRange(new System.Windows.Forms.Control[] {
            this.grpSchedule,
            this.grpContactInfo,
            this.grpBasicInfo,
            this.lblValidation
        });

            // 
            // AppointmentEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 550);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
            this.pnlContent,
            this.pnlButtons,
            this.pnlHeader
        });
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppointmentEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Appointment";

            // Perform layout
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblWindowTitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblValidation;
        private System.Windows.Forms.GroupBox grpBasicInfo;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.GroupBox grpContactInfo;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.GroupBox grpSchedule;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtEnd;
    }
}