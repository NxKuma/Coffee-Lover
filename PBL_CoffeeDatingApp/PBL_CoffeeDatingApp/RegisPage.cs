using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace PBL_CoffeeDatingApp
{

    public partial class RegisPage : Form
    {

        public RegisPage()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            LogInPage logInPage = new LogInPage();
            logInPage.Show();
            this.Hide();
        }

        private void custButton1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string newPass = textBox2.Text;
            string confirmPass = textBox7.Text;
            string fName = textBox3.Text;
            string lName = textBox4.Text;
            string location = textBox5.Text;
            string ageString = textBox6.Text;

            bool allCompleted = email != string.Empty && newPass != string.Empty && confirmPass != string.Empty && fName != string.Empty && lName != string.Empty && ageString != string.Empty && location != string.Empty;

            if (allCompleted)
            {
                if(newPass == confirmPass)
                {
                    string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Participants;Integrated Security = True;";
                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();

                    string addParticipant = "INSERT INTO Participants (Name, Surname, Age, Location, Email) VALUES(@Name, @Surname, @Age, @Location,@Email);";
                    string addLogin = "INSERT INTO UserLogIn VALUES (@Email, @Password);";

                    SqlParameter param1 = new SqlParameter("@Name", fName);

                    SqlParameter param2 = new SqlParameter("@Surname", lName);

                    SqlParameter param3 = new SqlParameter("@Age", ageString);
                    
                    SqlParameter param4 = new SqlParameter("@Location", location);
                    
                    SqlParameter param5 = new SqlParameter("@Email", email);

                    SqlParameter param6 = new SqlParameter("@Email", email);
                   
                    SqlParameter param7 = new SqlParameter("@Password", newPass);

                    SqlCommand insertP = new SqlCommand(addParticipant, connection);
                    insertP.Parameters.Add(param1);
                    insertP.Parameters.Add(param2);
                    insertP.Parameters.Add(param3);
                    insertP.Parameters.Add(param4);
                    insertP.Parameters.Add(param5);
                    insertP.ExecuteNonQuery();
                    
                    SqlCommand insertL = new SqlCommand(addLogin, connection);
                    insertL.Parameters.Add(param6);
                    insertL.Parameters.Add(param7);

                    insertP.ExecuteNonQuery();
                    insertL.ExecuteNonQuery();
                    connection.Close();

                    Upload_Photo upload_Photo = new Upload_Photo(email);
                    upload_Photo.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Confirm Password does not match Password entered. Please Try Again", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show("Please Complete the Fields Present.", "Incomplete Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            
        }
    }
}
