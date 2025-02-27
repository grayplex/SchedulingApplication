namespace SchedulingApplication
{
    partial class AppointmentsUserControl
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
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblTimeFilter = new System.Windows.Forms.Label();
            this.cbTimeFilter = new System.Windows.Forms.ComboBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();


            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 50;

            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Appointments";
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // pnlFilter
            // 
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Height = 60;
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // 
            // lblTimeFilter
            // 
            this.lblTimeFilter.Text = "Filter:";
            this.lblTimeFilter.Location = new System.Drawing.Point(10, 15);
            this.lblTimeFilter.Width = 100;

            // 
            // cbTimeFilter
            // 
            this.cbTimeFilter.Location = new System.Drawing.Point(120, 12);
            this.cbTimeFilter.Width = 200;
            this.cbTimeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // 
            // lblStartDate
            // 
            this.lblStartDate.Text = "Start:";
            this.lblStartDate.Location = new System.Drawing.Point(330, 15);
            this.lblStartDate.Width = 100;

            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(430, 12);
            this.dtStart.Width = 120;
            this.dtStart.Enabled = false;

            // 
            // lblEndDate
            // 
            this.lblEndDate.Text = "End:";
            this.lblEndDate.Location = new System.Drawing.Point(560, 15);
            this.lblEndDate.Width = 100;

            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(660, 12);
            this.dtEnd.Width = 120;
            this.dtEnd.Enabled = false;

            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.Text = "Add Appointment";
            this.btnAddAppointment.Location = new System.Drawing.Point(790, 12);
            this.btnAddAppointment.Width = 120;
            this.btnAddAppointment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.btnAddAppointment.ForeColor = System.Drawing.Color.White;

            // 
            // pnlGrid
            // 
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(10);

            // 
            // dgvAppointments
            // 
            this.dgvAppointments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToDeleteRows = false;
            this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.ReadOnly = true;

            // Configure DataGridView Columns
            this.dgvAppointments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colId,
                this.colTitle,
                this.colCustomer,
                this.colType,
                this.colStart,
                this.colEnd,
                this.colLocation
            });
            this.colId.Name = "Id";
            this.colId.HeaderText = "ID";
            this.colId.Visible = false;
            this.colId.ReadOnly = true;

            this.colTitle.Name = "Title";
            this.colTitle.HeaderText = "Title";
            this.colTitle.Width = 180;
            this.colTitle.ReadOnly = true;

            this.colCustomer.Name = "Customer";
            this.colCustomer.HeaderText = "Customer";
            this.colCustomer.Width = 180;
            this.colCustomer.ReadOnly = true;

            this.colType.Name = "Type";
            this.colType.HeaderText = "Type";
            this.colType.Width = 120;
            this.colType.ReadOnly = true;

            this.colStart.Name = "Start";
            this.colStart.HeaderText = "Start";
            this.colStart.Width = 170;
            this.colStart.ReadOnly = true;

            this.colEnd.Name = "End";
            this.colEnd.HeaderText = "End";
            this.colEnd.Width = 170;
            this.colEnd.ReadOnly = true;

            this.colLocation.Name = "Location";
            this.colLocation.HeaderText = "Location";
            this.colLocation.Width = 150;
            this.colLocation.ReadOnly = true;


            // 
            // pnlButtons
            // 
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Height = 60;
            this.pnlButtons.BackColor = System.Drawing.SystemColors.Control;

            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.Enabled = false;
            this.btnViewDetails.Location = new System.Drawing.Point(400, 15);
            this.btnViewDetails.Width = 120;

            // 
            // btnEdit
            // 
            this.btnEdit.Text = "Edit";
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(530, 15);
            this.btnEdit.Width = 120;

            // 
            // btnDelete
            // 
            this.btnDelete.Text = "Delete";
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(660, 15);
            this.btnDelete.Width = 120;

            // 
            // AppointmentsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlHeader);
            this.Name = "AppointmentsUserControl";
            this.Size = new System.Drawing.Size(900, 600);
            // Add controls to panels
            this.pnlGrid.Controls.Add(this.dgvAppointments);
            this.pnlFilter.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTimeFilter,
                this.cbTimeFilter,
                this.lblStartDate,
                this.dtStart,
                this.lblEndDate,
                this.dtEnd,
                this.btnAddAppointment
            });
            this.pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnViewDetails,
                this.btnEdit,
                this.btnDelete
            });
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        // Header Panel
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;

        // Filter Panel
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblTimeFilter;
        private System.Windows.Forms.ComboBox cbTimeFilter;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.Button btnAddAppointment;

        // Grid Panel
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvAppointments;

        // Buttons Panel
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;

        // DataGridView Columns
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocation;

    }
}