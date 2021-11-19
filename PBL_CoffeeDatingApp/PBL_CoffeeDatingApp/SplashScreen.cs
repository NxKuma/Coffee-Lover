using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL_CoffeeDatingApp
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            StartPage startPage = new StartPage();
            panel2.Width += 3;

            if (panel2.Width >= 636)
            {
                timer1.Stop();
                this.Hide();
                startPage.Show();  
            }
        }
    }
}
