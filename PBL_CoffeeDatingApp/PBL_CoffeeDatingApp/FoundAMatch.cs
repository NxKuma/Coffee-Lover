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
    public partial class FoundAMatch : Form
    {
        string email = string.Empty;
        byte[] userImg;
        byte[] partImg;

        public FoundAMatch(byte[] userImage, byte[] matchImage, string emailUsed)
        {
            InitializeComponent();
            userImg = userImage;
            partImg = matchImage;
            email = emailUsed;
        }

        private void FoundAMatch_Load(object sender, EventArgs e)
        {

            MemoryStream userM = new MemoryStream(userImg);
            MemoryStream partM = new MemoryStream(partImg);


            circlePicBox1.Image = Image.FromStream(userM);
            circlePicBox2.Image = Image.FromStream(partM);
        }

        private void custButton1_Click(object sender, EventArgs e)
        {
            DashboardMatch dashboard = new DashboardMatch(email);
            dashboard.Show();
            this.Hide();
        }
    }
}
