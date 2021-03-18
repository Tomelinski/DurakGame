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

            // Hides the Current Form the User is on
            this.Hide();
            ///<summary>
            /// Actual game frm goes in here goes in here
            ///</summary>

            // initializes Start Form
            // frmHowToPlay how2Play = new frmHowToPlay();

            // Show How to Play Form
            // how2Play.ShowDialog();
            this.Show();
        }
    }
}
