namespace SchedulingApplication
{
    partial class ReportsUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlTabs = new System.Windows.Forms.TabControl();
            this.tabAppointmentTypes = new System.Windows.Forms.TabPage();
            this.lblAppointmentTypesYear = new System.Windows.Forms.Label();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.btnAppointmentTypes = new System.Windows.Forms.Button();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.tabConsultantSchedule = new System.Windows.Forms.TabPage();
            this.lblConsultant = new System.Windows.Forms.Label();
            this.cbConsultant = new System.Windows.Forms.ComboBox();
            this.btnConsultantSchedule = new System.Windows.Forms.Button();
            this.tabCustomerStats = new System.Windows.Forms.TabPage();
            this.btnCustomerStats = new System.Windows.Forms.Button();
            this.pnlTabs.SuspendLayout();
            this.tabAppointmentTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.tabConsultantSchedule.SuspendLayout();
            this.tabCustomerStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 50);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(100, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Reports";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTabs
            // 
            this.pnlTabs.Controls.Add(this.tabAppointmentTypes);
            this.pnlTabs.Controls.Add(this.tabConsultantSchedule);
            this.pnlTabs.Controls.Add(this.tabCustomerStats);
            this.pnlTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabs.Location = new System.Drawing.Point(0, 50);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.SelectedIndex = 0;
            this.pnlTabs.Size = new System.Drawing.Size(900, 550);
            this.pnlTabs.TabIndex = 0;
            // 
            // tabAppointmentTypes
            // 
            this.tabAppointmentTypes.Controls.Add(this.lblAppointmentTypesYear);
            this.tabAppointmentTypes.Controls.Add(this.cbYear);
            this.tabAppointmentTypes.Controls.Add(this.btnAppointmentTypes);
            this.tabAppointmentTypes.Location = new System.Drawing.Point(4, 22);
            this.tabAppointmentTypes.Name = "tabAppointmentTypes";
            this.tabAppointmentTypes.Size = new System.Drawing.Size(892, 524);
            this.tabAppointmentTypes.TabIndex = 0;
            this.tabAppointmentTypes.Text = "Appointment Types";
            // 
            // lblAppointmentTypesYear
            // 
            this.lblAppointmentTypesYear.Location = new System.Drawing.Point(10, 20);
            this.lblAppointmentTypesYear.Name = "lblAppointmentTypesYear";
            this.lblAppointmentTypesYear.Size = new System.Drawing.Size(50, 23);
            this.lblAppointmentTypesYear.TabIndex = 0;
            this.lblAppointmentTypesYear.Text = "Year:";
            // 
            // cbYear
            // 
            this.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYear.Location = new System.Drawing.Point(70, 17);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(100, 21);
            this.cbYear.TabIndex = 1;
            // 
            // btnAppointmentTypes
            // 
            this.btnAppointmentTypes.Location = new System.Drawing.Point(200, 17);
            this.btnAppointmentTypes.Name = "btnAppointmentTypes";
            this.btnAppointmentTypes.Size = new System.Drawing.Size(120, 23);
            this.btnAppointmentTypes.TabIndex = 2;
            this.btnAppointmentTypes.Text = "Generate Report";
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReport.Location = new System.Drawing.Point(0, 0);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReport.Size = new System.Drawing.Size(892, 524);
            this.dgvReport.TabIndex = 3;
            // 
            // tabConsultantSchedule
            // 
            this.tabConsultantSchedule.Controls.Add(this.lblConsultant);
            this.tabConsultantSchedule.Controls.Add(this.cbConsultant);
            this.tabConsultantSchedule.Controls.Add(this.btnConsultantSchedule);
            this.tabConsultantSchedule.Location = new System.Drawing.Point(4, 22);
            this.tabConsultantSchedule.Name = "tabConsultantSchedule";
            this.tabConsultantSchedule.Size = new System.Drawing.Size(892, 524);
            this.tabConsultantSchedule.TabIndex = 1;
            this.tabConsultantSchedule.Text = "Consultant Schedule";
            // 
            // lblConsultant
            // 
            this.lblConsultant.Location = new System.Drawing.Point(10, 20);
            this.lblConsultant.Name = "lblConsultant";
            this.lblConsultant.Size = new System.Drawing.Size(70, 23);
            this.lblConsultant.TabIndex = 0;
            this.lblConsultant.Text = "Consultant:";
            // 
            // cbConsultant
            // 
            this.cbConsultant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConsultant.Location = new System.Drawing.Point(90, 17);
            this.cbConsultant.Name = "cbConsultant";
            this.cbConsultant.Size = new System.Drawing.Size(200, 21);
            this.cbConsultant.TabIndex = 1;
            // 
            // btnConsultantSchedule
            // 
            this.btnConsultantSchedule.Location = new System.Drawing.Point(300, 17);
            this.btnConsultantSchedule.Name = "btnConsultantSchedule";
            this.btnConsultantSchedule.Size = new System.Drawing.Size(120, 23);
            this.btnConsultantSchedule.TabIndex = 2;
            this.btnConsultantSchedule.Text = "Generate Report";
            // 
            // tabCustomerStats
            // 
            this.tabCustomerStats.Controls.Add(this.btnCustomerStats);
            this.tabCustomerStats.Controls.Add(this.dgvReport);
            this.tabCustomerStats.Location = new System.Drawing.Point(4, 22);
            this.tabCustomerStats.Name = "tabCustomerStats";
            this.tabCustomerStats.Size = new System.Drawing.Size(892, 524);
            this.tabCustomerStats.TabIndex = 2;
            this.tabCustomerStats.Text = "Customer Statistics";
            // 
            // btnCustomerStats
            // 
            this.btnCustomerStats.Location = new System.Drawing.Point(10, 17);
            this.btnCustomerStats.Name = "btnCustomerStats";
            this.btnCustomerStats.Size = new System.Drawing.Size(120, 23);
            this.btnCustomerStats.TabIndex = 0;
            this.btnCustomerStats.Text = "Generate Report";
            // 
            // ReportsUserControl
            // 
            this.Controls.Add(this.pnlTabs);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ReportsUserControl";
            this.Size = new System.Drawing.Size(900, 600);
            this.pnlTabs.ResumeLayout(false);
            this.tabAppointmentTypes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.tabConsultantSchedule.ResumeLayout(false);
            this.tabCustomerStats.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // Header Panel
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;

        // Tabs Panel
        private System.Windows.Forms.TabControl pnlTabs;
        private System.Windows.Forms.TabPage tabAppointmentTypes;
        private System.Windows.Forms.TabPage tabConsultantSchedule;
        private System.Windows.Forms.TabPage tabCustomerStats;

        // Appointment Types Tab Controls
        private System.Windows.Forms.Label lblAppointmentTypesYear;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.Button btnAppointmentTypes;

        // Consultant Schedule Tab Controls
        private System.Windows.Forms.Label lblConsultant;
        private System.Windows.Forms.ComboBox cbConsultant;
        private System.Windows.Forms.Button btnConsultantSchedule;

        // Customer Stats Tab Controls
        private System.Windows.Forms.Button btnCustomerStats;

        // Report Grid
        private System.Windows.Forms.DataGridView dgvReport;
    }
}