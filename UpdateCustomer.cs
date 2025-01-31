using AliceLyC969.Database;
using AliceLyC969.Model;
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
    public partial class UpdateCustomer : Form
    {
        ErrorProvider errorProvider = new ErrorProvider();

        private Customer _customer;

        public UpdateCustomer(Customer customer)
        {
            InitializeComponent();

            _customer = customer;

            // display data
            int customerId = _customer.customerId;
            string customerName = _customer.customerName;
            int addressId = _customer.addressId;
            bool active = _customer.active;

            // dates and current user
            var currentDateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            var currentUser = Properties.Settings.Default.userName;

            DBConnection constr = new DBConnection();

            try
            {
                // get customer data
                string customerQuery = @"
                    SELECT c.customerId, c.customerName, a.address, a.address2, a.postalCode, a.phone, ci.city, co.country FROM customer c
                    JOIN address a ON c.addressId = a.addressId
                    JOIN city ci ON a.cityId = ci.cityId
                    JOIN country co ON ci.countryId = co.countryId
                    WHERE c.customerId = @customerId AND c.customerName = @customerName AND a.addressId = @customerAddressId;";

                using (var conn = constr.GetConnection())
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand(customerQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                        cmd.Parameters.AddWithValue("@customerName", customerName);
                        cmd.Parameters.AddWithValue("@customerAddressId", addressId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // get data
                                string address = reader["address"].ToString();
                                string address2 = reader["address2"].ToString();
                                string city = reader["city"].ToString();
                                string country = reader["country"].ToString();
                                string postalCode = reader["postalCode"].ToString();
                                string phone = reader["phone"].ToString();

                                // insert data into fields
                                customerNameField.Text = customerName.ToString();
                                customerAddressField.Text = address.ToString();
                                customerAddress2Field.Text = address2.ToString();
                                customerCityField.Text = city.ToString();
                                customerCountryField.Text = country.ToString();
                                customerPostalCodeField.Text = postalCode.ToString();
                                customerPhoneField.Text = phone.ToString();
                            }
                            else
                            {
                                Console.WriteLine("Customer not found.");
                            }
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
            int customerId = _customer.customerId;
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

            try
            {
                using (var conn = constr.GetConnection())
                {
                    conn.Open();

                    using (var transaction = conn.BeginTransaction()) { 
                        try
                        {
                            // step 1: update country

                            // find country query
                            string findCountryQuery = @"
                                SELECT countryId FROM country WHERE country = @country;";

                            MySqlCommand findCountryCmd = new MySqlCommand(findCountryQuery, conn, transaction);

                            findCountryCmd.Parameters.AddWithValue("@country", customerCountry);

                            object countryIdObj = findCountryCmd.ExecuteScalar();

                            int countryId;
                            if (countryIdObj != null)
                            {
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

                            // step 2: update city

                            // find city query
                            string findCityQuery = @"
                                SELECT cityId FROM city WHERE city = @city AND countryId = @countryId";

                            MySqlCommand findCityCmd = new MySqlCommand(findCityQuery, conn, transaction);

                            findCityCmd.Parameters.AddWithValue("@city", customerCity);
                            findCityCmd.Parameters.AddWithValue("@countryId", countryId);

                            object cityIdObj = findCityCmd.ExecuteScalar();

                            int cityId;
                            if (cityIdObj != null)
                            {
                                // city exists
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

                            // step 3: update address

                            int addressId;
                            // find address query
                            string findAddressQuery = @"
                                SELECT addressId FROM customer WHERE customerId = @customerId";

                            using (var findAddressCmd = new MySqlCommand(findAddressQuery, conn, transaction))
                            {
                                findAddressCmd.Parameters.AddWithValue("@customerId", customerId);

                                object addressIdObj = findAddressCmd.ExecuteScalar();

                                if (addressIdObj == null) {
                                    throw new Exception("Customer not found.");
                                }
                                addressId = Convert.ToInt32(addressIdObj);
                            }

                            // update address query
                            string updateAddressQuery = @"
                                UPDATE address 
                                SET address = @address, address2 = @address2, cityId = @cityId, postalCode = @postalCode, phone = @phone, lastUpdate = @lastUpdate, lastUpdateBy = @lastUpdateBy
                                WHERE addressId = @addressId;";

                            using (var updateAddressCmd = new MySqlCommand(updateAddressQuery, conn, transaction))
                            {
                                updateAddressCmd.Parameters.AddWithValue("addressId", addressId);
                                updateAddressCmd.Parameters.AddWithValue("@address", customerAddress);
                                updateAddressCmd.Parameters.AddWithValue("@address2", customerAddress2);
                                updateAddressCmd.Parameters.AddWithValue("@cityId", cityId);
                                updateAddressCmd.Parameters.AddWithValue("@postalCode", customerPostalCode);
                                updateAddressCmd.Parameters.AddWithValue("@phone", customerPhone);
                                updateAddressCmd.Parameters.AddWithValue("@lastUpdate", currentDateTime.ToString());
                                updateAddressCmd.Parameters.AddWithValue("@lastUpdateBy", currentUser);

                                updateAddressCmd.ExecuteNonQuery();
                            }

                            // step 4: update customer
                            string updateCustomerQuery = @"
                                UPDATE customer
                                SET customerName = @customerName, addressId = @addressId, active = active, lastUpdate = @lastUpdate, lastUpdateBy = @lastUpdateBy
                                WHERE customerId = @customerId;";

                            // set active to true
                            isActive = true;

                            using (var updateCustomerCmd = new MySqlCommand(updateCustomerQuery, conn, transaction))
                            {
                                updateCustomerCmd.Parameters.AddWithValue("@customerId", customerId);
                                updateCustomerCmd.Parameters.AddWithValue("@customerName", customerName);
                                updateCustomerCmd.Parameters.AddWithValue("@addressId", addressId);
                                updateCustomerCmd.Parameters.AddWithValue("@active", isActive);
                                updateCustomerCmd.Parameters.AddWithValue("@lastUpdate", currentDateTime.ToString());
                                updateCustomerCmd.Parameters.AddWithValue("@lastUpdateBy", currentUser);

                                updateCustomerCmd.ExecuteNonQuery();
                            }

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
    }
}
