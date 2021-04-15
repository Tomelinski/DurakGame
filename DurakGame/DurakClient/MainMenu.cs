/* MainMenu.cs - This is the Main Menu of the Durak APP. Allows the User to select from several options
 *             such as playing the game, Quiting, A Showcase of how the Application Functions as well as an
 *             option to view Logs and Player Statistics.
 *         
 * Author(s): Aadithkeshev Anushayamunaithuraivan,
 *            Menushan Karunakaran,
 *            Calvin May,
 *            Tom Zielinski
 *            
 * Last Modified: 04/15/2021
 */

// Imports
using System;

namespace DurakClient
{
    using System.Windows.Forms;


    
    public partial class frmDurakMainMenu : Form
    {
        public frmDurakMainMenu()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Event for Handling the Play Button CLick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            // Hides the Current Form the User is on
            Hide();

            // initializes Start Menu Form
            frmStartMenu start = new frmStartMenu();

            // Show Start Form & Waits for it to close
            start.ShowDialog();
            //-Before reshowing this form
            this.Show();
        }

        /// <summary>
        /// Event For the Quit Button Click. This Closes the Application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Event for the Showcase Button. Links to a video that showcases
        /// this app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHowToPlay_Click(object sender, EventArgs e)
        {
            // Get the link to the video
            string videoLink = "https://youtu.be/hQHW_CuGG2A";

            // Watch for Exceptions
            try
            {
                // Go to the Video
                System.Diagnostics.Process.Start(videoLink);
            }
            catch (Exception)
            {
                // Show a Messagebox that provides the link instead
                MessageBox.Show("Error redirecting to help video. Please see this link for the video: https://youtu.be/hQHW_CuGG2A.");
            }

        }

        /// <summary>
        /// Event for a Log button click. This will bring the User to the Log form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogs_Click(object sender, EventArgs e)
        {

            // Hides the Current Form the User is on
            Hide();

            // initializes Log Form
            frmGameLogs frmLog = new frmGameLogs();

            // Show Start Form, and pause here until it closes
            frmLog.ShowDialog();

            // Reshow this form
            this.Show();
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            // Get the link to the video
            string videoLink = "https://youtu.be/zwMPQAsCNX4";

            // Watch for Exceptions
            try
            {
                // Go to the Video
                System.Diagnostics.Process.Start(videoLink);
            }
            catch (Exception)
            {
                // Show a Messagebox that provides the link instead
                MessageBox.Show("Error redirecting to help video. Please see this link for the video: https://youtu.be/zwMPQAsCNX4.");
            }
        }
    }
}
