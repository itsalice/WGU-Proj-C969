using AliceLyC969.Database;
using AliceLyC969.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliceLyC969
{
    public partial class ReportsScreen : Form
    {
        public ReportsScreen()
        {
            InitializeComponent();

            // get user data
            var userData = new User();

            foreach (int userId in userData.GetUserIDs())
            {
                // add user IDs to userBox
                userBox.Items.Add(userId);
            }

            // load user appointment data
            loadUserApptData();

            // load month appointment data
            loadMonthAppointments();

            // load total customers by city data
            loadTotalCustomers();
        }

        private void changeColumnName(DataGridView dgvName, string oldColName, string newColName)
        {
            dgvName.Columns[oldColName].HeaderText = newColName;
        }

        private void loadUserApptData()
        {
            // load data in user reports
            var userReportData = new Appointment();

            dgvUserReport.DataSource = userReportData.GetAppointmentData();

            // LAMBDA FUNCTION - to hide specific columns
            // shorter to write lambda function rather than the long dgvUserReport.Columns...
            Action<string> hideCols = columnName =>
            {
                dgvUserReport.Columns[columnName].Visible = false;
            };

            // use the lambda function to hide columns
            hideCols("url");
            hideCols("createDate");
            hideCols("createdBy");
            hideCols("lastUpdate");
            hideCols("lastUpdateBy");

            // custom start and end datetime format
            dgvUserReport.Columns["start"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgvUserReport.Columns["end"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

            // change column names
            changeColumnName(dgvUserReport, "appointmentId", "ID");
            changeColumnName(dgvUserReport, "customerId", "Customer ID");
            changeColumnName(dgvUserReport, "userId", "User ID");
            changeColumnName(dgvUserReport, "title", "Title");
            changeColumnName(dgvUserReport, "description", "Description");
            changeColumnName(dgvUserReport, "location", "Location");
            changeColumnName(dgvUserReport, "contact", "Contact");
            changeColumnName(dgvUserReport, "type", "Type");
            changeColumnName(dgvUserReport, "start", "Start");
            changeColumnName(dgvUserReport, "end", "End");

            // select whole row
            dgvUserReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // make cell read-only
            dgvUserReport.ReadOnly = true;

            // disallow multi selection
            dgvUserReport.MultiSelect = false;

            // disallow users to add rows
            dgvUserReport.AllowUserToAddRows = false;

            // hide first column
            dgvUserReport.RowHeadersVisible = false;
        }

        private void userBoxSelected(object sender, EventArgs e)
        {
            // load data in user reports
            var userReportData = new Appointment();

            dgvUserReport.DataSource = userReportData.GetAppointmentData();

            // deselect row
            dgvUserReport.CurrentCell = null;

            foreach (DataGridViewRow row in dgvUserReport.Rows)
            {
                if (row.Cells["userId"].Value != null)
                {
                    string currUserId = Convert.ToString(row.Cells["userId"].Value);

                    row.Visible = (userBox.Text == currUserId);
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void loadMonthAppointments()
        {
            DataTable dataTable = new DataTable();

            BindingSource source = new BindingSource();

            DBConnection constr = new DBConnection();

            using (var conn = constr.GetConnection())
            {
                conn.Open();

                string query = "SELECT MONTHNAME(start) AS month, type, COUNT(type) AS numOfTypes FROM appointment GROUP BY type, month ORDER BY numOfTypes desc;";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }

                // close the connection
                conn.Close();
            }

            dgvApptReport.DataSource = dataTable;

            // change column name
            changeColumnName(dgvApptReport, "month", "Appointment Month");
            changeColumnName(dgvApptReport, "type", "Appointment Type");
            changeColumnName(dgvApptReport, "numOfTypes", "Total Appointments");

            // select whole row
            dgvApptReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // make cell read-only
            dgvApptReport.ReadOnly = true;

            // disallow multi selection
            dgvApptReport.MultiSelect = false;

            // disallow users to add rows
            dgvApptReport.AllowUserToAddRows = false;

            // hide first column
            dgvApptReport.RowHeadersVisible = false;
        }

        private void loadTotalCustomers()
        {
            DataTable dataTable = new DataTable();

            BindingSource source = new BindingSource();

            DBConnection constr = new DBConnection();

            using (var conn = constr.GetConnection())
            {
                conn.Open();

                string query = "SELECT ci.city AS city, COUNT(c.customerId) AS numOfCustomers FROM customer c JOIN address a ON c.addressId = a.addressId JOIN city ci ON a.cityId = ci.cityId GROUP BY city ORDER BY numOfCustomers desc;";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }

                // close the connection
                conn.Close();
            }

            dgvCityReport.DataSource = dataTable;

            // change column name
            changeColumnName(dgvCityReport, "city", "City");
            changeColumnName(dgvCityReport, "numOfCustomers", "Total Customers");

            // select whole row
            dgvCityReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // make cell read-only
            dgvCityReport.ReadOnly = true;

            // disallow multi selection
            dgvCityReport.MultiSelect = false;

            // disallow users to add rows
            dgvCityReport.AllowUserToAddRows = false;

            // hide first column
            dgvCityReport.RowHeadersVisible = false;
        }

        private void backButtonClicked(object sender, EventArgs e)
        {
            MainScreen mainScreen = new MainScreen();
            mainScreen.Show();
            Close();
        }
    }
}
