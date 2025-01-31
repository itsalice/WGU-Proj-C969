namespace AliceLyC969
{
    partial class MainScreen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.deleteCustomer = new System.Windows.Forms.Button();
            this.updateCustomer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.addNewCustomers = new System.Windows.Forms.Button();
            this.welcomeMessage = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.deleteAppointment = new System.Windows.Forms.Button();
            this.updateAppointment = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.addAppointment = new System.Windows.Forms.Button();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.currMonthApptRadio = new System.Windows.Forms.RadioButton();
            this.currWeekApptRadio = new System.Windows.Forms.RadioButton();
            this.allApptRadio = new System.Windows.Forms.RadioButton();
            this.generateReports = new System.Windows.Forms.Button();
            this.apptDateTimePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Location = new System.Drawing.Point(55, 65);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.Size = new System.Drawing.Size(822, 178);
            this.dgvCustomers.TabIndex = 0;
            // 
            // deleteCustomer
            // 
            this.deleteCustomer.Location = new System.Drawing.Point(257, 278);
            this.deleteCustomer.Name = "deleteCustomer";
            this.deleteCustomer.Size = new System.Drawing.Size(75, 30);
            this.deleteCustomer.TabIndex = 4;
            this.deleteCustomer.Text = "Delete";
            this.deleteCustomer.UseVisualStyleBackColor = true;
            this.deleteCustomer.Click += new System.EventHandler(this.deleteCustomerClicked);
            // 
            // updateCustomer
            // 
            this.updateCustomer.Location = new System.Drawing.Point(156, 278);
            this.updateCustomer.Name = "updateCustomer";
            this.updateCustomer.Size = new System.Drawing.Size(75, 30);
            this.updateCustomer.TabIndex = 3;
            this.updateCustomer.Text = "Update";
            this.updateCustomer.UseVisualStyleBackColor = true;
            this.updateCustomer.Click += new System.EventHandler(this.updateCustomerClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Customers";
            // 
            // addNewCustomers
            // 
            this.addNewCustomers.Location = new System.Drawing.Point(54, 278);
            this.addNewCustomers.Name = "addNewCustomers";
            this.addNewCustomers.Size = new System.Drawing.Size(75, 30);
            this.addNewCustomers.TabIndex = 1;
            this.addNewCustomers.Text = "Add";
            this.addNewCustomers.UseVisualStyleBackColor = true;
            this.addNewCustomers.Click += new System.EventHandler(this.addNewCustomerClicked);
            // 
            // welcomeMessage
            // 
            this.welcomeMessage.AutoSize = true;
            this.welcomeMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeMessage.Location = new System.Drawing.Point(36, 34);
            this.welcomeMessage.Name = "welcomeMessage";
            this.welcomeMessage.Size = new System.Drawing.Size(115, 29);
            this.welcomeMessage.TabIndex = 2;
            this.welcomeMessage.Text = "Welcome";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(452, 829);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "Log off";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.logOffButtonClicked);
            // 
            // deleteAppointment
            // 
            this.deleteAppointment.Location = new System.Drawing.Point(258, 273);
            this.deleteAppointment.Name = "deleteAppointment";
            this.deleteAppointment.Size = new System.Drawing.Size(75, 30);
            this.deleteAppointment.TabIndex = 9;
            this.deleteAppointment.Text = "Delete";
            this.deleteAppointment.UseVisualStyleBackColor = true;
            this.deleteAppointment.Click += new System.EventHandler(this.deleteAppointmentClicked);
            // 
            // updateAppointment
            // 
            this.updateAppointment.Location = new System.Drawing.Point(157, 273);
            this.updateAppointment.Name = "updateAppointment";
            this.updateAppointment.Size = new System.Drawing.Size(75, 30);
            this.updateAppointment.TabIndex = 8;
            this.updateAppointment.Text = "Update";
            this.updateAppointment.UseVisualStyleBackColor = true;
            this.updateAppointment.Click += new System.EventHandler(this.updateAppointmentClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Appointments";
            // 
            // addAppointment
            // 
            this.addAppointment.Location = new System.Drawing.Point(55, 273);
            this.addAppointment.Name = "addAppointment";
            this.addAppointment.Size = new System.Drawing.Size(75, 30);
            this.addAppointment.TabIndex = 6;
            this.addAppointment.Text = "Add";
            this.addAppointment.UseVisualStyleBackColor = true;
            this.addAppointment.Click += new System.EventHandler(this.addAppointmentClicked);
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAppointments.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAppointments.Location = new System.Drawing.Point(56, 65);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.Size = new System.Drawing.Size(822, 178);
            this.dgvAppointments.TabIndex = 5;
            this.dgvAppointments.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAppointmentsCellFormatting);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(41, 92);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.apptDateTimePicker);
            this.splitContainer1.Panel1.Controls.Add(this.currMonthApptRadio);
            this.splitContainer1.Panel1.Controls.Add(this.currWeekApptRadio);
            this.splitContainer1.Panel1.Controls.Add(this.allApptRadio);
            this.splitContainer1.Panel1.Controls.Add(this.dgvAppointments);
            this.splitContainer1.Panel1.Controls.Add(this.deleteAppointment);
            this.splitContainer1.Panel1.Controls.Add(this.addAppointment);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.updateAppointment);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvCustomers);
            this.splitContainer1.Panel2.Controls.Add(this.deleteCustomer);
            this.splitContainer1.Panel2.Controls.Add(this.addNewCustomers);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.updateCustomer);
            this.splitContainer1.Size = new System.Drawing.Size(940, 663);
            this.splitContainer1.SplitterDistance = 325;
            this.splitContainer1.TabIndex = 10;
            // 
            // currMonthApptRadio
            // 
            this.currMonthApptRadio.AutoSize = true;
            this.currMonthApptRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currMonthApptRadio.Location = new System.Drawing.Point(639, 22);
            this.currMonthApptRadio.Name = "currMonthApptRadio";
            this.currMonthApptRadio.Size = new System.Drawing.Size(121, 22);
            this.currMonthApptRadio.TabIndex = 12;
            this.currMonthApptRadio.Text = "Current Month";
            this.currMonthApptRadio.UseVisualStyleBackColor = true;
            this.currMonthApptRadio.CheckedChanged += new System.EventHandler(this.currMonthApptChecked);
            // 
            // currWeekApptRadio
            // 
            this.currWeekApptRadio.AutoSize = true;
            this.currWeekApptRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currWeekApptRadio.Location = new System.Drawing.Point(502, 22);
            this.currWeekApptRadio.Name = "currWeekApptRadio";
            this.currWeekApptRadio.Size = new System.Drawing.Size(118, 22);
            this.currWeekApptRadio.TabIndex = 11;
            this.currWeekApptRadio.Text = "Current Week";
            this.currWeekApptRadio.UseVisualStyleBackColor = true;
            this.currWeekApptRadio.CheckedChanged += new System.EventHandler(this.currWeekApptChecked);
            // 
            // allApptRadio
            // 
            this.allApptRadio.AutoSize = true;
            this.allApptRadio.Checked = true;
            this.allApptRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allApptRadio.Location = new System.Drawing.Point(348, 22);
            this.allApptRadio.Name = "allApptRadio";
            this.allApptRadio.Size = new System.Drawing.Size(135, 22);
            this.allApptRadio.TabIndex = 10;
            this.allApptRadio.TabStop = true;
            this.allApptRadio.Text = "All Appointments";
            this.allApptRadio.UseVisualStyleBackColor = true;
            this.allApptRadio.CheckedChanged += new System.EventHandler(this.allAppointmentsChecked);
            // 
            // generateReports
            // 
            this.generateReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateReports.Location = new System.Drawing.Point(825, 36);
            this.generateReports.Name = "generateReports";
            this.generateReports.Size = new System.Drawing.Size(156, 30);
            this.generateReports.TabIndex = 11;
            this.generateReports.Text = "Generate Reports";
            this.generateReports.UseVisualStyleBackColor = true;
            this.generateReports.Click += new System.EventHandler(this.generateReportsClicked);
            // 
            // apptDateTimePicker
            // 
            this.apptDateTimePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apptDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apptDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.apptDateTimePicker.Location = new System.Drawing.Point(780, 20);
            this.apptDateTimePicker.Name = "apptDateTimePicker";
            this.apptDateTimePicker.Size = new System.Drawing.Size(97, 24);
            this.apptDateTimePicker.TabIndex = 13;
            this.apptDateTimePicker.ValueChanged += new System.EventHandler(this.apptDateTimePickerChanged);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 895);
            this.Controls.Add(this.generateReports);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.welcomeMessage);
            this.Name = "MainScreen";
            this.Text = "Customer Records";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Label welcomeMessage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button addNewCustomers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button deleteCustomer;
        private System.Windows.Forms.Button updateCustomer;
        private System.Windows.Forms.Button deleteAppointment;
        private System.Windows.Forms.Button updateAppointment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addAppointment;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RadioButton currMonthApptRadio;
        private System.Windows.Forms.RadioButton currWeekApptRadio;
        private System.Windows.Forms.RadioButton allApptRadio;
        private System.Windows.Forms.Button generateReports;
        private System.Windows.Forms.DateTimePicker apptDateTimePicker;
    }
}