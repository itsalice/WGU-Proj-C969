using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.IO;
using AliceLyC969.Model;
using System.Diagnostics;
using System.Data.Common;
using AliceLyC969.Database;
using System.ComponentModel;

namespace AliceLyC969
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.Contains("fr"))
            {
                userLoginLabel.Text = "Connexion de l’utilisateur";
                loginUserField.Text = "Nom d’utilisateur";
                loginPasswordField.Text = "Mot de passe";
                loginButton.Text = "Se connecter";
                exitButton.Text = "Sortie";
                timeZone.Text = CultureInfo.CurrentCulture.DisplayName;
            }
            else
            {
                userLoginLabel.Text = "User Login";
                loginUserField.Text = "Username";
                loginPasswordField.Text = "Password";
                loginButton.Text = "Login";
                exitButton.Text = "Exit";
                timeZone.Text = CultureInfo.CurrentCulture.DisplayName;
            }
        }

        private void appointmentReminder()
        {
            DBConnection constr = new DBConnection();

            DateTime currentDateTime = DateTime.Now;
            BindingList<Appointment> appointmentList = new BindingList<Appointment>();

            try
            {
                using (var conn = constr.GetConnection())
                {
                    conn.Open();

                    // find user query
                    string findUserQuery = @"SELECT userId FROM user
                        WHERE username = @userName";

                    MySqlCommand findUserCmd = new MySqlCommand(findUserQuery, conn);

                    findUserCmd.Parameters.AddWithValue("@userName", loginUserField.Text);

                    int userId = Convert.ToInt32(findUserCmd.ExecuteScalar());

                    // find appointment query
                    string findAppointmentQuery = @"SELECT * FROM appointment
                        WHERE userId = @userId";

                    MySqlCommand findAppointmentCmd = new MySqlCommand(findAppointmentQuery, conn);

                    findAppointmentCmd.Parameters.AddWithValue("@userId", userId);
                    findAppointmentCmd.ExecuteNonQuery();

                    using (MySqlDataReader reader = findAppointmentCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            appointmentList.Add(new Appointment()
                            {
                                customerId = Convert.ToInt32(reader["customerId"]),
                                title = reader["title"].ToString(),
                                description = reader["description"].ToString(),
                                location = reader["location"].ToString(),
                                contact = reader["contact"].ToString(),
                                type = reader["type"].ToString(),
                                url = reader["url"].ToString(),
                                start = reader["start"].ToString(),
                                end = reader["end"].ToString(),
                            });
                        }
                    }


                    if (appointmentList.Count > 0)
                    {
                        foreach (var appointment in appointmentList)
                        {
                            TimeSpan nowUntilAppt = currentDateTime - DateTime.Parse(appointment.start).ToLocalTime();

                            if (nowUntilAppt.TotalMinutes >= -15 && nowUntilAppt.TotalMinutes < 1)
                            {
                                MessageBox.Show($"You have an upcoming appointment with {appointment.contact} at {DateTime.Parse(appointment.start).ToLocalTime()}.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private void userLoginLabelChanged(object sender, EventArgs e)
        {
            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.Contains("fr"))
            {
                userLoginLabel.Location = new Point(250, 119);
                loginButton.Location = new Point(330, 263);
                timeZone.Location = new Point(330, 354);
            }
        }

        private void loginButtonClicked(object sender, EventArgs e)
        {
            DateTime currentDateTime = DateTime.Now;

            // LAMBDA FUNCTION - to log user activity in a text file
            // only used in the loginButtonClicked event so no need to make a function outside this one
            Action<string, string> logUserActivity = (message, userName) =>
            {
                // set log path
                string path = "Login_History.txt";

                if (!File.Exists(path))
                {
                    using (StreamWriter streamWriter = File.CreateText(path))
                    {
                        streamWriter.WriteLine(message);
                    }
                }

                using (StreamWriter streamWriter = File.AppendText(path))
                {
                    streamWriter.WriteLine(message);
                }
            };

            // get connection string
            string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(constr);

            // set error message
            string userErrorFr = "Le nom d’utilisateur et le mot de passe ne correspondent pas.";
            string UserErrorEn = "The username and password do not match.";

            try
            {
                string sql = "SELECT userName FROM user WHERE userName=@userName AND password=@password";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add("@userName", MySqlDbType.VarChar, 50).Value = loginUserField.Text;
                cmd.Parameters.Add("@password", MySqlDbType.VarChar, 50).Value = loginPasswordField.Text;

                // open the connection
                conn.Open();

                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    // log successful login
                    string successMessage = $"User {loginUserField.Text} has logged in at {currentDateTime}.";
                    logUserActivity(successMessage, loginUserField.Text);

                    Properties.Settings.Default.userName = loginUserField.Text;
                    Properties.Settings.Default.Save();
                    appointmentReminder();

                    MainScreen mainScreen = new MainScreen();
                    mainScreen.Show();
                    Hide();
                }
                else
                {
                    if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.Contains("fr"))
                    {
                        MessageBox.Show(userErrorFr);
                    }
                    else
                    {
                        MessageBox.Show(UserErrorEn);
                    }

                    // log failed login
                    string failedMessage = $"Failed login attempt with user {loginUserField.Text} at {currentDateTime}.";
                    logUserActivity(failedMessage, loginUserField.Text);
                }

                // close the connection
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
        }

        private void exitButtonClick(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
