using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DurakClient
{
    using System.Windows.Forms;


    
    public partial class frmDurakMainMenu : Form
    {
        public frmDurakMainMenu()
        {
            InitializeComponent();

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            // Hides the Current Form the User is on
            Hide();

            // initializes Start Form
            frmStartMenu start = new frmStartMenu();

            // Show Start Form
            start.ShowDialog();
            this.Show();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnHowToPlay_Click(object sender, EventArgs e)
        {
            string videoLink = "https://youtu.be/hQHW_CuGG2A";

            try
            {
                System.Diagnostics.Process.Start(videoLink);
            }
            catch (Exception)
            {
                MessageBox.Show("Error redirecting to help video. Please see this link for the video: https://youtu.be/hQHW_CuGG2A.");
            }

        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// Logs  and statistics go in here. Under Construction
            /// </summary>
        }
    }
}
