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
    public partial class AskSexulitynInterest : Form
    {
        string email = string.Empty;
        public AskSexulitynInterest(string emailUsed)
        {
            InitializeComponent();
            email = emailUsed;

        }

        private void custButton1_Click(object sender, EventArgs e)
        {
            string sexuality = textBox5.Text;
            string pronouns = textBox6.Text;
            string gender = string.Empty;
            char preference = ' ';

            if (custRadioButt1.Checked) preference = 'M';
            if (custRadioButt2.Checked) preference = 'F';
            if (custRadioButt3.Checked) preference = 'B';

            string pronounCheck = pronouns.ToUpper();
            bool male = pronounCheck.Substring(0, pronouns.Length - 1).Contains("HE");
            bool female = pronounCheck.Substring(0, pronouns.Length - 1).Contains("SHE");
            bool nonB = pronounCheck.Substring(0, pronouns.Length - 1).Contains("THEY");

            if (male)
            {
                gender = "M";
            }
            else if (female)
            {
                gender = "F";
            }
            else if (nonB)
            {
                gender = "N";
            }


            string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Participants;Integrated Security = True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string UpDate = "UPDATE Participants SET Preference = @Preference , Gender = @Gender, Pronouns = @Pronouns, Sexuality = @Sexuality WHERE Email = @Email;";

            var command = new SqlCommand(UpDate, connection);
            SqlParameter param1 = new SqlParameter("@Preference", preference); 
            SqlParameter param2 = new SqlParameter("@Gender", gender); 
            SqlParameter param3 = new SqlParameter("@Pronouns", pronouns); 
            SqlParameter param4 = new SqlParameter("@Sexuality", sexuality);
            SqlParameter param5 = new SqlParameter("@Email", email);

            command.Parameters.Add(param1);
            command.Parameters.Add(param2);
            command.Parameters.Add(param3);
            command.Parameters.Add(param4);
            command.Parameters.Add(param5);

            command.ExecuteNonQuery();
            connection.Close();
                                    


            DashboardMatch dashboardMatch = new DashboardMatch(email);
            dashboardMatch.Show();
            this.Hide();
        }
    }
}
