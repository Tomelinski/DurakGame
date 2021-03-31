using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DurakGame
{
    public partial class frmHowToPlay : Form
    {
        public frmHowToPlay()
        {
            InitializeComponent();
        }
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            // Hides the Current Form the User is on
            Hide();

            // initializes Start Form
            frmDurakMainMenu mainMenu = new frmDurakMainMenu();

            // Show Start Form
            mainMenu.ShowDialog();
            this.Show();
        }


        private void frmHowToPlay_Load(object sender, EventArgs e)
        {
            string videoLink = "https://youtu.be/hQHW_CuGG2A";

            try
            {
                System.Diagnostics.Process.Start(videoLink);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error redirecting to help video. Please see this link for the video: https://youtu.be/hQHW_CuGG2A.");
            }
        }
    }
}
