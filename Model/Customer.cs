using AliceLyC969.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace AliceLyC969.Model
{
    public class Customer
    {
        public int customerId { get; set; }
        public string customerName { get; set; }
        public int addressId { get; set; }
        public bool active { get; set; }
        public string createDate { get; set; }
        public string createdBy { get; set; }
        public string lastUpdate { get; set; }
        public string lastUpdateBy { get; set; }

        BindingList<string> CustomerNames = new BindingList<string>();

        public DataTable GetCustomerData()
        {
            DataTable dataTable = new DataTable();

            BindingSource source = new BindingSource();

            DBConnection constr = new DBConnection();

            using (var conn = constr.GetConnection())
            {
                conn.Open();

                string query = "SELECT c.customerId, c.customerName, c.addressId, c.active, c.createDate, c.createdBy, c.lastUpdate, c.lastUpdateBy, a.address, a.address2, a.postalCode, a.phone, ci.city, co.country FROM customer c JOIN address a ON c.addressId = a.addressId JOIN city ci ON a.cityId = ci.cityId JOIN country co ON ci.countryId = co.countryId;";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }

                conn.Close();
            }

            return dataTable;
        }

        public BindingList<string> GetCustomerName()
        {
            DBConnection constr = new DBConnection();

            using (var conn = constr.GetConnection())
            {
                conn.Open();

                string query = "SELECT customerName FROM customer";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CustomerNames.Add(reader.GetString("customerName"));
                    }
                }

                conn.Close();
            }

            return CustomerNames;
        }

        public void RemoveCustomer(int customerId)
        {
            DBConnection constr = new DBConnection();

            try
            {
                using (var conn = constr.GetConnection())
                {
                    conn.Open();

                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // step 0: delete appointment associated with the customer
                            string deleteAppointmentQuery = @"
                                DELETE FROM appointment
                                WHERE customerId = @customerId";

                            using (var deleteAppointmentCmd = new MySqlCommand(deleteAppointmentQuery, conn, transaction))
                            {
                                deleteAppointmentCmd.Parameters.AddWithValue("@customerId", customerId);
                                deleteAppointmentCmd.ExecuteNonQuery();
                            }

                            // step 1: find address

                            // find address query
                            int addressId;
                            string findAddressQuery = @"
                                SELECT addressId FROM customer 
                                WHERE customerId = @customerId";

                            using (var findAddressCmd = new MySqlCommand(findAddressQuery, conn, transaction))
                            {
                                findAddressCmd.Parameters.AddWithValue("@customerId", customerId);

                                object addressIdObj = findAddressCmd.ExecuteScalar();

                                if (addressIdObj == null)
                                {
                                    throw new Exception("Customer not found.");
                                }
                                addressId = Convert.ToInt32(addressIdObj);
                            }

                            // step 2: delete customer
                            string deleteCustomerQuery = @"
                                DELETE FROM customer
                                WHERE customerId = @customerId";

                            using (var deleteCustomerCmd = new MySqlCommand(deleteCustomerQuery, conn, transaction))
                            {
                                deleteCustomerCmd.Parameters.AddWithValue("@customerId", customerId);
                                deleteCustomerCmd.ExecuteNonQuery();
                            }

                            // delete address query
                            string deleteAddressQuery = @"
                                DELETE FROM address
                                WHERE addressId = @addressId";

                            using (var deleteAddressCmd = new MySqlCommand(deleteAddressQuery, conn, transaction))
                            {
                                deleteAddressCmd.Parameters.AddWithValue("addressId", addressId);

                                deleteAddressCmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
