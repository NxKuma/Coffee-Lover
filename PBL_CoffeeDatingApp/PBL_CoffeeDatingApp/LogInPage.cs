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
    public partial class LogInPage : Form
    {

        public LogInPage()
        {
            InitializeComponent();
           
        }


        private void RegistPage_Load(object sender, EventArgs e)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialCheckbox1_CheckedChanged(object sender, EventArgs e)
        {
            materialCheckbox1.ForeColor = Color.FromArgb(176, 49, 64);
            if (materialCheckbox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '●';
            }
            //textBox2
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            RegisPage regis = new RegisPage();
            regis.Show();
            this.Hide();
        }

        private void custButton1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string password = textBox2.Text;
              

            if(email == string.Empty && password == string.Empty)
            {
                MessageBox.Show("The Email and/or Password Entered is Invalid. Please try again.", "Log-in Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Participants;Integrated Security = True;";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                string show = "SELECT * FROM UserLogIn;";
                bool match = false;

                SqlCommand select = new SqlCommand(show, connection);
                var reader = select.ExecuteReader();
                while (reader.Read() && !match)
                {
                    string dbEmail = reader["Email"].ToString();
                    string dbPassword = reader["Password"].ToString();

                    if (dbEmail == email && dbPassword == password)
                    {
                        match = true;
                    }

                }
                reader.Close();
                connection.Close();

                if (!match)
                {
                    MessageBox.Show("Email and/or Password is not Recognized. Please try again or Register an Account", "Log-in Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DashboardMatch upload_Photo = new DashboardMatch(email);
                    upload_Photo.Show();
                    this.Hide();
                }




                
            }
            
        }
    }
}
