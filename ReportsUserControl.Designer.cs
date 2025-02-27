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
            // Panels
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();

            this.pnlTabs = new System.Windows.Forms.TabControl();
            this.tabAppointmentTypes = new System.Windows.Forms.TabPage();
            this.tabConsultantSchedule = new System.Windows.Forms.TabPage();
            this.tabCustomerStats = new System.Windows.Forms.TabPage();

            // Appointment Types Tab Controls
            this.lblAppointmentTypesYear = new System.Windows.Forms.Label();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.btnAppointmentTypes = new System.Windows.Forms.Button();

            // Consultant Schedule Tab Controls
            this.lblConsultant = new System.Windows.Forms.Label();
            this.cbConsultant = new System.Windows.Forms.ComboBox();
            this.btnConsultantSchedule = new System.Windows.Forms.Button();

            // Customer Stats Tab Controls
            this.btnCustomerStats = new System.Windows.Forms.Button();

            // Report Grid
            this.dgvReport = new System.Windows.Forms.DataGridView();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 50;

            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Reports";
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);

            // 
            // pnlTabs
            // 
            this.pnlTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabs.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.tabAppointmentTypes,
                this.tabConsultantSchedule,
                this.tabCustomerStats
            });

            // 
            // tabAppointmentTypes
            // 
            this.tabAppointmentTypes.Text = "Appointment Types";

            // 
            // lblAppointmentTypesYear
            // 
            this.lblAppointmentTypesYear.Text = "Year:";
            this.lblAppointmentTypesYear.Location = new System.Drawing.Point(10, 20);
            this.lblAppointmentTypesYear.Width = 50;

            // 
            // cbYear
            // 
            this.cbYear.Location = new System.Drawing.Point(70, 17);
            this.cbYear.Width = 100;
            this.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // 
            // btnAppointmentTypes
            // 
            this.btnAppointmentTypes.Text = "Generate Report";
            this.btnAppointmentTypes.Location = new System.Drawing.Point(200, 17);
            this.btnAppointmentTypes.Width = 120;

            // 
            // tabConsultantSchedule
            // 
            this.tabConsultantSchedule.Text = "Consultant Schedule";
            
            // 
            // lblConsultant
            // 
            this.lblConsultant.Text = "Consultant:";
            this.lblConsultant.Location = new System.Drawing.Point(10, 20);
            this.lblConsultant.Width = 70;

            // 
            // cbConsultant
            // 
            this.cbConsultant.Location = new System.Drawing.Point(90, 17);
            this.cbConsultant.Width = 200;
            this.cbConsultant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // 
            // btnConsultantSchedule
            // 
            this.btnConsultantSchedule.Text = "Generate Report";
            this.btnConsultantSchedule.Location = new System.Drawing.Point(300, 17);
            this.btnConsultantSchedule.Width = 120;

            // 
            // tabCustomerStats
            // 
            this.tabCustomerStats.Text = "Customer Statistics";

            // 
            // btnCustomerStats
            // 
            this.btnCustomerStats.Text = "Generate Report";
            this.btnCustomerStats.Location = new System.Drawing.Point(10, 17);
            this.btnCustomerStats.Width = 120;

            // 
            // dgvReport
            // 
            this.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.ReadOnly = true;
            this.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // Layout controls in tabs
            this.tabAppointmentTypes.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblAppointmentTypesYear,
                this.cbYear,
                this.btnAppointmentTypes,
                this.dgvReport
            });

            this.tabConsultantSchedule.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblConsultant,
                this.cbConsultant,
                this.btnConsultantSchedule,
                this.dgvReport
            });

            this.tabCustomerStats.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnCustomerStats,
                this.dgvReport
            });

            // 
            // ReportsUserControl
            // 
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.pnlTabs,
                this.pnlHeader
            });
            this.Name = "ReportsUserControl";
            this.Size = new System.Drawing.Size(900, 600);

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