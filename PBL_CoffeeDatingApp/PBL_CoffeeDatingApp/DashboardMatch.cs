using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.IO;

namespace PBL_CoffeeDatingApp
{
    public partial class DashboardMatch : Form
    {
        string email = string.Empty;
        List<string> names = new List<string>();
        string genderParam = string.Empty;
        byte[] useImg;
        byte[] partImg;
        bool fromStart = true;


        public DashboardMatch(string emailUsed)
        {
            InitializeComponent();
            email = emailUsed;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Connect to Database
            string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Participants;Integrated Security = True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            //Get the Name to Delete in the Database
            string getItems = "SELECT MatchPartner, AttractionPercent, Notified FROM MatchTable WHERE MatchPartner = @Name;";
            var command = new SqlCommand(getItems, connection);
            SqlParameter param1 = new SqlParameter("@Name", names[0]);
            command.Parameters.Add(param1);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                string partner = reader["MatchPartner"].ToString();
            }
            reader.Close();

            //Delete the name from the Database
            string deleteName = "DELETE FROM MatchTable WHERE MatchPartner = @Name;";
            var delete = new SqlCommand(deleteName, connection);
            SqlParameter param2 = new SqlParameter("@Name", names[0]);
            delete.Parameters.Add(param2);
            delete.ExecuteNonQuery();

            names.Remove(names[0]);
            Thread.Sleep(1000);
            InitializeList(false);
            ShowMatches(names[0]);

        }

        public void InitializeList(bool firstTime)
        {
            //Connect to the Database
            string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Participants;Integrated Security = True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            //Query and Command to Show the Preference of the User
            string checkPreference = "SELECT Preference FROM Participants WHERE Email = @Email;";
            var checkCommand = new SqlCommand(checkPreference, connection);
            SqlParameter param1 = new SqlParameter("@Email", email);
            checkCommand.Parameters.Add(param1);

            var userReader = checkCommand.ExecuteReader();

            while (userReader.Read())
            {
                string genderPreference = userReader["Preference"].ToString();
                genderParam = genderPreference;

            }
            userReader.Close();


            //List the People That User Wants
            string getName = string.Empty;

            if (firstTime)
            {
                //Show select people or just 
                if (genderParam == "B")
                {
                    getName = "SELECT Name FROM Participants WHERE Email IS NULL;";
                }
                else
                {
                    getName = "SELECT Name FROM Participants WHERE Email IS NULL AND Gender = @Gender;";
                }

                //Query and Command to Show the Match
                var showCommand = new SqlCommand(getName, connection);
                SqlParameter param3 = new SqlParameter("@Gender", genderParam);
                showCommand.Parameters.Add(param3);

                var showReader = showCommand.ExecuteReader();

                while (showReader.Read())
                {
                    string fname = showReader["Name"].ToString();

                    names.Add(fname);
                }
                showReader.Close();

                
                foreach (string name in names)
                {
                    Random rn = new Random();
                    int rgn = rn.Next(1, 100);

                    string addName = "INSERT INTO MatchTable VALUES (@Email, @Partner, 0, @Random);";
                    var command = new SqlCommand(addName, connection);
                    SqlParameter param4 = new SqlParameter("@Email", email);
                    SqlParameter param5 = new SqlParameter("@Partner", name);
                    SqlParameter param6 = new SqlParameter("@Random", rgn);
                    command.Parameters.Add(param4);
                    command.Parameters.Add(param5);
                    command.Parameters.Add(param6);

                    command.ExecuteNonQuery();

                }
                

            }
            else
            {
                names.Clear();
                getName = "SELECT MatchPartner FROM MatchTable WHERE UserEmail = @Email;";
                var command = new SqlCommand(getName, connection);
                SqlParameter param11 = new SqlParameter("@Email", email);
                command.Parameters.Add(param11);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader["MatchPartner"].ToString();
                    names.Add(name);

                }
                reader.Close();


            }

            

            
            connection.Close();

        }

        public void ShowMatches(string name)
        {
            string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Participants;Integrated Security = True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string getMatch = "SELECT Name, Surname, Age, Location, Photo FROM Participants WHERE Name = @Name;";

           

            var command = new SqlCommand(getMatch, connection);
            SqlParameter param1 = new SqlParameter("@Name", name);
            command.Parameters.Add(param1);

            var showReader = command.ExecuteReader();

            while (showReader.Read())
            {
                string fname = showReader["Name"].ToString();
                string lname = showReader["Surname"].ToString();
                string location = showReader["Location"].ToString();
                string age = showReader["Age"].ToString();

                label5.Text = fname;
                label1.Text = lname;
                label2.Text = location;
                label3.Text = age;

                byte[] img = (byte[])(showReader["Photo"]);
                MemoryStream ms = new MemoryStream(img);
                pictureBox4.Image = Image.FromStream(ms);
            }

            showReader.Close();
            connection.Close();
        }

        private void ProfileButt_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile(email);
            profile.Show();
            this.Hide();
        }

        private void DashboardMatch_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Participants;Integrated Security = True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            bool newId = true;
            string getName = "SELECT UserEmail FROM MatchTable WHERE UserEmail = @Email;";
            SqlCommand command = new SqlCommand(getName, connection);
            SqlParameter param1 = new SqlParameter("@Email", email);
            command.Parameters.Add(param1);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                string email = reader["UserEmail"].ToString();
                if (email != string.Empty)
                {
                    newId = false;
                }
                else
                {
                    newId = true;
                }
            }
            reader.Close();
            connection.Close();



            InitializeList(newId);
            ShowMatches(names[0]);

        }

        private void MatchButt_Click(object sender, EventArgs e)
        {
            string nameToRemove = string.Empty;
            int proboblity = 0;
            

            //Connect to Database
            string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Participants;Integrated Security = True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            //Get the Name to Delete in the Database
            string getItems = "SELECT MatchPartner, AttractionPercent, Notified FROM MatchTable WHERE MatchPartner = @Name;";
            var command = new SqlCommand(getItems, connection);
            SqlParameter param1 = new SqlParameter("@Name", names[0]);
            command.Parameters.Add(param1);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                string partner = reader["MatchPartner"].ToString();
                string percent = reader["AttractionPercent"].ToString();

                proboblity = int.Parse(percent);
                nameToRemove = partner;
            }
            reader.Close();

            //Delete the name from the Database
            string deleteName = "DELETE FROM MatchTable WHERE MatchPartner = @Name;";
            var delete = new SqlCommand(deleteName, connection);
            SqlParameter param2 = new SqlParameter("@Name", names[0]);
            delete.Parameters.Add(param2);
            delete.ExecuteNonQuery();





            //Get the Image of the User and the Match if they are compatible
            string getUserImage = "SELECT Photo FROM Participants WHERE Email = @Email;";
            string getPartnerImage = "SELECT Photo FROM Participants WHERE Name = @Name;";
            var command1 = new SqlCommand(getUserImage, connection);
            var command2 = new SqlCommand(getPartnerImage, connection);
            SqlParameter param3 = new SqlParameter("@Email", email);
            SqlParameter param4 = new SqlParameter("@Name", names[0]);
            command1.Parameters.Add(param3);
            command2.Parameters.Add(param4);

            var reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                byte[] img = (byte[])(reader1["Photo"]);
                useImg = img;
            }
            reader1.Close();

            var reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                byte[] img = (byte[])(reader2["Photo"]);
                partImg = img;
            }
            reader2.Close();
            connection.Close();



            if(proboblity > 40)
            {
                FoundAMatch foundAMatch = new FoundAMatch(useImg, partImg,email);
                foundAMatch.Show();
                this.Hide();
            }
            else
            {
                names.Remove(names[0]);
                Thread.Sleep(1000);
                InitializeList(false);
                ShowMatches(names[0]);

            }
           

        }
    }
}
