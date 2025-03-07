﻿namespace SchedulingApplication
{
    partial class CustomerAppointmentsForm
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
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConsultant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.pnlHeader.Controls.Add(this.lblCustomerName);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblCustomerName.ForeColor = System.Drawing.Color.White;
            this.lblCustomerName.Location = new System.Drawing.Point(0, 0);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblCustomerName.Size = new System.Drawing.Size(900, 60);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilter.Controls.Add(this.lblFilter);
            this.pnlFilter.Controls.Add(this.cbFilter);
            this.pnlFilter.Controls.Add(this.btnAddAppointment);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 60);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(900, 80);
            this.pnlFilter.TabIndex = 1;
            // 
            // lblFilter
            // 
            this.lblFilter.Location = new System.Drawing.Point(10, 20);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(50, 23);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter:";
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.Location = new System.Drawing.Point(70, 17);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(200, 21);
            this.cbFilter.TabIndex = 1;
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAppointment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.btnAddAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAppointment.ForeColor = System.Drawing.Color.White;
            this.btnAddAppointment.Location = new System.Drawing.Point(700, 17);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Size = new System.Drawing.Size(120, 30);
            this.btnAddAppointment.TabIndex = 2;
            this.btnAddAppointment.Text = "Add Appointment";
            this.btnAddAppointment.UseVisualStyleBackColor = false;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvAppointments);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 140);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(10);
            this.pnlGrid.Size = new System.Drawing.Size(900, 400);
            this.pnlGrid.TabIndex = 2;
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToDeleteRows = false;
            this.dgvAppointments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colTitle,
            this.colConsultant,
            this.colType,
            this.colStart,
            this.colEnd,
            this.colLocation});
            this.dgvAppointments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAppointments.Location = new System.Drawing.Point(10, 10);
            this.dgvAppointments.MultiSelect = false;
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.Size = new System.Drawing.Size(880, 380);
            this.dgvAppointments.TabIndex = 0;
            // 
            // Id
            // 
            this.colId.HeaderText = "ID";
            this.colId.Name = "Id";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // Title
            // 
            this.colTitle.HeaderText = "Title";
            this.colTitle.Name = "Title";
            this.colTitle.ReadOnly = true;
            this.colTitle.Width = 180;
            // 
            // Consultant
            // 
            this.colConsultant.HeaderText = "Consultant";
            this.colConsultant.Name = "Consultant";
            this.colConsultant.ReadOnly = true;
            this.colConsultant.Width = 120;
            // 
            // Type
            // 
            this.colType.HeaderText = "Type";
            this.colType.Name = "Type";
            this.colType.ReadOnly = true;
            this.colType.Width = 120;
            // 
            // Start
            // 
            this.colStart.HeaderText = "Start";
            this.colStart.Name = "Start";
            this.colStart.ReadOnly = true;
            this.colStart.Width = 170;
            // 
            // End
            // 
            this.colEnd.HeaderText = "End";
            this.colEnd.Name = "End";
            this.colEnd.ReadOnly = true;
            this.colEnd.Width = 170;
            // 
            // Location
            // 
            this.colLocation.HeaderText = "Location";
            this.colLocation.Name = "Location";
            this.colLocation.ReadOnly = true;
            this.colLocation.Width = 150;
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.SystemColors.Control;
            this.pnlButtons.Controls.Add(this.btnViewDetails);
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 540);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(900, 60);
            this.pnlButtons.TabIndex = 3;
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.btnClose.Enabled = true;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(748, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // CustomerAppointmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerAppointmentsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customer Appointments";
            this.pnlHeader.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Button btnAddAppointment;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvAppointments;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colConsultant;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colStart;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colEnd;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colLocation;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConsultant;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocation;
    }
}