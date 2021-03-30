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
    public partial class frmStartMenu : Form
    {
        public frmStartMenu()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int playerNum;
            int deckSize;
            
            // Radio Button Selection
            if(rdb2Players.Checked)
            {
                playerNum = 2;
            }
            else if(rdb3Players.Checked)
            {
                playerNum = 3;
            }
            else
            {
                playerNum = 4;
            }

            if (rdbDeck20.Checked)
            {
                deckSize = 20;
            }
            else if (rdbDeck36.Checked)
            {
                deckSize = 36;
            }
            else
            {
                deckSize = 52;
            }
            // Hides the Current Form the User is on
            this.Hide();
            frmDurak game = new frmDurak(playerNum, deckSize);
            game.ShowDialog();
            ///<summary>
            /// Actual game frm goes in here goes in here. Under Construction. *********Need to  discuss this *********
            ///</summary>

            // initializes Start Form
            // frmHowToPlay how2Play = new frmHowToPlay();

            // Show How to Play Form
            // how2Play.ShowDialog();
            this.Show();
        }
    }
}
