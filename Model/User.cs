using AliceLyC969.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceLyC969.Model
{
    public class User
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public bool active { get; set; }
        public string createdBy { get; set; }
        public string updatedBy { get; set; }

        BindingList<int> UserIDs = new BindingList<int>();

        public int GetUserID(string userName)
        {
            int userId = 0;

            DBConnection constr = new DBConnection();

            using (var conn = constr.GetConnection())
            {
                conn.Open();

                string query = @"SELECT userId 
                FROM user 
                WHERE userName = @userName";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userName", userName);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) {
                        userId = reader.GetInt32("userId");
                    }
                    else
                    {
                        Console.WriteLine("User not found.");
                    }
                }

                conn.Close();
            }

            return userId;
        }

        public BindingList<int> GetUserIDs()
        {
            DBConnection constr = new DBConnection();

            using (var conn = constr.GetConnection())
            {
                conn.Open();

                string query = "SELECT userId FROM user";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        UserIDs.Add(reader.GetInt32("userId"));
                    }
                }

                conn.Close();
            }

            return UserIDs;
        }
    }
}
