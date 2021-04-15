/* frmLogs.cs - This Form allows users to access Logs and Statistics.
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
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace DurakClient
{
    public partial class frmGameLogs : Form
    {
        public frmGameLogs()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event for a Player Clicking the Find Button to search
        /// for a player stored in statistics
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFind_Click(object sender, EventArgs e)
        {
            // Store the name entered by the user
            string name = txtFind.Text;

            // Create a list to hold all players in statistics
            List<string> line = new List<string>();

            // Read the log File, storing the Players in the List
            using (StreamReader sr = new StreamReader("../../../stats/stats.txt"))
            {
                // While not at end of file
                while (sr.Peek() > -1)
                {
                    string row = sr.ReadLine();
                    if (row != "Name-G-W-L")
                        line.Add(row);

                }
            }

            // By default we have not found a User
            bool PlayerFound = false;
            string foundUser = "";

            // Loop through each user in the Stats File
            foreach (String user in line)
            {
                if (user != null)
                {
                    // IF we Find a matching User
                    if (name == user.Split('-')[0])
                    {
                        // Record the User
                        foundUser = user;
                        PlayerFound = true;
                        break;
                    }
                }
            }

            // If we Found the User
            if (PlayerFound)
            {
                // Display their information
                lblName.Text = foundUser.Split('-')[0].ToString();
                lblGames.Text = foundUser.Split('-')[1].ToString();
                lblWins.Text = foundUser.Split('-')[2].ToString();
                lblLosses.Text = foundUser.Split('-')[3].ToString();
            }
            // Otherwise,
            else
            {
                // Empty all Display Text
                lblName.Text = String.Empty;
                lblGames.Text = String.Empty;
                lblWins.Text = String.Empty;
                lblLosses.Text = String.Empty;
            }





        }

        /// <summary>
        /// Event Handler for when the Delete Button is CLicked.
        /// IT deletes the Player whose name is entered by the User,
        /// and who exists in the statistics log.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {

            // Store the Entered name
            string name = txtDelete.Text;

            // Create a list to hold all players in statistics
            List<string> line = new List<string>();

            // Read the stats File, storing the Players in the List
            using (StreamReader sr = new StreamReader("../../../stats/stats.txt"))
            {
                // While not at end of file
                while (sr.Peek() > -1)
                {
                    // Keep reading/storing
                    string row = sr.ReadLine();
                    if (row != "Name-G-W-L")
                        line.Add(row);

                }
            }

            // Set playerFound to false by default
            bool PlayerFound = false;
            string foundUser = "";

            // Loop through each user retrieved from the file
            foreach (String user in line)
            {
                if (user != null)
                {
                    // If the User entered name matches one from the file
                    if (name == user.Split('-')[0])
                    {
                        // Retrieve the User
                        foundUser = user;
                        PlayerFound = true;
                        break;
                    }
                }
            }

            // IF we Found a matching player
            if (PlayerFound)
            {
                // Remove it from the lsit
                line.Remove(foundUser);

                // Write back to the file with the current list
                using (StreamWriter sw = new StreamWriter("../../../stats/stats.txt"))
                {
                    sw.WriteLine("Name-G-W-L");
                    foreach (string row in line)
                    {
                        sw.WriteLine(row);

                    }
                }
            }

            // Clear the Displayed Stats info, if we deleted that player
            if (name == lblName.Text)
            {
                lblName.Text = String.Empty;
                lblGames.Text = String.Empty;
                lblWins.Text = String.Empty;
                lblLosses.Text = String.Empty;
            }

        }

        /// <summary>
        /// Event Handler for the Open Logs Button. Simple opens the Log File.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenLogs_Click(object sender, EventArgs e)
        {
            // Set the Path to the file
            string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            path += "/../logs";

            // Open the File
            System.Diagnostics.Process.Start(path);
        }

        /// <summary>
        /// Event Handler for the Open Statistics button. Simple opens the Statistics File.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenStats_Click(object sender, EventArgs e)
        {
            // Set the Path to the file
            string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            path += "/../stats/stats.txt";

            // Open the File
            System.Diagnostics.Process.Start(path);
        }

        /// <summary>
        /// Back Button Event Handler. Closes this Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Find Textbox Gets Focus Event handler. QOL to remove text from opposing textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFind_Enter(object sender, EventArgs e)
        {
            txtDelete.Text = String.Empty;
        }

        /// <summary>
        /// Delete Textbox Gets Focus Event handler. QOL to remove text from opposing textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDelete_Enter(object sender, EventArgs e)
        {
            txtFind.Text = String.Empty;
        }
    }
}
