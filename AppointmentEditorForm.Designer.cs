using System.Drawing;
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
            this.grpBasicInfo = new System.Windows.Forms.GroupBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.grpContactInfo = new System.Windows.Forms.GroupBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblContact = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.grpSchedule = new System.Windows.Forms.GroupBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.lblTimezoneSelection = new System.Windows.Forms.Label();
            this.rbBusinessTimezone = new System.Windows.Forms.RadioButton();
            this.rbUserTimezone = new System.Windows.Forms.RadioButton();
            this.lblTimePickerHelp = new System.Windows.Forms.Label();
            this.lblValidation = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.grpBasicInfo.SuspendLayout();
            this.grpContactInfo.SuspendLayout();
            this.grpSchedule.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.pnlHeader.Controls.Add(this.lblWindowTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(600, 60);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblWindowTitle
            // 
            this.lblWindowTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblWindowTitle.ForeColor = System.Drawing.Color.White;
            this.lblWindowTitle.Location = new System.Drawing.Point(10, 15);
            this.lblWindowTitle.Name = "lblWindowTitle";
            this.lblWindowTitle.Size = new System.Drawing.Size(100, 23);
            this.lblWindowTitle.TabIndex = 0;
            this.lblWindowTitle.Text = "Add/Edit Appointment";
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.grpBasicInfo);
            this.pnlContent.Controls.Add(this.grpContactInfo);
            this.pnlContent.Controls.Add(this.grpSchedule);
            this.pnlContent.Controls.Add(this.lblValidation);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 60);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Size = new System.Drawing.Size(600, 680);
            this.pnlContent.TabIndex = 0;
            // 
            // grpBasicInfo
            // 
            this.grpBasicInfo.Controls.Add(this.lblCustomer);
            this.grpBasicInfo.Controls.Add(this.cboCustomer);
            this.grpBasicInfo.Controls.Add(this.lblTitle);
            this.grpBasicInfo.Controls.Add(this.txtTitle);
            this.grpBasicInfo.Controls.Add(this.lblType);
            this.grpBasicInfo.Controls.Add(this.cboType);
            this.grpBasicInfo.Controls.Add(this.lblDescription);
            this.grpBasicInfo.Controls.Add(this.txtDescription);
            this.grpBasicInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBasicInfo.Location = new System.Drawing.Point(20, 340);
            this.grpBasicInfo.Name = "grpBasicInfo";
            this.grpBasicInfo.Size = new System.Drawing.Size(560, 250);
            this.grpBasicInfo.TabIndex = 0;
            this.grpBasicInfo.TabStop = false;
            this.grpBasicInfo.Text = "Basic Information";
            // 
            // lblCustomer
            // 
            this.lblCustomer.Location = new System.Drawing.Point(10, 30);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(100, 23);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Customer:";
            // 
            // cboCustomer
            // 
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.Location = new System.Drawing.Point(150, 30);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(300, 21);
            this.cboCustomer.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(10, 70);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 23);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(150, 70);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(300, 20);
            this.txtTitle.TabIndex = 3;
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(10, 110);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(100, 23);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Type:";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.Location = new System.Drawing.Point(150, 110);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(300, 21);
            this.cboType.TabIndex = 5;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(10, 150);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(100, 23);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(150, 150);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(300, 80);
            this.txtDescription.TabIndex = 7;
            // 
            // grpContactInfo
            // 
            this.grpContactInfo.Controls.Add(this.lblLocation);
            this.grpContactInfo.Controls.Add(this.txtLocation);
            this.grpContactInfo.Controls.Add(this.lblContact);
            this.grpContactInfo.Controls.Add(this.txtContact);
            this.grpContactInfo.Controls.Add(this.lblUrl);
            this.grpContactInfo.Controls.Add(this.txtUrl);
            this.grpContactInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpContactInfo.Location = new System.Drawing.Point(20, 180);
            this.grpContactInfo.Name = "grpContactInfo";
            this.grpContactInfo.Size = new System.Drawing.Size(560, 160);
            this.grpContactInfo.TabIndex = 1;
            this.grpContactInfo.TabStop = false;
            this.grpContactInfo.Text = "Contact Information";
            // 
            // lblLocation
            // 
            this.lblLocation.Location = new System.Drawing.Point(10, 30);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(100, 23);
            this.lblLocation.TabIndex = 0;
            this.lblLocation.Text = "Location:";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(150, 30);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(300, 20);
            this.txtLocation.TabIndex = 1;
            // 
            // lblContact
            // 
            this.lblContact.Location = new System.Drawing.Point(10, 70);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(100, 23);
            this.lblContact.TabIndex = 2;
            this.lblContact.Text = "Contact Name:";
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(150, 70);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(300, 20);
            this.txtContact.TabIndex = 3;
            // 
            // lblUrl
            // 
            this.lblUrl.Location = new System.Drawing.Point(10, 110);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(100, 23);
            this.lblUrl.TabIndex = 4;
            this.lblUrl.Text = "URL:";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(150, 110);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(300, 20);
            this.txtUrl.TabIndex = 5;
            // 
            // grpSchedule
            // 
            this.grpSchedule.Controls.Add(this.lblStartDate);
            this.grpSchedule.Controls.Add(this.dtStart);
            this.grpSchedule.Controls.Add(this.lblEndDate);
            this.grpSchedule.Controls.Add(this.dtEnd);
            this.grpSchedule.Controls.Add(this.lblTimezoneSelection);
            this.grpSchedule.Controls.Add(this.rbBusinessTimezone);
            this.grpSchedule.Controls.Add(this.rbUserTimezone);
            this.grpSchedule.Controls.Add(this.lblTimePickerHelp);
            this.grpSchedule.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSchedule.Location = new System.Drawing.Point(20, 20);
            this.grpSchedule.Name = "grpSchedule";
            this.grpSchedule.Size = new System.Drawing.Size(560, 160);
            this.grpSchedule.TabIndex = 2;
            this.grpSchedule.TabStop = false;
            this.grpSchedule.Text = "Schedule";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(10, 30);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(86, 13);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "Start Date/Time:";
            // 
            // dtStart
            // 
            this.dtStart.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStart.Location = new System.Drawing.Point(150, 30);
            this.dtStart.Name = "dtStart";
            this.dtStart.ShowUpDown = true;
            this.dtStart.Size = new System.Drawing.Size(250, 20);
            this.dtStart.TabIndex = 1;
            // 
            // lblEndDate
            // 
            this.lblEndDate.Location = new System.Drawing.Point(10, 70);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(100, 23);
            this.lblEndDate.TabIndex = 2;
            this.lblEndDate.Text = "End Date/Time:";
            // 
            // dtEnd
            // 
            this.dtEnd.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnd.Location = new System.Drawing.Point(150, 70);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.ShowUpDown = true;
            this.dtEnd.Size = new System.Drawing.Size(250, 20);
            this.dtEnd.TabIndex = 3;
            // 
            // lblTimezoneSelection
            // 
            this.lblTimezoneSelection.Location = new System.Drawing.Point(10, 110);
            this.lblTimezoneSelection.Name = "lblTimezoneSelection";
            this.lblTimezoneSelection.Size = new System.Drawing.Size(100, 23);
            this.lblTimezoneSelection.TabIndex = 4;
            this.lblTimezoneSelection.Text = "Timezone:";
            // 
            // rbBusinessTimezone
            // 
            this.rbBusinessTimezone.AutoSize = true;
            this.rbBusinessTimezone.Location = new System.Drawing.Point(150, 110);
            this.rbBusinessTimezone.Name = "rbBusinessTimezone";
            this.rbBusinessTimezone.Size = new System.Drawing.Size(97, 17);
            this.rbBusinessTimezone.TabIndex = 5;
            this.rbBusinessTimezone.Text = "Business (EST)";
            // 
            // rbUserTimezone
            // 
            this.rbUserTimezone.AutoSize = true;
            this.rbUserTimezone.Checked = true;
            this.rbUserTimezone.Location = new System.Drawing.Point(270, 110);
            this.rbUserTimezone.Name = "rbUserTimezone";
            this.rbUserTimezone.Size = new System.Drawing.Size(103, 17);
            this.rbUserTimezone.TabIndex = 6;
            this.rbUserTimezone.TabStop = true;
            this.rbUserTimezone.Text = "User\'s Timezone";
            // 
            // lblTimePickerHelp
            // 
            this.lblTimePickerHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblTimePickerHelp.ForeColor = System.Drawing.Color.Navy;
            this.lblTimePickerHelp.Location = new System.Drawing.Point(150, 50);
            this.lblTimePickerHelp.Name = "lblTimePickerHelp";
            this.lblTimePickerHelp.Size = new System.Drawing.Size(250, 23);
            this.lblTimePickerHelp.TabIndex = 7;
            this.lblTimePickerHelp.Text = "Tip: Right-click the time pickers for quick options";
            // 
            // lblValidation
            // 
            this.lblValidation.BackColor = System.Drawing.Color.MistyRose;
            this.lblValidation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblValidation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblValidation.ForeColor = System.Drawing.Color.Red;
            this.lblValidation.Location = new System.Drawing.Point(20, 593);
            this.lblValidation.Name = "lblValidation";
            this.lblValidation.Padding = new System.Windows.Forms.Padding(5);
            this.lblValidation.Size = new System.Drawing.Size(560, 26);
            this.lblValidation.TabIndex = 3;
            this.lblValidation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValidation.Visible = false;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 740);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(600, 60);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(300, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(410, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // AppointmentEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 800);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppointmentEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Appointment";
            this.pnlHeader.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.grpBasicInfo.ResumeLayout(false);
            this.grpBasicInfo.PerformLayout();
            this.grpContactInfo.ResumeLayout(false);
            this.grpContactInfo.PerformLayout();
            this.grpSchedule.ResumeLayout(false);
            this.grpSchedule.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.RadioButton rbBusinessTimezone;
        private System.Windows.Forms.RadioButton rbUserTimezone;
        private System.Windows.Forms.Label lblTimezoneSelection;
        private System.Windows.Forms.Label lblTimePickerHelp;
    }
}