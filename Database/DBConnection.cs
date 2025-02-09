﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliceLyC969.Database
{
    public class DBConnection
    {
        public static MySqlConnection conn { get; set; }

        public MySqlConnection GetConnection()
        {
            // get connection string
            string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            return new MySqlConnection(constr);
        }

        public static void startConnection() 
        {
            try
            {
                // get connection string
                string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
                conn = new MySqlConnection(constr);

                // open the connection
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void closeConnection() 
        {
            // close the connection
            try
            {
                if (conn != null)
                {
                    conn.Close();
                }

                conn = null;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
