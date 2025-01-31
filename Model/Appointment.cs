using AliceLyC969.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliceLyC969.Model
{
    public class Appointment
    {
        public int appointmentId { get; set; }
        public int customerId { get; set; }
        public int userId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public string contact { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string createDate { get; set; }
        public string createdBy { get; set; }
        public string lastUpdate { get; set; }
        public string lastUpdateBy { get; set; }

        BindingList<string> UserNames = new BindingList<string>();

        public DataTable GetAppointmentData()
        {
            DataTable dataTable = new DataTable();

            BindingSource source = new BindingSource();

            DBConnection constr = new DBConnection();

            using (var conn = constr.GetConnection())
            {
                conn.Open();

                string query = "SELECT * FROM appointment";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }

                conn.Close();
            }

            return dataTable;
        }
        
        public void RemoveAppointment(int appointmentId)
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
                            // delete appointment query
                            string deleteApptQuery = @"
                                DELETE FROM appointment
                                WHERE appointmentId = @appointmentId";

                            using (var deleteApptCmd = new MySqlCommand(deleteApptQuery, conn, transaction))
                            {
                                deleteApptCmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                                deleteApptCmd.ExecuteNonQuery();
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
