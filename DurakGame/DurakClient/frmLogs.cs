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
    public partial class frmGameLogs : Form
    {
        public frmGameLogs()
        {
            InitializeComponent();
        }

        //private void frmWriteLog_Closing(object sender, FormClosingEventArgs e)
        //{
        //    Logs.WriteGameStat(txtLogs.Text);
        //    if (e.CloseReason == CloseReason.UserClosing)
        //    {
        //        e.Cancel = true;
        //        Hide();
        //    }
        //}

        //public void WriteLog(string gameLog)
        //{
        //    if (!txtLogs.IsDisposed)
        //        txtLogs.AppendText(gameLog + "\n");
        //}
    }
}
