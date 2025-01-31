using AliceLyC969.Database;
using AliceLyC969.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliceLyC969
{
    public partial class UpdateAppointment : Form
    {
        ErrorProvider errorProvider = new ErrorProvider();

        private Appointment _appointment;

        int currentUserId = 0;

        public UpdateAppointment(Appointment appointment)
        {
            InitializeComponent();

            // default time picker
            startTimePicker.Format = DateTimePickerFormat.Time;
            startTimePicker.ShowUpDown = true;
            endTimePicker.Format = DateTimePickerFormat.Time;
            endTimePicker.ShowUpDown = true;

            // change format of date pickers
            startDatePicker.Format = DateTimePickerFormat.Custom;
            endDatePicker.Format = DateTimePickerFormat.Custom;
            startDatePicker.CustomFormat = "MM/dd/yyyy";
            endDatePicker.CustomFormat = "MM/dd/yyyy";

            _appointment = appointment;

            // display data
            int appointmentId = _appointment.appointmentId;
            string title = _appointment.title;
            string description = _appointment.description;
            string location = _appointment.location;
            string contact = _appointment.contact;
            string type = _appointment.type;
            string url = _appointment.url;
            DateTime startDate = DateTime.Parse(_appointment.start).ToLocalTime();
            DateTime endDate = DateTime.Parse(_appointment.end).ToLocalTime();
            TimeSpan startTime = startDate.TimeOfDay;
            TimeSpan endTime = endDate.TimeOfDay;
            int customerId = _appointment.customerId;
            int userId = _appointment.userId;

            // dates and current user
            var currentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var currentUser = Properties.Settings.Default.userName;

            // add customer names to customer name box
            Customer customer = new Customer();

            foreach (string customerName in customer.GetCustomerName())
            {
                customerNameBox.Items.Add(customerName);
            }

            customerNameBox.SelectedIndex = 0;

            // add user IDs to user ID box
            User user = new User();

            foreach (int userIdItem in user.GetUserIDs())
            {
                userIdBox.Items.Add(userIdItem);
            }

            userIdBox.SelectedIndex = 0;

            // fill out fields with data
            apptTitleField.Text = title;
            apptDescField.Text = description;
            apptLocationField.Text = location;
            apptContactField.Text = contact;
            apptTypeField.Text = type;
            apptUrlField.Text = url;
            startDatePicker.Value = startDate;
            endDatePicker.Value = endDate;
            startTimePicker.Value = DateTime.Parse(startTime.ToString());
            endTimePicker.Value = DateTime.Parse(endTime.ToString());
            userIdBox.SelectedItem = userId;

            validateFields();
        }

        private void startDatePickerValueChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = validateFields();
        }

        private void endDatePickerValueChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = validateFields();
        }

        private void startTimeValueChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = validateFields();
        }

        private void endTimeValueChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = validateFields();
        }

        private bool validateFields()
        {
            bool isValid = true;
            int today = DateTime.Now.Day;

            // start date
            if (startDatePicker.Value > endDatePicker.Value)
            {
                startDatePicker.BackColor = System.Drawing.Color.Salmon;
                errorProvider.SetError(startDatePicker, "Start date must be before the end date.");
                isValid = false;
            }
            else if (startDatePicker.Value.Day < today)
            {
                startDatePicker.BackColor = System.Drawing.Color.Salmon;
                errorProvider.SetError(startDatePicker, "Start date must be today or later.");
                isValid = false;
            }
            else if (startDatePicker.Value.DayOfWeek.ToString() == "Saturday" || startDatePicker.Value.DayOfWeek.ToString() == "Sunday")
            {
                startDatePicker.BackColor = System.Drawing.Color.Salmon;
                errorProvider.SetError(startDatePicker, "Start date must be within Monday - Friday.");
                isValid = false;
            }
            else
            {
                startDatePicker.BackColor = System.Drawing.Color.White;
                errorProvider.SetError(startDatePicker, "");
            }

            // end date
            if (endDatePicker.Value < startDatePicker.Value)
            {
                endDatePicker.BackColor = System.Drawing.Color.Salmon;
                errorProvider.SetError(endDatePicker, "End date must be after the start date.");
                isValid = false;
            }
            else if (endDatePicker.Value.DayOfWeek.ToString() == "Saturday" || endDatePicker.Value.DayOfWeek.ToString() == "Sunday")
            {
                endDatePicker.BackColor = System.Drawing.Color.Salmon;
                errorProvider.SetError(endDatePicker, "End date must be within Monday - Friday.");
                isValid = false;
            }
            else
            {
                endDatePicker.BackColor = System.Drawing.Color.White;
                errorProvider.SetError(endDatePicker, "");
            }

            // start time
            if (startTimePicker.Value.Hour > endTimePicker.Value.Hour)
            {
                startTimePicker.BackColor = System.Drawing.Color.Salmon;
                errorProvider.SetError(startTimePicker, "Start time must be before the end time.");
                isValid = false;
            }
            else if (startTimePicker.Value.Hour < 9 || startTimePicker.Value.Hour > 17)
            {
                startTimePicker.BackColor = System.Drawing.Color.Salmon;
                errorProvider.SetError(startTimePicker, "Start time must be within business hours. Business hours are 9:00 AM - 5:00 PM EST");
                isValid = false;
            }
            else
            {
                startTimePicker.BackColor = System.Drawing.Color.White;
                errorProvider.SetError(startTimePicker, "");
            }

            // end time
            if (endTimePicker.Value.Hour < startTimePicker.Value.Hour)
            {
                endTimePicker.BackColor = System.Drawing.Color.Salmon;
                errorProvider.SetError(endTimePicker, "End time must be after the start time.");
                isValid = false;
            }
            else if (endTimePicker.Value.Hour < 9 || endTimePicker.Value.Hour > 17)
            {
                endTimePicker.BackColor = System.Drawing.Color.Salmon;
                errorProvider.SetError(endTimePicker, "End time must be within business hours. Business hours are 9:00 AM - 5:00 PM EST");
                isValid = false;
            }
            else
            {
                endTimePicker.BackColor = System.Drawing.Color.White;
                errorProvider.SetError(endTimePicker, "");
            }

            return isValid;
        }

        private void userIdBoxValueChanged(object sender, EventArgs e)
        {
            currentUserId = Convert.ToInt32(userIdBox.Text);
        }

        private void saveButtonClicked(object sender, EventArgs e)
        {
            DBConnection constr = new DBConnection();

            // is overlap?
            bool isOverlap = false;

            // appointment fields
            int userId = _appointment.userId;
            int appointmentId = _appointment.appointmentId;
            string titleField = apptTitleField.Text;
            string descriptionField = apptDescField.Text;
            string locationField = apptLocationField.Text;
            string contactField = apptContactField.Text;
            string typeField = apptTypeField.Text;
            string urlField = apptUrlField.Text;
            startDatePicker.CustomFormat = "yyyy-MM-dd";
            endDatePicker.CustomFormat = "yyyy-MM-dd";
            DateTime apptStartDate = startDatePicker.Value.ToUniversalTime().Date + startTimePicker.Value.ToUniversalTime().TimeOfDay;
            DateTime apptEndDate = endDatePicker.Value.ToUniversalTime().Date + endTimePicker.Value.ToUniversalTime().TimeOfDay;

            // dates and current user
            var currentDateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            var currentUser = Properties.Settings.Default.userName;

            try
            {
                using (var conn = constr.GetConnection())
                {
                    conn.Open();

                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // find customer query
                            string findCustomerQuery = @"SELECT customerId FROM customer
                                WHERE customerName = @customerName";

                            MySqlCommand findCustomerCmd = new MySqlCommand(@findCustomerQuery, conn);

                            findCustomerCmd.Parameters.AddWithValue("@customerName", customerNameBox.Text);

                            int customerId = Convert.ToInt32(findCustomerCmd.ExecuteScalar());

                            // does schedule overlap query
                            string isOverlapQuery = @"SELECT * FROM appointment
                                        WHERE EXISTS
                                        (SELECT * FROM appointment WHERE start <= @end AND end >= @start AND appointmentId <> @appointmentId AND userId = @userId);";
                            MySqlCommand isOverlapCmd = new MySqlCommand(isOverlapQuery, conn);

                            isOverlapCmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                            isOverlapCmd.Parameters.AddWithValue("@userId", currentUserId);
                            isOverlapCmd.Parameters.AddWithValue("@start", apptStartDate);
                            isOverlapCmd.Parameters.AddWithValue("@end", apptEndDate);

                            int countOverlap = Convert.ToInt32(isOverlapCmd.ExecuteScalar());

                            if (countOverlap > 0)
                            {
                                // error message if appointment overlaps
                                MessageBox.Show("Cannot schedule overlapping appointments.");
                            }
                            else
                            {
                                // update appointment
                                string updateApptQuery = @"
                                    UPDATE appointment
                                    SET customerId = @customerId, userId = @userId, title = @title, description = @description, location = @location, contact = @contact, type = @type, url = @url, start = @start, end = @end, lastUpdate = @lastUpdate, lastUpdateBy = @lastUpdateBy
                                    WHERE appointmentId = @appointmentId;";

                                using (var updateApptCmd = new MySqlCommand(updateApptQuery, conn, transaction))
                                {
                                    updateApptCmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                                    updateApptCmd.Parameters.AddWithValue("@customerId", customerId);
                                    updateApptCmd.Parameters.AddWithValue("@userId", userIdBox.Text);
                                    updateApptCmd.Parameters.AddWithValue("@title", titleField);
                                    updateApptCmd.Parameters.AddWithValue("@description", descriptionField);
                                    updateApptCmd.Parameters.AddWithValue("@location", locationField);
                                    updateApptCmd.Parameters.AddWithValue("@contact", contactField);
                                    updateApptCmd.Parameters.AddWithValue("@type", typeField);
                                    updateApptCmd.Parameters.AddWithValue("@url", urlField);
                                    updateApptCmd.Parameters.AddWithValue("@start", apptStartDate);
                                    updateApptCmd.Parameters.AddWithValue("@end", apptEndDate);
                                    updateApptCmd.Parameters.AddWithValue("@lastUpdate", currentDateTime);
                                    updateApptCmd.Parameters.AddWithValue("@lastUpdateBy", currentUser);

                                    updateApptCmd.ExecuteNonQuery();
                                }

                                transaction.Commit();

                                MainScreen mainScreen = new MainScreen();
                                mainScreen.Show();
                                Close();
                            }
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }

                    // close the connection
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private void cancelButtonClicked(object sender, EventArgs e)
        {
            MainScreen mainScreen = new MainScreen();
            mainScreen.Show();
            Close();
        }
    }
}
