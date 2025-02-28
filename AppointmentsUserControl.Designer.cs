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
            this.lblTimeFilter.Width = 50;

            // 
            // cbTimeFilter
            // 
            this.cbTimeFilter.Location = new System.Drawing.Point(70, 12);
            this.cbTimeFilter.Width = 200;
            this.cbTimeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // 
            // lblStartDate
            // 
            this.lblStartDate.Text = "Start:";
            this.lblStartDate.Location = new System.Drawing.Point(280, 15);
            this.lblStartDate.Width = 50;

            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(330, 12);
            this.dtStart.Width = 100;
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStart.Enabled = false;

            // 
            // lblEndDate
            // 
            this.lblEndDate.Text = "End:";
            this.lblEndDate.Location = new System.Drawing.Point(450, 15);
            this.lblEndDate.Width = 50;

            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(500, 12);
            this.dtEnd.Width = 100;
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEnd.Enabled = false;

            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.Text = "Add Appointment";
            this.btnAddAppointment.Location = new System.Drawing.Point(700, 12);
            this.btnAddAppointment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.btnAddAppointment.ForeColor = System.Drawing.Color.White;
            this.btnAddAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAppointment.Size = new System.Drawing.Size(120, 30);
            this.btnAddAppointment.UseVisualStyleBackColor = false;

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
            this.colTitle.Width = 150;
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
            this.colStart.Width = 125;
            this.colStart.ReadOnly = true;

            this.colEnd.Name = "End";
            this.colEnd.HeaderText = "End";
            this.colEnd.Width = 125;
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
            this.btnViewDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnViewDetails.Enabled = false;
            this.btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDetails.ForeColor = System.Drawing.Color.White;
            this.btnViewDetails.Location = new System.Drawing.Point(460, 15);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(90, 30);
            this.btnViewDetails.TabIndex = 0;
            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.UseVisualStyleBackColor = false;

            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnEdit.Enabled = false;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(556, 15);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 30);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;

            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(652, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;

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