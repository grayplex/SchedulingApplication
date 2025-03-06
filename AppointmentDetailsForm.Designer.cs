using System.Drawing;

namespace SchedulingApplication
{
    partial class AppointmentDetailsForm
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.groupSystemInfo = new System.Windows.Forms.GroupBox();
            this.lblLastUpdated = new System.Windows.Forms.Label();
            this.lblLastUpdatedLabel = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblCreatedByLabel = new System.Windows.Forms.Label();
            this.groupDetails = new System.Windows.Forms.GroupBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblUrlLabel = new System.Windows.Forms.Label();
            this.lblContactLabel = new System.Windows.Forms.Label();
            this.lblLocationLabel = new System.Windows.Forms.Label();
            this.lblDescriptionLabel = new System.Windows.Forms.Label();
            this.groupSchedule = new System.Windows.Forms.GroupBox();
            this.lblTimeZone = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEndLabel = new System.Windows.Forms.Label();
            this.lblStartLabel = new System.Windows.Forms.Label();
            this.pnlWarning = new System.Windows.Forms.Panel();
            this.lblWarning = new System.Windows.Forms.Label();
            this.groupBasic = new System.Windows.Forms.GroupBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblConsultant = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAppointmentId = new System.Windows.Forms.Label();
            this.lblTypeLabel = new System.Windows.Forms.Label();
            this.lblConsultantLabel = new System.Windows.Forms.Label();
            this.lblCustomerLabel = new System.Windows.Forms.Label();
            this.lblTitleLabel = new System.Windows.Forms.Label();
            this.lblAppointmentIdLabel = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.groupSystemInfo.SuspendLayout();
            this.groupDetails.SuspendLayout();
            this.groupSchedule.SuspendLayout();
            this.pnlWarning.SuspendLayout();
            this.groupBasic.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(584, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(16, 18);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(196, 24);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Appointment Details";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 611);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(584, 60);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(457, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 32);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(343, 16);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 32);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.Controls.Add(this.groupSystemInfo);
            this.pnlContent.Controls.Add(this.groupDetails);
            this.pnlContent.Controls.Add(this.groupSchedule);
            this.pnlContent.Controls.Add(this.groupBasic);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 60);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Size = new System.Drawing.Size(584, 551);
            this.pnlContent.TabIndex = 2;
            // 
            // groupSystemInfo
            // 
            this.groupSystemInfo.Controls.Add(this.lblLastUpdated);
            this.groupSystemInfo.Controls.Add(this.lblLastUpdatedLabel);
            this.groupSystemInfo.Controls.Add(this.lblCreatedBy);
            this.groupSystemInfo.Controls.Add(this.lblCreatedByLabel);
            this.groupSystemInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupSystemInfo.Location = new System.Drawing.Point(20, 427);
            this.groupSystemInfo.Name = "groupSystemInfo";
            this.groupSystemInfo.Size = new System.Drawing.Size(544, 100);
            this.groupSystemInfo.TabIndex = 3;
            this.groupSystemInfo.TabStop = false;
            this.groupSystemInfo.Text = "System Information";
            // 
            // lblLastUpdated
            // 
            this.lblLastUpdated.AutoSize = true;
            this.lblLastUpdated.Location = new System.Drawing.Point(120, 60);
            this.lblLastUpdated.Name = "lblLastUpdated";
            this.lblLastUpdated.Size = new System.Drawing.Size(109, 13);
            this.lblLastUpdated.TabIndex = 3;
            this.lblLastUpdated.Text = "test on 01/01/2025...";
            // 
            // lblLastUpdatedLabel
            // 
            this.lblLastUpdatedLabel.AutoSize = true;
            this.lblLastUpdatedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastUpdatedLabel.Location = new System.Drawing.Point(20, 60);
            this.lblLastUpdatedLabel.Name = "lblLastUpdatedLabel";
            this.lblLastUpdatedLabel.Size = new System.Drawing.Size(87, 13);
            this.lblLastUpdatedLabel.TabIndex = 2;
            this.lblLastUpdatedLabel.Text = "Last Updated:";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(120, 30);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(109, 13);
            this.lblCreatedBy.TabIndex = 1;
            this.lblCreatedBy.Text = "test on 01/01/2025...";
            // 
            // lblCreatedByLabel
            // 
            this.lblCreatedByLabel.AutoSize = true;
            this.lblCreatedByLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByLabel.Location = new System.Drawing.Point(20, 30);
            this.lblCreatedByLabel.Name = "lblCreatedByLabel";
            this.lblCreatedByLabel.Size = new System.Drawing.Size(73, 13);
            this.lblCreatedByLabel.TabIndex = 0;
            this.lblCreatedByLabel.Text = "Created By:";
            // 
            // groupDetails
            // 
            this.groupDetails.Controls.Add(this.lblUrl);
            this.groupDetails.Controls.Add(this.lblContact);
            this.groupDetails.Controls.Add(this.lblLocation);
            this.groupDetails.Controls.Add(this.txtDescription);
            this.groupDetails.Controls.Add(this.lblUrlLabel);
            this.groupDetails.Controls.Add(this.lblContactLabel);
            this.groupDetails.Controls.Add(this.lblLocationLabel);
            this.groupDetails.Controls.Add(this.lblDescriptionLabel);
            this.groupDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupDetails.Location = new System.Drawing.Point(20, 267);
            this.groupDetails.Name = "groupDetails";
            this.groupDetails.Size = new System.Drawing.Size(544, 160);
            this.groupDetails.TabIndex = 2;
            this.groupDetails.TabStop = false;
            this.groupDetails.Text = "Additional Details";
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(120, 130);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(127, 13);
            this.lblUrl.TabIndex = 7;
            this.lblUrl.Text = "http://www.example.com";
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(120, 100);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(75, 13);
            this.lblContact.TabIndex = 6;
            this.lblContact.Text = "Contact Name";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(120, 70);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(109, 13);
            this.lblLocation.TabIndex = 5;
            this.lblLocation.Text = "Conference Room 3A";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.Location = new System.Drawing.Point(120, 27);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(403, 40);
            this.txtDescription.TabIndex = 4;
            // 
            // lblUrlLabel
            // 
            this.lblUrlLabel.AutoSize = true;
            this.lblUrlLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUrlLabel.Location = new System.Drawing.Point(20, 130);
            this.lblUrlLabel.Name = "lblUrlLabel";
            this.lblUrlLabel.Size = new System.Drawing.Size(36, 13);
            this.lblUrlLabel.TabIndex = 3;
            this.lblUrlLabel.Text = "URL:";
            // 
            // lblContactLabel
            // 
            this.lblContactLabel.AutoSize = true;
            this.lblContactLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactLabel.Location = new System.Drawing.Point(20, 100);
            this.lblContactLabel.Name = "lblContactLabel";
            this.lblContactLabel.Size = new System.Drawing.Size(55, 13);
            this.lblContactLabel.TabIndex = 2;
            this.lblContactLabel.Text = "Contact:";
            // 
            // lblLocationLabel
            // 
            this.lblLocationLabel.AutoSize = true;
            this.lblLocationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocationLabel.Location = new System.Drawing.Point(20, 70);
            this.lblLocationLabel.Name = "lblLocationLabel";
            this.lblLocationLabel.Size = new System.Drawing.Size(60, 13);
            this.lblLocationLabel.TabIndex = 1;
            this.lblLocationLabel.Text = "Location:";
            // 
            // lblDescriptionLabel
            // 
            this.lblDescriptionLabel.AutoSize = true;
            this.lblDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptionLabel.Location = new System.Drawing.Point(20, 30);
            this.lblDescriptionLabel.Name = "lblDescriptionLabel";
            this.lblDescriptionLabel.Size = new System.Drawing.Size(75, 13);
            this.lblDescriptionLabel.TabIndex = 0;
            this.lblDescriptionLabel.Text = "Description:";
            // 
            // groupSchedule
            // 
            this.groupSchedule.AutoSize = true;
            this.groupSchedule.Controls.Add(this.lblTimeZone);
            this.groupSchedule.Controls.Add(this.lblEnd);
            this.groupSchedule.Controls.Add(this.lblStart);
            this.groupSchedule.Controls.Add(this.lblEndLabel);
            this.groupSchedule.Controls.Add(this.lblStartLabel);
            this.groupSchedule.Controls.Add(this.pnlWarning);
            this.groupSchedule.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupSchedule.Location = new System.Drawing.Point(20, 168);
            this.groupSchedule.Name = "groupSchedule";
            this.groupSchedule.Size = new System.Drawing.Size(544, 99);
            this.groupSchedule.TabIndex = 1;
            this.groupSchedule.TabStop = false;
            this.groupSchedule.Text = "Schedule";
            // 
            // lblTimeZone
            // 
            this.lblTimeZone.AutoSize = true;
            this.lblTimeZone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTimeZone.Location = new System.Drawing.Point(120, 70);
            this.lblTimeZone.Name = "lblTimeZone";
            this.lblTimeZone.Size = new System.Drawing.Size(174, 13);
            this.lblTimeZone.TabIndex = 4;
            this.lblTimeZone.Text = "(Time Zone: Pacific Standard Time)";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(120, 50);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(154, 13);
            this.lblEnd.TabIndex = 3;
            this.lblEnd.Text = "02/02/2025 11:00:00 AM PDT";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(120, 30);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(154, 13);
            this.lblStart.TabIndex = 2;
            this.lblStart.Text = "02/02/2025 10:00:00 AM PDT";
            // 
            // lblEndLabel
            // 
            this.lblEndLabel.AutoSize = true;
            this.lblEndLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndLabel.Location = new System.Drawing.Point(20, 50);
            this.lblEndLabel.Name = "lblEndLabel";
            this.lblEndLabel.Size = new System.Drawing.Size(33, 13);
            this.lblEndLabel.TabIndex = 1;
            this.lblEndLabel.Text = "End:";
            // 
            // lblStartLabel
            // 
            this.lblStartLabel.AutoSize = true;
            this.lblStartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartLabel.Location = new System.Drawing.Point(20, 30);
            this.lblStartLabel.Name = "lblStartLabel";
            this.lblStartLabel.Size = new System.Drawing.Size(38, 13);
            this.lblStartLabel.TabIndex = 0;
            this.lblStartLabel.Text = "Start:";
            // 
            // pnlWarning
            // 
            this.pnlWarning.BackColor = System.Drawing.Color.LightYellow;
            this.pnlWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlWarning.Controls.Add(this.lblWarning);
            this.pnlWarning.Location = new System.Drawing.Point(13, 16);
            this.pnlWarning.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.pnlWarning.Name = "pnlWarning";
            this.pnlWarning.Size = new System.Drawing.Size(518, 30);
            this.pnlWarning.TabIndex = 5;
            this.pnlWarning.Visible = false;
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWarning.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblWarning.Location = new System.Drawing.Point(0, 0);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(274, 13);
            this.lblWarning.TabIndex = 0;
            this.lblWarning.Text = "Note: This appointment is outside normal business hours.";
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBasic
            // 
            this.groupBasic.Controls.Add(this.lblType);
            this.groupBasic.Controls.Add(this.lblConsultant);
            this.groupBasic.Controls.Add(this.lblCustomer);
            this.groupBasic.Controls.Add(this.lblTitle);
            this.groupBasic.Controls.Add(this.lblAppointmentId);
            this.groupBasic.Controls.Add(this.lblTypeLabel);
            this.groupBasic.Controls.Add(this.lblConsultantLabel);
            this.groupBasic.Controls.Add(this.lblCustomerLabel);
            this.groupBasic.Controls.Add(this.lblTitleLabel);
            this.groupBasic.Controls.Add(this.lblAppointmentIdLabel);
            this.groupBasic.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBasic.Location = new System.Drawing.Point(20, 20);
            this.groupBasic.Name = "groupBasic";
            this.groupBasic.Size = new System.Drawing.Size(544, 148);
            this.groupBasic.TabIndex = 0;
            this.groupBasic.TabStop = false;
            this.groupBasic.Text = "Basic Information";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(120, 110);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(58, 13);
            this.lblType.TabIndex = 9;
            this.lblType.Text = "Discussion";
            // 
            // lblConsultant
            // 
            this.lblConsultant.AutoSize = true;
            this.lblConsultant.Location = new System.Drawing.Point(120, 90);
            this.lblConsultant.Name = "lblConsultant";
            this.lblConsultant.Size = new System.Drawing.Size(28, 13);
            this.lblConsultant.TabIndex = 8;
            this.lblConsultant.Text = "Test";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(120, 70);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(53, 13);
            this.lblCustomer.TabIndex = 7;
            this.lblCustomer.Text = "John Doe";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(120, 50);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(94, 13);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Project Discussion";
            // 
            // lblAppointmentId
            // 
            this.lblAppointmentId.AutoSize = true;
            this.lblAppointmentId.Location = new System.Drawing.Point(120, 30);
            this.lblAppointmentId.Name = "lblAppointmentId";
            this.lblAppointmentId.Size = new System.Drawing.Size(13, 13);
            this.lblAppointmentId.TabIndex = 5;
            this.lblAppointmentId.Text = "1";
            // 
            // lblTypeLabel
            // 
            this.lblTypeLabel.AutoSize = true;
            this.lblTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeLabel.Location = new System.Drawing.Point(20, 110);
            this.lblTypeLabel.Name = "lblTypeLabel";
            this.lblTypeLabel.Size = new System.Drawing.Size(39, 13);
            this.lblTypeLabel.TabIndex = 4;
            this.lblTypeLabel.Text = "Type:";
            // 
            // lblConsultantLabel
            // 
            this.lblConsultantLabel.AutoSize = true;
            this.lblConsultantLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultantLabel.Location = new System.Drawing.Point(20, 90);
            this.lblConsultantLabel.Name = "lblConsultantLabel";
            this.lblConsultantLabel.Size = new System.Drawing.Size(71, 13);
            this.lblConsultantLabel.TabIndex = 3;
            this.lblConsultantLabel.Text = "Consultant:";
            // 
            // lblCustomerLabel
            // 
            this.lblCustomerLabel.AutoSize = true;
            this.lblCustomerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerLabel.Location = new System.Drawing.Point(20, 70);
            this.lblCustomerLabel.Name = "lblCustomerLabel";
            this.lblCustomerLabel.Size = new System.Drawing.Size(63, 13);
            this.lblCustomerLabel.TabIndex = 2;
            this.lblCustomerLabel.Text = "Customer:";
            // 
            // lblTitleLabel
            // 
            this.lblTitleLabel.AutoSize = true;
            this.lblTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleLabel.Location = new System.Drawing.Point(20, 50);
            this.lblTitleLabel.Name = "lblTitleLabel";
            this.lblTitleLabel.Size = new System.Drawing.Size(36, 13);
            this.lblTitleLabel.TabIndex = 1;
            this.lblTitleLabel.Text = "Title:";
            // 
            // lblAppointmentIdLabel
            // 
            this.lblAppointmentIdLabel.AutoSize = true;
            this.lblAppointmentIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentIdLabel.Location = new System.Drawing.Point(20, 30);
            this.lblAppointmentIdLabel.Name = "lblAppointmentIdLabel";
            this.lblAppointmentIdLabel.Size = new System.Drawing.Size(98, 13);
            this.lblAppointmentIdLabel.TabIndex = 0;
            this.lblAppointmentIdLabel.Text = "Appointment ID:";
            // 
            // AppointmentDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 671);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppointmentDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Appointment Details";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.groupSystemInfo.ResumeLayout(false);
            this.groupSystemInfo.PerformLayout();
            this.groupDetails.ResumeLayout(false);
            this.groupDetails.PerformLayout();
            this.groupSchedule.ResumeLayout(false);
            this.groupSchedule.PerformLayout();
            this.pnlWarning.ResumeLayout(false);
            this.pnlWarning.PerformLayout();
            this.groupBasic.ResumeLayout(false);
            this.groupBasic.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.GroupBox groupSystemInfo;
        private System.Windows.Forms.Label lblLastUpdated;
        private System.Windows.Forms.Label lblLastUpdatedLabel;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblCreatedByLabel;
        private System.Windows.Forms.GroupBox groupDetails;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblUrlLabel;
        private System.Windows.Forms.Label lblContactLabel;
        private System.Windows.Forms.Label lblLocationLabel;
        private System.Windows.Forms.Label lblDescriptionLabel;
        private System.Windows.Forms.GroupBox groupSchedule;
        private System.Windows.Forms.Label lblTimeZone;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEndLabel;
        private System.Windows.Forms.Label lblStartLabel;
        private System.Windows.Forms.GroupBox groupBasic;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblConsultant;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAppointmentId;
        private System.Windows.Forms.Label lblTypeLabel;
        private System.Windows.Forms.Label lblConsultantLabel;
        private System.Windows.Forms.Label lblCustomerLabel;
        private System.Windows.Forms.Label lblTitleLabel;
        private System.Windows.Forms.Label lblAppointmentIdLabel;
        private System.Windows.Forms.Panel pnlWarning;
        private System.Windows.Forms.Label lblWarning;

    }
}