/* frmLogs.cs - Entry Point for the Durak CLient App. It Calls the Application.Run()
 *            method to create a new instance of the Main Menu Form
 *         
 * Author(s): Aadithkeshev Anushayamunaithuraivan,
 *            Menushan Karunakaran,
 *            Calvin May,
 *            Tom Zielinski
 *            
 * Last Modified: 04/15/2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DurakClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmDurakMainMenu());    // Main Menu!
        }
    }
}
