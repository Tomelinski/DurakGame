/* Program.cs - 
 *         
 * Author(s): Aadithkeshev Anushayamunaithuraivan,
 *            Menushan Karunakaran,
 *            Calvin May,
 *            Tom Zielinski
 *            
 * Date: 02/27/2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLibrary;
using PlayerLibrary;
using DurakGame;

namespace DurakGame
{


    class Program
    {
        static void Main(string[] args)
        {
            // Start the Durak Game
            DurakGame.StartGame();



            //Task myTask = Task.Run(() => { frmDurakMainMenu form = new frmDurakMainMenu(); form.ShowDialog(); });

           

            Console.ReadKey();
        }
    }
}
