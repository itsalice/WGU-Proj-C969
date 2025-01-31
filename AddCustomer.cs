using AliceLyC969.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliceLyC969
{
    public partial class AddCustomer : Form
    {
        ErrorProvider errorProvider = new ErrorProvider();

        public AddCustomer()
        {
            InitializeComponent();

            // disable save button
            validateFields();
            saveButton.Enabled = false;
        }

        private void customerNameFieldChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = validateFields();
        }

        private void customerAddressFieldChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = validateFields();
        }

        private void customerCityFieldChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = validateFields();
        }

        private void customerCountryFieldChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = validateFields();
        }

        private void customerPostalCodeFieldChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = validateFields();
        }

        private void customerPhoneFieldChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = validateFields();
        }

        private bool validateFields()
        {
            bool isValid = true;

            // set up regex for phone pattern
            string pattern = @"^\d{3}-\d{4}$";
            Regex regex = new Regex(pattern, RegexOptions.Compiled);

            // name
            if (string.IsNullOrEmpty(customerNameField.Text))
            {
                customerNameField.BackColor = System.Drawing.Color.Salmon;
                errorProvider.SetError(customerNameField, "Please enter a name.");
                isValid = false;
            }
            else
            {
                customerNameField.BackColor = System.Drawing.Color.White;
                errorProvider.SetError(customerNameField, "");
            }

            // address
            if (string.IsNullOrEmpty(customerAddressField.Text))
            {
                customerAddressField.BackColor = System.Drawing.Color.Salmon;
                errorProvider.SetError(customerAddressField, "Please enter an address.");
                isValid = false;
            }
            else
            {
                customerAddressField.BackColor = System.Drawing.Color.White;
                errorProvider.SetError(customerAddressField, "");
            }

            // city
            if (string.IsNullOrEmpty(customerCityField.Text))
            {
                customerCityField.BackColor = System.Drawing.Color.Salmon;
                errorProvider.SetError(customerCityField, "Please enter a city.");
                isValid = false;
            }
            else
            {
                customerCityField.BackColor = System.Drawing.Color.White;
                errorProvider.SetError(customerCityField, "");
            }

            // country
            if (string.IsNullOrEmpty(customerCountryField.Text))
            {
                customerCountryField.BackColor = System.Drawing.Color.Salmon;
                errorProvider.SetError(customerCountryField, "Please enter a country.");
                isValid = false;
            }
            else
            {
                customerCountryField.BackColor = System.Drawing.Color.White;
                errorProvider.SetError(customerCountryField, "");
            }

            // postal code
            if (string.IsNullOrEmpty(customerPostalCodeField.Text))
            {
                customerPostalCodeField.BackColor = System.Drawing.Color.Salmon;
                errorProvider.SetError(customerPostalCodeField, "Please enter a valid postal code.");
                isValid = false;
            }
            else
            {
                customerPostalCodeField.BackColor = System.Drawing.Color.White;
                errorProvider.SetError(customerPostalCodeField, "");
            }

            // phone
            if (string.IsNullOrEmpty(customerPhoneField.Text))
            {
                customerPhoneField.BackColor = System.Drawing.Color.Salmon;
                errorProvider.SetError(customerPhoneField, "Please enter a valid numeric phone number.");
                isValid = false;
            }
            else if (!regex.IsMatch(customerPhoneField.Text))
            {
                customerPhoneField.BackColor = System.Drawing.Color.Salmon;
                errorProvider.SetError(customerPhoneField, "Phone number must be numeric and in the format xxx-xxxx.");
                isValid = false;
            }
            else
            {
                customerPhoneField.BackColor = System.Drawing.Color.White;
                errorProvider.SetError(customerPhoneField, "");
            }

            return isValid;
        }

        private void saveButtonClicked(object sender, EventArgs e)
        {
            DBConnection constr = new DBConnection();

            // customer fields
            string customerName = customerNameField.Text;
            string customerAddress = customerAddressField.Text;
            string customerAddress2 = customerAddress2Field.Text;
            string customerCity = customerCityField.Text;
            string customerCountry = customerCountryField.Text;
            string customerPostalCode = customerPostalCodeField.Text;
            string customerPhone = customerPhoneField.Text;
            bool isActive = false;

            // dates and current user
            var currentDateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            var currentUser = Properties.Settings.Default.userName;

            Console.WriteLine(currentDateTime.ToString());

            try
            {
                using (var conn = constr.GetConnection())
                {
                    conn.Open();

                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // step 0: check for customer

                            // find customer query
                            string findCustomerQuery = @"
                                SELECT customerId FROM customer c
                                JOIN address a ON c.addressId = a.addressId
                                WHERE c.customerName = @customerName AND a.address = @address AND a.postalCode = @postalCode AND a.phone = @phone";

                            MySqlCommand findCustomerCmd = new MySqlCommand(findCustomerQuery, conn, transaction);

                            findCustomerCmd.Parameters.AddWithValue("@customerName", customerName);
                            findCustomerCmd.Parameters.AddWithValue("@address", customerAddress);
                            findCustomerCmd.Parameters.AddWithValue("@postalCode", customerPostalCode);
                            findCustomerCmd.Parameters.AddWithValue("@phone", customerPhone);

                            object customerIdObj = findCustomerCmd.ExecuteScalar();

                            if (customerIdObj != null)
                            {
                                MessageBox.Show($"Customer '{customerName}' already exists in the database.");
                                transaction.Rollback();
                                return;
                            }

                            // step 1: country

                            // find country query
                            string findCountryQuery = @"
                                SELECT countryId FROM country WHERE country = @country;";

                            MySqlCommand findCountryCmd = new MySqlCommand(findCountryQuery, conn, transaction);

                            findCountryCmd.Parameters.AddWithValue("@country", customerCountry);

                            object countryIdObj = findCountryCmd.ExecuteScalar();

                            int countryId;
                            if (countryIdObj != null) {
                                // country exists
                                countryId = Convert.ToInt32(countryIdObj);
                            }
                            else
                            {
                                // insert country query
                                string insertCountryQuery = @"
                                    INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) 
                                    VALUES (@country, @createDate, @createdBy, @lastUpdate, @lastUpdateBy);
                                    SELECT LAST_INSERT_ID();";

                                MySqlCommand insertCountryCmd = new MySqlCommand(insertCountryQuery, conn, transaction);

                                insertCountryCmd.Parameters.AddWithValue("@country", customerCountry);
                                insertCountryCmd.Parameters.AddWithValue("@createDate", currentDateTime.ToString());
                                insertCountryCmd.Parameters.AddWithValue("@createdBy", currentUser);
                                insertCountryCmd.Parameters.AddWithValue("@lastUpdate", currentDateTime.ToString());
                                insertCountryCmd.Parameters.AddWithValue("@lastUpdateBy", currentUser);

                                countryId = Convert.ToInt32(insertCountryCmd.ExecuteScalar());
                            }

                            // step 2: city

                            // find city query
                            string findCityQuery = @"
                                SELECT cityId FROM city WHERE city = @city AND countryId = @countryId";

                            MySqlCommand findCityCmd = new MySqlCommand(findCityQuery, conn, transaction);

                            findCityCmd.Parameters.AddWithValue("@city", customerCity);
                            findCityCmd.Parameters.AddWithValue("@countryId", countryId);

                            object cityIdObj = findCityCmd.ExecuteScalar();

                            int cityId;
                            if (cityIdObj != null) {
                                cityId = Convert.ToInt32(cityIdObj);
                            }
                            else
                            {
                                // insert city query
                                string insertCityQuery = @"
                                    INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) 
                                    VALUES (@city, @countryId, @createDate, @createdBy, @lastUpdate, @lastUpdateBy);
                                    SELECT LAST_INSERT_ID();";

                                MySqlCommand insertCityCmd = new MySqlCommand(insertCityQuery, conn, transaction);

                                insertCityCmd.Parameters.AddWithValue("@city", customerCity);
                                insertCityCmd.Parameters.AddWithValue("@countryId", countryId);
                                insertCityCmd.Parameters.AddWithValue("@createDate", currentDateTime.ToString());
                                insertCityCmd.Parameters.AddWithValue("@createdBy", currentUser);
                                insertCityCmd.Parameters.AddWithValue("@lastUpdate", currentDateTime.ToString());
                                insertCityCmd.Parameters.AddWithValue("@lastUpdateBy", currentUser);

                                cityId = Convert.ToInt32(insertCityCmd.ExecuteScalar());
                            }

                            // step 3: address

                            // find address query
                            string findAddressQuery = @"
                                SELECT addressId FROM address 
                                WHERE address = @address AND address2 = @address2 AND cityId = @cityId AND postalCode = @postalCode AND phone = @phone;";

                            MySqlCommand findAddressCmd = new MySqlCommand(findAddressQuery, conn, transaction);

                            findAddressCmd.Parameters.AddWithValue("@address", customerAddress);
                            findAddressCmd.Parameters.AddWithValue("@address2", customerAddress2);
                            findAddressCmd.Parameters.AddWithValue("@cityId", cityId);
                            findAddressCmd.Parameters.AddWithValue("@postalCode", customerPostalCode);
                            findAddressCmd.Parameters.AddWithValue("@phone", customerPhone);

                            object addressIdObj = findAddressCmd.ExecuteScalar();

                            int addressId;
                            if (addressIdObj != null)
                            {
                                addressId = Convert.ToInt32(addressIdObj);
                            }
                            else
                            {
                                // insert address query
                                string insertAddressQuery = @"
                                    INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) 
                                    VALUES (@address, @address2, @cityId, @postalCode, @phone, @createDate, @createdBy, @lastUpdate, @lastUpdateBy);
                                    SELECT LAST_INSERT_ID();";

                                MySqlCommand insertAddressCmd = new MySqlCommand(insertAddressQuery, conn, transaction);

                                insertAddressCmd.Parameters.AddWithValue("@address", customerAddress);
                                insertAddressCmd.Parameters.AddWithValue("@address2", customerAddress2);
                                insertAddressCmd.Parameters.AddWithValue("@cityId", cityId);
                                insertAddressCmd.Parameters.AddWithValue("@postalCode", customerPostalCode);
                                insertAddressCmd.Parameters.AddWithValue("@phone", customerPhone);
                                insertAddressCmd.Parameters.AddWithValue("@createDate", currentDateTime.ToString());
                                insertAddressCmd.Parameters.AddWithValue("@createdBy", currentUser);
                                insertAddressCmd.Parameters.AddWithValue("@lastUpdate", currentDateTime.ToString());
                                insertAddressCmd.Parameters.AddWithValue("@lastUpdateBy", currentUser);

                                addressId = Convert.ToInt32(insertAddressCmd.ExecuteScalar());
                            }

                            // step 4: insert customer
                            string insertCustomerQuery = @"
                                INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) 
                                VALUES (@customerName, @addressId, @active, @createDate, @createdBy, @lastUpdate, @lastUpdateBy);";

                            MySqlCommand insertCustomerCmd = new MySqlCommand(insertCustomerQuery, conn, transaction);

                            // set active to true
                            isActive = true;

                            insertCustomerCmd.Parameters.AddWithValue("@customerName", customerName);
                            insertCustomerCmd.Parameters.AddWithValue("@addressId", addressId);
                            insertCustomerCmd.Parameters.AddWithValue("@active", isActive);
                            insertCustomerCmd.Parameters.AddWithValue("@createDate", currentDateTime.ToString());
                            insertCustomerCmd.Parameters.AddWithValue("@createdBy", currentUser);
                            insertCustomerCmd.Parameters.AddWithValue("@lastUpdate", currentDateTime.ToString());
                            insertCustomerCmd.Parameters.AddWithValue("@lastUpdateBy", currentUser);

                            insertCustomerCmd.ExecuteNonQuery();

                            transaction.Commit();

                            MainScreen mainScreen = new MainScreen();
                            mainScreen.Show();
                            Close();
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

        private void AddCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
