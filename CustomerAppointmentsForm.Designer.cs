namespace SchedulingApplication
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
            // Panels
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 60;

            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblCustomerName.ForeColor = System.Drawing.Color.White;
            this.lblCustomerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCustomerName.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);

            // 
            // pnlFilter
            // 
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Height = 60;
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // 
            // lblFilter
            // 
            this.lblFilter.Text = "Filter:";
            this.lblFilter.Location = new System.Drawing.Point(10, 20);
            this.lblFilter.Width = 50;

            // 
            // cbFilter
            // 
            this.cbFilter.Location = new System.Drawing.Point(70, 17);
            this.cbFilter.Width = 200;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.Text = "Add Appointment";
            this.btnAddAppointment.Location = new System.Drawing.Point(700, 17);
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
                new System.Windows.Forms.DataGridViewTextBoxColumn {
                    Name = "Id",
                    HeaderText = "ID",
                    Visible = false
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn {
                    Name = "Title",
                    HeaderText = "Title",
                    Width = 180
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn {
                    Name = "Consultant",
                    HeaderText = "Consultant",
                    Width = 120
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn {
                    Name = "Type",
                    HeaderText = "Type",
                    Width = 120
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn {
                    Name = "Start",
                    HeaderText = "Start",
                    Width = 170
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn {
                    Name = "End",
                    HeaderText = "End",
                    Width = 170
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn {
                    Name = "Location",
                    HeaderText = "Location",
                    Width = 150
                }
            });

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
            this.btnViewDetails.Location = new System.Drawing.Point(300, 15);
            this.btnViewDetails.Width = 120;

            // 
            // btnEdit
            // 
            this.btnEdit.Text = "Edit";
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(430, 15);
            this.btnEdit.Width = 120;

            // 
            // btnDelete
            // 
            this.btnDelete.Text = "Delete";
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(560, 15);
            this.btnDelete.Width = 120;

            // 
            // btnClose
            // 
            this.btnClose.Text = "Close";
            this.btnClose.Location = new System.Drawing.Point(690, 15);
            this.btnClose.Width = 120;

            // Add controls to panels
            this.pnlHeader.Controls.Add(this.lblCustomerName);
            this.pnlFilter.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblFilter,
                this.cbFilter,
                this.btnAddAppointment
            });
            this.pnlGrid.Controls.Add(this.dgvAppointments);
            this.pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnViewDetails,
                this.btnEdit,
                this.btnDelete,
                this.btnClose
            });

            // 
            // CustomerAppointmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.pnlGrid,
                this.pnlButtons,
                this.pnlFilter,
                this.pnlHeader
            });
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerAppointmentsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customer Appointments";

            this.ResumeLayout(false);
        }

        #endregion

        // Header Panel
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblCustomerName;

        // Filter Panel
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Button btnAddAppointment;

        // Grid Panel
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvAppointments;

        // Buttons Panel
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
    }
}