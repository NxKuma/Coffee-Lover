using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace PBL_CoffeeDatingApp
{
    public partial class Profile : Form
    {
        string email = string.Empty;

        public Profile(string emailUsed)
        {
            InitializeComponent();
            email = emailUsed;
        }

        private void DontMatchButt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void custButton1_Click(object sender, EventArgs e)
        {
            DashboardMatch dashboardMatch = new DashboardMatch(email);
            dashboardMatch.Show();
            this.Hide();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            textBox5.Text = email;

            string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Participants;Integrated Security = True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string getItems = "SELECT Name, Surname, Age, Location, Sexuality, Pronouns, Photo FROM Participants WHERE Email = @Email;";
            var command = new SqlCommand(getItems, connection);
            SqlParameter param1 = new SqlParameter("@Email", email);
            command.Parameters.Add(param1);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                string lname = reader["Surname"].ToString();
                label1.Text = lname;

                string location = reader["Location"].ToString();
                label2.Text = location;

                string sex = reader["Sexuality"].ToString();
                label3.Text = sex;

                string age = reader["Age"].ToString();
                label4.Text = age;

                string fname = reader["Name"].ToString();
                label5.Text = fname;

                string pNoun = reader["Pronouns"].ToString();
                label6.Text = pNoun;

                byte[] img = (byte[])(reader["Photo"]);
                MemoryStream ms = new MemoryStream(img);
                circlePicBox1.Image = Image.FromStream(ms);
            }

            reader.Close();
            connection.Close();

        }
    }
}
