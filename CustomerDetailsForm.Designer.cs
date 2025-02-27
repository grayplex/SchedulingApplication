namespace SchedulingApplication
{
    partial class CustomerDetailsForm
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
            this.btnViewAppointments = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.groupSystemInfo = new System.Windows.Forms.GroupBox();
            this.lblLastUpdated = new System.Windows.Forms.Label();
            this.lblLastUpdatedLabel = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblCreatedByLabel = new System.Windows.Forms.Label();
            this.groupAddress = new System.Windows.Forms.GroupBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblPhoneLabel = new System.Windows.Forms.Label();
            this.lblPostalCode = new System.Windows.Forms.Label();
            this.lblPostalCodeLabel = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblCountryLabel = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblCityLabel = new System.Windows.Forms.Label();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.lblAddress2Label = new System.Windows.Forms.Label();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.lblAddress1Label = new System.Windows.Forms.Label();
            this.groupBasic = new System.Windows.Forms.GroupBox();
            this.lblActive = new System.Windows.Forms.Label();
            this.lblActiveLabel = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblCustomerNameLabel = new System.Windows.Forms.Label();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.lblCustomerIdLabel = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.groupSystemInfo.SuspendLayout();
            this.groupAddress.SuspendLayout();
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
            this.pnlHeader.Size = new System.Drawing.Size(534, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(16, 18);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(166, 24);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Customer Details";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnViewAppointments);
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 551);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(534, 60);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnViewAppointments
            // 
            this.btnViewAppointments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewAppointments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.btnViewAppointments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewAppointments.ForeColor = System.Drawing.Color.White;
            this.btnViewAppointments.Location = new System.Drawing.Point(159, 14);
            this.btnViewAppointments.Name = "btnViewAppointments";
            this.btnViewAppointments.Size = new System.Drawing.Size(167, 32);
            this.btnViewAppointments.TabIndex = 2;
            this.btnViewAppointments.Text = "View Appointments";
            this.btnViewAppointments.UseVisualStyleBackColor = false;
            this.btnViewAppointments.Click += new System.EventHandler(this.btnViewAppointments_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(332, 14);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 32);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(428, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 32);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.Controls.Add(this.groupSystemInfo);
            this.pnlContent.Controls.Add(this.groupAddress);
            this.pnlContent.Controls.Add(this.groupBasic);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 60);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Size = new System.Drawing.Size(534, 491);
            this.pnlContent.TabIndex = 2;
            // 
            // groupSystemInfo
            // 
            this.groupSystemInfo.Controls.Add(this.lblLastUpdated);
            this.groupSystemInfo.Controls.Add(this.lblLastUpdatedLabel);
            this.groupSystemInfo.Controls.Add(this.lblCreatedBy);
            this.groupSystemInfo.Controls.Add(this.lblCreatedByLabel);
            this.groupSystemInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupSystemInfo.Location = new System.Drawing.Point(20, 330);
            this.groupSystemInfo.Name = "groupSystemInfo";
            this.groupSystemInfo.Size = new System.Drawing.Size(494, 100);
            this.groupSystemInfo.TabIndex = 2;
            this.groupSystemInfo.TabStop = false;
            this.groupSystemInfo.Text = "System Information";
            // 
            // lblLastUpdated
            // 
            this.lblLastUpdated.AutoSize = true;
            this.lblLastUpdated.Location = new System.Drawing.Point(120, 60);
            this.lblLastUpdated.Name = "lblLastUpdated";
            this.lblLastUpdated.Size = new System.Drawing.Size(116, 13);
            this.lblLastUpdated.TabIndex = 3;
            this.lblLastUpdated.Text = "test on 01/01/2025...";
            // 
            // lblLastUpdatedLabel
            // 
            this.lblLastUpdatedLabel.AutoSize = true;
            this.lblLastUpdatedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastUpdatedLabel.Location = new System.Drawing.Point(20, 60);
            this.lblLastUpdatedLabel.Name = "lblLastUpdatedLabel";
            this.lblLastUpdatedLabel.Size = new System.Drawing.Size(89, 13);
            this.lblLastUpdatedLabel.TabIndex = 2;
            this.lblLastUpdatedLabel.Text = "Last Updated:";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(120, 30);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(116, 13);
            this.lblCreatedBy.TabIndex = 1;
            this.lblCreatedBy.Text = "test on 01/01/2025...";
            // 
            // lblCreatedByLabel
            // 
            this.lblCreatedByLabel.AutoSize = true;
            this.lblCreatedByLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByLabel.Location = new System.Drawing.Point(20, 30);
            this.lblCreatedByLabel.Name = "lblCreatedByLabel";
            this.lblCreatedByLabel.Size = new System.Drawing.Size(72, 13);
            this.lblCreatedByLabel.TabIndex = 0;
            this.lblCreatedByLabel.Text = "Created By:";
            // 
            // groupAddress
            // 
            this.groupAddress.Controls.Add(this.lblPhone);
            this.groupAddress.Controls.Add(this.lblPhoneLabel);
            this.groupAddress.Controls.Add(this.lblPostalCode);
            this.groupAddress.Controls.Add(this.lblPostalCodeLabel);
            this.groupAddress.Controls.Add(this.lblCountry);
            this.groupAddress.Controls.Add(this.lblCountryLabel);
            this.groupAddress.Controls.Add(this.lblCity);
            this.groupAddress.Controls.Add(this.lblCityLabel);
            this.groupAddress.Controls.Add(this.lblAddress2);
            this.groupAddress.Controls.Add(this.lblAddress2Label);
            this.groupAddress.Controls.Add(this.lblAddress1);
            this.groupAddress.Controls.Add(this.lblAddress1Label);
            this.groupAddress.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupAddress.Location = new System.Drawing.Point(20, 130);
            this.groupAddress.Name = "groupAddress";
            this.groupAddress.Size = new System.Drawing.Size(494, 200);
            this.groupAddress.TabIndex = 1;
            this.groupAddress.TabStop = false;
            this.groupAddress.Text = "Address Information";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(120, 170);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(79, 13);
            this.lblPhone.TabIndex = 11;
            this.lblPhone.Text = "123-555-6789";
            // 
            // lblPhoneLabel
            // 
            this.lblPhoneLabel.AutoSize = true;
            this.lblPhoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneLabel.Location = new System.Drawing.Point(20, 170);
            this.lblPhoneLabel.Name = "lblPhoneLabel";
            this.lblPhoneLabel.Size = new System.Drawing.Size(47, 13);
            this.lblPhoneLabel.TabIndex = 10;
            this.lblPhoneLabel.Text = "Phone:";
            // 
            // lblPostalCode
            // 
            this.lblPostalCode.AutoSize = true;
            this.lblPostalCode.Location = new System.Drawing.Point(120, 140);
            this.lblPostalCode.Name = "lblPostalCode";
            this.lblPostalCode.Size = new System.Drawing.Size(43, 13);
            this.lblPostalCode.TabIndex = 9;
            this.lblPostalCode.Text = "123456";
            // 
            // lblPostalCodeLabel
            // 
            this.lblPostalCodeLabel.AutoSize = true;
            this.lblPostalCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostalCodeLabel.Location = new System.Drawing.Point(20, 140);
            this.lblPostalCodeLabel.Name = "lblPostalCodeLabel";
            this.lblPostalCodeLabel.Size = new System.Drawing.Size(81, 13);
            this.lblPostalCodeLabel.TabIndex = 8;
            this.lblPostalCodeLabel.Text = "Postal Code:";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(120, 110);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(82, 13);
            this.lblCountry.TabIndex = 7;
            this.lblCountry.Text = "United Kingdom";
            // 
            // lblCountryLabel
            // 
            this.lblCountryLabel.AutoSize = true;
            this.lblCountryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountryLabel.Location = new System.Drawing.Point(20, 110);
            this.lblCountryLabel.Name = "lblCountryLabel";
            this.lblCountryLabel.Size = new System.Drawing.Size(54, 13);
            this.lblCountryLabel.TabIndex = 6;
            this.lblCountryLabel.Text = "Country:";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(120, 80);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(42, 13);
            this.lblCity.TabIndex = 5;
            this.lblCity.Text = "London";
            // 
            // lblCityLabel
            // 
            this.lblCityLabel.AutoSize = true;
            this.lblCityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCityLabel.Location = new System.Drawing.Point(20, 80);
            this.lblCityLabel.Name = "lblCityLabel";
            this.lblCityLabel.Size = new System.Drawing.Size(32, 13);
            this.lblCityLabel.TabIndex = 4;
            this.lblCityLabel.Text = "City:";
            // 
            // lblAddress2
            // 
            this.lblAddress2.AutoSize = true;
            this.lblAddress2.Location = new System.Drawing.Point(120, 50);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(35, 13);
            this.lblAddress2.TabIndex = 3;
            this.lblAddress2.Text = "Apt. 5";
            // 
            // lblAddress2Label
            // 
            this.lblAddress2Label.AutoSize = true;
            this.lblAddress2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress2Label.Location = new System.Drawing.Point(20, 50);
            this.lblAddress2Label.Name = "lblAddress2Label";
            this.lblAddress2Label.Size = new System.Drawing.Size(69, 13);
            this.lblAddress2Label.TabIndex = 2;
            this.lblAddress2Label.Text = "Address 2:";
            // 
            // lblAddress1
            // 
            this.lblAddress1.AutoSize = true;
            this.lblAddress1.Location = new System.Drawing.Point(120, 30);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(116, 13);
            this.lblAddress1.TabIndex = 1;
            this.lblAddress1.Text = "123 Westminster Lane";
            // 
            // lblAddress1Label
            // 
            this.lblAddress1Label.AutoSize = true;
            this.lblAddress1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress1Label.Location = new System.Drawing.Point(20, 30);
            this.lblAddress1Label.Name = "lblAddress1Label";
            this.lblAddress1Label.Size = new System.Drawing.Size(69, 13);
            this.lblAddress1Label.TabIndex = 0;
            this.lblAddress1Label.Text = "Address 1:";
            // 
            // groupBasic
            // 
            this.groupBasic.Controls.Add(this.lblActive);
            this.groupBasic.Controls.Add(this.lblActiveLabel);
            this.groupBasic.Controls.Add(this.lblCustomerName);
            this.groupBasic.Controls.Add(this.lblCustomerNameLabel);
            this.groupBasic.Controls.Add(this.lblCustomerId);
            this.groupBasic.Controls.Add(this.lblCustomerIdLabel);
            this.groupBasic.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBasic.Location = new System.Drawing.Point(20, 20);
            this.groupBasic.Name = "groupBasic";
            this.groupBasic.Size = new System.Drawing.Size(494, 110);
            this.groupBasic.TabIndex = 0;
            this.groupBasic.TabStop = false;
            this.groupBasic.Text = "Basic Information";
            // 
            // lblActive
            // 
            this.lblActive.AutoSize = true;
            this.lblActive.Location = new System.Drawing.Point(120, 80);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(37, 13);
            this.lblActive.TabIndex = 5;
            this.lblActive.Text = "Active";
            // 
            // lblActiveLabel
            // 
            this.lblActiveLabel.AutoSize = true;
            this.lblActiveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveLabel.Location = new System.Drawing.Point(20, 80);
            this.lblActiveLabel.Name = "lblActiveLabel";
            this.lblActiveLabel.Size = new System.Drawing.Size(47, 13);
            this.lblActiveLabel.TabIndex = 4;
            this.lblActiveLabel.Text = "Status:";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(120, 50);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(117, 13);
            this.lblCustomerName.TabIndex = 3;
            this.lblCustomerName.Text = "ABC Software, Ltd.";
            // 
            // lblCustomerNameLabel
            // 
            this.lblCustomerNameLabel.AutoSize = true;
            this.lblCustomerNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerNameLabel.Location = new System.Drawing.Point(20, 50);
            this.lblCustomerNameLabel.Name = "lblCustomerNameLabel";
            this.lblCustomerNameLabel.Size = new System.Drawing.Size(43, 13);
            this.lblCustomerNameLabel.TabIndex = 2;
            this.lblCustomerNameLabel.Text = "Name:";
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Location = new System.Drawing.Point(120, 30);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(13, 13);
            this.lblCustomerId.TabIndex = 1;
            this.lblCustomerId.Text = "1";
            // 
            // lblCustomerIdLabel
            // 
            this.lblCustomerIdLabel.AutoSize = true;
            this.lblCustomerIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerIdLabel.Location = new System.Drawing.Point(20, 30);
            this.lblCustomerIdLabel.Name = "lblCustomerIdLabel";
            this.lblCustomerIdLabel.Size = new System.Drawing.Size(82, 13);
            this.lblCustomerIdLabel.TabIndex = 0;
            this.lblCustomerIdLabel.Text = "Customer ID:";
            // 
            // CustomerDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 611);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customer Details";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.groupSystemInfo.ResumeLayout(false);
            this.groupSystemInfo.PerformLayout();
            this.groupAddress.ResumeLayout(false);
            this.groupAddress.PerformLayout();
            this.groupBasic.ResumeLayout(false);
            this.groupBasic.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnViewAppointments;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.GroupBox groupSystemInfo;
        private System.Windows.Forms.Label lblLastUpdated;
        private System.Windows.Forms.Label lblLastUpdatedLabel;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblCreatedByLabel;
        private System.Windows.Forms.GroupBox groupAddress;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblPhoneLabel;
        private System.Windows.Forms.Label lblPostalCode;
        private System.Windows.Forms.Label lblPostalCodeLabel;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblCountryLabel;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblCityLabel;
        private System.Windows.Forms.Label lblAddress2;
        private System.Windows.Forms.Label lblAddress2Label;
        private System.Windows.Forms.Label lblAddress1;
        private System.Windows.Forms.Label lblAddress1Label;
        private System.Windows.Forms.GroupBox groupBasic;
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.Label lblActiveLabel;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblCustomerNameLabel;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.Label lblCustomerIdLabel;
    }
}