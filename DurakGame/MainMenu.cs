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
            // Hides the Current Form the User is on
            Hide();

            // initializes Start Form
            frmHowToPlay how2Play = new frmHowToPlay();

            // Show How to Play Form
            how2Play.ShowDialog();
            this.Show();

        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// Logs  and statistics go in here. Under Construction
            /// </summary>
        }
    }
}
