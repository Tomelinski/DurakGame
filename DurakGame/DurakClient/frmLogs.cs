using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DurakClient
{
    public partial class frmGameLogs : Form
    {
        public frmGameLogs()
        {
            InitializeComponent();
        }


        private void btnFind_Click(object sender, EventArgs e)
        {
            string name = txtFind.Text;

            List<string> line = new List<string>();

            using (StreamReader sr = new StreamReader("../../../stats/stats.txt"))
            {
                while (sr.Peek() > -1)
                {
                    string row = sr.ReadLine();
                    if (row != "Name-G-W-L")
                        line.Add(row);

                }
            }

            bool PlayerFound = false;
            string foundUser = "";

            foreach (String user in line)
            {
                if (user != null)
                {

                    if (name == user.Split('-')[0])
                    {
                        foundUser = user;
                        PlayerFound = true;
                        break;
                    }

                }

            }

            if (PlayerFound)
            {
                lblName.Text = foundUser.Split('-')[0].ToString();
                lblGames.Text = foundUser.Split('-')[1].ToString();
                lblWins.Text = foundUser.Split('-')[2].ToString();
                lblLosses.Text = foundUser.Split('-')[3].ToString();
            }
            else
            {
                lblName.Text = String.Empty;
                lblGames.Text = String.Empty;
                lblWins.Text = String.Empty;
                lblLosses.Text = String.Empty;
            }





        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string name = txtDelete.Text;

            List<string> line = new List<string>();

            using (StreamReader sr = new StreamReader("../../../stats/stats.txt"))
            {
                while (sr.Peek() > -1)
                {
                    string row = sr.ReadLine();
                    if (row != "Name-G-W-L")
                        line.Add(row);

                }
            }

            bool PlayerFound = false;
            string foundUser = "";

            foreach (String user in line)
            {
                if (user != null)
                {

                    if (name == user.Split('-')[0])
                    {
                        foundUser = user;
                        PlayerFound = true;
                        break;
                    }

                }

            }

            if (PlayerFound)
            {
                line.Remove(foundUser);

                using (StreamWriter sw = new StreamWriter("../../../stats/stats.txt"))
                {
                    sw.WriteLine("Name-G-W-L");
                    foreach (string row in line)
                    {
                        sw.WriteLine(row);

                    }
                }
            }

            if (name == lblName.Text)
            {
                lblName.Text = String.Empty;
                lblGames.Text = String.Empty;
                lblWins.Text = String.Empty;
                lblLosses.Text = String.Empty;
            }


        }

        private void btnOpenLogs_Click(object sender, EventArgs e)
        {
            string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            path += "/../logs";

            System.Diagnostics.Process.Start(path);
        }

        private void btnOpenStats_Click(object sender, EventArgs e)
        {
            string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            path += "/../stats/stats.txt";

            System.Diagnostics.Process.Start(path);
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtFind_Enter(object sender, EventArgs e)
        {
            txtDelete.Text = String.Empty;
        }

        private void txtDelete_Enter(object sender, EventArgs e)
        {
            txtFind.Text = String.Empty;
        }
    }
}
