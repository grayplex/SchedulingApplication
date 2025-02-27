namespace SchedulingApplication
{
    partial class CalendarUserControl
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
            this.pnlMonthNavigation = new System.Windows.Forms.Panel();
            this.btnNextMonth = new System.Windows.Forms.Button();
            this.lblMonthYear = new System.Windows.Forms.Label();
            this.btnPreviousMonth = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pnlCalendarContainer = new System.Windows.Forms.Panel();
            this.pnlDaysOfWeek = new System.Windows.Forms.Panel();
            this.lblSaturday = new System.Windows.Forms.Label();
            this.lblFriday = new System.Windows.Forms.Label();
            this.lblThursday = new System.Windows.Forms.Label();
            this.lblWednesday = new System.Windows.Forms.Label();
            this.lblTuesday = new System.Windows.Forms.Label();
            this.lblMonday = new System.Windows.Forms.Label();
            this.lblSunday = new System.Windows.Forms.Label();
            this.pnlCalendar = new System.Windows.Forms.Panel();
            this.pnlAppointments = new System.Windows.Forms.Panel();
            this.pnlAppointmentsHeader = new System.Windows.Forms.Panel();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.lblSelectedDate = new System.Windows.Forms.Label();
            this.pnlAppointmentsList = new System.Windows.Forms.Panel();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNoAppointments = new System.Windows.Forms.Label();
            this.pnlAppointmentsActions = new System.Windows.Forms.Panel();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlMonthNavigation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.pnlCalendarContainer.SuspendLayout();
            this.pnlDaysOfWeek.SuspendLayout();
            this.pnlAppointments.SuspendLayout();
            this.pnlAppointmentsHeader.SuspendLayout();
            this.pnlAppointmentsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.pnlAppointmentsActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(17, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(149, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Calendar View";
            // 
            // pnlMonthNavigation
            // 
            this.pnlMonthNavigation.BackColor = System.Drawing.Color.White;
            this.pnlMonthNavigation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMonthNavigation.Controls.Add(this.btnNextMonth);
            this.pnlMonthNavigation.Controls.Add(this.lblMonthYear);
            this.pnlMonthNavigation.Controls.Add(this.btnPreviousMonth);
            this.pnlMonthNavigation.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMonthNavigation.Location = new System.Drawing.Point(0, 50);
            this.pnlMonthNavigation.Name = "pnlMonthNavigation";
            this.pnlMonthNavigation.Size = new System.Drawing.Size(900, 50);
            this.pnlMonthNavigation.TabIndex = 1;
            // 
            // btnNextMonth
            // 
            this.btnNextMonth.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNextMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.btnNextMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextMonth.ForeColor = System.Drawing.Color.White;
            this.btnNextMonth.Location = new System.Drawing.Point(500, 8);
            this.btnNextMonth.Name = "btnNextMonth";
            this.btnNextMonth.Size = new System.Drawing.Size(40, 33);
            this.btnNextMonth.TabIndex = 2;
            this.btnNextMonth.Text = ">";
            this.btnNextMonth.UseVisualStyleBackColor = false;
            // 
            // lblMonthYear
            // 
            this.lblMonthYear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMonthYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthYear.Location = new System.Drawing.Point(350, 15);
            this.lblMonthYear.Name = "lblMonthYear";
            this.lblMonthYear.Size = new System.Drawing.Size(200, 20);
            this.lblMonthYear.TabIndex = 1;
            this.lblMonthYear.Text = "April 2025";
            this.lblMonthYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPreviousMonth
            // 
            this.btnPreviousMonth.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPreviousMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.btnPreviousMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreviousMonth.ForeColor = System.Drawing.Color.White;
            this.btnPreviousMonth.Location = new System.Drawing.Point(350, 8);
            this.btnPreviousMonth.Name = "btnPreviousMonth";
            this.btnPreviousMonth.Size = new System.Drawing.Size(40, 33);
            this.btnPreviousMonth.TabIndex = 0;
            this.btnPreviousMonth.Text = "<";
            this.btnPreviousMonth.UseVisualStyleBackColor = false;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 100);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.pnlCalendarContainer);
            this.splitContainer.Panel1MinSize = 400;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.pnlAppointments);
            this.splitContainer.Panel2MinSize = 300;
            this.splitContainer.Size = new System.Drawing.Size(900, 500);
            this.splitContainer.SplitterDistance = 550;
            this.splitContainer.TabIndex = 2;
            // 
            // pnlCalendarContainer
            // 
            this.pnlCalendarContainer.BackColor = System.Drawing.Color.White;
            this.pnlCalendarContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCalendarContainer.Controls.Add(this.pnlDaysOfWeek);
            this.pnlCalendarContainer.Controls.Add(this.pnlCalendar);
            this.pnlCalendarContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCalendarContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlCalendarContainer.Margin = new System.Windows.Forms.Padding(10);
            this.pnlCalendarContainer.Name = "pnlCalendarContainer";
            this.pnlCalendarContainer.Padding = new System.Windows.Forms.Padding(10);
            this.pnlCalendarContainer.Size = new System.Drawing.Size(550, 500);
            this.pnlCalendarContainer.TabIndex = 0;
            // 
            // pnlDaysOfWeek
            // 
            this.pnlDaysOfWeek.Controls.Add(this.lblSaturday);
            this.pnlDaysOfWeek.Controls.Add(this.lblFriday);
            this.pnlDaysOfWeek.Controls.Add(this.lblThursday);
            this.pnlDaysOfWeek.Controls.Add(this.lblWednesday);
            this.pnlDaysOfWeek.Controls.Add(this.lblTuesday);
            this.pnlDaysOfWeek.Controls.Add(this.lblMonday);
            this.pnlDaysOfWeek.Controls.Add(this.lblSunday);
            this.pnlDaysOfWeek.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDaysOfWeek.Location = new System.Drawing.Point(10, 10);
            this.pnlDaysOfWeek.Name = "pnlDaysOfWeek";
            this.pnlDaysOfWeek.Size = new System.Drawing.Size(528, 30);
            this.pnlDaysOfWeek.TabIndex = 1;
            // 
            // lblSaturday
            // 
            this.lblSaturday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaturday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSaturday.Location = new System.Drawing.Point(240, 5);
            this.lblSaturday.Name = "lblSaturday";
            this.lblSaturday.Size = new System.Drawing.Size(40, 20);
            this.lblSaturday.TabIndex = 6;
            this.lblSaturday.Text = "Sat";
            this.lblSaturday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFriday
            // 
            this.lblFriday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFriday.Location = new System.Drawing.Point(200, 5);
            this.lblFriday.Name = "lblFriday";
            this.lblFriday.Size = new System.Drawing.Size(40, 20);
            this.lblFriday.TabIndex = 5;
            this.lblFriday.Text = "Fri";
            this.lblFriday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblThursday
            // 
            this.lblThursday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThursday.Location = new System.Drawing.Point(160, 5);
            this.lblThursday.Name = "lblThursday";
            this.lblThursday.Size = new System.Drawing.Size(40, 20);
            this.lblThursday.TabIndex = 4;
            this.lblThursday.Text = "Thu";
            this.lblThursday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWednesday
            // 
            this.lblWednesday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWednesday.Location = new System.Drawing.Point(120, 5);
            this.lblWednesday.Name = "lblWednesday";
            this.lblWednesday.Size = new System.Drawing.Size(40, 20);
            this.lblWednesday.TabIndex = 3;
            this.lblWednesday.Text = "Wed";
            this.lblWednesday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTuesday
            // 
            this.lblTuesday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuesday.Location = new System.Drawing.Point(80, 5);
            this.lblTuesday.Name = "lblTuesday";
            this.lblTuesday.Size = new System.Drawing.Size(40, 20);
            this.lblTuesday.TabIndex = 2;
            this.lblTuesday.Text = "Tue";
            this.lblTuesday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMonday
            // 
            this.lblMonday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonday.Location = new System.Drawing.Point(40, 5);
            this.lblMonday.Name = "lblMonday";
            this.lblMonday.Size = new System.Drawing.Size(40, 20);
            this.lblMonday.TabIndex = 1;
            this.lblMonday.Text = "Mon";
            this.lblMonday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSunday
            // 
            this.lblSunday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSunday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSunday.Location = new System.Drawing.Point(0, 5);
            this.lblSunday.Name = "lblSunday";
            this.lblSunday.Size = new System.Drawing.Size(40, 20);
            this.lblSunday.TabIndex = 0;
            this.lblSunday.Text = "Sun";
            this.lblSunday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCalendar
            // 
            this.pnlCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCalendar.Location = new System.Drawing.Point(10, 46);
            this.pnlCalendar.Name = "pnlCalendar";
            this.pnlCalendar.Size = new System.Drawing.Size(528, 442);
            this.pnlCalendar.TabIndex = 0;
            // 
            // pnlAppointments
            // 
            this.pnlAppointments.BackColor = System.Drawing.Color.White;
            this.pnlAppointments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAppointments.Controls.Add(this.pnlAppointmentsHeader);
            this.pnlAppointments.Controls.Add(this.pnlAppointmentsList);
            this.pnlAppointments.Controls.Add(this.pnlAppointmentsActions);
            this.pnlAppointments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAppointments.Location = new System.Drawing.Point(0, 0);
            this.pnlAppointments.Margin = new System.Windows.Forms.Padding(10);
            this.pnlAppointments.Name = "pnlAppointments";
            this.pnlAppointments.Size = new System.Drawing.Size(346, 500);
            this.pnlAppointments.TabIndex = 1;
            // 
            // pnlAppointmentsHeader
            // 
            this.pnlAppointmentsHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.pnlAppointmentsHeader.Controls.Add(this.btnAddAppointment);
            this.pnlAppointmentsHeader.Controls.Add(this.lblSelectedDate);
            this.pnlAppointmentsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAppointmentsHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlAppointmentsHeader.Name = "pnlAppointmentsHeader";
            this.pnlAppointmentsHeader.Size = new System.Drawing.Size(344, 60);
            this.pnlAppointmentsHeader.TabIndex = 2;
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAppointment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.btnAddAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAppointment.ForeColor = System.Drawing.Color.White;
            this.btnAddAppointment.Location = new System.Drawing.Point(257, 17);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Size = new System.Drawing.Size(75, 30);
            this.btnAddAppointment.TabIndex = 1;
            this.btnAddAppointment.Text = "Add";
            this.btnAddAppointment.UseVisualStyleBackColor = false;
            // 
            // lblSelectedDate
            // 
            this.lblSelectedDate.AutoSize = true;
            this.lblSelectedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedDate.Location = new System.Drawing.Point(12, 23);
            this.lblSelectedDate.Name = "lblSelectedDate";
            this.lblSelectedDate.Size = new System.Drawing.Size(189, 17);
            this.lblSelectedDate.TabIndex = 0;
            this.lblSelectedDate.Text = "Monday, February 1, 2025";
            // 
            // pnlAppointmentsList
            // 
            this.pnlAppointmentsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAppointmentsList.Controls.Add(this.dgvAppointments);
            this.pnlAppointmentsList.Controls.Add(this.lblNoAppointments);
            this.pnlAppointmentsList.Location = new System.Drawing.Point(0, 60);
            this.pnlAppointmentsList.Name = "pnlAppointmentsList";
            this.pnlAppointmentsList.Size = new System.Drawing.Size(344, 388);
            this.pnlAppointmentsList.TabIndex = 1;
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToDeleteRows = false;
            this.dgvAppointments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTime,
            this.colTitle,
            this.colCustomer,
            this.colType});
            this.dgvAppointments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAppointments.Location = new System.Drawing.Point(0, 0);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.RowHeadersVisible = false;
            this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.Size = new System.Drawing.Size(344, 388);
            this.dgvAppointments.TabIndex = 0;
            // 
            // colTime
            // 
            this.colTime.HeaderText = "Time";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            this.colTime.Width = 70;
            // 
            // colTitle
            // 
            this.colTitle.HeaderText = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            this.colTitle.Width = 120;
            // 
            // colCustomer
            // 
            this.colCustomer.HeaderText = "Customer";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            this.colCustomer.Width = 80;
            // 
            // colType
            // 
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 70;
            // 
            // lblNoAppointments
            // 
            this.lblNoAppointments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNoAppointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoAppointments.ForeColor = System.Drawing.Color.Gray;
            this.lblNoAppointments.Location = new System.Drawing.Point(0, 0);
            this.lblNoAppointments.Name = "lblNoAppointments";
            this.lblNoAppointments.Size = new System.Drawing.Size(344, 388);
            this.lblNoAppointments.TabIndex = 1;
            this.lblNoAppointments.Text = "No appointments for this day";
            this.lblNoAppointments.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlAppointmentsActions
            // 
            this.pnlAppointmentsActions.Controls.Add(this.btnViewDetails);
            this.pnlAppointmentsActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAppointmentsActions.Location = new System.Drawing.Point(0, 448);
            this.pnlAppointmentsActions.Name = "pnlAppointmentsActions";
            this.pnlAppointmentsActions.Size = new System.Drawing.Size(344, 50);
            this.pnlAppointmentsActions.TabIndex = 0;
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.btnViewDetails.Enabled = false;
            this.btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDetails.ForeColor = System.Drawing.Color.White;
            this.btnViewDetails.Location = new System.Drawing.Point(230, 10);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(102, 30);
            this.btnViewDetails.TabIndex = 0;
            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.UseVisualStyleBackColor = false;
            // 
            // CalendarUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.pnlMonthNavigation);
            this.Controls.Add(this.pnlHeader);
            this.Name = "CalendarUserControl";
            this.Size = new System.Drawing.Size(900, 600);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMonthNavigation.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.pnlCalendarContainer.ResumeLayout(false);
            this.pnlDaysOfWeek.ResumeLayout(false);
            this.pnlAppointments.ResumeLayout(false);
            this.pnlAppointmentsHeader.ResumeLayout(false);
            this.pnlAppointmentsHeader.PerformLayout();
            this.pnlAppointmentsList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.pnlAppointmentsActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMonthNavigation;
        private System.Windows.Forms.Button btnNextMonth;
        private System.Windows.Forms.Label lblMonthYear;
        private System.Windows.Forms.Button btnPreviousMonth;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel pnlCalendarContainer;
        private System.Windows.Forms.Panel pnlDaysOfWeek;
        private System.Windows.Forms.Label lblSaturday;
        private System.Windows.Forms.Label lblFriday;
        private System.Windows.Forms.Label lblThursday;
        private System.Windows.Forms.Label lblWednesday;
        private System.Windows.Forms.Label lblTuesday;
        private System.Windows.Forms.Label lblMonday;
        private System.Windows.Forms.Label lblSunday;
        private System.Windows.Forms.Panel pnlCalendar;
        private System.Windows.Forms.Panel pnlAppointments;
        private System.Windows.Forms.Panel pnlAppointmentsHeader;
        private System.Windows.Forms.Button btnAddAppointment;
        private System.Windows.Forms.Label lblSelectedDate;
        private System.Windows.Forms.Panel pnlAppointmentsList;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.Label lblNoAppointments;
        private System.Windows.Forms.Panel pnlAppointmentsActions;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
    }
}
