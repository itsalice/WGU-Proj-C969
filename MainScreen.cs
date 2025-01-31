using AliceLyC969.Database;
using AliceLyC969.Model;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.BC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliceLyC969
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();

            // welcome message
            var userName = Properties.Settings.Default.userName;
            welcomeMessage.Text = $"Welcome, {userName}";

            // load appointment data in table
            loadAppointments();

            // load customer data in table
            loadCustomers();

            // disable update and delete buttons
            updateCustomer.Enabled = false;
            deleteCustomer.Enabled = false;

            // enable update and delete buttons
            if (dgvCustomers.Rows.Count > 0)
            {
                updateCustomer.Enabled = true;
                deleteCustomer.Enabled = true;
            }
        }

        private void changeColumnName(DataGridView dgvName, string oldColName, string newColName)
        {
            dgvName.Columns[oldColName].HeaderText = newColName;
        }

        private void hideColumn(DataGridView dgvName, string colName)
        {
            dgvName.Columns[colName].Visible = false;
        }

        private void loadAppointments()
        {
            // appointment data
            var appointmentData = new Appointment();

            dgvAppointments.DataSource = appointmentData.GetAppointmentData();

            // custom start and end datetime format
            dgvAppointments.Columns["start"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgvAppointments.Columns["end"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

            // hide certain columns
            hideColumn(dgvAppointments, "customerId");
            hideColumn(dgvAppointments, "userId");
            hideColumn(dgvAppointments, "url");
            hideColumn(dgvAppointments, "createDate");
            hideColumn(dgvAppointments, "createdBy");
            hideColumn(dgvAppointments, "lastUpdate");
            hideColumn(dgvAppointments, "lastUpdateBy");

            // change column names
            changeColumnName(dgvAppointments, "appointmentId", "ID");
            changeColumnName(dgvAppointments, "title", "Title");
            changeColumnName(dgvAppointments, "description", "Description");
            changeColumnName(dgvAppointments, "location", "Location");
            changeColumnName(dgvAppointments, "contact", "Contact");
            changeColumnName(dgvAppointments, "type", "Type");
            changeColumnName(dgvAppointments, "start", "Start");
            changeColumnName(dgvAppointments, "end", "End");

            // select whole row
            dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // make cell read-only
            dgvAppointments.ReadOnly = true;

            // disallow multi selection
            dgvAppointments.MultiSelect = false;

            // disallow users to add rows
            dgvAppointments.AllowUserToAddRows = false;

            // hide first column
            dgvAppointments.RowHeadersVisible = false;
        }

        private void dgvAppointmentsCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DateTime)
            {
                var date = (DateTime)e.Value;
                var localDate = date.ToLocalTime();
                e.Value = localDate.ToString();
                e.FormattingApplied = true;
            }
        }

        private void loadCustomers()
        {
            // customer data
            var customerData = new Customer();

            dgvCustomers.DataSource = customerData.GetCustomerData();

            // hide certain columns
            hideColumn(dgvCustomers, "addressId");
            hideColumn(dgvCustomers, "active");
            hideColumn(dgvCustomers, "createDate");
            hideColumn(dgvCustomers, "createdBy");
            hideColumn(dgvCustomers, "lastUpdate");
            hideColumn(dgvCustomers, "lastUpdateBy");

            // change column names
            changeColumnName(dgvCustomers, "customerId", "ID");
            changeColumnName(dgvCustomers, "customerName", "Name");
            changeColumnName(dgvCustomers, "address", "Address");
            changeColumnName(dgvCustomers, "address2", "Address 2");
            changeColumnName(dgvCustomers, "postalCode", "Postal Code");
            changeColumnName(dgvCustomers, "phone", "Phone");
            changeColumnName(dgvCustomers, "city", "City");
            changeColumnName(dgvCustomers, "country", "Country");

            // select whole row
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // make cell read-only
            dgvCustomers.ReadOnly = true;

            // disallow multi selection
            dgvCustomers.MultiSelect = false;

            // disallow users to add rows
            dgvCustomers.AllowUserToAddRows = false;

            // hide first column
            dgvCustomers.RowHeadersVisible = false;
        }

        private void allAppointmentsChecked(object sender, EventArgs e)
        {
            // appointment data
            var appointmentData = new Appointment();

            dgvAppointments.DataSource = appointmentData.GetAppointmentData();
        }

        private void currWeekApptChecked(object sender, EventArgs e)
        {
            // appointment data
            var appointmentData = new Appointment();

            dgvAppointments.DataSource = appointmentData.GetAppointmentData();

            // deselect row
            dgvAppointments.CurrentCell = null;

            DateTime today = DateTime.Now;
            DayOfWeek currentDay = today.DayOfWeek;

            // start of week
            DateTime startOfWeek = today.AddDays(-(int)currentDay + (int)DayOfWeek.Sunday);

            // end of week
            DateTime endOfWeek = startOfWeek.AddDays(6);

            DataTable dataTable = (DataTable)dgvAppointments.DataSource;

            dataTable.DefaultView.RowFilter = string.Format("start >= #{0}# and end < #{1}#",
                startOfWeek.ToString("yyyy-MM-dd"),
                endOfWeek.ToString("yyyy-MM-dd"));
        }

        private void currMonthApptChecked(object sender, EventArgs e)
        {
            // appointment data
            var appointmentData = new Appointment();

            dgvAppointments.DataSource = appointmentData.GetAppointmentData();

            DateTime today = DateTime.Now;
            int currentMonth = DateTime.Now.Month;

            // deselect row
            dgvAppointments.CurrentCell = null;

            foreach (DataGridViewRow row in dgvAppointments.Rows)
            {
                if (row.Cells["start"].Value != null)
                {
                    DateTime startDate = Convert.ToDateTime(row.Cells["start"].Value);
                    int startMonth = startDate.Month;

                    row.Visible = (startMonth == currentMonth);
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void apptDateTimePickerChanged(object sender, EventArgs e)
        {
            allApptRadio.Checked = false;
            currWeekApptRadio.Checked = false;
            currMonthApptRadio.Checked = false;

            // appointment data
            var appointmentData = new Appointment();

            dgvAppointments.DataSource = appointmentData.GetAppointmentData();

            DateTime today = DateTime.Now;

            // deselect row
            dgvAppointments.CurrentCell = null;

            foreach (DataGridViewRow row in dgvAppointments.Rows)
            {
                if (row.Cells["start"].Value != null)
                {
                    string startDate = Convert.ToDateTime(row.Cells["start"].Value).ToShortDateString();
                    string selectedDate = apptDateTimePicker.Value.ToShortDateString();

                    row.Visible = (startDate == selectedDate);
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void addNewCustomerClicked(object sender, EventArgs e)
        {
            AddCustomer addCustomerScreen = new AddCustomer();
            addCustomerScreen.Show();
            Hide();
        }

        private void updateCustomerClicked(object sender, EventArgs e)
        {
            var currRow = dgvCustomers.CurrentRow;

            Customer customer = new Customer
            {
                customerId = Convert.ToInt32(currRow.Cells["customerId"].Value),
                customerName = Convert.ToString(currRow.Cells["customerName"].Value),
                addressId = Convert.ToInt32(currRow.Cells["addressId"].Value),
                active = Convert.ToBoolean(currRow.Cells["active"].Value),
                createDate = Convert.ToString(currRow.Cells["createDate"].Value),
                createdBy = Convert.ToString(currRow.Cells["createdBy"].Value),
                lastUpdate = Convert.ToString(currRow.Cells["lastUpdate"].Value),
                lastUpdateBy = Convert.ToString(currRow.Cells["lastUpdateBy"].Value)
            };
            
            UpdateCustomer updateCustomerScreen = new UpdateCustomer(customer);
            updateCustomerScreen.Show();
            Hide();
        }

        private void deleteCustomerClicked(object sender, EventArgs e)
        {
            var currRow = dgvCustomers.CurrentRow;
            int currCustId = Convert.ToInt32(currRow.Cells["customerId"].Value);

            Customer customer = new Customer();

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this customer?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                customer.RemoveCustomer(currCustId);

                // refresh customer data
                var customerData = new Customer();
                var appointmentData = new Appointment();

                dgvCustomers.DataSource = customerData.GetCustomerData();
                dgvAppointments.DataSource = appointmentData.GetAppointmentData();
            }

            updateCustomer.Enabled = false;
            deleteCustomer.Enabled = false;

            if (dgvCustomers.Rows.Count > 0)
            {
                updateCustomer.Enabled = true;
                deleteCustomer.Enabled = true;
            }
        }

        private void logOffButtonClicked(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            Close();
        }

        private void addAppointmentClicked(object sender, EventArgs e)
        {
            AddAppointment addApptForm = new AddAppointment();
            addApptForm.Show();
            Hide();
        }

        private void updateAppointmentClicked(object sender, EventArgs e)
        {
            var currRow = dgvAppointments.CurrentRow;

            Appointment appointment = new Appointment 
            {
                appointmentId = Convert.ToInt32(currRow.Cells["appointmentId"].Value),
                customerId = Convert.ToInt32(currRow.Cells["customerId"].Value),
                userId = Convert.ToInt32(currRow.Cells["userId"].Value),
                title = Convert.ToString(currRow.Cells["title"].Value),
                description = Convert.ToString(currRow.Cells["description"].Value),
                location = Convert.ToString(currRow.Cells["location"].Value),
                contact = Convert.ToString(currRow.Cells["contact"].Value),
                type = Convert.ToString(currRow.Cells["type"].Value),
                url = Convert.ToString(currRow.Cells["url"].Value),
                start = Convert.ToString(currRow.Cells["start"].Value),
                end = Convert.ToString(currRow.Cells["end"].Value),
                createDate = Convert.ToString(currRow.Cells["createDate"].Value),
                createdBy = Convert.ToString(currRow.Cells["createdBy"].Value),
                lastUpdate = Convert.ToString(currRow.Cells["lastUpdate"].Value),
                lastUpdateBy = Convert.ToString(currRow.Cells["lastUpdateBy"].Value)
            };

            if (dgvAppointments.SelectedRows.Count > 0)
            {
                UpdateAppointment updateApptForm = new UpdateAppointment(appointment);
                updateApptForm.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("You must select an appointment.");
            }
        }

        private void deleteAppointmentClicked(object sender, EventArgs e)
        {
            var currRow = dgvAppointments.CurrentRow;

            int currApptId = Convert.ToInt32(currRow.Cells["appointmentId"].Value);

            Appointment appointment = new Appointment();

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this appointment?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                appointment.RemoveAppointment(currApptId);

                // refresh DGV
                var appointmentData = new Appointment();

                dgvAppointments.DataSource = appointmentData.GetAppointmentData();
            }

            updateAppointment.Enabled = false;
            deleteAppointment.Enabled = false;

            if (dgvAppointments.Rows.Count > 0)
            {
                updateAppointment.Enabled = true;
                deleteAppointment.Enabled = true;
            }
        }

        private void generateReportsClicked(object sender, EventArgs e)
        {
            ReportsScreen reportsScreen = new ReportsScreen();
            reportsScreen.Show();
            Hide();
        }
    }
}
