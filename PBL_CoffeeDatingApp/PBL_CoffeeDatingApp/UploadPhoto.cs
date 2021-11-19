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
    public partial class Upload_Photo : Form
    {
        string email = string.Empty;
        string imageLocation = "";
        public Upload_Photo(string emailUsed)
        {
            InitializeComponent();
            email = emailUsed;
        }

        private void custButton1_Click(object sender, EventArgs e)
        {
            
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)| *.jpg| PNG files(*.png)| *.png| All Files(*.*)| *.*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    circlePicBox1.ImageLocation = imageLocation;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void custButton2_Click(object sender, EventArgs e)
        {

            if(circlePicBox1.Image != null)
            {
                byte[] img = null;
                FileStream fs = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);

                string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Participants;Integrated Security = True;";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                string upload = "UPDATE Participants SET Photo = @Image WHERE Email = @Email;";
                var command = new SqlCommand(upload, connection);
                SqlParameter param1 = new SqlParameter("@Image", img);
                SqlParameter param2 = new SqlParameter("@Email", email);
                command.Parameters.Add(param1);
                command.Parameters.Add(param2);

                command.ExecuteNonQuery();
                connection.Close();
                custButton2.Enabled = false;

                AskSexulitynInterest askSexulitynInterest = new AskSexulitynInterest(email);
                askSexulitynInterest.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please Submit an Image for your Profile", "No Image Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
