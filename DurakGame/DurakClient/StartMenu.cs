/* StartMenu.cs - This is the Start Menu Form. This is the Predecessor to the Actual Durak Game Form.
 *              This form allows the User to select a few options regarding the Type of Durak Game
 *              they want to play. We had planned to include more than 2 players, as well as player vs
 *              player but that did not make it into the final release (Notice the options are greyed out).
 *              However, a Player can choose between a 20, 36, and 52 sized Deck of Cards.
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
using System.Windows.Forms;

namespace DurakClient
{
    public partial class frmStartMenu : Form
    {
        public frmStartMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event Handler for the Start Button being Clicked.
        /// This simply grabs all the selected values and creates a
        /// new instance of the Durak Game for th Player.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            int playerNum;
            int deckSize;


            // Radio Button Selection
            if(rdb2Players.Checked)         // Game with 2 Players
            {
                playerNum = 2;
            }
            else if(rdb3Players.Checked)    // Game with 3 Players (Not Selectable)
            {
                playerNum = 3;
            }
            else                            // Game with 4 Players (Not Selectable)
            {
                playerNum = 4;
            }

            if (rdbDeck20.Checked)          // Game with Deck Size of 20
            {
                deckSize = 20;
            }
            else if (rdbDeck36.Checked)     // Game with Deck Size of 36
            {
                deckSize = 36;             
            }
            else                            // Game with Deck Size of 36
            {
                deckSize = 52;
            }
            // Hides the Current Form the User is on
            this.Hide();
            // Create the New Game Instance
            frmDurak game = new frmDurak(deckSize, playerNum, txtPlayerName.Text);
            // Wait for it to close
            game.ShowDialog();
            // Then reshow the form
            this.Show();
        }
    }
}
